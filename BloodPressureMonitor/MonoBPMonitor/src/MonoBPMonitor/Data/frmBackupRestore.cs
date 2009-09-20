// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using so = System.IO;
using System.Collections;
using System.Data;
using SQLiteDataProvider;
using ICSharpCode.SharpZipLib.Zip;
using Gtk;
using GoonTools;

namespace MonoBPMonitor {
	
	
	public partial class frmBackupRestore : Gtk.Dialog
	{
		private string tmpFolderName = "";
		private string strNewLine = System.Environment.NewLine;
		public frmBackupRestore()
		{
			tmpFolderName = Common.EnvData.GetNewTempFolder("BPMonitor", false);
			this.Build();
		}
		
		private void BackupSchema()
		{
			try
			{
				so.StreamWriter sw = new so.StreamWriter(so.Path.Combine(tmpFolderName, "Schema.sql"));
				// write the database tables
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("select tbl_name, sql from sqlite_master where type = 'table' and tbl_name NOT LIKE 'sqlite_%'", "Tables");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine(dt.Rows[i]["sql"].ToString() + ";");
				}
				dt.Clear();
				// write the database indexes
				dt = dp.ExecuteDataTable("select tbl_name, sql from sqlite_master where type = 'index' and tbl_name NOT LIKE 'sqlite_%'", "Tables");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine(dt.Rows[i]["sql"].ToString() + ";");
				}
				dt.Clear();
				sw.Close();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		private void BackupData()
		{
			try
			{
				so.StreamWriter sw = new so.StreamWriter(so.Path.Combine(tmpFolderName, "Data.sql"));
				// write the database tables
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				// begin writing the data to the file
				// backup the doctor table
				DataTable dt = dp.ExecuteDataTable("SELECT DoctorID, DoctorName, Location, PhoneNum, UserID FROM tb_Doctor");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_Doctor (DoctorID, DoctorName, Location, PhoneNum, UserID) VALUES(" + dt.Rows[i]["DoctorID"].ToString() + ", '" + dt.Rows[i]["DoctorName"].ToString() + "', '" + dt.Rows[i]["Location"].ToString() + "', '" + dt.Rows[i]["PhoneNum"].ToString() + "', " + dt.Rows[i]["UserID"].ToString() + ");");
				}
				dt.Clear();
				// backup the doctor table
				dt = dp.ExecuteDataTable("SELECT EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_Entry (EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID) VALUES(" + dt.Rows[i]["EntryID"].ToString() + ", '" + Convert.ToDateTime(dt.Rows[i]["EntryDateTime"]).ToString("yyyy-MM-dd hh:mm:ss") + "', " + dt.Rows[i]["Systolic"].ToString() + ", " + dt.Rows[i]["Diastolic"].ToString() + ", " + dt.Rows[i]["HeartRate"].ToString() + ", '" + dt.Rows[i]["Notes"].ToString() + "', " + dt.Rows[i]["UserID"].ToString() + ");");
				}
				dt.Clear();
				// backup the doctor table
				dt = dp.ExecuteDataTable("SELECT MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID FROM tb_Medicine");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_Medicine (MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID) VALUES(" + dt.Rows[i]["MedicineID"].ToString() + ", '" + dt.Rows[i]["MedicineName"].ToString() + "', '" + dt.Rows[i]["Dosage"].ToString() + "', '" + Convert.ToDateTime(dt.Rows[i]["StartDate"]).ToString("yyyy-MM-dd hh:mm:ss") + "', '" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd hh:mm:ss") + "', " + dt.Rows[i]["DoctorID"].ToString() + ", " + dt.Rows[i]["UserID"].ToString() + ");");
				}
				dt.Clear();
				// backup the doctor table
				dt = dp.ExecuteDataTable("SELECT UserID, UserName, DateAdded, IsActive FROM tb_User");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_User (UserID, UserName, DateAdded, IsActive) VALUES(" + dt.Rows[i]["UserID"].ToString() + ", '" + dt.Rows[i]["UserName"].ToString() + "', '" + Convert.ToDateTime(dt.Rows[i]["DateAdded"]).ToString("yyyy-MM-dd hh:mm:ss") + "', '" + dt.Rows[i]["IsActive"].ToString() + "');");
				}
				dt.Clear();
				sw.Close();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		private void BackupOptions()
		{
			try
			{
				so.StreamWriter sw = new so.StreamWriter(so.Path.Combine(tmpFolderName, "Options.dat"));
				// write the database tables
				sw.WriteLine("## Begin Mono BPMonitor options backup");
				foreach( DictionaryEntry de in Common.Option.GetOptionsTable())
				{
					sw.WriteLine(de.Key.ToString() + "=" + de.Value.ToString());
				}
				sw.WriteLine("## End Mono BPMonitor options backup");
				sw.Close();
				sw.Close();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		private void BackupLogs()
		{
			try
			{
				// for the logs we just add their location to the arraylist
				if(Common.Option.SaveErrorLog)
					so.File.Copy(Common.EnvData.ErrorLog, so.Path.Combine(tmpFolderName, "error.log"));
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			
		}
		
		private void BackupMetaInfo()
		{
			try
			{
				so.StreamWriter sw = new so.StreamWriter(so.Path.Combine(tmpFolderName, "MetaInfo.txt"));
				// write the database tables
				sw.WriteLine("## Begin Mono BPMonitor MetaInfo backup");
				sw.WriteLine("Application: MonoBPMonitor");
				sw.WriteLine("Date: " + DateTime.Now.ToString());
				sw.WriteLine("Backup Database Schema =" + (cbxDatabaseSchema.Active ? "Yes": "No"));
				sw.WriteLine("Backup Database Data   =" + (cbxDatabaseData.Active ? "Yes": "No"));
				sw.WriteLine("Backup Program Options =" + (cbxOptions.Active ? "Yes": "No"));
				sw.WriteLine("Backup Program Logs    =" + (cbxLogs.Active ? "Yes": "No"));
				sw.WriteLine("Description: Backup files for Mono BPMonitor");
				sw.WriteLine("## End Mono BPMonitor MetaInfo backup");
				sw.Close();
				sw.Close();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		protected virtual void OnBtnClearLogClicked(object sender, System.EventArgs e) {
		}

		protected virtual void OnCbxAllToggled (object sender, System.EventArgs e)
		{
			cbxDatabaseData.Active = cbxAll.Active;
			cbxDatabaseSchema.Active = cbxAll.Active;
			cbxLogs.Active = cbxAll.Active;
			cbxOptions.Active = cbxAll.Active;
		}

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		protected virtual void OnBtnBackupClicked (object sender, System.EventArgs e)
		{
			
			FileChooserDialog fc = new FileChooserDialog("Select a backup file", null, FileChooserAction.Save, "Cancel",ResponseType.Cancel,"Save",ResponseType.Ok);
			FileFilter filter = new FileFilter();
			try
			{
				if(!cbxLogs.Active && !cbxDatabaseData.Active && !cbxDatabaseSchema.Active && !cbxOptions.Active)
				{
					Gtk.MessageDialog msg = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "No backup options selected", "Select a backup option.");
					msg.Run();
					msg.Destroy();
				}
				else
				{
					
					// lets start by getting our file name
					filter.Name = "Backup Files (bz2)";
					filter.AddMimeType("application/bzip2");
					filter.AddPattern("*.bz2");
					fc.AddFilter(filter);
					fc.SelectMultiple = false;
					fc.CurrentName= "BPMonitor.bak.bz2";
					fc.SetCurrentFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
					if (fc.Run() == (int)ResponseType.Ok)
					{
						// put backup code here
						BackupMetaInfo();
						if(cbxDatabaseSchema.Active == true)
							BackupSchema();
						
						if(cbxDatabaseData.Active == true)
							BackupData();
						
						if(cbxOptions.Active == true)
							BackupOptions();
						
						if(cbxLogs.Active == true)
							BackupLogs();
						
						string[] filenames = so.Directory.GetFiles(so.Path.GetFullPath(tmpFolderName));
						using (ZipOutputStream s = new ZipOutputStream(so.File.Create(fc.Filename)))
						{
							s.SetLevel(9); // 0 - store only to 9 - means best compression
							byte[] buffer = new byte[4096];
							foreach (string file in filenames)
							{
								ZipEntry entry = new ZipEntry(so.Path.GetFileName(file));
								entry.DateTime = DateTime.Now;
								s.PutNextEntry(entry);
								using ( so.FileStream fs = so.File.OpenRead(file) )
								{
									int sourceBytes;
									do
									{
										sourceBytes = fs.Read(buffer, 0, buffer.Length);
										s.Write(buffer, 0, sourceBytes);
									} while ( sourceBytes > 0 );
								}
							}							
							s.Finish();
							s.Close();
						}
					}
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			finally
			{
				fc.Destroy();
				filter.Destroy();
			}
		}
	}	
}
