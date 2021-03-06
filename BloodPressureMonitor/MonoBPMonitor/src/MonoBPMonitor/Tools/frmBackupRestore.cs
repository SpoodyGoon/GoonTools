
using System;
using so = System.IO;
using System.Collections;
using System.Data;
using ICSharpCode.SharpZipLib.Zip;
using Gtk;
using GoonTools;
using SQLiteDataHelper;

namespace MonoBPMonitor
{


	public partial class frmBackupRestore : Gtk.Dialog
	{
		private string tmpFolderName = "";
		public frmBackupRestore ()
		{
			this.Build ();
			try
			{
				cbxAll.Activated += new EventHandler (OnCbxAllToggled);
				cbxDatabaseSchema.Active = Common.Option.BackupSchema;
				cbxDatabaseData.Active = Common.Option.BackupData;
				cbxOptions.Active = Common.Option.BackupOptions;
				cbxLogs.Active = Common.Option.BackupLogs;
				CheckAll ();
				this.ActionArea.Destroy ();
				this.HasSeparator = false;
			
				
			}
			catch (Exception ex)
			{
				Common.HandleError (this, ex);
			}
		}

		private void SaveChanges ()
		{
			try
			{
				Common.Option.BackupSchema = cbxDatabaseSchema.Active;
				Common.Option.BackupData = cbxDatabaseData.Active;
				Common.Option.BackupOptions = cbxOptions.Active;
				Common.Option.BackupLogs = cbxLogs.Active;
				GoonTools.Common.SaveUserData ();
			}
			catch (Exception ex)
			{
				Common.HandleError (this, ex);
			}
			
		}

		protected override void OnClose ()
		{
			SaveChanges ();
			this.Respond (Gtk.ResponseType.Ok);
			base.OnClose ();
		}
		
		#region Backup Area
		
		protected virtual void OnBtnBackupClicked (object sender, System.EventArgs e)
		{
			FileChooserDialog fc = new FileChooserDialog("Select a backup file", null, FileChooserAction.Save, "Cancel",ResponseType.Cancel,"Save",ResponseType.Ok);
			FileFilter filter = new FileFilter();
			DataSet ds = new DataSet("BPMonitorBackup");
            
			SQLiteBackup slb = new SQLiteBackup(Common.Option.DBLocation);
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
					tmpFolderName = Common.EnvData.GetNewTempFolder("BPMonitor_" + DateTime.Now.Ticks.ToString(), false);
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
						// get the backup summary info
						ds.Tables.Add(BackupSummary());
						// get the application meta info from the meta info class
						ds.Tables.Add(Common.MetaInfo.ToDataTable());
						
						if(cbxDatabaseSchema.Active == true && cbxDatabaseData.Active == true)
						{
							//slb.WriteBackupFile();
						}
						else if(cbxDatabaseSchema.Active == true)
						{
							BackupData();
						}
						else if(cbxDatabaseData.Active == true)
						{
							BackupData();
						}
						
						
						if(cbxOptions.Active == true)
							ds.Tables.Add(BackupOptions());
						
						if(cbxLogs.Active == true)
							BackupLogs();
						
						
						if(ds.Tables.Count > 0)
							ds.WriteXml(so.Path.Combine(tmpFolderName, "Backup.xml"));
						
						
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
				
				// clean up the temp folders
				so.FileInfo[] fi;
				so.DirectoryInfo di = new so.DirectoryInfo(tmpFolderName);
				if(so.Directory.Exists(di.FullName))
				{
					fi = di.GetFiles();
					for(int i= 0; i< fi.Length; i++)
					{
						fi[i].Delete();
					}
				}
				di.Delete();
				Gtk.MessageDialog msg3 = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "Backup is complete.", "Backup is complete.");
				msg3.Run();
				msg3.Destroy();
				
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			finally
			{
				fc.Destroy();
				filter.Destroy();
				ds.Clear();
				ds.Dispose();
			}
		}
		
