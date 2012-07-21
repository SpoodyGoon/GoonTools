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
			SQL = sql.Replace(Environment.NewLine, "").Replace("\r", "").Replace("\n", "");
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
			int intTemp1 = SQL.LastIndexOf(')');
			int intTemp2 = SQL.IndexOf('(');
			string strTemp = SQL.Substring(SQL.IndexOf('('), SQL.LastIndexOf(')') - SQL.IndexOf('('));
			string[] strColumnSQL = strTemp.Split(new char[]{','});
			for(int i=0;i<strColumnSQL.Length;i++)
			{
				strColName = strColumnSQL[i].Substring(strColumnSQL[i].IndexOf("[") + 1, strColumnSQL[i].LastIndexOf("]") - 1);
				col = (Column)Columns[strColName];
				col.DataTypeDisplay = strColumnSQL[i].Trim();
			}
		}
		
	}
}

