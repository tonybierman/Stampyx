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
            this.btnLocation = new System.Windows.Forms.Button();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkboxMaintMode = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSrcPath
            // 
            this.btnSrcPath.Location = new System.Drawing.Point(12, 34);
            this.btnSrcPath.Name = "btnSrcPath";
            this.btnSrcPath.Size = new System.Drawing.Size(138, 23);
            this.btnSrcPath.TabIndex = 0;
            this.btnSrcPath.Text = "Select source folder";
            this.btnSrcPath.UseVisualStyleBackColor = true;
            this.btnSrcPath.Click += new System.EventHandler(this.btnSrcPath_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(155, 260);
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
            this.labelSrcPath.Location = new System.Drawing.Point(12, 60);
            this.labelSrcPath.MaximumSize = new System.Drawing.Size(360, 32);
            this.labelSrcPath.Name = "labelSrcPath";
            this.labelSrcPath.Size = new System.Drawing.Size(41, 13);
            this.labelSrcPath.TabIndex = 7;
            this.labelSrcPath.Text = "Not set";
            // 
            // btnDestPath
            // 
            this.btnDestPath.Location = new System.Drawing.Point(12, 85);
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
            this.labelDestPath.Location = new System.Drawing.Point(12, 111);
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
            this.statusStrip1.Size = new System.Drawing.Size(242, 22);
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
            this.btnLocation.Location = new System.Drawing.Point(12, 138);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(218, 65);
            this.btnLocation.TabIndex = 9;
            this.btnLocation.Text = "Watermarks Editor";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(152, 209);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(64, 20);
            this.textBoxPrefix.TabIndex = 3;
            this.textBoxPrefix.TextChanged += new System.EventHandler(this.textBoxPrefix_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 212);
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
            this.chkboxMaintMode.Location = new System.Drawing.Point(12, 237);
            this.chkboxMaintMode.Name = "chkboxMaintMode";
            this.chkboxMaintMode.Size = new System.Drawing.Size(204, 17);
            this.chkboxMaintMode.TabIndex = 4;
            this.chkboxMaintMode.Text = "Run Watermarker in folder sync mode";
            this.chkboxMaintMode.UseVisualStyleBackColor = true;
            this.chkboxMaintMode.CheckedChanged += new System.EventHandler(this.chkboxMaintMode_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(242, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveasToolStripMenuItem.Text = "Save &as";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 308);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
            this.Text = "Stampyx |  For watermarking";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkboxMaintMode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

