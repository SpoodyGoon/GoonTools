/*************************************************************************
 *                      Common.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.Configuration;
using so = System.IO;
using System.Data;
using Gtk;

namespace GoonTools.Helper
{
	/// <summary>
	/// This will be used to compair versons during loading of the programa
	/// if the version don't match then we will be albe to take care of any  
	/// file or applciation version migration that needs to occure at the user level
	/// </summary>
	public class MetaInfo
	{
		public MetaInfo()
		{
			
			
		}
		
		public MetaInfo(DataTable dt)
		{
//			if(dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
//				throw new Exception("Invalid Table Passed to load Options");
//			
//			dt.PrimaryKey = new DataColumn[]{(DataColumn)dt.Columns["Key"]};
//			DataRow dr;
//			
//			dr = (DataRow)dt.Rows.Find("FileVersion");
//			if(dr != null)
//				_FileVersion = Convert.ToInt16(dr["Value"]);			
//			dr = (DataRow)dt.Rows.Find("UpdateTime");
//			if(dr != null)
//				_UpdateTime = dr["Value"].ToString();			
//			dr = (DataRow)dt.Rows.Find("UpdateHours");
//			if(dr != null)
//				_UpdateHours = Convert.ToInt32(dr["Value"]);			
//			dr = (DataRow)dt.Rows.Find("AutoUpdate");
//			if(dr != null)
//				_AutoUpdate = Convert.ToBoolean(dr["Value"]);			
//			dr = (DataRow)dt.Rows.Find("LastUpdate");
//			if(dr != null)
//				_LastUpdate = Convert.ToDateTime(dr["Value"]);			
//			dr = (DataRow)dt.Rows.Find("LastUpdateCheck");
//			if(dr != null)
//				_LastUpdateCheck = Convert.ToDateTime(dr["Value"]);
		}
		
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("MetaInfo");
//			dt.Columns.AddRange(new DataColumn[] { new DataColumn("Key", typeof(string)), new DataColumn("Value", typeof(object))});
//			dt.PrimaryKey = new DataColumn[]{dt.Columns["Key"]};
//			System.Data.DataRow dr = dt.NewRow();
//			dr["Key"] = "FileVersion";
//			dr["Value"] = _FileVersion;
//			dt.Rows.Add(dr);
//			dr = dt.NewRow();
//			dr["Key"] = "UpdateTime";
//			dr["Value"] = _UpdateTime;
//			dt.Rows.Add(dr);
//			dr = dt.NewRow();
//			dr["Key"] = "UpdateHours";
//			dr["Value"] = _UpdateHours;
//			dt.Rows.Add(dr);
//			dr = dt.NewRow();
//			dr["Key"] = "AutoUpdate";
//			dr["Value"] = _AutoUpdate;
//			dt.Rows.Add(dr);
//			dr = dt.NewRow();
//			dr["Key"] = "LastUpdate";
//			dr["Value"] = _LastUpdate;
//			dt.Rows.Add(dr);
//			dr = dt.NewRow();
//			dr["Key"] = "LastUpdateCheck";
//			dr["Value"] = _LastUpdateCheck;
//			dt.Rows.Add(dr);
			return dt;
		}
	}
}
