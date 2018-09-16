namespace Stampyx
{
    partial class FormWatermarkLocations
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
            this.btnLowerLeft = new System.Windows.Forms.Button();
            this.btnLowerRight = new System.Windows.Forms.Button();
            this.btnUpperLeft = new System.Windows.Forms.Button();
            this.btnUpperRight = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLowerLeft
            // 
            this.btnLowerLeft.Location = new System.Drawing.Point(12, 69);
            this.btnLowerLeft.Name = "btnLowerLeft";
            this.btnLowerLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLowerLeft.TabIndex = 0;
            this.btnLowerLeft.Text = "Lower left";
            this.btnLowerLeft.UseVisualStyleBackColor = true;
            this.btnLowerLeft.Click += new System.EventHandler(this.btnLowerLeft_Click);
            // 
            // btnLowerRight
            // 
            this.btnLowerRight.Location = new System.Drawing.Point(154, 69);
            this.btnLowerRight.Name = "btnLowerRight";
            this.btnLowerRight.Size = new System.Drawing.Size(75, 23);
            this.btnLowerRight.TabIndex = 1;
            this.btnLowerRight.Text = "Lower right";
            this.btnLowerRight.UseVisualStyleBackColor = true;
            this.btnLowerRight.Click += new System.EventHandler(this.btnLowerRight_Click);
            // 
            // btnUpperLeft
            // 
            this.btnUpperLeft.Location = new System.Drawing.Point(12, 12);
            this.btnUpperLeft.Name = "btnUpperLeft";
            this.btnUpperLeft.Size = new System.Drawing.Size(75, 23);
            this.btnUpperLeft.TabIndex = 2;
            this.btnUpperLeft.Text = "Upper left";
            this.btnUpperLeft.UseVisualStyleBackColor = true;
            this.btnUpperLeft.Click += new System.EventHandler(this.btnUpperLeft_Click);
            // 
            // btnUpperRight
            // 
            this.btnUpperRight.Location = new System.Drawing.Point(154, 12);
            this.btnUpperRight.Name = "btnUpperRight";
            this.btnUpperRight.Size = new System.Drawing.Size(75, 23);
            this.btnUpperRight.TabIndex = 3;
            this.btnUpperRight.Text = "Upper right";
            this.btnUpperRight.UseVisualStyleBackColor = true;
            this.btnUpperRight.Click += new System.EventHandler(this.btnUpperRight_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.Location = new System.Drawing.Point(83, 40);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(75, 23);
            this.btnCenter.TabIndex = 4;
            this.btnCenter.Text = "Center";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(154, 117);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormWatermarkLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(241, 152);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCenter);
            this.Controls.Add(this.btnUpperRight);
            this.Controls.Add(this.btnUpperLeft);
            this.Controls.Add(this.btnLowerRight);
            this.Controls.Add(this.btnLowerLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWatermarkLocations";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit a watermark";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLowerLeft;
        private System.Windows.Forms.Button btnLowerRight;
        private System.Windows.Forms.Button btnUpperLeft;
        private System.Windows.Forms.Button btnUpperRight;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnOk;
    }
}