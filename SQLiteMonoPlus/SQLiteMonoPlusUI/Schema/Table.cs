using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Table
	{
		public Nullable<int> CID = null;
		public string TableName = string.Empty;
		public string SQL = string.Empty;
		public ColumnCollection Columns = new ColumnCollection();
		public TriggerCollection Triggers = new TriggerCollection();
		public Table (string name, string sql) : base()
		{
			TableName = name;
			SQL = sql;
		}
		
		public Table(string name)
		{
			TableName = name;
		}
		
		
	}
}

