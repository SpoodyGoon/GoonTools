/*
 * Created by SharpDevelop.
 * User: Andrew York
 * Date: 8/9/2008
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Global;

namespace BookmarkSharpClient.DataSets
{
	/// <summary>
	/// Description of dsLocal.
	/// </summary>
	public class dsLocal : System.Data.DataSet
	{
		public dsLocal()
		{
			DataTable dtTags = new DataTable("dtTags");
			this.DataSetName = "dsTags";				
			DataColumn[] dc = new DataColumn[] { 
													new DataColumn("TagID",Type.GetType("System.Int32")),
													new DataColumn("TagName", Type.GetType("System.String")),
													new DataColumn("UseTag", Type.GetType("System.Boolean"))
												};
			for(int i = 0; i < dc.Length; i++)
			{
				dc[i].AllowDBNull = true;
			}
			dc[2].DefaultValue  = false;
			dtTags.Columns.AddRange(dc);
			dtTags.PrimaryKey =  new DataColumn[]{ (DataColumn)dc[0]};
			this.Tables.Add(dtTags);
		}
		
		public void Save()
		{
			this.WriteXml(Global.Common.GetWorkingFolder());
		}
		
		public void Load()
		{
			this.Clear();
			this.ReadXml(Global.Common.GetWorkingFolder());
		}
	}
}
