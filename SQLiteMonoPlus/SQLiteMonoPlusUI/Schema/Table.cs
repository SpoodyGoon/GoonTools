using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Table
	{
		public string TableName = string.Empty;
		public string SQL = string.Empty;
		public ColumnCollection Columns = new ColumnCollection();
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

