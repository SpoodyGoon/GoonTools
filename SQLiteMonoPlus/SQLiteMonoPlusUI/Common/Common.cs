/*************************************************************************
 *                      Common.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <spoodygoon@gmail.com>
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
using Mono.Data.SqliteClient;
using Gtk;

namespace SQLiteMonoPlusUI.GlobalTools
{
    /// <summary>
    /// This is a static class that holds values that
    /// are reqularly used by the program it also first off
    /// the serialzation of certian objects
    /// </summary>
    internal static class Common
    {
        internal static EnviromentData EnvData = new EnviromentData();
        internal static GlobalData.ConnectionStore RecentConnections = new GlobalData.ConnectionStore();


        internal static void Load()
        { 
        	
            RecentConnections.Load(); 
            
            //if (string.IsNullOrEmpty(UserConfig.Default.DBLocation) || !File.Exists(UserConfig.Default.DBLocation))
            //{
            //    // TODO copy the database to the save folder
            //    UserConfig.Default.DBLocation = new FileInfo(Path.Combine(EnvData.UserDataPath, "SQLiteMonoPlus.s3db")).FullName;
            //    File.Copy(Path.Combine(EnvData.AppDataPath, "SQLiteMonoPlus.s3db"), UserConfig.Default.DBLocation);               
            //}
        }

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
            if (SQLiteMonoPlusUI.UserConfig.Default.UserErrorLog)
            {
                StreamWriter sw = new StreamWriter(EnvData.ErrorLogFile, true);
                sw.Write(sb.ToString());
                sw.Close();
            }

            Gtk.MessageDialog md = new MessageDialog(parent_window, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, ex.ToString());
            md.Run();
            md.Destroy();
            sb.Length = 0;
        }

        internal static void CleanErrorLog()
        {
            try
            {
                StreamWriter sw = new StreamWriter(EnvData.ErrorLogFile, false);
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
       
        internal static bool DatabaseTryConnect(string DBFile)
        {        	
			bool blnSuccess = true;
			try 
			{
				SqliteConnection sqlCN = new SqliteConnection (Constants.ConnectionString.Simple.Replace ("[DBPATH]", DBFile));
				SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.ConnectionTest, sqlCN);
				sqlCN.Open ();
				sqlCMD.ExecuteNonQuery();
				sqlCN.Close ();
				sqlCMD.Dispose();
				sqlCN.Dispose ();
			} 
			catch (Exception ex) 
			{
				blnSuccess = false;
				Console.WriteLine (ex.ToString ());				
			}
			return blnSuccess;
        }
    }
}
