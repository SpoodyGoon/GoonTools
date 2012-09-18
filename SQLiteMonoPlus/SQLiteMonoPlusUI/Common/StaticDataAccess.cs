using System;
using Gtk;

namespace SQLiteMonoPlusUI.GlobalData
{
	internal class StaticDataAccess
	{		
		internal static ConnectionStore RecentConnections = new GlobalData.ConnectionStore ();

		internal static void Load()
		{
			RecentConnections.Load();
		}
	}
}

