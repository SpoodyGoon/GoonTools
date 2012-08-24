using System;
using Gtk;
using SQLiteMonoPlus.Schema;

namespace SQLiteMonoPlusEditor.SQLEditor
{
	public class SQLEditorView : Gtk.TextView, IDatabaseEditor
	{
		private SQLiteMonoPlus.Connection _CurrentConnection;

		public event SQLiteMonoPlusEditor.Events.SQLExecutedEventHandler SQLExecuted;
		public event SQLiteMonoPlusEditor.Events.SQLModifiedEventHandler SQLChanged;

		private bool _ExecuteComple = true;

		public SQLEditorView () : base()
		{
			LoadWidget ();
		}

		public SQLEditorView (SQLiteMonoPlus.Connection EditorConnection)
		{
			_CurrentConnection = EditorConnection;
			LoadWidget ();
		}

		public SQLiteMonoPlus.Connection CurrentConnection {
			get{ return _CurrentConnection;}
		}

		public string SQLText{ get { return this.Buffer.Text; } }

		public string SQLSelectedText { 
			get {
				if (this.Buffer.HasSelection) {
					Gtk.TextIter IterStart, IterEnd;
					this.Buffer.GetSelectionBounds (out IterStart, out IterEnd);
					return this.Buffer.GetText (IterStart, IterEnd, false);
				}
				else {
					return this.Buffer.Text;
				}
			} 
		}

		public bool ExecuteComplete{ set { _ExecuteComple = value; } }

		public SQLiteMonoPlus.DBEditorType EditorType{ get { return SQLiteMonoPlus.DBEditorType.Editor; } }

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


		private void OnSQLExecuted(string strSQL)
		{
			SQLExecuted(this, new SQLiteMonoPlusEditor.Events.SQLExecutedEventArgs(_CurrentConnection, strSQL));
		}
	}
}

