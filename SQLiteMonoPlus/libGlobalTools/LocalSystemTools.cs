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
    public class LocalSystemTools
    {
        public string OS = null;
        public string AppPath = null;
       	public string ProgramName = null;
		public bool UserErrorLog = false;
        public string ErrorLogFile = null;
        public string ConnectionFilePath = null;
        public string UserDataPath = null;
        public string AppDataPath = null;
		public bool DebugMode = false;
        public LocalSystemTools()
        {
            FileInfo fi;
            DirectoryInfo di;
            Assembly asm = Assembly.GetExecutingAssembly();

            // set the operating system
			OS = Environment.OSVersion.Platform.ToString();

            // set the app path
            fi = new FileInfo(asm.Location);
            AppPath = fi.Directory.FullName;
            ProgramName = asm.GetName().Name;

			// Set the flags for when to use the error log
			if (CM.AppSettings["UserErrorLog"] != null && Convert.ToBoolean(CM.AppSettings["UserErrorLog"]))
			{
				UserErrorLog = true;				
			}

			if (CM.AppSettings["DebugMode"] != null && Convert.ToBoolean(CM.AppSettings["DebugMode"]))
            {
                // set the location of the save data for the user
                // in a non-development enviroment
				di = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProgramName));
				DebugMode = true;
            }
            else
            {
                // where the user data is saved for development
                di = new DirectoryInfo(Path.Combine(AppPath, "DebugFiles"));
            }

            if (!di.Exists)
                di.Create();

            UserDataPath = di.FullName;

            // App Database for copying over application file during first use
            di = new DirectoryInfo(Path.Combine(AppPath, "GlobalData"));
            AppDataPath = di.FullName;


            // the error file
            fi = new FileInfo(Path.Combine(UserDataPath, Constants.FileStruture.ErrorLogName));
            ErrorLogFile = fi.FullName;
            
            fi = new FileInfo(Path.Combine(UserDataPath, Constants.FileStruture.ConnectionFileName));
            ConnectionFilePath = fi.FullName;

        }

        #region Public Methods

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

        #endregion Public Methods
    }

}
