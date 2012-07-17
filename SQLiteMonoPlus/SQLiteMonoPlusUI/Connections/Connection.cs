using System;
using System.Data;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI
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
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_ConnectionID = value;
        	}
        }
        
        public string ConnectionName
        {
        	get{return _ConnectionName;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_ConnectionName = value;
        	}
        }
        
        public string FilePath
        {
        	get{return _FilePath;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_FilePath = value;
        	}
        }
        
        public string Password
        {
        	get{return _Password;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_Password = value;
        	}
        }
        
        public int Timeout
        {
        	get{return _Timeout;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_Timeout = value;
        	}
        }
        
        public bool Pooling
        {
        	get{return _Pooling;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_Pooling = value;
        	}
        }
        
        public int MaxPoolSize
        {
        	get{return _MaxPoolSize;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_MaxPoolSize = value;
        	}
        }
        
        public DateTime AddedDate
        {
        	get{return _AddedDate;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_AddedDate = value;
        	}
        }
          
        public DateTime LastUsedDate
        {
        	get{return _LastUsedDate;}
        	set
        	{
        		if(!_ConnectionID.Equals(value))
        			Common.RecentConnections.Modified = true;
        		_LastUsedDate = value;
        	}
        }
              
        #endregion Public Properties
        
        #region Constructors

        public Connection(string name) : base()
		{
			_ConnectionName = name;
		}
        
        public Connection(DataRow dr)
        {
        	_ConnectionID = Convert.ToInt32(dr["ConnectionID"]);
            _ConnectionName = dr["ConnectionName"].ToString();
            _FilePath = dr["FilePath"].ToString();
			_Password =  dr["Password"].ToString();
			_Pooling =  Convert.ToBoolean(dr["Pooling"]);
			_MaxPoolSize =  Convert.ToInt32(dr["MaxPooling"]);
			_AddedDate = Convert.ToDateTime(dr["AddedDate"]);
			_LastUsedDate = Convert.ToDateTime(dr["LastUsedDate"]);
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

