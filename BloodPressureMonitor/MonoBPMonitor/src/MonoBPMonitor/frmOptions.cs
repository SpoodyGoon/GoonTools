
using System;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmOptions : Gtk.Dialog
	{


	
		public frmOptions ()
		{
			// TODO: add checkbox to not have any sort at all.
			this.Build();
			
			spnDefaultHistory.Value = (double)GoonTools.Common.Option.HistoryDefaultShow;
			cbxLogErrors.Active = GoonTools.Common.Option.SaveErrorLog;
			themecombobox1.SetThemeName(Common.Option.CustomTheme);
			btnApply.Clicked += new EventHandler(btnApply_Clicked);
			btnOk.Clicked += new EventHandler(btnOk_Clicked);
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
			GoonTools.Common.Option.HistoryDefaultShow=Convert.ToInt32(spnDefaultHistory.Value);
			GoonTools.Common.Option.SaveErrorLog= cbxLogErrors.Active;
			GoonTools.Common.Option.CustomTheme = themecombobox1.ThemeName;
			GoonTools.Common.Option.CustomThemeLocation = themecombobox1.ThemeLoc;
			GoonTools.Common.SaveOptions();
			if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "true")
			{
				if(System.IO.File.Exists(GoonTools.Common.Option.CustomThemeLocation) && GoonTools.Common.Option.CustomThemeLocation != "System")
				{
					Gtk.Rc.Parse(GoonTools.Common.Option.CustomThemeLocation);
					
				}
				else
				{
					Gtk.Rc.Parse("");
				}
			}
			
		}
	}
}
