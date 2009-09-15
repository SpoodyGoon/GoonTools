
using System;
using Gtk;
using SQLiteDataProvider;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public class Entry
	{
		private int _EntryID = -1;
		private DateTime _EntryDateTime = DateTime.Now;
		private int _Systolic = 120;
		private int _Diastolic= 80;
		private int _HeartRate = 55;
		private string _Notes= "";
		private int _UserID =1;
		
		#region Construtors
		
		public Entry()
		{
			
		}
		
		public Entry(int entryid, bool open)
		{
			if(open)
			{
				_EntryID = entryid;
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				System.Collections.Hashtable htEntry = dp.ExecuteHashTable("SELECT EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry WHERE EntryID = " + _EntryID.ToString() + ";");
				dp.Dispose();
				_EntryDateTime = Convert.ToDateTime(htEntry["EntryDateTime"]);
				_Systolic = Convert.ToInt32(htEntry["Systolic"]);
				_Diastolic =  Convert.ToInt32(htEntry["Diastolic"]);			
				_HeartRate =  Convert.ToInt32(htEntry["HeartRate"]);
				_Notes = htEntry["Notes"].ToString();
				_UserID = Convert.ToInt32(htEntry["UserID"]);
			}
		}
		
		public Entry(int entryid, DateTime entrydatetime, int systolic, int diastolic, int heartrate, string notes, int userid)
		{
			_EntryID=entryid;
			_EntryDateTime=entrydatetime;
			_Systolic=systolic;
			_Diastolic=diastolic;
			_HeartRate=heartrate;
			_Notes=notes;
			_UserID=userid;
		}
		
		public Entry(DateTime entrydatetime, int systolic, int diastolic, int heartrate, string notes, int userid)
		{
			_EntryDateTime=entrydatetime;
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
		
		public int EntryID
		{
			get{return _EntryID;}	
		}
		
		public DateTime EntryDateTime
		{
			set{_EntryDateTime=value;}
			get{return _EntryDateTime;}	
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
				if(_EntryID < 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					_EntryID = Convert.ToInt32(dp.ExecuteScalar("INSERT INTO tb_Entry(EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID)VALUES('" + _EntryDateTime.ToString("yyyy-MM-dd hh:mm:ss") + "'," + _Systolic.ToString() + "," + _Diastolic.ToString() + "," + _HeartRate.ToString() + ",'" +_Notes + "', " + _UserID.ToString() + "); SELECT last_insert_rowid();" ));
					dp.Dispose();
				}
				else
				{
					throw new Exception("Attempting to add a Blood Pressure Entry that already exists");
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
				if(_EntryID > 0)
				{
					DataProvider dp = new DataProvider(Common.Option.ConnString);
					dp.ExecuteNonQuery("UPDATE tb_Entry SET EntryDateTime = DATETIME('" + _EntryDateTime.ToString("yyyy-MM-dd hh:mm:ss") + "','localtime'), Systolic = " + _Systolic.ToString() + ", Diastolic = " + _Diastolic.ToString() + ", HeartRate = " + _HeartRate.ToString() + ", Notes = '" + _Notes + "', UserID = " + _UserID.ToString() + " WHERE EntryID = " + _EntryID.ToString() + ";");
					dp.Dispose();
				}
				else
				{
					throw new Exception("Cannont update a  Blood Pressure Entry that is not already in the database");
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
				dp.ExecuteNonQuery("DELETE FROM tb_Entry WHERE EntryID = " + _EntryID.ToString() + ";");
				dp.Dispose();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void AddUpdate()
		{
			if(_EntryID > 0)
				Update();
			else
				Add();
		}
		
		#endregion Public Methods
	}
}
