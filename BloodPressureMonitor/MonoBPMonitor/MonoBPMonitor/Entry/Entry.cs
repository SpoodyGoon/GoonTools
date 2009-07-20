
using System;
using Gtk;
using SQLiteDataProvider;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public class Entry
	{
		private int _BPEntryID;
		private DateTime _EntryDate = DateTime.Now.Date;
		private int _Systolic = 120;
		private int _Diastolic= 80;
		private int _HeartRate = 55;
		private string _Notes= "";
		private int _UserID;
		
		#region Construtors
		
		public Entry()
		{
		}
		
		public Entry(int bpentryid, DateTime entrydate, int systolic, int diastolic, int heartrate, string notes, int userid)
		{
			_BPEntryID=bpentryid;
			_EntryDate=entrydate;
			_Systolic=systolic;
			_Diastolic=diastolic;
			_HeartRate=heartrate;
			_Notes=notes;
			_UserID=userid;
		}
		
		public Entry(DateTime entrydate, int systolic, int diastolic, int heartrate, string notes, int userid)
		{
			_EntryDate=entrydate;
			_Systolic=systolic;
			_Diastolic=diastolic;
			_HeartRate=heartrate;
			_Notes=notes;
			_UserID=userid;
		}
		
		public Entry(int systolic, int diastolic, int heartrate, int userid)
		{
			_Systolic=systolic;
			_Diastolic=diastolic;
			_HeartRate=heartrate;
			_UserID=userid;
		}
				
		#endregion Construtors
		
		#region Public Properties
		
		public int BPEntryID
		{
			get{return _BPEntryID;}	
		}
		
		public DateTime EntryDate
		{
			set{_EntryDate=value;}
			get{return _EntryDate;}	
		}
		
		public int Systolic
		{
			set{_Systolic=value;}
			get{return _Systolic;}	
		}
		
		public int Diastolic
		{
			set{_Diastolic=value;}
			get{return _Diastolic;}	
		}
		
		public int HeartRate
		{
			set{_HeartRate=value;}
			get{return _HeartRate;}	
		}
		
		public string Notes
		{
			set{_Notes=value;}
			get{return _Notes;}	
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
				if(_BPEntryID > 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					_BPEntryID = Convert.ToInt32(dp.ExecuteScalar("INSERT INTO tb_BPEntry(EntryDate, Systolic, Diastolic, HeartRate, Notes, UserID)VALUES('" + _EntryDate.ToShortDateString() + "'," + _Systolic.ToString() + "," + _Diastolic.ToString() + "," + _HeartRate.ToString() + ",'" +_Notes + "', " + _UserID.ToString() + "); SELECT last_insert_rowid();" ));
					dp.Dispose();
				}
				else
				{
					throw new Exception("Attempting to add a Blood Pressure Entry that already exists");
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
				if(_BPEntryID != 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					dp.ExecuteNonQuery("UPDATE tb_BPEntry SET EntryDate = '" + _EntryDate.ToShortDateString() + "', Systolic = " + _Systolic.ToString() + ", Diastolic = " + _Diastolic.ToString() + ", HeartRate = " + _HeartRate.ToString() + ", Notes = '" + _Notes + "', UserID = " + _UserID.ToString() + " WHERE BPEntryID = " + _BPEntryID.ToString() + ";");
					dp.Dispose();
				}
				else
				{
					throw new Exception("Cannont update a  Blood Pressure Entry that is not already in the database");
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
				dp.ExecuteNonQuery("DELETE FROM tb_BPEntry WHERE BPEntryID = " + _BPEntryID.ToString() + ";");
				dp.Dispose();
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		#endregion Public Methods
	}
}
