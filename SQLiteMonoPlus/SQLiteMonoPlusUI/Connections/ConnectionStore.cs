using System;
using System.Data;
using Mono.Data.Sqlite;

namespace SQLiteMonoPlusUI
{
	public class ConnectionStore : Gtk.ListStore, Gtk.TreeModel
	{
		private string _DBFilePath = string.Empty;
		public ConnectionStore (string FilePath) : base(typeof(Connection))
		{
			if(!string.IsNullOrEmpty(FilePath))
			{
				_DBFilePath = FilePath;
			}
		}
		
		#region Public Methods
		
		public void Load(string FilePath)
		{			
			_DBFilePath = FilePath;
			DataTable dt = new DataTable();
			dt.ReadXml(_SaveFile);
		}
		
		public void Load()
		{	
//			if(string.IsNullOrEmpty(_SaveFile))
//				throw new System.IO.FileLoadException("Unable to save Connection data file path not set");
//			
//			DataTable dt = new DataTable();
//			dt.ReadXml(_SaveFile);
//			Connection c = null;
//			for(int i = 0; i < dt.Rows.Count; i++)
//			{
//				c = new Connection((DataRow)dt.Rows[i]);
//				this.AppendValues(c);
//			}
		}
		
		public void Refresh()
		{
			
		}
		
		public void Save()
		{
			if(string.IsNullOrEmpty(_SaveFile))
				throw new System.IO.FileLoadException("Unable to save Connection data file path not set");
			
			
		}
		
		#endregion Public Methods
	}
}

