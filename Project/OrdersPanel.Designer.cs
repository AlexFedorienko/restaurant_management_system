using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    partial class OrdersPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersPanel));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDashBoardAP = new System.Windows.Forms.Button();
            this.buttonActiveOrdersAP = new System.Windows.Forms.Button();
            this.buttonBookingAP = new System.Windows.Forms.Button();
            this.buttonMoneyCostAP = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(226, 7);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1043, 711);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(30, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
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
            this.buttonDashBoardAP.Location = new System.Drawing.Point(9, 45);
            this.buttonDashBoardAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDashBoardAP.Name = "buttonDashBoardAP";
            this.buttonDashBoardAP.Size = new System.Drawing.Size(188, 41);
            this.buttonDashBoardAP.TabIndex = 2;
            this.buttonDashBoardAP.Text = "Dashboard";
            this.buttonDashBoardAP.UseVisualStyleBackColor = false;
            // 
            // buttonActiveOrdersAP
            // 
            this.buttonActiveOrdersAP.BackColor = System.Drawing.Color.Black;
            this.buttonActiveOrdersAP.FlatAppearance.BorderSize = 0;
            this.buttonActiveOrdersAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActiveOrdersAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonActiveOrdersAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonActiveOrdersAP.Location = new System.Drawing.Point(9, 98);
            this.buttonActiveOrdersAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActiveOrdersAP.Name = "buttonActiveOrdersAP";
            this.buttonActiveOrdersAP.Size = new System.Drawing.Size(188, 41);
            this.buttonActiveOrdersAP.TabIndex = 3;
            this.buttonActiveOrdersAP.Text = "Orders";
            this.buttonActiveOrdersAP.UseVisualStyleBackColor = false;
            // 
            // buttonBookingAP
            // 
            this.buttonBookingAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonBookingAP.FlatAppearance.BorderSize = 0;
            this.buttonBookingAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookingAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBookingAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBookingAP.Location = new System.Drawing.Point(9, 152);
            this.buttonBookingAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBookingAP.Name = "buttonBookingAP";
            this.buttonBookingAP.Size = new System.Drawing.Size(188, 41);
            this.buttonBookingAP.TabIndex = 4;
            this.buttonBookingAP.Text = "Booking";
            this.buttonBookingAP.UseVisualStyleBackColor = false;
            // 
            // buttonMoneyCostAP
            // 
            this.buttonMoneyCostAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonMoneyCostAP.FlatAppearance.BorderSize = 0;
            this.buttonMoneyCostAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoneyCostAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMoneyCostAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonMoneyCostAP.Location = new System.Drawing.Point(9, 205);
            this.buttonMoneyCostAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoneyCostAP.Name = "buttonMoneyCostAP";
            this.buttonMoneyCostAP.Size = new System.Drawing.Size(188, 41);
            this.buttonMoneyCostAP.TabIndex = 5;
            this.buttonMoneyCostAP.Text = "Money cost";
            this.buttonMoneyCostAP.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(9, 260);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(188, 41);
            this.button6.TabIndex = 6;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project.Properties.Resources.iconDashboard_grey_32px1;
            this.pictureBox1.Location = new System.Drawing.Point(14, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.pictureBox5.Location = new System.Drawing.Point(16, 217);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(15, 15);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(16, 165);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 15);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project.Properties.Resources.iconCalendar_grey_32px1;
            this.pictureBox2.Location = new System.Drawing.Point(14, 105);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrdersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonMoneyCostAP);
            this.Controls.Add(this.buttonBookingAP);
            this.Controls.Add(this.buttonActiveOrdersAP);
            this.Controls.Add(this.buttonDashBoardAP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrdersPanel";
            this.Text = "Admin_Panel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDashBoardAP;
        private System.Windows.Forms.Button buttonActiveOrdersAP;
        private System.Windows.Forms.Button buttonBookingAP;
        private System.Windows.Forms.Button buttonMoneyCostAP;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}