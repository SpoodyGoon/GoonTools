﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoonMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            frmEntry fm = new frmEntry();
            if ((DialogResult)fm.ShowDialog() == DialogResult.OK)
            {
                // TODO add to dataset
            }
            fm.Dispose();
           
        }

    }
}