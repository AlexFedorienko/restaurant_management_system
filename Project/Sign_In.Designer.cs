namespace Project
{
    partial class Auth
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
            this.textBox_Login = new System.Windows.Forms.RichTextBox();
            this.textBox_Psw = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.btnEnterSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(26, 97);
            this.textBox_Login.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(300, 49);
            this.textBox_Login.TabIndex = 1;
            this.textBox_Login.Text = "";
            // 
            // textBox_Psw
            // 
            this.textBox_Psw.Location = new System.Drawing.Point(26, 185);
            this.textBox_Psw.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Psw.Name = "textBox_Psw";
            this.textBox_Psw.Size = new System.Drawing.Size(300, 49);
            this.textBox_Psw.TabIndex = 2;
            this.textBox_Psw.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "SIGN IN";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // signUpBtn
            // 
            this.signUpBtn.Location = new System.Drawing.Point(195, 10);
            this.signUpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(92, 23);
            this.signUpBtn.TabIndex = 6;
            this.signUpBtn.Text = "SIGN UP";
            this.signUpBtn.UseVisualStyleBackColor = true;
            // 
            // btnEnterSignIn
            // 
            this.btnEnterSignIn.Location = new System.Drawing.Point(26, 401);
            this.btnEnterSignIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnterSignIn.Name = "btnEnterSignIn";
            this.btnEnterSignIn.Size = new System.Drawing.Size(298, 36);
            this.btnEnterSignIn.TabIndex = 7;
            this.btnEnterSignIn.Text = "SIGN IN";
            this.btnEnterSignIn.UseVisualStyleBackColor = true;
            this.btnEnterSignIn.Click += new System.EventHandler(this.btnEnterSignIn_Click);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 490);
            this.Controls.Add(this.btnEnterSignIn);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_Psw);
            this.Controls.Add(this.textBox_Login);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Auth";
            this.Text = "Sign In";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox textBox_Login;
        private System.Windows.Forms.RichTextBox textBox_Psw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Button btnEnterSignIn;
    }
}