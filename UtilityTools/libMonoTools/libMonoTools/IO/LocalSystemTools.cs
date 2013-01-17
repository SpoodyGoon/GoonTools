//
//  LocalSystemTools.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using sc = System.Collections;
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using cm = System.Configuration.ConfigurationManager;
using Gtk;

namespace MonoTools.IO
{
    public abstract class LocalSystemTools
    {
        #region Protected Properties

        protected string ApplicationPath = System.Environment.CurrentDirectory;
        protected string ApplicationDataPath = so.Path.Combine(System.Environment.CurrentDirectory, "Data");
        protected string ActiveUserDataPath = null;
        protected string OperatingSystem = "Windows";
        protected bool UseErrorLog = false;
        protected string ErrorLogFileName = "ErrorLog.txt";
        protected string ErrorLogFilePath = null;
        protected bool DebugMode = false;

        #endregion Protected Properties

        #region Public Properties

        public virtual string AppPath
        {
            get{ return ApplicationPath;}
            set{ ApplicationPath = value;}
        }
        
        public virtual string AppDataPath
        {
            get{ return ApplicationDataPath;}
            set{ ApplicationDataPath = value;}
        }
        
        public virtual string UserDataPath
        {
            get{ return ActiveUserDataPath;}
            set{ ActiveUserDataPath = value;}
        }
        
        public virtual string OS
        {
            get{ return OperatingSystem;}
            set{ OperatingSystem = value;}
        }
        
        public virtual string ErrorLogPath
        {
            get{ return ErrorLogFilePath;}
            set{ ErrorLogFilePath = value;}
        }

        public virtual bool Debug
        {
            get{ return DebugMode;}
            set{ DebugMode = value;}
        }

        #endregion Public Properties

        protected virtual void Initalize()
        {
            so.FileInfo fi;
            so.DirectoryInfo di;
            switch (System.Environment.OSVersion.Platform) 
            {
                case System.PlatformID.Win32NT:
                case System.PlatformID.Win32S:
                case System.PlatformID.Win32Windows:
                case System.PlatformID.WinCE:
                    this.OperatingSystem = "Windows";
                    break;
                case System.PlatformID.Unix:
                    this.OperatingSystem = "Linux";
                    break;
                case System.PlatformID.MacOSX:
                    this.OperatingSystem = "Mac";
                    break;
            }

            // Get commonly used path information
            sr.Assembly asm = sr.Assembly.GetExecutingAssembly();
            fi = new so.FileInfo(asm.Location);
            ApplicationPath = fi.Directory.FullName;


            _ProgramName = asm.GetName().Name;
            
            // Set the flags for when to use the error log
            if (cm.AppSettings["UserErrorLog"] != null && Convert.ToBoolean(cm.AppSettings["UserErrorLog"]))
            {
                _UseErrorLog = true;
            }
            
            if (cm.AppSettings["DebugMode"] != null && Convert.ToBoolean(cm.AppSettings["DebugMode"]))
            {
                // set the location of the save data for the user
                // in a non-development enviroment
                di = new so.DirectoryInfo(so.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _ProgramName));
                _DebugMode = true;
            }
            else
            {
                // where the user data is saved for development
                di = new so.DirectoryInfo(so.Path.Combine(_AppPath, "DebugFiles"));
            }
            
            if (!di.Exists)
                di.Create();
            
            _UserDataPath = di.FullName;
            
            // the error file
            fi = new so.FileInfo(so.Path.Combine(UserDataPath, "ErrorLog.txt"));
            _ErrorLogFile = fi.FullName;
        }
    }
}

