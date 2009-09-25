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
		private bool _RestoreOptions = true;
		private bool _RestoreSchema = true;
		private bool _RestoreData = true;
		private bool _RestoreLogs = true;
		public frmBackupRestore()
		{
			this.Build();
			cbxDatabaseSchema.Active = Common.Option.BackupSchema;
			cbxDatabaseData.Active = Common.Option.BackupData;
			cbxOptions.Active = Common.Option.BackupOptions;
			cbxLogs.Active = Common.Option.BackupLogs;
			CheckAll();
			this.WidthRequest = 500;
			this.ShowAll();
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
		
		#region Backup Area
		
		protected virtual void OnBtnBackupClicked (object sender, System.EventArgs e)
		{
			FileChooserDialog fc = new FileChooserDialog("Select a backup file", null, FileChooserAction.Save, "Cancel",ResponseType.Cancel,"Save",ResponseType.Ok);
			FileFilter filter = new FileFilter();
			DataSet ds = new DataSet("BPMonitorBackup");
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
						// put backup code here
						ds.Tables.Add(BackupMetaInfo());
						if(cbxDatabaseSchema.Active == true)
							BackupSchema();
						
						if(cbxDatabaseData.Active == true)
							BackupData();
						
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
				throw ex;
			}
		}
		
		private void BackupData()
		{
			int tmpYear = 2009;
			int tmpMonth = 1;
			int tmpDay = 1;
			int tmpHour = 8;
			int tmpMinute = 15;
			int tmpSecond = 0;
			string[] tmptest;
			DateTime tmpFirstDate = DateTime.Now;
			DateTime tmpDateTime = DateTime.Now;
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
				dt = dp.ExecuteDataTable("SELECT EntryID, EntryDate, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry");
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					if(dt.Rows[i]["Notes"].ToString().Trim() != "")
					{
						
						tmptest = dt.Rows[i]["Notes"].ToString().Replace("pm", "").Replace("am", "").Split(new string[]{":"}, StringSplitOptions.RemoveEmptyEntries);
						tmpFirstDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"]);
						System.Diagnostics.Debug.WriteLine("notes " + tmptest[0] + " - " + tmptest[1] + " - " + tmpFirstDate.ToString());
						tmpDateTime = new DateTime(tmpFirstDate.Year, tmpFirstDate.Month, tmpFirstDate.Day, Convert.ToInt32(tmptest[0]) + 12, Convert.ToInt32(tmptest[1]),0);
						if( dt.Rows[i]["Notes"].ToString().Contains("pm"))
						{
							tmpDateTime.AddHours((double)12);
						}
						sw.WriteLine("INSERT INTO tb_Entry (EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID) VALUES(" + dt.Rows[i]["EntryID"].ToString() + ", '" + tmpDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', " + dt.Rows[i]["Systolic"].ToString() + ", " + dt.Rows[i]["Diastolic"].ToString() + ", " + dt.Rows[i]["HeartRate"].ToString() + ", '', " + dt.Rows[i]["UserID"].ToString() + ");");
					}
					else
					{
						sw.WriteLine("INSERT INTO tb_Entry (EntryID, EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID) VALUES(" + dt.Rows[i]["EntryID"].ToString() + ", '" + Convert.ToDateTime(dt.Rows[i]["EntryDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "', " + dt.Rows[i]["Systolic"].ToString() + ", " + dt.Rows[i]["Diastolic"].ToString() + ", " + dt.Rows[i]["HeartRate"].ToString() + ", '', " + dt.Rows[i]["UserID"].ToString() + ");");
					}
					
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
				throw ex;
			}
		}
		
		private DataTable BackupOptions()
		{
			DataTable dt = SimpleDataTable("Options");
			try
			{
				DataRow dr;
				foreach( DictionaryEntry de in Common.Option.GetOptionsTable())
				{
					dr = dt.NewRow();
					dr["Key"] = de.Key.ToString();
					dr["Value"] = de.Value.ToString();
					dt.Rows.Add(dr);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return dt;
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
		
		private DataTable BackupMetaInfo()
		{
			DataTable dt = SimpleDataTable("MetaInfo");
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
				dr["Key"] = "MajorVersion";
				dr["Value"] = asm.GetName().Version.Major.ToString();
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "MinorVersion";
				dr["Value"] = asm.GetName().Version.Minor.ToString();
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "Contact Info";
				dr["Value"] = "Andy York <goontools@brdstudio.net>";
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
							if(cbxDatabaseSchema.Active && _RestoreSchema == true)
								RestoreSchema(so.Path.Combine(tmpFolderName, "Schema.sql"));
							if(cbxDatabaseData.Active && _RestoreData == true)
								RestoreData(so.Path.Combine(tmpFolderName, "Data.sql"));
							if(cbxOptions.Active && _RestoreOptions == true)
								RestoreOptions((DataTable)ds.Tables["Options"]);
							if(cbxLogs.Active && _RestoreLogs == true)
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
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				for(int i = 0; i < strSQL.Length; i++)
				{
					System.Diagnostics.Debug.WriteLine(strSQL[i].Trim() + ";");
					if(strSQL[i].Trim().Length > 5)
						dp.ExecuteNonQuery(strSQL[i].Trim() + ";");
				}
				dp.Dispose();
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
			DataProvider dp = new DataProvider(Common.Option.ConnString);
			for(int i = 0; i < strSQL.Length; i++)
			{
				System.Diagnostics.Debug.WriteLine(strSQL[i].Trim() + ";");
				if(strSQL[i].Trim().Length > 5)
						dp.ExecuteNonQuery(strSQL[i].Trim() + ";");
			}
			dp.Dispose();
		}
		
		private void RestoreOptions(DataTable dt)
		{
			Hashtable hsh = new Hashtable();
			for(int i = 0; i < dt.Rows.Count; i++)
			{
				hsh.Add(dt.Rows[i]["Key"], dt.Rows[i]["Value"]);
			}
			Common.Option.RefreshAll(hsh);
			Common.SaveOptions();
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
				_RestoreSchema = true;
			if(((DataRow)dt.Rows.Find("Backup Database Data")).ToString() == "Yes")
				_RestoreData = true;
			if(((DataRow)dt.Rows.Find("Backup Options")).ToString() == "Yes")
				_RestoreOptions = true;
			if(((DataRow)dt.Rows.Find("Backup Logs")).ToString() == "Yes")
				_RestoreLogs = true;
		}

		#endregion Restore Area
		
		protected virtual void OnCbxAllToggled (object sender, System.EventArgs e)
		{
			cbxAll.Inconsistent = false;
			cbxDatabaseData.Active = cbxAll.Active;
			cbxDatabaseSchema.Active = cbxAll.Active;
			cbxLogs.Active = cbxAll.Active;
			cbxOptions.Active = cbxAll.Active;
		}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Hide();
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
	}
}
