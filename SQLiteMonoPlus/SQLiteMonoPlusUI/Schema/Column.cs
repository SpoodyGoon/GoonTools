using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Column
	{
		public Nullable<int> CID = null;
		public string ColumnName = string.Empty;
		public SQLiteDataType DataType = SQLiteDataType.None;
		public int Size = 50;
		public bool PrimaryKey = false;
		public bool ForeingKey = false;
		public bool AllowNull = true;
		public object DefaultValue = "";
		public Column (int cid, string name, string type, bool allow_null, object default_value, bool primary_key) : base()
		{
			CID = cid;
			ColumnName = name;
			AllowNull = allow_null;
			DefaultValue = default_value;
			PrimaryKey = primary_key;
		}
		
		public Column (string name, string type, bool allow_null, object default_value, bool primary_key)
		{
		}
		
		public Column (string name, string type, bool allow_null, object default_value)
		{
		}
		
		public Column (string name, string type)
		{
		}
		
		public Column ()
		{
		}
	}
}

