/*
 * Created by SharpDevelop.
 * User: Andrew York
 * Date: 8/16/2008
 * Time: 4:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Data;
using Global;

namespace BookmarkSharpClient.DataSets
{
	/// <summary>
	/// Description of dsTags.
	/// </summary>
	public class dsTags : System.Data.DataSet
	{
		DataTable dtTags = new DataTable("dtTags");
		public dsTags()
		{
			this.DataSetName = "dsTags";
			DataColumn[] dc = new DataColumn[] {
				new DataColumn("TagID",typeof(int)),
				new DataColumn("TagName", typeof(string)),
				new DataColumn("Use", typeof(bool))
			};
			dtTags.Columns.AddRange(dc);
			dtTags.PrimaryKey =  new DataColumn[]{ (DataColumn)dc[0]};
			dc[2].DefaultValue = false;
			this.Tables.Add(dtTags);
		}
		
		public DataTable Tags
		{
			set{ dtTags = value;}
			get{ return dtTags;}
		}
		
		public void LoadTags()
		{
			if(File.Exists(Common.GetWorkingFolder() + "dsTags.xml"))
			{
				this.ReadXml(Common.GetWorkingFolder() + "dsTags.xml");
			}
		}
		
		public void UpdateTags(DataTable dt)
		{
			if(dt.Rows.Count > 0)
			{
				DataRow drNew;
				foreach(DataRow dr in dt.Rows)
				{
					if(dtTags.Rows.Find(dr["TagID"]) != null)
					{
						drNew = dtTags.NewRow();
						drNew["TagID"] = dr["TagID"];
						drNew["TagName"] = dr["TagName"];
						dtTags.Rows.Add(drNew);
					}
				}
				this.WriteXml(Common.GetWorkingFolder() + "dsTags.xml");
			}
		}
		
		public void FlagUse(int intTagID, bool blnUse)
		{
			DataRow dr = dtTags.Rows.Find(intTagID);
			dr["Use"] = blnUse;
			
		}
	}
}
