/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/3/2010
 * Time: 3:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using so = System.IO;
using Gtk;
using GoonTools;

namespace MonoBPMonitor.Data
{
	[System.ComponentModel.ToolboxItem(true)]
	public class ThemeComboBox : Gtk.ComboBox
	{
		private Gtk.ListStore _ListStore = new Gtk.ListStore(typeof(string), typeof(string));
		private string _ThemeLocation;
		private string _ThemeName;
		private string _SearchThemeName;
		private bool _IsLoading = false;
		public ThemeComboBox()
		{
			Build();
		}
		
		private void Build()
		{
			Load();
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			this.PackStart(ct, true);
			this.AddAttribute(ct, "text", 1);
			this.Model = _ListStore;
			Gtk.TreeIter iter;
			if(! string.IsNullOrEmpty(Common.Option.CustomThemeName))
			{
				SetTheme(Common.Option.CustomThemeName);
			}
			else
			{
				if(_ListStore.GetIterFirst(out iter))
					this.SetActiveIter(iter);
			}
		}
		
		private void Load()
		{
			try
			{
				_IsLoading = true;
				_ListStore.Clear();
				so.DirectoryInfo di =  new so.DirectoryInfo(Common.EnvData.ThemeFolder);
				so.DirectoryInfo[] dis = di.GetDirectories();
				for(int i = 0; i < dis.Length; i ++)
				{
					so.FileInfo fi = new so.FileInfo(so.Path.Combine(so.Path.Combine(dis[i].FullName, "gtk-2.0"), "gtkrc"));
					if(fi.Exists)
					{
						_ListStore.AppendValues(fi.FullName, dis[i].Name);
					}
				}
				di =  new so.DirectoryInfo(Common.EnvData.UserThemeFolder);
				dis = di.GetDirectories();
				for(int i = 0; i < dis.Length; i ++)
				{
					so.FileInfo fi = new so.FileInfo(so.Path.Combine(so.Path.Combine(dis[i].FullName, "gtk-2.0"), "gtkrc"));
					if(fi.Exists)
					{
						_ListStore.AppendValues(fi.FullName, dis[i].Name);
					}
				}
				_IsLoading = false;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnRealized ()
		{
			this.WidthRequest = 200;
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
						_ThemeLocation = (string)_ListStore.GetValue(iter, 0);
						_ThemeName =  (string)_ListStore.GetValue(iter, 1);
						Common.Option.CustomThemeFile = _ThemeLocation;
						Common.Option.CustomThemeName = _ThemeName;
					}
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		
		#region Public Properties
		
		public string ThemeName
		{
			get{return _ThemeName;}
		}
		
		public string ThemeLocation
		{
			get{return _ThemeLocation;}
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public void SetTheme(string themename)
		{
			_SearchThemeName = themename;
			_ListStore.Foreach(new TreeModelForeachFunc(ForeachText));
			
		}
		
		#endregion Public Methods
		
		private bool ForeachText(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchThemeName == _ListStore.GetValue(iter, 1).ToString())
			{
				_ThemeName = _ListStore.GetValue(iter, 1).ToString();
				_ThemeLocation = _ListStore.GetValue(iter, 0).ToString();
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
	}
}
