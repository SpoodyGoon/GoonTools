

using System;
using Gtk;
using SQLiteDataProvider;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public class Doctor
	{
		private int _DoctorID = -1;
		private string _DoctorName= "New Doctor";
		private string _Location = "";
		private string _PhoneNum = "";
		private int _UserID = 1;
		
		#region Construtors
		
		public Doctor()
		{
		}
		
		public Doctor(string doctorname, int userid)
		{
			_DoctorName= doctorname;
			_UserID=userid;
		}
		
		public Doctor(string doctorname, string location, string phonenum, int userid)
		{
			_DoctorName= doctorname;
			_Location=location;
			_PhoneNum =phonenum;
			_UserID=userid;
		}
		
		public Doctor(int doctorid, string doctorname, string location, string phonenum, int userid)
		{
			_DoctorID = doctorid;
			_DoctorName= doctorname;
			_Location=location;
			_PhoneNum =phonenum;
			_UserID=userid;
		}
		
		#endregion Construtors
		
		#region Public Properties
		
		public int DoctorID
		{
			get{return _DoctorID;}	
		}
		
		public string DoctorName
		{
			set{_DoctorName=value;}
			get{return _DoctorName;}	
		}
		
		public string Location
		{
			set{_Location=value;}
			get{return _Location;}	
		}
		
		public string PhoneNum
		{
			set{_PhoneNum=value;}
			get{return _PhoneNum;}	
		}
		
		public int UserID
		{
			set{_UserID=value;}
			get{return _UserID;}	
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public void Add()
		{
			try
			{
				if(_DoctorID < 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					_DoctorID = Convert.ToInt32(dp.ExecuteScalar("INSERT INTO tb_Doctor(DoctorName, Location, PhoneNum, UserID)VALUES('" + _DoctorName + "','" + _Location + "','" + _PhoneNum + "', " + _UserID.ToString() + "); SELECT last_insert_rowid();" ));
					dp.Dispose();
				}
				else
				{
					throw new Exception("Attempting to add a Doctor that already exists");
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public void Update()
		{
			try
			{
				if(_DoctorID > 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					dp.ExecuteNonQuery("UPDATE tb_Doctor SET DoctorName = '" + _DoctorName + "', Location = '" + _Location + "', PhoneNum = '" + _PhoneNum + "', UserID = " + _UserID.ToString() + " WHERE DoctorID = " + _DoctorID.ToString() + ";");
					dp.Dispose();
				}
				else
				{
					throw new Exception("Cannont update a Doctor that is not already in the database");
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public void Remove()
		{
			try
			{
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				dp.ExecuteNonQuery("DELETE FROM tb_Doctor WHERE DoctorID = " + _DoctorID.ToString() + ";");
				dp.Dispose();
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public void AddUpdate()
		{
			if(_DoctorID > 0)
				Update();
			else
				Add();
		}
		
		#endregion Public Methods
		
		
	}
}