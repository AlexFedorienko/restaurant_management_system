using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            panel1.Region = new Region(CreateRoundRectangle(panel1.ClientRectangle, radius));

            labelName.Text = userName;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
            // Создание панели для общей суммы
            rectPanel.Size = new Size(310, 150);
            rectPanel.BackColor = Color.SeaGreen;
            rectPanel.Margin = new Padding(0, 20, 0, 0);
            flowLayoutPanelPayment.Controls.Add(rectPanel);

            // Обновление метки totalAmountLabel
            totalAmountLabel.Text = "$0";  // Начальная сумма
            totalAmountLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            totalAmountLabel.Size = new Size(300, 30);
            totalAmountLabel.TextAlign = ContentAlignment.MiddleCenter;
            totalAmountLabel.Margin = new Padding(5, 10, 5, 0);
            totalAmountLabel.Location = new Point(230, 220);
            flowLayoutPanelPayment.Controls.Add(totalAmountLabel);

            // Кнопка оформления заказа
            checkoutButton.Text = "Checkout";
            checkoutButton.Size = new Size(310, 37);
            checkoutButton.BackColor = Color.SeaGreen;
            checkoutButton.ForeColor = Color.White;
            checkoutButton.FlatStyle = FlatStyle.Flat;
            checkoutButton.Click += CheckoutButton_Click;
            checkoutButton.Margin = new Padding((flowLayoutPanelPayment.Width - 180) / 2, 10, 0, 0);
            flowLayoutPanelPayment.Controls.Add(checkoutButton);

            // Установка положения и размера панели оплаты
            flowLayoutPanelPayment.Location = new Point(3, 463);
            flowLayoutPanelPayment.Size = new Size(310, 380);
            flowLayoutPanelPayment.AutoScroll = true;
        }



        private void UpdateCartDisplay()
        {
            flowLayoutPanelCart.Controls.Clear(); // Очищаем панель с товарами корзины

            // Заголовок "My Order"
            Label myOrderLabel = new Label();
            myOrderLabel.Text = "My Order";
            myOrderLabel.Font = new Font("Century Gothic", 26, FontStyle.Bold);
            myOrderLabel.ForeColor = Color.Black;
            myOrderLabel.Size = new Size(300, 40);
            myOrderLabel.TextAlign = ContentAlignment.MiddleCenter;
            flowLayoutPanelCart.Controls.Add(myOrderLabel);

            decimal totalAmount = 0;

            // Отображаем все товары в корзине
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

            // Обновляем метку с общей суммой
            totalAmountLabel.Text = $"${totalAmount}";
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
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

            this.Hide();
            finance.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            news = new News(userName, userId);

            this.Hide();
            news.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gallery = new Gallery(userName, userId);

            this.Hide();
            gallery.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserImage(Auth.UserId);
            LoadMenuItems();
            buttonAdminPanel.Visible = Auth.IsAdmin;

            // Создаем панель с общей суммой и кнопкой оформления заказа
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
    }
}