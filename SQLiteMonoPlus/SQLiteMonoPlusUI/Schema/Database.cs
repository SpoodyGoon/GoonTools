using System;
using System.Collections;
using System.Collections.Generic;

namespace SQLiteMonoPlusUI.Schema
{
	public class Database
	{
		private string _DatabaseFile = string.Empty;
		public Dictionary<string, string> Pragmas = new Dictionary<string, string> ();
		public TableCollection Tables = new TableCollection ();
		public Database (string DBFile)
		{
			_DatabaseFile = DBFile;
		}
	}

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
}

