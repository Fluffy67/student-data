using System;
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
    public partial class samples : Form
    {
        public samples()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fgroups = new Form4();
            fgroups.Show();
            fgroups.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ffaculty = new faculty();
            ffaculty.Show();
            ffaculty.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fstudents = new students();
            fstudents.Show();
            fstudents.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
