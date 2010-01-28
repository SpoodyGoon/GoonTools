/*************************************************************************
 *                      ButterTags.cs
 *
 *         Copyright (C) 2009 Andrew York
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using Gtk;
using GoonTools;

namespace MonoPad.Editor
{
	public class BufferTags
	{
		private System.Collections.ArrayList _CustomTags = new System.Collections.ArrayList();
		private Gtk.TextBuffer _TextBuffer;
		public BufferTags(Gtk.TextBuffer textbuffer)
		{
			try
			{
				_TextBuffer = textbuffer;
				SetBaseBufferTags();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void SetBaseBufferTags()
		{
			try
			{
				// Text Decaration
				TextTag tag  = new TextTag ("Bold");
				tag.Weight = Pango.Weight.Bold;
				_TextBuffer.TagTable.Add (tag);
				
				tag  = new TextTag ("Italic");
				tag.Style = Pango.Style.Italic;
				_TextBuffer.TagTable.Add (tag);
				
				tag  = new TextTag ("Underline");
				tag.Underline = Pango.Underline.Single;
				_TextBuffer.TagTable.Add (tag);
				
				tag  = new TextTag ("StrikeThrough");
				tag.Strikethrough = true;
				_TextBuffer.TagTable.Add (tag);
				
				// Wrap types
				tag  = new TextTag ("WordWrap");
				tag.WrapMode = WrapMode.Word;
				_TextBuffer.TagTable.Add (tag);

				tag  = new TextTag ("CharWrap");
				tag.WrapMode = WrapMode.Char;
				_TextBuffer.TagTable.Add (tag);

				tag  = new TextTag ("NoWrap");
				tag.WrapMode = WrapMode.None;
				_TextBuffer.TagTable.Add (tag);

				// Alignments
				tag  = new TextTag ("AlignLeft");
				tag.Justification = Justification.Left;
				_TextBuffer.TagTable.Add (tag);
				
				tag  = new TextTag ("AlignCenter");
				tag.Justification = Justification.Center;
				_TextBuffer.TagTable.Add (tag);

				tag  = new TextTag ("AlignRight");
				tag.Justification = Justification.Right;
				_TextBuffer.TagTable.Add (tag);

				tag  = new TextTag ("AlignFill");
				tag.Justification = Justification.Fill;
				_TextBuffer.TagTable.Add (tag);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public string SetFont(string fontname)
		{
			string TagName = "FontTag" + (_CustomTags.Count + 1).ToString();
			TextTag tag = new TextTag(TagName);
			tag.Font = fontname;
			_TextBuffer.TagTable.Add(tag);
			return TagName;
		}
	}
	
	public enum FormatTag
	{
		None,
		Bold,
		Italic,
		Underline,
		StrikeThrough,
		WordWrap,
		CharWrap,
		NoWrap,
		AlignLeft,
		AlignCenter,
		AlignRight,
		AlignFill
	}
	
	public enum SaveType
	{
		None,
		Text,
		RichText
	}
}
