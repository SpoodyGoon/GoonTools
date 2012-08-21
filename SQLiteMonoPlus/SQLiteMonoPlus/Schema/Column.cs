using System;
namespace SQLiteMonoPlus.Schema
{
	public class Column
	{
		public Nullable<int> CID = null;
		public string ColumnName = string.Empty;
		public SQLiteDataType DataType = SQLiteDataType.None;
		public string DataTypeDisplay = string.Empty;
		public int Size = 50;
		public bool PrimaryKey = false;
		public bool ForeingKey = false;
		public bool AllowNull = true;
		public object DefaultValue = null;
		public Column (int cid, string name, string type, bool allow_null, object default_value, bool primary_key) : base()
		{
			CID = cid;
			ColumnName = name;
			DataTypeDisplay = type;
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

		public string DisplayFormat {

			get
			{ 
				if(!this.PrimaryKey)
					return ColumnName + " (" + DataTypeDisplay + " ," + (AllowNull == true ? "null" : "not null") + ")";
				else
					return ColumnName + " (PK, " + DataTypeDisplay + " ," + (AllowNull == true ? "null" : "not null") + ")";
			}
		}
	}
}

