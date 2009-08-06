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
