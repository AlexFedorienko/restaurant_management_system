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
            this.textBoxLoginS = new System.Windows.Forms.TextBox();
            this.labelLoginS = new System.Windows.Forms.Label();
            this.labelEmailS = new System.Windows.Forms.Label();
            this.textBoxEmailS = new System.Windows.Forms.TextBox();
            this.labelPasswordS = new System.Windows.Forms.Label();
            this.textBoxPasswordS = new System.Windows.Forms.TextBox();
            this.buttonSaveExitS = new System.Windows.Forms.Button();
            this.VisibleButtonS = new System.Windows.Forms.Button();
            this.PensilButton = new System.Windows.Forms.Button();
            this.UserImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLoginS
            // 
            this.textBoxLoginS.Location = new System.Drawing.Point(110, 218);
            this.textBoxLoginS.Multiline = true;
            this.textBoxLoginS.Name = "textBoxLoginS";
            this.textBoxLoginS.Size = new System.Drawing.Size(200, 30);
            this.textBoxLoginS.TabIndex = 8;
            // 
            // labelLoginS
            // 
            this.labelLoginS.AutoSize = true;
            this.labelLoginS.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoginS.Location = new System.Drawing.Point(106, 192);
            this.labelLoginS.Name = "labelLoginS";
            this.labelLoginS.Size = new System.Drawing.Size(65, 23);
            this.labelLoginS.TabIndex = 9;
            this.labelLoginS.Text = "Login";
            // 
            // labelEmailS
            // 
            this.labelEmailS.AutoSize = true;
            this.labelEmailS.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmailS.Location = new System.Drawing.Point(106, 253);
            this.labelEmailS.Name = "labelEmailS";
            this.labelEmailS.Size = new System.Drawing.Size(65, 23);
            this.labelEmailS.TabIndex = 11;
            this.labelEmailS.Text = "Email";
            // 
            // textBoxEmailS
            // 
            this.textBoxEmailS.Location = new System.Drawing.Point(110, 279);
            this.textBoxEmailS.Multiline = true;
            this.textBoxEmailS.Name = "textBoxEmailS";
            this.textBoxEmailS.Size = new System.Drawing.Size(200, 30);
            this.textBoxEmailS.TabIndex = 10;
            // 
            // labelPasswordS
            // 
            this.labelPasswordS.AutoSize = true;
            this.labelPasswordS.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPasswordS.Location = new System.Drawing.Point(106, 314);
            this.labelPasswordS.Name = "labelPasswordS";
            this.labelPasswordS.Size = new System.Drawing.Size(98, 23);
            this.labelPasswordS.TabIndex = 13;
            this.labelPasswordS.Text = "Password";
            // 
            // textBoxPasswordS
            // 
            this.textBoxPasswordS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPasswordS.Location = new System.Drawing.Point(110, 340);
            this.textBoxPasswordS.Multiline = true;
            this.textBoxPasswordS.Name = "textBoxPasswordS";
            this.textBoxPasswordS.Size = new System.Drawing.Size(200, 30);
            this.textBoxPasswordS.TabIndex = 12;
            // 
            // buttonSaveExitS
            // 
            this.buttonSaveExitS.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveExitS.Location = new System.Drawing.Point(144, 408);
            this.buttonSaveExitS.Name = "buttonSaveExitS";
            this.buttonSaveExitS.Size = new System.Drawing.Size(145, 42);
            this.buttonSaveExitS.TabIndex = 14;
            this.buttonSaveExitS.Text = "Save, Exit";
            this.buttonSaveExitS.UseVisualStyleBackColor = true;
            this.buttonSaveExitS.Click += new System.EventHandler(this.SaveExitButton_Click);
            // 
            // VisibleButtonS
            // 
            this.VisibleButtonS.Image = global::Project.Properties.Resources.iconEye_dark_blue_32px3917159;
            this.VisibleButtonS.Location = new System.Drawing.Point(310, 339);
            this.VisibleButtonS.Name = "VisibleButtonS";
            this.VisibleButtonS.Size = new System.Drawing.Size(40, 32);
            this.VisibleButtonS.TabIndex = 15;
            this.VisibleButtonS.UseVisualStyleBackColor = true;
            this.VisibleButtonS.Click += new System.EventHandler(this.VisibleButtonS_Click);
            // 
            // PensilButton
            // 
            this.PensilButton.Image = ((System.Drawing.Image)(resources.GetObject("PensilButton.Image")));
            this.PensilButton.Location = new System.Drawing.Point(254, 137);
            this.PensilButton.Name = "PensilButton";
            this.PensilButton.Size = new System.Drawing.Size(35, 35);
            this.PensilButton.TabIndex = 7;
            this.PensilButton.UseVisualStyleBackColor = true;
            this.PensilButton.Click += new System.EventHandler(this.PensilButton_Click);
            // 
            // UserImage
            // 
            this.UserImage.Image = ((System.Drawing.Image)(resources.GetObject("UserImage.Image")));
            this.UserImage.Location = new System.Drawing.Point(144, 40);
            this.UserImage.Name = "UserImage";
            this.UserImage.Size = new System.Drawing.Size(145, 132);
            this.UserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserImage.TabIndex = 5;
            this.UserImage.TabStop = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 490);
            this.Controls.Add(this.VisibleButtonS);
            this.Controls.Add(this.buttonSaveExitS);
            this.Controls.Add(this.labelPasswordS);
            this.Controls.Add(this.textBoxPasswordS);
            this.Controls.Add(this.labelEmailS);
            this.Controls.Add(this.textBoxEmailS);
            this.Controls.Add(this.labelLoginS);
            this.Controls.Add(this.textBoxLoginS);
            this.Controls.Add(this.PensilButton);
            this.Controls.Add(this.UserImage);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox UserImage;
        private System.Windows.Forms.Button PensilButton;
        private System.Windows.Forms.TextBox textBoxLoginS;
        private System.Windows.Forms.Label labelLoginS;
        private System.Windows.Forms.Label labelEmailS;
        private System.Windows.Forms.TextBox textBoxEmailS;
        private System.Windows.Forms.Label labelPasswordS;
        private System.Windows.Forms.TextBox textBoxPasswordS;
        private System.Windows.Forms.Button buttonSaveExitS;
        private System.Windows.Forms.Button VisibleButtonS;
    }
}