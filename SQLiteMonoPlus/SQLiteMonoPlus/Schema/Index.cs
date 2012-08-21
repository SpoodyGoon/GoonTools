using System;
namespace SQLiteMonoPlus.Schema
{
	public class Index
	{
		public string IndexName = string.Empty;
		public string IndexTable = string.Empty;
		public string SQL = string.Empty;
		public bool Unique = false;
		public System.Collections.ArrayList IndexColumns = new System.Collections.ArrayList();
		public Index (string name, string sql,string table_name) : base()
		{
			IndexName = name;
			SQL = sql;
			IndexTable = table_name;
			Unique = SQL.Trim().StartsWith("CREATE UNIQUE INDEX", StringComparison.OrdinalIgnoreCase);
		}
		
		public Index (string name, string sql,string table_name, bool unique )
		{
			IndexName = name;
			SQL = sql;
			IndexTable = table_name;
			Unique = unique;
		}
		
		public void AddColumnInfo(IndexColumn idxColumn)
		{
			IndexColumns.Add(idxColumn);
		}
	}
	
	public struct IndexColumn
	{
		public Column ColumnIndex;
		public SortDirection Sort;
		public bool Unique;
		public IndexColumn(Column column, SortDirection sort, bool unique)
		{
			ColumnIndex = column;
			Sort = sort;
			Unique = unique;
		}
	}
}

