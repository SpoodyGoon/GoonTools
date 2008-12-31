// clsGlobals.cs created with MonoDevelop
// User: spoodygoon at 8:21 AM 5/17/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Configuration;
using System.IO;
using Gtk;

namespace Global
{
	
	
	public class Common
	{
		
		public static string GetAppPath()
		{
			string strAppPath = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
			strAppPath = strAppPath.Substring(0, strAppPath.LastIndexOf(GetDirChar()) + 1);
			return strAppPath;
		}
		
		public static string GetDirChar()
		{
			string strDirChar = null;
			if(System.Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				strDirChar = @"\";
			}
			else
			{
				strDirChar = @"/";
			}
			
			return strDirChar;
		}
		
		public static string GetOS()
		{
			return System.Environment.OSVersion.Platform.ToString();
		}
		
		public static string GetWorkingFolder()
		{
			string strDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + GetDirChar() + ".BookmarkSharp" + GetDirChar();
			if(!Directory.Exists(strDir))
				Directory.CreateDirectory(strDir);
			return strDir;
		}
		
		public static void LogError(string strErrorString)
		{
			if(ConfigurationManager.AppSettings["LoggingType"] != null)
			{
				switch(ConfigurationManager.AppSettings["LoggingType"].ToString())
				{
					case "MessageBox":
						MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error,  ButtonsType.Ok, strErrorString, "ERROR!");
						md.Run();
						md.Destroy();
						break;
					case "File":
						StreamWriter sw = new StreamWriter(GetWorkingFolder(), true);
						sw.Write("\n--------------------------------------------------------------------");
						sw.Write("\n---- " + DateTime.Now.ToString());
						sw.Write("\n" + strErrorString);
						sw.Close();
						break;
					default:
						System.Diagnostics.Debug.WriteLine("Error: " + strErrorString);
						break;
				}
			}
			else
			{				
				System.Diagnostics.Debug.WriteLine("Error: " + strErrorString);
			}
		}
	}
}
