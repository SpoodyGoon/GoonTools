/*************************************************************************
 *                      ThemeComboBox.cs
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
using so = System.IO;
using GoonTools;

namespace MonoBPMonitor.Themes
{
	/// <summary>
	/// Description of ThemeComboBox.
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
	[System.Drawing.ToolboxBitmapAttribute(typeof(Gtk.ComboBox))]
	public class ThemeComboBox : Gtk.ComboBox
	{
		private Gtk.ListStore lsTheme = new Gtk.ListStore(typeof(string), typeof(string));
		private string _ThemeLoc;
		private string _ThemeName;
		private string _SearchThemeLoc;
		private string _SearchThemeName;
		private bool _IsLoading = false;
		public ThemeComboBox()
		{
		}
		
		
		
		private void Build()
		{
			so.DirectoryInfo[] dis;
			so.DirectoryInfo di;
			// if themes are allow load them
			if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "true")
			{
				lsTheme.AppendValues("System", "System");				
				// load the custom themes from the locations
				if(so.Directory.Exists(Common.EnvData.ThemeFolder))
				{
					di = new so.DirectoryInfo(Common.EnvData.ThemeFolder);
					dis = di.GetDirectories();
					for(int i = 0; i< dis.Length; i++)
					{
						lsTheme.AppendValues(dis[i].FullName + Common.EnvData.DirChar + "gtk-2.0" + Common.EnvData.DirChar + "gtkrc", dis[i].Name);
					}
				}
				if(so.Directory.Exists(Common.EnvData.AltThemeFolder))
				{
					di = new so.DirectoryInfo(Common.EnvData.AltThemeFolder);
					dis = di.GetDirectories();
					for(int i = 0; i< dis.Length; i++)
					{
						lsTheme.AppendValues(dis[i].FullName, dis[i].Name);
					}
				}
			}
			lsTheme.SetSortFunc(1, DirectoryNameTreeIterCompareFunc );
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			this.PackStart(ct, true);
			this.AddAttribute(ct, "text", 1);
			this.Model = lsTheme;
			Gtk.TreeIter iter;
			if(lsTheme.GetIterFirst(out iter))
				this.SetActiveIter(iter);
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnRealized ()
		{
			Build();
			this.WidthRequest = 150;
			base.OnRealized ();
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnChanged ()
		{
			try
			{
				if(!_IsLoading)
				{
					Gtk.TreeIter iter;
					if(this.GetActiveIter(out iter))
					{
						_ThemeLoc = (string)lsTheme.GetValue(iter, 0);
						_ThemeName =  (string)lsTheme.GetValue(iter, 1);
					}
				}
				base.OnChanged ();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public int DirectoryNameTreeIterCompareFunc(TreeModel model, TreeIter a, TreeIter b)
		{
			return StringFieldCompare(model.GetValue(a, 1).ToString(), model.GetValue(b, 1).ToString());
		}
		
		private int StringFieldCompare(string a, string b)
		{
			if(a != null)
				a = a.ToLower();
			
			if(b != null)
				b = b.ToLower();
			
			return String.Compare(a, b);
		}
		
		#region Public Properties
		
		public string ThemeName
		{
			get{return _ThemeName;}
		}
		
		public string ThemeLoc
		{
			get{return _ThemeLoc;}
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public void SetThemeName(string themename)
		{
			_SearchThemeName = themename;
			lsTheme.Foreach(new TreeModelForeachFunc(ForeachThemeName));
			
		}
		
		public void SetTheme(string themeloc)
		{
			_SearchThemeLoc = themeloc;
			lsTheme.Foreach(new TreeModelForeachFunc(ForeachThemeLoc));
		}
		
		#endregion Public Methods
		
		private bool ForeachThemeName(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchThemeName == lsTheme.GetValue(iter, 1).ToString())
			{
				_ThemeName = lsTheme.GetValue(iter, 1).ToString();
				_ThemeLoc = lsTheme.GetValue(iter, 0).ToString();
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
		
		private bool ForeachThemeLoc(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchThemeLoc ==lsTheme.GetValue(iter, 0).ToString())
			{
				_ThemeName = lsTheme.GetValue(iter, 1).ToString();
				_ThemeLoc = lsTheme.GetValue(iter, 0).ToString();
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
	}
}
