using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class News : Form
    {
        DataBase dataBase = new DataBase();
        Auth auth = new Auth();
        Admin_Panel adminPanel = new Admin_Panel();
        private byte[] attachedReviewImage;
        private string userName;
        private int userId;

        public News(string userName, int userId)
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

            string querystring = $"SELECT image_user FROM auth WHERE id = @userId";

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
            string query = "UPDATE auth SET image_user = @image WHERE id = @userId";

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

        // Оставляем только один метод для обновления изображения
        public void UpdateUserImage()
        {
            LoadUserImage(Auth.UserId);
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {
            this.Close();
            adminPanel.ShowDialog();
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.SeaGreen;

            button3.BackColor = Color.SeaGreen;
            label5.BackColor = Color.SeaGreen;
            label5.ForeColor = Color.White;

            label3.BackColor = Color.White;
            label3.ForeColor = Color.SeaGreen;

            thirdIcon.Image = Properties.Resources.news_white;
            thirdIcon.BackColor = Color.SeaGreen;

            firstIcon.Image = Properties.Resources.dashboard_green1;
            firstIcon.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SeaGreen;
            button1.ForeColor = Color.White;

            button3.BackColor = Color.White;
            label5.BackColor = Color.White;
            label5.ForeColor = Color.SeaGreen;

            label3.BackColor = Color.SeaGreen;
            label3.ForeColor = Color.White;

            thirdIcon.Image = Properties.Resources.news_green;
            thirdIcon.BackColor = Color.White;

            firstIcon.Image = Properties.Resources.dashboard_white1;
            firstIcon.BackColor = Color.SeaGreen;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.SeaGreen;

            button3.BackColor = Color.SeaGreen;
            label5.BackColor = Color.SeaGreen;
            label5.ForeColor = Color.White;

            label4.BackColor = Color.White;
            label4.ForeColor = Color.SeaGreen;

            thirdIcon.Image = Properties.Resources.news_white;
            thirdIcon.BackColor = Color.SeaGreen;

            secondIcon.Image = Properties.Resources.creditcards_green;
            secondIcon.BackColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;

            button2.BackColor = Color.SeaGreen;
            label5.BackColor = Color.White;
            label5.ForeColor = Color.SeaGreen;

            label4.BackColor = Color.SeaGreen;
            label4.ForeColor = Color.White;

            thirdIcon.Image = Properties.Resources.news_green;
            thirdIcon.BackColor = Color.White;

            secondIcon.Image = Properties.Resources.creditcards_white;
            secondIcon.BackColor = Color.SeaGreen;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.ForeColor = Color.SeaGreen;

            button3.BackColor = Color.SeaGreen;
            label5.BackColor = Color.SeaGreen;
            label5.ForeColor = Color.White;

            label6.BackColor = Color.White;
            label6.ForeColor = Color.SeaGreen;

            thirdIcon.Image = Properties.Resources.news_white;
            thirdIcon.BackColor = Color.SeaGreen;

            fourthIcon.Image = Properties.Resources.gallery_green;
            fourthIcon.BackColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SeaGreen;
            button4.ForeColor = Color.White;

            button3.BackColor = Color.White;
            label5.BackColor = Color.White;
            label5.ForeColor = Color.SeaGreen;

            label6.BackColor = Color.SeaGreen;
            label6.ForeColor = Color.White;

            thirdIcon.Image = Properties.Resources.news_green;
            thirdIcon.BackColor = Color.White;

            fourthIcon.Image = Properties.Resources.gallery_white;
            fourthIcon.BackColor = Color.SeaGreen;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.SeaGreen;

            button3.BackColor = Color.SeaGreen;
            label5.BackColor = Color.SeaGreen;
            label5.ForeColor = Color.White;

            label7.BackColor = Color.White;
            label7.ForeColor = Color.SeaGreen;

            thirdIcon.Image = Properties.Resources.news_white;
            thirdIcon.BackColor = Color.SeaGreen;

            fifthIcon.Image = Properties.Resources.logout_green;
            fifthIcon.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.SeaGreen;
            button5.ForeColor = Color.White;

            button3.BackColor = Color.White;
            label5.BackColor = Color.White;
            label5.ForeColor = Color.SeaGreen;

            label7.BackColor = Color.SeaGreen;
            label7.ForeColor = Color.White;

            thirdIcon.Image = Properties.Resources.news_green;
            thirdIcon.BackColor = Color.White;

            fifthIcon.Image = Properties.Resources.logout_white;
            fifthIcon.BackColor = Color.SeaGreen;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            auth.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(userName, userId);
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Finance finance = new Finance(userName, userId);

            finance.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gallery gallery = new Gallery(userName, userId);

            gallery.Show();
            this.Hide();
        }

        private void News_Load(object sender, EventArgs e)
        {
            buttonAdminPanel.Visible = Auth.IsAdmin;
            textBoxArticle.Visible = Auth.IsAdmin;
            textBoxNewsText.Visible = Auth.IsAdmin;
            buttonAttachPhoto.Visible = Auth.IsAdmin;
            pictureBoxReview.Visible = Auth.IsAdmin;
            buttonSend.Visible = Auth.IsAdmin;
            LoadNews();
        }

        private void pictureBoxReview_Click(object sender, EventArgs e)
        {

        }

        private void buttonAttachPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                attachedReviewImage = File.ReadAllBytes(imagePath);

                using (Image original = Image.FromFile(imagePath))
                {
                    pictureBoxReview.Image = new Bitmap(original, pictureBoxReview.Width, pictureBoxReview.Height);
                    pictureBoxReview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxArticle.Text) ||
                string.IsNullOrWhiteSpace(textBoxNewsText.Text) ||
                attachedReviewImage == null)
            {
                MessageBox.Show("Будь ласка, заповніть всі поля та додайте фото.");
                return;
            }

            string query = "INSERT INTO News (NewsArticle, NewsText, NewsDate, NewsPhoto) " +
                           "VALUES (@article, @text, @date, @photo)";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.Parameters.AddWithValue("@article", textBoxArticle.Text);
            command.Parameters.AddWithValue("@text", textBoxNewsText.Text);
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@photo", attachedReviewImage);

            dataBase.openConnection();

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Новину додано!");
                LoadNews(); // Перезавантажити стрічку
            }
            else
            {
                MessageBox.Show("Помилка при додаванні.");
            }

            dataBase.closeConnection();
        }
        private void LoadNews()
        {
            flowLayoutPanel1.Controls.Clear();

            string query = "SELECT NewsArticle, NewsText, NewsDate, NewsPhoto FROM News ORDER BY NewsDate DESC";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string article = reader["NewsArticle"].ToString();
                string text = reader["NewsText"].ToString();
                string date = Convert.ToDateTime(reader["NewsDate"]).ToString("dd.MM.yyyy HH:mm");
                byte[] imageData = (byte[])reader["NewsPhoto"];

                Image newsImage = ByteArrayToImage(imageData); // ← Ось тут створюється зображення

                Panel newsPanel = new Panel
                {
                    Width = 550,
                    AutoSize = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                Label labelTitle = new Label
                {
                    Text = article,
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Padding = new Padding(10, 10, 10, 5),
                    Dock = DockStyle.Top
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = newsImage,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(500, 250),
                    Margin = new Padding(10, 5, 10, 5)
                };

                Label labelText = new Label
                {
                    Text = text,
                    Font = new Font("Arial", 12),
                    AutoSize = true,
                    Padding = new Padding(10, 0, 10, 10)
                };

                Label labelDate = new Label
                {
                    Text = date,
                    Font = new Font("Arial", 9, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Dock = DockStyle.Bottom,
                    Padding = new Padding(10, 0, 10, 5)
                };

                newsPanel.Controls.Add(labelDate);
                newsPanel.Controls.Add(labelText);
                newsPanel.Controls.Add(pictureBox);
                newsPanel.Controls.Add(labelTitle);

                flowLayoutPanel1.Controls.Add(newsPanel);
            }

            reader.Close();
            dataBase.closeConnection();
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }



        private void textBoxNewsText_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
