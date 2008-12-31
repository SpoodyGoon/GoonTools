// frmAddNew.cs created with MonoDevelop
// User: spoodygoon at 9:27 PM 7/29/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace BookmarkSharpClient
{
	
	
	public partial class frmAddNew : Gtk.Dialog
	{
		public frmAddNew()
		{
			this.Build();
		}
		
		public string strTitle
		{
			set{ this.txtTitle.Text = value;}
			get{ return this.txtTitle.Text;}
		}

		public string strURL
		{
			set{ this.txtTitle.Text = value;}
			get{ return this.txtTitle.Text;}
		}

		public bool blnIsFolder
		{
			set{ this.cbxIsFolder.Active = value;}
			get{ return this.cbxIsFolder.Active;}
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnCbxIsFolderClicked (object sender, System.EventArgs e)
		{
		}
	}
}
