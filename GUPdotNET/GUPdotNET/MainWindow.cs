// MainWindow.cs
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Configuration;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	private void About()
	{
		AboutDialog dialog = new AboutDialog ();
		Assembly asm = Assembly.GetExecutingAssembly ();
		
		dialog.Name = (asm.GetCustomAttributes (
			typeof (AssemblyTitleAttribute), false) [0]
			as AssemblyTitleAttribute).Title;
		
		dialog.Version = asm.GetName ().Version.ToString ();
		
		dialog.Comments = (asm.GetCustomAttributes (
			typeof (AssemblyDescriptionAttribute), false) [0]
			as AssemblyDescriptionAttribute).Description;
		
		dialog.Copyright = (asm.GetCustomAttributes (
			typeof (AssemblyCopyrightAttribute), false) [0]
			as AssemblyCopyrightAttribute).Copyright;
		
		dialog.License = license;
		
		dialog.Authors = authors;
		
	}
	
	private static string [] authors = new string [] {
		"Brian Nickel <name@domain.ext>",
		"Rupert T. Monkey <name@domain.ext>"
	};
	
	private static string license =
@"Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
""Software""), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";
}
