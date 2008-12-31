/*
 * Created by SharpDevelop.
 * User: Andrew York
 * Date: 3/1/2008
 * Time: 4:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Collections;

namespace Global
{
	/// <summary>
	/// Description of clsOptions.
	/// </summary>
	public class Options
	{
		//this is our hashtable variable, a global one.
		private static Hashtable hshOptions = new Hashtable (); 
		private static bool blnIsLoaded = false;
		public Options()
		{
		}
		
		
        public static string GetOption(string strKey)
        {
            if(hshOptions.ContainsKey(strKey))
                return (string)hshOptions[strKey];
            else
                return string.Empty;
        }

        public static void SetOption(string strKey, string strValue)
        {
            if(!hshOptions.ContainsKey(strKey))
                hshOptions.Add(strKey, strValue);
			else
				hshOptions[strKey] = strValue;
        }
        
		//this method serialize the hashtable into a binary file, 
		//we have a load function to load that exact saved file
		public static void Save()
		{
			//file stream states the saved binary
			FileStream fs = new FileStream (Common.GetWorkingFolder() + "Options.dat",FileMode.OpenOrCreate ,FileAccess.Write );
			try
			{
				Hashtable a = new Hashtable();
				a = hshOptions;
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf=new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();
				//as easy as 1,2,3...we serialize a to a binary formating using file stream.
				bf.Serialize (fs,a );
				fs.Close ();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
		

		//A method to load saved binary file
		public static void Load()
		{   	
			try
			{
				// clear the hash table to start fresh
				hshOptions.Clear();
				if(!File.Exists(Common.GetWorkingFolder() + "Options.dat"))
				{
					hshOptions.Add(" ", " ");
					Save();
				}
				   
				FileStream fs = new FileStream (Common.GetWorkingFolder() + "Options.dat",FileMode.Open ,FileAccess.Read );				
				Hashtable a = new Hashtable();
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

				//here we deserialize the binary to a hashtable
				a=(Hashtable)bf.Deserialize (fs);
				hshOptions = a;
				fs.Close ();
				
			}
			catch(Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
	}
}
