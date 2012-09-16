using System;
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using sc = System.Configuration;

namespace GlobalTools
{
    /// <summary>
    /// This class contains basic navigation functionality and some
    /// commonly used functions related to folder navigation and/or manipulation
    /// </summary>
    public class LocalSystemTools
    {
        public string AppPath;
        public string AppDBFile;
        public string AppDataPath;
        public string AppDBConnectionString;
        public string ProgramName;
        public string ErrorLogFile;
        public bool DebugMode = false;
        public LocalSystemTools()
        {
            so.FileInfo fi;
            so.DirectoryInfo di;
            sr.Assembly asm = sr.Assembly.GetExecutingAssembly();

            // set the app path
            fi = new so.FileInfo(asm.Location);
            AppPath = fi.Directory.FullName;
            ProgramName = asm.GetName().Name;
            DebugMode = Convert.ToBoolean(sc.ConfigurationManager.AppSettings["DebugMode"].ToString().Trim());

            // path to where the application keeps its data
            di = new so.DirectoryInfo(so.Path.Combine(AppPath, "Data"));
            AppDataPath = di.FullName;
            if (!di.Exists)
                di.Create();

            // path to the error log
            ErrorLogFile = so.Path.Combine(AppDataPath, "ErrorLog.txt");
            // location of the database for the applciation
            fi = new so.FileInfo(so.Path.Combine(AppDataPath, "DatabaseBuilder.s3db"));
            AppDBFile = fi.FullName;
            AppDBConnectionString = @"URI=file:C:\Temp\DatabaseBuilder.s3db, version=3, busy_timeout=300";
            //AppDBConnectionString = Constants.SVNScanSQL.ConnStringFormat.Replace("[FilePath]", fi.FullName);
        }

        #region Temp File/Folder Functions

        internal string GetNewTempFolder(string Name)
        {
            return GetNewTempFolder(Name, true);
        }

        internal string GetNewTempFolder(string Name, bool Overwrite)
        {
            string tmpName = so.Path.Combine(so.Path.GetTempPath(), Name);
            try
            {
                if (Overwrite)
                {
                    if (so.Directory.Exists(tmpName))
                        so.Directory.Delete(tmpName);

                    so.Directory.CreateDirectory(tmpName);
                }
                else
                {
                    string tmp = tmpName;
                    int i = 0;
                    while (so.Directory.Exists(tmp))
                    {
                        tmp = tmpName + i.ToString();
                        i++;
                    }
                    so.Directory.CreateDirectory(tmp);
                    tmpName = tmp;
                }
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
            return tmpName;
        }

        internal string GetNewTempFile(string Name)
        {
            return GetNewTempFile(so.Path.GetFileNameWithoutExtension(Name), so.Path.GetExtension(Name), true);
        }

        internal string GetNewTempFile(string Name, string Extension)
        {
            return GetNewTempFile(Name, Extension, true);
        }

        internal string GetNewTempFile(string Name, string Extension, bool Overwrite)
        {
            string tmpName = so.Path.Combine(System.IO.Path.GetTempPath(), Name + "." + Extension);
            if (Overwrite)
            {
                if (so.File.Exists(tmpName))
                    so.File.Delete(tmpName);

                so.File.Create(tmpName);
            }
            else
            {
                string tmp = tmpName;
                int i = 0;
                while (so.File.Exists(tmp))
                {
                    tmp = tmpName + i.ToString();
                    i++;
                }
                so.File.Create(tmp);
                tmpName = tmp;
            }
            return tmpName;
        }

        internal void ClearDirectory(string strPath)
        {
            so.DirectoryInfo di = new so.DirectoryInfo(strPath);
            so.DirectoryInfo[] diTmp = di.GetDirectories();
            if (diTmp.Length > 0)
            {
                for (int i = 0; i < diTmp.Length; i++)
                {
                    diTmp[i].Delete(true);
                }
            }

            so.FileInfo[] fi = di.GetFiles();
            if (fi.Length > 0)
            {
                for (int i = 0; i < fi.Length; i++)
                {
                    fi[i].Delete();
                }
            }
        }

        internal void TextFileDump(string strText, string strPath)
        {
            if (so.File.Exists(strPath))
                throw new FieldAccessException("File already exists: " + strPath);

            using (so.StreamWriter sw = new so.StreamWriter(strPath, false, System.Text.Encoding.UTF8))
            {
                sw.Write(strText);
            }
        }

        #endregion Temp File/Folder Functions

        #region Launch URL

        private string _LaunchURL = string.Empty;
        internal void LaunchURL(string URL)
        {
            _LaunchURL = URL;
            System.Threading.Thread trd = new System.Threading.Thread(new System.Threading.ThreadStart(StartURL));
            trd.Start();
        }

        private void StartURL()
        {
            System.Diagnostics.Process.Start(_LaunchURL);
        }

        #endregion Launch URL
    }

}
