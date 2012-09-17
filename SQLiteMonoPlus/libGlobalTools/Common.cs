/*************************************************************************
 *                      Common.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <spoodygoon@gmail.com>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General public License for more details.
 *
 * You should have received a copy of the GNU General public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */
using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using Gtk;

namespace libGlobalTools
{
	public static class Common
	{
		public static LocalSystemTools LocalSystem = new LocalSystemTools ();

		public static void Load ()
		{ 
		}

        #region Logs

		public static void HandleError (Exception ex)
		{
			HandleError (null, ex);
		}

		public static void HandleError (Gtk.Window parent_window, Exception ex)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder ();
			sb.Append (System.Environment.NewLine + "------------------------------------------------------------------------------");
			sb.Append (System.Environment.NewLine + "--------------------------- " + DateTime.Now.ToString () + " --------------------------");
			sb.Append (System.Environment.NewLine + ex.ToString ());
			sb.Append (System.Environment.NewLine + "------------------------------------------------------------------------------");

			if (LocalSystem.UserErrorLog) {
				StreamWriter sw = new StreamWriter (LocalSystem.ErrorLogFile, true);
				sw.Write (sb.ToString ());
				sw.Close ();
			}
			/*
			 * code to write to the event log
			if (!EventLog.SourceExists(cs))
				EventLog.CreateEventSource(cs, "Application");    
			
			EventLog.WriteEntry(cs, message, EventLogEntryType.Error);
			*/

			Gtk.MessageDialog md = new MessageDialog (parent_window, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, ex.ToString ());
			md.Run ();
			md.Destroy ();
			sb.Length = 0;
		}

		public static void CleanErrorLog ()
		{
			try {
				StreamWriter sw = new StreamWriter (LocalSystem.ErrorLogFile, false);
				sw.Write ("");
				sw.Close ();
			}
			catch (Exception ex) {
				HandleError (ex);

			}
		}

        #endregion Logs

		public static void DebugWrite (string StringToWrite)
		{
			Console.WriteLine (StringToWrite);
			Console.ReadLine ();
			System.Diagnostics.Debug.WriteLine (StringToWrite);
		}

        #region Launch URL

		private static string _LaunchURL = string.Empty;

		public static void LaunchURL (string URL)
		{
			_LaunchURL = URL;
			System.Threading.Thread trd = new System.Threading.Thread (new System.Threading.ThreadStart (StartURL));
			trd.Start ();
		}

		private static void StartURL ()
		{
			Process.Start (_LaunchURL);
		}

        #endregion Launch URL

		public static T StringToEnum<T> (string name)
		{
			return (T)Enum.Parse (typeof(T), name);
		}
	}
}
