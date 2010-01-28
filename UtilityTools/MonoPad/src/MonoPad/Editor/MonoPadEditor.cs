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
			_BufferTags = new BufferTags(this.Buffer);
		}
		
		public bool SetBaseFormat(FormatTag tag)
		{
			return SetBaseFormat(tag, true);
		}
		
		public bool SetBaseFormat(FormatTag tag, bool UseSelected)
		{
			bool blnReturn = true;
			try
			{
				Gtk.TextIter StartIter;
				Gtk.TextIter EndIter;
				if(this.Buffer.GetSelectionBounds(out StartIter, out EndIter))
				{
					this.Buffer.ApplyTag(tag.ToString(), StartIter, EndIter);
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
