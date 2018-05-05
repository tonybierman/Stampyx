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
        string m_pathSrc = string.Empty;
        string m_pathDest = string.Empty;
        string m_prefix = string.Empty;
        string m_body = string.Empty;

        readonly string WMARK_FONT_FAMILY = "Georgia";
        readonly int WMARK_FONT_SIZE = 64;

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

            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

        private int process(BackgroundWorker bw, bool isMaint)
        {
            // Method variables
            Image img = null;
            string pathSource = String.Empty;
            string pathTarget = String.Empty;

            // Clear status
            //lblStatus.Text = String.Empty;

            // Member variables
            m_body = textBoxBody.Text;
            m_prefix = textBoxPrefix.Text;

            // Save general settings
            Properties.Settings.Default.Prefix = m_prefix;
            Properties.Settings.Default.Body = m_body;
            Properties.Settings.Default.Save();

            try
            {
                if (!Directory.Exists(m_pathDest))
                    throw new FileNotFoundException(m_pathDest);

                string[] imgExtensions = { "*.jpg" };
                List<FileInfo> files = new List<FileInfo>();
                DirectoryInfo dir = new DirectoryInfo(m_pathSrc);
                int c = 0;
                foreach (string e in imgExtensions)
                {
                    FileInfo[] folder = dir.GetFiles(e, SearchOption.AllDirectories);
                    foreach (FileInfo file in folder)
                    {
                        c++;
                        if(c % 100 == 0)
                            Debug.Print(string.Format("Processing {0}", c));
                        //lblStatus.Text = string.Format("Processing {0}", c);
                        //lblStatus.Refresh();
                        using (FileStream fs = file.OpenRead())
                        {
                            pathSource = string.Concat(m_pathSrc, @"\", file.Name);

                            // Skip watermarks images created by this app
                            if (file.Name.StartsWith(m_prefix))
                                continue;

                            // Path of the watermarked image to be created
                            pathTarget = string.Concat(m_pathDest, @"\", m_prefix, file.Name);
                            bool targetExists = File.Exists(pathTarget);

                            // If maintenance mode and watermarked image already exists,
                            // then skip it.  Otherwise, delete if it exists.
                            if (targetExists && isMaint)
                                continue;
                            else if (targetExists)
                                File.Delete(pathTarget);

                            // Create the watermarked image
                            Stream outputStream = new MemoryStream();
                            AddWatermark(fs, m_body, outputStream);
                            img = Image.FromStream(outputStream);
                            using (Bitmap savingImage = new Bitmap(img.Width, img.Height, img.PixelFormat))
                            {
                                savingImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                                ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Jpeg);

                                // Create an Encoder object based on the GUID  
                                // for the Quality parameter category.  
                                System.Drawing.Imaging.Encoder myEncoder =
                                    System.Drawing.Imaging.Encoder.Quality;

                                // Create an EncoderParameters object.  
                                // An EncoderParameters object has an array of EncoderParameter  
                                // objects. In this case, there is only one  
                                // EncoderParameter object in the array.  
                                EncoderParameters parms = new EncoderParameters(1);

                                EncoderParameter parm = new EncoderParameter(myEncoder, 100L);
                                parms.Param[0] = parm;

                                using (Graphics g = Graphics.FromImage(savingImage))
                                    g.DrawImage(img, new Point(0, 0));

                                savingImage.Save(pathTarget, codecInfo, parms);
                            }
                        }

                        img.Dispose();

                        // This would would delete the original
                        // file.Delete(); 
                    }
                }

                //lblStatus.Text = "Processing Completed";
                Debug.Print("Processing Completed");
            }
            catch (Exception ex)
            {
                //lblStatus.Text = "An error occured";
                //MessageBox.Show(ex.ToString(), "An error occured");
                Debug.Print(ex.ToString());
            }
            finally
            {
                if (img != null)
                    img.Dispose();
            }

            return 0;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void AddWatermark(FileStream fs, string watermarkText, Stream outputStream)
        {
            Image img = Image.FromStream(fs);
            Font font = new Font(WMARK_FONT_FAMILY, WMARK_FONT_SIZE, FontStyle.Regular, GraphicsUnit.Pixel);

            //Adds a transparent watermark with an 100 alpha value.
            Color color = Color.FromArgb(100, 255, 255, 255);

            //The position where to draw the watermark on the image
            Point pt = new Point(40, img.Height - 120);
            SolidBrush sbrush = new SolidBrush(color);

            Graphics gr = null;
            try
            {
                gr = Graphics.FromImage(img);
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
                //gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            }
            catch (Exception ex)
            {
                // http://support.microsoft.com/Default.aspx?id=814675
                Image img1 = img;
                img = new Bitmap(img1, img.Width, img.Height);
                gr = Graphics.FromImage(img);
                gr.DrawImage(img1, new Rectangle(0, 0, img.Width, img.Height));//, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                img1.Dispose();

                lblStatus.Text = ex.Message;
            }

            gr.DrawString(watermarkText, font, sbrush, pt);
            gr.Dispose();

            // Save to memory stream
            img.Save(outputStream, ImageFormat.Jpeg);
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
                lblStatus.Text = "Invalid directory..";
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
                lblStatus.Text = "Invalid directory..";
                return;
            }

            m_pathDest = path;
            labelDestPath.Text = path;
            Properties.Settings.Default.PathDest = path;
            Properties.Settings.Default.Save();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync(chkboxMaintMode.Checked);
        }

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion Form events 

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            // Extract the argument.
            bool arg = (bool)e.Argument;

            // Start the time-consuming operation.
            e.Result = process(bw, arg);

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
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
                MessageBox.Show("Operation was canceled");
            }
            else if (e.Error != null)
            {
                // There was an error during the operation.
                string msg = String.Format("An error occurred: {0}", e.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                // The operation completed normally.
                string msg = String.Format("Result = {0}", e.Result);
                MessageBox.Show(msg);
            }
        }
    }
}
