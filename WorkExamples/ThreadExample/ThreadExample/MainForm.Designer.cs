/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 5/3/2010
 * Time: 10:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ThreadExample
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.numMaxHeight = new System.Windows.Forms.NumericUpDown();
			this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDisplayText = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtFont = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnBrowseExport = new System.Windows.Forms.Button();
			this.btnBrowseImport = new System.Windows.Forms.Button();
			this.txtExportFolder = new System.Windows.Forms.TextBox();
			this.txtImportFolder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsExit = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMaxHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.numMaxHeight);
			this.panel1.Controls.Add(this.numMaxWidth);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtDisplayText);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.txtFont);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.btnBrowseExport);
			this.panel1.Controls.Add(this.btnBrowseImport);
			this.panel1.Controls.Add(this.txtExportFolder);
			this.panel1.Controls.Add(this.txtImportFolder);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(910, 231);
			this.panel1.TabIndex = 0;
			// 
			// numMaxHeight
			// 
			this.numMaxHeight.Location = new System.Drawing.Point(363, 178);
			this.numMaxHeight.Maximum = new decimal(new int[] {
									5000,
									0,
									0,
									0});
			this.numMaxHeight.Name = "numMaxHeight";
			this.numMaxHeight.Size = new System.Drawing.Size(95, 20);
			this.numMaxHeight.TabIndex = 23;
			this.numMaxHeight.Value = new decimal(new int[] {
									650,
									0,
									0,
									0});
			// 
			// numMaxWidth
			// 
			this.numMaxWidth.Location = new System.Drawing.Point(120, 178);
			this.numMaxWidth.Maximum = new decimal(new int[] {
									5000,
									0,
									0,
									0});
			this.numMaxWidth.Name = "numMaxWidth";
			this.numMaxWidth.Size = new System.Drawing.Size(95, 20);
			this.numMaxWidth.TabIndex = 22;
			this.numMaxWidth.Value = new decimal(new int[] {
									650,
									0,
									0,
									0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(36, 185);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Max Width:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(279, 185);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Max Height:";
			// 
			// txtDisplayText
			// 
			this.txtDisplayText.Location = new System.Drawing.Point(120, 149);
			this.txtDisplayText.Name = "txtDisplayText";
			this.txtDisplayText.Size = new System.Drawing.Size(500, 20);
			this.txtDisplayText.TabIndex = 19;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(29, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Display Text:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(545, 121);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "Browse...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.BtnBrowseFontClick);
			// 
			// txtFont
			// 
			this.txtFont.Location = new System.Drawing.Point(120, 123);
			this.txtFont.Name = "txtFont";
			this.txtFont.Size = new System.Drawing.Size(408, 20);
			this.txtFont.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(66, 126);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Font:";
			// 
			// btnBrowseExport
			// 
			this.btnBrowseExport.Location = new System.Drawing.Point(545, 89);
			this.btnBrowseExport.Name = "btnBrowseExport";
			this.btnBrowseExport.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseExport.TabIndex = 14;
			this.btnBrowseExport.Text = "Browse...";
			this.btnBrowseExport.UseVisualStyleBackColor = true;
			this.btnBrowseExport.Click += new System.EventHandler(this.BtnBrowseExportClick);
			// 
			// btnBrowseImport
			// 
			this.btnBrowseImport.Location = new System.Drawing.Point(545, 58);
			this.btnBrowseImport.Name = "btnBrowseImport";
			this.btnBrowseImport.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseImport.TabIndex = 13;
			this.btnBrowseImport.Text = "Browse...";
			this.btnBrowseImport.UseVisualStyleBackColor = true;
			this.btnBrowseImport.Click += new System.EventHandler(this.BtnBrowseImportClick);
			// 
			// txtExportFolder
			// 
			this.txtExportFolder.Location = new System.Drawing.Point(120, 91);
			this.txtExportFolder.Name = "txtExportFolder";
			this.txtExportFolder.Size = new System.Drawing.Size(408, 20);
			this.txtExportFolder.TabIndex = 12;
			// 
			// txtImportFolder
			// 
			this.txtImportFolder.Location = new System.Drawing.Point(120, 60);
			this.txtImportFolder.Name = "txtImportFolder";
			this.txtImportFolder.Size = new System.Drawing.Size(408, 20);
			this.txtImportFolder.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Import Folder:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Export Folder:";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsExit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(908, 36);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsExit
			// 
			this.tsExit.Image = ((System.Drawing.Image)(resources.GetObject("tsExit.Image")));
			this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsExit.Name = "tsExit";
			this.tsExit.Size = new System.Drawing.Size(29, 33);
			this.tsExit.Text = "Exit";
			this.tsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsExit.Click += new System.EventHandler(this.TsExitClick);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.statusStrip1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 231);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(910, 359);
			this.panel2.TabIndex = 1;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.StatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 335);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(908, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(46, 17);
			this.StatusLabel.Text = "Inactive";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(910, 590);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Threading Example";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMaxHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripButton tsExit;
		private System.Windows.Forms.NumericUpDown numMaxWidth;
		private System.Windows.Forms.NumericUpDown numMaxHeight;
		private System.Windows.Forms.TextBox txtFont;
		private System.Windows.Forms.TextBox txtDisplayText;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtExportFolder;
		private System.Windows.Forms.TextBox txtImportFolder;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnBrowseImport;
		private System.Windows.Forms.Button btnBrowseExport;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
	}
}
