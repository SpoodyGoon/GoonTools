//
//  MiscTools.cs
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
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// A helper class for working with process, diagnostics and threading.
    /// </summary>
    public static class ProcessTools
    {
        /// <summary>
        /// The URL to the web site to be launched.
        /// </summary>
        private static string launchURL = string.Empty;

        /// <summary>
        /// A method to launch the specified web site in the default browser.
        /// </summary>
        /// <param name="url">URL to the web site to be launched.</param>
        public static void LaunchURL(string url)
        {
            launchURL = url;
            Thread processThread = new Thread(new ThreadStart(StartURL));
            processThread.Start();
        }

        /// <summary>
        /// Method to start the supplied URL in the default browser.
        /// </summary>
        private static void StartURL()
        {
            Process.Start(launchURL);
        }
    }
}