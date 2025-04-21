using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            this.exitButton = new System.Windows.Forms.Button();
            this.gradientPanel1 = new Project.GradientPanel();
            this.textBox_Psw = new RoundedRichTextBox();
            this.textBox_Login = new RoundedRichTextBox();
            this.roundedButton1 = new RoundedButton();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(322, 8);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(35, 20);
            this.exitButton.TabIndex = 8;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 80F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(93)))), ((int)(((byte)(150)))));
            this.gradientPanel1.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(96)))));
            this.gradientPanel1.Controls.Add(this.guna2HtmlLabel4);
            this.gradientPanel1.Controls.Add(this.guna2HtmlLabel3);
            this.gradientPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.gradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.gradientPanel1.Controls.Add(this.textBox_Psw);
            this.gradientPanel1.Controls.Add(this.textBox_Login);
            this.gradientPanel1.Controls.Add(this.roundedButton1);
            this.gradientPanel1.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gradientPanel1.Location = new System.Drawing.Point(-1, -3);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(369, 496);
            this.gradientPanel1.TabIndex = 12;
            this.gradientPanel1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(92)))), ((int)(((byte)(123)))));
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint_1);
            // 
            // textBox_Psw
            // 
            this.textBox_Psw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            this.textBox_Psw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Psw.BulletIndent = 1;
            this.textBox_Psw.CornerRadius = 20;
            this.textBox_Psw.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox_Psw.Location = new System.Drawing.Point(24, 202);
            this.textBox_Psw.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Psw.MaximumSize = new System.Drawing.Size(100000, 100000);
            this.textBox_Psw.Name = "textBox_Psw";
            this.textBox_Psw.Size = new System.Drawing.Size(326, 40);
            this.textBox_Psw.TabIndex = 16;
            this.textBox_Psw.Text = "";
            // 
            // textBox_Login
            // 
            this.textBox_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(117)))), ((int)(((byte)(150)))));
            this.textBox_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Login.BulletIndent = 1;
            this.textBox_Login.CornerRadius = 20;
            this.textBox_Login.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox_Login.Location = new System.Drawing.Point(24, 114);
            this.textBox_Login.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Login.MaximumSize = new System.Drawing.Size(100000, 100000);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(326, 40);
            this.textBox_Login.TabIndex = 15;
            this.textBox_Login.Text = "";
            this.textBox_Login.TextChanged += new System.EventHandler(this.loginTextBox_TextChanged);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.RoyalBlue;
            this.roundedButton1.BorderRadius = 40;
            this.roundedButton1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roundedButton1.Location = new System.Drawing.Point(13, 415);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(330, 36);
            this.roundedButton1.TabIndex = 13;
            this.roundedButton1.Text = " SIGN IN";
            this.roundedButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.btnEnterSignIn_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(29, 85);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(74, 23);
            this.guna2HtmlLabel1.TabIndex = 17;
            this.guna2HtmlLabel1.Text = "Username";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(29, 173);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(70, 23);
            this.guna2HtmlLabel2.TabIndex = 18;
            this.guna2HtmlLabel2.Text = "Password";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(29, 35);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(59, 23);
            this.guna2HtmlLabel3.TabIndex = 19;
            this.guna2HtmlLabel3.Text = "SIGN IN";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.SystemColors.Control;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(131, 35);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(63, 23);
            this.guna2HtmlLabel4.TabIndex = 20;
            this.guna2HtmlLabel4.Text = "SIGN UP";
            this.guna2HtmlLabel4.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 490);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Auth";
            this.Text = "Sign In";
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private GradientPanel gradientPanel1;
        private RoundedButton roundedButton1;
        private RoundedRichTextBox textBox_Login;
        private RoundedRichTextBox textBox_Psw;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    }
}