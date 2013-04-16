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
    using System.Collections.Generic;
    using System.Data;
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
        /// Initializes a new instance of the <see cref="libMonoTools.Data.SQLite.SqliteHelper"/> class.
        /// </summary>
        /// <param name="databaseFilePath">Database file path currently being used.</param>
        public SqliteHelper(string databaseFilePath)
        {
            this.ConnectionString = string.Format(ConnectionStringFormat, databaseFilePath); 
        }
        
        /// <summary>
        /// Gets the connection string for the file passed in when the class is initializes.
        /// </summary>
        /// <value>The connection string for the database currently being used.</value>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <returns>The non query.</returns>
        /// <param name="commandText">Command text for the sql statement.</param>
        /// <param name="commandParameters">Command parameters for the sql statement.</param>
        public int ExecuteNonQuery(string commandText, Dictionary<string, object> commandParameters)
        {
            int nonQueryResult = -1;
            using (SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using (SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {           
                    if (commandParameters != null)
                    {
                        foreach (KeyValuePair<string,object> parameter in commandParameters)
                        {
                            sqlCMD.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                        }
                    }
                
                    nonQueryResult = sqlCMD.ExecuteNonQuery();
                }

                sqlCN.Close();
            }

            return nonQueryResult;
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <returns>The reader.</returns>
        /// <param name="commandText">Command text.</param>
        /// <param name="commandParameters">Command parameters.</param>
        public IDataReader ExecuteReader(string commandText, Dictionary<string, object> commandParameters)
        {
            SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString);
            sqlCN.Open();            
            try
            {
                using (SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {   
                    if (commandParameters != null)
                    {
                        foreach (KeyValuePair<string,object> parameter in commandParameters)
                        {
                            sqlCMD.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
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
                if (sqlCN.State == ConnectionState.Open)
                {
                    sqlCN.Close();
                }

                throw;
            }
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <returns>The scalar.</returns>
        /// <param name="commandText">Command text.</param>
        /// <param name="commandParameters">Command parameters.</param>
        public object ExecuteScalar(string commandText, Dictionary<string, object> commandParameters)
        {
            using (SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using (SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {                    
                    if (commandParameters != null)
                    {
                        foreach (KeyValuePair<string,object> parameter in commandParameters)
                        {
                            sqlCMD.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                        }
                    }
                    
                    return sqlCMD.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Returns a data set based on the command text and parameters.
        /// </summary>
        /// <returns>A data set based on the command text.</returns>
        /// <param name="commandText">Command text for the sql statement.</param>
        /// <param name="commandParameters">Command parameters for the sql statement.</param>
        public DataSet ExecuteDataset(string commandText, Dictionary<string, object> commandParameters)
        {
            return this.ExecuteDataset("NewDataSet", commandText, commandParameters);
        }

        /// <summary>
        /// Returns a data set based on the command text and parameters.
        /// </summary>
        /// <returns>A data set based on the command text.</returns>
        /// <param name="dataSetName">Optional name for the data set.</param>
        /// <param name="commandText">Command text for the sql statement.</param>
        /// <param name="commandParameters">Command parameters for the sql statement.</param>
        public DataSet ExecuteDataset(string dataSetName, string commandText, Dictionary<string, object> commandParameters)
        {
            DataSet dataSet = new DataSet(dataSetName);
            using (SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using (SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {
                    if (commandParameters != null)
                    {
                        foreach (KeyValuePair<string,object> parameter in commandParameters)
                        {
                            sqlCMD.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                        }
                    }
                    
                    using (SqliteDataAdapter adapter = new SqliteDataAdapter(sqlCMD))
                    {
                        adapter.Fill(dataSet);
                    }
                }

                sqlCN.Close();
            }

            return dataSet;
        }

        /// <summary>
        /// Returns a data table based on the command text and parameters.
        /// </summary>
        /// <returns>The data table.</returns>
        /// <param name="commandText">Command text for the sql statement.</param>
        /// <param name="commandParameters">Command parameters for the sql statement.</param>
        public DataTable ExecuteDataTable(string commandText, Dictionary<string, object> commandParameters)
        {
            return this.ExecuteDataTable("NewTable", commandText, commandParameters); 
        }

        /// <summary>
        /// Returns a data table based on the command text and parameters.
        /// </summary>
        /// <returns>A data table.</returns>
        /// <param name="tableName">Optional name for the data table.</param>
        /// <param name="commandText">Command text for the sql statement.</param>
        /// <param name="commandParameters">Command parameters for the sql statement.</param>
        public DataTable ExecuteDataTable(string tableName, string commandText, Dictionary<string, object> commandParameters)
        {
            DataTable dataTable = new DataTable(tableName);
            using (SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using (SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {
                    if (commandParameters != null)
                    {
                        foreach (KeyValuePair<string,object> parameter in commandParameters)
                        {
                            sqlCMD.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                        }
                    }
                    
                    using (SqliteDataAdapter sqlDA = new SqliteDataAdapter(sqlCMD))
                    {
                        sqlDA.Fill(dataTable); 
                    }
                }

                sqlCN.Close();
            }     

            return dataTable;
        }

        /// <summary>
        /// Quick and dirty method to see if a value exist in a table(s) and/or a view(s).
        /// </summary>
        /// <param name="commandText">Command text for the sql statement.</param>
        /// <param name="commandParameters">Command parameters for the sql statement.</param>
        public bool Exists(string commandText, Dictionary<string, object> commandParameters)
        {
            bool rowExists = true;            
            using (SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString))
            {
                sqlCN.Open();
                using (SqliteCommand sqlCMD = new SqliteCommand(commandText, sqlCN))
                {                    
                    if (commandParameters != null)
                    {
                        foreach (KeyValuePair<string,object> parameter in commandParameters)
                        {
                            sqlCMD.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                        }
                    }
                    
                    using (SqliteDataReader sqlReader = sqlCMD.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (sqlReader.HasRows)
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