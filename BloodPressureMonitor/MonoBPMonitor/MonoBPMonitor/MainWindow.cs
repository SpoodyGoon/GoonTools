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
			tvEntityRpt = new Reports.EntryRptTreeView (cboUser.UserID);
			swEntityRpt.Add (tvEntityRpt);
			this.ShowAll ();
		}

		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{

		}

		protected virtual void OnNewEntryActionActivated (object sender, System.EventArgs e)
		{
			frmBPEntry fm = new frmBPEntry ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnMedicationActionActivated (object sender, System.EventArgs e)
		{
			frmMedication fm = new frmMedication ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnDoctorsActionActivated (object sender, System.EventArgs e)
		{
			frmDoctors fm = new frmDoctors ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnUsersActionActivated (object sender, System.EventArgs e)
		{
			frmUsers fm = new frmUsers ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
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
			ad.AllowShrink = true;
			ad.AllowGrow = true;
			ad.Copyright = "GoonTools 2009";
			ad.HasSeparator = true;
			ad.Modal = true;
			ad.WidthRequest = 550;
			ad.HeightRequest = 300;
			ad.Website = "http://brdstudio.net/mbpmonitor/";
			ad.WebsiteLabel = "http://brdstudio.net/mbpmonitor/";
			ad.Run();
			ad.Destroy();
		}

		protected virtual void OnEditaddPngActionActivated (object sender, System.EventArgs e)
		{
			frmBPEntry fm = new frmBPEntry ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnEdituserPngActionActivated (object sender, System.EventArgs e)
		{
			frmUsers fm = new frmUsers ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnExitPngActionActivated (object sender, System.EventArgs e)
		{
			Gtk.Application.Quit ();
		}

		protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			Gtk.Application.Quit ();
		}

		protected virtual void OnPreferencesActionActivated (object sender, System.EventArgs e)
		{
			frmOptions fm = new frmOptions ();
			fm.Run ();
			fm.Destroy ();
			tvEntityRpt.Refresh (true);
		}

		protected virtual void OnRxPngActionActivated (object sender, System.EventArgs e)
		{
			frmMedication fm = new frmMedication ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnDoctorPngActionActivated (object sender, System.EventArgs e)
		{
			frmDoctors fm = new frmDoctors ();
			fm.Run ();
			fm.Destroy ();
		}

		protected virtual void OnErrorLogActionActivated (object sender, System.EventArgs e)
		{
			frmErrorLog fm = new frmErrorLog ();
			fm.Run();
			fm.Destroy();
		}
	}

}
