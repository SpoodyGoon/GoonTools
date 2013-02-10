//
//  NameValueSerialize.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
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
using so = System.IO;
using st = System.Text;
using sc = System.Collections;
using scg = System.Collections.Generic;
using System.Linq;

namespace libMonoTools.IO
{
    public class NameValueSerialize
    { 
        #region Private Properties 

        private string _SaveFilePath = null;
        private string _SaveData = null;
        
        #endregion Private Properties

        #region Public Properties

        public string SaveFilePath {
            get{ return _SaveFilePath;}
            set{ _SaveFilePath = value;}
        }
        
        public string SaveData {
            get{ return _SaveData;}
            set{ _SaveData = value;}
        }
        #endregion Public Properties

        #region Constructors

        public NameValueSerialize()
        {
        }

        public NameValueSerialize(string SavePath, scg.Dictionary<string, object> DictionarySave)
        {
            _SaveFilePath = SavePath;
            int i = 0;
            int iCount = DictionarySave.Count;
            st.StringBuilder sb = new st.StringBuilder();
            foreach(scg.KeyValuePair<string, object> de in DictionarySave)
            {
                sb.Append(String.Format("{0}={1}{2}", de.Key, de.Value.ToString(), (i < iCount ? "|" : "")));
                i++;
            }
            _SaveData = sb.ToString();
            sb.Clear();
        }

        public NameValueSerialize(string SavePath, string StringSave)
        {
            _SaveFilePath = SavePath;
            _SaveData = StringSave;
        }

        public NameValueSerialize(string SavePath, sc.Hashtable HashSave)
        {
            _SaveFilePath = SavePath;
            int i = 0;
            int iCount = HashSave.Count;
            st.StringBuilder sb = new st.StringBuilder();
            foreach(sc.DictionaryEntry de in HashSave)
            {
                sb.Append(String.Format("{0}={1}{2}", de.Key, de.Value.ToString(), (i < iCount ? "|" : "")));
                i++;
            }
            _SaveData = sb.ToString();
            sb.Clear();
        }
        #endregion Constructors

        #region Load Methods

        public void Load(string LoadPath)
        {
            _SaveFilePath = LoadPath;
            Load();
        }

        public void Load()
        {
            try
            {
                so.FileInfo fi = new so.FileInfo(_SaveFilePath);
                
                if(string.IsNullOrEmpty(_SaveFilePath) || !fi.Exists)
                    throw new so.FileNotFoundException("Invalid or empty load path supplied, unable to load file.", _SaveFilePath);

                st.StringBuilder sb = new st.StringBuilder();
                using (so.StreamReader sr = new so.StreamReader(fi.FullName))
                {
                    sb.Append(sr.ReadToEnd());
                }
                _SaveData = sb.ToString();
                sb.Clear();

            }
            catch(Exception ex)
            {
                libMonoTools.ErrorTools.HandleError(ex);
            }
        }

        #endregion Load Methods

//        public scg.Dictionary<string, string> DictionaryGet()
//        {
//            var deserialized = new scg.Dictionary<string,string>(from pair in _SaveData.Split('|') let tokens = pair.Split('=') select new scg.KeyValuePair<string,string>(tokens[0],tokens[1]));
//            //scg.Dictionary<string, string> dic = _SaveData.Split('|').Select(s => s.Split('=')).ToDictionary(a => a[0].Trim(), a => a[1].Trim());
//            return (scg.Dictionary<string,string>)deserialized;
//        }

        #region Save Methods

        public void Save(string SavePath)
        {
            _SaveFilePath = SavePath;
            Save();
        }

        public void Save()
        {
            try
            {
                so.FileInfo fi = new so.FileInfo(_SaveFilePath);

                if(!fi.Directory.Exists)
                    throw new so.DirectoryNotFoundException("Unable to save file to directory, missing or invalid save path information." + System.Environment.NewLine + fi.Directory.FullName);

                if(string.IsNullOrEmpty(_SaveFilePath))
                    throw new so.FileNotFoundException("Invalid or empty save path supplied, unable to save file.", _SaveFilePath);

                if(string.IsNullOrEmpty(_SaveData))
                    throw new Exception("No save data was provide to save to file.");

                using (so.StreamWriter sw = new so.StreamWriter(fi.FullName))
                {
                    sw.Write(_SaveData);
                }
            }
            catch(Exception ex)
            {
                libMonoTools.ErrorTools.HandleError(ex);
            }
        }

        #endregion Save Methods
    }
}

