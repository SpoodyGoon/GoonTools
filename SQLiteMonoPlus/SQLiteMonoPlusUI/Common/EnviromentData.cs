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
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using sc = System.Configuration;
using Gtk;

namespace SQLiteMonoPlusUI.GlobalTools
{
    /// <summary>
    ///  This class contains data that is related to the
    ///  enviroment around the probram
    /// </summary>
    public class EnviromentData
    {
        internal string OS = null;
        internal string AppPath = null;
       	internal string ProgramName = null;
        internal string ErrorLogFile = null;
        internal string ConnectionFilePath = null;
        internal string UserDataPath = null;
        internal string AppDataPath = null;
        public EnviromentData()
        {
            so.FileInfo fi;
            so.DirectoryInfo di;
            sr.Assembly asm = sr.Assembly.GetExecutingAssembly();

            // set the operating system
            OS = se.OSVersion.Platform.ToString();

            // set the app path
            fi = new so.FileInfo(asm.Location);
            AppPath = fi.Directory.FullName;
            ProgramName = asm.GetName().Name;
            if (SQLiteMonoPlusUI.UserConfig.Default.Debug == false)
            {
                // set the location of the save data for the user
                // in a non-development enviroment
                di = new so.DirectoryInfo(so.Path.Combine(se.GetFolderPath(se.SpecialFolder.ApplicationData), ProgramName));

            }
            else
            {
                // where the user data is saved for development
                di = new so.DirectoryInfo(so.Path.Combine(AppPath, "DebugFiles"));
            }

            if (!di.Exists)
                di.Create();

            UserDataPath = di.FullName;

            // App Database for copying over application file during first use
            di = new so.DirectoryInfo(so.Path.Combine(AppPath, "GlobalData"));
            AppDataPath = di.FullName;


            // the error file
            fi = new so.FileInfo(so.Path.Combine(UserDataPath, GlobalTools.Constants.FileStruture.ErrorLogName));
            ErrorLogFile = fi.FullName;
            
            fi = new so.FileInfo(so.Path.Combine(UserDataPath, GlobalTools.Constants.FileStruture.ConnectionFileName));
            ConnectionFilePath = fi.FullName;

        }

        #region Public Methods

        public string GetNewTempFolder(string Name)
        {
            return GetNewTempFolder(Name, true);
        }

        public string GetNewTempFolder(string Name, bool Overwrite)
        {
            string tmpName = so.Path.Combine(so.Path.GetTempPath(), Name);
            try
            {
                if (Overwrite)
                {
                    if (so.Directory.Exists(tmpName))
                        so.Directory.Delete(tmpName);

                    so.Directory.CreateDirectory(tmpName);
                }
                else
                {
                    string tmp = tmpName;
                    int i = 0;
                    while (so.Directory.Exists(tmp))
                    {
                        tmp = tmpName + i.ToString();
                        i++;
                    }
                    so.Directory.CreateDirectory(tmp);
                    tmpName = tmp;
                }
            }
            catch (Exception ex)
            {
                GlobalTools.Common.HandleError(ex);
            }
            return tmpName;
        }

        public string GetNewTempFile(string Name)
        {
            return GetNewTempFile(so.Path.GetFileNameWithoutExtension(Name), so.Path.GetExtension(Name), true);
        }

        public string GetNewTempFile(string Name, string Extension)
        {
            return GetNewTempFile(Name, Extension, true);
        }

        public string GetNewTempFile(string Name, string Extension, bool Overwrite)
        {
            string tmpName = so.Path.Combine(System.IO.Path.GetTempPath(), Name + "." + Extension);
            if (Overwrite)
            {
                if (so.File.Exists(tmpName))
                    so.File.Delete(tmpName);

                so.File.Create(tmpName);
            }
            else
            {
                string tmp = tmpName;
                int i = 0;
                while (so.File.Exists(tmp))
                {
                    tmp = tmpName + i.ToString();
                    i++;
                }
                so.File.Create(tmp);
                tmpName = tmp;
            }
            return tmpName;
        }

        #endregion Public Methods
    }

}
