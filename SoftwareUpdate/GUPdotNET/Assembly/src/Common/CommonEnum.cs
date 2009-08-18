
/*************************************************************************
 *                      CommonEnum.cs
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

namespace GoonTools
{		
	public enum UpdateDateType
	{
		Day,
		Week,
		Month,
		Year,
		Never
	}
	
	
	public enum OperatingSystem
	{
		Windows,
		Linux,
		Mac,
		BSD,
		None // for initialization
	}
	
	
	public enum InstallType
	{
		Installer, // mostly with Windows and Mac 
		RPM, // Linux Pakage Installer
		DEB, // Linux Package Installer
		BIN, // Linux Binary
		TGZ, // Linux Slackware
		SRC,  // Generic Source
		None // for initialization
	}
}