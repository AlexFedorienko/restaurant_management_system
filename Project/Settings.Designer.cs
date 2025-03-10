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
            this.btnEnterUploadImageWs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnterUploadImageWs
            // 
            this.btnEnterUploadImageWs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEnterUploadImageWs.Location = new System.Drawing.Point(142, 213);
            this.btnEnterUploadImageWs.Name = "btnEnterUploadImageWs";
            this.btnEnterUploadImageWs.Size = new System.Drawing.Size(120, 35);
            this.btnEnterUploadImageWs.TabIndex = 3;
            this.btnEnterUploadImageWs.Text = "Upload";
            this.btnEnterUploadImageWs.UseVisualStyleBackColor = true;
            this.btnEnterUploadImageWs.Click += new System.EventHandler(this.btnEnterUploadImageWs_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 437);
            this.Controls.Add(this.btnEnterUploadImageWs);
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnterUploadImageWs;
    }
}