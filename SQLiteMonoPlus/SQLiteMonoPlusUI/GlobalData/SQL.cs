using System;

namespace SQLiteMonoPlusUI.GlobalData
{
	static class SQL
	{
        public const string ConnectionsGet = "SELECT ConnectionID, ConnectionName, FilePath, Password, Pooling, MaxPooling, AddedDate, LastUsedDate FROM tb_Connections ORDER BY LastUsedDate DESC, ConnectionName;";
        public const string ConnectionAdd = "INSERT INTO tb_Connections(ConnectionName, FilePath, Password, Pooling, MaxPooling) VALUES (@ConnectionName, @FilePath, @Password, @Pooling, @MaxPooling); SELECT last_insert_rowid();";
        public const string ConnectionUpdate = "UPDATE tb_Connections SET ConnectionName = @ConnectionName, FilePath = @FilePath, Password = @Password, Pooling = @Pooling, MaxPooling = @MaxPooling, LastUsedDate = (DATETIME('now')) WHERE ConnectionID = @ConnectionID;";
        public const string ConnectionDelete = "DELETE FROM tb_Connections WHERE ConnectionID = @ConnectionID;";
		// this will need a union
		public const string TablesGet = "" +
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

