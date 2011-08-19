using System;

namespace SQLiteMonoPlusUI.GlobalData
{
	static class SQL
	{
		// this will need a union
		public const string SchemaGet = "" +
			"SELECT " +
			"	name AS ObjectName, " +
			"	tbl_name AS TableName, " +
			"	sql AS SQL " +
			"	CASE LOWER(type) WHEN 'table' THEN 1 WHEN 'index' THEN 2 WHEN 'view' THEN 3 ELSE 4 END as SortOrder" +
			"FROM " +
			"	sqlite_master " +
			"WHERE " +
			"	name NOT LIKE 'sqlite_%'" +
			"ORDER BY " +
			"	SortOrder, tbl_name, name;";
	}
}

