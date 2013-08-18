using System;
using System.Linq;
using GUPdotNET.Data;
using GUPdotNET.IO;
using Gtk;
using GUPdotNET.UI.Views;

namespace GUPdotNET
{
    public class MainClass
    {
        public static void Main(string[] args)
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
