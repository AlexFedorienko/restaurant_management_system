using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Finance : Form
    {
        DataBase dataBase = new DataBase();
        Auth auth = new Auth();
        Admin_Panel adminPanel = new Admin_Panel();

        private string userName;
        private int userId;

        public Finance(string userName, int userId)
        {
            InitializeComponent();
            this.userName = userName;
            this.userId = userId;

            StartPosition = FormStartPosition.CenterScreen;

            int radius = 70;
            panel1.Region = new Region(CreateRoundRectangle(panel1.ClientRectangle, radius));

            labelName.Text = userName;


            LoadUserImage(userId);
            MakePictureBoxRound(pictureBox1);

            MakeButtonRound(button1, 30);
            MakeButtonRound(button2, 30);
            MakeButtonRound(button3, 30);
            MakeButtonRound(button4, 30);
            MakeButtonRound(button5, 30);
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

            button2.BackColor = Color.SeaGreen;
            label4.BackColor = Color.SeaGreen;
            label4.ForeColor = Color.White;

            label3.BackColor = Color.White;
            label3.ForeColor = Color.SeaGreen;

            secondIcon.Image = Properties.Resources.creditcards_white;
            secondIcon.BackColor = Color.SeaGreen;

            firstIcon.Image = Properties.Resources.dashboard_green1;
            firstIcon.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SeaGreen;
            button1.ForeColor = Color.White;

            button2.BackColor = Color.White;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.SeaGreen;

            label3.BackColor = Color.SeaGreen;
            label3.ForeColor = Color.White;

            secondIcon.Image = Properties.Resources.creditcards_green;
            secondIcon.BackColor = Color.White;

            firstIcon.Image = Properties.Resources.dashboard_white1;
            firstIcon.BackColor = Color.SeaGreen;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.SeaGreen;

            button2.BackColor = Color.SeaGreen;
            label4.BackColor = Color.SeaGreen;
            label4.ForeColor = Color.White;

            label5.BackColor = Color.White;
            label5.ForeColor = Color.SeaGreen;

            secondIcon.Image = Properties.Resources.creditcards_white;
            secondIcon.BackColor = Color.SeaGreen;

            thirdIcon.Image = Properties.Resources.news_green;
            thirdIcon.BackColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.SeaGreen;
            button3.ForeColor = Color.White;

            button2.BackColor = Color.White;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.SeaGreen;

            label5.BackColor = Color.SeaGreen;
            label5.ForeColor = Color.White;

            secondIcon.Image = Properties.Resources.creditcards_green;
            secondIcon.BackColor = Color.White;

            thirdIcon.Image = Properties.Resources.news_white;
            thirdIcon.BackColor = Color.SeaGreen;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.ForeColor = Color.SeaGreen;

            button2.BackColor = Color.SeaGreen;
            label4.BackColor = Color.SeaGreen;
            label4.ForeColor = Color.White;

            label6.BackColor = Color.White;
            label6.ForeColor = Color.SeaGreen;

            secondIcon.Image = Properties.Resources.creditcards_white;
            secondIcon.BackColor = Color.SeaGreen;

            fourthIcon.Image = Properties.Resources.gallery_green;
            fourthIcon.BackColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SeaGreen;
            button4.ForeColor = Color.White;

            button2.BackColor = Color.White;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.SeaGreen;

            label6.BackColor = Color.SeaGreen;
            label6.ForeColor = Color.White;

            secondIcon.Image = Properties.Resources.creditcards_green;
            secondIcon.BackColor = Color.White;

            fourthIcon.Image = Properties.Resources.gallery_white;
            fourthIcon.BackColor = Color.SeaGreen;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.SeaGreen;

            button2.BackColor = Color.SeaGreen;
            label4.BackColor = Color.SeaGreen;
            label4.ForeColor = Color.White;

            label7.BackColor = Color.White;
            label7.ForeColor = Color.SeaGreen;

            secondIcon.Image = Properties.Resources.creditcards_white;
            secondIcon.BackColor = Color.SeaGreen;

            fifthIcon.Image = Properties.Resources.logout_green;
            fifthIcon.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.SeaGreen;
            button5.ForeColor = Color.White;

            button2.BackColor = Color.White;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.SeaGreen;

            label7.BackColor = Color.SeaGreen;
            label7.ForeColor = Color.White;

            secondIcon.Image = Properties.Resources.creditcards_green;
            secondIcon.BackColor = Color.White;

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

        private void button3_Click(object sender, EventArgs e)
        {
            News news = new News(userName, userId);

            news.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gallery gallery = new Gallery(userName, userId);

            gallery.Show();
            this.Hide();
        }

        private void textBoxCardNumberF_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCardMonthF_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCardYearF_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCardCvvF_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFullAdressF_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSaveChangesF_Click(object sender, EventArgs e)
        {
            var cardNumber = textBoxCardNumberF.Text;
            var cardMonth = textBoxCardMonthF.Text;
            var cardYear = textBoxCardYearF.Text;
            var cvv = textBoxCardCvvF.Text;
            var userAddress = textBoxFullAdressF.Text;

            // Простенька валідація
            if (cardNumber.Length < 13 || cvv.Length != 3 || cardMonth.Length != 2 || cardYear.Length != 2)
            {
                MessageBox.Show("Please enter valid card details.");
                return;
            }

            string query = "UPDATE Auth SET " +
                           "card_number = @cardNumber, " +
                           "expire_month = @month, " +
                           "expire_year = @year, " +
                           "cvv = @cvv, " +
                           "user_adress = @address " +
                           "WHERE id = @userId";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            command.Parameters.AddWithValue("@cardNumber", cardNumber);
            command.Parameters.AddWithValue("@month", cardMonth);
            command.Parameters.AddWithValue("@year", cardYear);
            command.Parameters.AddWithValue("@cvv", cvv);
            command.Parameters.AddWithValue("@address", userAddress);
            command.Parameters.AddWithValue("@userId", userId);

            dataBase.openConnection();

            try
            {
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Payment information updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update information.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }


        private void LoadUserFinanceData()
        {
            dataBase.openConnection();
            string query = $"SELECT card_number, expire_month, expire_year, cvv, user_adress FROM Auth WHERE id = {userId}";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                textBoxCardNumberF.Text = reader["card_number"]?.ToString();
                textBoxCardMonthF.Text = reader["expire_month"]?.ToString();
                textBoxCardYearF.Text = reader["expire_year"]?.ToString();
                textBoxCardCvvF.Text = reader["cvv"]?.ToString();
                textBoxFullAdressF.Text = reader["user_adress"]?.ToString();
            }

            reader.Close();
            dataBase.closeConnection();
        }
        public Finance(string userName, int userId, string cardNumber, string expireMonth, string expireYear, string cvv, string userAddress)
        {
            InitializeComponent();
            this.userName = userName;
            this.userId = userId;

            // Отображаем данные в текстбоксах
            textBoxCardNumberF.Text = cardNumber;
            textBoxCardMonthF.Text = expireMonth;
            textBoxCardYearF.Text = expireYear;
            textBoxCardCvvF.Text = cvv;
            textBoxFullAdressF.Text = userAddress;
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            LoadUserFinanceData();
            buttonAdminPanel.Visible = Auth.IsAdmin;


            textBoxFullAdressA.Text = "Street adress";
            textBoxFullAdressA.ForeColor = Color.Silver;


            textBoxFullMail.Text = "Apt,Suite,Bldg,Gate Code(optional)";
            textBoxFullMail.ForeColor = Color.Silver;


            textBoxFullCountry.Text = "State/Country";
            textBoxFullCountry.ForeColor = Color.Silver;


            textBoxFullPostcode.Text = "Postcode/ZIP";
            textBoxFullPostcode.ForeColor = Color.Silver;


            textBoxCardCvvF.Text = "CVV";
            textBoxCardCvvF.ForeColor = Color.Silver;


            textBoxCardNumberF.Text = "Card number";
            textBoxCardNumberF.ForeColor = Color.Silver;


            guna2TextBox1.Text = "Notes about your order,e.g.special notes for dilivery.";
            guna2TextBox1.ForeColor = Color.Silver;



        }

        private void textBoxFullAdressA_Enter(object sender, EventArgs e)
        {
            if (textBoxFullAdressA.Text == "Street adress")
            {
                textBoxFullAdressA.Text = "";
                textBoxFullAdressA.ForeColor = Color.Black;
            }
        }

        private void textBoxFullAdressA_Leave(object sender, EventArgs e)
        {
            if (textBoxFullAdressA.Text == "")
            {
                textBoxFullAdressA.Text = "Street adress";
                textBoxFullAdressA.ForeColor = Color.Silver;
            }
        }

        private void textBoxFullMail_Leave(object sender, EventArgs e)
        {
            if (textBoxFullMail.Text == "")
            {
                textBoxFullMail.Text = "Apt,Suite,Bldg,Gate Code(optional)";
                textBoxFullMail.ForeColor = Color.Silver;
            }
        }

        private void textBoxFullMail_Enter(object sender, EventArgs e)
        {
            if (textBoxFullMail.Text == "Apt,Suite,Bldg,Gate Code(optional)")
            {
                textBoxFullMail.Text = "";
                textBoxFullMail.ForeColor = Color.Black;
            }
        }














        private void textBoxFullCountry_Leave(object sender, EventArgs e)
        {
            if   (textBoxFullCountry.Text == "")
            {
                textBoxFullCountry.Text = "State/Country";
                textBoxFullCountry.ForeColor = Color.Silver;
            }
        }

        private void textBoxFullCountry_Enter(object sender, EventArgs e)
        {
            if (textBoxFullCountry.Text == "State/Country")
            {
                textBoxFullCountry.Text = "";
                textBoxFullCountry.ForeColor = Color.Black;
            }
        }





        private void textBoxFullPostcode_Leave(object sender, EventArgs e)
        {
            if (textBoxFullPostcode.Text == "")
            {
                textBoxFullPostcode.Text = "Postcode/ZIP";
                textBoxFullPostcode.ForeColor = Color.Silver;
            }
        }

        private void textBoxFullPostcode_Enter(object sender, EventArgs e)
        {
            if (textBoxFullPostcode.Text == "Postcode/ZIP")
            {
                textBoxFullPostcode.Text = "";
                textBoxFullPostcode.ForeColor = Color.Black;
            }
        }

        private void textBoxCardCvvF_Leave(object sender, EventArgs e)
        {
            if (textBoxCardCvvF.Text == "")
            {
                textBoxCardCvvF.Text = "CVV";
                textBoxCardCvvF.ForeColor = Color.Silver;
            }
        }

        private void textBoxCardCvvF_Enter(object sender, EventArgs e)
        {
            if (textBoxCardCvvF.Text == "CVV")
            {
                textBoxCardCvvF.Text = "";
                textBoxCardCvvF.ForeColor = Color.Black;
            }
        }

        private void textBoxCardNumberF_Leave(object sender, EventArgs e)
        {
            if (textBoxCardNumberF.Text == "")
            {
                textBoxCardNumberF.Text = "Card number";
                textBoxCardNumberF.ForeColor = Color.Silver;
            }
        }

        private void textBoxCardNumberF_Enter(object sender, EventArgs e)
        {
            if (textBoxCardNumberF.Text == "Card number")
            {
                textBoxCardNumberF.Text = "";
                textBoxCardNumberF.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                guna2TextBox1.Text = "Notes about your order,e.g.special notes for dilivery.";
                guna2TextBox1.ForeColor = Color.Silver;
            }
        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "Notes about your order,e.g.special notes for dilivery.")
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
            }
        }
    }
}