
using System;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmOptions : Gtk.Dialog
	{
		private string StartingTheme;

		
		public frmOptions ()
		{
			// TODO: add checkbox to not have any sort at all.
			this.Build();
			
			spnDefaultHistory.Value = (double)GoonTools.Common.Option.HistoryDefaultShow;
			cbxLimitRecords.Active = GoonTools.Common.Option.LimitHistory;
			cbxLogErrors.Active = GoonTools.Common.Option.SaveErrorLog;
			spnDefaultHistory.Sensitive = GoonTools.Common.Option.LimitHistory;
			// TODO: put this in a frame for toggling visiblity
			if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "true")
			{
				themecombobox1.SetThemeName(Common.Option.CustomTheme);
				algThemeControl.Visible = true;
				algThemeLabel.Visible = true;
			}
			else
			{
				algThemeLabel.Visible = false;
				algThemeControl.Visible = false;
			}
			btnApply.Clicked += new EventHandler(btnApply_Clicked);
			btnOk.Clicked += new EventHandler(btnOk_Clicked);
			StartingTheme = Common.Option.CustomTheme;
			this.ShowAll();
		}

		protected virtual void btnOk_Clicked (object sender, System.EventArgs e)
		{
			SaveChanges();
			this.Hide();
		}

		protected void btnApply_Clicked(object sender, EventArgs e)
		{
			SaveChanges();
		}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			SaveChanges();
			this.Hide();
		}
		
		protected virtual void OnClose (object sender, System.EventArgs e)
		{
			SaveChanges();
		}

		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			SaveChanges();
		}
		
		private void SaveChanges()
		{
			// no matter what happens just save the changes
			// when we close
			GoonTools.Common.Option.LimitHistory = cbxLimitRecords.Active;
			GoonTools.Common.Option.HistoryDefaultShow=Convert.ToInt32(spnDefaultHistory.Value);
			GoonTools.Common.Option.SaveErrorLog= cbxLogErrors.Active;
			if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "true")
			{
				GoonTools.Common.Option.CustomTheme = themecombobox1.ThemeName;
				GoonTools.Common.Option.CustomThemeLocation = themecombobox1.ThemeLoc;
			}
			GoonTools.Common.SaveOptions();
			
			if(StartingTheme != themecombobox1.ThemeName)
			{
				Gtk.MessageDialog msg = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "The theme will be changed the next time you restart the program.", "Theme Change.");
				msg.Run();
				msg.Destroy();
			}
			
//			Console.WriteLine("theme " + Common.Option.CustomThemeLocation + " = " + Common.Option.CustomTheme);
//			System.Diagnostics.Debug.WriteLine("theme " + Common.Option.CustomThemeLocation + " = " + Common.Option.CustomTheme);
//			if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "true")
//			{
//				if(StartingTheme != themecombobox1.ThemeName)
//				{
//					if(System.IO.File.Exists(GoonTools.Common.Option.CustomThemeLocation) && GoonTools.Common.Option.CustomTheme != "System")
//					{
//						Gtk.Rc.Parse(GoonTools.Common.Option.CustomThemeLocation);
//						Gtk.Rc.ResetStyles( Gtk.Settings.GetForScreen(Gdk.Screen.Default) );
//					}
//					else
//					{
//						Gtk.Rc.ResetStyles(Gtk.Settings.Default);
//					}
//				}
//			}
			
		}
		
		
		protected virtual void OnCbxLimitRecordsToggled (object sender, System.EventArgs e)
		{
			spnDefaultHistory.Sensitive = cbxLimitRecords.Active;
		}
	}
}