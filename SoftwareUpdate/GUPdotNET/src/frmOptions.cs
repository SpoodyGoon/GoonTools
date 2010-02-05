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
		// this variable is used to not fire a combobox change event
		// during loading the controls
		private bool _Loading = false;
		private int _Result = 0;
		public frmOptions()
		{
			try
			{
				this.Build();
				_Loading = true;
				// load the controls for display;
				LoadControls();
				_Loading = false;
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			this.ShowAll();
		}
		
		public int Result
		{
			get{return _Result;}
		}
		
		#region Option Widget Loading
		
		// load the controls from the options.dat
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
		
		#region About Dialog Related
		
		
		protected virtual void OnEbxAboutButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
			try
			{
				Gtk.AboutDialog.SetUrlHook(delegate(Gtk.AboutDialog dialog, string link) {
				                           	System.Diagnostics.Process.Start(link);
				                           });
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
				ad.AllowShrink = false;
				ad.AllowGrow = false;
				ad.DestroyWithParent = true;
				ad.Copyright = "GoonTools 2009";
				ad.HasSeparator = true;
				ad.Modal = true;
				ad.BorderWidth = 8;
				ad.WidthRequest = 450;
//				ad.HeightRequest = 300;
				ad.Website = "http://code.google.com/p/goontools/wiki/GUPdotNet";
				ad.WebsiteLabel = "GUPdotNET Web Site";
				ad.WindowPosition = WindowPosition.Mouse;
				ad.Parent = this;
				ad.Run();
				
				ad.Destroy();
			}catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		

		// when the mouse if over the label
		// change it to behave like a link button
		protected virtual void OnEbxAboutEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand1);
			lblAbout.Text = "<span size=\"8080\" color=\"#920000\"><b><u><tt>About GUPdotNET</tt></u></b></span>";
			lblAbout.UseMarkup = true;
			lblAbout.ShowNow();
		}

		// when the mouse gose away from the label return it to its previous state
		// so it behaves like a link button
		protected virtual void OnEbxAboutLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
			lblAbout.Text = "<span size=\"8080\" color=\"#000000\"><b><u><tt>About GUPdotNET</tt></u></b></span>";
			lblAbout.UseMarkup = true;
			lblAbout.ShowNow();
		}
		
		#endregion About Dialog Related
		
		#region Dialog Command Buttons

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Respond(Gtk.ResponseType.Cancel);
			this.Hide();
		}

		protected virtual void OnBtnOkClicked (object sender, System.EventArgs e)
		{
			Common.SaveOptions();
			this.Respond(Gtk.ResponseType.Ok);
			this.Hide();
		}
		
		#endregion Dialog Command Buttons
		
		#region Option Widget Events
		
		protected virtual void OnBtnCheckNowClicked (object sender, System.EventArgs e)
		{
			UpdateCheck uc = new UpdateCheck();
			uc.RunUpdate(true);
		}

		// event for the update check box
		protected virtual void OnCbxAutoUpdateToggled (object sender, System.EventArgs e)
		{
			try
			{
				if (!_Loading)
				{
					if ((bool)cbxAutoUpdate.Active == false)
					{
						_Loading = true;
						cboUpdateTime.SetTimeDisplay ("Never");
						// if we are not having a update check update disable the combobox
						fraCheckLimits.Sensitive = false;
						_Loading = false;
					}
					else
					{
						_Loading = true;
						if(cboUpdateTime.TimeDisplay == "Never")
							cboUpdateTime.SetTimeDisplay("Day");
						// if we are allowing an update enable the combobox
						fraCheckLimits.Sensitive = true;
						_Loading = false;
					}
					// update the options.dat file
					Common.Option.AutoUpdate = (bool)cbxAutoUpdate.Active;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		// event for the amount of time between update checks
		protected virtual void OnCboUpdateTimeTypeChanged (object sender, System.EventArgs e)
		{
			try
			{
				if (!_Loading)
				{
					// if these is no updated needed update the checkbox also
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
					// update the options.dat file
					Common.Option.UpdateTime = (string)cboUpdateTime.TimeDisplay;
					Common.Option.UpdateHours = (int)cboUpdateTime.Hours;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
		
		#endregion Option Widget Events

	}
}
