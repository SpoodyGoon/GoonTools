
using System;

namespace MonoBPMonitor
{
	
	
	public class Doctor
	{
		private int _DoctorID;
		private string _DoctorName= "New Doctor";
		private string _Location = "";
		private string _PhoneNum = "";
		private int _PersonID;
		
		#region Construtors
		
		public Doctor()
		{
		}
		
		public Doctor(string doctorname, string location, string phonenum, int personid)
		{
			_DoctorName= doctorname;
			_Location=location;
			_PhoneNum =phonenum;
			_PersonID=personid;
		}
		
		public Doctor(int doctorid, string doctorname, string location, string phonenum, int personid)
		{
			_DoctorID = doctorid;
			_DoctorName= doctorname;
			_Location=location;
			_PhoneNum =phonenum;
			_PersonID=personid;
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
		
		public int PersonID
		{
			set{_PersonID=value;}
			get{return _PersonID;}	
		}
		
		#endregion Public Properties
		
		#region Public Properties
		
		public void Add()
		{
			
		}
		
		public void Update()
		{
			
		}
		
		public void Remove()
		{
			
		}
		
		#endregion Public Properties
		
		
	}
}
