
using System;

namespace libGlobalTools.Constants
{
	public static class SQLite
	{
		public const string ConnectionStringFormat = @"URI=file:[FilePath], version=3, busy_timeout=300";
		public const string FilePlaceHolder = "[FilePath]";
		public const string DatabaseFileName = "DatabaseBuilder.s3db";
	}

	public class FileStruture
    {
        internal const string SetUpLogName = "SetUpLog.txt";
        internal const string ErrorLogName = "Error.log";
        internal const string ConnectionFileName = "RecentConnections.xml";
        
    }
}
