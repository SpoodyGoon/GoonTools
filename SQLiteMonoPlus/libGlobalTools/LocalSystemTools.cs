/*************************************************************************
 *                      EnviromentData.cs
 *
 *      Copyright (C) 2010
 *      Andrew York <GlobalTools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.IO;
using System.Reflection;
using CM = System.Configuration.ConfigurationManager;
using Gtk;

namespace libGlobalTools
{
    /// <summary>
    ///  This class contains data that is related to the
    ///  enviroment around the probram
    /// </summary>
	public class LocalSystemTools : ILocalSystemTools
    {
		private string _AppPath;
		private string _AppDBFile;
		private string _AppDataPath;
		private string _DBConnectionString;
		private string _ProgramName;
		private string _ErrorLogFile;
		private bool _UseErrorLog = false;
		private bool _DebugMode = false;
		private string _OS = null;
        private string _UserDataPath = null;
        public LocalSystemTools ()
		{
			FileInfo fi;
			DirectoryInfo di;
			Assembly asm = Assembly.GetExecutingAssembly ();

			// set the operating system
			_OS = Environment.OSVersion.Platform.ToString ();

			// set the app path
			fi = new FileInfo (asm.Location);
			_AppPath = fi.Directory.FullName;
			_ProgramName = asm.GetName ().Name;

			// Set the flags for when to use the error log
			if (CM.AppSettings ["UserErrorLog"] != null && Convert.ToBoolean (CM.AppSettings ["UserErrorLog"]))
			{
				_UseErrorLog = true;				
			}

			if (CM.AppSettings ["DebugMode"] != null && Convert.ToBoolean (CM.AppSettings ["DebugMode"]))
			{
				// set the location of the save data for the user
				// in a non-development enviroment
				di = new DirectoryInfo (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), _ProgramName));
				_DebugMode = true;
			}
			else
			{
				// where the user data is saved for development
				di = new DirectoryInfo (Path.Combine (_AppPath, "DebugFiles"));
			}

			if (!di.Exists)
				di.Create ();

			_UserDataPath = di.FullName;

			// App Database for copying over application file during first use
			di = new DirectoryInfo (Path.Combine (_AppPath, "AppData"));
			_AppDataPath = di.FullName;


			// the error file
			fi = new FileInfo (Path.Combine (UserDataPath, Constants.FileStruture.ErrorLogName));			
			if (_UseErrorLog)
			{
				_ErrorLogFile = fi.FullName;
				if(!fi.Exists)
					fi.Create();
			}

			// location of the database for the applciation
			fi = new FileInfo(Path.Combine(AppDataPath, Constants.SQLite.DatabaseFileName));
			_AppDBFile = fi.FullName;
			_DBConnectionString = Constants.SQLite.ConnectionStringFormat.Replace(Constants.SQLite.FilePlaceHolder, System.Web.HttpUtility.UrlEncode(fi.FullName.Trim()));

        }
		
		#region Public Properties
		
		public string AppPath { get { return _AppPath; } }
		public string AppDBFile { get { return _AppDBFile; } }
		public string AppDataPath { get { return _AppDataPath; } }
		public string DBConnectionString { get { return _DBConnectionString; } }
		public string ProgramName { get { return _ProgramName; } }
		public string ErrorLogFile { get { return _ErrorLogFile; } }
		public string UserDataPath { get { return _UserDataPath; } }
		public bool UseErrorLog { get { return _UseErrorLog; } }
		public bool DebugMode { get { return _DebugMode; } }
		public string OS { get { return _OS; } }
		
		#endregion Public Properties

		#region Temp File/Folder Functions

        public string GetNewTempFolder(string Name)
        {
            return GetNewTempFolder(Name, true);
        }

        public string GetNewTempFolder(string Name, bool Overwrite)
        {
            string tmpName = Path.Combine(Path.GetTempPath(), Name);
            try
            {
                if (Overwrite)
                {
                    if (Directory.Exists(tmpName))
                        Directory.Delete(tmpName);

                    Directory.CreateDirectory(tmpName);
                }
                else
                {
                    string tmp = tmpName;
                    int i = 0;
                    while (Directory.Exists(tmp))
                    {
                        tmp = tmpName + i.ToString();
                        i++;
                    }
                    Directory.CreateDirectory(tmp);
                    tmpName = tmp;
                }
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
            return tmpName;
        }

        public string GetNewTempFile(string Name)
        {
            return GetNewTempFile(Path.GetFileNameWithoutExtension(Name), Path.GetExtension(Name), true);
        }

        public string GetNewTempFile(string Name, string Extension)
        {
            return GetNewTempFile(Name, Extension, true);
        }

        public string GetNewTempFile(string Name, string Extension, bool Overwrite)
        {
            string tmpName = Path.Combine(System.IO.Path.GetTempPath(), Name + "." + Extension);
            if (Overwrite)
            {
                if (File.Exists(tmpName))
                    File.Delete(tmpName);

                File.Create(tmpName);
            }
            else
            {
                string tmp = tmpName;
                int i = 0;
                while (File.Exists(tmp))
                {
                    tmp = tmpName + i.ToString();
                    i++;
                }
                File.Create(tmp);
                tmpName = tmp;
            }
            return tmpName;
        }
		
		public void ClearDirectory(string strPath)
		{
			DirectoryInfo di = new DirectoryInfo(strPath);
			DirectoryInfo[] diTmp = di.GetDirectories();
			if (diTmp.Length > 0)
			{
				for (int i = 0; i < diTmp.Length; i++)
				{
					diTmp[i].Delete(true);
				}
			}
			
			FileInfo[] fi = di.GetFiles();
			if (fi.Length > 0)
			{
				for (int i = 0; i < fi.Length; i++)
				{
					fi[i].Delete();
				}
			}
		}

		#endregion Temp File/Folder Functions
		
		#region Launch URL
		
		private string _LaunchURL = string.Empty;
		public void LaunchURL(string URL)
		{
			_LaunchURL = URL;
			System.Threading.Thread trd = new System.Threading.Thread(new System.Threading.ThreadStart(StartURL));
			trd.Start();
		}
		
		private void StartURL()
		{
			System.Diagnostics.Process.Start(_LaunchURL);
		}
		
		#endregion Launch URL
    }

}
