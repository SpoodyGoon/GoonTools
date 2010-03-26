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
	internal class MetaInformation
	{
		private Version _MonoBPMonitor = new Version(0,1);
		private Version _GUPdotNET = new Version(0,1);
		private Version _UserFile = new Version(1,0);
		private Version _Database = new Version(1,0);
		internal MetaInformation()
		{
		}
		
		internal MetaInformation(DataTable dt)
		{			
			try
			{
				if (dt.TableName != "MetaInfo" || dt.Columns[0].ColumnName != "Entity" || dt.Columns[1].ColumnName != "MajorVersion" || dt.Columns[2].ColumnName != "MinorVersion")
					throw new Exception ("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[] { (DataColumn)dt.Columns["Entity"] };
				DataRow dr;
				
				dr = (DataRow)dt.Rows.Find ("MonoBPMonitor");
				if (dr != null)
					_MonoBPMonitor = new Version((int)dr["MajorVersion"], (int)dr["MinorVersion"]);
				dr = (DataRow)dt.Rows.Find ("GUPdotNET");
				if (dr != null)
					_GUPdotNET = new Version((int)dr["MajorVersion"], (int)dr["MinorVersion"]);
				dr = (DataRow)dt.Rows.Find ("UserFile");
				if (dr != null)
					_UserFile = new Version((int)dr["MajorVersion"], (int)dr["MinorVersion"]);
				dr = (DataRow)dt.Rows.Find ("Database");
				if (dr != null)
					_Database = new Version((int)dr["MajorVersion"], (int)dr["MinorVersion"]);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		internal DataTable ToDataTable()
		{			
			DataTable dt = new DataTable ("MetaInfo");
			try {
				dt.Columns.AddRange (new DataColumn[] {
					new DataColumn ("Entity", typeof(string)),
					new DataColumn ("MajorVersion", typeof(int)),
					new DataColumn ("MinorVersion", typeof(int))
				});
				dt.PrimaryKey = new DataColumn[] { dt.Columns["Entity"] };
				System.Data.DataRow dr = dt.NewRow ();
				dr["Entity"] = "MonoBPMonitor";
				dr["MajorVersion"] = _MonoBPMonitor.Major;
				dr["MinorVersion"] = _MonoBPMonitor.Minor;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Entity"] = "GUPdotNET";
				dr["MajorVersion"] = _GUPdotNET.Major;
				dr["MinorVersion"] = _GUPdotNET.Minor;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Entity"] = "UserFile";
				dr["MajorVersion"] = _UserFile.Major;
				dr["MinorVersion"] = _UserFile.Minor;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Entity"] = "Database";
				dr["MajorVersion"] = _Database.Major;
				dr["MinorVersion"] = _Database.Minor;
				dt.Rows.Add (dr);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			return dt;
		}
		
		#region Public Properties
		
		internal Version MonoBPMonitor
		{
			get{return _MonoBPMonitor;}
		}
		
		internal Version GUPdotNET
		{
			get{return _GUPdotNET;}
		}
		
		internal Version UserFile
		{
			get{return _UserFile;}
		}
		
		internal Version Database
		{
			get{return _Database;}
		}
		
		#endregion Public Properties
	}
}
