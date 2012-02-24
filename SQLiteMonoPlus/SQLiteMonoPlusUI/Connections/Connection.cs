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
		private string _Password = null;
		private bool _Pooling = false;
		private int _MaxPoolSize = -1;
        private DateTime _AddedDate = DateTime.Now;
        private DateTime _LastUsedDate = DateTime.Now;
        private DataRow _ConnectionRow;
        
		#endregion Private Properties

        #region Public Properties
        
        public Nullable<int> ConnectionID
        {
        	get{return _ConnectionID;}
        	set
        	{
        		_ConnectionID = value;
        		_ConnectionRow["ConnectionID"] = (int)value;
        	}
        }
        
        public string ConnectionName
        {
        	get{return _ConnectionName;}
        	set
        	{
        		_ConnectionName = value;
        		_ConnectionRow["ConnectionName"] = value;
        	}
        }
        
        public string FilePath
        {
        	get{return _FilePath;}
        	set
        	{
        		_FilePath = value;
        		_ConnectionRow["FilePath"] = value;
        	}
        }
        
        public string Password
        {
        	get{return _Password;}
        	set
        	{
        		_Password = value;
        		_ConnectionRow["Password"] = value;
        	}
        }
        
        public bool Pooling
        {
        	get{return _Pooling;}
        	set
        	{
        		_Pooling = value;
        		_ConnectionRow["Pooling"] = value;
        	}
        }
        
        public int MaxPoolSize
        {
        	get{return _MaxPoolSize;}
        	set
        	{
        		_MaxPoolSize = value;
        		_ConnectionRow["MaxPoolSize"] = value;
        	}
        }
        
        public DateTime AddedDate
        {
        	get{return _AddedDate;}
        	set
        	{
        		_AddedDate = value;
        		_ConnectionRow["AddedDate"] = value;
        	}
        }
          
        public DateTime LastUsedDate
        {
        	get{return _LastUsedDate;}
        	set
        	{
        		_LastUsedDate = value;
        		_ConnectionRow["LastUsedDate"] = value;
        	}
        }
              
        #endregion Public Properties
        
        #region Constructors
        
        public Connection(DataRow dr)
        {
        	_ConnectionRow = dr;
        	_ConnectionID = Convert.ToInt32(dr["ConnectionID"]);
            _ConnectionName = dr["ConnectionName"].ToString();
            _FilePath = dr["FilePath"].ToString();
			_Password =  dr["Password"].ToString();
			_Pooling =  Convert.ToBoolean(dr["Pooling"]);
			_MaxPoolSize =  Convert.ToInt32(dr["MaxPoolSize"]);
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

        public Connection(int id, string name, string path, bool pooling, int maxpoolsize) 
		{
			_ConnectionName = name;
			_FilePath = path;
			_Pooling = pooling;
			_MaxPoolSize = maxpoolsize;
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

