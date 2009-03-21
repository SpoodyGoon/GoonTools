/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 3/12/2009
 * Time: 2:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace GUPdotNET
{
	/// <summary>
	/// Description of GUPdotNET.
	/// </summary>
	internal static class GUPdotNET
	{
		// value from the calling application or from the app con
		private static string _InstallType = null;
		private static string _ProgramName = null;
		private static string _ProgramFullPath = null;
		private static string _UpdateInfoURL = null;
		private static int _CurrentMajorVersion = -1;
		private static int _CurrentMinorVersion = -1;
		private static bool _SilentCheck = true;
		private static string _CallingApplication = null;
		
		// values that are imported from the aspx file on the listed web site
		private static string _UpdateFileURL = null;
		private static int _UpdateMajorVersion = -1;
		private static int _UpdateMinorVersion = -1;
		private static string _LatestVersion = null;
		private static string _Error = null;
		
		#region Public Properties Local
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		internal static string InstallType
		{
			set{_InstallType=value;}
			get{return _InstallType;}
		}
		
		/// <summary>
		///  the freindly name of the application
		/// </summary>
		internal static  string ProgramName
		{
			set{_ProgramName = value;}
			get{return _ProgramName;}
		}
		
		/// <summary>
		///  full path to the application we are updating
		/// </summary>
		internal static  string ProgramFullPath
		{
			set{_ProgramFullPath = value;}
			get{return _ProgramFullPath;}
		}
		
		/// <summary>
		///  This is URL for the web site
		///  containing the update information
		/// </summary>
		internal static string UpdateInfoURL
		{
			set{_UpdateInfoURL = value;}
			get{return _UpdateInfoURL;}
		}
		
		/// <summary>
		///  This is the major version of the application
		///  we are looking to update
		/// </summary>
		internal static int CurrentMajorVersion
		{
			set{_CurrentMajorVersion=value;}
			get{return _CurrentMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version or the application
		///  we are looking to update
		/// </summary>
		internal static int CurrentMinorVersion
		{
			set{_CurrentMinorVersion=value;}
			get{return _CurrentMinorVersion;}
		}
		
		/// <summary>
		///  if this is set to true this will
		///  not report if no connection is made to the
		///  web server or if other interuptions occur
		/// </summary>
		internal static bool SilentCheck
		{
			set{_SilentCheck=value;}
			get{return _SilentCheck;}
		}
		
		/// <summary>
		///  The name of the application that we are looking to update
		/// </summary>
		internal static string CallingApplication
		{
			set{_CallingApplication = value;}
			get{return _CallingApplication;}
		}
		
		#endregion Public Properties Local
		
		#region Public Properties Web Server
		
		/// <summary>
		///  The file that is the updated installation
		/// </summary>
		internal static string UpdateFileURL
		{
			set{_UpdateFileURL=value;}
			get{return _UpdateFileURL;}
		}
		
		/// <summary>
		///  This is the major version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		internal static int UpdateMajorVersion
		{
			set{_UpdateMajorVersion= value;}
			get{return _UpdateMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		internal static int UpdateMinorVersion
		{
			set{_UpdateMinorVersion = value;}
			get{return _UpdateMinorVersion;}
		}
		
		/// <summary>
		///  this is a generic string of the updatable version
		/// </summary>
		internal static string LatestVersion
		{
			set{_LatestVersion=value;}
			get{return _LatestVersion;}
		}
		
		/// <summary>
		///  this contains any error that is returned from the
		///  web site portion of the app
		/// </summary>
		internal static string Error
		{
			set{_Error=value;}
			get{return _Error;}
		}
		
		#endregion Public Properties Web Server
		
		
	}
}
