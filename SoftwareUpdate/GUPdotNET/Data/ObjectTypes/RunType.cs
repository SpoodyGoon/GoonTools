// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunType.cs" company="Andy York">
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
    /// The method for running the application.
    /// </summary>
    public enum RunType
    {
        /// <summary>
        /// Used when the application is started from a user action.
        /// </summary>
        ManualCheck,

        /// <summary>
        /// Used when checking for updates automatically.
        /// </summary>
        BackgroundCheck,

        /// <summary>
        /// Used when requesting GUPdotNET options window.
        /// </summary>
        Options
    }
}