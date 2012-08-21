using System;
using Gtk;

namespace SQLiteMonoPlusEditor.SQLEditor
{
	[System.ComponentModel.ToolboxItem(true)]
	public class EditorView : Gtk.TextView
	{
		public EditorView () : base()
		{
			TextBuffer tb = new TextBuffer(new TextTagTable());
			this.Buffer = tb;
			this.ModifyBg(StateType.Normal, new Gdk.Color(111,111,111));
		}
	}
}

