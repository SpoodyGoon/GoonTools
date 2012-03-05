/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/28/2012
 * Time: 2:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SQLiteMonoPlusUI.Schema
{
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
