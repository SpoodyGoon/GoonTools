using System;

namespace SQLiteMonoPlus.Data.Schema
{
	static class AdminSQL
	{
        
		// this will need a union
		public const string TablesGet = " " +
			"SELECT " +
			"	name AS ObjectName, " +
			"	tbl_name AS TableName, " +
			"	sql AS SQL, " +
			"	LOWER(type) AS ObjectType, " +
			"	CASE LOWER(type) WHEN 'table' THEN 1 WHEN 'index' THEN 2 WHEN 'view' THEN 3 ELSE 4 END as SortOrder " +
			"FROM " +
			"	sqlite_master " +
			"WHERE " +
			"	name NOT LIKE 'sqlite_%' " +
			"ORDER BY " +
			"	SortOrder, tbl_name, name; ";
	}

	static class Pragma
	{
        public const string PragmaBase = "PRAGMA [PragmaName];";
        public const string TableInfo = "PRAGMA table_info('[TableName]');";
        public const string IndexInfo = "PRAGMA index_info('[IndexName]');";
        public const string IndexList = "PRAGMA index_list('[TableName]');";
		public const string ForeignKeys = "PRAGMA foreign_keys;";
		public const string ForeignKeyList = "PRAGMA foreign_key_list('[TableName]');";
	}
}

