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
            this.lblStatus = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // btnSrcPath
            // 
            this.btnSrcPath.Location = new System.Drawing.Point(68, 12);
            this.btnSrcPath.Name = "btnSrcPath";
            this.btnSrcPath.Size = new System.Drawing.Size(162, 23);
            this.btnSrcPath.TabIndex = 0;
            this.btnSrcPath.Text = "Select source folder";
            this.btnSrcPath.UseVisualStyleBackColor = true;
            this.btnSrcPath.Click += new System.EventHandler(this.btnSrcPath_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(65, 268);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(95, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status: Not run yet";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix new images with";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(177, 131);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(53, 20);
            this.textBoxPrefix.TabIndex = 3;
            this.textBoxPrefix.TextChanged += new System.EventHandler(this.textBoxPrefix_TextChanged);
            // 
            // chkboxMaintMode
            // 
            this.chkboxMaintMode.AutoSize = true;
            this.chkboxMaintMode.Checked = true;
            this.chkboxMaintMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxMaintMode.Location = new System.Drawing.Point(68, 157);
            this.chkboxMaintMode.Name = "chkboxMaintMode";
            this.chkboxMaintMode.Size = new System.Drawing.Size(168, 17);
            this.chkboxMaintMode.TabIndex = 4;
            this.chkboxMaintMode.Text = "Run folder maintenance mode";
            this.chkboxMaintMode.UseVisualStyleBackColor = true;
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(68, 181);
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(162, 20);
            this.textBoxBody.TabIndex = 5;
            this.textBoxBody.TextChanged += new System.EventHandler(this.textBoxBody_TextChanged);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(68, 232);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(162, 23);
            this.btnRepeat.TabIndex = 6;
            this.btnRepeat.Text = "GO";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // labelSrcPath
            // 
            this.labelSrcPath.AutoSize = true;
            this.labelSrcPath.Location = new System.Drawing.Point(68, 38);
            this.labelSrcPath.MaximumSize = new System.Drawing.Size(180, 32);
            this.labelSrcPath.Name = "labelSrcPath";
            this.labelSrcPath.Size = new System.Drawing.Size(41, 13);
            this.labelSrcPath.TabIndex = 7;
            this.labelSrcPath.Text = "Not set";
            // 
            // btnDestPath
            // 
            this.btnDestPath.Location = new System.Drawing.Point(68, 68);
            this.btnDestPath.Name = "btnDestPath";
            this.btnDestPath.Size = new System.Drawing.Size(162, 23);
            this.btnDestPath.TabIndex = 8;
            this.btnDestPath.Text = "Select destination folder";
            this.btnDestPath.UseVisualStyleBackColor = true;
            this.btnDestPath.Click += new System.EventHandler(this.btnDestPath_Click);
            // 
            // labelDestPath
            // 
            this.labelDestPath.AutoSize = true;
            this.labelDestPath.Location = new System.Drawing.Point(68, 94);
            this.labelDestPath.MaximumSize = new System.Drawing.Size(180, 32);
            this.labelDestPath.Name = "labelDestPath";
            this.labelDestPath.Size = new System.Drawing.Size(41, 13);
            this.labelDestPath.TabIndex = 10;
            this.labelDestPath.Text = "Not set";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 323);
            this.Controls.Add(this.labelDestPath);
            this.Controls.Add(this.btnDestPath);
            this.Controls.Add(this.labelSrcPath);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.chkboxMaintMode);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSrcPath);
            this.Name = "FormMain";
            this.Text = "Watermarker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSrcPath;
        private System.Windows.Forms.Label lblStatus;
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
    }
}

