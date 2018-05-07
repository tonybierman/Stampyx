using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatermarkerCore;

namespace wmark
{
    public partial class FormWatermarkLocationPicker : Form
    {
        WatermarkLocation m_markLocation = WatermarkLocation.LowerLeft;
        public WatermarkLocation MarkLocation { get => m_markLocation; set => m_markLocation = value; }

        public FormWatermarkLocationPicker()
        {
            InitializeComponent();
        }

        private void btnUpperLeft_Click(object sender, EventArgs e)
        {
            MarkLocation = WatermarkLocation.UpperLeft;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUpperRight_Click(object sender, EventArgs e)
        {
            MarkLocation = WatermarkLocation.UpperRight;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLowerLeft_Click(object sender, EventArgs e)
        {
            MarkLocation = WatermarkLocation.LowerLeft;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLowerRight_Click(object sender, EventArgs e)
        {
            MarkLocation = WatermarkLocation.LowerRight;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
