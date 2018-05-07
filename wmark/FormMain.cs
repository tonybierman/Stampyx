using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatermarkerCore;

namespace wmark
{
    public partial class FormMain : Form
    {
        ProcessConfig m_config = new ProcessConfig();

        public FormMain()
        {
            InitializeComponent();

            // Configure folder pickers
            this.folderBrowserDialogSrc.ShowNewFolderButton = false;
            this.folderBrowserDialogSrc.Description = "Select the source images directory";
            this.folderBrowserDialogDest.ShowNewFolderButton = false;
            this.folderBrowserDialogDest.Description = "Select the target images directory";

            // Load settings to member variables
            m_config.PathSrc = Properties.Settings.Default.PathSource;
            m_config.PathDest = Properties.Settings.Default.PathDest;
            m_config.Prefix = Properties.Settings.Default.Prefix;
            m_config.Body = Properties.Settings.Default.Body;
            m_config.TextColor = Properties.Settings.Default.TextColor;
            m_config.TextFont = Properties.Settings.Default.Font;
            m_config.MarkLocation = Properties.Settings.Default.MarkLocation;

            // Load settings to UI
            labelDestPath.Text = m_config.PathDest;
            labelSrcPath.Text = m_config.PathSrc;
            this.folderBrowserDialogSrc.SelectedPath = m_config.PathSrc;
            this.folderBrowserDialogDest.SelectedPath = m_config.PathDest;
            textBoxBody.Text = string.IsNullOrEmpty(m_config.Body) ? ImageHelper.DEFAULT_BODY : m_config.Body;
            textBoxPrefix.Text = string.IsNullOrEmpty(m_config.Prefix) ? ImageHelper.DEFAULT_PREFIX : m_config.Prefix;

            // Initialize background worker
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

        private int Process(BackgroundWorker bw, bool isMaint)
        {
            // Refresh a few salient member variables with UI data
            m_config.Body = textBoxBody.Text;
            m_config.Prefix = textBoxPrefix.Text;
            m_config.IsMaint = isMaint;

            // Save a few general settings
            Properties.Settings.Default.Prefix = m_config.Prefix;
            Properties.Settings.Default.Body = m_config.Body;
            Properties.Settings.Default.TextColor = m_config.TextColor;
            Properties.Settings.Default.Font = m_config.TextFont;
            Properties.Settings.Default.MarkLocation = m_config.MarkLocation;
            Properties.Settings.Default.Save();

            // Process files in background
            return ImageHelper.ProcessFilesInBackground(bw, m_config);
        }

        #region Form events

        private void btnSrcPath_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            DialogResult result = folderBrowserDialogSrc.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialogSrc.SelectedPath;
            }

            if (path == String.Empty)
            {
                toolStripStatusLabel1.Text = "Invalid directory..";
                return;
            }

            m_config.PathSrc = path;
            labelSrcPath.Text = path;
            Properties.Settings.Default.PathSource = path;
            Properties.Settings.Default.Save();
        }

        private void btnDestPath_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            DialogResult result = folderBrowserDialogDest.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialogDest.SelectedPath;
            }

            if (path == String.Empty)
            {
                toolStripStatusLabel1.Text = "Invalid directory..";
                return;
            }

            m_config.PathDest = path;
            labelDestPath.Text = path;
            Properties.Settings.Default.PathDest = path;
            Properties.Settings.Default.Save();
        }

        private void textBoxBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DisableUI();
            if (this.backgroundWorker1.IsBusy)
            {
                btnRepeat.Text = "CANCELLING...";
                this.backgroundWorker1.CancelAsync();
            }
            else
            {
                btnRepeat.Text = "CANCEL";
                this.backgroundWorker1.RunWorkerAsync(chkboxMaintMode.Checked);
            }
        }

        #endregion Form events 

        #region Background Worker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            // Extract the argument.
            bool arg = (bool)e.Argument;

            // Start the time-consuming operation.
            e.Result = Process(bw, arg);

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Process is {0}% complete", e.ProgressPercentage);
            toolStripStatusLabel1.Invalidate();
        }

        // This event handler demonstrates how to interpret 
        // the outcome of the asynchronous operation implemented
        // in the DoWork event handler.
        private void backgroundWorker1_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // The user canceled the operation.
                toolStripStatusLabel1.Text = "Operation was canceled";
            }
            else if (e.Error != null)
            {
                // There was an error during the operation.
                toolStripStatusLabel1.Text = "An error occurred";
                string msg = String.Format("An error occurred: {0}", e.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                // The operation completed normally.
                //string msg = String.Format("Result = {0}", e.Result);
                toolStripStatusLabel1.Text = "Operation completed";
            }

            btnRepeat.Text = "GO";
            EnableUI();
        }

        #endregion Background Worker

        #region UI Helpers

        private void DisableUI()
        {
            btnDestPath.Enabled = false;
            btnSrcPath.Enabled = false;
            textBoxBody.Enabled = false;
            textBoxPrefix.Enabled = false;
            chkboxMaintMode.Enabled = false;
        }

        private void EnableUI()
        {
            btnDestPath.Enabled = true;
            btnSrcPath.Enabled = true;
            textBoxBody.Enabled = true;
            textBoxPrefix.Enabled = true;
            chkboxMaintMode.Enabled = true;
        }

        #endregion UI Helpers

        private void btnColor_Click(object sender, EventArgs e)
        {
            FormWebColorPicker colorPicker = new FormWebColorPicker(m_config.TextColor);
            if (colorPicker.ShowDialog(this) == DialogResult.OK)
            {
                m_config.TextColor = colorPicker.Pick;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = m_config.TextFont;
            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                m_config.TextFont = fontDialog1.Font;
            }
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            FormWatermarkLocationPicker locationPicker = new FormWatermarkLocationPicker();
            if (locationPicker.ShowDialog(this) == DialogResult.OK)
            {
                m_config.MarkLocation = locationPicker.MarkLocation;
            }
        }
    }
}
