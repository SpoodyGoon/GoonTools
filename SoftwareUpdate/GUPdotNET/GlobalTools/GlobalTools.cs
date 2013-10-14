using System;
using System.IO;
using GUPdotNET.Data;
using MonoTools.IO;
using System.Configuration;

namespace GUPdotNET
{
	internal static class GlobalTools
    {
        internal static string UpdateProgramName { get; private set; }

        internal static RunType UpdateRunType { get; set; }

        internal static bool DebugMode { get; private set; }

        internal static AppSettings Options { get; set; }

		internal static PackageInfo PackageInfo{ get; set; }

		internal static ProgramInfo ProgramInfo{ get; set; }

        internal static LocalSystemTools LocalSystem { get; private set; }

		internal static void Initalize()
		{
            UpdateProgramName = ConfigurationManager.AppSettings["UpdateProgramName"].ToString();
            DebugMode = Convert.ToBoolean(ConfigurationManager.AppSettings["DebugMode"]);
			LocalSystem = new LocalSystemTools();
            LocalSystem.Initalize(DebugMode);
            Options = new AppSettings();
            Options.Load();
        }

        internal static void HandleError(Exception error)
        {   
            HandleError(null, error);
        }

        internal static void HandleError(Gtk.Window parentWindow, Exception error)
        {            
            Gtk.MessageDialog errorDialog = new Gtk.MessageDialog(parentWindow, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Ok, false, error.Message, "An error has occured");
            errorDialog.Run();
            errorDialog.Destroy();
        }

        internal static string ToLocalFile(string remoteURL)
        {
            return ToLocalFile(new Uri(remoteURL));
        }

        internal static string ToLocalFile(Uri remoteURL)
        {
            return Path.Combine(GlobalTools.LocalSystem.TempPackagePath, Path.GetFileName(remoteURL.LocalPath));
        }
	}
}

