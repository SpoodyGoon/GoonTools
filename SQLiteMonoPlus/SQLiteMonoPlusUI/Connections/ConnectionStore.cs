using System;
using System.Data;
using Mono.Data.Sqlite;
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
            SqliteConnection sqlCN = new SqliteConnection(UserConfig.Default.DBLocation);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.ConnectionsGet, sqlCN);
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            SqliteDataReader sqlReader = null;
            try
            {
                sqlCN.Open();
                sqlReader = sqlCMD.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    Connection c;
                    while (sqlReader.Read())
                    {
                        c = new Connection(Convert.ToInt32(sqlReader["ConnectionID"]), sqlReader["ConnectionName"].ToString(), sqlReader["FilePath"].ToString());
                        this.AppendValues(c);
                    } 
                }
                sqlReader.Close();
                sqlCN.Close();
                IsLoaded = true;
                LastLoaded = DateTime.Now;
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
            finally
            {
                if (sqlReader != null)
                {
                    if (!sqlReader.IsClosed)
                        sqlReader.Close();
                    sqlReader.Dispose();
                }
                sqlCMD.Dispose();
                if (sqlCN.State != ConnectionState.Closed)
                    sqlCN.Close();
                sqlCN.Dispose();
            }
        }

        public void Refresh()
        {
            Load();
        }
		
		
		#endregion Public Methods
	}
}

