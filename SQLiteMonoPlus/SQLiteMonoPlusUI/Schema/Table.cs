using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class Table
	{
		public string TableName = "tb_NewTable";
		public ColumnCollection Columns = new ColumnCollection();
		public Table (string Name) 
		{
			TableName = Name;
		}
		
		public Table()
		{
		}
		
		
	}
}

