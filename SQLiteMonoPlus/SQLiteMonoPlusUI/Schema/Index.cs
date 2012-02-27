using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Index
	{
		public string IndexName = string.Empty;
		public string IndexTable = string.Empty;
		public string SQL = string.Empty;
		public bool Unique = false;
		public Index (string name, string sql, string tbl_name) : base()
		{
			IndexName = name;
			SQL = sql;
			IndexTable = tbl_name;
			Unique = SQL.Trim().StartsWith("CREATE UNIQUE INDEX", StringComparison.OrdinalIgnoreCase);
		}
		
		public Index (string name, string sql, string tbl_name, bool unique )
		{
			IndexName = name;
			SQL = sql;
			IndexTable = tbl_name;
			Unique = unique;
		}
	}
}

