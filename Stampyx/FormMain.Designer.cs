namespace Stampyx
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSrcPath = new System.Windows.Forms.Button();
            this.folderBrowserDialogSrc = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.labelSrcPath = new System.Windows.Forms.Label();
            this.btnDestPath = new System.Windows.Forms.Button();
            this.labelDestPath = new System.Windows.Forms.Label();
            this.folderBrowserDialogDest = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblFontFamily = new System.Windows.Forms.Label();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkboxMaintMode = new System.Windows.Forms.CheckBox();
            this.checkBoxShouldQrCode = new System.Windows.Forms.CheckBox();
            this.textQrCodeBody = new System.Windows.Forms.TextBox();
            this.lblQrCodeBody = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSrcPath
            // 
            this.btnSrcPath.Location = new System.Drawing.Point(12, 12);
            this.btnSrcPath.Name = "btnSrcPath";
            this.btnSrcPath.Size = new System.Drawing.Size(138, 23);
            this.btnSrcPath.TabIndex = 0;
            this.btnSrcPath.Text = "Select source folder";
            this.btnSrcPath.UseVisualStyleBackColor = true;
            this.btnSrcPath.Click += new System.EventHandler(this.btnSrcPath_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(418, 239);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(75, 23);
            this.btnRepeat.TabIndex = 6;
            this.btnRepeat.Text = "GO";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // labelSrcPath
            // 
            this.labelSrcPath.AutoSize = true;
            this.labelSrcPath.Location = new System.Drawing.Point(156, 17);
            this.labelSrcPath.MaximumSize = new System.Drawing.Size(360, 32);
            this.labelSrcPath.Name = "labelSrcPath";
            this.labelSrcPath.Size = new System.Drawing.Size(41, 13);
            this.labelSrcPath.TabIndex = 7;
            this.labelSrcPath.Text = "Not set";
            // 
            // btnDestPath
            // 
            this.btnDestPath.Location = new System.Drawing.Point(12, 41);
            this.btnDestPath.Name = "btnDestPath";
            this.btnDestPath.Size = new System.Drawing.Size(138, 23);
            this.btnDestPath.TabIndex = 8;
            this.btnDestPath.Text = "Select destination folder";
            this.btnDestPath.UseVisualStyleBackColor = true;
            this.btnDestPath.Click += new System.EventHandler(this.btnDestPath_Click);
            // 
            // labelDestPath
            // 
            this.labelDestPath.AutoSize = true;
            this.labelDestPath.Location = new System.Drawing.Point(156, 41);
            this.labelDestPath.MaximumSize = new System.Drawing.Size(360, 32);
            this.labelDestPath.Name = "labelDestPath";
            this.labelDestPath.Size = new System.Drawing.Size(41, 13);
            this.labelDestPath.TabIndex = 10;
            this.labelDestPath.Text = "Not set";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 286);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(550, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "Not run yet";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 149);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblLocation);
            this.tabPage1.Controls.Add(this.lblColor);
            this.tabPage1.Controls.Add(this.lblFontFamily);
            this.tabPage1.Controls.Add(this.textBoxBody);
            this.tabPage1.Controls.Add(this.btnLocation);
            this.tabPage1.Controls.Add(this.btnFont);
            this.tabPage1.Controls.Add(this.btnColor);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 123);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text Mark";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(399, 81);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(35, 13);
            this.lblLocation.TabIndex = 12;
            this.lblLocation.Text = "label3";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(399, 51);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(35, 13);
            this.lblColor.TabIndex = 11;
            this.lblColor.Text = "label3";
            // 
            // lblFontFamily
            // 
            this.lblFontFamily.AutoSize = true;
            this.lblFontFamily.Location = new System.Drawing.Point(399, 21);
            this.lblFontFamily.Name = "lblFontFamily";
            this.lblFontFamily.Size = new System.Drawing.Size(35, 13);
            this.lblFontFamily.TabIndex = 10;
            this.lblFontFamily.Text = "label3";
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(96, 46);
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(182, 20);
            this.textBoxBody.TabIndex = 5;
            this.textBoxBody.TextChanged += new System.EventHandler(this.textBoxBody_TextChanged);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(302, 77);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(75, 23);
            this.btnLocation.TabIndex = 9;
            this.btnLocation.Text = "Location";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(302, 16);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 8;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(302, 46);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Watermark text";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.lblQrCodeBody);
            this.tabPage2.Controls.Add(this.textQrCodeBody);
            this.tabPage2.Controls.Add(this.checkBoxShouldQrCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 123);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "QR Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(170, 225);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(64, 20);
            this.textBoxPrefix.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix for copied image files";
            // 
            // chkboxMaintMode
            // 
            this.chkboxMaintMode.AutoSize = true;
            this.chkboxMaintMode.Checked = true;
            this.chkboxMaintMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxMaintMode.Location = new System.Drawing.Point(30, 251);
            this.chkboxMaintMode.Name = "chkboxMaintMode";
            this.chkboxMaintMode.Size = new System.Drawing.Size(204, 17);
            this.chkboxMaintMode.TabIndex = 4;
            this.chkboxMaintMode.Text = "Run Watermarker in folder sync mode";
            this.chkboxMaintMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxShouldQrCode
            // 
            this.checkBoxShouldQrCode.AutoSize = true;
            this.checkBoxShouldQrCode.Location = new System.Drawing.Point(14, 31);
            this.checkBoxShouldQrCode.Name = "checkBoxShouldQrCode";
            this.checkBoxShouldQrCode.Size = new System.Drawing.Size(171, 17);
            this.checkBoxShouldQrCode.TabIndex = 0;
            this.checkBoxShouldQrCode.Text = "Add a QR Code to each image";
            this.checkBoxShouldQrCode.UseVisualStyleBackColor = true;
            // 
            // textQrCodeBody
            // 
            this.textQrCodeBody.Location = new System.Drawing.Point(88, 62);
            this.textQrCodeBody.Name = "textQrCodeBody";
            this.textQrCodeBody.Size = new System.Drawing.Size(195, 20);
            this.textQrCodeBody.TabIndex = 1;
            // 
            // lblQrCodeBody
            // 
            this.lblQrCodeBody.AutoSize = true;
            this.lblQrCodeBody.Location = new System.Drawing.Point(11, 65);
            this.lblQrCodeBody.Name = "lblQrCodeBody";
            this.lblQrCodeBody.Size = new System.Drawing.Size(71, 13);
            this.lblQrCodeBody.TabIndex = 2;
            this.lblQrCodeBody.Text = "QR Code text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Location";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Color";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 308);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.labelDestPath);
            this.Controls.Add(this.btnDestPath);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.labelSrcPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSrcPath);
            this.Controls.Add(this.chkboxMaintMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Stampyx |  The batch image marking tool";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSrcPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSrc;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Label labelSrcPath;
        private System.Windows.Forms.Button btnDestPath;
        private System.Windows.Forms.Label labelDestPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDest;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblFontFamily;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkboxMaintMode;
        private System.Windows.Forms.Label lblQrCodeBody;
        private System.Windows.Forms.TextBox textQrCodeBody;
        private System.Windows.Forms.CheckBox checkBoxShouldQrCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

