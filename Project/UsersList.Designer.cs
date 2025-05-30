﻿using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    partial class UsersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersList));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDashBoardAP = new System.Windows.Forms.Button();
            this.buttonActiveOrdersAP = new System.Windows.Forms.Button();
            this.buttonBookingAP = new System.Windows.Forms.Button();
            this.buttonMoneyCostAP = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridViewUsersList = new System.Windows.Forms.DataGridView();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsersList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Panel";
            // 
            // buttonDashBoardAP
            // 
            this.buttonDashBoardAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonDashBoardAP.FlatAppearance.BorderSize = 0;
            this.buttonDashBoardAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashBoardAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonDashBoardAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonDashBoardAP.Location = new System.Drawing.Point(9, 73);
            this.buttonDashBoardAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDashBoardAP.Name = "buttonDashBoardAP";
            this.buttonDashBoardAP.Size = new System.Drawing.Size(188, 41);
            this.buttonDashBoardAP.TabIndex = 2;
            this.buttonDashBoardAP.UseVisualStyleBackColor = false;
            this.buttonDashBoardAP.Click += new System.EventHandler(this.buttonDashBoardAP_Click);
            // 
            // buttonActiveOrdersAP
            // 
            this.buttonActiveOrdersAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonActiveOrdersAP.FlatAppearance.BorderSize = 0;
            this.buttonActiveOrdersAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActiveOrdersAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonActiveOrdersAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonActiveOrdersAP.Location = new System.Drawing.Point(9, 124);
            this.buttonActiveOrdersAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActiveOrdersAP.Name = "buttonActiveOrdersAP";
            this.buttonActiveOrdersAP.Size = new System.Drawing.Size(188, 41);
            this.buttonActiveOrdersAP.TabIndex = 3;
            this.buttonActiveOrdersAP.UseVisualStyleBackColor = false;
            this.buttonActiveOrdersAP.Click += new System.EventHandler(this.buttonActiveOrdersAP_Click);
            // 
            // buttonBookingAP
            // 
            this.buttonBookingAP.BackColor = System.Drawing.SystemColors.Window;
            this.buttonBookingAP.FlatAppearance.BorderSize = 0;
            this.buttonBookingAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookingAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBookingAP.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonBookingAP.Location = new System.Drawing.Point(10, 232);
            this.buttonBookingAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBookingAP.Name = "buttonBookingAP";
            this.buttonBookingAP.Size = new System.Drawing.Size(188, 41);
            this.buttonBookingAP.TabIndex = 4;
            this.buttonBookingAP.UseVisualStyleBackColor = false;
            // 
            // buttonMoneyCostAP
            // 
            this.buttonMoneyCostAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonMoneyCostAP.FlatAppearance.BorderSize = 0;
            this.buttonMoneyCostAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoneyCostAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMoneyCostAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonMoneyCostAP.Location = new System.Drawing.Point(9, 178);
            this.buttonMoneyCostAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoneyCostAP.Name = "buttonMoneyCostAP";
            this.buttonMoneyCostAP.Size = new System.Drawing.Size(188, 41);
            this.buttonMoneyCostAP.TabIndex = 5;
            this.buttonMoneyCostAP.Text = "\r\n";
            this.buttonMoneyCostAP.UseVisualStyleBackColor = false;
            this.buttonMoneyCostAP.Click += new System.EventHandler(this.buttonMoneyCostAP_Click);
            // 
            // quit
            // 
            this.quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quit.BackgroundImage")));
            this.quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quit.Location = new System.Drawing.Point(14, 677);
            this.quit.Margin = new System.Windows.Forms.Padding(0);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(32, 23);
            this.quit.TabIndex = 0;
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Revenue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Orders";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(56, 242);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(55, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Dashboard";
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(25)))));
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Controls.Add(this.pictureBox2);
            this.LeftPanel.Controls.Add(this.label4);
            this.LeftPanel.Controls.Add(this.buttonBookingAP);
            this.LeftPanel.Location = new System.Drawing.Point(-1, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(223, 723);
            this.LeftPanel.TabIndex = 32;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Image = global::Project.Properties.Resources.iconCalendar_grey_32px;
            this.pictureBox2.Location = new System.Drawing.Point(18, 235);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox5.Image = global::Project.Properties.Resources.iconTags_grey_32px;
            this.pictureBox5.Location = new System.Drawing.Point(18, 186);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox1.Image = global::Project.Properties.Resources.iconDashboard_grey_32px1;
            this.pictureBox1.Location = new System.Drawing.Point(17, 78);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox3.Image = global::Project.Properties.Resources.iconOrderTelephone_grey_32px;
            this.pictureBox3.Location = new System.Drawing.Point(17, 132);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridViewUsersList
            // 
            this.dataGridViewUsersList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.dataGridViewUsersList.ColumnHeadersHeight = 50;
            this.dataGridViewUsersList.Location = new System.Drawing.Point(265, 28);
            this.dataGridViewUsersList.Margin = new System.Windows.Forms.Padding(450, 3, 3, 3);
            this.dataGridViewUsersList.Name = "dataGridViewUsersList";
            this.dataGridViewUsersList.RowHeadersWidth = 47;
            this.dataGridViewUsersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewUsersList.Size = new System.Drawing.Size(736, 607);
            this.dataGridViewUsersList.TabIndex = 34;
            this.dataGridViewUsersList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsersList_CellContentClick);
            // 
            // UsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.dataGridViewUsersList);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonMoneyCostAP);
            this.Controls.Add(this.buttonActiveOrdersAP);
            this.Controls.Add(this.buttonDashBoardAP);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.LeftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersList";
            this.Text = "Admin_Panel";
            this.Load += new System.EventHandler(this.UsersList_Load);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDashBoardAP;
        private System.Windows.Forms.Button buttonActiveOrdersAP;
        private System.Windows.Forms.Button buttonBookingAP;
        private System.Windows.Forms.Button buttonMoneyCostAP;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel LeftPanel;
        private DataGridView dataGridViewUsersList;
    }
}