using StampyxCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stampyx
{
    public partial class FormWatermarkEditor : Form
    {
        Watermark m_mark = null;
        string m_body = "Lorem Ipsum";
        Color m_color = Color.White;
        Font m_font = new Font(ImageHelper.WMARK_FONT_FAMILY, ImageHelper.WMARK_FONT_SIZE, FontStyle.Regular, GraphicsUnit.Pixel);

        public FormWatermarkEditor()
        {
            InitializeComponent();
        }

        public FormWatermarkEditor(Watermark mark) : this()
        {
            m_mark = mark;
            lblColor.Text = StringHelper.SplitCamelCase(m_mark.TextColor.Name);
            m_color = m_mark.TextColor;
            lblFontFamily.Text = m_mark.TextFont.Name;
            m_font = m_mark.TextFont;
            textBoxBody.Text = m_mark.Body;
            m_body = m_mark.Body;
        }

        public Watermark Mark { get => m_mark; set => m_mark = value; }

        private void btnColor_Click(object sender, EventArgs e)
        {
            FormWebColorPicker colorPicker = new FormWebColorPicker();
            if (colorPicker.ShowDialog(this) == DialogResult.OK)
            {
                m_color = colorPicker.Pick;
                lblColor.Text = StringHelper.SplitCamelCase(m_color.Name);
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = m_font;
            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                m_font = fontDialog1.Font;
                lblFontFamily.Text = m_font.FontFamily.Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_mark.Body = textBoxBody.Text;
            m_mark.TextFont = m_font;
            m_mark.TextColor = m_color;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
