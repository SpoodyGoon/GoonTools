namespace BookmarkSharp.Windows
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
            this.bookmarkAPIButton = new System.Windows.Forms.Button();
            this.resultsTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bookmarkAPIButton
            // 
            this.bookmarkAPIButton.Location = new System.Drawing.Point(220, 382);
            this.bookmarkAPIButton.Name = "bookmarkAPIButton";
            this.bookmarkAPIButton.Size = new System.Drawing.Size(131, 29);
            this.bookmarkAPIButton.TabIndex = 0;
            this.bookmarkAPIButton.Text = "Get Bookmark";
            this.bookmarkAPIButton.UseVisualStyleBackColor = true;
            this.bookmarkAPIButton.Click += new System.EventHandler(this.bookmarkAPIButton_Click);
            // 
            // resultsTextbox
            // 
            this.resultsTextbox.Location = new System.Drawing.Point(57, 50);
            this.resultsTextbox.Multiline = true;
            this.resultsTextbox.Name = "resultsTextbox";
            this.resultsTextbox.Size = new System.Drawing.Size(507, 240);
            this.resultsTextbox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 464);
            this.Controls.Add(this.resultsTextbox);
            this.Controls.Add(this.bookmarkAPIButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bookmarkAPIButton;
        private System.Windows.Forms.TextBox resultsTextbox;
    }
}

