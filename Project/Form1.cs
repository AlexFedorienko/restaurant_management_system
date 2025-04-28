using System;
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

        public Color Transparent { get; private set; }

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
                    cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                    return cp;
                }
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // Не рисуем фон
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
            MakePictureBoxRound(pictureBox1);

            MakeButtonRound(button1, 30);
            MakeButtonRound(button2, 30);
            MakeButtonRound(button3, 30);
            MakeButtonRound(button4, 30);
            MakeButtonRound(button5, 30);
            MakeButtonRound(SettingsButton, 20);
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
            totalAmountLabel.Location = new Point(220, 225);
            totalAmountLabel.TextAlign = ContentAlignment.MiddleCenter;

            checkoutButton.Text = "Checkout";
            checkoutButton.BackColor = Color.SeaGreen;
            checkoutButton.ForeColor = Color.White;
            checkoutButton.FlatStyle = FlatStyle.Flat;

            checkoutButton.Click -= CheckoutButton_Click;
            checkoutButton.Click += CheckoutButton_Click;
        }

        // верхняя часть, сделать общую иформацию, время итд.
        private void LoadOrderHistory()
        {
            /*
            flowLayoutPanelMyOrders.Controls.Clear();

            dataBase.openConnection();

            string queryOrders = "SELECT * FROM Orders WHERE UserId = @UserId ORDER BY OrderId DESC";
            SqlCommand commandOrders = new SqlCommand(queryOrders, dataBase.getConnection());
            commandOrders.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader orderReader = commandOrders.ExecuteReader();
            List<int> orderIds = new List<int>();

            DataTable ordersTable = new DataTable();
            ordersTable.Load(orderReader);

            Label myOrderLabel = new Label();
            myOrderLabel.Text = "My Order";
            myOrderLabel.Font = new Font("Century Gothic", 26, FontStyle.Bold);
            myOrderLabel.ForeColor = Color.Black;
            myOrderLabel.Size = new Size(300, 40);
            myOrderLabel.TextAlign = ContentAlignment.MiddleCenter;
            flowLayoutPanelMyOrders.Controls.Add(myOrderLabel);

            foreach (DataRow orderRow in ordersTable.Rows)
            {
                int orderId = Convert.ToInt32(orderRow["OrderId"]);
                decimal totalAmount = Convert.ToDecimal(orderRow["TotalAmount"]);

                Panel orderPanel = new Panel
                {
                    Size = new Size(300, 150),
                    BackColor = Color.LightGray,
                    Margin = new Padding(10)
                };

                Label labelOrder = new Label
                {
                    Text = $"Order #{orderId} - Total: ${totalAmount}",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    AutoSize = false,
                    Size = new Size(280, 30),
                    Location = new Point(10, 10)
                };
                orderPanel.Controls.Add(labelOrder);

                string queryItems = "SELECT * FROM OrderItems WHERE OrderId = @OrderId";
                SqlCommand commandItems = new SqlCommand(queryItems, dataBase.getConnection());
                commandItems.Parameters.AddWithValue("@OrderId", orderId);

                SqlDataAdapter adapter = new SqlDataAdapter(commandItems);
                DataTable itemsTable = new DataTable();
                adapter.Fill(itemsTable);

                int yOffset = 45;

                foreach (DataRow itemRow in itemsTable.Rows)
                {
                    string itemName = itemRow["ProductName"].ToString();
                    int quantity = Convert.ToInt32(itemRow["Quantity"]);
                    decimal price = Convert.ToDecimal(itemRow["ProductPrice"]);
                    decimal total = Convert.ToDecimal(itemRow["TotalPrice"]);

                    Label labelItem = new Label
                    {
                        Text = $"{itemName} x{quantity} - ${total}",
                        Font = new Font("Arial", 10),
                        Location = new Point(10, yOffset),
                        AutoSize = true
                    };

                    orderPanel.Controls.Add(labelItem);
                    yOffset += 20;
                }

                flowLayoutPanelMyOrders.Controls.Add(orderPanel);
            }

            dataBase.closeConnection();
            */
        }
        // Корзина
        private void UpdateCartDisplay()
        {
            flowLayoutPanelCart.Controls.Clear();

            decimal totalAmount = 0;

            foreach (CartItem item in cart)
            {
                Panel itemPanel = new Panel();
                itemPanel.Size = new Size(270, 100);
                itemPanel.Margin = new Padding(20);
                itemPanel.BackColor = Color.Gainsboro;

                Label labelName = new Label();
                labelName.Text = $"{item.Name}";
                labelName.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                labelName.Size = new Size(200, 30);
                labelName.Location = new Point(15, 10);

                Label labelQuantity = new Label();
                labelQuantity.Text = $"Количество: {item.Quantity}";
                labelQuantity.Font = new Font("Arial", 10);
                labelQuantity.Size = new Size(200, 30);
                labelQuantity.Location = new Point(15, labelName.Bottom + 5);

                Label labelPrice = new Label();
                labelPrice.Text = $"Цена: ${item.Price}";
                labelPrice.Font = new Font("Arial", 10);
                labelPrice.Size = new Size(200, 30);
                labelPrice.Location = new Point(15, labelQuantity.Bottom + 5);

                Label labelTotal = new Label();
                labelTotal.Text = $"Итого: ${item.Price * item.Quantity}";
                labelTotal.Font = new Font("Arial", 10);
                labelTotal.Size = new Size(200, 30);
                labelTotal.Location = new Point(15, labelPrice.Bottom + 5);

                itemPanel.Controls.Add(labelName);
                itemPanel.Controls.Add(labelQuantity);
                itemPanel.Controls.Add(labelPrice);
                itemPanel.Controls.Add(labelTotal);

                flowLayoutPanelCart.Controls.Add(itemPanel);

                totalAmount += item.Price * item.Quantity;
            }

            totalAmountLabel.Text = $"${totalAmount}";
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
            UpdateCartDisplay();

            MessageBox.Show("Покупка успешно оформлена!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void AddToCart(DataRow productRow)
        {
            string productName = productRow["Name"].ToString();
            decimal productPrice = Convert.ToDecimal(productRow["Price"]);
            string productCategory = productRow.Table.Columns.Contains("Category") ? productRow["Category"].ToString() : "Unknown";

            // Проверка, если товар уже есть в корзине
            CartItem existingItem = cart.FirstOrDefault(item => item.Name == productName && item.Category == productCategory);

            if (existingItem != null)
            {
                existingItem.Quantity++; // Увеличиваем количество товара
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
                cart.Add(newItem); // Добавляем новый товар
            }

            // Обновляем отображение корзины
            UpdateCartDisplay();
        }


        // Перехід між формами
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

            // Удаляем все пробелы (если они есть)
            string cleanNumber = cardNumber.Replace(" ", "");

            // Разбиваем на группы по 4 цифры
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

            string queryPaymentInfo = "SELECT card_number, expire_month, expire_year, cvv, user_adress FROM Auth WHERE id = @UserId";
            SqlCommand commandPaymentInfo = new SqlCommand(queryPaymentInfo, dataBase.getConnection());
            commandPaymentInfo.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader reader = commandPaymentInfo.ExecuteReader();

            string cardNumber = "0", expireMonth = "0", expireYear = "0", cvv = "0";

            if (reader.Read())
            {
                cardNumber = reader["card_number"]?.ToString();
                expireMonth = reader["expire_month"]?.ToString();
                expireYear = reader["expire_year"]?.ToString();
                cvv = reader["cvv"]?.ToString();

            }

            reader.Close();
            dataBase.closeConnection();

            labelCardNumber.Text = string.IsNullOrEmpty(cardNumber) ? "0000 0000 0000 0000" : FormatCardNumber(cardNumber); labelCardMonth.Text = string.IsNullOrEmpty(expireMonth) ? "00" : expireMonth;
            labelCardYear.Text = string.IsNullOrEmpty(expireYear) ? "00" : expireYear;
            LoadUserImage(Auth.UserId);
            LoadMenuItems();
            LoadOrderHistory();
            buttonAdminPanel.Visible = Auth.IsAdmin;

            LoadCartPanel();

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

        private void labelCardYear_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelMyOrders_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelCardNumber_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void roundedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}