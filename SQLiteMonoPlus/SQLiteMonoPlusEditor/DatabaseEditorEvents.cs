using System;

namespace SQLiteMonoPlusEditor.Events
{
	public delegate void SQLExecutedEventHandler(object sender,SQLExecutedEventArgs args);
	public class SQLExecutedEventArgs : EventArgs
	{
		public SQLiteMonoPlus.Connection CurrentConnection;
		public string SQLStatement = "";
		public SQLExecutedEventArgs (SQLiteMonoPlus.Connection connection, string sqlstatement)
		{
			CurrentConnection = connection;
			SQLStatement = sqlstatement;
		}
	}

	public delegate void SQLModifiedEventHandler(object sender, SQLModifiedEventArgs args);
	public class SQLModifiedEventArgs : System.EventArgs
	{
		public bool HasChanged = false;
		public SQLModifiedEventArgs (bool changed)
		{
			HasChanged  =changed;
		}
	}
}

