// 
// UpdateTimeCombo.cs
//  
// Author:
//       Andy York <goontools@brdstudio.net>
// 
// Copyright (c) 2009 Andy York
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using so = System.IO;
using System.Data;
using Gtk;

namespace GUPdotNET
{
	
	[System.ComponentModel.ToolboxItem(true)]
	public class UpdateTimeCombo : Gtk.ComboBox
	{
		private Gtk.ListStore lsTimeDisplay = new Gtk.ListStore(typeof(int), typeof(string));
		private int _Hours;
		private string _TimeDisplay;
		private int _SearchHours;
		private string _SearchTimeDisplay;
		private bool _IsLoading = false;
		public UpdateTimeCombo()
		{
		}
		
		private void Build()
		{
			LoadUpdateTime();
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			this.PackStart(ct, true);
			this.AddAttribute(ct, "text", 1);
			this.Model = lsTimeDisplay;
			Gtk.TreeIter iter;
			if(lsTimeDisplay.GetIterFirst(out iter))
				this.SetActiveIter(iter);
		}
		
		private void LoadUpdateTime()
		{
			try
			{
				string strXML = so.Path.Combine(Common.AppPath , "TimeValues.xml");
				_IsLoading = true;
				lsTimeDisplay.Clear();
				if(System.IO.File.Exists(strXML))
				{
					DataSet ds = new DataSet();
					ds.ReadXml(strXML);
					for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						lsTimeDisplay.AppendValues(Convert.ToInt32(ds.Tables[0].Rows[i]["Hours"]), ds.Tables[0].Rows[i]["TimeDisplay"].ToString());	
					}
					ds.Clear();
					ds.Dispose();
				}
				_IsLoading = false;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnRealized ()
		{
			Build();
			this.WidthRequest = 185;
			this.HeightRequest = 30;
			base.OnRealized ();
		}

		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnChanged ()
		{
			try
			{
				if(!_IsLoading)
				{
					Gtk.TreeIter iter;
					this.GetActiveIter(out iter);											
					_Hours = (int)lsTimeDisplay.GetValue(iter, 0);
					_TimeDisplay =  (string)lsTimeDisplay.GetValue(iter, 1);					
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			base.OnChanged ();
		}

		
		#region Public Properties
		
		public string TimeDisplay
		{
			get{return _TimeDisplay;}
		}
		
		public int Hours
		{
			get{return _Hours;}
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public void SetTimeDisplay(string timedisplay)
		{
			_SearchTimeDisplay = timedisplay;
			lsTimeDisplay.Foreach(new TreeModelForeachFunc(ForeachTimeDisplay));
			
		}
		
		public void SetHours(int hours)
		{
			_SearchHours = hours;
			lsTimeDisplay.Foreach(new TreeModelForeachFunc(ForeachHours));
		}
		
		#endregion Public Methods
		
		private bool ForeachTimeDisplay(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchTimeDisplay == lsTimeDisplay.GetValue(iter, 1).ToString())
			{
				_TimeDisplay = lsTimeDisplay.GetValue(iter, 1).ToString();
				_Hours = Convert.ToInt32(lsTimeDisplay.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
		
		private bool ForeachHours(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchHours == Convert.ToInt32(lsTimeDisplay.GetValue(iter, 0)))
			{
				_TimeDisplay = lsTimeDisplay.GetValue(iter, 1).ToString();
				_Hours = Convert.ToInt32(lsTimeDisplay.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
	}
}
