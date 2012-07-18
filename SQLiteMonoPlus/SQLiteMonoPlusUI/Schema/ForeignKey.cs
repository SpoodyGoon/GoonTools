using System;
namespace SQLiteMonoPlusUI.Schema
{
	public class ForeignKey
	{
		public string ForeignKeyName = string.Empty;
		public Table PKTable;
		public Column PKColumn;
		public Table FKTable;
		public Column FKColumn;
		public ForeignKeyAction OnUpdate = ForeignKeyAction.NoAction;
		public ForeignKeyAction OnDelete = ForeignKeyAction.NoAction;
		public bool Deferrable = false;
		public bool InitiallyDeferred = false;
		public ForeignKey ()
		{
		}
	}
	// test test
	public enum ForeignKeyAction
	{
		NoAction, 
		Restrict, 
		SetNull, 
		SetDefault,
		Cascade
	}
}

