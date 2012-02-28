/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/28/2012
 * Time: 10:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SQLiteMonoPlusUI.Schema
{
	/// <summary>
	/// Description of Trigger.
	/// </summary>
	public class Trigger
	{
		public string TriggerName = string.Empty;
		public string TableName;
		public string SQL = string.Empty;
		public Trigger(string name, string sql, string table_name)
		{
			TriggerName = name;
			TableName = table_name;
			SQL = sql;
		}
	}
}