		private void BackupSchema()
		{
			try
			{
				
				so.StreamWriter sw = new so.StreamWriter(so.Path.Combine(tmpFolderName, "Schema.sql"));
				// write the database tables
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				DataTable dt = shp.ExecuteDataTable("select tbl_name, sql from sqlite_master where type = 'table' and tbl_name NOT LIKE 'sqlite_%'", "Tables");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine(dt.Rows[i]["sql"].ToString() + ";");
				}
				dt.Clear();
				// write the database indexes
				dt = shp.ExecuteDataTable("select tbl_name, sql from sqlite_master where type = 'index' and tbl_name NOT LIKE 'sqlite_%'", "Tables");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine(dt.Rows[i]["sql"].ToString() + ";");
				}
				dt.Clear();
				sw.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		
		private void BackupData()
		{
			try
			{
				so.StreamWriter sw = new so.StreamWriter(so.Path.Combine(tmpFolderName, "Data.sql"));
				// write the database tables
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				// begin writing the data to the file
				// backup the doctor table
				DataTable dt = shp.ExecuteDataTable("SELECT DoctorID, DoctorName, Location, PhoneNum, UserID FROM tb_Doctor");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_Doctor (DoctorID, DoctorName, Location, PhoneNum, UserID) VALUES(" + dt.Rows[i]["DoctorID"].ToString() + ", '" + dt.Rows[i]["DoctorName"].ToString() + "', '" + dt.Rows[i]["Location"].ToString() + "', '" + dt.Rows[i]["PhoneNum"].ToString() + "', " + dt.Rows[i]["UserID"].ToString() + ");");
				}
				dt.Clear();
				// backup the doctor table
				dt = shp.ExecuteDataTable("SELECT EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_Entry (EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID) VALUES(" + dt.Rows[i]["EntryID"].ToString() + ", '" + Convert.ToDateTime(dt.Rows[i]["EntryDateTime"]).ToString("yyyy-MM-dd hh:mm:ss") + "', " + dt.Rows[i]["Systolic"].ToString() + ", " + dt.Rows[i]["Diastolic"].ToString() + ", " + dt.Rows[i]["HeartRate"].ToString() + ", '', " + dt.Rows[i]["UserID"].ToString() + ");");
				}
				dt.Clear();
				// backup the doctor table
				dt = shp.ExecuteDataTable("SELECT MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID FROM tb_Medicine");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_Medicine (MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID) VALUES(" + dt.Rows[i]["MedicineID"].ToString() + ", '" + dt.Rows[i]["MedicineName"].ToString() + "', '" + dt.Rows[i]["Dosage"].ToString() + "', '" + Convert.ToDateTime(dt.Rows[i]["StartDate"]).ToString("yyyy-MM-dd hh:mm:ss") + "', '" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd hh:mm:ss") + "', " + dt.Rows[i]["DoctorID"].ToString() + ", " + dt.Rows[i]["UserID"].ToString() + ");");
				}
				dt.Clear();
				// backup the doctor table
				dt = shp.ExecuteDataTable("SELECT UserID, UserName, DateAdded, IsActive FROM tb_User");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					sw.WriteLine("INSERT INTO tb_User (UserID, UserName, DateAdded, IsActive) VALUES(" + dt.Rows[i]["UserID"].ToString() + ", '" + dt.Rows[i]["UserName"].ToString() + "', '" + Convert.ToDateTime(dt.Rows[i]["DateAdded"]).ToString("yyyy-MM-dd hh:mm:ss") + "', '" + dt.Rows[i]["IsActive"].ToString() + "');");
				}
				dt.Clear();
				sw.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		
		private DataTable BackupOptions()
		{
			return Common.Option.ToDataTable();
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
				throw ex;
			}
			
		}
		
		private DataTable BackupSummary()
		{
			DataTable dt = new DataTable("BackupSummary");
			dt.Columns.AddRange(new DataColumn[]{new DataColumn("Key", typeof(string)),new DataColumn("Value", typeof(string))});
			dt.PrimaryKey = new DataColumn[]{dt.Columns[0]};
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly ();
				DataRow dr = dt.NewRow();
				dr["Key"] = "Application";
				dr["Value"] = "MonoBPMonitor";
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Description";
				dr["Value"] = "Mono BPMonitor - Backup Meta Info";
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Program Author Info";
				dr["Value"] = "Andy York <goontools@brdstudio.net>";
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Backup Date/Time";
				dr["Value"] = DateTime.Now;
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Backup Database Schema";
				dr["Value"] = cbxDatabaseSchema.Active ? "Yes":"No";
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Backup Database Data";
				dr["Value"] = cbxDatabaseData.Active ? "Yes":"No";
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Backup Options";
				dr["Value"] = cbxOptions.Active ? "Yes":"No";
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Backup Logs";
				dr["Value"] = cbxLogs.Active ? "Yes":"No";
				dt.Rows.Add(dr);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return dt;
		}
		
		#endregion Backup Area
		
		#region Restore Area
		
		protected virtual void OnBtnRestoreClicked (object sender, System.EventArgs e)
		{
			FileChooserDialog fc = new FileChooserDialog("Select a backup file", null, FileChooserAction.Open, "Cancel",ResponseType.Cancel,"Open",ResponseType.Ok);
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
						Gtk.MessageDialog msg2 = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Warning, Gtk.ButtonsType.YesNo, false, "This will over write existing files for each restore you asked for."+ Environment.NewLine + "Are you sure you want to overwrite your current files?", "Confirm");
						if (msg2.Run() == (int)ResponseType.Yes)
						{
							tmpFolderName = Common.EnvData.GetNewTempFolder("BPMonitor_" + DateTime.Now.Ticks.ToString(), false);
							using (ZipInputStream s = new ZipInputStream(so.File.OpenRead(fc.Filename)))
							{
								ZipEntry theEntry;
								while ((theEntry = s.GetNextEntry()) != null)
								{
									Console.WriteLine(theEntry.Name);
									string directoryName = so.Path.GetDirectoryName(theEntry.Name);
									string fileName      = so.Path.GetFileName(theEntry.Name);
									// create directory
									if ( directoryName.Length > 0 )
									{
										so.Directory.CreateDirectory(so.Path.Combine(tmpFolderName,directoryName));
									}
									if (fileName != String.Empty)
									{
										using (so.FileStream streamWriter = so.File.Create(so.Path.Combine(tmpFolderName, theEntry.Name)))
										{
											int size = 2048;
											byte[] data = new byte[2048];
											while (true)
											{
												size = s.Read(data, 0, data.Length);
												if (size > 0)
												{
													streamWriter.Write(data, 0, size);
												}
												else
												{
													break;
												}
											}
										}
									}
								}
							}
							
							DataSet ds = new DataSet();
							ds.ReadXml(so.Path.Combine(tmpFolderName, "Backup.xml"));
							
							RestoreMetaInfo((DataTable)ds.Tables["MetaInfo"]);
							if(cbxDatabaseSchema.Active && cbxDatabaseSchema.Active == true)
								RestoreSchema(so.Path.Combine(tmpFolderName, "Schema.sql"));
							if(cbxDatabaseData.Active && cbxDatabaseData.Active == true)
								RestoreData(so.Path.Combine(tmpFolderName, "Data.sql"));
							if(cbxOptions.Active && cbxOptions.Active == true)
								RestoreOptions((DataTable)ds.Tables["Options"]);
							if(cbxLogs.Active && cbxLogs.Active == true)
								RestoreLogs();
						}
						msg2.Destroy();
						
						
						// clean up the temp folders
						so.FileInfo[] fi;
						so.DirectoryInfo di = new so.DirectoryInfo(tmpFolderName);
						if(so.Directory.Exists(di.FullName))
						{
							fi = di.GetFiles();
							for(int i= 0; i< fi.Length; i++)
							{
								fi[i].Delete();
							}
						}
						di.Delete();
						
						Gtk.MessageDialog msg3 = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "Restore is complete.", "Restore is complete.");
						msg3.Run();
						msg3.Destroy();
						
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
		
		private void RestoreSchema(string SqlFileLocation)
		{
			try
			{
				//byte[] buffer = new byte[4096];
				if(so.File.Exists(Common.Option.DBLocation))
					so.File.Delete(Common.Option.DBLocation);
				
				// create the db file
				so.FileStream fs  = so.File.Create(Common.Option.DBLocation, 4096, so.FileOptions.None);
				fs.Close();
				fs.Dispose();
				
				System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(";");
				System.IO.StreamReader sr = new System.IO.StreamReader(SqlFileLocation);
				string[] strSQL = rx.Split(sr.ReadToEnd());
				sr.Close();
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				for(int i = 0; i < strSQL.Length; i++)
				{
					System.Diagnostics.Debug.WriteLine(strSQL[i].Trim() + ";");
					if(strSQL[i].Trim().Length > 5)
						shp.ExecuteNonQuery(strSQL[i].Trim() + ";");
				}
				shp.Dispose();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		private void RestoreData(string SqlFileLocation)
		{
			System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(";");
			System.IO.StreamReader sr = new System.IO.StreamReader(SqlFileLocation);
			string[] strSQL = rx.Split(sr.ReadToEnd());
			sr.Close();
			SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
			for(int i = 0; i < strSQL.Length; i++)
			{
				System.Diagnostics.Debug.WriteLine(strSQL[i].Trim() + ";");
				if(strSQL[i].Trim().Length > 5)
					shp.ExecuteNonQuery(strSQL[i].Trim() + ";");
			}
			shp.Dispose();
		}
		
		private void RestoreOptions(DataTable dt)
		{			
			Common.Option.RefreshAll(dt);
			Common.SaveUserData();
		}
		
		private void RestoreLogs()
		{
			if(so.File.Exists(Common.EnvData.ErrorLog))
				so.File.Delete(Common.EnvData.ErrorLog);
			so.File.Copy(so.Path.Combine(tmpFolderName, "error.log"), Common.EnvData.ErrorLog ,true);
		}
		
		private void RestoreMetaInfo(DataTable dt)
		{
			dt.PrimaryKey = new DataColumn[]{(DataColumn)dt.Columns[0]};
			if(((DataRow)dt.Rows.Find("Backup Database Schema"))["Value"].ToString() == "Yes")
				cbxDatabaseSchema.Active = true;
			else
				cbxDatabaseSchema.Active = false;
			
			if(((DataRow)dt.Rows.Find("Backup Database Data")).ToString() == "Yes")
				cbxDatabaseData.Active = true;
			else
				cbxDatabaseData.Active = false;
			
			
			if(((DataRow)dt.Rows.Find("Backup Options")).ToString() == "Yes")
				cbxOptions.Active = true;
			else
				cbxOptions.Active = false;
			
			if(((DataRow)dt.Rows.Find("Backup Logs")).ToString() == "Yes")
				cbxLogs.Active = true;
			else
				cbxLogs.Active = false;
			
			CheckAll();
			
		}

		#endregion Restore Area
		
		
		#region Backup/Restore
		
		private void OnCbxAllToggled (object sender, System.EventArgs e)
		{
			cbxAll.Inconsistent = false;
			cbxDatabaseData.Active = cbxAll.Active;
			cbxDatabaseSchema.Active = cbxAll.Active;
			cbxLogs.Active = cbxAll.Active;
			cbxOptions.Active = cbxAll.Active;
		}
		
		protected void OnBackupCheck_Clicked(object sender, System.EventArgs e)
		{
			Gtk.CheckButton cbx = (Gtk.CheckButton)sender;
			switch(cbx.Label)
			{
				case "Database Schema":
					Common.Option.BackupSchema = (bool)cbxDatabaseSchema.Active;
					break;
				case "Database Data":
					Common.Option.BackupData = (bool)cbxDatabaseData.Active;
					break;
				case "Program Options":
					Common.Option.BackupOptions = (bool)cbxOptions.Active;
					break;
				case"Program Logs":
					Common.Option.BackupLogs = (bool)cbxLogs.Active;
					break;
			}
			CheckAll();
		}

		private DataTable SimpleDataTable(string TableName)
		{
			DataTable dt = new DataTable(TableName);
			dt.Columns.AddRange(new DataColumn[]{new DataColumn("Key", typeof(string)),new DataColumn("Value", typeof(string))});
			dt.PrimaryKey = new DataColumn[]{dt.Columns[0]};
			return dt;
		}
		
		private void CheckAll()
		{
			if(cbxOptions.Active && cbxLogs.Active && cbxDatabaseSchema.Active && cbxDatabaseData.Active)
			{
				cbxAll.Inconsistent = false;
				cbxAll.Active = true;
			}
			else if(!cbxOptions.Active && !cbxLogs.Active && !cbxDatabaseSchema.Active && !cbxDatabaseData.Active)
			{
				cbxAll.Inconsistent = false;
				cbxAll.Active = false;
			}
			else
			{
				cbxAll.Inconsistent=true;
			}
		}
		
		#endregion Backup/Restore

		
		
		protected virtual void OnBackupGeneral_Toggled (object sender, System.EventArgs e)
		{
			Gtk.CheckButton cbx = (Gtk.CheckButton)sender;
			switch(cbx.Label)
			{
				case "Database Schema":
					Common.Option.BackupSchema = cbx.Active;
					break;
				case "Database Data":
					Common.Option.BackupData = cbx.Active;
					break;
				case "Program Options":
					Common.Option.BackupOptions = cbx.Active;
					break;
				case "Program Logs":
					Common.Option.BackupLogs = cbx.Active;
					break;
			}
			CheckAll();
		}
	}
}
