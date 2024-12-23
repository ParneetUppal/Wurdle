namespace WindowsFormsApp.Parneet.Kaur
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.btnaboutformOK = new System.Windows.Forms.Button();
            this.lblappversion = new System.Windows.Forms.Label();
            this.lblapptitle = new System.Windows.Forms.Label();
            this.lblcopyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnaboutformOK
            // 
            this.btnaboutformOK.Location = new System.Drawing.Point(146, 203);
            this.btnaboutformOK.Name = "btnaboutformOK";
            this.btnaboutformOK.Size = new System.Drawing.Size(75, 23);
            this.btnaboutformOK.TabIndex = 0;
            this.btnaboutformOK.Text = "OK";
            this.btnaboutformOK.UseVisualStyleBackColor = true;
            // 
            // lblappversion
            // 
            this.lblappversion.AutoSize = true;
            this.lblappversion.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblappversion.Location = new System.Drawing.Point(63, 144);
            this.lblappversion.Name = "lblappversion";
            this.lblappversion.Size = new System.Drawing.Size(258, 18);
            this.lblappversion.TabIndex = 1;
            this.lblappversion.Text = "Application Version: 1.0 ";
            // 
            // lblapptitle
            // 
            this.lblapptitle.AutoSize = true;
            this.lblapptitle.Font = new System.Drawing.Font("Baskerville Old Face", 32F);
            this.lblapptitle.Location = new System.Drawing.Point(12, 90);
            this.lblapptitle.Name = "lblapptitle";
            this.lblapptitle.Size = new System.Drawing.Size(368, 49);
            this.lblapptitle.TabIndex = 2;
            this.lblapptitle.Text = "Vehicle Quote App ";
            // 
            // lblcopyright
            // 
            this.lblcopyright.AutoSize = true;
            this.lblcopyright.Location = new System.Drawing.Point(104, 176);
            this.lblcopyright.Name = "lblcopyright";
            this.lblcopyright.Size = new System.Drawing.Size(161, 13);
            this.lblcopyright.TabIndex = 3;
            this.lblcopyright.Text = "Copyright © 2024 - Parneet Kaur";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(107, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(143, 81);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Logo Credits ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblcopyright);
            this.Controls.Add(this.lblapptitle);
            this.Controls.Add(this.lblappversion);
            this.Controls.Add(this.btnaboutformOK);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnaboutformOK;
        private System.Windows.Forms.Label lblappversion;
        private System.Windows.Forms.Label lblapptitle;
        private System.Windows.Forms.Label lblcopyright;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}