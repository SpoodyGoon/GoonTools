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
			Column col;
			string strColName = null;
			string[] strColumnSQL = SQL.Substring(SQL.IndexOf('('), SQL.LastIndexOf(')')).Split(new char[]{','});
			for(int i=0;i<strColumnSQL.Length;i++)
			{
				strColName = strColumnSQL[i].Substring(strColumnSQL[i].IndexOf("["), strColumnSQL[i].LastIndexOf("]"));
				col = (Column)Columns[strColName];
				col.DataTypeDisplay = strColumnSQL[i].Trim();
			}
		}
		
	}
}

