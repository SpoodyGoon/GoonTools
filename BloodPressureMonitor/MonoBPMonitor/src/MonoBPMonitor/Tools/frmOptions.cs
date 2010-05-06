using System;
using so = System.IO;
using System.Collections;
using System.Data;
using ICSharpCode.SharpZipLib.Zip;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{	
	
	public partial class frmOptions : Gtk.Dialog
	{
		public frmOptions ()
		{
			// TODO: add a restart program button or notice when the theme changes to prompt restart
			// all spelling on notice is wrong
			this.Build ();
			try
			{
				// themes are only used in Windows where a good looking theme is not a sure thing
				if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "false" || Common.Option.UseCustomUpdate == false)
				{
					notebook1.RemovePage(notebook1.NPages - 1);
				}
				if (System.Configuration.ConfigurationManager.AppSettings["AllowCustomUpdate"].ToLower() == "false" || Common.Option.UseCustomUpdate == false)
				{
					lblGUPdotNETVersion.Destroy();
					lblGUPdotNETText.Destroy();
				}
				spnDefaultHistory.Value = (double)GoonTools.Common.Option.HistoryDefaultShow;
				cbxLogErrors.Active = GoonTools.Common.Option.SaveErrorLog;
				spnDefaultHistory.Sensitive = GoonTools.Common.Option.LimitHistory;
				lblDatabaseLocation.Text = Common.Option.DBLocation;
				lblDatabaseVersion.Text = Common.MetaInfo.Database.ToString();
				lblGUPdotNETVersion.Text = Common.MetaInfo.GUPdotNET.ToString();
				lblMonoBPMonitorVersion.Text = Common.MetaInfo.MonoBPMonitor.ToString();
				lblOptionsFileVersion.Text = Common.MetaInfo.UserFile.ToString();
				
				this.ActionArea.Destroy();
				this.HasSeparator = false;
				notebook1.CurrentPage = 0;
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			this.ShowAll();
		}
		
		protected override void OnClose()
		{
			SaveChanges();
			this.Respond(Gtk.ResponseType.Ok);
			base.OnClose();
		}

		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			SaveChanges();
		}
		
		private void SaveChanges()
		{
			try
			{
				GoonTools.Common.Option.LimitHistory = cbxLimitRecords.Active;
				GoonTools.Common.Option.HistoryDefaultShow=Convert.ToInt32(spnDefaultHistory.Value);
				GoonTools.Common.Option.SaveErrorLog= cbxLogErrors.Active;
				GoonTools.Common.SaveUserData();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			
		}
		
		protected virtual void OnCbxLimitRecordsToggled (object sender, System.EventArgs e)
		{
			spnDefaultHistory.Sensitive = cbxLimitRecords.Active;
		}
		
		protected virtual void OnClose (object sender, System.EventArgs e)
		{
			 SaveChanges();
		}
		
		protected virtual void OnLblDatabaseLocationShown (object sender, System.EventArgs e)
		{
			lblDatabaseLocation.WidthRequest = this.Allocation.Width - 35;
			lblDatabaseLocation.QueueDraw();
		}
	}
}