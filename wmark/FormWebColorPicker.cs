using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wmark
{
    public partial class FormWebColorPicker : Form
    {
        public FormWebColorPicker()
        {
            InitializeComponent();
            this.Load += WebColors_Load;
        }

        public FormWebColorPicker(Color pick) : this()
        {
            this.Pick = pick;
        }

        public Color Pick { get; set; }

        private void WebColors_Load(object sender, EventArgs e)
        {
            lbl_colorName.Text = this.Pick.Name;
            var webColors =
              Enum.GetValues(typeof(KnownColor))
                .Cast<KnownColor>()
                .Where(k => k >= KnownColor.Transparent && k < KnownColor.ButtonFace)
                .Select(k => Color.FromKnownColor(k))
                .OrderBy(c => c.GetHue())
                .ThenBy(c => c.GetSaturation())
                .ThenBy(c => c.GetBrightness()).ToList();

            int cc = webColors.Count;
            int n = (int)Math.Sqrt(cc) + 0;
            int w = ClientSize.Width / (n) - 1;
            Height = (n + 1) * w + 90;
            for (int i = 0; i < cc; i++)
            {
                Label lbl = new Label();
                lbl.Text = "";
                lbl.AutoSize = false;
                lbl.Size = new Size(w - 1, w - 1);
                lbl.BackColor = webColors[i];
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Location = new Point(1 + w * (i % (n + 1)), w * (i / (n + 1)));
                lbl.Click += (ss, ee) =>
                {
                    Pick = lbl.BackColor;
                    lbl_colorName.Text = Pick.Name;
                };
                Controls.Add(lbl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
