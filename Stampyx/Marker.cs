using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wmark
{
    internal class Marker
    {
        readonly string WMARK_FONT_FAMILY = "Georgia";
        readonly int WMARK_FONT_SIZE = 64;

        private FileStream m_src;
        private Stream m_dest;
        private string m_mark;

        public Marker(FileStream fs, string watermarkText, Stream outputStream)
        {
            m_src = fs;
            Dest = outputStream;
            m_mark = watermarkText;
        }

        public Stream Dest { get => m_dest; set => m_dest = value; }

        private void AddWatermark()
        {
            Image img = Image.FromStream(m_src);
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

                throw;
            }

            gr.DrawString(m_mark, font, sbrush, pt);
            gr.Dispose();

            // Save to memory stream
            img.Save(Dest, ImageFormat.Jpeg);
        }
    }
}
