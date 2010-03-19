// 
// MainWindow.cs
//
// Author:
//       spoodygoon <${AuthorEmail}>
// 
// Copyright (c) 2010 spoodygoon
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.IO;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		this.btnGenerate.Label = "Get CheckSum";
		this.ShowAll();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnBtnGenerateClicked (object sender, System.EventArgs e)
	{
		try
		{
			if(fcSelectedFile.Filename != "")
			{
				GoonTools.CheckSum c = new GoonTools.CheckSum(fcSelectedFile.Filename);
				txtMD5.Text = c.GetCheckSum().Replace("-", "");
			}
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
		}
	}
	
	protected virtual void OnBtnClearClicked (object sender, System.EventArgs e)
	{
		try
		{
			fcSelectedFile.SetFilename(null);
			txtMD5.Text = "";
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
		}
	}
	
	protected virtual void OnQuitAction1Activated (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	protected virtual void OnSaveAction1Activated (object sender, System.EventArgs e)
	{
		try
		{
			FileChooserDialog fc = new FileChooserDialog("Save CheckSum", this, FileChooserAction.Save, "Cancel",ResponseType.Cancel, "Save",ResponseType.Ok);
			fc.Title = "Save MD5";
			fc.DestroyWithParent = true;
			fc.WindowPosition = WindowPosition.Center;
			FileFilter ff = new FileFilter();
			ff.AddMimeType("text/plain");
			ff.Name = "CheckSum.txt";
			fc.Filter = ff;
			fc.SetFilename("CheckSum.txt");
			if((Gtk.ResponseType)fc.Run() == Gtk.ResponseType.Ok)
			{
				StreamWriter sw = new StreamWriter(fc.Filename);
				sw.WriteLine(txtMD5.Text);
				sw.Close();
			}
			fc.Destroy();
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
		}
	}
	
	
	
	
	
	
	
}
