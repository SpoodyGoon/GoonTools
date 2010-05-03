/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 5/3/2010
 * Time: 10:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ThreadExample
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnBrowseImportClick(object sender, EventArgs e)
		{
			FolderBrowserDialog fd = new FolderBrowserDialog();
			if(fd.ShowDialog() == DialogResult.OK)
			{
				txtImportFolder.Text = fd.SelectedPath;
			}
		}
		
		void BtnBrowseExportClick(object sender, EventArgs e)
		{			
			FolderBrowserDialog fd = new FolderBrowserDialog();
			if(fd.ShowDialog() == DialogResult.OK)
			{
				txtExportFolder.Text = fd.SelectedPath;
			}
		}
		
		void BtnBrowseFontClick(object sender, EventArgs e)
		{
			FontDialog fd  = new FontDialog();
			if(fd.ShowDialog() == DialogResult.OK)
			{
				txtFont.Text = fd.Font.ToString();
			}
		}
		
		void TsExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
