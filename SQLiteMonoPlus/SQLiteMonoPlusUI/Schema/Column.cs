using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Column
	{
		public string ColumnName = string.Empty;
		public SQLiteDataType DataType = SQLiteDataType.None;
		public int Size = 50;
		public bool PrimaryKey = false;
		public bool ForeingKey = false;
		public bool AllowNull = true;
		public object Default = "";
		public Column ()
		{
		}
	}
}

