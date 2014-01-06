// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorLogWriter.cs" company="Andy York">
//
// Copyright (C) 2013 Andy York
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Email: goontools@brdstudio.net
// Author: Andy York 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MonoTools.ErrorManager
{
    using System;
    using System.IO;

    /// <summary>
    /// Helper class for writing error logs.
    /// </summary>
    internal class ErrorLogWriter
    {
        /// <summary>
        /// The format for writing error logs.
        /// </summary>
        private const string ErrorMessageFormat = "Date/Time:\n{0}\nMessage:\n{1}\nTrace:\n{2}\n------------------------------------\n\n";
        
        /// <summary>
        /// Default error log size in megabites.
        /// </summary>
        private const int DefaultMaxLogSize = 100;

        /// <summary>
        /// Method for writing error logs.
        /// </summary>
        /// <param name="filePath">Full path the error log is to be written to.</param>
        /// <param name="error">The error to be written to file.</param>
        internal static void WriteLog(string filePath, Exception error)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(string.Format(ErrorMessageFormat, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), error.Message, error.ToString()));
            }
        }
    }
}