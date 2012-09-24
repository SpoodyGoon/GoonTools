using System;
using System.IO;
using System.Data;
using Gtk;
using SQLiteMonoPlus;
using libGlobalTools;

namespace SQLiteMonoPlusUI.GlobalData
{
	public class ConnectionStore : Gtk.ListStore, Gtk.TreeModel
	{
		private ConnectionSaveFile _SaveFile;
		public bool Modified = false;
        
        #region Search Paramaters
        
		private int _SearchID = -1;
		private string _SearchName = string.Empty;
		private string _SearchFilePath = string.Empty;
		private Connection _SearchConnection = null;
		private Gtk.TreeIter _SearchIter = Gtk.TreeIter.Zero;
		private const string _SaveFileName = "RecentConnections.xml";
		private string _SaveFileFullPath = "";
		
        #endregion Search Paramaters
        
		public ConnectionStore () : base(typeof(Connection))
		{
			_SaveFileFullPath = Path.Combine (Common.LocalSystem.UserDataPath, _SaveFileName);
		}
		 
		public void AddConnection (Connection conn)
		{
			if (((Connection)this.FindFile (conn.FilePath)) == null)
			{
				this.AppendValues (conn);
			}
		}
		
		public void DeleteConnection (Gtk.TreeIter iter)
		{
			try
			{ 
				this.Remove (ref iter);
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}
		
		public void DeleteConnection (Connection cn)
		{
			try
			{         
				if (cn.ConnectionID != null)
				{
					_SearchIter = Gtk.TreeIter.Zero;     	
					_SearchConnection = null;
					_SearchID = (int)cn.ConnectionID;
					this.Foreach (new TreeModelForeachFunc (ForeachID));
					if (!_SearchIter.Equals (Gtk.TreeIter.Zero))
					{
						this.Remove (ref _SearchIter);
						this.Save ();
					}
				}
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}
		
		#region Load/Save Methods
		
		public void Load ()
		{
			try
			{
				/*
            	if(Modified)
            	{
            		Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Warning, Gtk.ButtonsType.YesNo, false, Constants.ConnectionMessage.SaveWarning, Constants.ConnectionMessage.WarningTitle);
            		if((Gtk.ResponseType)md.Run() == Gtk.ResponseType.Yes)
            		{
            			Save();
            		}
                	md.Destroy();
            	}
            	*/
            	
				this.Clear ();
				// See if the Connection save file exists
				if (File.Exists (_SaveFileFullPath))
				{	
					_SaveFile = new ConnectionSaveFile ();
					// Load the save file from xml
					_SaveFile.ReadXml (_SaveFileFullPath);
					SQLiteMonoPlus.Connection cn = new SQLiteMonoPlus.Connection ("");
					this.AppendValues (cn);
					DataView dv = _SaveFile.DefaultView;
					dv.Sort = "LastUsedDate DESC";
					foreach (DataRowView drv in dv)
					{
						cn = new SQLiteMonoPlus.Connection (Convert.ToInt32 (drv ["ConnectionID"]), drv ["ConnectionName"].ToString (), drv ["FilePath"].ToString ());
						cn.AddedDate = Convert.ToDateTime (drv ["AddedDate"]);
						cn.LastUsedDate = Convert.ToDateTime (drv ["LastUsedDate"]);
						this.AppendValues (cn);
					}
	                
					// once the store is loaded we can clear the save file
					dv.Dispose();
					_SaveFile.Clear();
				}
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}

		public void Refresh ()
		{
			Load ();
		}
        
		public void Save ()
		{
			try
			{       
				_SaveFile = new ConnectionSaveFile ();
        		
				// Loop through the TreeModel and Update the datatable
				// before saving it to XML
				this.Foreach (new TreeModelForeachFunc (SaveLoop));
				_SaveFile.WriteXml (_SaveFileFullPath);
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}
        
		private bool SaveLoop (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			Connection cn = (Connection)this.GetValue (iter, 0);
			if (!string.IsNullOrEmpty (cn.FilePath))
			{
				DataRow dr = _SaveFile.NewRow ();
				dr ["ConnectionName"] = cn.ConnectionName;
				dr ["FilePath"] = cn.FilePath;
				dr ["Password"] = cn.Password;
				dr ["Pooling"] = cn.Pooling;
				dr ["MaxPooling"] = cn.MaxPoolSize;
				dr ["AddedDate"] = cn.AddedDate;
				dr ["LastUsedDate"] = cn.LastUsedDate;
				_SaveFile.Rows.Add (dr);
			}
			return false;
		}
		
		#endregion Load/Save Methods
		
		#region Connection Lookup
		
		public Connection Find (int ID)
		{        	
			_SearchIter = Gtk.TreeIter.Zero;
			_SearchConnection = null;
			_SearchID = ID;
			this.Foreach (new TreeModelForeachFunc (ForeachID));
			return _SearchConnection;
		}
        
		private bool ForeachID (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			Connection cn = (Connection)this.GetValue (iter, 0);
			if (_SearchID.Equals ((int)cn.ConnectionID))
			{
				_SearchIter = iter;
				_SearchConnection = cn;
				return true;
			}
			return false;
		}
		
		public Connection Find (string Name)
		{          	
			_SearchIter = Gtk.TreeIter.Zero;      	
			_SearchConnection = null;
			_SearchName = Name;
			this.Foreach (new TreeModelForeachFunc (ForeachName));
			return _SearchConnection;
		}
        
		private bool ForeachName (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			Connection cn = (Connection)this.GetValue (iter, 0);
			if (_SearchName.Equals (cn.ConnectionName, StringComparison.OrdinalIgnoreCase))
			{
				_SearchIter = iter;
				_SearchConnection = cn;
				return true;
			}
			return false;
		}
		
		public Connection FindFile (string FilePath)
		{             	
			_SearchIter = Gtk.TreeIter.Zero;   	
			_SearchConnection = null;
			_SearchFilePath = FilePath;
			this.Foreach (new TreeModelForeachFunc (ForeachFilePath));
			return _SearchConnection;
		}
        
		private bool ForeachFilePath (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			Connection cn = (Connection)this.GetValue (iter, 0);
			if (_SearchFilePath.Equals (cn.FilePath, StringComparison.OrdinalIgnoreCase))
			{
				_SearchIter = iter;
				_SearchConnection = cn;
				return true;
			}
			return false;
		}
		
		#endregion Connection Lookup
	}
}

