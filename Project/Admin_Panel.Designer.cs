using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    partial class Admin_Panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Panel));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDashBoardAP = new System.Windows.Forms.Button();
            this.buttonActiveOrdersAP = new System.Windows.Forms.Button();
            this.buttonBookingAP = new System.Windows.Forms.Button();
            this.buttonMoneyCostAP = new System.Windows.Forms.Button();
            this.MenuList = new System.Windows.Forms.DataGridView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.UploadImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.quit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.comboBoxNames = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MenuList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.LeftPanel.SuspendLayout();
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
            this.buttonDashBoardAP.BackColor = System.Drawing.SystemColors.Window;
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
            this.buttonBookingAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonBookingAP.FlatAppearance.BorderSize = 0;
            this.buttonBookingAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookingAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBookingAP.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonBookingAP.Location = new System.Drawing.Point(9, 178);
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
            this.buttonMoneyCostAP.Location = new System.Drawing.Point(9, 232);
            this.buttonMoneyCostAP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoneyCostAP.Name = "buttonMoneyCostAP";
            this.buttonMoneyCostAP.Size = new System.Drawing.Size(188, 41);
            this.buttonMoneyCostAP.TabIndex = 5;
            this.buttonMoneyCostAP.Text = "\r\n";
            this.buttonMoneyCostAP.UseVisualStyleBackColor = false;
            // 
            // MenuList
            // 
            this.MenuList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.MenuList.ColumnHeadersHeight = 50;
            this.MenuList.Location = new System.Drawing.Point(675, 28);
            this.MenuList.Margin = new System.Windows.Forms.Padding(450, 3, 3, 3);
            this.MenuList.Name = "MenuList";
            this.MenuList.RowHeadersWidth = 47;
            this.MenuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.MenuList.Size = new System.Drawing.Size(582, 657);
            this.MenuList.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.Silver;
            this.textBoxName.Location = new System.Drawing.Point(265, 118);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(156, 28);
            this.textBoxName.TabIndex = 13;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.Silver;
            this.textBoxDescription.Location = new System.Drawing.Point(264, 192);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(157, 30);
            this.textBoxDescription.TabIndex = 14;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BackColor = System.Drawing.Color.Silver;
            this.textBoxPrice.Location = new System.Drawing.Point(265, 268);
            this.textBoxPrice.Multiline = true;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(156, 30);
            this.textBoxPrice.TabIndex = 15;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonAddItem.FlatAppearance.BorderSize = 0;
            this.buttonAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddItem.ForeColor = System.Drawing.Color.White;
            this.buttonAddItem.Location = new System.Drawing.Point(265, 363);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(156, 27);
            this.buttonAddItem.TabIndex = 17;
            this.buttonAddItem.Text = "Save and create";
            this.buttonAddItem.UseVisualStyleBackColor = false;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // UploadImage
            // 
            this.UploadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.UploadImage.FlatAppearance.BorderSize = 0;
            this.UploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadImage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UploadImage.ForeColor = System.Drawing.Color.White;
            this.UploadImage.Location = new System.Drawing.Point(265, 320);
            this.UploadImage.Name = "UploadImage";
            this.UploadImage.Size = new System.Drawing.Size(156, 27);
            this.UploadImage.TabIndex = 18;
            this.UploadImage.Text = "Upload image";
            this.UploadImage.UseVisualStyleBackColor = false;
            this.UploadImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Project.Properties.Resources.iconDashboard_grey_32px;
            this.pictureBox1.Location = new System.Drawing.Point(17, 78);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox5.Image = global::Project.Properties.Resources.iconTags_grey_32px;
            this.pictureBox5.Location = new System.Drawing.Point(18, 240);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.pictureBox2.Image = global::Project.Properties.Resources.iconCalendar_grey_32px2;
            this.pictureBox2.Location = new System.Drawing.Point(17, 187);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // quit
            // 
            this.quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quit.Image = ((System.Drawing.Image)(resources.GetObject("quit.Image")));
            this.quit.Location = new System.Drawing.Point(14, 677);
            this.quit.Margin = new System.Windows.Forms.Padding(0);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(32, 23);
            this.quit.TabIndex = 0;
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 243);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Money Cost";
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
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(55, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Booking\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(55, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Dashboard";
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(51)))));
            this.buttonDeleteItem.FlatAppearance.BorderSize = 0;
            this.buttonDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteItem.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteItem.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteItem.Location = new System.Drawing.Point(259, 577);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(162, 29);
            this.buttonDeleteItem.TabIndex = 24;
            this.buttonDeleteItem.Text = "Delete";
            this.buttonDeleteItem.UseVisualStyleBackColor = false;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBoxNames
            // 
            this.comboBoxNames.BackColor = System.Drawing.Color.Silver;
            this.comboBoxNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNames.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxNames.FormattingEnabled = true;
            this.comboBoxNames.IntegralHeight = false;
            this.comboBoxNames.ItemHeight = 20;
            this.comboBoxNames.Location = new System.Drawing.Point(259, 529);
            this.comboBoxNames.Name = "comboBoxNames";
            this.comboBoxNames.Size = new System.Drawing.Size(162, 28);
            this.comboBoxNames.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(243, 431);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 36);
            this.label6.TabIndex = 26;
            this.label6.Text = "Delete item";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(239, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 36);
            this.label7.TabIndex = 27;
            this.label7.Text = "Add item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(260, 82);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 26);
            this.label8.TabIndex = 28;
            this.label8.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(260, 156);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 26);
            this.label9.TabIndex = 29;
            this.label9.Text = "Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(261, 235);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 26);
            this.label10.TabIndex = 30;
            this.label10.Text = "Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(257, 493);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 26);
            this.label11.TabIndex = 31;
            this.label11.Text = "Select by name";
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(25)))));
            this.LeftPanel.Controls.Add(this.label1);
            this.LeftPanel.Location = new System.Drawing.Point(-1, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(223, 723);
            this.LeftPanel.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(466, 484);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 36);
            this.label12.TabIndex = 33;
            this.label12.Text = "New Promo";
            // 
            // Admin_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxNames);
            this.Controls.Add(this.buttonDeleteItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UploadImage);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.MenuList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonMoneyCostAP);
            this.Controls.Add(this.buttonBookingAP);
            this.Controls.Add(this.buttonActiveOrdersAP);
            this.Controls.Add(this.buttonDashBoardAP);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.LeftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_Panel";
            this.Text = "Admin_Panel";
            ((System.ComponentModel.ISupportInitialize)(this.MenuList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
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
        private DataGridView MenuList;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxPrice;
        private Button buttonAddItem;
        private Button UploadImage;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonDeleteItem;
        private ComboBox comboBoxNames;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Panel LeftPanel;
        private Label label12;
    }
}