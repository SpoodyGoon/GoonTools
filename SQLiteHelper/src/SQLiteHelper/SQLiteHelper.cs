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

// This class is a SQLiteHelper for SQLite (http://sqlite.org/) a file and/or memory based database
// This class requires:
//      + Mono .NET framework (http://www.mono-project.com)
//	+ SQLite version 3

#endregion "Description"


using System;
using System.Threading;
using System.IO;
using SD = System.Data;
using System.Collections;
using System.Collections.Generic;
using SL = Mono.Data.SqliteClient;
using Gtk;

namespace SQLiteDataHelper
{	
	/// <summary>
	/// A SQLiteHelper for SQLite and Mono .NET
	/// </summary>
	public class SQLiteHelper
	{
		#region Private Properties

		private string _DatabaseURL = null;
		private int _TimeOut = 500;
		private int _BusyTimeout = 500;
		private int _LockedDBSleep = 500;
		private string _ExceptionMessage = null;
		private SL.SqliteConnection _SQLiteCN = null;
		private SL.SqliteCommand _SQLiteCMD = null;
		private SL.SqliteTransaction _SQLiteTrans = null;
		private SL.SqliteDataReader _SQLiteReader = null;
//		private Dictionary<string, object> _Parmeters = new Dictionary<string, object>();

		// Local GUI Options
		private bool _ReportExceptionInline = false;

		#endregion Private Properties

		#region Public Properties

		/// <summary>
		///  Sets of gets the connection busy time out
		/// </summary>
		public int BusyTimeout {
			get { return _BusyTimeout; }
			set { _BusyTimeout = value; }
		}

		/// <summary>
		///  Sets of gets the connection time out
		/// </summary>
		public int TimeOut {
			get { return _TimeOut; }
			set { _TimeOut = value; }
		}

		/// <summary>
		///  Sets or gets the connection string
		/// </summary>
		public string DatabaseURL {
			get { return _DatabaseURL; }
			set { _DatabaseURL = value; }
		}

		/// <summary>
		///  Returns and Exception message if needed
		/// </summary>
		public string ExceptionMessage {
			get { return _ExceptionMessage; }
		}

		/// <summary>
		///  If this is true then we will
		/// show the error dialog from this class
		/// otherwise it is passed backto the calling class
		/// </summary>
		public bool ReportExceptionInline {
			get { return _ReportExceptionInline; }
			set { _ReportExceptionInline = value; }
		}
		

//		public Dictionary<string, object> Parameters
//		{
//			get{return _Parmeters;}
//		}

		#endregion Public Properties

		#region Private Methods

		private void HandleError (Exception ex, string FunctionDesc)
		{
			// set the error message for return if needed
			_ExceptionMessage = ex.ToString ();
			// if the error message is shown inline
			if (_ReportExceptionInline) {
				Gtk.MessageDialog md = new Gtk.MessageDialog (null, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, ex.ToString () + " " + FunctionDesc, "An Error Has Occured");
				md.Run ();
				md.Destroy ();
			} else {
				// throw the error back at the calling class
				throw new Exception (ex.ToString ());
			}
		}
		

		#endregion Private Mehtods
		
		#region Class Constructors

		/// <summary>
		/// Base Class Constructor
		/// </summary>
		public SQLiteHelper ()
		{
			_DatabaseURL = null;
			_TimeOut = 0;
			_ExceptionMessage = null;
		}

		/// <summary>
		///  Class Constructor that specifies the connection string
		/// </summary>
		/// <param name="Conn"></param>
		public SQLiteHelper (string dbURL)
		{
			_DatabaseURL = dbURL;
		}

		/// <summary>
		/// Class Constructor that specifies the connection string
		/// and the connection time out
		/// </summary>
		/// <param name="dbURL">Location of the database</param>
		/// <param name="TimeOut">Lenght of time out in milli-second</param>
		public SQLiteHelper (string dbURL, int TimeOut)
		{
			_TimeOut = TimeOut;
			_DatabaseURL = dbURL;
		}

		/// <summary>
		///  A dummmy dispose with no real purpose in life.
		///  It's a sad Dispose()... nobody love it
		/// </summary>
		public void Dispose ()
		{
			// dispose any used sql transaction
			if (_SQLiteTrans != null)
				_SQLiteTrans.Dispose ();
			
			// close and dispose the conneciton
			if (_SQLiteCN != null) {
				if (_SQLiteCN.State != SD.ConnectionState.Closed)
					_SQLiteCN.Close ();
				
				_SQLiteCN.Dispose ();
			}
			// dispose any used sql data reader
			if (_SQLiteReader != null)
				_SQLiteReader.Dispose ();
			// dispose any used sql command
			if (_SQLiteCMD != null)
				_SQLiteCMD.Dispose ();
			
		}

		#endregion Class Constructors

		#region Public Transaction Methods

		public void StartTransaction ()
		{
			if (_SQLiteCN != null)
				_SQLiteTrans = (SL.SqliteTransaction)_SQLiteCN.BeginTransaction ();
		}

