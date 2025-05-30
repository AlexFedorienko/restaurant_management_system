﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Project.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Project
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();

        Auth auth = new Auth();
        Admin_Panel adminPanel = new Admin_Panel();
        Finance finance;
        News news;
        Gallery gallery;

        private string userName;
        private int userId;
        private List<CartItem> cart = new List<CartItem>();

        private Button applyButton;
        private Label originalTotalLabel;
        private decimal currentTotal = 0;
        private decimal discountPercent = 0;
        private bool discountApplied = false;
        private Timer timeUpdateTimer;

        public Color Transparent { get; private set; }
        public string UserAddress { get; set; }

        public class TransparentLabel : Label
        {
            public TransparentLabel()
            {
                SetStyle(ControlStyles.Opaque, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x20;
                    return cp;
                }
            }
        }

        public class CartItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string Category { get; set; }
        }

        public Form1(string userName, int userId)
        {
            InitializeComponent();
            this.userName = userName;
            this.userId = userId;

            StartPosition = FormStartPosition.CenterScreen;

            int radius = 70;
            this.Width = 1920;
            this.Height = 1080;
            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.None;
            panel1.Region = new Region(CreateRoundRectangle(panel1.ClientRectangle, radius));

            labelName.Text = userName;
            labelName2.Text = userName.ToUpper();
            comboBox.Text = userName;

            LoadUserImage(userId);
            LoadUserAddress();
            MakePictureBoxRound(pictureBox1);

            MakeButtonRound(button1, 30);
            MakeButtonRound(button2, 30);
            MakeButtonRound(button3, 30);
            MakeButtonRound(button4, 30);
            MakeButtonRound(button5, 30);
            MakeButtonRound(SettingsButton, 20);

            flowLayoutPanelPayment.Controls.Add(couponcodeTextBox);
            couponcodeTextBox.Location = new Point(20, 250);

            promoTextBox.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(promoTextBox.Text))
                    couponcodeTextBox.Hide();
                else
                    couponcodeTextBox.Show();
            };

            timeUpdateTimer = new Timer();
            timeUpdateTimer.Interval = 1000;
            timeUpdateTimer.Tick += UpdateCurrentTime;
            timeUpdateTimer.Start();

            UpdateCurrentTime(null, null);
        }

        private void UpdateCurrentTime(object sender, EventArgs e)
        {
            timeTextBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void LoadUserAddress()
        {
            try
            {
                dataBase.openConnection();

                using (var cmd = new SqlCommand("SELECT user_adress FROM Auth WHERE id = @userId",
                                              dataBase.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    object result = cmd.ExecuteScalar();
                    UserAddress = result?.ToString() ?? string.Empty;
                    adressTextBox.Text = UserAddress;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке адреса: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserAddress = string.Empty;
                adressTextBox.Text = string.Empty;
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void ApplyPromoCode_Click(object sender, EventArgs e)
        {
            string promoCode = promoTextBox.Text.Trim();

            if (string.IsNullOrEmpty(promoCode))
            {
                MessageBox.Show("Please enter a promo code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dataBase.openConnection();

                string query = "SELECT discount_percent FROM Promocodes WHERE code = @PromoCode";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                command.Parameters.AddWithValue("@PromoCode", promoCode);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    discountPercent = Convert.ToDecimal(result);
                    discountApplied = true;
                    MessageBox.Show($"Discount applied! {discountPercent}% off", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateCartDisplay();
                }
                else
                {
                    MessageBox.Show("Invalid promo code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    discountApplied = false;
                    discountPercent = 0;
                    UpdateCartDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying promo code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void promoTextBox_FontChanged(object sender, EventArgs e)
        {
            if (couponcodeTextBox != null)
            {
                couponcodeTextBox.Hide();
            }
        }

        private static GraphicsPath CreateRoundRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void MakePictureBoxRound(PictureBox pictureBox)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
            g.SetClip(path);
            g.DrawImage(pictureBox.Image, 0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
        }

        public void LoadUserImage(int userId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"SELECT image_user FROM Auth WHERE id = @userId";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            command.Parameters.AddWithValue("@userId", userId);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                byte[] imageData = table.Rows[0]["image_user"] as byte[];
                if (imageData != null)
                {
                    MemoryStream ms = new MemoryStream(imageData);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void SaveImageToDatabase(byte[] imageBytes)
        {
            string query = "UPDATE Auth SET image_user = @image WHERE id = @userId";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = Auth.UserId;

            dataBase.openConnection();

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Image uploaded successfully.");
            }
            else
            {
                MessageBox.Show("Error uploading image.");
            }
            dataBase.closeConnection();
        }

        public void UpdateUserImage()
        {
            LoadUserImage(Auth.UserId);
        }

        private void btnEnterUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                byte[] imageBytes = File.ReadAllBytes(imagePath);

                SaveImageToDatabase(imageBytes);
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settingsWindow = new Settings(this);
            settingsWindow.Show();
        }

        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {
            Admin_Panel adminPanel = new Admin_Panel(userName, userId);
            adminPanel.ShowDialog();
            this.Hide();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            auth.Show();
            this.Hide();
        }

        private void MakeButtonRound(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius - 1, button.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;

            button1.BackColor = Color.SeaGreen;
            label3.BackColor = Color.SeaGreen;
            label3.ForeColor = Color.White;

            label4.BackColor = Color.White;
            label4.ForeColor = Color.SeaGreen;

            firstIcon.Image = Properties.Resources.dashboard_white1;
            firstIcon.BackColor = Color.SeaGreen;

            secondIcon.Image = Properties.Resources.creditcards_green;
            secondIcon.BackColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.SeaGreen;

            button1.BackColor = Color.White;
            label3.BackColor = Color.White;
            label3.ForeColor = Color.SeaGreen;

            label4.BackColor = Color.SeaGreen;
            label4.ForeColor = Color.White;

            firstIcon.Image = Properties.Resources.dashboard_green1;
            firstIcon.BackColor = Color.White;

            secondIcon.Image = Properties.Resources.creditcards_white;
            secondIcon.BackColor = Color.SeaGreen;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;

            button1.BackColor = Color.SeaGreen;
            label3.BackColor = Color.SeaGreen;
            label3.ForeColor = Color.White;

            label5.BackColor = Color.White;
            label5.ForeColor = Color.SeaGreen;

            firstIcon.Image = Properties.Resources.dashboard_white1;
            firstIcon.BackColor = Color.SeaGreen;

            thirdIcon.Image = Properties.Resources.news_green;
            thirdIcon.BackColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.SeaGreen;

            button1.BackColor = Color.White;
            label3.BackColor = Color.White;
            label3.ForeColor = Color.SeaGreen;

            label5.BackColor = Color.SeaGreen;
            label5.ForeColor = Color.White;

            firstIcon.Image = Properties.Resources.dashboard_green1;
            firstIcon.BackColor = Color.White;

            thirdIcon.Image = Properties.Resources.news_white;
            thirdIcon.BackColor = Color.SeaGreen;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;

            button1.BackColor = Color.SeaGreen;
            label3.BackColor = Color.SeaGreen;
            label3.ForeColor = Color.White;

            label6.BackColor = Color.White;
            label6.ForeColor = Color.SeaGreen;

            firstIcon.Image = Properties.Resources.dashboard_white1;
            firstIcon.BackColor = Color.SeaGreen;

            fourthIcon.Image = Properties.Resources.gallery_green;
            fourthIcon.BackColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SeaGreen;

            button1.BackColor = Color.White;
            label3.BackColor = Color.White;
            label3.ForeColor = Color.SeaGreen;

            label6.BackColor = Color.SeaGreen;
            label6.ForeColor = Color.White;

            firstIcon.Image = Properties.Resources.dashboard_green1;
            firstIcon.BackColor = Color.White;

            fourthIcon.Image = Properties.Resources.gallery_white;
            fourthIcon.BackColor = Color.SeaGreen;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;

            button1.BackColor = Color.SeaGreen;
            label3.BackColor = Color.SeaGreen;
            label3.ForeColor = Color.White;

            label7.BackColor = Color.White;
            label7.ForeColor = Color.SeaGreen;

            firstIcon.Image = Properties.Resources.dashboard_white1;
            firstIcon.BackColor = Color.SeaGreen;

            fifthIcon.Image = Properties.Resources.logout_green;
            fifthIcon.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.SeaGreen;

            button1.BackColor = Color.White;
            label3.BackColor = Color.White;
            label3.ForeColor = Color.SeaGreen;

            label7.BackColor = Color.SeaGreen;
            label7.ForeColor = Color.White;

            firstIcon.Image = Properties.Resources.dashboard_green1;
            firstIcon.BackColor = Color.White;

            fifthIcon.Image = Properties.Resources.logout_white;
            fifthIcon.BackColor = Color.SeaGreen;
        }

        private void LoadMenuItems(string searchText = "")
        {
            dataBase.openConnection();
            string query = "SELECT * FROM Menu";

            if (!string.IsNullOrEmpty(searchText))
            {
                query += " WHERE Name LIKE @SearchText";
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            if (!string.IsNullOrEmpty(searchText))
            {
                command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            flowLayoutPanelMenu.Controls.Clear();

            foreach (DataRow row in table.Rows)
            {
                Panel productPanel = new Panel
                {
                    Size = new Size(200, 280),
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(150, 150),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (row["Image"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["Image"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }

                Label labelName = new Label
                {
                    Text = row["Name"].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(150, 30),
                    Font = new Font("Century Gothic", 15, FontStyle.Bold),
                    Location = new Point((productPanel.Width - 150) / 2, pictureBox.Bottom + 5)
                };

                Label labelPrice = new Label
                {
                    Text = "$" + row["Price"].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(150, 30),
                    Font = new Font("Century Gothic", 15, FontStyle.Bold),
                    Location = new Point((productPanel.Width - 150) / 2, labelName.Bottom + 5)
                };

                Button addToCartButton = new Button
                {
                    Text = "Add to cart",
                    Size = new Size(150, 32),
                    BackColor = Color.SeaGreen,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point((productPanel.Width - 150) / 2, labelPrice.Bottom + 10)
                };
                addToCartButton.Click += (sender, e) => AddToCart(row);

                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(labelName);
                productPanel.Controls.Add(labelPrice);
                productPanel.Controls.Add(addToCartButton);

                flowLayoutPanelMenu.Controls.Add(productPanel);
            }

            dataBase.closeConnection();
        }

        private void LoadCartPanel()
        {
            flowLayoutPanelPayment.AutoScroll = false;

            totalAmountLabel.Text = "$0";
            totalAmountLabel.Font = new Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            totalAmountLabel.ForeColor = Color.Black;
            totalAmountLabel.BackColor = Color.Transparent;
            totalAmountLabel.Location = new Point(220, 295);
            totalAmountLabel.TextAlign = ContentAlignment.MiddleCenter;

            checkoutButton.Text = "Checkout";
            checkoutButton.BackColor = Color.SeaGreen;
            checkoutButton.ForeColor = Color.White;
            checkoutButton.FlatStyle = FlatStyle.Flat;

            checkoutButton.Click -= CheckoutButton_Click;
            checkoutButton.Click += CheckoutButton_Click;
        }

        private void LoadProductImage(string productName, PictureBox pictureBox)
        {
            try
            {
                dataBase.openConnection();
                string query = "SELECT Image FROM Menu WHERE Name = @ProductName";
                SqlCommand command = new SqlCommand(query, dataBase.getConnection());
                command.Parameters.AddWithValue("@ProductName", productName);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    byte[] imageData = (byte[])result;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void UpdateCartDisplay()
        {
            flowLayoutPanelCart.Controls.Clear();

            currentTotal = cart.Sum(item => item.Price * item.Quantity);
            decimal discountedTotal = discountApplied
                ? Math.Round(currentTotal * (1 - discountPercent / 100), 2)
                : currentTotal;

            totalAmountLabel.Text = $"${discountedTotal:0.00}";

            flowLayoutPanelCart.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelCart.WrapContents = false;
            flowLayoutPanelCart.AutoScroll = true;

            if (cart.Count == 0)
            {
                emptyCartPictureBox.Visible = true;
                emptyCartLabel1.Visible = true;
                emptyCartLabel2.Visible = true;

                Panel centerPanel = new Panel
                {
                    Size = new Size(flowLayoutPanelCart.Width, 250),
                    Dock = DockStyle.Top
                };

                emptyCartPictureBox.Size = new Size(120, 120);
                emptyCartPictureBox.Location = new Point(
                    (centerPanel.Width - emptyCartPictureBox.Width) / 2,
                    20);
                emptyCartPictureBox.Anchor = AnchorStyles.None;

                emptyCartLabel1.Text = "КОРЗИНА ПУСТА";
                emptyCartLabel1.Font = new Font("Arial", 14, FontStyle.Bold);
                emptyCartLabel1.ForeColor = Color.Gray;
                emptyCartLabel1.AutoSize = true;
                emptyCartLabel1.TextAlign = ContentAlignment.MiddleCenter;
                emptyCartLabel1.Location = new Point(
                    (centerPanel.Width - emptyCartLabel1.Width) / 2,
                    emptyCartPictureBox.Bottom + 10);
                emptyCartLabel1.Anchor = AnchorStyles.None;

                emptyCartLabel2.Text = "Добавьте товары из меню";
                emptyCartLabel2.Font = new Font("Arial", 12);
                emptyCartLabel2.ForeColor = Color.Gray;
                emptyCartLabel2.AutoSize = true;
                emptyCartLabel2.TextAlign = ContentAlignment.MiddleCenter;
                emptyCartLabel2.Location = new Point(
                    (centerPanel.Width - emptyCartLabel2.Width) / 2,
                    emptyCartLabel1.Bottom + 5);
                emptyCartLabel2.Anchor = AnchorStyles.None;

                centerPanel.Controls.Add(emptyCartPictureBox);
                centerPanel.Controls.Add(emptyCartLabel1);
                centerPanel.Controls.Add(emptyCartLabel2);

                flowLayoutPanelCart.Controls.Add(centerPanel);
            }
            else
            {
                emptyCartPictureBox.Visible = false;
                emptyCartLabel1.Visible = false;
                emptyCartLabel2.Visible = false;

                foreach (CartItem item in cart)
                {
                    Panel itemPanel = new Panel
                    {
                        Size = new Size(flowLayoutPanelCart.Width - 25, 80),
                        BackColor = Color.Transparent,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    PictureBox picBox = new PictureBox
                    {
                        Size = new Size(60, 60),
                        Location = new Point(10, 10),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    LoadProductImage(item.Name, picBox);

                    Label nameLabel = new Label
                    {
                        Text = item.Name,
                        Location = new Point(80, 10),
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        MaximumSize = new Size(120, 40)
                    };

                    Label priceLabel = new Label
                    {
                        Text = $"${item.Price:0.00}",
                        Location = new Point(210, 10),
                        Font = new Font("Arial", 10),
                        AutoSize = true
                    };

                    Panel quantityPanel = new Panel
                    {
                        Size = new Size(90, 25),
                        Location = new Point(80, 40)
                    };

                    Button btnMinus = new Button
                    {
                        Text = "-",
                        Size = new Size(25, 25),
                        Location = new Point(0, 0),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Tag = item
                    };
                    btnMinus.Click += (s, e) => UpdateItemQuantity(item, -1);

                    Button btnPlus = new Button
                    {
                        Text = "+",
                        Size = new Size(25, 25),
                        Location = new Point(65, 0),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Tag = item
                    };
                    btnPlus.Click += (s, e) => UpdateItemQuantity(item, 1);

                    Label quantityLabel = new Label
                    {
                        Text = item.Quantity.ToString(),
                        Size = new Size(40, 25),
                        Location = new Point(25, 0),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 10)
                    };

                    Button btnRemove = new Button
                    {
                        Size = new Size(25, 25),
                        Location = new Point(itemPanel.Width - 35, 5),
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImage = Properties.Resources.free_icon_font_trash_xmark__2_,
                        BackgroundImageLayout = ImageLayout.Zoom,
                        Tag = item
                    };
                    btnRemove.Click += (s, e) => {
                        cart.Remove(item);
                        UpdateCartDisplay();
                    };

                    quantityPanel.Controls.Add(btnMinus);
                    quantityPanel.Controls.Add(quantityLabel);
                    quantityPanel.Controls.Add(btnPlus);

                    itemPanel.Controls.Add(picBox);
                    itemPanel.Controls.Add(nameLabel);
                    itemPanel.Controls.Add(priceLabel);
                    itemPanel.Controls.Add(quantityPanel);
                    itemPanel.Controls.Add(btnRemove);

                    flowLayoutPanelCart.Controls.Add(itemPanel);
                }
            }

            UpdateDiscountDisplay();
        }

        private void UpdateDiscountDisplay()
        {
            if (originalTotalLabel != null)
            {
                flowLayoutPanelPayment.Controls.Remove(originalTotalLabel);
                originalTotalLabel = null;
            }

            if (discountApplied)
            {
                originalTotalLabel = new Label
                {
                    Text = $"${currentTotal:0.00}",
                    Font = new Font("Arial", 12, FontStyle.Strikeout),
                    ForeColor = Color.Red,
                    Location = new Point(145, 300),
                    AutoSize = true
                };
                flowLayoutPanelPayment.Controls.Add(originalTotalLabel);
                totalAmountLabel.Location = new Point(220, 295);
            }
            else
            {
                totalAmountLabel.Location = new Point(180, 295);
            }
        }

        private void UpdateItemQuantity(CartItem item, int change)
        {
            item.Quantity += change;
            if (item.Quantity <= 0) cart.Remove(item);
            UpdateCartDisplay();
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            string queryPaymentInfo = "SELECT card_number, expire_month, expire_year, cvv, user_adress FROM Auth WHERE id = @UserId";
            SqlCommand commandPaymentInfo = new SqlCommand(queryPaymentInfo, dataBase.getConnection());
            commandPaymentInfo.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader reader = commandPaymentInfo.ExecuteReader();

            string cardNumber = null, expireMonth = null, expireYear = null, cvv = null, userAddress = null;

            if (reader.Read())
            {
                cardNumber = reader["card_number"]?.ToString();
                expireMonth = reader["expire_month"]?.ToString();
                expireYear = reader["expire_year"]?.ToString();
                cvv = reader["cvv"]?.ToString();
                userAddress = reader["user_adress"]?.ToString();
            }

            reader.Close();

            if (string.IsNullOrWhiteSpace(cardNumber) || string.IsNullOrWhiteSpace(expireMonth) ||
                string.IsNullOrWhiteSpace(expireYear) || string.IsNullOrWhiteSpace(cvv) || string.IsNullOrWhiteSpace(userAddress))
            {
                dataBase.closeConnection();

                MessageBox.Show("Пожалуйста, заполните все платёжные данные перед оформлением заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                finance = new Finance(userName, userId);
                this.Hide();
                finance.Show();

                return;
            }

            decimal totalAmount = cart.Sum(item => item.Price * item.Quantity);

            if (discountApplied)
            {
                totalAmount = Math.Round(totalAmount * (1 - discountPercent / 100), 2);
            }

            string queryOrder = "INSERT INTO Orders (UserId, TotalAmount) OUTPUT INSERTED.OrderId VALUES (@UserId, @TotalAmount)";
            SqlCommand commandOrder = new SqlCommand(queryOrder, dataBase.getConnection());
            commandOrder.Parameters.AddWithValue("@UserId", userId);
            commandOrder.Parameters.AddWithValue("@TotalAmount", totalAmount);

            int orderId = (int)commandOrder.ExecuteScalar();

            foreach (var item in cart)
            {
                string queryOrderItems = "INSERT INTO OrderItems (OrderId, ProductName, ProductPrice, Quantity, TotalPrice) VALUES (@OrderId, @ProductName, @ProductPrice, @Quantity, @TotalPrice)";
                SqlCommand commandOrderItems = new SqlCommand(queryOrderItems, dataBase.getConnection());
                commandOrderItems.Parameters.AddWithValue("@OrderId", orderId);
                commandOrderItems.Parameters.AddWithValue("@ProductName", item.Name);
                commandOrderItems.Parameters.AddWithValue("@ProductPrice", item.Price);
                commandOrderItems.Parameters.AddWithValue("@Quantity", item.Quantity);
                commandOrderItems.Parameters.AddWithValue("@TotalPrice", item.Price * item.Quantity);

                commandOrderItems.ExecuteNonQuery();
            }

            dataBase.closeConnection();

            cart.Clear();
            discountApplied = false;
            discountPercent = 0;
            promoTextBox.Text = "";
            UpdateCartDisplay();

            MessageBox.Show("Покупка успешно оформлена!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddToCart(DataRow productRow)
        {
            string productName = productRow["Name"].ToString();
            decimal productPrice = Convert.ToDecimal(productRow["Price"]);
            string productCategory = productRow.Table.Columns.Contains("Category") ? productRow["Category"].ToString() : "Unknown";

            CartItem existingItem = cart.FirstOrDefault(item => item.Name == productName && item.Category == productCategory);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItem newItem = new CartItem
                {
                    Name = productName,
                    Price = productPrice,
                    Quantity = 1,
                    Category = productCategory
                };
                cart.Add(newItem);
            }

            UpdateCartDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            finance = new Finance(userName, userId);

            finance.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            news = new News(userName, userId);

            news.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gallery = new Gallery(userName, userId);

            gallery.Show();
            this.Hide();
        }

        private string FormatCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber == "0")
                return "0";

            string cleanNumber = cardNumber.Replace(" ", "");

            StringBuilder formattedNumber = new StringBuilder();
            for (int i = 0; i < cleanNumber.Length; i += 4)
            {
                int length = Math.Min(4, cleanNumber.Length - i);
                formattedNumber.Append(cleanNumber.Substring(i, length));

                if (i + 4 < cleanNumber.Length)
                    formattedNumber.Append(" ");
            }

            return formattedNumber.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();

            try
            {
                string queryPaymentInfo = "SELECT card_number, expire_month, expire_year, cvv, user_adress FROM Auth WHERE id = @UserId";
                SqlCommand commandPaymentInfo = new SqlCommand(queryPaymentInfo, dataBase.getConnection());
                commandPaymentInfo.Parameters.AddWithValue("@UserId", userId);

                using (SqlDataReader reader = commandPaymentInfo.ExecuteReader())
                {
                    string cardNumber = "0", expireMonth = "0", expireYear = "0", cvv = "0";

                    if (reader.Read())
                    {
                        cardNumber = reader["card_number"]?.ToString();
                        expireMonth = reader["expire_month"]?.ToString();
                        expireYear = reader["expire_year"]?.ToString();
                        cvv = reader["cvv"]?.ToString();
                    }

                    labelCardNumber.Text = string.IsNullOrEmpty(cardNumber) ? "0000 0000 0000 0000" : FormatCardNumber(cardNumber);
                    labelCardMonth.Text = string.IsNullOrEmpty(expireMonth) ? "00" : expireMonth;
                    labelCardYear.Text = string.IsNullOrEmpty(expireYear) ? "00" : expireYear;
                }

                if (cartItemPanelTemplate != null)
                {
                    cartItemPanelTemplate.Visible = false;
                }

                buttonAdminPanel.Visible = Auth.IsAdmin;

                LoadUserImage(Auth.UserId);
                LoadMenuItems();
                LoadCartPanel();
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        public class RightRoundedButton : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);
                Graphics graphics = pevent.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = this.ClientRectangle;
                int radius = 30;

                GraphicsPath path = new GraphicsPath();

                path.StartFigure();
                path.AddLine(rect.Left, rect.Top, rect.Right - radius / 2, rect.Top);
                path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
                path.AddLine(rect.Right, rect.Top + radius / 2, rect.Right, rect.Bottom - radius / 2);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddLine(rect.Right - radius / 2, rect.Bottom, rect.Left, rect.Bottom);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        private void textBoxSearchF_TextChanged(object sender, EventArgs e)
        {
            LoadMenuItems(textBoxSearchF.Text);
        }

        private void flowLayoutPanelMenu_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            auth.Show();
            this.Hide();
        }
    }
}