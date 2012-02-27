using System;
namespace SQLiteMonoPlusUI
{
	public class View
	{
		public string ViewName = string.Empty;
		public string SQL = string.Empty;
		public View (string name, string sql) : base()
		{
			ViewName = name;
			SQL = sql;
		}
		
		public View ()
		{
		}
	}
}

