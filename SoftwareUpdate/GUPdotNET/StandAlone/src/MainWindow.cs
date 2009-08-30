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
		UpdateInfo _UpdateInfo = new UpdateInfo();
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
			if(DateTime.Compare(DateTime.Now, Common.Option.LastUpdateCheck.AddHours(Common.Option.UpdateHours)) > 1)
				return true;
			else
				return false;
		}
		
		#region Option Widget Loading
		
		private void LoadControls()
		{
			try
			{
				cboUpdateTimeType.SetHours(Common.Option.UpdateHours);
				cbxAutoUpdate.Active = Common.Option.AutoUpdate;
				if(cbxAutoUpdate.Active == false)
					frame1.Sensitive = false;
				else
					frame1.Sensitive = true;
				
				cboUpdateTimeType.Changed += new EventHandler(OnCboUpdateTimeTypeChanged);
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
				if(!_Loading)
				{
					Common.Option.AutoUpdate = (bool)cbxAutoUpdate.Active;
					if((bool)cbxAutoUpdate.Active == false)
					{
						_Loading = true;
						cboUpdateTimeType.SetTimeDisplay("Never");
						frame1.Sensitive = false;
						_Loading = false;
					}
					else
					{
						_Loading = true;
						if(cboUpdateTimeType.TimeDisplay == "Never")
							cboUpdateTimeType.SetTimeDisplay("Day");
						frame1.Sensitive = true;
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
				if(!_Loading)
				{
					if((string)cboUpdateTimeType.TimeDisplay == "Never")
					{
						_Loading = true;
						cbxAutoUpdate.Active = false;
						frame1.Sensitive = false;
						_Loading = false;
					}
					else
					{						
						_Loading = true;
						cbxAutoUpdate.Active = true;
						frame1.Sensitive = true;
						_Loading = false;
					}
					Common.Option.UpdateTime = (string)cboUpdateTimeType.ActiveText;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		protected virtual void OnBtnAboutClicked (object sender, System.EventArgs e)
		{
			btnAbout.Relief = Gtk.ReliefStyle.None;
			btnAbout.State = Gtk.StateType.Normal;
			btnAbout.ShowNow();
			try
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
				ad.WidthRequest = 400;
//				ad.HeightRequest = 300;
				ad.Website = "http://code.google.com/p/goontools/wiki/GUPdotNet";
				ad.WebsiteLabel = "GUPdotNET Web Site";
				ad.Parent = this;
				ad.Run();
				
				btnAbout.Relief = Gtk.ReliefStyle.None;
				btnAbout.State = Gtk.StateType.Normal;
				btnAbout.ShowNow();
				ad.Destroy();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		
		protected virtual void OnBtnAboutEntered (object sender, System.EventArgs e)
		{
			btnAbout.Relief = Gtk.ReliefStyle.None;
			btnAbout.State = Gtk.StateType.Normal;
			btnAbout.ShowNow();
		}
		
		
		protected virtual void OnBtnAboutPressed (object sender, System.EventArgs e)
		{
			btnAbout.Relief = Gtk.ReliefStyle.None;
			btnAbout.State = Gtk.StateType.Normal;
			btnAbout.ShowNow();
		}
		
		
		protected virtual void OnBtnAboutActivated (object sender, System.EventArgs e)
		{
			btnAbout.Relief = Gtk.ReliefStyle.None;
			btnAbout.State = Gtk.StateType.Normal;
			btnAbout.ShowNow();
		}
		
		
		protected virtual void OnBtnAboutReleased (object sender, System.EventArgs e)
		{
			btnAbout.Relief = Gtk.ReliefStyle.None;
			btnAbout.State = Gtk.StateType.Normal;
			btnAbout.ShowNow();
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
	
	}
}
