//      ProgramAttributes.cs
//
//      Author:
//           Andy York <goontools@brdstudio.net>
//
//      Copyright (c) 2013 Andy York
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

namespace libMonoTools.Data.Generic
{
	using System.Reflection;
	
	/// <summary>
	/// A class to reference data used globally about YahtzeeSharp.
	/// </summary>
	public class ApplicationAttributes
	{
		/// <summary>
		/// Gets or sets the title to be used for the application.
		/// </summary>
		public string Title{get; private set;}
		
		/// <summary>
		/// Gets or sets the description to be used for the application.
		/// </summary>
		public string Description{get; private set;}
		
		/// <summary>
		/// Gets or sets the copy right to be used for the application.
		/// </summary>
		public string CopyRight{get; private set;}
		
		/// <summary>
		/// Gets or sets the company to be used for the application.
		/// </summary>
		public string Company{get; private set;}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="libMonoTools.Data.Generic.ApplicationAttributes"/> class.
		/// </summary>
		/// <param name="programAssembly">Assembly to get the data from.</param>
		public ApplicationAttributes(Assembly programAssembly)
		{
			this.Title = (programAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute).Title;
			this.Description = (programAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description;
			this.CopyRight = (programAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute).Copyright;
			this.Company = (programAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0] as AssemblyCompanyAttribute).Company;
		}
	}
}

