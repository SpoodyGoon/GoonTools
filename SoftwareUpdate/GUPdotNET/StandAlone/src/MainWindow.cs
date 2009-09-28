/*************************************************************************
 *                      MainWindow.cs
 *
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>
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


namespace GUPdotNET
{
	public partial class MainWindow : Gtk.Window
	{
		private bool _SilentCheck = false;
		private bool _Loading = false;
		private UpdateInfo _UpdateInfo = new UpdateInfo();
		private string _UserSaveLoc = null;
		private Gdk.Cursor ctLink = new Gdk.Cursor(Gdk.CursorType.Hand1);
		public MainWindow(bool blnSilentCheck) :  base(Gtk.WindowType.Toplevel)
		{
			_Loading = true;
			_SilentCheck = blnSilentCheck;
			this.Build();
			
			if(_SilentCheck)
			{
				
				// This is for checking for updates in the background
				// notifying the user only if an update is avalaiable
				this.SkipPagerHint = true;
				this.SkipTaskbarHint = true;
				this.Visible = false;
				if(TimeForCheck())
				{
					
					_UpdateInfo.LoadInfo(UpdateInfoType.All);
					_UpdateInfo.SilentCheck = true;
					if(_UpdateInfo.UpdateAvailable)
						RunUpdate();
				}
			}
			else
			{
				// this is for showing the options and optionally running an update check manually
				this.SkipPagerHint = false;
				this.SkipTaskbarHint = false;
				this.Visible = true;
				LoadControls();
			}
			_Loading = false;
			this.ShowAll();
		}
		
		private bool TimeForCheck()
		{
			if(System.Configuration.ConfigurationManager.AppSettings["Debug"].ToString()== "true")
				Console.WriteLine("Debug - Time for Check: " + DateTime.Compare(DateTime.Now, Common.Option.LastUpdateCheck.AddHours(Common.Option.UpdateHours)).ToString());
			if(DateTime.Compare(DateTime.Now, Common.Option.LastUpdateCheck.AddHours(Common.Option.UpdateHours)) > 0)
				return true;
			else
				return false;
		}
		
		public string UserSaveLoc
		{
			set{_UserSaveLoc = value;}
			get{return _UserSaveLoc;}
		}
		
		#region Option Widget Loading
		
		private void LoadControls ()
		{
			try
			{
				cboUpdateTime.SetHours (Common.Option.UpdateHours);
				cbxAutoUpdate.Active = Common.Option.AutoUpdate;
				if (cbxAutoUpdate.Active == false)
					fraCheckLimits.Sensitive = false;
				else
					fraCheckLimits.Sensitive = true;
				
				cboUpdateTime.Changed += new EventHandler(OnCboUpdateTimeTypeChanged);
				lblLastCheck.Text = Common.Option.LastUpdateCheck.ToShortDateString();
				lblLastUpdate.Text = Common.Option.LastUpdate.ToShortDateString();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		#endregion Option Widget Loading
		
		#region Widget Events
		
		protected virtual void OnBtnCheckNowClicked (object sender, System.EventArgs e)
		{
			if(_UpdateInfo.UpdateAvailable)
			{
				RunUpdate();
			}
			else
			{
				MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "No Update Available", "No Update Available");
				md.Run();
				md.Destroy();
			}
		}
		
		
		protected virtual void OnbtnCloseClicked (object sender, System.EventArgs e)
		{
			Common.SaveOptions();
			Gtk.Application.Quit();
		}
		
		protected virtual void OnCbxAutoUpdateToggled (object sender, System.EventArgs e)
		{
			try
			{
				if (!_Loading)
				{
					Common.Option.AutoUpdate = (bool)cbxAutoUpdate.Active;
					if ((bool)cbxAutoUpdate.Active == false)
					{
						_Loading = true;
						cboUpdateTime.SetTimeDisplay ("Never");
						fraCheckLimits.Sensitive = false;
						_Loading = false;
					}
					else
					{
						_Loading = true;
						if(cboUpdateTime.TimeDisplay == "Never")
							cboUpdateTime.SetTimeDisplay("Day");
						fraCheckLimits.Sensitive = true;
						_Loading = false;
					}
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}		
		
		protected virtual void OnCboUpdateTimeTypeChanged (object sender, System.EventArgs e)
		{
			try
			{
				if (!_Loading)
				{
					if ((string)cboUpdateTime.TimeDisplay == "Never")
					{
						_Loading = true;
						cbxAutoUpdate.Active = false;
						fraCheckLimits.Sensitive = false;
						_Loading = false;
					}
					else
					{

						_Loading = true;
						cbxAutoUpdate.Active = true;
						fraCheckLimits.Sensitive = true;
						_Loading = false;
					}
					Common.Option.UpdateTime = (string)cboUpdateTime.TimeDisplay;
					Common.Option.UpdateHours = (int)cboUpdateTime.Hours;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			if(!_SilentCheck)
				Common.SaveOptions();
			
			Gtk.Application.Quit();
		}

		#endregion Widget Events
		
		private void RunUpdate()
		{
			// tell the user there is an update availalbe
			// and ask if they would like to update
			frmConfirm dlgConfirm = new frmConfirm(_UpdateInfo);
			if((Gtk.ResponseType)dlgConfirm.Run() == Gtk.ResponseType.Yes)
			{
				// update confirmed get installer file
				frmDownload dlgDownload = new frmDownload(_UpdateInfo);
				if((Gtk.ResponseType)dlgDownload.Run() == Gtk.ResponseType.Ok)
				{
					// if the download was sucessful then procede with the install
					frmInstall Inst = new frmInstall(_UpdateInfo);
					Inst.Run();
					Inst.Destroy();
					
				}
				dlgDownload.Destroy();
			}
			else
			{
				Application.Quit();
			}
			dlgConfirm.Destroy();
		}
		
		
		protected virtual void OnEbxAboutButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
				Gtk.AboutDialog ad = new Gtk.AboutDialog();
				ad.Title = "About GUPdotNET";
				ad.ProgramName = "GUPdotNET";
				ad.Comments ="General Purpose Update program for Mono/Gtk#.";
				ad.License = GUPdotNET.Const.License;
				ad.Authors = new String[]{"Andrew York <goontools@brdstudio.net>"};
				ad.Version = " " + asm.GetName().Version.Major.ToString() + "." + asm.GetName().Version.Minor.ToString() + " alpha";
				ad.Logo = Gdk.Pixbuf.LoadFromResource("update_large.png");
				ad.Icon = Gdk.Pixbuf.LoadFromResource("update_small.png");
				ad.AllowShrink = true;
				ad.AllowGrow = true;
				ad.Copyright = "GoonTools 2009";
				ad.HasSeparator = true;
				ad.Modal = true;
				ad.BorderWidth = 8;
				ad.WidthRequest = 450;
//				ad.HeightRequest = 300;
				ad.Website = "http://code.google.com/p/goontools/wiki/GUPdotNet";
				ad.WebsiteLabel = "GUPdotNET Web Site";
				ad.Parent = this;
				ad.Run();
				
				ad.Destroy();
		}
		
		
		protected virtual void OnEbxAboutEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = ctLink;
			lblAbout.Text = "<span size=\"7500\" color=\"#920000\"><b><u><tt>About GUPdotNET</tt></u></b></span>";
			lblAbout.UseMarkup = true;
			lblAbout.ShowNow();
		}
		
		
		protected virtual void OnEbxAboutLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.LastCursor);
			lblAbout.Text = "<span size=\"7500\" color=\"#00006B\"><b><u><tt>About GUPdotNET</tt></u></b></span>";
			lblAbout.UseMarkup = true;
			lblAbout.ShowNow();
		}
		
		
		protected virtual void OnEbxAboutButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
		}
		
		
		protected virtual void OnCbxAutoUpdateClicked (object sender, System.EventArgs e)
		{
		}
		
		
		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			Application.Quit();
		}












		
	}
}
