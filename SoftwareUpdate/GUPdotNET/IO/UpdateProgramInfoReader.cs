//
//  UpdateProgramInfoReader.cs
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
using System.Configuration;
using System.Reflection;
using GUPdotNET.Data;

namespace GUPdotNET.IO
{
	public class UpdateProgramInfoReader
	{
		public void CallingAssemblyRead()
		{
			Assembly programAssembly = Assembly.GetCallingAssembly();
			GlobalTools.ProgramInfo = new UpdateProgramInfo() {
				ProgramName = (programAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0] as AssemblyProductAttribute).Product,
				ProgramTitle = (programAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute).Title,
				ProgramDescription = (programAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description,
				ProgramVersion = programAssembly.GetName().Version,
				ProgramFullPath = programAssembly.Location,
				OS = GlobalTools.LocalSystem.OS,
				//InstallType = (Enum.Parse(typeof(InstallMethod), ConfigurationManager.AppSettings["InstallType"].ToString()) as InstallMethod),
				UpdatePackageURL = ConfigurationManager.AppSettings["UpdatePackageURL"].ToString()
			};
		}
	}
}

