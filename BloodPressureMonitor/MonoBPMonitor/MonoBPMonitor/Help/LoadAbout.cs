/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 8/5/2009
 * Time: 3:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Gtk;
using Glade;

namespace MonoBPMonitor
{
	/// <summary>
	/// Description of LoadAbout.
	/// </summary>
	public class LoadAbout
	{
		public LoadAbout()
		{
		}
		
		public void Show()
		{
			try
			{
				Glade.XML gxml = new Glade.XML(null, "frmAbout.xml", "frmAbout", null);
				gxml.Autoconnect(this);
				
			}
			catch(Exception ex)
			{
				GoonTools.Common.EnvData.HandleError(ex);
			}
		}
	}
}
