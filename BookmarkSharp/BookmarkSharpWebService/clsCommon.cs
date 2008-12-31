/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 8/12/2008
 * Time: 10:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Configuration;

namespace BookmarkSharpWebService
{
	/// <summary>
	/// Description of clsCommon.
	/// </summary>
	public static class Common
	{
		
		#region "ErrorLoging"
		
		public static void LogError(System.Exception ex)
		{
			// see if we are in development
			if(ConfigurationManager.AppSettings["RunEnv"].ToString().ToLower() == "dev")
			{
				// for development just write to the counsol
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
			else if(ConfigurationManager.AppSettings["RunEnv"].ToString().ToLower() == "prod")
			{
				// we are in production see what type of logging we are doining
				if(ConfigurationManager.AppSettings["LoggingType"].ToString().ToLower() == "file")
				{
					string strFile = ConfigurationManager.AppSettings["LoggingFileLoc"].ToString();
					if(!File.Exists(strFile))
						File.Create(strFile);
					
					using (StreamWriter w = File.AppendText(strFile))
			        {
						w.WriteLine("");
						w.WriteLine("======================================================================");
						w.WriteLine(" " + DateTime.Now.ToString());
						w.WriteLine("Error Message: " + ex.Message);
						w.WriteLine("Error Type: " + ex.GetType().ToString());
						w.WriteLine("Error Dump: " + ex.ToString());
			            w.Close();
			        }					
				}
			}
			// and of course always rethrow the error
			throw ex;
		}
		
		public static void LogError(string strLog)
		{
			// see if we are in development
			if(ConfigurationManager.AppSettings["RunEnv"].ToString().ToLower() == "dev")
			{
				// for development just write to the counsol
				System.Diagnostics.Debug.WriteLine(strLog);
			}
			else if(ConfigurationManager.AppSettings["RunEnv"].ToString().ToLower() == "prod")
			{
				// we are in production see what type of logging we are doining
				if(ConfigurationManager.AppSettings["LoggingType"].ToString().ToLower() == "file")
				{
					string strFile = ConfigurationManager.AppSettings["LoggingFileLoc"].ToString();
					if(!File.Exists(strFile))
						File.Create(strFile);
					
					using (StreamWriter w = File.AppendText(strFile))
			        {
						w.WriteLine("");
						w.WriteLine("======================================================================");
						w.WriteLine(" " + DateTime.Now.ToString());
						w.WriteLine("Message: " + strLog);
			            w.Close();
			        }					
				}
			}
		}
		
		#endregion "ErrorLoging"
	}
}
