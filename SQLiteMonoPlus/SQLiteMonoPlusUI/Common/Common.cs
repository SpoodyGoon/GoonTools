/*************************************************************************
 *                      Common.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <YahtzeeSharp@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General internal License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General internal License for more details.
 *
 * You should have received a copy of the GNU General internal License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using Gtk;
using GlobalTools.Helper;

namespace GlobalTools
{
    /// <summary>
    /// This is a static class that holds values that
    /// are reqularly used by the program it also first off
    /// the serialzation of certian objects
    /// </summary>
    internal static class Common
    {
        private static EnviromentData _EnvData = new EnviromentData();
        private static YahtzeeSharp2.GameTheme _GameTheme = new YahtzeeSharp2.GameTheme();

        #region internal Properties

        internal static EnviromentData EnvData
        {
            get { return _EnvData; }
        }

        internal static YahtzeeSharp2.GameTheme GameTheme
        {
            get { return _GameTheme; }
        }

        internal static Gdk.Pixbuf[] DiceImages
        {
            get { return _DiceImages; }
        }

        #endregion internal Properties

        #region Logs

        internal static void HandleError(Exception ex)
        {
            HandleError(null, ex);
        }

        internal static void HandleError(Gtk.Window parent_window, Exception ex)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(System.Environment.NewLine + "------------------------------------------------------------------------------");
            sb.Append(System.Environment.NewLine + "--------------------------- " + DateTime.Now.ToString() + " --------------------------");
            sb.Append(System.Environment.NewLine + ex.ToString());
            sb.Append(System.Environment.NewLine + "------------------------------------------------------------------------------");
            if (YahtzeeSharp2.UserConfig.Default.UseErrorLog)
            {
                StreamWriter sw = new StreamWriter(EnvData.ErrorLog, true);
                sw.Write(sb.ToString());
                sw.Close();
            }

            YahtzeeSharp2.frmBasicError fmb = new YahtzeeSharp2.frmBasicError(parent_window, ex.ToString());
            fmb.Run();
            fmb.Destroy();
//            if ((Gtk.ResponseType)fmb.Run() == Gtk.ResponseType.Accept)
//            {
//                fmb.Destroy();
//                YahtzeeSharp2.frmErrorMessage fme = new YahtzeeSharp2.frmErrorMessage(parent_window, ex.Message);
//                fme.Run();
//                fme.Destroy();
//            }
//            else
//            {
//                fmb.Destroy();
//            }
            sb.Length = 0;
        }

        internal static void CleanErrorLog()
        {
            try
            {
                StreamWriter sw = new StreamWriter(EnvData.ErrorLog, false);
                sw.Write("");
                sw.Close();
            }
            catch (Exception ex)
            {
                HandleError(ex);

            }
        }

        #endregion Logs

        internal static void DebugWrite(string StringToWrite)
        {
            Console.WriteLine(StringToWrite);
            Console.ReadLine();
            System.Diagnostics.Debug.WriteLine(StringToWrite);
        }

        #region Launch URL

        private static string _LaunchURL = string.Empty;
        internal static void LaunchURL(string URL)
        {
            _LaunchURL = URL;
            System.Threading.Thread trd = new System.Threading.Thread(new System.Threading.ThreadStart(StartURL));
            trd.Start();
        }

        private static void StartURL()
        {
            Process.Start(_LaunchURL);
        }

        #endregion Launch URL

    }
}
