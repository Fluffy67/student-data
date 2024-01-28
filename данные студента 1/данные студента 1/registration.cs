using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace данные_студента_1
{
    public partial class registration : Form
    {
        private readonly string connString = @"Data Source=styd.db;Version=3;";

        public registration()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fentrance = new entrance();
            fentrance.Show();
            fentrance.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string parol = PassTextBox.Text.Trim();

            // Проверяем, что поля логина и пароля не пустые
            if (login == "" || parol == "")
            {
                _ = MessageBox.Show("Заполните все поля");
                return;
            }

            // Формируем запрос на проверку наличия пользователя с таким же логином в базе данных
            string checkQuery = $"SELECT COUNT(*) FROM Users WHERE login='{login}'";

            // Создаем новое подключение к базе данных SQLite
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                // Открываем соединение с базой данных
                conn.Open();

                // Создаем новый объект команды SQL с запросом на проверку наличия пользователя с таким же логином в базе данных
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    // Получаем результат выполнения запроса на проверку наличия пользователя с таким же логином в базе данных
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    // Проверяем, что пользователь с таким логином уже не зарегистрирован в базе данных
                    if (count > 0)
                    {
                        _ = MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                        return;
                    }
                }

                // Формируем запрос на добавление нового пользователя в базу данных
                string insertQuery = $"INSERT INTO Users (login, parol) VALUES ('{login}', '{parol}');";

                // Создаем новый объект команды SQL с запросом на добавление нового пользователя в базу данных
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                {
                    // Выполняем запрос на добавление нового пользователя в базу данных
                    _ = insertCmd.ExecuteNonQuery();
                }
            }
            Form fentrance = new entrance();
            fentrance.Show();
            fentrance.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
            // Выводим сообщение об успешной регистрации пользователя
            _ = MessageBox.Show("Вы успешно зарегистрировались");
        }
    }
}
