using System;
using Gtk;
using SQLiteDataProvider;
using GoonTools;

namespace MonoBPMonitor.Reports
{
	/// <summary>
	/// Description of MainBPReport.
	/// </summary>
	public class MainBPReport
	{
		private int _EntryID = -1;
		private DateTime _EntryDateTime = DateTime.Now;
		private int _Systolic = 120;
		private int _Diastolic= 80;
		private int _HeartRate = 55;
		private int _SystolicAvg = 120;
		private int _DiastolicAvg = 80;
		private int _HeartRateAvg = 55;
		public MainBPReport(int entryid, DateTime entrydatetime, int systolic, int diastolic, int heartrate, int systolictotal, int diastolictotal, int heartratetotal, int recordcount )
		{
			_EntryID = entryid;
			_EntryDateTime = entrydatetime;
			_Systolic = systolic;
			_Diastolic = diastolic;
			_HeartRate = heartrate;
			_SystolicAvg = systolictotal/recordcount;
			_DiastolicAvg = diastolictotal/recordcount;
			_HeartRateAvg = heartratetotal/recordcount;
		}
		
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
		
		public int SystolicAvg
		{
			set{_SystolicAvg=value;}
			get{return _SystolicAvg;}	
		}
		
		public int DiastolicAvg
		{
			set{_DiastolicAvg=value;}
			get{return _DiastolicAvg;}	
		}
		
		public int HeartRateAvg
		{
			set{_HeartRateAvg=value;}
			get{return _HeartRateAvg;}	
		}
		
		#endregion Public Properties
		
		
	}
}
