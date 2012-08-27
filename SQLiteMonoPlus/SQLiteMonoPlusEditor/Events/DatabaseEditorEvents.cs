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

	public delegate void ConnectionChangeEventHandler(object sender, SQLModifiedEventArgs args);
	public class ConnectionChangeEventArgs : System.EventArgs
	{
		public ConnectionChangeEventArgs ()
		{
		}
	}

	public delegate void ConnectMenuItemEventHandler(object sender);
	public class ConnectMenuItemEventArgs : System.EventArgs
	{
		public ConnectMenuItemEventArgs ()
		{
		}
	}
}

