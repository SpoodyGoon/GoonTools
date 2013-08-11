//
//  StartupOptions.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GUPdotNET.Data
{
	using System;

	public class StartupOptions
	{
		public RunType UpdateRunType{ get; set; }

		public bool RunSilent{ get; set; }

		public bool SuppressErrors{ get; set; }

		public StartupOptions()
		{
			this.UpdateRunType = RunType.BackgroundCheck;
			this.RunSilent = true;
			this.SuppressErrors = true;
		}
	}
}

