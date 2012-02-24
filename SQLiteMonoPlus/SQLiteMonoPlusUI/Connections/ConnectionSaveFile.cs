using System;
using System.Data;

namespace SQLiteMonoPlusUI.GlobalData
{
    public class ConnectionSaveFile : DataTable
    {
    	public ConnectionSaveFile() : base("Connections")
        {
            this.Columns.AddRange(new DataColumn[]
                                { 
                                        new DataColumn ("ConnectionID", typeof(int)),
                                        new DataColumn ("ConnectionName", typeof(string)),
                                        new DataColumn ("FilePath", typeof(string)),
                                        new DataColumn ("Password", typeof(string)),
                                        new DataColumn ("Pooling", typeof(bool)),
                                        new DataColumn ("MaxPooling", typeof(int)),
                                        new DataColumn ("AddedDate", typeof(DateTime)),
                                        new DataColumn ("LastUsedDate", typeof(DateTime))
                                });
            DataColumn dc = this.Columns["ConnectionID"];
            dc.AllowDBNull = false;
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dc = this.Columns["ConnectionName"];
            dc.AllowDBNull = false;
            dc.DefaultValue = "";
            dc = this.Columns["FilePath"];
            dc.AllowDBNull = false;
            dc.DefaultValue = "";
        }
    }
}
