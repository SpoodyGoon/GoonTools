// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainClass.cs" company="Andy York">
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
    using System;
    using System.Diagnostics;
    using System.Threading;
    using Gtk;
    using GUPdotNET.UI.Views;

    /// <summary>
    /// The main entry class for the application.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// Error message format for initialization errors.
        /// </summary>
        private const string InitializeErrorFormat = "An error occured while initializing {0}. If you are getting this error on a regular basis concider disabling the update program (GUPdotNET) using the user preferences/options in {1}.\n\n<b>Error Message:</b>\n{2}";

        /// <summary>
        /// The title to be displayed on the error message dialog
        /// for initialization errors.
        /// </summary>
        private const string InitializeErrorTitle = "Update Program Startup Error";

        /// <summary>
        /// The format for error messages created during global tools initialization.
        /// </summary>
        private const string GlobalToolsErrorFormat = "Step: {0} Error: {1}.";

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments that are passed into the application.</param>
        internal static void Main(string[] args)
        {
            Application.Init();
            Thread globalToolsThread = new Thread(delegate()
            {
                bool init = GlobalToolInitialize();
                if (init)
                {
                    Application.Invoke(delegate
                    {
                        if (args.Length > 0 && args[0].ToLower() == "background")
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
                    });
                }
                else
                {
                    Thread.Sleep(1000);
                    Debug.WriteLine("Update Program Startup Failed");
                    Application.Quit();
                }
            });

            globalToolsThread.Start();
            Application.Run();
        }

        /// <summary>
        /// Method to load all the tools needed to start the application as well
        /// as provide feedback through the splash screen.
        /// </summary>
        /// <returns><c>true</c>, if tool initialization was successful, <c>false</c> if there was an error that requires the application to abort starting.</returns>
        private static bool GlobalToolInitialize()
        {
            GlobalTools.InitializeMessageChanged += delegate(string message)
            {
                if (Properties.Settings.Default.DebugMode)
                {
                    Console.WriteLine(message);
                    Debug.WriteLine(message);
                }
            };

            GlobalTools.InitializateError += delegate(Exception error, string initializeStep)
            {
                if (Properties.Settings.Default.DebugMode)
                {
                    Console.WriteLine(string.Format(GlobalToolsErrorFormat, initializeStep, error.ToString()));
                    Debug.WriteLine(string.Format(GlobalToolsErrorFormat, initializeStep, error.ToString()));
                }

                Application.Invoke(delegate
                {
                    GlobalTools.HandleError(error);
                });
            };

            bool initalizeCompleted = false;
            GlobalTools.InitializationComplete += delegate
            {
                initalizeCompleted = true;
            };

            bool initializeSuccess = GlobalTools.Initalize();
            while (!initalizeCompleted)
            {
                Thread.Sleep(1000);
            }

            return initializeSuccess;
        }
    }
}
