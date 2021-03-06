﻿/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/28/2012
 * Time: 4:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Gtk;
using GlobalTools;
using SQLiteMonoPlus;
using sc = SQLiteMonoPlus.Schema;

namespace SQLiteMonoPlusUI.UI.ObjectExplorer
{
	/// <summary>
	/// Description of SchemaTreeView.
	/// </summary>
	public class SchemaTreeView : Gtk.TreeView
	{
		private Gtk.Window _Parent;
		public SchemaTreeModel _TreeModel = new SchemaTreeModel ();

		public SchemaTreeView (Gtk.Window parent)
		{
			_Parent = parent;
			this.Build ();
		}
		
		private void Build ()
		{
			this.HeadersClickable = false;
			this.HeadersVisible = false;
			this.RulesHint = false;
			this.EnableGridLines = Gtk.TreeViewGridLines.None;

			Gtk.TreeViewColumn colPixbuf = new TreeViewColumn ();
			colPixbuf.Clickable = false;
			colPixbuf.Expand = false;
			colPixbuf.Resizable = false;
			colPixbuf.Title = "";
			Gtk.CellRendererPixbuf cellPixbuf = new Gtk.CellRendererPixbuf ();
			colPixbuf.PackStart (cellPixbuf, true);
			this.AppendColumn (colPixbuf);
			Gtk.TreeViewColumn colObjectName = new Gtk.TreeViewColumn ();
			colObjectName.Clickable = true;
			colObjectName.Expand = true;
			colObjectName.Resizable = true;
			colObjectName.Title = "Object Name";
			Gtk.CellRendererText cellObjectName = new Gtk.CellRendererText ();
			cellObjectName.Editable = false;
			cellObjectName.Ellipsize = Pango.EllipsizeMode.End;
			colObjectName.PackStart (cellObjectName, true);
			this.AppendColumn (colObjectName);
			
			colPixbuf.SetCellDataFunc (cellPixbuf, new Gtk.TreeCellDataFunc (RenderPixbuf));
			colObjectName.SetCellDataFunc (cellObjectName, new Gtk.TreeCellDataFunc (RenderObjectName));
			this.Model = _TreeModel;

			this.ButtonReleaseEvent += SchemaTreeView_OnClick;
		}
		
		[GLib.ConnectBefore]
		private void SchemaTreeView_OnClick (object o, ButtonReleaseEventArgs args)
		{
			Gtk.TreeIter iter;
			Gtk.TreePath path;
			Gtk.TreeViewColumn tvc;
			Gtk.Menu mnu;
			// set the cursor to the row under the mouse
			this.GetPathAtPos ((int)Math.Round (args.Event.X, 0), (int)Math.Round (args.Event.Y, 0), out path, out tvc);
			this.SetCursor (path, tvc, false);
			if ((int)args.Event.Button == 3 && this.Selection.GetSelected (out iter))
			{

				SchemaDisplay sd = (SchemaDisplay)this.Model.GetValue (iter, 0);
				switch(sd.ObjectType)
				{
					case DBObjectType.Database:
						mnu = new SQLiteMonoPlusUI.UI.ContexMenus.DBLevel ((sc.Database)sd.SchemaItem);
						mnu.ShowAll ();
						mnu.Popup ();
						break;
					case DBObjectType.Table:
						mnu = new SQLiteMonoPlusUI.UI.ContexMenus.TableLevel((sc.Table)sd.SchemaItem);
						mnu.ShowAll ();
						mnu.Popup ();
						break;
				}
			}
		}
		
		private void RenderObjectName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SchemaDisplay sd = (SchemaDisplay)model.GetValue (iter, 0);
			(cell as Gtk.CellRendererText).Text = sd.ObjectDisplay;
		}
		
		private void RenderPixbuf (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SchemaDisplay sd = (SchemaDisplay)model.GetValue (iter, 0);
			(cell as Gtk.CellRendererPixbuf).Pixbuf = sd.ObjectImage;
		}
		
		public void Load ()
		{
			_TreeModel.LoadOpenConnections ();
		}

		public void AddDatabase (sc.Database db)
		{
			if (db.ObjectExporerDisplay)
			{
				_TreeModel.AddDatabase (db);
			}
		}
	}
}
