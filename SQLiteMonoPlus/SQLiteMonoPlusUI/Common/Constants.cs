
using System;

namespace SQLiteMonoPlusUI.GlobalTools.Constants
{
    /// <summary>
    /// Description of Constants.
    /// </summary>
    internal class FileStruture
    {
        internal const string SetUpLogName = "SetUpLog.txt";
        internal const string ErrorLogName = "Error.log";
        internal const string ConnectionFileName = "RecentConnections.xml";
        
    }
    
    internal class ConnectionMessage
    {    	
        internal const string SaveWarning = "There are unsaved changes that maybe lost if there is not a save before loading/reloading from the save file.";
        internal const string WarningTitle = "Unsaved Changes";
    }
}
