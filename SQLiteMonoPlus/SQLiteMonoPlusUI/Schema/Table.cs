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
		public IndexCollection Indexes = new IndexCollection();
		public Table (string name, string sql) : base()
		{
			TableName = name;
			SQL = sql;
		}
		
		public Table(string name)
		{
			TableName = name;
		}
		
		// TODO: run though the sql and populate a 
		// display text for each column
		public void PopulateColumnDescriptions()
		{
			
		}
		
	}
}

