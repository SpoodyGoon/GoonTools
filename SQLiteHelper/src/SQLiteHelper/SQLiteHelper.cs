#region Copyright/License

/*
                     	SQLiteHelp.cs
 
 	 		Copyright (C) 2010
		Andrew York <goontools@brdstudio.net>
		
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.
	
	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.
	
	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.

 */

#endregion Copyright/License

#region "Description"

// This class is a dataprovider for SQLite (http://sqlite.org/) a file and/or memory based database
// This class requires:
//      + Mono .NET framework (http://www.mono-project.com)
//	+ SQLite version 3

#endregion "Description"


using System;
using so = System.IO;
using sd = System.Data;
using sc = System.Collections;
using mds = Mono.Data.SqliteClient;

namespace GoonTools
{
	/// <summary>
	/// A dataprovider for SQLite and Mono .NET
	/// </summary>
	public class SQLiteHelper
	{
		#region Private Properties

		private string _DatabaseURL = null;
		private int _TimeOut = 500;
		private int _BusyTimeout = 500;
		private int _LockedDBSleep = 500;
		private string _ExceptionMessage = null;
		private mds.SqliteConnection _SQLiteCN = null;
		private mds.SqliteCommand _SQLiteCMD = null;
		private mds.SqliteTransaction _SQLiteTrans = null;
		private mds.SqliteDataReader _SQLiteReader = null;
		
		#endregion Private Properties
		
		#region Public Properties
		
		/// <summary>
		///  Sets of gets the connection busy time out
		/// </summary>
		public int BusyTimeout
		{
			set{ _BusyTimeout = value;}
			get{ return _BusyTimeout;}
		}
		
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
		public string DatabaseURL
		{
			set{ _DatabaseURL = value;}
			get{ return _DatabaseURL;}
		}
		
		/// <summary>
		///  Returns and Exception message if needed
		/// </summary>
		public string ExceptionMessage
		{
			get { return _ExceptionMessage; }
		}

		#endregion Public Properties
		
		#region Class Constructors
		
		/// <summary>
		/// Base Class Constructor
		/// </summary>
		public SQLiteHelper()
		{
			_DatabaseURL = null;
			_TimeOut = 0;
			_ExceptionMessage = null;
		}
		
		/// <summary>
		///  Class Constructor that specifies the connection string
		/// </summary>
		/// <param name="Conn"></param>
		public SQLiteHelper(string dbURL)
		{
			_DatabaseURL = dbURL;
		}
		
		/// <summary>
		/// Class Constructor that specifies the connection string
		/// and the connection time out
		/// </summary>
		/// <param name="dbURL">Location of the database</param>
		/// <param name="TimeOut">Lenght of time out in milli-second</param>
		public SQLiteHelper(string dbURL, int TimeOut)
		{
			_TimeOut = TimeOut;
			_DatabaseURL = dbURL;
		}
		
		/// <summary>
		///  A dummmy dispose with no real purpose in life.
		///  It's a sad Dispose()... nobody love it
		/// </summary>
		public void Dispose()
		{
			// dispose any used sql transaction
			if(_SQLiteTrans != null)
				_SQLiteTrans.Dispose();
			
			// close and dispose the conneciton
			if(_SQLiteCN != null)
			{
				if(_SQLiteCN.State != sd.ConnectionState.Closed)
					_SQLiteCN.Close();
			
				_SQLiteCN.Dispose();
			}
			// dispose any used sql data reader
			if(_SQLiteReader != null)
				_SQLiteReader.Dispose();
			// dispose any used sql command
			if(_SQLiteCMD != null)
				_SQLiteCMD.Dispose();
			
		}
		
		#endregion Class Constructors
		
		public void StartTransaction()
		{
			StartTransaction("DefaultTrans");
		}
		
		public void StartTransaction(string TransName)
		{
			
		}
		
		
		#region Main Connection
		
		/// <summary>
		///  Creates a new database connection
		/// </summary>
		/// <returns></returns>
		private void OpenConnection()
		{
			if(_SQLiteCN.State != sd.ConnectionState.Open)
				_SQLiteCN.Open();
		}
		
		/// <summary>
		///  Initialized a connection without opening it
		///  for use with DataAdapters
		/// </summary>
		/// <returns></returns>
		private void InitConnection()
		{
			if(_SQLiteCN == null)
			{
				so.FileInfo fi = new so.FileInfo(_DatabaseURL);
				if(!fi.Exists)
					throw new so.FileNotFoundException("Database not found for connection string.", fi.FullName);
				
				_SQLiteCN.ConnectionString = "URI=file:" +  fi.FullName + ",version=3, busy_timeout=" + _BusyTimeout.ToString();
				_SQLiteCN.BusyTimeout = _BusyTimeout;
			}
		}
		
		#endregion Main Connection
		
		#region Boolean
		
		/// <summary>
		///  Returns true if rows exist and false if they do not
		///  Most likly to be used for quick security checks
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public bool Exists(string SQL)
		{
			bool blnHasRows = false;
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					_SQLiteReader = _SQLiteCMD.ExecuteReader();
					blnHasRows = _SQLiteReader.HasRows;
					_SQLiteReader.Close();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			return blnHasRows;
		}
		
		#endregion Boolean
		
