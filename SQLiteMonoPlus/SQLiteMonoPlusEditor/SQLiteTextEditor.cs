using System;
using Gtk;
using SQLiteMonoPlus.Schema;

namespace SQLiteMonoPlusEditor.SQLEditor
{
	[System.ComponentModel.ToolboxItem(true)]
	public class EditorView : Gtk.TextView
	{
		Database _CurrentDatabase;
		public EditorView () : base()
		{
			LoadWidget ();
		}

		public EditorView (Database db)
		{
			_CurrentDatabase = db;
			LoadWidget();
		}

		private void LoadWidget ()
		{
			TextBuffer tb = new TextBuffer (new TextTagTable ());
			this.Buffer = tb;
			this.BorderWidth = 5;

			//this.ModifyBg (StateType.Insensitive, new Gdk.Color (111, 111, 111));
			this.AppPaintable = true;
			this.DoubleBuffered = true;
			this.ShowAll ();
		}

		protected override bool OnKeyReleaseEvent (Gdk.EventKey evnt)
		{
			switch (evnt.Key) {
			case Gdk.Key.F5:
				break;
			case Gdk.Key.space:
				break;
			case Gdk.Key.Tab:
				break;
			}
			return base.OnKeyReleaseEvent (evnt);
		}
	}
}

