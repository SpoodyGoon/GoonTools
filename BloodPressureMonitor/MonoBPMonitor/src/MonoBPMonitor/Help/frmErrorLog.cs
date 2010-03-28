/*************************************************************************
 *                      frmErrorLog.cs
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
using GoonTools;


namespace MonoBPMonitor
{
	
	
	public partial class frmErrorLog : Gtk.Dialog
	{
		public frmErrorLog()
		{
			this.Build();
			// TODO add to stectic
			txtErrorLog.WrapMode = Gtk.WrapMode.Word;
			LoadErrorLog();			
		}
		
		private void LoadErrorLog()
		{
			try
			{
				string strFile = System.IO.Path.GetFullPath(Common.EnvData.ErrorLog);
				if(System.IO.File.Exists(strFile))
				{
					System.IO.StreamReader sr = new System.IO.StreamReader(strFile);
					string tmpLog =  sr.ReadToEnd();
					if(tmpLog.Length > 6)
					{
						txtErrorLog.Buffer.Text = tmpLog;
						btnClearLog.Sensitive = true;
					}
					else
					{
						txtErrorLog.Buffer.Text = "No log available";
						btnClearLog.Sensitive = false;
					}
					sr.Close();
					sr.Dispose();
				}
				else
				{
					txtErrorLog.Buffer.Text = "No log available";
					btnClearLog.Sensitive = false;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		
		protected virtual void OnBtnClearLogClicked (object sender, System.EventArgs e)
		{
			Common.CleanErrorLog();
			LoadErrorLog();
		}
	}
}
