// 
// frmOptions.cs
//  
// Author:
//       Andy York <goontools@brdstudio.net>
// 
// Copyright (c) 2009 Andy York
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Gtk;

namespace GUPdotNET
{
	public partial class frmOptions : Gtk.Dialog
	{

		private bool _Loading = false;
		private Gdk.Cursor ctLink = new Gdk.Cursor(Gdk.CursorType.Hand1);
		public frmOptions()
		{
			_Loading = true;
			this.Build();			
			LoadControls();
			this.Visible = true;
			this.ShowAll();
			_Loading = false;
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
		
		
		
		private void RunUpdate(UpdateInfo _UpdateInfo)
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

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnBtnOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		
		protected virtual void OnBtnCheckNowClicked (object sender, System.EventArgs e)
		{
			UpdateInfo _UpdateInfo = new UpdateInfo();
			_UpdateInfo.LoadInfo(UpdateInfoType.All);
			if(_UpdateInfo.UpdateAvailable)
			{
				RunUpdate(_UpdateInfo);
			}
			else
			{
				MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "No Update Available", "No Update Available");
				md.Run();
				md.Destroy();
			}
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

	}
}
