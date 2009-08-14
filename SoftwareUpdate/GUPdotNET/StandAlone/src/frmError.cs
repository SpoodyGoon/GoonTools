// frmError.cs created with MonoDevelop
// User: spoodygoon at 5:35 PM 3/28/2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace GUPdotNET
{
	
	
	public partial class frmError : Gtk.Dialog
	{
		
		public frmError()
		{
			this.Build();
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
        #region Pubic Properties
		
		public string ErrorMess
		{
			set{lblErrorMess.Text = value;}
		}
		
		public string ErrorDetails
		{
			set{txtDetails.Buffer.Text = value;}
		}
		
		#endregion Pubic Properties
	}
}
