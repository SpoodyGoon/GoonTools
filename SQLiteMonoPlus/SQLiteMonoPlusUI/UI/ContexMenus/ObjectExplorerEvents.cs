using System;

namespace SQLiteMonoPlusUI.UI.ContexMenus.Events
{
	public delegate void ScriptObjectToEventHandler(object sender, ScriptObjectToEventArgs args);
	public class ScriptObjectToEventArgs : EventArgs
	{
		public SQLiteMonoPlus.Connection CurrentConnection;
		public string SQLStatement = "";
		public ScriptObjectToEventArgs (SQLiteMonoPlus.Connection connection, string sqlstatement)
		{
			CurrentConnection = connection;
			SQLStatement = sqlstatement;
		}
	}
}

