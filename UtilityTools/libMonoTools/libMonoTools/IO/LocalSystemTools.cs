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
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using Gtk;

namespace libMonoTools.IO
{
    public abstract class LocalSystemTools
    {
        #region Protected Properties

        private string _AppPath = null;
        private string _AppDataPath = null;
        protected string AppDataPathName = "Data";

        private string _UserDataPath = null;
        private string _UserConfigPath = null;
        private string _UserLogPath = null;
        private string _UserCashePath = null;
        protected string UserDataPathName = "DebugData";
        protected string UserConfigPathName = "Config";
        protected string UserLogPathName = "Logs";
        protected string UserCashePathName = "Cashe";

        protected string _OS = "Windows";
        protected bool UseErrorLog = false;
        protected string ErrorLogFileName = "ErrorLog.txt";
        protected string _ErrorLogFile = null;
        protected bool DebugMode = false;

        #endregion Protected Properties

        #region Public Properties

        public virtual string AppPath {
            get{ return _AppPath;}
        }
        
        public virtual string AppDataPath {
            get{ return _AppDataPath;}
        }
        
        public virtual string UserDataPath {
            get{ return _UserDataPath;}
        }
        
        public virtual string UserConfigPath {
            get{ return _UserConfigPath;}
        }
        
        public virtual string UserLogPath {
            get{ return _UserLogPath;}
        }
        
        public virtual string UserCashePath {
            get{ return _UserCashePath;}
        }
        
        public virtual string OS {
            get{ return _OS;}
        }
        
        public virtual string ErrorLogFile {
            get{ return _ErrorLogFile;}
        }

        public virtual bool Debug {
            get{ return DebugMode;}
            set{ DebugMode = value;}
        }

        #endregion Public Properties

        public virtual void Initalize ()
        {
            so.FileInfo fi;
            so.DirectoryInfo di;

            // get OS information
            switch(System.Environment.OSVersion.Platform)
            {
                case System.PlatformID.Win32NT:
                case System.PlatformID.Win32S:
                case System.PlatformID.Win32Windows:
                case System.PlatformID.WinCE:
                    this._OS = "Windows";
                break;
                case System.PlatformID.Unix:
                    this._OS = "Linux";
                break;
                case System.PlatformID.MacOSX:
                    this._OS = "Mac";
                break;
            }

            // Get commonly used path information
            sr.Assembly asm = sr.Assembly.GetExecutingAssembly();
            fi = new so.FileInfo(asm.Location);
            _AppPath = fi.Directory.FullName;

            // set and create the application data folder
            di = new so.DirectoryInfo(so.Path.Combine(_AppPath, AppDataPathName));
            if(!di.Exists)
                di.Create();
            _AppDataPath = di.FullName;

            // if the application is in debug mode store the user data under the apppath
            // otherwise use the users local application data path
            if(DebugMode)
            {
                di = new so.DirectoryInfo(so.Path.Combine(_AppPath, UserDataPathName));            
            }
            else
            {                
                di = new so.DirectoryInfo(so.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), UserDataPathName)); 
            }
            // create the user data folder
            if(!di.Exists)
                di.Create();
            _UserDataPath = di.FullName;

            // set and create the user log folder
            di = new so.DirectoryInfo(so.Path.Combine(_UserDataPath, UserLogPathName));            
            if(!di.Exists)
                di.Create();
            _UserLogPath = di.FullName;
            _ErrorLogFile = so.Path.Combine(_UserLogPath, ErrorLogFileName);

            // set and create the user config folder
            di = new so.DirectoryInfo(so.Path.Combine(_UserDataPath, this.UserConfigPathName));            
            if(!di.Exists)
                di.Create();
            _UserConfigPath = di.FullName;

            // set and create the user cashe path
            di = new so.DirectoryInfo(so.Path.Combine(_UserDataPath, this.UserCashePathName));            
            if(!di.Exists)
                di.Create();
            _UserCashePath = di.FullName;        
        }
    }
}

