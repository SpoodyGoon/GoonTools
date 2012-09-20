
using System;
using Gtk;
using SQLiteMonoPlus;
using libGlobalTools;

namespace SQLiteMonoPlusUI
{
    [System.ComponentModel.ToolboxItem(true)]
    public class ConnectionComboBoxEntry : Gtk.ComboBoxEntry
    {
        private Nullable<int> _SearchConnectionID = null;
        private string _SearchConnectionName = null;
        private DateTime _LastLoad = DateTime.Now;
        public Connection CurrentConnection = null;

        public ConnectionComboBoxEntry ()
        {
            Build ();
        }

        private void Build ()
        {
            try
            {
                // set up the sell
                Gtk.CellRendererText cellConnectionName = new Gtk.CellRendererText ();
                cellConnectionName.Editable = false;
                cellConnectionName.Sensitive = true;
                this.PackStart (cellConnectionName, true);
                this.SetCellDataFunc (cellConnectionName, new Gtk.CellLayoutDataFunc (RenderConnectionName));
				this.Model = (Gtk.TreeModel)GlobalData.StaticDataAccess.RecentConnections;
                _LastLoad = DateTime.Now;
                this.QueueDraw ();
            } catch (Exception ex)
            {   
                Common.HandleError (ex);
            }
        }
		
        public void Refresh ()
        {
			GlobalData.StaticDataAccess.RecentConnections.Refresh ();
            _LastLoad = DateTime.Now;
            this.ShowAll ();
        }

		#region Cell Data Functions

        private void RenderConnectionName (Gtk.CellLayout celllayout, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
        {
            Connection s = (Connection)model.GetValue (iter, 0);
            (cell as Gtk.CellRendererText).Text = s.ConnectionName;
        }

		#endregion Cell Data Functions

		#region Public Properties

        public string ConnectionName
        {
            set
            {
                Gtk.TreeIter iter = Gtk.TreeIter.Zero;
                if (this.Model.GetIterFirst (out iter))
                    this.SetActiveIter (iter);
				
                CurrentConnection = null;
                _SearchConnectionName = value;
                this.Model.Foreach (new TreeModelForeachFunc (ForeachConnectionName));
            }
            get { return CurrentConnection.ConnectionName; }
        }

        public Nullable<int> ConnectionID
        {
            set
            {
                Gtk.TreeIter iter = Gtk.TreeIter.Zero;
                if (this.Model.GetIterFirst (out iter))
                    this.SetActiveIter (iter);
				
                CurrentConnection = null;
                _SearchConnectionID = value;
                this.Model.Foreach (new TreeModelForeachFunc (ForeachConnectionID));
            }
            get { return CurrentConnection.ConnectionID; }
        }

		#endregion Public Properties

		#region Search Functions Related To Value Setting

        private bool ForeachConnectionName (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection tmpCN = (Connection)this.Model.GetValue (iter, 0);
            if (_SearchConnectionName == tmpCN.ConnectionName)
            {
                CurrentConnection = tmpCN;
                this.SetActiveIter (iter);
                return true;
            }
            return false;
        }

        private bool ForeachConnectionID (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
        {
            Connection tmpCN = (Connection)this.Model.GetValue (iter, 0);
            if (_SearchConnectionID == Convert.ToInt32 (tmpCN.ConnectionID))
            {
                CurrentConnection = tmpCN;
                this.SetActiveIter (iter);
                return true;
            }
            return false;
        }

		#endregion Search Functions Related To Value Setting
		
        protected override void OnChanged ()
        {
            Gtk.TreeIter iter = Gtk.TreeIter.Zero;
            if (this.GetActiveIter (out iter))
            {
                Connection tmpCN = (Connection)this.Model.GetValue (iter, 0);
                if (!string.IsNullOrEmpty (tmpCN.ConnectionName))
                {
                    if (System.IO.File.Exists (tmpCN.FilePath))
                    {
                        CurrentConnection = tmpCN;
						this.Entry.Text = CurrentConnection.ConnectionName;
                    } else
                    {						           
                        string strTmp = "Unable to find SQLite database file from recent connections.\n\nWould you like to remove this file from the saved connections?";
                        Gtk.MessageDialog md = new Gtk.MessageDialog (null, DialogFlags.Modal, MessageType.Question, Gtk.ButtonsType.YesNo, false, strTmp, "Database File Missing");
                        if ((Gtk.ResponseType)md.Run () == Gtk.ResponseType.Yes)
                        {
							((SQLiteMonoPlusUI.GlobalData.ConnectionStore)this.Model).DeleteConnection(iter);
                        }							
                        md.Destroy ();
                    }
						
                }
            }
            this.ShowNow();
            this.QueueDraw();
            base.OnChanged ();
        }
    }
}


