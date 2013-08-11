/*************************************************************************
 *                      CheckSum.cs
 *
 * 		Copyright (C) Date: 1/3/2010 - Time: 7:23 PM
 *		User: Andy - <goontools@brdstudio.net>
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

/*
 * Portions of this class were taken from a code project article by Dariush Tasdighi
 * URL: http://www.codeproject.com/KB/files/dt_file_hasher.aspx
 * which is covered under the MIT licence: http://www.opensource.org/licenses/mit-license.php
 * if you have any questions or comments about the use of this code please contact the this project owner
 */

using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace GoonTools.Helper
{
	/// <summary>
	/// Description of CheckSum.
	/// </summary>
	internal class CheckSumUtility
	{
		#region Variable Declaration
		
		// path to the file that is being checked
		private string _FilePath = null;
		// a string representing the checksum to validate the input file
		private string _ValidatingCheckSum = null;
		// what type of cryptology are we checking
		private CheckSumType _CurrentCheckSumType = CheckSumType.MD5;
		
		#endregion Variable Declaration
		
		#region Constructors
		
		// default constructor
		
		internal CheckSumUtility()
		{
		}
		
		internal CheckSumUtility(string filepath)
		{
			_FilePath = filepath;
		}

		internal CheckSumUtility(string validatingchecksum, string filepath)
		{
			_ValidatingCheckSum = validatingchecksum;
			_FilePath = filepath;
		}

		internal CheckSumUtility(string validatingchecksum, string filepath, CheckSumType currchecksumtype)
		{
			_ValidatingCheckSum = validatingchecksum;
			_FilePath = filepath;
			_CurrentCheckSumType = currchecksumtype;
		}
		
		#endregion Constructors
		
		#region public properties
		
		internal string FilePath
		{
			set{_FilePath=value;}
			get{return _FilePath;}
		}
		
		internal string ValidatingCheckSum
		{
			set{_ValidatingCheckSum=value;}
			get{return _ValidatingCheckSum;}
		}
		
		internal CheckSumType CurrentCheckSumType
		{
			set{_CurrentCheckSumType=value;}
			get{return _CurrentCheckSumType;}
		}
		
		#endregion public properties
		
		internal string GetCheckSum()
		{
			switch(_CurrentCheckSumType)
			{
				case CheckSumType.MD5:
					MD5CryptoServiceProvider cryMD5 = new MD5CryptoServiceProvider();
					return System.BitConverter.ToString(cryMD5.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA1:
					SHA1CryptoServiceProvider crySHA1 = new SHA1CryptoServiceProvider();
					return System.BitConverter.ToString(crySHA1.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA256:
					SHA256 crySHA256 = SHA256.Create();
					return System.BitConverter.ToString(crySHA256.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA384:
					SHA384 crySHA384 = SHA384.Create();
					return System.BitConverter.ToString(crySHA384.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA512:
					SHA512 crySHA512 = SHA512.Create();
					return System.BitConverter.ToString(crySHA512.ComputeHash(GetFileStream(_FilePath)));
			}
			return null;
		}
		
		internal bool ValidateFile()
		{
			switch(_CurrentCheckSumType)
			{
				case CheckSumType.MD5:
					MD5CryptoServiceProvider cryMD5 = new MD5CryptoServiceProvider();
					return CompareCheckSum(Encoding.UTF8.GetBytes(_ValidatingCheckSum), cryMD5.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA1:
					SHA1CryptoServiceProvider crySHA1 = new SHA1CryptoServiceProvider();
					return CompareCheckSum(Encoding.UTF8.GetBytes(_ValidatingCheckSum), crySHA1.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA256:
					SHA256 crySHA256 = SHA256.Create();
					return CompareCheckSum(Encoding.UTF8.GetBytes(_ValidatingCheckSum), crySHA256.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA384:
					SHA384 crySHA384 = SHA384.Create();
					return CompareCheckSum(Encoding.UTF8.GetBytes(_ValidatingCheckSum), crySHA384.ComputeHash(GetFileStream(_FilePath)));
				case CheckSumType.SHA512:
					SHA512 crySHA512 = SHA512.Create();
					return CompareCheckSum(Encoding.UTF8.GetBytes(_ValidatingCheckSum), crySHA512.ComputeHash(GetFileStream(_FilePath)));
			}
			return false;
		}
		
		private bool CompareCheckSum(byte[] validate, byte[] file)
		{
			if (validate.Length != file.Length)
			{
				return false;
			}
			for (int i = 0; i < validate.Length; i++)
			{
				if (validate[i] != file[i])
				{
					return false;
				}
			}
			return true;
		}
		
		private FileStream GetFileStream(string file)
		{
			return(new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
		}
	}
}

namespace GoonTools
{	
		internal enum CheckSumType
		{
			MD5,
			SHA1,
			SHA256,
			SHA384,
			SHA512
		}
}
