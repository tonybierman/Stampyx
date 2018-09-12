using QRCoder;
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

namespace StampyxCore
{
    public enum WatermarkLocation
    {
        LowerLeft,
        UpperLeft,
        UpperRight,
        LowerRight,
        Center
    };

    /// <summary>
    /// A helper class to create watermarked copies of images
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// Font used for watermark
        /// </summary>
        public static readonly string WMARK_FONT_FAMILY = "Georgia";

        /// <summary>
        /// Font size used for watermark
        /// </summary>
        public static readonly int WMARK_FONT_SIZE = 64;

        /// <summary>
        /// Default watermarked copy file prefix
        /// </summary>
        public static readonly string DEFAULT_PREFIX = "wm_";

        /// <summary>
        /// Default watermark text
        /// </summary>
        public static readonly string DEFAULT_BODY = "© Me";

        /// <summary>
        /// Get an image format encoder
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create watermarked copies of all images in a folder
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="folderSource"></param>
        /// <param name="folderDest"></param>
        /// <param name="watermarkFilePrefix"></param>
        /// <param name="watermarkText"></param>
        /// <param name="isMaintenanceMode"></param>
        /// <returns></returns>
        public static int ProcessFilesInBackground(BackgroundWorker bw, string folderSource, string folderDest, 
            string watermarkFilePrefix, string watermarkText, Color textColor, Font wmFont, WatermarkLocation location, 
            bool isMaintenanceMode)
        {
            // Method variables
            watermarkText = watermarkText.Replace(@"\n", Environment.NewLine);
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
                            ImageHelper.AddWatermark(fs, watermarkText, textColor, wmFont, location, outputStream);
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

                                // TODO IF QRCode checked
                                //QRCodeGenerator qrGenerator = new QRCodeGenerator();
                                //QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
                                //QRCode qrCode = new QRCode(qrCodeData);
                                //Bitmap qrCodeImage = qrCode.GetGraphic(10);
                                //using (Graphics g = Graphics.FromImage(savingImage))
                                //    g.DrawImage(qrCodeImage, new Point(0, 0));

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

        /// <summary>
        /// Convenience overload
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int ProcessFilesInBackground(BackgroundWorker bw, ProcessConfig config)
        {
            return ProcessFilesInBackground(bw, config.PathSrc, config.PathDest, config.Prefix, config.Body, config.TextColor, config.TextFont, config.MarkLocation, config.IsMaint);
        }

        /// <summary>
        /// Adds a text watermark to an input image filestream
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="watermarkText"></param>
        /// <param name="outputStream"></param>
        public static void AddWatermark(FileStream fs, string watermarkText, Color textColor, Font wmFont, WatermarkLocation location, Stream outputStream)
        {
            Image img = Image.FromStream(fs);
            Font font = wmFont;

            SolidBrush sbrush = new SolidBrush(textColor);
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

            // The position where to draw the watermark on the image
            SizeF ss = gr.MeasureString(watermarkText, font);

            // Lower left
            Point pt = new Point(40, img.Height - ((int)ss.Height + 40));

            // Upper left
            if(location == WatermarkLocation.UpperLeft)
                pt = new Point(40, 40);

            // Upper right
            if(location == WatermarkLocation.UpperRight)
                pt = new Point(img.Width - ((int)ss.Width + 40), 40);

            // Lower right
            if(location == WatermarkLocation.LowerRight)
                pt = new Point(img.Width - ((int)ss.Width + 40), img.Height - ((int)ss.Height + 40));

            // Center
            if (location == WatermarkLocation.Center)
                pt = new Point((img.Width / 2) - (((int)ss.Width / 2)), (img.Height / 2) - (((int)ss.Height / 2)));

            // Print
            gr.DrawString(watermarkText, font, sbrush, pt);

            // Cleanup
            gr.Dispose();

            // Save to memory stream
            img.Save(outputStream, ImageFormat.Jpeg);
        }
    }
}
