using System;
using Gtk;

namespace SQLiteMonoPlusEditor.SQLEditor
{
	public class SQLEditor : Gtk.TextView
	{
		public SQLEditor (SQLiteBuffer SQLBuf) : base(SQLBuf)
		{
		}
	}
}

