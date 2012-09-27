using System;
using Gtk;

namespace SQLiteMonoPlusUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public class ResultMessageView : Gtk.TextView
	{
		public ResultMessageView () : base()
		{
			this.BorderWidth = (uint)5;
			TextTag tag = new TextTag("ResultSuccess");
			tag.Weight = Pango.Weight.Normal;
			tag.Size = (int) Pango.Scale.PangoScale * 10;
			this.Buffer.TagTable.Add (tag);
			tag = new TextTag("ResultError");
			tag.Weight = Pango.Weight.Bold;
			tag.Size = (int) Pango.Scale.PangoScale * 10;
			tag.ForegroundGdk = new Gdk.Color(255,11,11);
			this.Buffer.TagTable.Add (tag);

		}

		public string SuccessMessage
		{
			set
			{
				this.Buffer.Text = value.Trim();
				this.Buffer.ApplyTag("ResultSuccess", this.Buffer.StartIter, this.Buffer.EndIter);
				this.QueueDraw();
				this.ShowNow();
			}
		}
		
		public string ErrorMessage
		{
			set
			{
				this.Buffer.Text = value.Trim();
				this.Buffer.ApplyTag("ResultError", this.Buffer.StartIter, this.Buffer.EndIter);
				this.QueueDraw();
				this.ShowNow();
			}
		}
	}
}

