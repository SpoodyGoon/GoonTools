using System;

namespace SQLiteMonoPlus.Constants
{
	
	internal class ConnectionMessage
	{    	
		internal const string SaveWarning = "There are unsaved changes that maybe lost if there is not a save before loading/reloading from the save file.";
		internal const string WarningTitle = "Unsaved Changes";
	}
	
	internal class ConnectionString
	{
		internal const string Simple = "URI=file:[DBPATH],version=3, busy_timeout=300";
		internal const string WithPasword = "";
		internal const string WithPooling = "";
		internal const string ConnectionTest = "SELECT * FROM sqlite_master WHERE 1=2";
	}

	internal class ScriptTableTemplate
	{
		internal const string Alter = "";
	}
}
