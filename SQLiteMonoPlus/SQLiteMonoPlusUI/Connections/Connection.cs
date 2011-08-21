using System;
using Mono.Data.Sqlite;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI
{
	public class Connection
	{
        public Nullable<int> ConnectionID = null;
		public string ConnectionName = string.Empty;
		public string FilePath = string.Empty;
		public string Password = null;
		public bool Pooling = false;
		public int MaxPoolSize = 0;
        public DateTime AddedDate = DateTime.Now;
        public DateTime LastUsedDate = DateTime.Now;

        public Connection(string name, string path, string password)
        {
            ConnectionName = name;
            FilePath = path;
        }

        public Connection(string name, string path)
        {
            ConnectionName = name;
            FilePath = path;
        }
		
		public Connection (int id, string name, string path) 
		{
            ConnectionID = id;
			ConnectionName = name;
			FilePath = path;
		}

        public Connection(int id, string name, string path, string password) 
		{
			ConnectionName = name;
			FilePath = path;
			Password = password;
		}

        public Connection(int id, string name, string path, bool pooling, int maxpoolsize) 
		{
			ConnectionName = name;
			FilePath = path;
			Pooling = pooling;
			MaxPoolSize = maxpoolsize;
		}

        public Connection(int id, string name, string path, string password, bool pooling, int maxpoolsize) 
		{
			ConnectionName = name;
			FilePath = path;
			Password = password;
			Pooling = pooling;
			MaxPoolSize = maxpoolsize;
		}

        ~Connection() { }

        public void Add()
        {
            SqliteConnection sqlCN = new SqliteConnection(UserConfig.Default.DBLocation);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.ConnectionAdd, sqlCN);
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            try
            {
                sqlCN.Open();
                sqlCMD.Parameters.AddWithValue("@ConnectionName", ConnectionName);
                sqlCMD.Parameters.AddWithValue("@FilePath", FilePath);
                sqlCMD.Parameters.AddWithValue("@Password", Password);
                sqlCMD.Parameters.AddWithValue("@Pooling", Pooling);
                sqlCMD.Parameters.AddWithValue("@MaxPoolSize", MaxPoolSize);
                ConnectionID = Convert.ToInt32(sqlCMD.ExecuteScalar());
                sqlCN.Close();
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
            finally
            {
                sqlCMD.Dispose();
                if (sqlCN.State != System.Data.ConnectionState.Closed)
                    sqlCN.Close();
                sqlCN.Dispose();
            }
        }

        public void Update()
        {
            SqliteConnection sqlCN = new SqliteConnection(UserConfig.Default.DBLocation);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.ConnectionUpdate, sqlCN);
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            try
            {
                sqlCN.Open();
                sqlCMD.Parameters.AddWithValue("@ConnectionID", ConnectionID);
                sqlCMD.Parameters.AddWithValue("@ConnectionName", ConnectionName);
                sqlCMD.Parameters.AddWithValue("@FilePath", FilePath);
                sqlCMD.Parameters.AddWithValue("@Password", Password);
                sqlCMD.Parameters.AddWithValue("@Pooling", Pooling);
                sqlCMD.Parameters.AddWithValue("@MaxPoolSize", MaxPoolSize);
                sqlCMD.ExecuteNonQuery();
                sqlCN.Close();
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
            finally
            {
                sqlCMD.Dispose();
                if (sqlCN.State != System.Data.ConnectionState.Closed)
                    sqlCN.Close();
                sqlCN.Dispose();
            }
			
        }

        public void Delete()
        {
            SqliteConnection sqlCN = new SqliteConnection(UserConfig.Default.DBLocation);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.ConnectionDelete, sqlCN);
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            try
            {
                sqlCN.Open();
                sqlCMD.Parameters.AddWithValue("@ConnectionID", ConnectionID);
                sqlCMD.ExecuteNonQuery();
                sqlCN.Close();
                // Refresh the Connection Store so it is current
                GlobalData.StoreModels.Connections.Refresh();
                
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
            finally
            {
                sqlCMD.Dispose();
                if (sqlCN.State != System.Data.ConnectionState.Closed)
                    sqlCN.Close();
                sqlCN.Dispose();
            }
			
        }
		
	}
}

