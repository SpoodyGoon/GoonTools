//
//  SimpleConfigFile.cs
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

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MonoTools.IO
{
    /// <summary>
    /// This class is for reading/writing very basic config data,
    /// nothing advanced here, it falls on the class calling SimpleConfigFile 
    /// to handle any null data, missing keys, or bad casting. 
    /// Best used for hobby related work that
    /// is not well defined ahead of time.
    /// </summary>
    public class SimpleConfigFile
    { 
        private const string OUTPUT = "{0}{1}{2}{3}";
        public string SaveFilePath{ get; private set; }
        public SimpleConfigDataItem DataItem{ get; private set; }
        private string[] nameValueSeperator = new string[] { "=" };

        public string[] NameValueSeperator
        { 
            get{ return this.nameValueSeperator;}
            set{ this.nameValueSeperator = value;}
        }

        private string[] nameValuePairSeperator = new string[] { "|" };

        public string[] NameValuePairSeperator
        { 
            get{ return this.nameValuePairSeperator;}
            set{ this.nameValuePairSeperator = value;}
        }

        public SimpleConfigFile()
        {
            this.DataItem = new SimpleConfigDataItem();
        }

        public void Save(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath,false))
            {
                foreach(KeyValuePair<string, string> pair in this.DataItem)
                {
                    writer.Write(string.Format(OUTPUT, pair.Key, this.nameValueSeperator[0], pair.Value, this.nameValuePairSeperator[0]));
                }
            }
        }

        public void Load(string filePath)
        {
            this.DataItem.Clear();
            string fileContents = string.Empty;
            if (File.Exists(filePath))
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    fileContents = reader.ReadToEnd();
                }
            }

            if(!string.IsNullOrEmpty(fileContents))
            {
                var dict = fileContents.Split(this.nameValuePairSeperator, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(this.nameValueSeperator, StringSplitOptions.RemoveEmptyEntries)).ToDictionary(a => a[0].Trim(), a => a[1].Trim());
                foreach (KeyValuePair<string, string> pair in dict)
                {
                    this.DataItem.Add(pair.Key, pair.Value);
                }
            }
        }
    }
}

