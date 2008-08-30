#region "License"

// Copyright (c) 2008 Andrew York
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

#endregion "License"

#region "Description"

// This class is a dataprovider for SQLite (http://sqlite.org/) a file and/or memory based database
// This class requires: 
//      + MS .NET 2.0 framework (http://www.microsoft.com/downloads/details.aspx?FamilyID=fe6f2099-b7b4-4f47-a244-c96d69c35dec&DisplayLang=en)
//      + ADO.NET 2.0 Provider for SQLite (http://sourceforge.net/projects/sqlite-dotnet2)
 
#endregion "Description"

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Data.SQLite;
using System.ComponentModel;
using System.Collections;
using System.Configuration;


namespace SQLiteDataProvider
{
	/// <summary>
	/// A dataprovider for SQLite and MS .NET
	/// </summary>
	public class DataProvider: System.IDisposable
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
        ///  Class Constructor that specifies the IntPtr handle
        ///  for disposing
        /// </summary>
        /// <param name="handle"></param>
        public DataProvider(IntPtr handle)
		{
			this.handle = handle;
		}
		
        /// <summary>
        ///  Class Constructor that specifies the IntPtr handle
        ///  and the connection string
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="handle"></param>
		public DataProvider(string strConn,IntPtr handle)
		{
			this.handle = handle;
			_ConnString = strConn;
		}
		
        /// <summary>
        /// Base Class Constructor
        /// </summary>
		public DataProvider()
		{
			
		}
		
        /// <summary>
        ///  Class Constructor that specifies the connection string
        /// </summary>
        /// <param name="strConn"></param>
		public DataProvider(string strConn)
		{
			_ConnString = strConn;
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
		
		#endregion "Class Constructors"

		#region "Items for Disposing"
		
		// Pointer to an external unmanaged resource.
		private IntPtr handle;
		// Other managed resource this class uses.
		private Component component = new Component();
		// Track whether Dispose has been called.
		private bool disposed = false;

        /// <summary>
        /// Implement IDisposable.
        /// Do not make this method virtual.
        /// A derived class should not be able to override this method.
        /// </summary>
        public void Dispose()
		{
			Dispose(true);
			// This object will be cleaned up by the Dispose method.
			// Therefore, you should call GC.SupressFinalize to
			// take this object off the finalization queue
			// and prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}

		
        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
		/// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if(!this.disposed)
			{
				// If disposing equals true, dispose all managed
				// and unmanaged resources.
				if(disposing)
				{
					// Dispose managed resources.
					component.Dispose();
				}

				// Call the appropriate methods to clean up
				// unmanaged resources here.
				// If disposing is false,
				// only the following code is executed.
				CloseHandle(handle);
				handle = IntPtr.Zero;

				// Note disposing has been done.
				disposed = true;

			}
		}

		/// <summary>
        /// Use interop to call the method necessary
        /// to clean up the unmanaged resource.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
		[System.Runtime.InteropServices.DllImport("Kernel32")]
		private extern static Boolean CloseHandle(IntPtr handle);

		/// <summary>
        /// Use C# destructor syntax for finalization code.
        /// This destructor will run only if the Dispose method
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </summary>
		~DataProvider()
		{
			// Do not re-create Dispose clean-up code here.
			// Calling Dispose(false) is optimal in terms of
			// readability and maintainability.
			Dispose(false);
		}
		
		#endregion "Items for Disposing"
		
		#region "Main Connection"
		
        /// <summary>
        ///  Creates a new database connection
        /// </summary>
        /// <returns></returns>
		private SQLiteConnection GetConn()
		{
			SQLiteConnection sqlCN = null;
			try
			{
				// if the connection string is null
				// try to get the default from the config file
				if(_ConnStringType == ConnectionStringType.FromCallingCode)
				{
					sqlCN = new SQLiteConnection(_ConnString);		
				}
				else
				{
                    sqlCN = new SQLiteConnection(ConfigurationManager.AppSettings[_ConnString].ToString());				
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
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SQLiteDataReader sqlReader = null;
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
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SQLiteDataReader sqlReader = null;
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
		
		#region "Array Lists"
		
		/// <summary>
		///  Used to return only the first column
        ///  in an ArrayList
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public ArrayList ExecuteArrayList(string strSQL)
		{
			
			ArrayList arrReturn = new ArrayList();
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SQLiteDataReader sqlReader = null;
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
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SQLiteDataReader sqlReader = null;
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
			return arrReturn;
		}
		
		#endregion
		
		#region "NonQueries and Scalars"
		
        /// <summary>
        ///  Used to execute non-queries
        /// </summary>
        /// <param name="strSQL"></param>
		public void ExecuteNonQuery(string strSQL)
		{
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			try
			{
				sqlCMD = new SQLiteCommand(strSQL, sqlCN);
				sqlCMD.CommandType = CommandType.Text;
				sqlCN.Open();
				sqlCMD.ExecuteNonQuery();
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
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			string strReturn = null;
			try
			{
				if(blnAddIdentityStatement == true)
					sqlCMD.CommandText += " SELECT last_insert_rowid();";
				
				sqlCN.Open();
				strReturn = sqlCMD.ExecuteScalar().ToString();
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
			}
			return strReturn;
		}
		
		#endregion
		
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
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SQLiteDataAdapter sqlDA = null;
			DataSet ds = new DataSet();
			try
			{
				if(strDataSetName != null)
					ds.DataSetName = strDataSetName;
				else
					ds.DataSetName = "ds";
				
				sqlDA = new SQLiteDataAdapter(sqlCMD);
				sqlDA.Fill(ds);
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
			SQLiteConnection sqlCN = GetConn();
			SQLiteCommand sqlCMD = new SQLiteCommand(strSQL, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = _TimeOut;
			SQLiteDataAdapter sqlDA = null;
			DataTable dt = new DataTable();
			try
			{
				if(strDataTableName != null)
					dt.TableName = strDataTableName;
				else
					dt.TableName = "dt";
				
				sqlDA = new SQLiteDataAdapter(sqlCMD);
				sqlDA.Fill(dt);
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
				sqlDA.Dispose();
			}
			return dt;
		}
		
		#endregion "DataSets and DataTables"
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
