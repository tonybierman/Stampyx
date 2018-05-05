using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string m_path = string.Empty;
        readonly string PATH_DEST = @"E:\usr\var\media\Watermarked";
        readonly string WMARK_FONT_FAMILY = "Georgia";
        readonly int WMARK_FONT_SIZE = 64;

        public FormMain()
        {
            InitializeComponent();

            // Disallow creation of new files using the FolderBrowserDialog.
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.Description = "Select the source images directory";
        }

        private void process(string path)
        {
            lblStatus.Text = String.Empty;
            Image img = null;
            string pathSource = String.Empty;
            string pathTarget = String.Empty;

            try
            {
                if (!Directory.Exists(PATH_DEST))
                    throw new FileNotFoundException(PATH_DEST);

                string[] imgExtensions = { "*.jpg" };
                List<FileInfo> files = new List<FileInfo>();
                DirectoryInfo dir = new DirectoryInfo(path);
                int c = 0;
                foreach (string e in imgExtensions)
                {
                    FileInfo[] folder = dir.GetFiles(e, SearchOption.AllDirectories);
                    foreach (FileInfo file in folder)
                    {
                        c++;
                        lblStatus.Text = string.Format("Processing {0}", c);
                        lblStatus.Refresh();
                        using (FileStream fs = file.OpenRead())
                        {
                            pathSource = string.Concat(path, @"\", file.Name);

                            // Skip watermarks images created by this app
                            if (file.Name.StartsWith(textBoxPrefix.Text))
                                continue;

                            // Path of the watermarked image to be created
                            pathTarget = string.Concat(PATH_DEST, @"\", textBoxPrefix.Text, file.Name);
                            bool targetExists = File.Exists(pathTarget);

                            // If maintenance mode and watermarked image already exists,
                            // then skip it.  Otherwise, delete if it exists.
                            if (targetExists && chkboxMaintMode.Checked)
                                continue;
                            else if (targetExists)
                                File.Delete(pathTarget);

                            // Create the watermarked image
                            Stream outputStream = new MemoryStream();
                            AddWatermark(fs, textBoxBody.Text, outputStream);
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

                lblStatus.Text = "Processing Completed";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occured";
                MessageBox.Show(ex.ToString(), "An error occured");
            }
            finally
            {
                if (img != null)
                    img.Dispose();
            }
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

        private void btnWatermark_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
            }

            if (path == String.Empty)
            {
                lblStatus.Text = "Invalid directory..";
                return;
            }

            m_path = path;

            process(path);
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
            process(m_path);
        }

        #endregion Form events 

        private void textBoxPrefix_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
