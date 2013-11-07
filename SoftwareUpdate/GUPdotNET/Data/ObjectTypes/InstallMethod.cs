// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstallMethod.cs" company="Andy York">
//
// Copyright (c) 2013 Andy York
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Email: goontools@brdstudio.net
// Author: Andy York 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GUPdotNET
{
    /// <summary>
    /// The type of installer being used.
    /// </summary>
    public enum InstallMethod
    {
        /// <summary>
        /// Windows installer package.
        /// </summary>
        msi,

        /// <summary>
        /// Windows installer or setup program.
        /// </summary>
        exe,

        /// <summary>
        /// Used when the program is stored in a compressed file.
        /// </summary>
        zip,

        /// <summary>
        /// Linux binary installer not distribution specific.
        /// </summary>
        bin,

        /// <summary>
        /// Linux Red Hat Package Manager binary installer.
        /// </summary>
        rpm,

        /// <summary>
        /// Debian package manager binary installer.
        /// </summary>
        deb,

        /// <summary>
        /// Installed by building the source code.
        /// </summary>
        src
    }
}