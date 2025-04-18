﻿using System.Windows.Forms;

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
            this.textBox_Login = new RoundedRichTextBox();
            this.roundedButton1 = new RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Psw = new RoundedRichTextBox();
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
            this.gradientPanel1.Controls.Add(this.textBox_Psw);
            this.gradientPanel1.Controls.Add(this.textBox_Login);
            this.gradientPanel1.Controls.Add(this.roundedButton1);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.signUpBtn);
            this.gradientPanel1.Controls.Add(this.button1);
            this.gradientPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradientPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gradientPanel1.Location = new System.Drawing.Point(-1, -3);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(369, 496);
            this.gradientPanel1.TabIndex = 12;
            this.gradientPanel1.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(92)))), ((int)(((byte)(123)))));
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint_1);
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
            this.roundedButton1.BackColor = System.Drawing.Color.Blue;
            this.roundedButton1.BorderRadius = 40;
            this.roundedButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roundedButton1.Location = new System.Drawing.Point(13, 415);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(330, 36);
            this.roundedButton1.TabIndex = 13;
            this.roundedButton1.Text = " SIGN IN";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.btnEnterSignIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.GhostWhite;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // signUpBtn
            // 
            this.signUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signUpBtn.Location = new System.Drawing.Point(197, 35);
            this.signUpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(92, 23);
            this.signUpBtn.TabIndex = 6;
            this.signUpBtn.Text = "SIGN UP";
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(48, 35);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "SIGN IN";
            this.button1.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private GradientPanel gradientPanel1;
        private RoundedButton roundedButton1;
        private RoundedRichTextBox textBox_Login;
        private RoundedRichTextBox textBox_Psw;
    }
}