#region "License"

// SQLiteDataProvider.cs
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

#endregion "License"

#region "Description"

// This class is a dataprovider for SQLite (http://sqlite.org/) a file and/or memory based database
// This class requires: 
//      + Mono .NET framework (http://www.mono-project.com)
 
#endregion "Description"


using System;
using System.IO;
using System.Data;
using System.Configuration;
using Gtk;
using System.ComponentModel;
using System.Collections;
using Mono.Data.SqliteClient;

namespace SQLiteDataProvider
{
	/// <summary>
	/// A dataprovider for SQLite and Mono .NET
	/// </summary>
	public class DataProvider
	{
		private string _ConnString = null;
		private int _TimeOut = 300;
		private string _ExceptionMessage = null;
        private ConnectionStringType _ConnStringType = ConnectionStringType.FromCallingCode;

		#region "Public Properties"
		
        /// <summary>
        ///  Sets of gets the connection time out
        /// </summary>
		public int TimeOut
		{
			set{ _TimeOut = value;}
			get{ return _TimeOut;}
		}
		
        /// <summary>
        ///  Sets or gets the connection string
        /// </summary>
		public string ConnString
		{
			set{ _ConnString = value;}
			get{ return _ConnString;}
		}
		
        /// <summary>
        ///  Returns and Exception message if needed
        /// </summary>
        public string ExceptionMessage
		{
            get { return _ExceptionMessage; }
        }

        /// <summary>
        /// Sets the connection string type
        /// </summary>
        public ConnectionStringType ConnStringType
        {
            set { _ConnStringType = value; }
        }

        #endregion "Public Properties"
        
		#region "Class Constructors"
		
		/// <summary>
        /// Base Class Constructor
        /// </summary>
		public DataProvider()
		{
			_ConnString = null;
			_TimeOut = 0;
			_ExceptionMessage = null;
		    _ConnStringType = ConnectionStringType.FromCallingCode;
		}
		
		/// <summary>
        ///  Class Constructor that specifies the connection string
        /// </summary>
        /// <param name="Conn"></param>
		public DataProvider(string Conn)
		{
			_ConnString = Conn;
		}
		
		/// <summary>
        /// Class Constructor that specifies the connection string
        /// and the connection string type
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="ConnType"></param>
        public DataProvider(string Conn, ConnectionStringType ConnType)
        {
            _ConnStringType = ConnType;
            _ConnString = Conn;
        }

        /// <summary>
        /// Class Constructor that specifies the connection string
        /// and the connection time out
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="TimeOut"></param>
        public DataProvider(string Conn, int TimeOut)
        {
            _TimeOut = TimeOut;
            _ConnString = Conn;
        }

        /// <summary>
        /// Class Constructor that specifies the connection string
        /// the connection time out and the connection string type
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="ConnType"></param>
        /// <param name="TimeOut"></param>
        public DataProvider(string Conn, ConnectionStringType ConnType, int TimeOut)
        {
            _TimeOut = TimeOut;
            _ConnStringType = ConnType;
            _ConnString = Conn;
        }
		
		public void Dispose()
		{
			
		}
		
		#endregion "Class Constructors"

		#region "Main Connection"
		
        /// <summary>
        ///  Creates a new database connection
        /// </summary>
        /// <returns></returns>
		private SqliteConnection GetConn()
        {
        	SqliteConnection sqlCN = null;
			try
			{
				// if the connection string is null
				// try to get the default from the config file
				if(_ConnStringType == ConnectionStringType.FromCallingCode)
				{
					sqlCN = new SqliteConnection(_ConnString);		
				}
				else
				{
                    sqlCN = new SqliteConnection(ConfigurationManager.AppSettings[_ConnString].ToString());				
				}
			}
			catch(Exception ex)
			{
                _ExceptionMessage = ex.ToString();
                throw new Exception(ex.ToString());
			}
			return sqlCN;
        }
		
		#endregion "Main Connection"
        
        #region "Boolean"
		
