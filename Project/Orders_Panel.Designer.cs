﻿using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    partial class Orders_Panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_Panel));
            this.article = new System.Windows.Forms.Label();
            this.buttonDashBoardAP = new System.Windows.Forms.Button();
            this.buttonActiveOrdersAP = new System.Windows.Forms.Button();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRevenue = new System.Windows.Forms.Button();
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.latestOrdersPanel = new System.Windows.Forms.Label();
            this.firstIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // article
            // 
            this.article.AutoSize = true;
            this.article.BackColor = System.Drawing.Color.Transparent;
            this.article.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.article.ForeColor = System.Drawing.Color.White;
            this.article.Location = new System.Drawing.Point(19, 18);
            this.article.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.article.Name = "article";
            this.article.Size = new System.Drawing.Size(182, 32);
            this.article.TabIndex = 0;
            this.article.Text = "Orders Panel";
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
            this.buttonDashBoardAP.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // buttonActiveOrdersAP
            // 
            this.buttonActiveOrdersAP.BackColor = System.Drawing.SystemColors.Window;
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
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.dataGridViewOrder.ColumnHeadersHeight = 50;
            this.dataGridViewOrder.Location = new System.Drawing.Point(272, 82);
            this.dataGridViewOrder.Margin = new System.Windows.Forms.Padding(450, 3, 3, 3);
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.RowHeadersWidth = 47;
            this.dataGridViewOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewOrder.Size = new System.Drawing.Size(736, 256);
            this.dataGridViewOrder.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(55, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Orders";
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
            this.LeftPanel.Controls.Add(this.pictureBox2);
            this.LeftPanel.Controls.Add(this.label4);
            this.LeftPanel.Controls.Add(this.buttonSettings);
            this.LeftPanel.Controls.Add(this.pictureBox4);
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Controls.Add(this.buttonRevenue);
            this.LeftPanel.Controls.Add(this.article);
            this.LeftPanel.Location = new System.Drawing.Point(-1, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(223, 723);
            this.LeftPanel.TabIndex = 32;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox2.Image = global::Project.Properties.Resources.iconCalendar_grey_32px2;
            this.pictureBox2.Location = new System.Drawing.Point(18, 236);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 243);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Settings";
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonSettings.Location = new System.Drawing.Point(10, 233);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(188, 41);
            this.buttonSettings.TabIndex = 26;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox4.Image = global::Project.Properties.Resources.iconTags_grey_32px;
            this.pictureBox4.Location = new System.Drawing.Point(19, 186);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 24;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 189);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Revenue";
            // 
            // buttonRevenue
            // 
            this.buttonRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonRevenue.FlatAppearance.BorderSize = 0;
            this.buttonRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRevenue.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonRevenue.Location = new System.Drawing.Point(10, 178);
            this.buttonRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRevenue.Name = "buttonRevenue";
            this.buttonRevenue.Size = new System.Drawing.Size(188, 41);
            this.buttonRevenue.TabIndex = 23;
            this.buttonRevenue.Text = "\r\n";
            this.buttonRevenue.UseVisualStyleBackColor = false;
            this.buttonRevenue.Click += new System.EventHandler(this.buttonRevenue_Click);
            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.dataGridViewOrderItems.ColumnHeadersHeight = 50;
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(272, 353);
            this.dataGridViewOrderItems.Margin = new System.Windows.Forms.Padding(450, 3, 3, 3);
            this.dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            this.dataGridViewOrderItems.RowHeadersWidth = 47;
            this.dataGridViewOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(736, 336);
            this.dataGridViewOrderItems.TabIndex = 33;
            // 
            // latestOrdersPanel
            // 
            this.latestOrdersPanel.AutoSize = true;
            this.latestOrdersPanel.BackColor = System.Drawing.Color.Transparent;
            this.latestOrdersPanel.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.latestOrdersPanel.ForeColor = System.Drawing.Color.White;
            this.latestOrdersPanel.Location = new System.Drawing.Point(316, 21);
            this.latestOrdersPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.latestOrdersPanel.Name = "latestOrdersPanel";
            this.latestOrdersPanel.Size = new System.Drawing.Size(198, 36);
            this.latestOrdersPanel.TabIndex = 34;
            this.latestOrdersPanel.Text = "Latest Orders";
            // 
            // firstIcon
            // 
            this.firstIcon.BackColor = System.Drawing.Color.Transparent;
            this.firstIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.firstIcon.Image = global::Project.Properties.Resources.cart;
            this.firstIcon.Location = new System.Drawing.Point(274, 23);
            this.firstIcon.Margin = new System.Windows.Forms.Padding(2);
            this.firstIcon.Name = "firstIcon";
            this.firstIcon.Size = new System.Drawing.Size(35, 35);
            this.firstIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.firstIcon.TabIndex = 35;
            this.firstIcon.TabStop = false;
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
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox3.Image = global::Project.Properties.Resources.iconOrderTelephone_grey_32px;
            this.pictureBox3.Location = new System.Drawing.Point(17, 132);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(14, 677);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.quit_Click);
            // 
            // Orders_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.firstIcon);
            this.Controls.Add(this.latestOrdersPanel);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewOrder);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonActiveOrdersAP);
            this.Controls.Add(this.buttonDashBoardAP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LeftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Orders_Panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Panel";
            this.Load += new System.EventHandler(this.Orders_Panel_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label article;
        private System.Windows.Forms.Button buttonDashBoardAP;
        private System.Windows.Forms.Button buttonActiveOrdersAP;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataGridView dataGridViewOrder;
        private Label label3;
        private Label label5;
        private Panel LeftPanel;
        private DataGridView dataGridViewOrderItems;
        private Label latestOrdersPanel;
        private PictureBox firstIcon;
        private PictureBox pictureBox4;
        private Label label1;
        private Button buttonRevenue;
        private PictureBox pictureBox2;
        private Label label4;
        private Button buttonSettings;
    }
}