using System;

namespace SQLiteMonoPlus
{
	public enum SQLiteDataType
	{
		Integer,
		Bool,
		Varchar,
		Double,
		Text,
		Blob,
		Real,
		DateTime,
		None
	}

	public enum ForeignKeyAction
	{
		NoAction, 
		Restrict, 
		SetNull, 
		SetDefault,
		Cascade
	}

	public enum SortDirection
	{
		ASC,
		DESC
	}
	
	public enum DBObjectType
	{
		Database,
		Table,
		View,
		Column,
		Index,
		Label
	}
}

