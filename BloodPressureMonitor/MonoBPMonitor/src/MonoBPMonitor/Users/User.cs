
using System;
using Gtk;
using SQLiteDataProvider;
using GoonTools;

namespace MonoBPMonitor
{
	public class User
	{
		private int _UserID = -1;
		private string _UserName = "New User";
		private DateTime _DateAdded = DateTime.Now.Date;
		private bool _IsActive = true;
		
		#region Construtors
		
		public User()
		{
		}
		
		public User(string username)
		{
			_UserName=username;
		}
		
		public User(int userid, string username, DateTime dateadded, bool isactive)
		{
			_UserID = userid;
			_UserName=username;
			_DateAdded=dateadded;
			_IsActive=isactive;
		}
		
		#endregion Construtors
		
		#region Public Properties
		
		public int UserID
		{
			get{return _UserID;}	
		}
		
		public string UserName
		{
			set{_UserName=value;}
			get{return _UserName;}	
		}
		
		public DateTime DateAdded
		{
			set{_DateAdded=value;}
			get{return _DateAdded;}	
		}
		
		public bool IsActive
		{
			set{_IsActive=value;}
			get{return _IsActive;}	
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public void Add()
		{
			try
			{
				if(_UserID < 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					_UserID = Convert.ToInt32(dp.ExecuteScalar("INSERT INTO tb_User(UserName, DateAdded, IsActive)VALUES('" + _UserName + "','" + _DateAdded.ToShortDateString() + "','" + _IsActive.ToString() + "'); SELECT last_insert_rowid();" ));
					dp.Dispose();
				}
				else
				{
					throw new Exception("Attempting to add a User that already exists.\n\n");
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void Update()
		{
			try
			{
				if(_UserID > 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					dp.ExecuteNonQuery("UPDATE tb_User SET UserName = '" + _UserName + "', DateAdded = '" + _DateAdded.ToShortDateString() + "', IsActive = '" + _IsActive.ToString() + "' WHERE UserID = " + _UserID.ToString() + ";");
					dp.Dispose();
				}
				else
				{
					throw new Exception("Cannont update a User that is not already in the database.\n\n");
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void Remove()
		{
			try
			{
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				dp.ExecuteNonQuery("DELETE FROM tb_User WHERE UserID = " + _UserID.ToString() + ";");
				dp.Dispose();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void AddUpdate()
		{
			if(_UserID > 0)
				Update();
			else
				Add();
		}
		
		#endregion Public Methods
	}
}
