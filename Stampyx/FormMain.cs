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
using StampyxCore;

namespace Stampyx
{
    public partial class FormMain : Form
    {
        ProcessConfig m_config = null;
        ProcessConfig m_configRevert = null;

        string m_configFname = null;

        public FormMain()
        {
            InitializeComponent();

            // Configure folder pickers
            this.folderBrowserDialogSrc.ShowNewFolderButton = false;
            this.folderBrowserDialogSrc.Description = "Select the source images directory";
            this.folderBrowserDialogDest.ShowNewFolderButton = false;
            this.folderBrowserDialogDest.Description = "Select the target images directory";

            // Load settings
            m_config = Hydrator.HydrateFrom<ProcessConfig>("josie_config.stx");

            // Load settings to UI
            //labelDestPath.Text = m_config.PathDest;
            //labelSrcPath.Text = m_config.PathSrc;
            //this.folderBrowserDialogSrc.SelectedPath = m_config.PathSrc;
            //this.folderBrowserDialogDest.SelectedPath = m_config.PathDest;
            //textBoxPrefix.Text = string.IsNullOrEmpty(m_config.Prefix) ? ImageHelper.DEFAULT_PREFIX : m_config.Prefix;

            // Initialize background worker
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

        private int Process(BackgroundWorker bw, bool isMaint)
        {
            // Process files in background
            return ImageHelper.ProcessFilesInBackground(bw, m_config);
        }

        #region Form events

        private void btnSrcPath_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            folderBrowserDialogSrc.SelectedPath = m_config.PathSrc;
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
        }

        private void btnDestPath_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            folderBrowserDialogDest.SelectedPath = m_config.PathDest;
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
            textBoxPrefix.Enabled = false;
            chkboxMaintMode.Enabled = false;
        }

        private void EnableUI()
        {
            btnDestPath.Enabled = true;
            btnSrcPath.Enabled = true;
            textBoxPrefix.Enabled = true;
            chkboxMaintMode.Enabled = true;
        }

        #endregion UI Helpers

        private void btnLocation_Click(object sender, EventArgs e)
        {
            FormWatermarkLocations locationPicker = new FormWatermarkLocations(m_config);
            if (locationPicker.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "stx";
            openFileDialog1.Title = "Browse Stampyx Files";
            openFileDialog1.Filter = "Stampyx files (*.stx)|*.stx";
            openFileDialog1.FilterIndex = 1;
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                m_configFname = openFileDialog1.FileName;
                m_config = Hydrator.HydrateFrom<ProcessConfig>(m_configFname);
                m_configRevert = Hydrator.HydrateFrom<ProcessConfig>(m_configFname);
                toolStripStatusLabel1.Text = m_configFname;
                labelSrcPath.Text = m_config.PathSrc;
                labelDestPath.Text = m_config.PathDest;
                textBoxPrefix.Text = m_config.Prefix;
                chkboxMaintMode.Checked = m_config.IsMaint;
            }

            if (m_configFname == String.Empty)
            {
                toolStripStatusLabel1.Text = "Invalid file.";
                return;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_configFname))
            {
                saveFileDialog1.FileName = m_configFname;
                saveFileDialog1.DefaultExt = "stx";
                saveFileDialog1.Title = "Save Stampyx File";
                saveFileDialog1.Filter = "Stampyx files (*.stx)|*.stx";
                saveFileDialog1.FilterIndex = 1;
                DialogResult result = saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    Hydrator.DehydrateTo(m_config, saveFileDialog1.FileName);
                    toolStripStatusLabel1.Text = "File saved.";
                    m_configFname = saveFileDialog1.FileName;
                }
            }
            else
            {
                Hydrator.DehydrateTo(m_config, m_configFname);
                toolStripStatusLabel1.Text = "File saved.";
            }
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = m_configFname;
            saveFileDialog1.DefaultExt = "stx";
            saveFileDialog1.Title = "Save Stampyx File";
            saveFileDialog1.Filter = "Stampyx files (*.stx)|*.stx";
            saveFileDialog1.FilterIndex = 1;
            DialogResult result = saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                Hydrator.DehydrateTo(m_config, saveFileDialog1.FileName);
                toolStripStatusLabel1.Text = "File saved.";
                m_configFname = saveFileDialog1.FileName;
            }
        }

        private void chkboxMaintMode_CheckedChanged(object sender, EventArgs e)
        {
            m_config.IsMaint = chkboxMaintMode.Checked;
        }

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {
            m_config.Prefix = textBoxPrefix.Text;
        }


    }
}
