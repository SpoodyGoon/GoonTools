using System;
namespace SQLiteMonoPlus.Schema
{
	public class ForeignKey
	{
		public string ForeignKeyName = string.Empty;
		public Column PKColumn;
		public Table FKTable;
		public Column FKColumn;
		public ForeignKeyAction OnUpdate = ForeignKeyAction.NoAction;
		public ForeignKeyAction OnDelete = ForeignKeyAction.NoAction;
		public bool Deferrable = false;
		public bool InitiallyDeferred = false;
		public ForeignKey() :base()
		{
		}

		public ForeignKey (Column pkcolumn, Table fktable, Column fkcolumn, ForeignKeyAction onupdate, ForeignKeyAction ondelete) 
		{
		}

		public ForeignKey (string pkcolumn, string fktable, string fkcolumn, string onupdate, string ondelete)
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

