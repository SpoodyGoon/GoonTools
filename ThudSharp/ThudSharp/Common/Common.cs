/*************************************************************************
 *                      Common.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
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
using System.IO;
using Gtk;

namespace GoonTools
{
	/// <summary>
	/// This is a static class that holds values that
	/// are reqularly used by the program it also first off
	/// the serialzation of certian objects
	/// </summary>
	public static class Common
	{
		private static GoonTools.Options _Option;
		private static GoonTools.EnviromentData _EnvData = new GoonTools.EnviromentData();
		private static Gdk.Pixbuf _BoardBackGround = new Gdk.Pixbuf(_EnvData.ImageFolder + "background.png" );
		private static Gdk.Pixbuf _BoardPieceDark = new Gdk.Pixbuf(_EnvData.ImageFolder + "BoardPieceDark.png");
		private static Gdk.Pixbuf _BoardPieceLight = new Gdk.Pixbuf(_EnvData.ImageFolder + "BoardPieceLight.png");
		private static Gdk.Pixbuf _HighLight = new Gdk.Pixbuf(_EnvData.ImageFolder + "HighLight.png");
		private static Gdk.Pixbuf _Troll = new Gdk.Pixbuf(_EnvData.ImageFolder + "Troll.png");
		private static Gdk.Pixbuf _Dwarf = new Gdk.Pixbuf(_EnvData.ImageFolder + "Dwarf.png");
		private static Gdk.Pixbuf _Rock = new Gdk.Pixbuf(_EnvData.ImageFolder + "Rock.png");
		#region Public Properties
		
		public static GoonTools.Options Option
		{
			get{return _Option;}
		}
		
		public static GoonTools.EnviromentData EnvData
		{
			get{return _EnvData;}
		}
		
		public static Gdk.Pixbuf BoardBackGround
		{
			get{return _BoardBackGround; }
		}
		
		public static Gdk.Pixbuf BoardPieceDark
		{
			get{return _BoardPieceDark; }
		}
		
		public static Gdk.Pixbuf BoardPieceLight
		{
			get{return _BoardPieceLight; }
		}
		
		public static Gdk.Pixbuf HighLight
		{
			get{return _HighLight; }
		}
		
		public static Gdk.Pixbuf Troll
		{
			get{return _Troll; }
		}
		
		public static Gdk.Pixbuf Dwarf
		{
			get{return _Dwarf; }
		}
		
		public static Gdk.Pixbuf Rock
		{
			get{return _Rock; }
		}
		
		#endregion Public Properties
		
		#region Loading and Saving
		
		public static void LoadAll()
		{
			// search for the options file if it exists load it
			// if it has not been saved load the defaults
			if(File.Exists(EnvData.SaveFolder + "Options.dat"))
			{
				LoadOptions();
			}
			else
			{
				_Option = new Options();
			}
		}
		
		public static void LoadOptions()
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				Stream stream = new FileStream(EnvData.SaveFolder + "Options.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
				_Option = (GoonTools.Options) formatter.Deserialize(stream);
				stream.Close();
			}
			catch(Exception Ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, Ex.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		public static void SaveOptions()
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				Stream stream = new FileStream(EnvData.SaveFolder + "Options.dat", FileMode.Create, FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, _Option);
				stream.Close();
			}
			catch(Exception Ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, Ex.ToString());
				md.Run();
				md.Destroy();
			}
		}		
		
		#endregion Loading and Saving
		
		#region Error Logging		
		
		public static void LogError(string ErrorString)
		{
			StreamWriter sw = new StreamWriter(EnvData.SaveFolder + "error.log", true);
			sw.Write("\n--------------------------------------------------------------------");
			sw.Write("\n---- " + DateTime.Now.ToString());
			sw.Write("\n" + ErrorString);
			sw.Close();
		}
		
		#endregion Error Logging
		
	}
}
