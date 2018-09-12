using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampyxCore
{
    [Serializable]
    public class Watermark
    {
        string m_body;
        WatermarkLocation m_location;
        Color m_textColor = Color.White;
        Font m_font = new Font(ImageHelper.WMARK_FONT_FAMILY, ImageHelper.WMARK_FONT_SIZE, FontStyle.Regular, GraphicsUnit.Pixel);

        public string Body { get => m_body; set => m_body = value; }
        public WatermarkLocation Location { get => m_location; set => m_location = value; }
        public Color TextColor { get => m_textColor; set => m_textColor = value; }
        public Font TextFont { get => m_font; set => m_font = value; }
    }
}