		public void RollBackTransaction ()
		{
			_SQLiteTrans.Rollback ();
			_SQLiteTrans.Dispose ();
		}

		public void CommitTransaction ()
		{
			_SQLiteTrans.Commit ();
			_SQLiteTrans.Dispose ();
		}

		#endregion Public Transaction Methods

		#region Main Connection

		/// <summary>
		///  Creates a new database connection
		/// </summary>
		/// <returns></returns>
		private void OpenConnection ()
		{
			if (_SQLiteCN.State != SD.ConnectionState.Open)
				_SQLiteCN.Open ();
		}

		/// <summary>
		///  Initialized a connection without opening it
		///  for use with DataAdapters
		/// </summary>
		/// <returns></returns>
		private void InitConnection ()
		{
			if (_SQLiteCN == null) {
				FileInfo fi = new FileInfo (_DatabaseURL);
				if (!fi.Exists)
					throw new FileNotFoundException ("Database not found for connection string.", fi.FullName);
				
				_SQLiteCN = new SL.SqliteConnection ("URI=file:" + fi.FullName + ",version=3, busy_timeout=" + _BusyTimeout.ToString ());
				_SQLiteCN.BusyTimeout = _BusyTimeout;
			}
		}

		#endregion Main Connection
		
//		public System.Data.IDbConnection ConnectionGet()
//		{
//			FileInfo fi = new FileInfo (_DatabaseURL);
//			if (!fi.Exists)
//				throw new FileNotFoundException ("Database not found for connection string.", fi.FullName);
//			
//			return = new SL.SqliteConnection ("URI=file:" + fi.FullName + ",version=3, busy_timeout=" + _BusyTimeout.ToString ());
//		}

		#region Boolean

