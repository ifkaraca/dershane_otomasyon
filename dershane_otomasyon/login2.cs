using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershane_otomasyon
{
    public partial class login2 : Form
    {
        public login2()
        {
            InitializeComponent();
        }
        private void login2_Load(object sender, EventArgs e)
        {
            pnlKullanıcıHata.Visible = false;
            pnlParolaHata.Visible = false;
            panel7.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Red;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Kullanıcı Adını Girniz";
                    textBox1.ForeColor = Color.Gray;
                    textBox1.SelectAll();
                    return;
                }
                textBox1.ForeColor = Color.White;
                pnlKullanıcıHata.Visible = false;
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (textBox2.Text == "")
                {
                    textBox2.Text = "Şifre";
                    textBox2.ForeColor = Color.Gray;
                    textBox2.SelectAll();
                    return;
                }
                textBox2.ForeColor = Color.White;
                textBox2.UseSystemPasswordChar = true;
                pnlParolaHata.Visible = false;
            }
            catch { }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.FromArgb(251, 183, 10);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(251, 183, 10);
            button1.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "admin")
            {
                pnlKullanıcıHata.Visible = true;
                textBox1.Focus();
                return;
            }
            if (textBox2.Text != "1234")
            {
                pnlParolaHata.Visible = true;
                textBox2.Focus();
                return;
            }
            string kullanici = textBox1.Text;
            string sifre = textBox2.Text;

            if (kullanici == "admin" && sifre == "1234")
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void kapaligoz_Click(object sender, EventArgs e)
        {
            kapaligoz.Visible = false;
            acikgoz.Visible = true;
            textBox2.UseSystemPasswordChar = false;
        }

        private void acikgoz_Click(object sender, EventArgs e)
        {
            kapaligoz.Visible = true;
            acikgoz.Visible = false;
            textBox2.UseSystemPasswordChar = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel7.Visible = true;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
    }
}