		/// <summary>
		///  Returns true if rows exist and false if they do not
        ///  Most likly to be used for quick security checks
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public bool ExecuteHasRows(string strSQL)
		{			
			bool blnHasRows = false;
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataReader sqlReader = null;
			try
			{
				sqlCN.Open();
				sqlReader = sqlCMD.ExecuteReader();
				blnHasRows = sqlReader.HasRows;
				sqlReader.Close();
				sqlCN.Close();
			}
			catch(Exception ex)
			{
                _ExceptionMessage = ex.ToString();
                throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlReader.Dispose();
			}
			return blnHasRows;
		}
		
		#endregion "Boolean"
		
		#region "Hashtable"
		
		/// <summary>
		///  use this ONLY when you are certain only on row will return
		///  this will parse out that single row into a hash table
		///  not for use with web services
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public Hashtable ExecuteHashTable(string strSQL)
		{
			Hashtable hshReturn = new Hashtable();
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataReader sqlReader = null;
			try
			{
				sqlCN.Open();
				sqlReader = sqlCMD.ExecuteReader();
				while(sqlReader.Read())
				{
					for(int i = 0; i < sqlReader.FieldCount; i++)
					{						
						hshReturn.Add(sqlReader.GetName(i).ToString(),sqlReader[i].ToString());
					}
				}
				sqlReader.Close();
				sqlCN.Close();
            }
            catch (Exception ex)
            {
                _ExceptionMessage = ex.ToString();
                throw new Exception(ex.ToString());
            }
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlReader.Dispose();
			}
			return hshReturn;
		}
		
		 #endregion "Hashtable"
		
		#region "Return Array Lists"
        
        /// <summary>
		///  Used to return only the first column
        ///  in an ArrayList
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public ArrayList ExecuteArrayList(string strSQL)
		{
			
			ArrayList arrReturn = new ArrayList();
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataReader sqlReader = null;
			try
			{	
				sqlCN.Open();
				sqlReader = sqlCMD.ExecuteReader();
				while(sqlReader.Read())
				{
					arrReturn.Add((object)sqlReader[0]);
				}
				sqlReader.Close();
				sqlCN.Close();
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlReader.Dispose();
			}
			return arrReturn;
		}
		
		/// <summary>
        /// Used to return only the named column
        /// in an ArrayList
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strColumnName"></param>
        /// <returns></returns>
		public ArrayList ExecuteArrayList(string strSQL, string strColumnName)
		{
			ArrayList arrReturn = new ArrayList();
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataReader sqlReader = null;
			try
			{	
				sqlCN.Open();
				sqlReader = sqlCMD.ExecuteReader();
				while(sqlReader.Read())
				{
					arrReturn.Add((object)sqlReader[strColumnName]);
				}
				sqlReader.Close();
				sqlCN.Close();
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlReader.Dispose();
			}
			return arrReturn;
		}
		
		#endregion "Return Array Lists"
		
		#region "Scalar and NonQuery"
		
		/// <summary>
        ///  Used to execute non-queries
        /// </summary>
        /// <param name="strSQL"></param>
		public void ExecuteNonQuery(string strSQL)
		{
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			try
			{	
				sqlCMD = new SqliteCommand(strSQL, sqlCN);
				sqlCMD.CommandType = CommandType.Text;
				sqlCN.Open();
				sqlCMD.ExecuteNonQuery();
				sqlCN.Close();
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
			}
		}
		
		/// <summary>
        ///  Executes Scalar when the last_insert_rowid statement
        ///  is already in the SQL string
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
		public string ExecuteScalar(string strSQL)
		{
			return ExecuteScalar(strSQL, false);
		}
		
		/// <summary>
        /// Executes Scalar when the last_insert_rowid statement
        ///  is not already in the SQL string
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="blnAddIdentityStatement"></param>
        /// <returns></returns>
		public string ExecuteScalar(string strSQL, bool blnAddIdentityStatement)
		{
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			string strReturn = null;
			try
			{	
				if(blnAddIdentityStatement == true)
					sqlCMD.CommandText += "SELECT last_insert_rowid();";			
			
				sqlCN.Open();
				strReturn = sqlCMD.ExecuteScalar().ToString();
				sqlCN.Close();
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
			}
			return strReturn;
		}
		
		#endregion "Scalar and NonQuery"
		
		#region "DataSets and DataTables"
		
		/// <summary>
        /// Returns a DataSet without naming it
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
		public DataSet ExecuteDataSet(string strSQL)
		{
			return ExecuteDataSet(strSQL, null);
		}
		
