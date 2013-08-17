//
//  LocalConfigFile.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
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
using System.IO;
using MonoTools.IO;
using GUPdotNET.Data;

namespace GUPdotNET.IO
{
	public class LocalConfigFile
	{
		private const string FILENAME_FORMAT = "{0}Update.config";

		private string fileName = string.Empty;

		public LocalConfigFile()
		{
			this.fileName =Path.Combine(GlobalTools.LocalSystem.UserDataPath, string.Format(FILENAME_FORMAT, GlobalTools.ProgramInfo.ProgramName));
		}

		public void ConfigFileRead()
		{
			GlobalTools.Options = new UpdateOptions();
			if(!File.Exists(this.fileName))
			{
				GlobalTools.Options.AutoUpdate = true;
				GlobalTools.Options.LastUpdateCheck = DateTime.Now.AddDays(-1);
				GlobalTools.Options.UpdateSchedule = new TimeSpan(1, 0, 0, 0);
				this.ConfigFileWrite();
			}
			else
			{
				using(SimpleConfigFile configFile = new SimpleConfigFile(this.fileName))
				{
					configFile.Load();
					bool boolTemp;
					if(configFile.DataItem.GetBoolean("AutoUpdate", out boolTemp))
					{
						GlobalTools.Options.AutoUpdate = boolTemp;
					}
					else
					{
						GlobalTools.Options.AutoUpdate = true;
					}

					DateTime datetimeTemp;
					if(configFile.DataItem.GetDateTime("LastUpdateCheck", out datetimeTemp))
					{
						GlobalTools.Options.LastUpdateCheck = datetimeTemp;
					}
					else
					{
						GlobalTools.Options.LastUpdateCheck = DateTime.Now.AddDays(-1);
					}

					int intTempDays;
					if(configFile.DataItem.GetInt("UpdateSchedule", out intTempDays))
					{
						GlobalTools.Options.UpdateSchedule = new TimeSpan(intTempDays, 0, 0, 0);
					}
					else
					{					
						GlobalTools.Options.UpdateSchedule = new TimeSpan(1, 0, 0, 0);
					}
				}

			}
		}

		public void ConfigFileWrite()
		{
			using(SimpleConfigFile configFile = new SimpleConfigFile(this.fileName))
			{
				configFile.DataItem.AddItem("AutoUpdate", GlobalTools.Options.AutoUpdate);
				configFile.DataItem.AddItem("LastUpdateCheck", GlobalTools.Options.LastUpdateCheck);
				configFile.DataItem.AddItem("UpdateSchedule", GlobalTools.Options.UpdateSchedule.Days);
				configFile.Save();
			}
		}
	}
}

