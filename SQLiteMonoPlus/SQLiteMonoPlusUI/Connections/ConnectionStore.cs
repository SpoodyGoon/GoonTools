using System;
using System.IO;
using System.Data;
using Gtk;
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
		
        private Connection ConnectionGet(int ID)
        {        	
        	_SearchConnection = null;
            _SearchID = ID;
            this.Foreach(new TreeModelForeachFunc(ForeachID));
            return _SearchConnection;
        }
        
		private int _SearchID = -1;
		private Connection _SearchConnection = null;
        private bool ForeachID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection cn = (Connection)this.GetValue(iter, 0);
            if (_SearchID == (int)cn.ConnectionID)
            {
                _SearchConnection = cn;
                return true;
            }
            return false;
        }
        

//        public Connection this[int index]
//        {
//            get
//            {
//                if (index < 0 || index >= Count)
//                    throw new ArgumentOutOfRangeException("index");
//
//                return (ForeignKey)_ForeignKeys[index];
//            }
//        }
		
		#endregion Public Methods
	}
}

