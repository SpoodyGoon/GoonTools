// dsBookmarks.cs created with MonoDevelop
// User: spoodygoon at 8:40 PM 7/31/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Data;
using System.Text;
using Gtk;

namespace BookmarkSharpClient
{
	
	
	public class dsBookmarks : System.Data.DataSet
	{
		
		public dsBookmarks()
		{
			DataTable dtBookMarks = new DataTable("dtBookMarks");
			this.DataSetName = "dsBookMarks";				
			DataColumn[] dc = new DataColumn[] { 
													new DataColumn("BookmarkID",Type.GetType("System.String")),
													new DataColumn("Title", Type.GetType("System.String")),
													new DataColumn("URL", Type.GetType("System.String")),
													new DataColumn("IsFolder", Type.GetType("System.String")),
													new DataColumn("PathDepth", Type.GetType("System.String")),
													new DataColumn("ParentID", Type.GetType("System.String")),
												};
			for(int i = 0; i < dc.Length; i++)
			{
				dc[i].AllowDBNull = true;
			}
			dtBookMarks.Columns.AddRange(dc);
			dtBookMarks.PrimaryKey =  new DataColumn[]{ (DataColumn)dc[0]};
			this.Tables.Add(dtBookMarks);
			
//			// dataset for projects
//			DataTable dtProjects = new DataTable("dtProjects");			
//			DataColumn[] dcProjects = new DataColumn[] { 
//												new DataColumn("ProjectID",Type.GetType("System.String")),
//												new DataColumn("ProjectName", Type.GetType("System.String")),
//												new DataColumn("ProjectManager", Type.GetType("System.String")),
//												new DataColumn("AccountAdmin", Type.GetType("System.String")),
//												new DataColumn("DevURL", Type.GetType("System.String")),
//												new DataColumn("TestURL", Type.GetType("System.String")),
//												new DataColumn("ProdURL", Type.GetType("System.String"))
//												};
//			dtProjects.Columns.AddRange(dcProjects);
//			dtProjects.PrimaryKey =  new DataColumn[]{ (DataColumn)dcProjects[0]};
//			this.Tables.Add(dtProjects);
//			
//			// dataset for Files
//			DataTable dtFilesLocations = new DataTable("dtFilesLocations");			
//			DataColumn[] dcFilesLocations = new DataColumn[] { 
//												new DataColumn("FileID",Type.GetType("System.String")),
//												new DataColumn("EntityTypeID", Type.GetType("System.String")),
//												new DataColumn("ID", Type.GetType("System.String")),
//												new DataColumn("FileName", Type.GetType("System.String")),
//												new DataColumn("FileLocation", Type.GetType("System.String")),
//												new DataColumn("FileTypeID", Type.GetType("System.String"))
//												};
//			dtFilesLocations.Columns.AddRange(dcFilesLocations);
//			dtFilesLocations.PrimaryKey =  new DataColumn[]{ (DataColumn)dcFilesLocations[0]};
//			this.Tables.Add(dtFilesLocations);
		}
	}
}
