/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 1/27/2010
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using GoonTools;

namespace MonoPad.Editor
{
	/// <summary>
	/// Description of MonoPadEditor.
	/// </summary>
	public class MonoPadEditor : Gtk.TextView
	{
		BufferTags _BufferTags;
		public MonoPadEditor()
		{
			this.WrapMode = Gtk.WrapMode.Word;
			_BufferTags = new BufferTags(this.Buffer);
		}
		
		public bool SetBaseFormat(FormatTag tag)
		{
			return SetBaseFormat(tag, true);
		}
		
		public bool SetBaseFormat(FormatTag tag, bool useselected)
		{
			bool blnReturn = true;
			try
			{
				Gtk.TextIter LineIter = Gtk.TextIter.Zero;
				Gtk.TextIter StartIter = Gtk.TextIter.Zero;
				Gtk.TextIter EndIter = Gtk.TextIter.Zero;
				// if we are to use the highlighted text
				if(this.Buffer.HasSelection)
				{
					if(this.Buffer.GetSelectionBounds(out StartIter, out EndIter))
					{
						this.Buffer.ApplyTag(tag.ToString(), StartIter, EndIter);
					}
				}
				else
				{
					LineIter = this.Buffer.GetIterAtLine(this.Buffer.CursorPosition);
					
					if(this.ForwardDisplayLine(ref StartIter) && this.ForwardDisplayLineEnd(ref EndIter))
					{
						this.Buffer.ApplyTag(tag.ToString(), StartIter, EndIter);
					}
				}
			}
			catch(Exception ex)
			{
				blnReturn = false;
				Common.HandleError(ex);
			}
			return blnReturn;
		}
		
		public bool SetFont(string fontname)
		{
			bool blnReturn = true;
			try
			{
				Gtk.TextIter StartIter;
				Gtk.TextIter EndIter;
				if(this.Buffer.GetSelectionBounds(out StartIter, out EndIter))
				{
					this.Buffer.ApplyTag(_BufferTags.SetFont(fontname), StartIter, EndIter);
				}
			}
			catch(Exception ex)
			{
				blnReturn = false;
				Common.HandleError(ex);
				
			}
			return blnReturn;
		}
	}
}
