//
//  UpdateFileInfo.cs
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

namespace GUPdotNET.Data
{
	using System;
	using System.Collections.Generic;
	public class UpdatePackageInfo
	{
		/// <summary>
		/// Gets or sets the OS as gotten from the GUPdotNET update package config file.
		/// </summary>
		/// <value>The O.</value>
		internal string OS{ get; set;}

		/// <summary>
		/// This is the major version recieved from the web site
		/// containing the update information.
		/// </summary>
		internal System.Version UpdateVersion{ get; set; }

		/// <summary>
		/// The install method used to install the supported program.
		/// </summary>
		internal InstallMethod InstallerType{ get; set; }

        /// <summary>
        /// The temporary directory where package files will be 
        /// downloaded/updated to be used.
        /// </summary>
        internal string TempPackagePath { get; set; }

		/// <summary>
		/// Gets or sets the package file(s) associated with an install package.
		/// </summary>
		internal List<PackageFile> PackageFile{get;set;}
	}
}

