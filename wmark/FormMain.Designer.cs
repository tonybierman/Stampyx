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
            this.btnWatermark = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.chkboxMaintMode = new System.Windows.Forms.CheckBox();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWatermark
            // 
            this.btnWatermark.Location = new System.Drawing.Point(68, 12);
            this.btnWatermark.Name = "btnWatermark";
            this.btnWatermark.Size = new System.Drawing.Size(111, 23);
            this.btnWatermark.TabIndex = 0;
            this.btnWatermark.Text = "Select source folder";
            this.btnWatermark.UseVisualStyleBackColor = true;
            this.btnWatermark.Click += new System.EventHandler(this.btnWatermark_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(65, 131);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix new images with";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(177, 47);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(53, 20);
            this.textBoxPrefix.TabIndex = 3;
            this.textBoxPrefix.Text = "wm_";
            this.textBoxPrefix.TextChanged += new System.EventHandler(this.textBoxPrefix_TextChanged);
            // 
            // chkboxMaintMode
            // 
            this.chkboxMaintMode.AutoSize = true;
            this.chkboxMaintMode.Checked = true;
            this.chkboxMaintMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxMaintMode.Location = new System.Drawing.Point(68, 73);
            this.chkboxMaintMode.Name = "chkboxMaintMode";
            this.chkboxMaintMode.Size = new System.Drawing.Size(148, 17);
            this.chkboxMaintMode.TabIndex = 4;
            this.chkboxMaintMode.Text = "Folder maintenance mode";
            this.chkboxMaintMode.UseVisualStyleBackColor = true;
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(68, 97);
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(162, 20);
            this.textBoxBody.TabIndex = 5;
            this.textBoxBody.Text = "© Tony Bierman";
            this.textBoxBody.TextChanged += new System.EventHandler(this.textBoxBody_TextChanged);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(185, 12);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(45, 23);
            this.btnRepeat.TabIndex = 6;
            this.btnRepeat.Text = "...";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 164);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.chkboxMaintMode);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnWatermark);
            this.Name = "FormMain";
            this.Text = "Watermarker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWatermark;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.CheckBox chkboxMaintMode;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Button btnRepeat;
    }
}

