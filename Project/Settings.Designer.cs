namespace Project
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.UserImage = new System.Windows.Forms.PictureBox();
            this.PensilButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // UserImage
            // 
            this.UserImage.Image = ((System.Drawing.Image)(resources.GetObject("UserImage.Image")));
            this.UserImage.Location = new System.Drawing.Point(144, 15);
            this.UserImage.Name = "UserImage";
            this.UserImage.Size = new System.Drawing.Size(145, 132);
            this.UserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserImage.TabIndex = 5;
            this.UserImage.TabStop = false;
            // 
            // PensilButton
            // 
            this.PensilButton.Image = ((System.Drawing.Image)(resources.GetObject("PensilButton.Image")));
            this.PensilButton.Location = new System.Drawing.Point(254, 112);
            this.PensilButton.Name = "PensilButton";
            this.PensilButton.Size = new System.Drawing.Size(35, 35);
            this.PensilButton.TabIndex = 7;
            this.PensilButton.UseVisualStyleBackColor = true;
            this.PensilButton.Click += new System.EventHandler(this.PensilButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 490);
            this.Controls.Add(this.PensilButton);
            this.Controls.Add(this.UserImage);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox UserImage;
        private System.Windows.Forms.Button PensilButton;
    }
}