using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreadingExample
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(ThreadingExample.Properties.Resources.AboutText);
                rtbAbout.LoadFile(ms, RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "An Error Has Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
