/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 10/5/2009
 * Time: 12:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Gtk;

namespace MonoBPMonitor.Reports
{
	/// <summary>
	/// Description of CellRenderLinkButton.
	/// </summary>
	public class CellRenderLinkButton : Gtk.CellView 
	{
		private Gdk.Cursor ctLink = new Gdk.Cursor(Gdk.CursorType.Hand1);
		private Gtk.Label lblText = new Gtk.Label();
		private string _MouseOutColor  = "#920000";
		private string _MouseOverColor  = "#000000";
		private string _Text = "Link Button";
		public CellRenderLinkButton(string text)
		{
			_Text = text;
			lblText.LeaveNotifyEvent += new LeaveNotifyEventHandler(lblText_LeaveNotifyEvent);
			lblText.EnterNotifyEvent += new EnterNotifyEventHandler(lblText_EnterNotifyEvent);
			lblText.ButtonReleaseEvent += new ButtonReleaseEventHandler(lblText_ButtonReleaseEvent);
			

		}
		
		public CellRenderLinkButton()
		{
		}
		



		protected void lblText_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
		{
//			Gtk.MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, false, "Link Fired");
//			md.Run();
//			md.Destroy();
		}

		protected void lblText_EnterNotifyEvent(object o, EnterNotifyEventArgs args)
		{
//			this.GdkWindow.Cursor = ctLink;
//			lblText.Text = "<span size=\"7500\" color=\"" + _MouseOverColor + "\"><b><u><tt>" + _Text + "</tt></u></b></span>";
//			lblText.UseMarkup = true;
//			lblText.ShowNow();
		}

		protected void lblText_LeaveNotifyEvent(object o, LeaveNotifyEventArgs args)
		{
//			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.LastCursor);
//			lblText.Text = "<span size=\"7500\" color=\"" + _MouseOutColor + "\"><b><u><tt>" + _Text + "</tt></u></b></span>";
//			lblText.UseMarkup = true;
//			lblText.ShowNow();
		}
		 
		#region Public Proporties
		
		public string Text
		{
			set{_Text = value;}
			get{return _Text;}
		}
		
		public string MouseOutColor
		{
			set{_MouseOutColor = value;}
			get{ return _MouseOutColor;}
		}
		
		public string MouseOverColor
		{
			set{_MouseOverColor = value;}
			get{ return _MouseOverColor;}
		}
		 
		 #endregion Public Proporties
		 
		 #region Public Events
		 
		 
		 
		 #endregion Public Events
		 
		 
	}
}
