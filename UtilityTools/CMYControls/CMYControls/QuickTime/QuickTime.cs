
using System;

namespace CMYControls
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class QuickTime : Gtk.Bin
	{

		public QuickTime()
		{
			this.Build();
		}

		protected virtual void OnBtnQuickTimeClicked (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnBtnClearTimeClicked (object sender, System.EventArgs e)
				{
			txtTime.Text = "";
				}		
		
	}
}
