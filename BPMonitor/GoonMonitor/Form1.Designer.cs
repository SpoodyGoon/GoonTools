namespace GoonMonitor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbBPMontor = new System.Windows.Forms.DataGridView();
            this.dsBPMonitor = new GoonMonitor.dsBPMonitor();
            this.dtBPMonitorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.entryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systolicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diastolicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heartRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBPMontor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBPMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBPMonitorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(648, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsNew
            // 
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(81, 35);
            this.tsNew.Text = "New Reading";
            this.tsNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbBPMontor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(648, 374);
            this.panel1.TabIndex = 2;
            // 
            // gbBPMontor
            // 
            this.gbBPMontor.AllowUserToAddRows = false;
            this.gbBPMontor.AllowUserToDeleteRows = false;
            this.gbBPMontor.AutoGenerateColumns = false;
            this.gbBPMontor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gbBPMontor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entryIDDataGridViewTextBoxColumn,
            this.colEdit,
            this.entryDateDataGridViewTextBoxColumn,
            this.systolicDataGridViewTextBoxColumn,
            this.diastolicDataGridViewTextBoxColumn,
            this.heartRateDataGridViewTextBoxColumn,
            this.colAverage,
            this.notesDataGridViewTextBoxColumn,
            this.archiveDataGridViewCheckBoxColumn});
            this.gbBPMontor.DataSource = this.dtBPMonitorBindingSource;
            this.gbBPMontor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBPMontor.Location = new System.Drawing.Point(5, 5);
            this.gbBPMontor.Name = "gbBPMontor";
            this.gbBPMontor.ReadOnly = true;
            this.gbBPMontor.Size = new System.Drawing.Size(638, 364);
            this.gbBPMontor.TabIndex = 0;
            // 
            // dsBPMonitor
            // 
            this.dsBPMonitor.DataSetName = "dsBPMonitor";
            this.dsBPMonitor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtBPMonitorBindingSource
            // 
            this.dtBPMonitorBindingSource.DataMember = "dtBPMonitor";
            this.dtBPMonitorBindingSource.DataSource = this.dsBPMonitor;
            // 
            // entryIDDataGridViewTextBoxColumn
            // 
            this.entryIDDataGridViewTextBoxColumn.DataPropertyName = "EntryID";
            this.entryIDDataGridViewTextBoxColumn.HeaderText = "EntryID";
            this.entryIDDataGridViewTextBoxColumn.Name = "entryIDDataGridViewTextBoxColumn";
            this.entryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.entryIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "Edit";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // entryDateDataGridViewTextBoxColumn
            // 
            this.entryDateDataGridViewTextBoxColumn.DataPropertyName = "EntryDate";
            this.entryDateDataGridViewTextBoxColumn.HeaderText = "EntryDate";
            this.entryDateDataGridViewTextBoxColumn.Name = "entryDateDataGridViewTextBoxColumn";
            this.entryDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // systolicDataGridViewTextBoxColumn
            // 
            this.systolicDataGridViewTextBoxColumn.DataPropertyName = "Systolic";
            this.systolicDataGridViewTextBoxColumn.HeaderText = "Systolic";
            this.systolicDataGridViewTextBoxColumn.Name = "systolicDataGridViewTextBoxColumn";
            this.systolicDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diastolicDataGridViewTextBoxColumn
            // 
            this.diastolicDataGridViewTextBoxColumn.DataPropertyName = "Diastolic";
            this.diastolicDataGridViewTextBoxColumn.HeaderText = "Diastolic";
            this.diastolicDataGridViewTextBoxColumn.Name = "diastolicDataGridViewTextBoxColumn";
            this.diastolicDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // heartRateDataGridViewTextBoxColumn
            // 
            this.heartRateDataGridViewTextBoxColumn.DataPropertyName = "HeartRate";
            this.heartRateDataGridViewTextBoxColumn.HeaderText = "HeartRate";
            this.heartRateDataGridViewTextBoxColumn.Name = "heartRateDataGridViewTextBoxColumn";
            this.heartRateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colAverage
            // 
            this.colAverage.HeaderText = "Avg";
            this.colAverage.Name = "colAverage";
            this.colAverage.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            this.notesDataGridViewTextBoxColumn.Visible = false;
            // 
            // archiveDataGridViewCheckBoxColumn
            // 
            this.archiveDataGridViewCheckBoxColumn.DataPropertyName = "Archive";
            this.archiveDataGridViewCheckBoxColumn.HeaderText = "Archive";
            this.archiveDataGridViewCheckBoxColumn.Name = "archiveDataGridViewCheckBoxColumn";
            this.archiveDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GoonTools BP Monitor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbBPMontor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBPMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBPMonitorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gbBPMontor;
        private System.Windows.Forms.BindingSource dtBPMonitorBindingSource;
        private dsBPMonitor dsBPMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn systolicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diastolicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heartRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn archiveDataGridViewCheckBoxColumn;
    }
}

