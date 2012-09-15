
using System;
using Gtk;

namespace libGlobalTools
{	
	public class GenericBufferTags : Gtk.TextTagTable
	{		
		private const int gray50_width = 2;
		private const int gray50_height = 2;
		private const string gray50_bits = "\x02\x01";
		public GenericBufferTags() : base()
		{
			// Create a bunch of tags. Note that it's also possible to
			// create tags with gtk_text_tag_new() then add them to the
			// tag table for the buffer, gtk_text_buffer_create_tag() is
			// just a convenience function. Also note that you don't have
			// to give tags a name; pass NULL for the name to create an
			// anonymous tag.
			//
			// In any real app, another useful optimization would be to create
			// a GtkTextTagTable in advance, and reuse the same tag table for
			// all the buffers with the same tag set, instead of creating
			// new copies of the same tags for every buffer.
			//
			// Tags are assigned default priorities in order of addition to the
			// tag table.	 That is, tags created later that affect the same text
			// property affected by an earlier tag will override the earlier
			// tag.  You can modify tag priorities with
			// gtk_text_tag_set_priority().
			
			TextTag tag  = new TextTag ("heading");
			tag.Weight = Pango.Weight.Bold;
			tag.Size = (int) Pango.Scale.PangoScale * 15;
			this.Add (tag);
			
			tag  = new TextTag ("sub_heading");
			tag.Weight = Pango.Weight.Bold;
			tag.Size = (int) Pango.Scale.PangoScale * 10;
			this.Add (tag);
			
			tag  = new TextTag ("italic");
			tag.Style = Pango.Style.Italic;
			this.Add (tag);
			
			tag  = new TextTag ("bold");
			tag.Weight = Pango.Weight.Bold;
			this.Add (tag);
			
			tag  = new TextTag ("big");
			tag.Size = (int) Pango.Scale.PangoScale * 20;
			this.Add (tag);
			
			tag  = new TextTag ("xx-small");
			tag.Scale = Pango.Scale.XXSmall;
			this.Add (tag);
			
			tag  = new TextTag ("x-large");
			tag.Scale = Pango.Scale.XLarge;
			this.Add (tag);
			
			tag  = new TextTag ("monospace");
			tag.Family = "monospace";
			this.Add (tag);
			
			tag  = new TextTag ("blue_foreground");
			tag.Foreground = "blue";
			this.Add (tag);
			
			tag  = new TextTag ("red_background");
			tag.Background = "red";
			this.Add (tag);
			
			// The C gtk-demo passes NULL for the drawable param, which isn't
			// multi-head safe, so it seems bad to allow it in the C# API.
			// But the Window isn't realized at this point, so we can't get
			// an actual Drawable from it. So we kludge for now.
			Gdk.Pixmap stipple = Gdk.Pixmap.CreateBitmapFromData (Gdk.Screen.Default.RootWindow, gray50_bits, gray50_width, gray50_height);
			
			tag  = new TextTag ("background_stipple");
			tag.BackgroundStipple = stipple;
			this.Add (tag);
			
			tag  = new TextTag ("foreground_stipple");
			tag.ForegroundStipple = stipple;
			this.Add (tag);
			
			tag  = new TextTag ("big_gap_before_line");
			tag.PixelsAboveLines = 30;
			this.Add (tag);
			
			tag  = new TextTag ("big_gap_after_line");
			tag.PixelsBelowLines = 30;
			this.Add (tag);
			
			tag  = new TextTag ("double_spaced_line");
			tag.PixelsInsideWrap = 10;
			this.Add (tag);
			
			tag  = new TextTag ("not_editable");
			tag.Editable = false;
			this.Add (tag);
			
			tag  = new TextTag ("word_wrap");
			tag.WrapMode = WrapMode.Word;
			this.Add (tag);
			
			tag  = new TextTag ("char_wrap");
			tag.WrapMode = WrapMode.Char;
			this.Add (tag);
			
			tag  = new TextTag ("no_wrap");
			tag.WrapMode = WrapMode.None;
			this.Add (tag);
			
			tag  = new TextTag ("center");
			tag.Justification = Justification.Center;
			this.Add (tag);
			
			tag  = new TextTag ("right_justify");
			tag.Justification = Justification.Right;
			this.Add (tag);
			
			tag  = new TextTag ("wide_margins");
			tag.LeftMargin = 50;
			tag.RightMargin = 50;
			this.Add (tag);
			
			tag  = new TextTag ("strikethrough");
			tag.Strikethrough = true;
			this.Add (tag);
			
			tag  = new TextTag ("underline");
			tag.Underline = Pango.Underline.Single;
			this.Add (tag);
			
			tag  = new TextTag ("double_underline");
			tag.Underline = Pango.Underline.Double;
			this.Add (tag);
			
			tag  = new TextTag ("superscript");
			tag.Rise = (int) Pango.Scale.PangoScale * 10;
			tag.Size = (int) Pango.Scale.PangoScale * 8;
			this.Add (tag);
			
			tag  = new TextTag ("subscript");
			tag.Rise = (int) Pango.Scale.PangoScale * -10;
			tag.Size = (int) Pango.Scale.PangoScale * 8;
			this.Add (tag);
			
			tag  = new TextTag ("rtl_quote");
			tag.WrapMode = WrapMode.Word;
			tag.Direction = TextDirection.Rtl;
			tag.Indent = 30;
			tag.LeftMargin = 20;
			tag.RightMargin = 20;
			this.Add (tag);
		}
	}
}
