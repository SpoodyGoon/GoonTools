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
using System;
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using sc = System.Configuration;
using Gtk;

namespace MonoTools.IO
{
    public abstract class LocalSystemTools
    {
        #region Protected Properties

        protected string ApplicationPath = null;
        protected string ApplicationDataPath = null;
        protected string ActiveUserDataPath = null;
        protected string OperatingSystem = null;
        protected bool UseErrorLog = false;
        protected string ErrorLogFile = null;
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
            get{ return ErrorLogFile;}
            set{ ErrorLogFile = value;}
        }

        public virtual bool Debug
        {
            get{ return DebugMode;}
            set{ DebugMode = value;}
        }

        #endregion Public Properties

        protected virtual void Initalize()
        {
            if(System.Environment.OSVersion.Platform == System.PlatformID.Unix)
            {
                this.OperatingSystem = "Linux";
            }
        }
    }
}

