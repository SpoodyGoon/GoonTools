/*
 * 
 * Created By: SpoodyGoon
 * Date: 8/1/2008
 * Time: 8:17 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Text;
using System.Configuration;
using System.Web.Services;
using SQLiteDataProvider;

namespace BookmarkSharpWebService
{
	
	/// <summary>
	/// Description of BookmarkSharp
	/// </summary>
	[WebService
	 (
	 	Name = "BookmarkSharp",
	 	Description = "BookmarkSharp",
	 	Namespace = "http://tempuri.org/"
	 )
	]
	public class BookmarkSharp : WebService
	{
		private bool _LoggedIn = false;
		private Hashtable hshImportIDs = new Hashtable();
		[WebMethod]
		public void Login(string strPassword)
		{
			ValidateUser(strPassword);
		}

		private void ValidateUser(string strPassword)
		{
			DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
			_LoggedIn = dp.ExecuteHasRows("SELECT SecurityID FROM tb_Security WHERE Password = '" + strPassword + "';");
			dp.Dispose();
		}
		
		/// <summary>
		///  duing the log in process
		///  if it fails it will simply return false
		///  if is success it will return true and the times
		///  the database was last updated
		/// </summary>
		/// <param name="strPassword"></param>
		/// <returns></returns>
		[WebMethod]
		public DataSet LastUpdateGet()
		{
			DataSet ds = new DataSet("dsLastUpdate");
			if(_LoggedIn == true)
			{
				// when the login is successful return true, the last connected, last time tags where update and the last time bookmarks were updated
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT ");
				sb.Append("CASE WHEN T.TagUpdate IS NULL THEN strftime(\"%m-%d-%Y %H:%M:%S\", 'NOW' , 'localtime') ELSE strftime(\"%m-%d-%Y %H:%M:%S\", T.TagUpdate) END AS TagUpdate, ");
				sb.Append("CASE WHEN B.BookmarkUpdate IS NULL THEN strftime(\"%m-%d-%Y %H:%M:%S\", 'NOW', 'localtime') ELSE strftime(\"%m-%d-%Y %H:%M:%S\", B.BookmarkUpdate) END AS BookmarkUpdate FROM ");
				sb.Append("(SELECT MAX(UpdateDate) AS TagUpdate FROM tb_UpdateLog WHERE UpdateItemID = 2) T ");
				sb.Append("CROSS JOIN ");
				sb.Append("(SELECT MAX(UpdateDate) AS BookmarkUpdate FROM tb_UpdateLog WHERE UpdateItemID = 1) B ;");
				DataTable dt = dp.ExecuteDataTable(sb.ToString());
				dp.Dispose();
				ds.Tables.Add(dt);
			}
			return ds;
		}
		
		#region "Bookmarks"
		
		[WebMethod]
		public string AddBookmark(string strTitle, string strURL, string strIsFolder, string strPathDepth, string strParentID)
		{
			string strReturn = null;
			if(_LoggedIn == true)
			{
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				strReturn = dp.ExecuteScalar("INSERT INTO tb_BookMarks(Title, URL, IsFolder, PathDepth, ParentID)VALUES('" + strTitle + "', '" + strURL + "', '" + strIsFolder + "', " + strPathDepth + ", " + strParentID + ");", true);
				dp.Dispose();
			}
			return strReturn;
		}
		
		[WebMethod]
		public void UpdateBookmark(string strBookmarkID, string strTitle, string strURL, string strIsFolder, string strPathDepth, string strParentID)
		{
			if(_LoggedIn == true)
			{
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				dp.ExecuteNonQuery("UPDATE tb_BookMarks SET Title = '" + strTitle + "', URL = '" + strURL + "', IsFolder = '" + strIsFolder + ", PathDepth = " + strPathDepth + ", ParentID = " + strParentID + " WHERE BookmarkID = " + strBookmarkID + ";");
				dp.Dispose();
			}
		}

		[WebMethod]
		public DataSet GetBookMarks()
		{
			if (_LoggedIn == true)
			{
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				DataTable dtBookmarks = dp.ExecuteDataTable("SELECT BookmarkID, Title, IsFolder, URL, ParentID, PathDepth FROM tb_BookMarks ORDER BY PathDepth, ParentID;", "dtBookmarks");
				DataSet dsBookmarks = new DataSet("dsBookmarks");
				dsBookmarks.Tables.Add(dtBookmarks);
				dp.Dispose();
				return dsBookmarks;
			}
			else
			{
				return new DataSet("Error");
			}
		}
		
		#endregion "Bookmarks"
		
		#region "Tags"
		
		[WebMethod]
		public DataSet GetTags()
		{
			if (_LoggedIn == true)
			{
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				DataTable dtTags = dp.ExecuteDataTable("SELECT TagID, TagName FROM tb_Tags", "dtTags");
				DataSet dsBookmarks = new DataSet("dsBookmarks");
				dsBookmarks.Tables.Add(dtTags);
				dp.Dispose();
				return dsBookmarks;
			}
			else
			{
				return new DataSet();
			}
		}
		
		[WebMethod]
		public string AddTag(string strTagName)
		{
			string strReturn = null;
			if(_LoggedIn == true)
			{
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				strReturn = dp.ExecuteScalar("INSERT INTO tb_Tags(TagName)VALUES('" + strTagName + "';", true);
				dp.Dispose();
			}
			return strReturn;
		}
		
		[WebMethod]
		public string UpdateTag(string strTagID, string strTagName)
		{
			string strReturn = null;
			if(_LoggedIn == true)
			{
				DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
				strReturn = dp.ExecuteScalar("UPDATE tb_Tags SET TagName = '" + strTagName + "' WHERE TagID = " + strTagID + ";");
				dp.Dispose();
			}
			return strReturn;
		}
		
		#endregion "Tags"
		
		#region "Import"
		
		[WebMethod]
		public bool ImportDataTable(DataTable dt)
		{
			bool blnImportSuccess = true;
			string strSQL = null;
			string strTMPID = null;
			DataProvider dp = new DataProvider(ConfigurationManager.AppSettings["ConnString"].ToString());
			bool blnFoundRows = true;
			int intDepth = 0;
			DataRow[] drFilter = null;
			try
			{
				if(_LoggedIn == true)
				{
					while(blnFoundRows == true)
					{
						drFilter = dt.Select("PathDepth = " + intDepth.ToString());
						for(int i = 0; i < drFilter.Length; i++)
						{
							strSQL = "INSERT INTO tb_Bookmarks(Title, URL, IsFolder, PathDepth, ParentID)VALUES('" + drFilter[i]["Title"].ToString() + "', '" + drFilter[i]["URL"].ToString() + "', '" + drFilter[i]["IsFolder"].ToString() + "', " + drFilter[i]["PathDepth"].ToString() + ", " + GetID(drFilter[i]["parent_id"].ToString()) + "); ";
							strTMPID = dp.ExecuteScalar(strSQL, true);
							SetID(drFilter[i]["id"].ToString(), strTMPID);
						}
						if(drFilter.Length < 1)
							blnFoundRows = false;
						
						intDepth++;
					}
					dp.ExecuteNonQuery("INSERT INTO tb_UpdateLog(UpdateTypeID, UpdateItemID)VALUES(1, 1);");
				}
			}
			catch(Exception ex)
			{
				Common.LogError(ex);
				Common.LogError("log" + strSQL);
				blnImportSuccess = false;
			}
			finally
			{
				dp.Dispose();
				strTMPID = null;
				hshImportIDs.Clear();
			}
			return blnImportSuccess;
		}
		
		private string GetID(string strImportID)
		{
			if(hshImportIDs[strImportID] != null)
				return hshImportIDs[strImportID].ToString();
			else
				return "NULL";
		}
		
		private void SetID(string strImportID, string strDBID)
		{
			if(hshImportIDs[strImportID] == null)
				hshImportIDs.Add(strImportID, strDBID);
		}
		
		#endregion "Import"
	}
}
