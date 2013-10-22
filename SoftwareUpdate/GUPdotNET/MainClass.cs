// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MainClass.cs" company="Andy York">
// //
// // Copyright (c) 2013 Andy York
// //
// // This program is free software: you can redistribute it and/or modify
// // it under the +terms of the GNU General Public License as published by
// // the Free Software Foundation, either version 3 of the License, or
// // (at your option) any later version.
// //
// // This program is distributed in the hope that it will be useful,
// // but WITHOUT ANY WARRANTY; without even the implied warranty of
// // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// // GNU General Public License for more details.
// //
// // You should have received a copy of the GNU General Public License
// // along with this program.  If not, see http://www.gnu.org/licenses/. 
// // </copyright>
// // <summary>
// // Email: goontools@brdstudio.net
// // Author: Andy York 
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace GUPdotNET
{
    using Gtk;
    using GUPdotNET.UI.Views;

    /// <summary>
    /// The main entry class for the application.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments that are passed into the application.</param>
        internal static void Main(string[] args)
        {
            Application.Init();
            GlobalTools.Initalize();
            if (args.Length > 0 && args[0].ToLower().Equals("background"))
            {
                // running a background check, which mean check to see if
                // it is time to run an update check based on the GUPdotNET settings
                GlobalTools.UpdateRunType = RunType.BackgroundCheck;               
                UpdateCheck updateCheck = new UpdateCheck();
                updateCheck.RunUpdateCheck();
                Application.Quit();
            }
            else
            {
                GlobalTools.UpdateRunType = RunType.ManualCheck;
                MainView mainView = new MainView();
                mainView.Show();
            }

            Application.Run();
        }
    }
}
