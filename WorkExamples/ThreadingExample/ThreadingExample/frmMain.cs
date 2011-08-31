using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ThreadingExample
{
    public partial class frmMain : Form
    {
        private Font _UseFont = DefaultFont;
        private Color _UseColor = Color.Black;
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(Path.Combine(Environment.CurrentDirectory, "SaveData.xml"));
            if (fi.Exists)
            {
                GlobalData.SaveDataTable dt = new GlobalData.SaveDataTable();
                dt.ReadXml(fi.FullName);
                if (!string.IsNullOrEmpty(dt.Rows[0]["InputFolderPath"].ToString()))
                    txtInputFolder.Text = dt.Rows[0]["InputFolderPath"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["OutputFolderPath"].ToString()))
                    txtOutputFolder.Text = dt.Rows[0]["OutputFolderPath"].ToString();
                txtWatermarkText.Text = dt.Rows[0]["WatermarkText"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["FontBold"]) && Convert.ToBoolean(dt.Rows[0]["FontItalic"]))
                {
                    _UseFont = new System.Drawing.Font(dt.Rows[0]["FontName"].ToString(), float.Parse(dt.Rows[0]["FontSize"].ToString()), FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                }
                else if (Convert.ToBoolean(dt.Rows[0]["FontBold"]))
                {
                    _UseFont = new System.Drawing.Font(dt.Rows[0]["FontName"].ToString(), float.Parse(dt.Rows[0]["FontSize"].ToString()), FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                }
                else if (Convert.ToBoolean(dt.Rows[0]["FontBold"]))
                {
                    _UseFont = new System.Drawing.Font(dt.Rows[0]["FontName"].ToString(), float.Parse(dt.Rows[0]["FontSize"].ToString()), FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                }
                _UseColor = ColorTranslator.FromHtml(dt.Rows[0]["FontColor"].ToString());
                cbxResize.Checked = Convert.ToBoolean(dt.Rows[0]["ResizeImages"]);
                numMaxWidth.Value = Convert.ToDecimal(dt.Rows[0]["MaxWidth"]);
                numMaxHeight.Value = Convert.ToDecimal(dt.Rows[0]["MaxHeight"]);
                numMaxThreads.Value = Convert.ToDecimal(dt.Rows[0]["MaxThreads"]);
                dt.Clear();
                dt.Dispose();
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "InputImages"));
                if (di.Exists)
                    txtInputFolder.Text = di.FullName;
                di = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "OutputImages"));
                if (di.Exists)
                    txtOutputFolder.Text = di.FullName;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(_UseFont.Name + " " + _UseFont.SizeInPoints.ToString() + "pt ");
            if (_UseFont.Bold)
                sb.Append("Bold ");
            if (_UseFont.Italic)
                sb.Append("Italic ");
            sb.Append(ColorTranslator.ToHtml(_UseColor));
            txtWatermarkFont.Text = sb.ToString();
        }

        #region Application Exit Process

        private void tsExit_Click(object sender, EventArgs e)
        {
            ExitProcess();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitProcess();
        }

        private void ExitProcess()
        {
            FileInfo fi = new FileInfo(Path.Combine(Environment.CurrentDirectory, "SaveData.xml"));
            GlobalData.SaveDataTable dt = new GlobalData.SaveDataTable();
            DataRow dr = dt.NewRow();
            dr["InputFolderPath"] = txtInputFolder.Text;
            dr["OutputFolderPath"] = txtOutputFolder.Text;
            dr["WatermarkText"] = txtWatermarkText.Text;
            dr["FontName"] = _UseFont.Name;
            dr["FontSize"] = _UseFont.Size;
            dr["FontBold"] = _UseFont.Bold;
            dr["FontItalic"] = _UseFont.Underline;
            dr["FontColor"] = ColorTranslator.ToHtml(_UseColor);
            dr["ResizeImages"] = cbxResize.Checked;
            dr["MaxWidth"] = Convert.ToInt32(numMaxWidth.Value);
            dr["MaxHeight"] = Convert.ToInt32(numMaxHeight.Value);
            dr["MaxThreads"] = Convert.ToInt32(numMaxThreads.Value);
            dt.Rows.Add(dr);
            dt.WriteXml(fi.FullName);
            dt.Clear();
            dt.Dispose();
        
            Application.Exit();
        }

        #endregion Application Exit Process

        private void tsAbout_Click(object sender, EventArgs e)
        {
            frmAbout fm = new frmAbout();
            fm.ShowDialog();
            fm.Dispose();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Input Images Folder";
            fbd.SelectedPath = Environment.CurrentDirectory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtInputFolder.Text = fbd.SelectedPath;
            }
            fbd.Dispose();
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select Output Images Folder";
            fbd.SelectedPath = Environment.CurrentDirectory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = fbd.SelectedPath;
            }
            fbd.Dispose();

        }

        private void btnFontBrowse_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.ShowEffects = false;
            fd.AllowScriptChange = false;
            fd.FontMustExist = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                _UseFont = fd.Font;
                _UseColor = fd.Color;
                StringBuilder sb = new StringBuilder();
                sb.Append(_UseFont.Name + " " + _UseFont.SizeInPoints.ToString() + "pt ");
                if (_UseFont.Bold)
                    sb.Append("Bold ");
                if (_UseFont.Italic)
                    sb.Append("Italic ");
                sb.Append(ColorTranslator.ToHtml(_UseColor));
                txtWatermarkFont.Text = sb.ToString();
            }
            fd.Dispose();
        }

        private void cbxResize_CheckedChanged(object sender, EventArgs e)
        {
            numMaxWidth.Enabled = cbxResize.Checked;
            numMaxHeight.Enabled = cbxResize.Checked;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
