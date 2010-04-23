/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 4/22/2010
 * Time: 5:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;

namespace SQLiteHelper
{
	/// <summary>
	/// Description of DumpDataSet.
	/// </summary>
	public class DumpDataSet : System.Data.DataSet
	{
		public DumpDataSet()
		{
			DataTable dt = new DataTable("");
		}
	}
}