		/// <summary>
		///  Returns true if rows exist and false if they do not
		///  Most likly to be used for quick security checks
		/// </summary>
		/// <param name="SQL"></param>
		/// <returns></returns>
		public bool Exists (string SQL)
		{
			bool blnHasRows = false;
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					_SQLiteReader = _SQLiteCMD.ExecuteReader ();
					blnHasRows = _SQLiteReader.HasRows;
					_SQLiteReader.Close ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						HandleError (ex, null);
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
		public Hashtable ExecuteHashTableRow (string SQL)
		{
			Hashtable hshReturn = new Hashtable ();
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					_SQLiteReader = _SQLiteCMD.ExecuteReader ();
					while (_SQLiteReader.Read ()) {
						for (int i = 0; i < _SQLiteReader.FieldCount; i++) {
							hshReturn.Add (_SQLiteReader.GetName (i).ToString (), _SQLiteReader[i].ToString ());
						}
					}
					
					_SQLiteReader.Close ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
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
		/// <param name="SQL"></param>
		/// <returns></returns>
		public ArrayList ExecuteArrayList (string SQL)
		{
			ArrayList arrReturn = new ArrayList ();
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					_SQLiteReader = _SQLiteCMD.ExecuteReader ();
					while (_SQLiteReader.Read ()) {
						arrReturn.Add ((object)_SQLiteReader[0]);
					}
					_SQLiteReader.Close ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			return arrReturn;
		}

		/// <summary>
		/// Used to return only the named column
		/// in an ArrayList
		/// </summary>
		/// <param name="SQL"></param>
		/// <param name="ColumnName"></param>
		/// <returns></returns>
		public ArrayList ExecuteArrayList (string SQL, string ColumnName)
		{
			ArrayList arrReturn = new ArrayList ();
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					_SQLiteReader = _SQLiteCMD.ExecuteReader ();
					while (_SQLiteReader.Read ()) {
						arrReturn.Add ((object)_SQLiteReader[ColumnName]);
					}
					_SQLiteReader.Close ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			return arrReturn;
		}

		/// <summary>
		/// Intended to return on single datarow in an array list
		/// </summary>
		/// <param name="SQL"></param>
		/// <returns></returns>
		public ArrayList ExecuteArrayListRow (string SQL)
		{
			ArrayList arrReturn = new ArrayList ();
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			_SQLiteReader = null;
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					_SQLiteReader = _SQLiteCMD.ExecuteReader ();
					while (_SQLiteReader.Read ()) {
						for (int i = 0; i < _SQLiteReader.FieldCount; i++) {
							arrReturn.Add ((object)_SQLiteReader[i]);
						}
						
					}
					_SQLiteReader.Close ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			return arrReturn;
		}

		#endregion Return Array Lists

		#region DataReader

		/// <summary>
		/// Intended to return on single datarow in an array list
		/// </summary>
		/// <param name="SQL"></param>
		/// <returns></returns>
		public SL.SqliteDataReader ExecuteReader (string SQL)
		{
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					OpenConnection ();
					_SQLiteReader = _SQLiteCMD.ExecuteReader ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			return _SQLiteReader;
		}
		#endregion DataReader

		#region Scalar and NonQuery

		/// <summary>
		///  Used to execute non-queries
		/// </summary>
		/// <param name="SQL"></param>
		public void ExecuteNonQuery (string SQL)
		{
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					_SQLiteCMD.ExecuteNonQuery ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
		}



		/// <summary>
		///  Executes Scalar when the last_insert_rowid statement
		///  is already in the SQL string
		/// </summary>
		/// <param name="SQL"></param>
		/// <returns></returns>
		public string ExecuteScalar (string SQL)
		{
			return ExecuteScalar (SQL, false);
		}

		/// <summary>
		/// Executes Scalar when the last_insert_rowid statement
		///  is not already in the SQL string
		/// </summary>
		/// <param name="SQL"></param>
		/// <param name="blnAddIdentityStatement"></param>
		/// <returns></returns>
		public string ExecuteScalar (string SQL, bool blnAddIdentityStatement)
		{
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			string strReturn = null;
			
			if (blnAddIdentityStatement == true)
				_SQLiteCMD.CommandText += "SELECT last_insert_rowid();";
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					//OpenConnection ();
					strReturn = _SQLiteCMD.ExecuteScalar ().ToString ();
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			return strReturn;
		}

		#endregion Scalar and NonQuery

		#region DataSets and DataTables

		public SD.DataSet ExecuteDataSet (string SQL)
		{
			return ExecuteDataSet (SQL, null);
		}

		public SD.DataSet ExecuteDataSet (string SQL, string DataSetName)
		{
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			SL.SqliteDataAdapter sqlDA = new SL.SqliteDataAdapter (_SQLiteCMD);
			SD.DataSet ds = new SD.DataSet ();
			
			if (DataSetName != null)
				ds.DataSetName = DataSetName;
			else
				ds.DataSetName = "ds";
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					sqlDA.Fill (ds);
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			sqlDA.Dispose ();
			return ds;
		}

		/// <summary>
		/// Returns a DataTable without setting it's name
		/// </summary>
		/// <param name="SQL"></param>
		/// <returns></returns>
		public SD.DataTable ExecuteDataTable (string SQL)
		{
			return DataTableGet(SQL, null);
		}

		/// <summary>
		/// Returns a DataTable and sets it's name
		/// </summary>
		/// <param name="SQL"></param>
		/// <param name="strDataTableName"></param>
		/// <returns></returns>
		public SD.DataTable ExecuteDataTable (string SQL, string DataTableName)
		{
			return DataTableGet(SQL, DataTableName);
		}
		
		private SD.DataTable DataTableGet (string SQL, string DataTableName)
		{
			InitConnection ();
			// Initialize the SQL Command
			_SQLiteCMD = new SL.SqliteCommand (SQL);
			// Set the Command Connection
			_SQLiteCMD.Connection = _SQLiteCN;
			
			// if there is an active transaction assign it to the Command
			if (_SQLiteTrans != null)
				_SQLiteCMD.Transaction = _SQLiteTrans;
			_SQLiteCMD.CommandType = SD.CommandType.Text;
			_SQLiteCMD.CommandTimeout = _TimeOut;
			SL.SqliteDataAdapter sqlDA = new SL.SqliteDataAdapter (_SQLiteCMD);
			SD.DataTable dt = new SD.DataTable ();
			
			if (DataTableName != null)
				dt.TableName = DataTableName;
			else
				dt.TableName = "dt";
			
			
			bool lockedDatabaseException = true;
			while (lockedDatabaseException) {
				try {
					sqlDA.Fill(dt);
					if (_SQLiteCMD.Parameters.Count > 0)
						_SQLiteCMD.Parameters.Clear ();
					lockedDatabaseException = false;
				} catch (Exception ex) {
					if (ex.Message.ToLower ().Contains ("database is locked")) {
						lockedDatabaseException = true;
						System.Threading.Thread.Sleep (_LockedDBSleep);
						
					} else {
						lockedDatabaseException = false;
						throw new Exception (ex.ToString ());
					}
				}
			}
			sqlDA.Dispose ();
			return dt;			
		}

		#endregion DataSets and DataTables

		#region Generic Conversions

		public string DateTimeNow {
			get { return "DATETIME('now','localtime')"; }
		}

		public string ToSQLiteDateTime (DateTime dt)
		{
			return "DATETIME('" + dt.ToString ("yyyy-MM-dd HH:mm:ss") + "','localtime')";
		}

		public string ToSQLiteDateTime (string DateTimeString)
		{
			string strReturn = "";
			if (!IsDateTime (DateTimeString)) {
				throw new Exception ("Invalid DateTime Format");
			} else {
				strReturn = "DATETIME('" + Convert.ToDateTime (DateTimeString).ToString ("yyyy-MM-dd HH:mm:ss") + "','localtime')";
			}
			return strReturn;
		}

		public bool IsDateTime (string DateTimeString)
		{
			try {
				Convert.ToDateTime (DateTimeString);
				return true;
			} catch {
				return false;
			}
		}

		#endregion Generic Conversions
		
	}

}
