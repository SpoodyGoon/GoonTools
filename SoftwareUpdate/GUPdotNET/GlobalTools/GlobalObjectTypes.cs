//
//  GlobalObjectTypes.cs
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

namespace GUPdotNET
{
    using System;

    /// <summary>
    /// The method for running the application.
    /// </summary>
    public enum RunType
    {
        ManualCheck,
        BackgroundCheck,
        Options
    }

    /// <summary>
    /// The type of processor we are working with, whether it is a 64 bit, 32 bit or 'Any' when it doesn't matter.
    /// </summary>
    public enum ProcessorBit
    {
        Any,
        x32,
        x64
    }

    /// <summary>
    /// The type of installer being used.
    /// </summary>
    public enum InstallMethod
    {
        msi,
        exe,
        zip,
        bin,
        rpm,
        deb,
        src
    }
}