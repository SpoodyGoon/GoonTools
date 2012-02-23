using System;
using System.IO;
using System.Data;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI
{
	public class ConnectionStore : Gtk.ListStore, Gtk.TreeModel
	{
        public bool IsLoaded = false;
        public DateTime LastLoaded = DateTime.Now;
		public ConnectionStore () : base(typeof(Connection))
		{
            
		}
		
		#region Public Methods
		
		public void Load()
        {
            try
            {
                FileInfo fi = new FileInfo(Path.Combine(Common.EnvData.UserDataPath, "Connections.xml"));
                if (fi.Exists)
                {
                    GlobalData.Connections cn = new GlobalData.Connections();
                    cn.ReadXml(fi.FullName);

                        Connection c;
                        foreach(DataRow dr in cn.Tables["Connections"].Rows)
                        {
                            c = new Connection(Convert.ToInt32(dr["ConnectionID"]), dr["ConnectionName"].ToString(), dr["FilePath"].ToString());
                            this.AppendValues(c);
                        }
                }
                IsLoaded = true;
                LastLoaded = DateTime.Now;
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
        }

        public void Refresh()
        {
            Load();
        }
		
		
		#endregion Public Methods
	}
}

