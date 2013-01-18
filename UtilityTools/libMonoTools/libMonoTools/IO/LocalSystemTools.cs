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

namespace libMonoTools.IO
{
	public abstract class LocalSystemTools
	{
        #region Protected Properties

		private string _AppPath = null;
		protected string AppDataPathName = "Data";
		private string _AppDataPath = null;
		protected string UserDataPathName = "DebugData";
		private string _UserDataPath = null;
		protected string _OS = "Windows";
		protected bool UseErrorLog = false;
		protected string ErrorLogFileName = "ErrorLog.txt";
		protected string _ErrorLogPath = null;
		protected bool DebugMode = false;

        #endregion Protected Properties

        #region Public Properties

		public virtual string AppPath {
			get{ return _AppPath;}
			set{ _AppPath = value;}
		}
        
		public virtual string AppDataPath {
			get{ return _AppDataPath;}
			set{ _AppDataPath = value;}
		}
        
		public virtual string UserDataPath {
			get{ return _UserDataPath;}
			set{ _UserDataPath = value;}
		}
        
		public virtual string OS {
			get{ return _OS;}
			set{ _OS = value;}
		}
        
		public virtual string ErrorLogPath {
			get{ return _ErrorLogPath;}
			set{ _ErrorLogPath = value;}
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
			switch (System.Environment.OSVersion.Platform)
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
			sr.Assembly asm = sr.Assembly.GetExecutingAssembly ();
			fi = new so.FileInfo (asm.Location);
			_AppPath = fi.Directory.FullName;

			di = new so.DirectoryInfo (so.Path.Combine (_AppPath, AppDataPathName));
			if (!di.Exists)
				di.Create ();
			_AppDataPath = di.FullName;

			_ErrorLogPath = so.Path.Combine (_AppDataPath, ErrorLogFileName);

			di = new so.DirectoryInfo (so.Path.Combine (_AppPath, UserDataPathName));
            
			if (!di.Exists)
				di.Create ();
            
			_UserDataPath = di.FullName;            
		}
	}
}

