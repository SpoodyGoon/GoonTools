
using System;
using Gtk;
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
		
		public Entry(int entryid)
		{
			new Entry(entryid, true);
		}
		
		public Entry(int entryid, bool open)
		{
			if(open)
			{
				_EntryID = entryid;
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				System.Collections.Hashtable htEntry = shp.ExecuteHashTableRow("SELECT EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry WHERE EntryID = " + _EntryID.ToString() + ";");
				shp.Dispose();
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
					SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
					_EntryID = Convert.ToInt32(shp.ExecuteScalar("INSERT INTO tb_Entry(EntryDateTime, Systolic, Diastolic, HeartRate, Notes, UserID)VALUES('" + _EntryDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'," + _Systolic.ToString() + "," + _Diastolic.ToString() + "," + _HeartRate.ToString() + ",'" +_Notes + "', " + _UserID.ToString() + "); SELECT last_insert_rowid();" ));
					shp.Dispose();
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
					SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
					shp.ExecuteNonQuery("UPDATE tb_Entry SET EntryDateTime = " + shp.ToSQLiteDateTime(_EntryDateTime) + ", Systolic = " + _Systolic.ToString() + ", Diastolic = " + _Diastolic.ToString() + ", HeartRate = " + _HeartRate.ToString() + ", Notes = '" + _Notes + "', UserID = " + _UserID.ToString() + " WHERE EntryID = " + _EntryID.ToString() + ";");
					shp.Dispose();
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
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Warning, Gtk.ButtonsType.YesNo, false, "Are you sure you want to delete this Blood Pressure Reading?", "Delete?.");
				md.WindowPosition = WindowPosition.Mouse;
				if(md.Run() == (int)ResponseType.Yes)
				{
					SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
					shp.ExecuteNonQuery("DELETE FROM tb_Entry WHERE EntryID = " + _EntryID.ToString() + ";");
					shp.Dispose();
				}
				md.Destroy();
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
