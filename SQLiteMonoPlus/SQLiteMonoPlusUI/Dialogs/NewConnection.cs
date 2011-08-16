using System;

namespace SQLiteMonoPlusUI
{
	public partial class NewConnection : Gtk.Dialog
	{
		//Data Source=filename;Version=3;Pooling=False;Max Pool Size=100;
		private string _FilePath = string.Empty;
		private string _Password = string.Empty;
		private int _Version = 3;
		private bool _Pooling = false;
		private int _MaxPoolSize = 0;
		public NewConnection ()
		{
			this.Build ();
		}
	}
}

