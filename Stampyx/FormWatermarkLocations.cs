using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StampyxCore;

namespace Stampyx
{
    public partial class FormWatermarkLocations : Form
    {
        ProcessConfig m_config = null;

        public FormWatermarkLocations()
        {
            InitializeComponent();
        }

        public FormWatermarkLocations(ProcessConfig config) : this() { m_config = config; }

        private void btnUpperLeft_Click(object sender, EventArgs e)
        {
            ShowMarkEditor(WatermarkLocation.UpperLeft);
        }

        private void btnUpperRight_Click(object sender, EventArgs e)
        {
            ShowMarkEditor(WatermarkLocation.UpperRight);
        }

        private void btnLowerLeft_Click(object sender, EventArgs e)
        {
            ShowMarkEditor(WatermarkLocation.LowerLeft);
        }

        private void btnLowerRight_Click(object sender, EventArgs e)
        {
            ShowMarkEditor(WatermarkLocation.LowerRight);
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            ShowMarkEditor(WatermarkLocation.Center);
        }

        private void ShowMarkEditor(WatermarkLocation location)
        {
            var wm = m_config.Marks.Where(a => a.Location == location).FirstOrDefault();
            if (wm == null)
            {
                wm = new Watermark();
                wm.Location = location;
            }

            FormWatermarkEditor editor = new FormWatermarkEditor(wm);
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                var tmp = m_config.Marks.Where(a => a.Location == editor.Mark.Location).FirstOrDefault();
                if (tmp != null)
                    m_config.Marks.Remove(wm);

                m_config.Marks.Add(editor.Mark);
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
