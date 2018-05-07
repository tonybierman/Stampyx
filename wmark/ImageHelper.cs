using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wmark
{
    internal class ImageHelper
    {
        public static readonly string WMARK_FONT_FAMILY = "Georgia";
        public static readonly int WMARK_FONT_SIZE = 64;

        public static ImageCodecInfo GetEncoder(ImageFormat format)
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

        public static int ProcessFilesInBackground(BackgroundWorker bw, string folderSource, string folderDest, string watermarkFilePrefix, string watermarkText, bool isMaintenanceMode)
        {
            // Method variables
            Image img = null;
            string pathSource = String.Empty;
            string pathTarget = String.Empty;
            int retval = 0;

            try
            {
                if (!Directory.Exists(folderDest))
                    throw new FileNotFoundException(folderDest);

                string[] imgExtensions = { "*.jpg" };
                List<FileInfo> files = new List<FileInfo>();
                DirectoryInfo dir = new DirectoryInfo(folderSource);
                int c = 0;

                foreach (string e in imgExtensions)
                {
                    FileInfo[] folder = dir.GetFiles(e, SearchOption.AllDirectories);
                    int totalfiles = folder.Length;
                    foreach (FileInfo file in folder)
                    {
                        // Check for cancellation from parent thread
                        if (bw.CancellationPending)
                            break;

                        c++;
                        double progress = (double)c / (double)totalfiles;
                        bw.ReportProgress((int)(progress * 100));

                        // Debug
                        if (c % 100 == 0)
                            Debug.Print(string.Format("Processing file {0}", c));

                        using (FileStream fs = file.OpenRead())
                        {
                            pathSource = string.Concat(folderSource, @"\", file.Name);

                            // Skip watermarks images created by this app
                            if (file.Name.StartsWith(watermarkFilePrefix))
                                continue;

                            // Path of the watermarked image to be created
                            pathTarget = string.Concat(folderDest, @"\", watermarkFilePrefix, file.Name);
                            bool targetExists = File.Exists(pathTarget);

                            // If maintenance mode and watermarked image already exists,
                            // then skip it.  Otherwise, delete if it exists.
                            if (targetExists && isMaintenanceMode)
                                continue;
                            else if (targetExists)
                                File.Delete(pathTarget);

                            // Create the watermarked image
                            Stream outputStream = new MemoryStream();
                            ImageHelper.AddWatermark(fs, watermarkText, outputStream);
                            img = Image.FromStream(outputStream);
                            using (Bitmap savingImage = new Bitmap(img.Width, img.Height, img.PixelFormat))
                            {
                                savingImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                                ImageCodecInfo codecInfo = ImageHelper.GetEncoder(ImageFormat.Jpeg);

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

                Debug.Print("Processing Completed");
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                retval = 1;
            }
            finally
            {
                if (img != null)
                    img.Dispose();
            }

            return retval;
        }

        public static void AddWatermark(FileStream fs, string watermarkText, Stream outputStream)
        {
            Image img = Image.FromStream(fs);
            Font font = new Font(ImageHelper.WMARK_FONT_FAMILY, ImageHelper.WMARK_FONT_SIZE, FontStyle.Regular, GraphicsUnit.Pixel);

            // Adds a white watermark with an 100 alpha value.
            Color color = Color.FromArgb(100, 255, 255, 255);

            // The position where to draw the watermark on the image
            // Bottom left
            // TODO: Give user option for other corners
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
                Image img1 = img;
                img = new Bitmap(img1, img.Width, img.Height);
                gr = Graphics.FromImage(img);
                gr.DrawImage(img1, new Rectangle(0, 0, img.Width, img.Height));//, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                img1.Dispose();
            }

            gr.DrawString(watermarkText, font, sbrush, pt);
            gr.Dispose();

            // Save to memory stream
            img.Save(outputStream, ImageFormat.Jpeg);
        }
    }
}
