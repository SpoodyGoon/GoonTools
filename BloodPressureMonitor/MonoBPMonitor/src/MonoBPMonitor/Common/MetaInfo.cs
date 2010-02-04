/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/4/2010
 * Time: 9:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using GoonTools;

namespace GoonTools.Helper
{
	/// <summary>
	/// Description of MetaInfo.
	/// </summary>
	public class MetaInfo
	{
		private Version _MonoBPMonitor = new Version(0,1);
		private Version _GUPdotNET = new Version(0,1);
		private Version _UserFile = new Version(1,0);
		private Version _Database = new Version(1,0);
		public MetaInfo()
		{
		}
		
		public MetaInfo(DataTable dt)
		{			
			try
			{
				if (dt.TableName != "MetaInfo" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
					throw new Exception ("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[] { (DataColumn)dt.Columns["Key"] };
				DataRow dr;
				
				dr = (DataRow)dt.Rows.Find ("MonoBPMonitor");
				if (dr != null)
					_MonoBPMonitor = (Version)(dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("GUPdotNET");
				if (dr != null)
					_GUPdotNET = (Version)(dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("UserFile");
				if (dr != null)
					_UserFile = (Version)(dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("Database");
				if (dr != null)
					_Database = (Version)(dr["Value"]);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public DataTable ToDataTable()
		{			
			DataTable dt = new DataTable ("MetaInfo");
			try {
				dt.Columns.AddRange (new DataColumn[] {
					new DataColumn ("Key", typeof(string)),
					new DataColumn ("Value", typeof(object))
				});
				dt.PrimaryKey = new DataColumn[] { dt.Columns["Key"] };
				System.Data.DataRow dr = dt.NewRow ();
				dr["Key"] = "MonoBPMonitor";
				dr["Value"] = _MonoBPMonitor;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "GUPdotNET";
				dr["Value"] = _GUPdotNET;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "UserFile";
				dr["Value"] = _UserFile;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "Database";
				dr["Value"] = _Database;
				dt.Rows.Add (dr);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			return dt;
		}
		
		#region Public Properties
		
		public Version MonoBPMonitor
		{
			get{return _MonoBPMonitor;}
		}
		
		public Version GUPdotNET
		{
			get{return _GUPdotNET;}
		}
		
		public Version UserFile
		{
			get{return _UserFile;}
		}
		
		public Version Database
		{
			get{return _Database;}
		}
		
		#endregion Public Properties
	}
}
