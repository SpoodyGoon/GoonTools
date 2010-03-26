/*************************************************************************
 *                      MainWindow.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.Configuration;
using so = System.IO;
using System.Data;
using System.Diagnostics;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{


	public partial class MainWindow : Gtk.Window
	{
		Reports.EntryRptTreeView tvEntityRpt;
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			try
			{
				tvEntityRpt = new Reports.EntryRptTreeView (cboUser.UserID);
				swEntityRpt.Add (tvEntityRpt);
				cboUser.Changed += new EventHandler(cboUser_Changed);
				tvEntityRpt.CursorChanged += delegate(object sender, EventArgs e) { btnRemoveEntry.Sensitive = true; btnEditEntry.Sensitive = true; };
				// the update feature is available only
				// for Windows and non-repository Linux versions
				if(ConfigurationManager.AppSettings["ShowUpdate"].ToLower() == "false")
				{
					UpdatesAction.Visible = false;
					UpdatesAction.VisibleHorizontal = false;
					UpdatesAction.VisibleOverflown = false;
					UpdatesAction.VisibleVertical = false;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			this.ShowAll ();
		}
		
		#region Private Window Events
		
		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			Common.SaveUserData();
			Application.Quit();
		}
		
		#endregion Private Window Events

		private void cboUser_Changed(object sender, EventArgs e)
		{
			tvEntityRpt.Refresh(cboUser.UserID);
		}

		protected virtual void OnNewEntryActionActivated (object sender, System.EventArgs e)
		{
			frmEntry fm = new frmEntry ();
			if(cboUser.UserID > -1)
				fm.UserID = cboUser.UserID;
			fm.WindowPosition = WindowPosition.Mouse;
			if((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok)
				tvEntityRpt.Refresh();
			fm.Destroy ();
		}

		protected virtual void OnMedicationActionActivated (object sender, System.EventArgs e)
		{
			frmMedication fm = new frmMedication ();
			fm.UserID = cboUser.UserID;
			fm.ParentWindow = this.GdkWindow;
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnDoctorsActionActivated (object sender, System.EventArgs e)
		{
			frmDoctors fm = new frmDoctors ();
			fm.UserID = cboUser.UserID;
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnUsersActionActivated (object sender, System.EventArgs e)
		{
			// TODO: when returning from the users dialog we need to refresh the user
			// combo box to reflect the changes
			frmUsers fm = new frmUsers ();
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
		{
			Gtk.AboutDialog.SetUrlHook(delegate(Gtk.AboutDialog dialog, string link) {
			                           	Common.LaunchURL(link);
			                           });
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
				Gtk.AboutDialog ad = new Gtk.AboutDialog();
				ad.Title = "About Mono Blood Pressure Monitor";
				ad.ProgramName = "Mono Blood Pressure Monitor";
				ad.Comments = "Simple .NET Blood Pressure Monitor written in Mono/Gtk# using SQLite for data storage.\n\nIt include methods to track medication as well as doctors but it's main focus is the simple tracking and reporting of blood pressure readings.";
				ad.License = GoonTools.Const.License;
				ad.Authors = new String[]{"Andrew York <goontools@brdstudio.net>"};
				ad.Version = asm.GetName().Version.Major.ToString() + "." + asm.GetName().Version.Minor.ToString() + " alpha";
				ad.Logo = Gdk.Pixbuf.LoadFromResource("icon_large.png");
				ad.Icon = Gdk.Pixbuf.LoadFromResource("icon_small.png");
				ad.AllowShrink = false;
				ad.AllowGrow = false;
				ad.DestroyWithParent = true;
				ad.Parent = this;
				ad.Copyright = "GoonTools 2009";
				ad.HasSeparator = true;
				ad.Modal = true;
				ad.WidthRequest = 550;
				ad.HeightRequest = 300;
				ad.WebsiteLabel = "MonoBPMonitor Project Site";
				ad.Website = "http://code.google.com/p/goontools/wiki/MonoBPMonitor";
				ad.WindowPosition = WindowPosition.Mouse;
				ad.Run();
				ad.Destroy();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}

		protected virtual void OnEditaddPngActionActivated (object sender, System.EventArgs e)
		{
			frmEntry fm = new frmEntry ();
			fm.UserID = cboUser.UserID;
			fm.WindowPosition = WindowPosition.Mouse;
			if((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok)
				tvEntityRpt.Refresh();
			
			fm.Destroy ();
		}

		protected virtual void OnEdituserPngActionActivated (object sender, System.EventArgs e)
		{
			frmUsers fm = new frmUsers ();
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnExitPngActionActivated (object sender, System.EventArgs e)
		{
			Common.SaveUserData();
			Gtk.Application.Quit ();
		}

		protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			Common.SaveUserData();
			Gtk.Application.Quit ();
		}

		protected virtual void OnPreferencesActionActivated (object sender, System.EventArgs e)
		{
			frmOptions fm = new frmOptions ();
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run ();
			fm.Destroy ();
			tvEntityRpt.Refresh (true);
		}

		protected virtual void OnRxPngActionActivated (object sender, System.EventArgs e)
		{
			frmMedication fm = new frmMedication ();
			fm.UserID = cboUser.UserID;
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnDoctorPngActionActivated (object sender, System.EventArgs e)
		{
			frmDoctors fm = new frmDoctors ();
			fm.UserID = cboUser.UserID;
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnErrorLogActionActivated (object sender, System.EventArgs e)
		{
			frmErrorLog fm = new frmErrorLog ();
			fm.WindowPosition = WindowPosition.Mouse;
			fm.Run();
			fm.Destroy();
		}
		
		protected virtual void OnBtnAddEntryClicked (object sender, System.EventArgs e)
		{
			try
			{
				frmEntry fm = new frmEntry ();
				fm.UserID = cboUser.UserID;
				fm.WindowPosition = WindowPosition.Mouse;
				if((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok)
					tvEntityRpt.Refresh();
				
				fm.Destroy ();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		protected virtual void OnBtnRemoveEntryClicked (object sender, System.EventArgs e)
		{
			try
			{
				tvEntityRpt.SelectedEntry.Remove();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		protected virtual void OnBtnEditEntryClicked (object sender, System.EventArgs e)
		{
			try
			{
				if(tvEntityRpt.SelectedEntryID > -1)
				{
					frmEntry fm = new frmEntry(tvEntityRpt.SelectedEntryID);
					fm.UserID = cboUser.UserID;
					if((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok)
						tvEntityRpt.Refresh();
					
					fm.Destroy ();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		#region Update Related
		
		protected virtual void OnUpdatesActionActivated (object sender, System.EventArgs e)
		{
			try
			{
				libGUPdotNET.GUPdotNET g  = new libGUPdotNET.GUPdotNET();
				g.ShowOptions();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		private void RunUpdate(bool showoptions)
		{
			try
			{
				
				
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		#endregion Update Related
		
		protected virtual void OnProjectWebSiteActionActivated (object sender, System.EventArgs e)
		{
			if(ConfigurationManager.AppSettings["ProjectSiteURL"] != "")
			{
				Common.LaunchURL(ConfigurationManager.AppSettings["ProjectSiteURL"]);
			}
			else
			{
				Common.HandleError(this, new Exception("Project web site URL not set in the configuation file"));
			}
		}
		
		protected virtual void OnOnlineDocumentationActionActivated (object sender, System.EventArgs e)
		{
			if(ConfigurationManager.AppSettings["OnlineHelpURL"] != "")
			{
				Common.LaunchURL(ConfigurationManager.AppSettings["OnlineHelpURL"]);
			}
			else
			{
				Common.HandleError(this, new Exception("Online Documentation URL not set in the configuation file"));
			}
		}
		
		protected virtual void OnIssuesFeatureRequestsActionActivated (object sender, System.EventArgs e)
		{
			if(ConfigurationManager.AppSettings["ProjectIssuesURL"] != "")
			{
				Common.LaunchURL(ConfigurationManager.AppSettings["ProjectIssuesURL"]);
			}
			else
			{
				Common.HandleError(this, new Exception("Project Issues/Feature Request URL not set in the configuation file"));
			}
		}
		
		
	}

}
