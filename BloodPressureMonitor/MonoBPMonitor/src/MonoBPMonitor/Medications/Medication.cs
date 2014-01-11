
using System;
using Gtk;
using GoonTools;
using SQLiteDataHelper;

namespace MonoBPMonitor
{
	public class Medication
	{
		private int _MedicineID;
		private string _MedicineName="New Medicine";
		private string _Dosage="";
		private DateTime _StartDate = new DateTime(1990, 1,1);
		private DateTime _EndDate = new DateTime(1990, 1,1);
		private int _DoctorID = 1;
		private int _UserID = 1;
		#region Construtors
		
		public Medication()
		{
		}		
		
		public Medication(int medicineid, string medicinename, string dosage, DateTime startdate, DateTime enddate, int doctorid, int userid)
		{
			_MedicineID=medicineid;
			_MedicineName=medicinename;
			_Dosage=dosage;
			_StartDate=startdate;
			_EndDate=enddate;
			_DoctorID=doctorid;
			_UserID=userid;
		}		
		
		public Medication(string medicinename, string dosage, string startdate, string enddate, int doctorid, int userid)
		{
			_MedicineName=medicinename;
			_Dosage=dosage;
			if(startdate.Trim() != "")
				_StartDate=DateTime.Parse(startdate);
			if(enddate.Trim() != "")
				_EndDate=DateTime.Parse(enddate);
			_DoctorID=doctorid;
			_UserID=userid;
		}	
		
		public Medication(string medicinename, int doctorid, int userid)
		{
			_MedicineName=medicinename;
			_DoctorID=doctorid;
			_UserID=userid;
		}	
		
		#endregion Construtors
		
		#region Public Properties
		
		public int MedicineID
		{
			get{return _MedicineID;}	
		}
		
		public string MedicineName
		{
			set{_MedicineName=value;}
			get{return _MedicineName;}	
		}
		
		public string Dosage
		{
			set{_Dosage=value;}
			get{return _Dosage;}	
		}
		
		public DateTime StartDate
		{
			set{_StartDate=value;}
			get{return _StartDate;}	
		}
		
		public DateTime EndDate
		{
			set{_EndDate=value;}
			get{return _EndDate;}	
		}
		
		public int DoctorID
		{
			set{_DoctorID=value;}
			get{return _DoctorID;}	
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
				if(_MedicineID < 0)
				{
					SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
					_MedicineID = Convert.ToInt32(shp.ExecuteScalar("INSERT INTO tb_Medicine(MedicineName, Dosage, StartDate,EndDate ,DoctorID, UserID)VALUES('" + _MedicineName + "','" + _Dosage + "','" + _StartDate.ToShortDateString() + "','" + _EndDate.ToShortDateString() + "'," + _DoctorID.ToString() + "," + _UserID.ToString() + "); SELECT last_insert_rowid();" ));
					shp.Dispose();
				}
				else
				{
					throw new Exception("Attempting to add a Medicine that already exists");
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
				if(_MedicineID > 0)
				{
					SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
					shp.ExecuteNonQuery("UPDATE tb_Medicine SET MedicineName = '" + _MedicineName + "', Dosage = '" + _Dosage + "', StartDate = '" + _StartDate.ToShortDateString() + "', EndDate = '" + _EndDate.ToShortDateString() + "', DoctorID = " + _DoctorID.ToString() + ", UserID = " + _UserID.ToString() + " WHERE MedicineID = " + _MedicineID.ToString() + ";");
					shp.Dispose();
				}
				else
				{
					throw new Exception("Cannont update a Medicine that is not already in the database");
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
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				shp.ExecuteNonQuery("DELETE FROM tb_Medicine WHERE MedicineID = " + _MedicineID.ToString() + ";");
				shp.Dispose();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void AddUpdate()
		{
			if(_MedicineID > 0)
				Update();
			else
				Add();
		}
		
		#endregion Public Methods
	}
}
