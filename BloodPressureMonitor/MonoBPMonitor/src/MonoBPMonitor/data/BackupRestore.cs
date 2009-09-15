/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 9/14/2009
 * Time: 4:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Collections;
using Gtk;
using SevenZip;
using GoonTools;
using Mono.Data.SqliteClient;

namespace MonoBPMonitor
{
	/// <summary>
	/// Description of BackupRestore.
	/// </summary>
	public static class Backup
	{
		private static string tmpSchema = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "BPMonitor.sql");
		private static string tmpOptions = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "BPMonitor.dat");
		private static string strNewLine = System.Environment.NewLine;
		public static void RunBackup()
		{
			try
			{
				if(System.IO.File.Exists(tmpSchema))
					System.IO.File.Delete(tmpSchema);
				System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpSchema);
				
				// lets start by getting our file name
				FileChooserDialog fc = new FileChooserDialog("Select a backup file", null, FileChooserAction.Save, "Cancel",ResponseType.Cancel,"Save",ResponseType.Ok);
				FileFilter filter = new FileFilter();
				filter.Name = "Backup Files (7z)";
				filter.AddMimeType("application/x-7z-compressed");
				filter.AddPattern("*.7z");
				fc.AddFilter(filter);
				fc.SelectMultiple = false;
				fc.CurrentName= "BPMonitor.bak.7z";
				fc.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
				if (fc.Run() == (int)ResponseType.Ok)
				{
					sw.WriteLine("-- Begin Schema");
					sw.WriteLine("BEGIN TRANSACTION;" + strNewLine);
					// write the database tables
					sw.WriteLine("-- Begin Table SQL");
					DataTable dt = GetDataTable("select tbl_name, sql from sqlite_master where type = 'table' and tbl_name NOT LIKE 'sqlite_%'", "Tables");
					for(int i = 0; i < dt.Rows.Count; i++)
					{
						sw.WriteLine(dt.Rows[i]["sql"].ToString() + ";");
					}
					dt.Clear();
					sw.WriteLine("-- End Table SQL" + strNewLine);
					
					sw.WriteLine("-- Begin Index SQL");
					// write the database indexes
					dt = GetDataTable("select tbl_name, sql from sqlite_master where type = 'index' and tbl_name NOT LIKE 'sqlite_%'", "Tables");
					for(int i = 0; i < dt.Rows.Count; i++)
					{
						sw.WriteLine(dt.Rows[i]["sql"].ToString() + ";");
					}
					sw.WriteLine("-- End Index SQL");
					dt.Clear();
					sw.WriteLine("-- End Schema" + strNewLine);
					
					// begin writing the data to the file
					sw.WriteLine("-- Begin Insert Data SQL" + strNewLine);
					sw.WriteLine("-- Begin Backup tb_Doctor");
					// backup the doctor table
					dt = GetDataTable("SELECT DoctorID, DoctorName, Location, PhoneNum, UserID FROM tb_Doctor");
					for(int i = 0; i < dt.Rows.Count; i++)
					{
						sw.WriteLine("INSERT INTO tb_Doctor (DoctorID, DoctorName, Location, PhoneNum, UserID) VALUES(" + dt.Rows[i]["DoctorID"].ToString() + ", '" + dt.Rows[i]["DoctorName"].ToString() + "', '" + dt.Rows[i]["Location"].ToString() + "', '" + dt.Rows[i]["PhoneNum"].ToString() + "', " + dt.Rows[i]["UserID"].ToString() + ");");
					}
					dt.Clear();
					sw.WriteLine("-- End Backup tb_Doctor");
					
					sw.WriteLine("-- Begin Backup tb_Entry");
					// backup the doctor table
					dt = GetDataTable("SELECT EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry");
					for(int i = 0; i < dt.Rows.Count; i++)
					{
						sw.WriteLine("INSERT INTO tb_Entry (EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID) VALUES(" + dt.Rows[i]["EntryID"].ToString() + ", '" + Convert.ToDateTime(dt.Rows[i]["EntryDateTime"]).ToString("yyyy-MM-dd hh:mm:ss") + "', " + dt.Rows[i]["Systolic"].ToString() + ", " + dt.Rows[i]["Diastolic"].ToString() + ", " + dt.Rows[i]["HeartRate"].ToString() + ", '" + dt.Rows[i]["Notes"].ToString() + "', " + dt.Rows[i]["UserID"].ToString() + ");");
					}
					dt.Clear();
					sw.WriteLine("-- End Backup tb_Entry");
					
					sw.WriteLine("-- Begin Backup tb_Medicine");
					// backup the doctor table
					dt = GetDataTable("SELECT MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID FROM tb_Medicine");
					for(int i = 0; i < dt.Rows.Count; i++)
					{
						sw.WriteLine("INSERT INTO tb_Medicine (MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID) VALUES(" + dt.Rows[i]["MedicineID"].ToString() + ", '" + dt.Rows[i]["MedicineName"].ToString() + "', '" + dt.Rows[i]["Dosage"].ToString() + "', '" + Convert.ToDateTime(dt.Rows[i]["StartDate"]).ToString("yyyy-MM-dd hh:mm:ss") + "', '" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd hh:mm:ss") + "', " + dt.Rows[i]["DoctorID"].ToString() + ", " + dt.Rows[i]["UserID"].ToString() + ");");
					}
					dt.Clear();
					sw.WriteLine("-- End Backup tb_Medicine");
					
					sw.WriteLine("-- Begin Backup tb_User");
					// backup the doctor table
					dt = GetDataTable("SELECT UserID, UserName, DateAdded, IsActive FROM tb_User");
					for(int i = 0; i < dt.Rows.Count; i++)
					{
						sw.WriteLine("INSERT INTO tb_User (UserID, UserName, DateAdded, IsActive) VALUES(" + dt.Rows[i]["UserID"].ToString() + ", '" + dt.Rows[i]["UserName"].ToString() + "', '" + Convert.ToDateTime(dt.Rows[i]["DateAdded"]).ToString("yyyy-MM-dd hh:mm:ss") + "', '" + dt.Rows[i]["IsActive"].ToString() + "');");
					}
					dt.Clear();
					sw.WriteLine("-- End Backup tb_User" + strNewLine);
					sw.WriteLine("COMMIT TRANSACTION;");
					sw.Close();
					
					// remove old files
					if(System.IO.File.Exists(fc.Filename + ".sql"))
						System.IO.File.Delete(fc.Filename + ".sql");
					// write the new file
					System.IO.File.Move(tmpSchema, fc.Filename + ".sql");
					// end of database backup
					
					// backup the options
					if(System.IO.File.Exists(tmpOptions))
						System.IO.File.Delete(tmpOptions);
					System.IO.StreamWriter swo = new System.IO.StreamWriter(tmpOptions);
					
					swo.WriteLine("## Begin Mono BPMonitor options backup");
					foreach( DictionaryEntry de in Common.Option.GetOptionsTable())
					{
						swo.WriteLine(de.Key.ToString() + "=" + de.Value.ToString());
					}
					swo.WriteLine("## End Mono BPMonitor options backup");
					swo.Close();
					
					if(System.IO.File.Exists(fc.Filename + ".dat"))
						System.IO.File.Delete(fc.Filename + ".dat");
					
					System.IO.File.Move(tmpOptions, fc.Filename + ".dat");
					
				}
				fc.Destroy();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private static DataTable GetDataTable(string strSQL)
		{
			return GetDataTable(strSQL, "dt");
		}
		
		private static DataTable GetDataTable(string strSQL, string strDataTableName)
		{
			SqliteConnection sqlCN = new SqliteConnection(Common.Option.ConnString);
			sqlCN.BusyTimeout = 300;
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = 300;
			SqliteDataAdapter sqlDA = new SqliteDataAdapter(sqlCMD);
			DataTable dt = new DataTable();
			
			if(strDataTableName != null)
				dt.TableName = strDataTableName;
			else
				dt.TableName = "dt";
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					sqlDA.Fill(dt);
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().IndexOf("database is locked") > -1)
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(100);
					}
					else
					{
						lockedDatabaseException = false;
						Common.HandleError(ex);
					}
				}
			}
			return dt;
		}
	}
	
	
	public static class Restore
	{
		public static void RunRestore()
		{
			
		}
	}
}
