
using System;

namespace CMYControls
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class QuickDate : Gtk.Bin
	{
		public QuickDate()
		{
			Build();
		}
		
		private void Build()
		{
			Gtk.Entry txtDate = new Gtk.Entry();
			txtDate.HasFrame = false;
			txtDate.Sensitive = false;
			Gtk.Alignment algDate = new Gtk.Alignment(0.5f, 0.5f, 0.5f, 0.5f);
			algDate.Add(txtDate);
			Gtk.Image imgClearDate = new Gtk.Image(Gdk.Pixbuf.LoadFromResource("ClearDate.png"));
			Gtk.Button btnClearDate = new Gtk.Button(imgClearDate);
			btnClearDate.Clicked += delegate {txtDate.Text = "";};
			Gtk.Alignment algClearDate = new Gtk.Alignment(0.5f, 0.5f, 0.5f, 0.5f);
			algClearDate.Add(btnClearDate);
			Gtk.Image imgQuickDate = new Gtk.Image(Gdk.Pixbuf.LoadFromResource("QuickDate.png"));
			Gtk.Button btnQuickDate = new Gtk.Button(imgQuickDate);
			btnQuickDate.Clicked += btnQuickDate_Clicked;
			Gtk.Alignment algQuickDate = new Gtk.Alignment(0.5f, 0.5f, 0.5f, 0.5f);
			algQuickDate.Add(btnQuickDate);
			Gtk.HBox hbxMain = new Gtk.HBox(false, 0);
			hbxMain.Add(algDate);
			hbxMain.Add(algClearDate);
			hbxMain.Add(algQuickDate);			
			Gtk.Alignment algMain = new Gtk.Alignment(0.5f, 0.5f, 0.5f, 0.5f);
			algMain.Add(hbxMain);
			this.Add(algMain);
			this.ShowAll();
		}

		protected virtual void btnQuickDate_Clicked (object sender, System.EventArgs e)
		{
//			QuickDateWindow win = new QuickDateWindow(this.Allocation);
//			win.ShowPopUp();
		}		
		
	}
}
