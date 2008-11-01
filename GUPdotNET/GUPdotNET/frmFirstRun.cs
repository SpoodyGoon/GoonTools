// frmFirstRun.cs created with MonoDevelop
// User: spoodygoon at 8:50 PM 6/3/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;

namespace GUPdotNET
{
	
	
	public partial class frmFirstRun : Gtk.Dialog
	{
		
		public frmFirstRun()
		{
			this.Build();
		}

		protected virtual void OnBtnNoClicked (object sender, System.EventArgs e)
		{
			if(System.IO.File.Exists("gdnFirstRunYes.txt"))
				System.IO.File.Delete("gdnFirstRunYes.txt");
			System.IO.StreamWriter sw = new StreamWriter("gdnFirstRunNo.txt");
			sw.WriteLine("No");
			sw.Close();
			sw.Flush();
			this.Hide();
		}

		protected virtual void OnBtnYesClicked (object sender, System.EventArgs e)
		{
			if(System.IO.File.Exists("gdnFirstRunNo.txt"))
				System.IO.File.Delete("gdnFirstRunNo.txt");
			System.IO.StreamWriter sw = new StreamWriter("gdnFirstRunYes.txt");
			sw.WriteLine("Yes");
			sw.Close();
			sw.Flush();
			this.Hide();
		}
	}
}
