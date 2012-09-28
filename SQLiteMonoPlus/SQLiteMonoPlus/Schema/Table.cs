using System;
namespace SQLiteMonoPlus.Schema
{
	public class Table
	{
		public Nullable<int> CID = null;
		public string TableName = string.Empty;
		public string SQL = string.Empty;
		public ColumnCollection Columns = new ColumnCollection();
		public ForeignKeyCollection ForeignKeys = new ForeignKeyCollection();
		public TriggerCollection Triggers = new TriggerCollection();
		public IndexCollection Indexes = new IndexCollection();
		public Table (string name, string sql) : base()
		{
			TableName = name;
			SQL = sql.Replace(Environment.NewLine, "").Replace("\r", "").Replace("\n", "");
		}
		
		public Table(string name)
		{
			TableName = name;
		}
		
		#region SQL Text Methods
		
		public string SQLScriptGet (ScriptToAction action)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			switch (action)
			{
				case ScriptToAction.Create:
					sb.Append(this.SQL);
					break;
				case ScriptToAction.Drop:
					sb.Append("DROP TABLE " + this.TableName + ";");
					break;
				case ScriptToAction.DropCreate:
					sb.Append("DROP TABLE " + this.TableName + ";" + Environment.NewLine);
					sb.Append(this.SQL);
					break;
				case ScriptToAction.Select:
					sb.Append("SELECT " + Environment.NewLine + SQLScriptColumnListGet() + "FROM " + Environment.NewLine + "    [" + this.TableName + "];");
					break;
				case ScriptToAction.Insert:
					sb.Append("INSERT INTO [" + this.TableName + "] " + Environment.NewLine + "(" + Environment.NewLine + SQLScriptColumnListGet() + ")" + Environment.NewLine + "VALUES");
					sb.Append(Environment.NewLine  + "(");
					sb.Append(SQLScriptColumnListGet().Replace("[", "<").Replace("]", ">"));
					sb.Append(Environment.NewLine + ")");
					break;
				case ScriptToAction.Update:
					break;
				case ScriptToAction.Delete:
					sb.Append("DELETE FROM " + Environment.NewLine + "    [" + this.TableName + "]" + Environment.NewLine + "WHERE " + Environment.NewLine + "    <Search Conditions>;");
					break;
			}
			return sb.ToString();
		}

		private string SQLScriptColumnListGet ()
		{
			int intColumnCount = this.Columns.Count;
			int index=0;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			foreach(Column col in this.Columns)
			{
				sb.Append("    [" + col.ColumnName + "]");
				
				if(index < intColumnCount)
					sb.Append("," + Environment.NewLine); 
				else
					sb.Append(Environment.NewLine);
				
				index++;
			}
			return sb.ToString();
		}

		#endregion SQL Text Methods
		
		// TODO: run though the sql and populate a 
		// display text for each column
		public void PopulateColumnDescriptions()
		{
			Column col;
			string strColName = null;
			int intTemp1 = SQL.LastIndexOf(')');
			int intTemp2 = SQL.IndexOf('(');
			string strTemp = SQL.Substring(SQL.IndexOf('('), SQL.LastIndexOf(')') - SQL.IndexOf('('));
			string[] strColumnSQL = strTemp.Split(new char[]{','});
			for(int i=0;i<strColumnSQL.Length;i++)
			{
				strColName = strColumnSQL[i].Substring(strColumnSQL[i].IndexOf("[") + 1, strColumnSQL[i].LastIndexOf("]") - 1);
				col = (Column)Columns[strColName];
				col.DataTypeDisplay = strColumnSQL[i].Trim();
			}
		}
		
	}
}

