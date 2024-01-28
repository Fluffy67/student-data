using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace данные_студента_1
{
    public partial class entrance : Form
    {
        private readonly string connString = @"Data Source=styd.db;Version=3;";

        public entrance()
        {
            InitializeComponent();
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fregistration = new registration();
            fregistration.Show();
            fregistration.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Login=@Login AND Parol=@Parol";

            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Login", LoginTextBox.Text);
                    command.Parameters.AddWithValue("@Parol", PassTextBox.Text);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Авторизация прошла успешно");
                            // код для входа обычного пользователя
                            Form fentrance = new samples();
                            fentrance.Show();
                            fentrance.FormClosed += new FormClosedEventHandler(form_FormClosed);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль были неверны.");
                        }
                    }
                }
            }
        }
    }
}

