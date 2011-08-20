using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Index
	{
		public Table PKTable;
		public string IndexName = string.Empty;
		public bool Unique = false;
		public Index ()
		{
		}
	}
}

