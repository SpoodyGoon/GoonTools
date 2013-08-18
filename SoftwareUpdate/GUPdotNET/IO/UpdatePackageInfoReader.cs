//
//  UpdatePackageInfoReader.cs
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
using System.Net;
using System.IO;
using GUPdotNET.Data;

namespace GUPdotNET.IO
{
	public class UpdatePackageInfoReader
	{
		public UpdatePackageInfoReader()
		{
		}

        public void Load()
        {
            GlobalTools.PackageInfo = new UpdatePackageInfo();
            GlobalTools.PackageInfo.TempPackagePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            if (Directory.Exists(GlobalTools.PackageInfo.TempPackagePath))
            {
                throw new Exception("Unable to create temporary package working folder, folder already exist");
            }

            Directory.CreateDirectory(GlobalTools.PackageInfo.TempPackagePath);
            string fileName = Path.GetFileName(new Uri(GlobalTools.ProgramInfo.UpdatePackageURL).LocalPath);
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GlobalTools.ProgramInfo.UpdatePackageURL, Path.Combine(GlobalTools.PackageInfo.TempPackagePath, fileName));

        }
	}
}

