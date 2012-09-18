using System;

namespace libGlobalTools
{
    interface ILocalSystemTools
    {
        string AppPath { get; }
        string AppDBFile { get; }
        string AppDataPath { get; }
		string DBConnectionString { get; }
        string ProgramName { get; }
        string ErrorLogFile { get; }
        bool UseErrorLog { get; }
        bool DebugMode { get; }

        string GetNewTempFolder(string Name);
        string GetNewTempFolder(string Name, bool Overwrite);
        string GetNewTempFile(string Name);
        string GetNewTempFile(string Name, string Extension);
        string GetNewTempFile(string Name, string Extension, bool Overwrite);
        void ClearDirectory(string strPath);
        void LaunchURL(string URL);
    }
}
