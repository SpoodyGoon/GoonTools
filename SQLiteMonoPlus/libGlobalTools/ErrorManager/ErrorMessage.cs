using System;

namespace libGlobalTools
{
	public partial class dlgErrorMessage : Gtk.Dialog
	{
		public dlgErrorMessage ()
		{
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}

