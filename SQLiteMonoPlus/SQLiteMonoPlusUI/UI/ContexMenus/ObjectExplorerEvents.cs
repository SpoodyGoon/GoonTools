using System;

namespace SQLiteMonoPlusUI.UI.ContexMenus
{
	public delegate void ScriptObjectToEventHandler(object sender,ScriptObjectToEventArgs args);
	public class ScriptObjectToEventArgs : EventArgs
	{
		public ScriptObjectToEventArgs ()
		{
		}
	}
}

