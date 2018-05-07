namespace wmark
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.chkboxMaintMode = new System.Windows.Forms.CheckBox();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.labelSrcPath = new System.Windows.Forms.Label();
            this.btnDestPath = new System.Windows.Forms.Button();
            this.labelDestPath = new System.Windows.Forms.Label();
            this.folderBrowserDialogDest = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnLocation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix watermarked image filenames with";
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(209, 17);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(154, 20);
            this.textBoxPrefix.TabIndex = 3;
            // 
            // chkboxMaintMode
            // 
            this.chkboxMaintMode.AutoSize = true;
            this.chkboxMaintMode.Checked = true;
            this.chkboxMaintMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxMaintMode.Location = new System.Drawing.Point(9, 78);
            this.chkboxMaintMode.Name = "chkboxMaintMode";
            this.chkboxMaintMode.Size = new System.Drawing.Size(204, 17);
            this.chkboxMaintMode.TabIndex = 4;
            this.chkboxMaintMode.Text = "Run Watermarker in folder sync mode";
            this.chkboxMaintMode.UseVisualStyleBackColor = true;
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(91, 41);
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(272, 20);
            this.textBoxBody.TabIndex = 5;
            this.textBoxBody.TextChanged += new System.EventHandler(this.textBoxBody_TextChanged);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(406, 210);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLocation);
            this.groupBox1.Controls.Add(this.btnFont);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkboxMaintMode);
            this.groupBox1.Controls.Add(this.textBoxBody);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPrefix);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 111);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(394, 19);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 8;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(394, 49);
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
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Watermark text";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 250);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(506, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "Not run yet";
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(394, 78);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(75, 23);
            this.btnLocation.TabIndex = 9;
            this.btnLocation.Text = "Location";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 272);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelDestPath);
            this.Controls.Add(this.btnDestPath);
            this.Controls.Add(this.labelSrcPath);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.btnSrcPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Watermarker |  The image watermarking tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSrcPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.CheckBox chkboxMaintMode;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Label labelSrcPath;
        private System.Windows.Forms.Button btnDestPath;
        private System.Windows.Forms.Label labelDestPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDest;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnLocation;
    }
}

