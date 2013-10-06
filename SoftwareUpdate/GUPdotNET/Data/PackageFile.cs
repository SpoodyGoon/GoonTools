//
//  PackageFile.cs
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

namespace GUPdotNET.Data
{
    internal class PackageFile
    {
        internal string FileType { get; set; }

        internal string URL { get; set; }

        internal string FileName
        {
            get
            {
                return Path.GetFileName(new Uri(this.URL).LocalPath);
            }
        }

        internal string Checksum { get; set; }
    }
}
