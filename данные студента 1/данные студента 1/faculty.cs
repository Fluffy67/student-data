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
    public partial class faculty : Form
    {
        private SQLiteConnection styd;

        public faculty()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fsamples = new samples();
            fsamples.Show();
            fsamples.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private async void faculty_Load(object sender, EventArgs e)
        {
            styd = new SQLiteConnection(database.connectionString);
            await styd.OpenAsync();
            LoadingTable();
        }
        private async void LoadingTable()
        {
            {
                dataGridView1.Rows.Clear();
                SQLiteDataReader sqlReader = null;
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_faculty.main}]", styd);
                List<string[]> data = new List<string[]>();
                try
                {
                    sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        data.Add(new string[8]);
                        //Указываем столбцы
                        data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{table_faculty.faculty_id}"]}");
                        data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{table_faculty.faculty_name}"]}");
                        data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{table_faculty.faculty_capacity}"]}");

                    }

                    foreach (string[] s in data)
                    {
                        dataGridView1.Rows.Add(s);
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"{ex.Source}");
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }

            }
        }
    }
}