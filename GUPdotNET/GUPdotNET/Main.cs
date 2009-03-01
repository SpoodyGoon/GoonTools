/*************************************************************************
 *                      Main.cs                                     
 *                                                                       
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>         
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
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			
			UpdateCheck uc = new UpdateCheck();
			// if there are no arguments then we are using the
			// app config file
			if(args.Length == 0)
			{
				uc.InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
				uc.ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
				uc.UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
				uc.CurrentMajorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMajorVersion"].ToString());
				uc.CurrentMinorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMinorVersion"].ToString());
				uc.SilentCheck = Convert.ToBoolean(ConfigurationManager.AppSettings["SilentCheck"].ToString());
				uc.CallingApplication = ConfigurationManager.AppSettings["CallingApplication"].ToString();
				
			}
			else
			{
				uc.InstallType = args[0].ToString();
				uc.ProgramName = args[0].ToString();
				uc.UpdateInfoURL = args[0].ToString();
				uc.CurrentMajorVersion = Convert.ToInt32(args[0].ToString());
				uc.CurrentMinorVersion = Convert.ToInt32(args[0].ToString());
				uc.SilentCheck = Convert.ToBoolean(args[0].ToString());
				uc.CallingApplication = args[0].ToString();
			}
			uc.RunCheck();
			
			Application.Run ();
			
		}
	}
}