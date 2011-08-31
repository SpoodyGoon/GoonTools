using System;
using System.Data;
using System.Collections.Generic;

namespace ThreadingExample.GlobalData
{
    class SaveDataTable : System.Data.DataTable
    {
        public SaveDataTable() 
        {
            this.TableName = "SaveData";
            this.Columns.Add(new DataColumn("InputFolderPath", typeof(string)));
            this.Columns.Add(new DataColumn("OutputFolderPath", typeof(string)));
            DataColumn dc = new DataColumn("WatermarkText", typeof(string));
            dc.DefaultValue = "Watermark Text";
            this.Columns.Add(dc);
            dc = new DataColumn("FontName", typeof(string));
            dc.DefaultValue = "Arial";
            this.Columns.Add(dc);
            dc = new DataColumn("FontSize", typeof(decimal));
            dc.DefaultValue = 12.0f;
            this.Columns.Add(dc);
            dc = new DataColumn("FontBold", typeof(bool));
            dc.DefaultValue = true;
            this.Columns.Add(dc);
            dc = new DataColumn("FontItalic", typeof(bool));
            dc.DefaultValue = false;
            this.Columns.Add(dc);
            dc = new DataColumn("FontColor", typeof(string));
            dc.DefaultValue = "#000000";
            this.Columns.Add(dc);
            dc = new DataColumn("ResizeImages", typeof(bool));
            dc.DefaultValue = false;
            this.Columns.Add(dc);
            dc = new DataColumn("MaxWidth", typeof(int));
            dc.DefaultValue = 800;
            this.Columns.Add(dc);
            dc = new DataColumn("MaxHeight", typeof(int));
            dc.DefaultValue = 600;
            this.Columns.Add(dc);
            dc = new DataColumn("OutputCount", typeof(int));
            dc.DefaultValue = 100;
            this.Columns.Add(dc);
            dc = new DataColumn("MaxThreads", typeof(int));
            dc.DefaultValue = 10;
            this.Columns.Add(dc);
        }
    }
}
