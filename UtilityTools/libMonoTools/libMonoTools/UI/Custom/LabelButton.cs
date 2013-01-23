using System;
using Gtk;

namespace libMonoTools.UI.Custom
{
	[System.ComponentModel.ToolboxItem(true)]
	public class LabelButton : Gtk.EventBox
	{
		private string _Text = "LinkButton";
		public LabelButton (string text) : base()
		{
			_Text = text;
		}

		public string Text {
			get{ return _Text;}
			set{ _Text = value;}
		}


	}
}

