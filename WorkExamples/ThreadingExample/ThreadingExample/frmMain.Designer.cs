namespace ThreadingExample
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.tsAbout = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.numMaxThreads = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numOutputCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxResize = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMaxHeight = new System.Windows.Forms.NumericUpDown();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnFontBrowse = new System.Windows.Forms.Button();
            this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtWatermarkFont = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.txtWatermarkText = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExit,
            this.tsAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1079, 36);
            this.toolStrip1.TabIndex = 0;
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
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tsAbout
            // 
            this.tsAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsAbout.Image")));
            this.tsAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAbout.Name = "tsAbout";
            this.tsAbout.Size = new System.Drawing.Size(40, 33);
            this.tsAbout.Text = "About";
            this.tsAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1079, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssLabel
            // 
            this.ssLabel.Name = "ssLabel";
            this.ssLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1079, 236);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRun);
            this.groupBox2.Controls.Add(this.numMaxThreads);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numOutputCount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(707, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 229);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Threading Options ";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(95, 106);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(138, 23);
            this.btnRun.TabIndex = 18;
            this.btnRun.Text = "Process Images";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // numMaxThreads
            // 
            this.numMaxThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxThreads.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxThreads.Location = new System.Drawing.Point(178, 52);
            this.numMaxThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxThreads.Name = "numMaxThreads";
            this.numMaxThreads.Size = new System.Drawing.Size(55, 20);
            this.numMaxThreads.TabIndex = 17;
            this.numMaxThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMaxThreads.ThousandsSeparator = true;
            this.numMaxThreads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Max Number of Threads:";
            // 
            // numOutputCount
            // 
            this.numOutputCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOutputCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numOutputCount.Location = new System.Drawing.Point(178, 24);
            this.numOutputCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numOutputCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numOutputCount.Name = "numOutputCount";
            this.numOutputCount.Size = new System.Drawing.Size(55, 20);
            this.numOutputCount.TabIndex = 15;
            this.numOutputCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOutputCount.ThousandsSeparator = true;
            this.numOutputCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Number of Images to Output:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxResize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numMaxHeight);
            this.groupBox1.Controls.Add(this.txtOutputFolder);
            this.groupBox1.Controls.Add(this.btnFontBrowse);
            this.groupBox1.Controls.Add(this.numMaxWidth);
            this.groupBox1.Controls.Add(this.btnBrowseOutput);
            this.groupBox1.Controls.Add(this.txtWatermarkFont);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtInputFolder);
            this.groupBox1.Controls.Add(this.btnBrowseInput);
            this.groupBox1.Controls.Add(this.txtWatermarkText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1077, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Process Options ";
            // 
            // cbxResize
            // 
            this.cbxResize.AutoSize = true;
            this.cbxResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxResize.Location = new System.Drawing.Point(127, 146);
            this.cbxResize.Name = "cbxResize";
            this.cbxResize.Size = new System.Drawing.Size(95, 17);
            this.cbxResize.TabIndex = 15;
            this.cbxResize.Text = "Resize Images";
            this.cbxResize.UseVisualStyleBackColor = true;
            this.cbxResize.CheckedChanged += new System.EventHandler(this.cbxResize_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Images Folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Watermark Font:";
            // 
            // numMaxHeight
            // 
            this.numMaxHeight.Enabled = false;
            this.numMaxHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxHeight.Location = new System.Drawing.Point(484, 145);
            this.numMaxHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numMaxHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxHeight.Name = "numMaxHeight";
            this.numMaxHeight.Size = new System.Drawing.Size(71, 20);
            this.numMaxHeight.TabIndex = 14;
            this.numMaxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMaxHeight.ThousandsSeparator = true;
            this.numMaxHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFolder.Location = new System.Drawing.Point(127, 52);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(461, 20);
            this.txtOutputFolder.TabIndex = 5;
            // 
            // btnFontBrowse
            // 
            this.btnFontBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFontBrowse.Location = new System.Drawing.Point(593, 82);
            this.btnFontBrowse.Name = "btnFontBrowse";
            this.btnFontBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnFontBrowse.TabIndex = 7;
            this.btnFontBrowse.Text = "Font...";
            this.btnFontBrowse.UseVisualStyleBackColor = true;
            this.btnFontBrowse.Click += new System.EventHandler(this.btnFontBrowse_Click);
            // 
            // numMaxWidth
            // 
            this.numMaxWidth.Enabled = false;
            this.numMaxWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxWidth.Location = new System.Drawing.Point(316, 145);
            this.numMaxWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numMaxWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxWidth.Name = "numMaxWidth";
            this.numMaxWidth.Size = new System.Drawing.Size(71, 20);
            this.numMaxWidth.TabIndex = 13;
            this.numMaxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMaxWidth.ThousandsSeparator = true;
            this.numMaxWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(594, 50);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutput.TabIndex = 4;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtWatermarkFont
            // 
            this.txtWatermarkFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWatermarkFont.Location = new System.Drawing.Point(127, 84);
            this.txtWatermarkFont.Name = "txtWatermarkFont";
            this.txtWatermarkFont.Size = new System.Drawing.Size(461, 20);
            this.txtWatermarkFont.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(418, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Images Folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Watermark Text:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(253, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Max Width:";
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputFolder.Location = new System.Drawing.Point(127, 24);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(461, 20);
            this.txtInputFolder.TabIndex = 2;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseInput.Location = new System.Drawing.Point(594, 22);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInput.TabIndex = 1;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // txtWatermarkText
            // 
            this.txtWatermarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWatermarkText.Location = new System.Drawing.Point(127, 113);
            this.txtWatermarkText.Name = "txtWatermarkText";
            this.txtWatermarkText.Size = new System.Drawing.Size(461, 20);
            this.txtWatermarkText.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 677);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Threading Example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.ToolStripButton tsAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWatermarkFont;
        private System.Windows.Forms.Button btnFontBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWatermarkText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMaxHeight;
        private System.Windows.Forms.NumericUpDown numMaxWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxResize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numOutputCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMaxThreads;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRun;
    }
}

