//
//  SQLiteHelper.cs
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
namespace libMonoTools.Data.SQLite
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using Mono.Data.SqliteClient;

    /// <summary>
    /// Collections of methods to help interact with SQLite.
    /// </summary>
    public class SqliteHelper
    {
        /// <summary>
        /// The connection string format.
        /// </summary>
        private const string ConnectionStringFormat = "URI=file:{0},version=3, busy_timeout=300";

        /// <summary>
        /// Gets the connection string for the file passed in when the class is initializes.
        /// </summary>
        /// <value>The connection string for the database currently being used.</value>
        public string ConnectionString{ get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="libMonoTools.Data.SQLite.SqliteHelper"/> class.
        /// </summary>
        /// <param name="databaseFilePath">Database file path currently being used.</param>
        public SqliteHelper(string databaseFilePath)
        {
            this.ConnectionString = string.Format(ConnectionStringFormat, databaseFilePath); 
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <returns>The non query.</returns>
        /// <param name="commandText">Command text.</param>
        /// <param name="commandParameters">Command parameters.</param>
        public int ExecuteNonQuery(string commandText, params IDataParameter[] commandParameters)
        {
            int nonQueryResult = -1;
            using(SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using(SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {           
                    if(commandParameters != null)
                    {
                        foreach(IDataParameter p in commandParameters)
                        {
                            sqlCMD.Parameters.Add(p);
                        }
                    }
                
                    nonQueryResult = sqlCMD.ExecuteNonQuery();
                }
                sqlCN.Close();
            }
            return nonQueryResult;
        }
        
        public IDataReader ExecuteReader(string commandText, params IDataParameter[] commandParameters)
        {
            SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString);
            sqlCN.Open();            
            try
            {
                using(SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {
                    
                    if(commandParameters != null)
                    {
                        foreach(IDataParameter p in commandParameters)
                        {
                            sqlCMD.Parameters.Add(p);
                        }
                    }
                    
                    return sqlCMD.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch
            {
                // we only want to close teh connection if there is an error
                // that has occured, otherwize the connection will be closed in 
                // the calling code.
                if(sqlCN.State == ConnectionState.Open)
                {
                    sqlCN.Close();
                }
                throw;
            }
        }
        
        public object ExecuteScalar(string commandText, params IDataParameter[] commandParameters)
        {
            using(SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using(SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {                    
                    if(commandParameters != null)
                    {
                        foreach(IDataParameter p in commandParameters)
                        {
                            sqlCMD.Parameters.Add(p);
                        }
                    }
                    
                    return sqlCMD.ExecuteScalar();
                }
            }
        }

        public DataSet ExecuteDataset(string commandText, params IDataParameter[] commandParameters)
        {
            return this.ExecuteDataset("NewDataSet", commandText, commandParameters);
        }
        
        public DataSet ExecuteDataset(string dataSetName, string commandText, params IDataParameter[] commandParameters)
        {
            DataSet dataSet = new DataSet(dataSetName);
            using(SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using(SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {
                    if(commandParameters != null)
                    {
                        foreach(IDataParameter p in commandParameters)
                        {
                            sqlCMD.Parameters.Add(p);
                        }
                    }
                    
                    using(SqliteDataAdapter adapter = new SqliteDataAdapter(sqlCMD))
                    {
                        adapter.Fill(dataSet);
                    }

                }
                sqlCN.Close();
            }
            return dataSet;
        }

        public DataTable ExecuteDataTable(string commandText, params IDataParameter[] commandParameters)
        {
            return this.ExecuteDataTable("NewTable", commandText, commandParameters); 
        }
        
        public DataTable ExecuteDataTable(string tableName, string commandText, params IDataParameter[] commandParameters)
        {
            DataTable dataTable = new DataTable(tableName);
            using(SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using(SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {
                    if(commandParameters != null)
                    {
                        foreach(IDataParameter p in commandParameters)
                        {
                            sqlCMD.Parameters.Add(p);
                        }
                    }
                    
                    using(SqliteDataAdapter sqlDA = new SqliteDataAdapter(sqlCMD))
                    {
                        sqlDA.Fill(dataTable); 
                    }
                }
                sqlCN.Close();
            }                   
            return dataTable;
        }

        public bool Exists(string commandText, params IDataParameter[] commandParameters)
        {
            bool rowExists = true;            
            using(SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using(SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {                    
                    if(commandParameters != null)
                    {
                        foreach(IDataParameter p in commandParameters)
                        {
                            sqlCMD.Parameters.Add(p);
                        }
                    }
                    
                    using(SqliteDataReader sqlReader = sqlCMD.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if(sqlReader.HasRows)
                        {
                            rowExists = true;
                        }
                        else
                        {
                            rowExists = false;
                        }
                        sqlReader.Close();
                    }
                }
                sqlCN.Close();
            }
            return rowExists;
        }
    }
}

