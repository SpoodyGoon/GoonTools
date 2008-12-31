// frmOptions.cs created with MonoDevelop
// User: spoodygoon at 8:27 PM 7/31/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Global;

namespace BookmarkSharpClient
{
	
	
	public partial class frmOptions : Gtk.Dialog
	{
		
		public frmOptions()
		{
			this.Build();
			this.cmdOpenTagsEditor.Clicked += OnCmdOpenTagsClicked;
			Options.Load();
			txtPassword.Text = Options.GetOption("Password");
			txtLastBookmarkUpdate.Text = Options.GetOption("BookmarkUpdate");
			txtLastTagUpdate.Text = Options.GetOption("TagUpdate");
			FillTags();
			this.ShowAll();
		}

		protected virtual void OnCmdOpenTagsClicked (object sender, System.EventArgs e)
		{
			frmTagEditor fm = new frmTagEditor();
			fm.Run();
			fm.Destroy();
		}
		
		private void FillTags()
		{
			swTags.Add(new BookmarkSharpClient.TreeViews.tvwTags());
			swTags.ShowAll();
		}

		protected virtual void OnCmdNewBrowserClicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnCmdAddBrowserClicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnCmdRemoveBrowserClicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnButton21Clicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Options.SetOption("Password", txtPassword.Text);
			Options.Save();
			Options.Load();
			this.Hide();
		}

		protected virtual void OnCmdOpenTagsEditorClicked (object sender, System.EventArgs e)
		{
			frmTagEditor fm = new frmTagEditor();
			fm.Run();
			fm.Destroy();
		}
	}
}
