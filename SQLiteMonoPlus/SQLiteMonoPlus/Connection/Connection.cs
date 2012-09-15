using System;
using Mono.Data.SqliteClient;

namespace SQLiteMonoPlus
{
	public class Connection
	{
		#region Private Properties
		
        private Nullable<int> _ConnectionID = null;
		private string _ConnectionName = string.Empty;
		private string _FilePath = string.Empty;
		private string _Password = string.Empty;
		private int _Timeout = 1000;
		private bool _Pooling = false;
		private int _MaxPoolSize = -1;
        private DateTime _AddedDate = DateTime.Now;
        private DateTime _LastUsedDate = DateTime.Now;
        
		#endregion Private Properties

        #region Public Properties
        
        public Nullable<int> ConnectionID
        {
        	get{return _ConnectionID;}
        	set
        	{
        		_ConnectionID = value;
        	}
        }
        
        public string ConnectionName
        {
        	get{return _ConnectionName;}
        	set
        	{
        		_ConnectionName = value;
        	}
        }
        
        public string FilePath
        {
        	get{return _FilePath;}
        	set
        	{
        		_FilePath = value;
        	}
        }
        
        public string Password
        {
        	get{return _Password;}
        	set
        	{
        		_Password = value;
        	}
        }
        
        public int Timeout
        {
        	get{return _Timeout;}
        	set
        	{
        		_Timeout = value;
        	}
        }
        
        public bool Pooling
        {
        	get{return _Pooling;}
        	set
        	{
        		_Pooling = value;
        	}
        }
        
        public int MaxPoolSize
        {
        	get{return _MaxPoolSize;}
        	set
        	{
        		_MaxPoolSize = value;
        	}
        }
        
        public DateTime AddedDate
        {
        	get{return _AddedDate;}
        	set
        	{
        		_AddedDate = value;
        	}
        }
          
        public DateTime LastUsedDate
        {
        	get{return _LastUsedDate;}
        	set
        	{
        		_LastUsedDate = value;
        	}
        }

		public string ConnectionString
		{
			get{ return "URI=file:" + _FilePath + ",version=3, busy_timeout=300";}
		}
		
		private bool CanConnect
		{
			get
			{				
				bool blnSuccess = true;
				try {
					SqliteConnection sqlCN = new SqliteConnection(this.ConnectionString);
					SqliteCommand sqlCMD = new SqliteCommand (SQLiteMonoPlus.Constants.ConnectionString.ConnectionTest, sqlCN);
					sqlCN.Open ();
					sqlCMD.ExecuteNonQuery ();
					sqlCN.Close ();
					sqlCMD.Dispose ();
					sqlCN.Dispose ();
				}
				catch (Exception ex) {
					blnSuccess = false;
					Console.WriteLine (ex.ToString ());				
				}
				return blnSuccess;
			}
		}
              
        #endregion Public Properties
        
        #region Constructors

        public Connection(string name) : base()
		{
			_ConnectionName = name;
		}
        
        public Connection(string name, string path, string password)
        {
            _ConnectionName = name;
            _FilePath = path;
        }

        public Connection(string name, string path)
        {
            _ConnectionName = name;
            _FilePath = path;
        }
		
		public Connection (int id, string name, string path) 
		{
            _ConnectionID = id;
			_ConnectionName = name;
			_FilePath = path;
		}

        public Connection(int id, string name, string path, string password) 
		{
			_ConnectionName = name;
			_FilePath = path;
			_Password = password;
		}

        public Connection(int id, string name, string path, string password, bool pooling, int maxpoolsize) 
		{
			_ConnectionName = name;
			_FilePath = path;
			_Password = password;
			_Pooling = pooling;
			_MaxPoolSize = maxpoolsize;
		}
        
        #endregion Constructors
		
        
	}
}