		/// <summary>
        ///  Returns a DataSet and sets it's name
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strDataSetName"></param>
        /// <returns></returns>
		public DataSet ExecuteDataSet(string strSQL, string strDataSetName)
		{
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataAdapter sqlDA = null;
			DataSet ds = new DataSet();
			try
			{	
				if(strDataSetName != null)
					ds.DataSetName = strDataSetName;
				else
					ds.DataSetName = "ds";			
			
				sqlDA = new SqliteDataAdapter(sqlCMD);
				sqlDA.Fill(ds);
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlDA.Dispose();
			}
			return ds;
		}
		
		/// <summary>
        /// Returns a DataTable without setting it's name
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
		public DataTable ExecuteDataTable(string strSQL)
		{
			return ExecuteDataTable(strSQL, null);
		}
		
		/// <summary>
        /// Returns a DataTable and sets it's name
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strDataTableName"></param>
        /// <returns></returns>
		public DataTable ExecuteDataTable(string strSQL, string strDataTableName)
		{
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataAdapter sqlDA = null;
			DataTable dt = new DataTable();
			try
			{				
				if(strDataTableName != null)
					dt.TableName = strDataTableName;
				else
					dt.TableName = "dt";
			
				sqlDA = new SqliteDataAdapter(sqlCMD);
				sqlDA.Fill(dt);
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlDA.Dispose();
			}
				return dt;
		}
		
		#endregion "DataSets and DataTables"
		
		#region "ListStore and TreeStore"
		/*
		 * Not too sure where the ListStore and the TreeStore are going or if they will work well
		 * I have had some problems with the data types not being correct
		 * in the calling code - but that could very well be a brain fart on my part
		 */
		public Gtk.ListStore ExecuteListStore(string strSQL)
		{
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataReader sqlReader = null;
			DataTable dtTypes = null;
			Gtk.ListStore ls;
			try
			{
				sqlCN.Open();
				sqlReader = sqlCMD.ExecuteReader();
				
				dtTypes = sqlReader.GetSchemaTable();
				// create our system types for the list store
				System.Type[] oType = new System.Type[dtTypes.Rows.Count];
				for(int i = 0; i < dtTypes.Rows.Count; i++)
				{
					oType[i] = typeof(string);
				}
				ls = new Gtk.ListStore(oType);
				
				while(sqlReader.Read())
				{
					ls.AppendValues(sqlReader[0].ToString(), sqlReader[1].ToString());
				}
				sqlReader.Close();
				sqlCN.Close();
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw new Exception(ex.ToString());
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				if(dtTypes.Rows.Count > 0)
					dtTypes.Clear();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlReader.Dispose();				
				dtTypes.Dispose();
			}
			return ls;
		}
		
		public Gtk.ListStore ExecuteListStore(string strSQL, string strName, string strValue)
		{
			SqliteConnection sqlCN = GetConn();
			SqliteCommand sqlCMD = new SqliteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SqliteDataReader sqlReader = null;
			Gtk.ListStore ls = new Gtk.ListStore(typeof(string), typeof(string));
			try
			{
				sqlCN.Open();
				sqlReader = sqlCMD.ExecuteReader();				
				while(sqlReader.Read())
				{
					ls.AppendValues(sqlReader[strValue].ToString(), sqlReader[strName].ToString());
				}
				sqlReader.Close();
				sqlCN.Close();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, doh.ToString());
				md.Run();
				md.Destroy();;
				
			}
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlReader.Dispose();
			}
			return ls;
		}
		
		public Gtk.TreeStore ExecuteTreeStore()
		{
			Gtk.TreeStore ts = new Gtk.TreeStore(typeof(string), typeof(string));
			return ts;			
		}
		
		#endregion "ListStore and TreeStore"
		
	}

    /// <summary>
    ///  Enumeration to restrict the connection type
    /// </summary>
    public enum ConnectionStringType
    {
        /// <summary>
        /// Connection string is located in the App and/or Web config file
        /// </summary>
        FromConfigFile,
        /// <summary>
        /// The entire connection string has been passed in by the calling code
        /// </summary>
        FromCallingCode
    }
}
