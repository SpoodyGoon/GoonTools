//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.IO;
using Gtk;
using GoonTools;
using MonoPad.Editor;


namespace MonoPad
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class MonoPad : Gtk.Bin
	{
		private MonoPadEditor _Editor = new MonoPadEditor();
		private string _CurrentSavePath = null;
		private string _CurrentSaveName = null;
		public MonoPad ()
		{
			this.Build ();
			this.algEditor.Add(_Editor);
			this.ShowAll();
		}
		
		#region Formatting Functions
		
		protected virtual void OnBoldActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.Bold, true);
		}
		
		protected virtual void OnItalicActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.Bold, true);
		}
		
		protected virtual void OnUnderlineActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.Underline, true);
		}
		
		protected virtual void OnStrikeThroughActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.StrikeThrough, true);
		}		
		
		protected virtual void OnFontSelectionActionActivated (object sender, System.EventArgs e)
		{
			Gtk.FontSelectionDialog fsd = new Gtk.FontSelectionDialog("Select Font");
			if((Gtk.ResponseType)fsd.Run() == Gtk.ResponseType.Ok)
			{
				_Editor.SetFont(fsd.FontName);
			}
			fsd.Destroy();
		}
		
		protected virtual void OnAlignRightActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.AlignRight, true);
		}
		
		protected virtual void OnAlignCenterActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.AlignCenter, true);
		}
		
		protected virtual void OnAlignLeftActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.AlignLeft, true);
		}
		
		protected virtual void OnBlockActionActivated (object sender, System.EventArgs e)
		{
			_Editor.SetBaseFormat(FormatTag.AlignFill, true);
		}
		
		#endregion Formatting Functions
		
		protected virtual void OnNewActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnOpenActionActivated (object sender, System.EventArgs e)
		{
			Gdk.Atom[] a = _Editor.Buffer.SerializeFormats;
			for(int i = 0; i < a.Length; i++)
			{
				System.Diagnostics.Debug.WriteLine("Atom #" + i.ToString() + ":" + a[i].Name);
			}
		}
		
		#region Save Functions
		
		protected virtual void OnSaveActionActivated (object sender, System.EventArgs e)
		{
			try
			{
				FileInfo fi;
				if(_CurrentSaveName != null)
				{
					if(RichTextAction.Active == true)
					{
						fi = new FileInfo(_CurrentSaveName + ".txt");
					}
					else
					{
						fi = new FileInfo(_CurrentSaveName + ".grt");
					}
					// we are all good to go save the file
					SaveFile(_Editor.Buffer.Text, fi.FullName);
				}
				else
				{
					FileChooserDialog fc = new FileChooserDialog("Save File", null, FileChooserAction.Save, "Cancel",ResponseType.Cancel,"Save",ResponseType.Ok);
					FileFilter filter = new FileFilter();
					fc.AddFilter(GetCurrentFilter());
					fc.SelectMultiple = false;
					DirectoryInfo di;
					if(_CurrentSavePath != null)
					{
						di = new DirectoryInfo(_CurrentSavePath);
						if(!di.Exists)
							di.Create();
						
						_CurrentSavePath = di.FullName;
					}
					else
					{
						di = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
						_CurrentSavePath = di.FullName;
					}
					
					fc.SetCurrentFolder(_CurrentSavePath);
					if((Gtk.ResponseType)fc.Run() == Gtk.ResponseType.Ok)
					{
						fi = new FileInfo(fc.Filename);
						_CurrentSaveName = fi.Name;
						_CurrentSavePath = ((DirectoryInfo)fi.Directory).FullName;
						TextBuffer tbb = new TextBuffer(new TextTagTable());
						if(RichTextAction.Active == true)
							SaveFile((byte[])tbb.Serialize(_Editor.Buffer, Gdk.Atom.Intern("application/x-gtk-text-buffer-rich-text",true), _Editor.Buffer.StartIter, _Editor.Buffer.EndIter), _CurrentSaveName);
						else
							SaveFile(_Editor.Buffer.Text, _CurrentSavePath);
					}
					fc.Destroy();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private void SaveFile(byte[] filetext, string fileloc)
		{
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			Stream stream = new FileStream(fileloc, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, filetext);
			stream.Close();
		}
		
		private void SaveFile(string filetext, string fileloc)
		{
			StreamWriter sw = new StreamWriter(fileloc);
			sw.Write(filetext);
			sw.Close();
		}
		
		private Gtk.FileFilter GetCurrentFilter()
		{
			Gtk.FileFilter filter = new FileFilter();
			if(RichTextAction.Active == true)
			{
				filter.Name = "Gtk Rich Text (grt)";
				filter.AddMimeType("application/x-gtk-text-buffer-rich-text");
				filter.AddPattern("*.grt");
			}
			else
			{
				filter.Name = "Text File (txt)";
				filter.AddMimeType("text/plain");
				filter.AddPattern("*.txt");
			}
			return filter;
		}
		
		protected virtual void OnSaveAsActionActivated (object sender, System.EventArgs e)
		{
			try
			{
				FileInfo fi;
				FileChooserDialog fc = new FileChooserDialog("Save File", null, FileChooserAction.Save, "Cancel",ResponseType.Cancel,"Save",ResponseType.Ok);
				fc.AddFilter(GetCurrentFilter());
				fc.SelectMultiple = false;
				DirectoryInfo di;
				if(_CurrentSavePath != null)
				{
					di = new DirectoryInfo(_CurrentSavePath);
					if(!di.Exists)
						di.Create();
					
					_CurrentSavePath = di.FullName;
				}
				else
				{
					di = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
					_CurrentSavePath = di.FullName;
				}
				
				fc.SetCurrentFolder(_CurrentSavePath);
				if((Gtk.ResponseType)fc.Run() == Gtk.ResponseType.Ok)
				{
					fi = new FileInfo(fc.Filename);
					_CurrentSaveName = fi.FullName;
					_CurrentSavePath = ((DirectoryInfo)fi.Directory).FullName;
					TextBuffer tbb = new TextBuffer(new TextTagTable());
					if(RichTextAction.Active == true)
						SaveFile((byte[])tbb.Serialize(_Editor.Buffer, Gdk.Atom.Intern("application/x-gtk-text-buffer-rich-text",true), _Editor.Buffer.StartIter, _Editor.Buffer.EndIter), _CurrentSaveName);
					else
						SaveFile(_Editor.Buffer.Text, _CurrentSavePath);
				}
				fc.Destroy();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		#endregion Save Functions
		
		protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			Gtk.Application.Quit();
		}
		
		protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnOptionsActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnToolbarActionToggled (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnFormatBarActionToggled (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnMiscActionToggled (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnCopyActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnCutActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnPasteActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnClearActionActivated (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnSelectAllActionActivated (object sender, System.EventArgs e)
		{
		}
		
	}
}