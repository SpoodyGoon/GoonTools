using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoonMonitor
{
    public partial class frmEntry : Form
    {
        public frmEntry()
        {
            InitializeComponent();
        }

        public DateTime EntryDate
        {
            get { return DateTime.Parse(dateTimePicker.Text); }
        }

        public int Systolic
        {
            get { return Convert.ToInt32(txtSystolic.Text); }
        }

        public int Systolic
        {
            get { return Convert.ToInt32(txtDiastolic.Text); }
        }

        public int Systolic
        {
            get { return Convert.ToInt32(txtHeartRate.Text); }
        }

        public string Notes
        {
            get { return txtNotes.Text; }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