		#region Hashtable
		
		/// <summary>
		///  use this ONLY when you are certain only on row will return
		///  this will parse out that single row into a hash table
		///  not for use with web services
		/// </summary>
		public sc.Hashtable ExecuteHashTableRow(string SQL)
		{
			sc.Hashtable hshReturn = new sc.Hashtable();
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					_SQLiteReader = _SQLiteCMD.ExecuteReader();
					while(_SQLiteReader.Read())
					{
						for(int i = 0; i < _SQLiteReader.FieldCount; i++)
						{
							hshReturn.Add(_SQLiteReader.GetName(i).ToString(),_SQLiteReader[i].ToString());
						}
					}
					
					_SQLiteReader.Close();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			return hshReturn;
		}
		
		#endregion Hashtable
		
		#region Return Array Lists
		
		/// <summary>
		///  Used to return only the first column
		///  in an ArrayList
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public sc.ArrayList ExecuteArrayList(string SQL)
		{
			sc.ArrayList arrReturn = new sc.ArrayList();
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					_SQLiteReader = _SQLiteCMD.ExecuteReader();
					while(_SQLiteReader.Read())
					{
						arrReturn.Add((object)_SQLiteReader[0]);
					}
					_SQLiteReader.Close();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
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
		public sc.ArrayList ExecuteArrayList(string strSQL, string strColumnName)
		{
			sc.ArrayList arrReturn = new sc.ArrayList();
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(strSQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					_SQLiteReader = _SQLiteCMD.ExecuteReader();
					while(_SQLiteReader.Read())
					{
						arrReturn.Add((object)_SQLiteReader[strColumnName]);
					}
					_SQLiteReader.Close();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			return arrReturn;
		}
		
		/// <summary>
		/// Intended to return on single datarow in an array list
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public sc.ArrayList ExecuteArrayListRow(string strSQL)
		{
			sc.ArrayList arrReturn = new sc.ArrayList();
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(strSQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			_SQLiteReader = null;
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					_SQLiteReader = _SQLiteCMD.ExecuteReader();
					while(_SQLiteReader.Read())
					{
						for(int i = 0; i < _SQLiteReader.FieldCount; i++)
						{
							arrReturn.Add((object)_SQLiteReader[i]);
						}
						
					}
					_SQLiteReader.Close();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			return arrReturn;
		}
		
		#endregion Return Array Lists
		
		#region Scalar and NonQuery
		
		/// <summary>
		///  Used to execute non-queries
		/// </summary>
		/// <param name="strSQL"></param>
		public void ExecuteNonQuery(string SQL)
		{
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					_SQLiteCMD.ExecuteNonQuery();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
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
		public string ExecuteScalar(string SQL, bool blnAddIdentityStatement)
		{
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			string strReturn = null;
			
			if(blnAddIdentityStatement == true)
				_SQLiteCMD.CommandText += "SELECT last_insert_rowid();";
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					OpenConnection();
					strReturn = _SQLiteCMD.ExecuteScalar().ToString();
					_SQLiteCN.Close();
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			return strReturn;
		}
		
		#endregion Scalar and NonQuery
		
		#region DataSets and DataTables
		
		public sd.DataSet ExecuteDataSet(string SQL)
		{
			return ExecuteDataSet(SQL, null);
		}
		
		public sd.DataSet ExecuteDataSet(string SQL, string DataSetName)
		{
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			mds.SqliteDataAdapter sqlDA =  new mds.SqliteDataAdapter(_SQLiteCMD);
			sd.DataSet ds = new sd.DataSet();
			
			if(DataSetName != null)
				ds.DataSetName = DataSetName;
			else
				ds.DataSetName = "ds";
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					sqlDA.Fill(ds);
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			sqlDA.Dispose();
			return ds;
		}
		
		/// <summary>
		/// Returns a DataTable without setting it's name
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public sd.DataTable ExecuteDataTable(string SQL)
		{
			return ExecuteDataTable(SQL, null);
		}
		
		/// <summary>
		/// Returns a DataTable and sets it's name
		/// </summary>
		/// <param name="strSQL"></param>
		/// <param name="strDataTableName"></param>
		/// <returns></returns>
		public sd.DataTable ExecuteDataTable(string SQL, string DataTableName)
		{
			InitConnection();
			_SQLiteCMD = new mds.SqliteCommand(SQL, _SQLiteCN);
			_SQLiteCMD.CommandType = sd.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			mds.SqliteDataAdapter sqlDA = new mds.SqliteDataAdapter(_SQLiteCMD);
			sd.DataTable dt = new sd.DataTable();
			
			if(DataTableName != null)
				dt.TableName = DataTableName;
			else
				dt.TableName = "dt";
			
			bool lockedDatabaseException = true;
			while ( lockedDatabaseException )
			{
				try
				{
					sqlDA.Fill(dt);
					lockedDatabaseException = false;
				}
				catch(Exception ex)
				{
					if (ex.Message.ToLower().Contains("database is locked"))
					{
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep(_LockedDBSleep);
					}
					else
					{
						lockedDatabaseException = false;
						throw new Exception(ex.ToString());
					}
				}
			}
			sqlDA.Dispose();
			return dt;
		}
		
		#endregion  DataSets and DataTables
		
	}
}
