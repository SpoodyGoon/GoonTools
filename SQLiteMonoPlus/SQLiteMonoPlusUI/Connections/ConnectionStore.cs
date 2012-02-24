using System;
using System.IO;
using System.Data;
using Gtk;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI.GlobalData
{
	public class ConnectionStore : Gtk.ListStore, Gtk.TreeModel
	{
        private ConnectionSaveFile _SaveFile = new ConnectionSaveFile();
        public bool Modified = false;
        
        #region Search Paramaters
        
		private int _SearchID = -1;
		private string _SearchName = string.Empty;
		private string _SearchFilePath = string.Empty;
		private Connection _SearchConnection = null;
		
        #endregion Search Paramaters
        
		public ConnectionStore () : base(typeof(Connection))
		{
            
		}
		
		#region Load/Save Methods
		
		public void Load()
        {
            try
            {
            	if(Modified)
            	{
            		Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Warning, Gtk.ButtonsType.YesNo, false, GlobalTools.Constants.ConnectionMessage.SaveWarning, GlobalTools.Constants.ConnectionMessage.WarningTitle);
            		if((Gtk.ResponseType)md.Run() == Gtk.ResponseType.Yes)
            		{
            			Save();
            		}
                	md.Destroy();
            	}
            	
            	// See if the Connection save file exists
            	if(File.Exists(Common.EnvData.ConnectionFilePath))
            	{	
            		// Load the save file from xml
            		_SaveFile.ReadXml(Common.EnvData.ConnectionFilePath);
	                Connection c;
	                foreach(DataRow dr in _SaveFile.Rows)
	                {
	                    c = new Connection(dr);
	                    this.AppendValues(c);
	                }
	                
	                // once the store is loaded we can clear the save file
	                _SaveFile.Clear();
            	}
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
        }

        public void Refresh()
        {
            Load();
        }
        
        public void Save()
        {
        	try
        	{       
        		if(_SaveFile.Rows.Count > 0)
        			_SaveFile.Clear();
        		
        		// Loop through the TreeModel and Update the datatable
        		// before saving it to XML
            	this.Foreach(new TreeModelForeachFunc(SaveLoop));
        	}
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
        }
        
        private bool SaveLoop(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection cn = (Connection)this.GetValue(iter, 0);
        	DataRow dr = _SaveFile.NewRow();
        	dr["ConnectionName"] = cn.ConnectionName;
        	dr["FilePath"] = cn.FilePath;
        	dr["Password"] = cn.Password;
        	dr["Pooling"] = cn.Pooling;
        	dr["MaxPooling"] = cn.MaxPoolSize;
        	dr["AddedDate"] = cn.AddedDate;
        	dr["LastUsedDate"] = cn.LastUsedDate;
        	_SaveFile.Rows.Add(dr);
            return false;
        }
		
		#endregion Load/Save Methods
		
		#region Connection Lookup
		
        public Connection Find(int ID)
        {        	
        	_SearchConnection = null;
            _SearchID = ID;
            this.Foreach(new TreeModelForeachFunc(ForeachID));
            return _SearchConnection;
        }
        
        private bool ForeachID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection cn = (Connection)this.GetValue(iter, 0);
            if (_SearchID.Equals((int)cn.ConnectionID))
            {
                _SearchConnection = cn;
                return true;
            }
            return false;
        }
		
        public Connection Find(string Name)
        {        	
        	_SearchConnection = null;
            _SearchName = Name;
            this.Foreach(new TreeModelForeachFunc(ForeachName));
            return _SearchConnection;
        }
        
        private bool ForeachName(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection cn = (Connection)this.GetValue(iter, 0);
            if (_SearchName.Equals(cn.ConnectionName, StringComparison.OrdinalIgnoreCase))
            {
                _SearchConnection = cn;
                return true;
            }
            return false;
        }
		
        public Connection FindFile(string FilePath)
        {        	
        	_SearchConnection = null;
            _SearchFilePath = FilePath;
            this.Foreach(new TreeModelForeachFunc(ForeachFilePath));
            return _SearchConnection;
        }
        
        private bool ForeachFilePath(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection cn = (Connection)this.GetValue(iter, 0);
            if (_SearchFilePath.Equals(cn.FilePath, StringComparison.OrdinalIgnoreCase))
            {
                _SearchConnection = cn;
                return true;
            }
            return false;
        }
		
		#endregion Connection Lookup
	}
}

