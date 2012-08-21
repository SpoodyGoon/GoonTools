using System;

namespace SQLiteMonoPlusUI.UI.Data.SQL
{
	internal static class Connection
	{
		internal const string ConnectionsGet = "SELECT ConnectionID, ConnectionName, FilePath, Password, Pooling, MaxPooling, AddedDate, LastUsedDate FROM tb_Connections ORDER BY LastUsedDate DESC, ConnectionName;";
		internal const string ConnectionAdd = "INSERT INTO tb_Connections(ConnectionName, FilePath, Password, Pooling, MaxPooling) VALUES (@ConnectionName, @FilePath, @Password, @Pooling, @MaxPooling); SELECT last_insert_rowid();";
		internal const string ConnectionUpdate = "UPDATE tb_Connections SET ConnectionName = @ConnectionName, FilePath = @FilePath, Password = @Password, Pooling = @Pooling, MaxPooling = @MaxPooling, LastUsedDate = (DATETIME('now')) WHERE ConnectionID = @ConnectionID;";
		internal const string ConnectionDelete = "DELETE FROM tb_Connections WHERE ConnectionID = @ConnectionID;";
	}
}

