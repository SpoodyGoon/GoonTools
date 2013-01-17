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

		protected string ApplicationPath = System.Environment.CurrentDirectory;
		protected string ApplicationDataPath = so.Path.Combine (System.Environment.CurrentDirectory, "Data");
		protected string ActiveUserDataPath = null;
		protected string OperatingSystem = "Windows";
		protected string ProgramName = null;
		protected bool UseErrorLog = false;
		protected string ErrorLogFileName = "ErrorLog.txt";
		protected string ErrorLogFilePath = null;
		protected bool DebugMode = false;
		private string DefaultErrorLogName = "ErrorLog.txt";

        #endregion Protected Properties

        #region Public Properties

		public virtual string AppPath {
			get{ return ApplicationPath;}
			set{ ApplicationPath = value;}
		}
        
		public virtual string AppDataPath {
			get{ return ApplicationDataPath;}
			set{ ApplicationDataPath = value;}
		}
        
		public virtual string UserDataPath {
			get{ return ActiveUserDataPath;}
			set{ ActiveUserDataPath = value;}
		}
        
		public virtual string OS {
			get{ return OperatingSystem;}
			set{ OperatingSystem = value;}
		}
        
		public virtual string ErrorLogPath {
			get{ return ErrorLogFilePath;}
			set{ ErrorLogFilePath = value;}
		}

		public virtual bool Debug {
			get{ return DebugMode;}
			set{ DebugMode = value;}
		}

        #endregion Public Properties

		protected virtual void Initalize ()
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
			sr.Assembly asm = sr.Assembly.GetExecutingAssembly ();
			fi = new so.FileInfo (asm.Location);
			ApplicationPath = fi.Directory.FullName;
			ProgramName = asm.GetName ().Name;

			di = new so.DirectoryInfo (so.Path.Combine (ApplicationDataPath, "AppData"));
			if (!di.Exists)
				di.Create ();
			ApplicationDataPath = di.FullName;


            
			// Set the flags for when to use the error log
			if (cm.AppSettings ["UserErrorLog"] != null && System.Convert.ToBoolean (cm.AppSettings ["UserErrorLog"]))
			{
				UseErrorLog = true;
				if (cm.AppSettings ["ErrorLogFileName"] != null && !string.IsNullOrEmpty (cm.AppSettings ["ErrorLogFileName"].ToString()))
				{
					ErrorLogPath = so.Path.Combine (AppDataPath, cm.AppSettings ["ErrorLogFileName"].ToString());
				}
				else
				{
					ErrorLogPath = so.Path.Combine (AppDataPath, DefaultErrorLogName);
				}
			}
			// UserDataFolder
			if (cm.AppSettings ["DebugMode"] != null && !System.Convert.ToBoolean (cm.AppSettings ["DebugMode"]))
			{
				DebugMode = true;
				// set the location of the save data for the user
				// in a non-development enviroment				
				if (cm.AppSettings ["UserDataFolder"] != null && !string.IsNullOrEmpty (cm.AppSettings ["UserDataFolder"].ToString ()))
				{
					di = new so.DirectoryInfo (so.Path.Combine (se.GetFolderPath (se.SpecialFolder.ApplicationData), cm.AppSettings ["UserDataFolder"].ToString ()));
				}
				else
				{
					di = new so.DirectoryInfo (so.Path.Combine (se.GetFolderPath (se.SpecialFolder.ApplicationData), asm.GetName ().Name));
				}
			}
			else
			{
				// where the user data is saved for development
				di = new so.DirectoryInfo (so.Path.Combine (ApplicationPath, "DebugFiles"));
			}
            
			if (!di.Exists)
				di.Create ();
            
			ActiveUserDataPath  = di.FullName;            
		}
	}
}

