using System;
using System.IO;
using Gtk;

namespace libGlobalTools
{
	public class ErrorManagerTools
	{
		public void HandleError (Exception ex)
		{
			HandleError (null, ex);
		}

		public void HandleError (Gtk.Window ParentWindow, Exception ex)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder ();
			sb.Append (System.Environment.NewLine + "------------------------------------------------------------------------------");
			sb.Append (System.Environment.NewLine + "--------------------------- " + DateTime.Now.ToString () + " --------------------------");
			sb.Append (System.Environment.NewLine + ex.ToString ());
			sb.Append (System.Environment.NewLine + "------------------------------------------------------------------------------");
			
			if (GlobalTools.LocalSystem.UseErrorLog)
			{
				StreamWriter sw = new StreamWriter (GlobalTools.LocalSystem.ErrorLogFile, true);
				sw.Write (sb.ToString ());
				sw.Close ();
			}
			/*
			 * code to write to the event log
			if (!EventLog.SourceExists(cs))
				EventLog.CreateEventSource(cs, "Application");    
			
			EventLog.WriteEntry(cs, message, EventLogEntryType.Error);
			*/
			
			Gtk.MessageDialog md = new MessageDialog (ParentWindow, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, ex.ToString ());
			md.Run ();
			md.Destroy ();
			sb.Length = 0;
		}
		
		public void Show (string ErrorMessage)
		{
		}
		
		public void Show (Exception ex)
		{
		}

		public void Show (Gtk.Window ParentWindow, Exception ex)
		{
		}
	}
}

