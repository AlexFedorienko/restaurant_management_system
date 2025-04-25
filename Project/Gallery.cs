using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Gallery : Form
    {
        DataBase dataBase = new DataBase();
        Auth auth = new Auth();
        Admin_Panel adminPanel = new Admin_Panel();

        private string userName;
        private int userId;
        private int selectedStars = 0;
        private byte[] attachedReviewImage;
        private byte[] imageUserBytes; // аватар пользователя




        public Gallery(string userName, int userId)
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
            LoadUserAvatar();
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

        private void button1_MouseLeave(object sender, EventArgs e)
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
        private void Gallery_Load(object sender, EventArgs e)
        {
            LoadReviews();
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
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

            this.Hide();
            finance.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            News news = new News(userName, userId);

            this.Hide();
            news.Show();
        }
        private void buttonStar1_Click(object sender, EventArgs e) => UpdateStarButtons(1);
        private void buttonStar2_Click(object sender, EventArgs e) => UpdateStarButtons(2);
        private void buttonStar3_Click(object sender, EventArgs e) => UpdateStarButtons(3);
        private void buttonStar4_Click(object sender, EventArgs e) => UpdateStarButtons(4);
        private void buttonStar5_Click(object sender, EventArgs e) => UpdateStarButtons(5);
        private void LoadReviews()
        {
            try
            {
                flowLayoutPanelReviews.Controls.Clear(); // Очистим, если вдруг повторно вызывается

                string query = "SELECT TOP 1000 id, review_text, stars, entity_id, review_date, review_image, image_user, username FROM Reviews ORDER BY review_date DESC";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    dataBase.openConnection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Создаем панель для одного отзыва
                            Panel reviewPanel = new Panel();
                            reviewPanel.Width = 600;
                            reviewPanel.Height = 200;
                            reviewPanel.BorderStyle = BorderStyle.FixedSingle;
                            reviewPanel.Padding = new Padding(10);
                            reviewPanel.Margin = new Padding(5);

                            // Аватар
                            PictureBox avatar = new PictureBox();
                            avatar.Width = 50;
                            avatar.Height = 50;
                            avatar.SizeMode = PictureBoxSizeMode.Zoom;
                            if (!reader.IsDBNull(6)) // image_user
                            {
                                byte[] avatarBytes = (byte[])reader["image_user"];
                                using (MemoryStream ms = new MemoryStream(avatarBytes))
                                {
                                    avatar.Image = Image.FromStream(ms);
                                }
                            }

                            // Логин
                            Label usernameLabel = new Label();
                            usernameLabel.Text = reader["username"].ToString();
                            usernameLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            usernameLabel.Location = new Point(60, 10);
                            usernameLabel.AutoSize = true;

                            // Дата
                            Label dateLabel = new Label();
                            dateLabel.Text = Convert.ToDateTime(reader["review_date"]).ToString("dd.MM.yyyy HH:mm");
                            dateLabel.Location = new Point(60, 30);
                            dateLabel.Font = new Font("Segoe UI", 8, FontStyle.Italic);
                            dateLabel.AutoSize = true;

                            // Звёзды
                            int stars = Convert.ToInt32(reader["stars"]);
                            Label starsLabel = new Label();
                            starsLabel.Text = new string('★', stars) + new string('☆', 5 - stars);
                            starsLabel.Font = new Font("Segoe UI", 12);
                            starsLabel.ForeColor = Color.Gold;
                            starsLabel.Location = new Point(10, 70);
                            starsLabel.AutoSize = true;

                            // Текст отзыва
                            Label reviewTextLabel = new Label();
                            reviewTextLabel.Text = reader["review_text"].ToString();
                            reviewTextLabel.Font = new Font("Segoe UI", 10);
                            reviewTextLabel.Location = new Point(10, 100);
                            reviewTextLabel.AutoSize = true;
                            reviewTextLabel.MaximumSize = new Size(400, 0);

                            // Фото отзыва
                            PictureBox reviewPhoto = new PictureBox();
                            reviewPhoto.Width = 150;
                            reviewPhoto.Height = 100;
                            reviewPhoto.Location = new Point(430, 80);
                            reviewPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                            if (!reader.IsDBNull(5)) // review_image
                            {
                                byte[] reviewImgBytes = (byte[])reader["review_image"];
                                using (MemoryStream ms = new MemoryStream(reviewImgBytes))
                                {
                                    reviewPhoto.Image = Image.FromStream(ms);
                                }
                            }

                            // Добавляем все в панель
                            reviewPanel.Controls.Add(avatar);
                            reviewPanel.Controls.Add(usernameLabel);
                            reviewPanel.Controls.Add(dateLabel);
                            reviewPanel.Controls.Add(starsLabel);
                            reviewPanel.Controls.Add(reviewTextLabel);
                            reviewPanel.Controls.Add(reviewPhoto);

                            // Добавляем панель в FlowLayoutPanel
                            flowLayoutPanelReviews.Controls.Add(reviewPanel);
                        }
                    }

                    dataBase.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке отзывов: " + ex.Message);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (selectedStars == 0)
            {
                MessageBox.Show("Пожалуйста, выберите рейтинг звёздами.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxReview.Text))
            {
                MessageBox.Show("Введите текст отзыва.");
                return;
            }
            if (attachedReviewImage == null)
            {
                MessageBox.Show("Прикрепите изображение.");
                return;
            }
            byte[] imageUserBytes = null;
            using (SqlCommand cmd = new SqlCommand("SELECT image_user FROM Auth WHERE id = @userId", dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                dataBase.openConnection();
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                    imageUserBytes = (byte[])result;
                dataBase.closeConnection();
            }
            using (SqlCommand command = new SqlCommand("INSERT INTO Reviews (review_text, stars, entity_id, review_date, review_image, image_user, username) VALUES (@text, @stars, @entity_id, @date, @review_image, @image_user, @username)", dataBase.getConnection()))
            {
                command.Parameters.Add("@text", SqlDbType.NVarChar).Value = textBoxReview.Text;
                command.Parameters.Add("@stars", SqlDbType.Int).Value = selectedStars;
                command.Parameters.Add("@entity_id", SqlDbType.Int).Value = userId;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@review_image", SqlDbType.VarBinary).Value = attachedReviewImage;
                command.Parameters.Add("@image_user", SqlDbType.VarBinary).Value = (object)imageUserBytes ?? DBNull.Value;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = userName;

                dataBase.openConnection();
                int result = command.ExecuteNonQuery();
                dataBase.closeConnection();

                if (result > 0)
                {
                    MessageBox.Show("Отзыв успешно добавлен!");
                    textBoxReview.Clear();
                    pictureBoxReview.Image = null;
                    UpdateStarButtons(0);
                    attachedReviewImage = null;
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении отзыва.");
                }
            }
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
        private void UpdateStarButtons(int stars)
        {
            Button[] buttons = { buttonStar1, buttonStar2, buttonStar3, buttonStar4, buttonStar5 };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Image = (i < stars) ?
                    Properties.Resources.iconStar_full_yellow_64px :
                    Properties.Resources.iconStar_empty_64px;
            }
            selectedStars = stars;
        }

        private void textBoxReview_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadUserAvatar()
        {
            try
            {
                DataBase db = new DataBase();
                string query = "SELECT image_user FROM Auth WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, db.getConnection()))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = userId;
                    db.openConnection();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() && !reader.IsDBNull(0))
                    {
                        imageUserBytes = (byte[])reader["image_user"];
                    }

                    reader.Close();
                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке аватара: " + ex.Message);
            }
        }

        private void buttonSend_Click_1(object sender, EventArgs e)
        {
            if (attachedReviewImage == null)
            {
                MessageBox.Show("Пожалуйста, прикрепите изображение к отзыву.");
                return;
            }

            if (selectedStars == 0)
            {
                MessageBox.Show("Пожалуйста, поставьте рейтинг от 1 до 5 звёзд.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxReview.Text))
            {
                MessageBox.Show("Пожалуйста, напишите текст отзыва.");
                return;
            }

            try
            {
                DataBase dataBase = new DataBase();

                string insertQuery = "INSERT INTO Reviews (review_text, stars, entity_id, review_date, review_image, image_user, username) " +
                                     "VALUES (@text, @stars, @entity_id, @date, @review_image, @image_user, @username)";

                using (SqlCommand command = new SqlCommand(insertQuery, dataBase.getConnection()))
                {
                    command.Parameters.Add("@text", SqlDbType.NVarChar).Value = textBoxReview.Text;
                    command.Parameters.Add("@stars", SqlDbType.Int).Value = selectedStars;
                    command.Parameters.Add("@entity_id", SqlDbType.Int).Value = userId; 
                    command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@review_image", SqlDbType.VarBinary).Value = attachedReviewImage;

                    if (imageUserBytes != null)
                        command.Parameters.Add("@image_user", SqlDbType.VarBinary).Value = imageUserBytes;
                    else
                        command.Parameters.Add("@image_user", SqlDbType.VarBinary).Value = DBNull.Value;

                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = userName;

                    dataBase.openConnection();

                    int result = command.ExecuteNonQuery();

                    dataBase.closeConnection();

                    if (result > 0)
                    {
                        MessageBox.Show("Отзыв успешно добавлен!");
                        textBoxReview.Clear();
                        pictureBoxReview.Image = null;
                        UpdateStarButtons(0);
                        attachedReviewImage = null;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить отзыв.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении отзыва: " + ex.Message);
            }
        }

    }
}
