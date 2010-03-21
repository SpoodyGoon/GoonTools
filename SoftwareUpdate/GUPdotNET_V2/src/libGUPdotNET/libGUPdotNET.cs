/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 3/19/2010
 * Time: 10:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Gtk;
using System.Reflection;
using GoonTools;

namespace libGUPdotNET
{
	/// <summary>
	/// Description of libGUPdotNET.
	/// </summary>
	public class GUPdotNET
	{
		public GUPdotNET()
		{
			try
			{
				
				Common.LoadAll();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
			}
		}

		public void ShowOptions()
		{
			frmOptions fm = new frmOptions();
			fm.Run();
			fm.Destroy();
		}

		public void RunUpdate()
		{
			UpdateCheck.RunUpdate();
		}
	}
}
