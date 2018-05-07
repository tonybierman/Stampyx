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

namespace wmark
{
    public partial class FormMain : Form
    {
        // Member variables
        string m_pathSrc = string.Empty;
        string m_pathDest = string.Empty;
        string m_prefix = string.Empty;
        string m_body = string.Empty;

        public FormMain()
        {
            InitializeComponent();

            // Disallow creation of new files using the FolderBrowserDialog.
            this.folderBrowserDialogSrc.ShowNewFolderButton = false;
            this.folderBrowserDialogSrc.Description = "Select the source images directory";

            // Load settings to member variables
            m_pathSrc = Properties.Settings.Default.PathSource;
            m_pathDest = Properties.Settings.Default.PathDest;
            m_prefix = Properties.Settings.Default.Prefix;
            m_body = Properties.Settings.Default.Body;

            // Load settings to UI
            labelDestPath.Text = m_pathDest;
            labelSrcPath.Text = m_pathSrc;
            this.folderBrowserDialogSrc.SelectedPath = m_pathSrc;
            this.folderBrowserDialogDest.SelectedPath = m_pathDest;
            textBoxBody.Text = string.IsNullOrEmpty(m_body) ? "© Me" : m_body;
            textBoxPrefix.Text = string.IsNullOrEmpty(m_prefix) ? "wm_" : m_prefix;

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
            m_body = textBoxBody.Text;
            m_prefix = textBoxPrefix.Text;

            // Save a few general settings
            Properties.Settings.Default.Prefix = m_prefix;
            Properties.Settings.Default.Body = m_body;
            Properties.Settings.Default.Save();

            // Process files in background
            return ImageHelper.ProcessFilesInBackground(bw, m_pathSrc, m_pathDest, m_prefix, m_body, isMaint);
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

            m_pathSrc = path;
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

            m_pathDest = path;
            labelDestPath.Text = path;
            Properties.Settings.Default.PathDest = path;
            Properties.Settings.Default.Save();
        }

        private void textBoxBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRepeat_Click(object sender, EventArgs e)
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
            chkboxMaintMode.Enabled = false;
        }

        #endregion UI Helpers
    }
}
