using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershane_otomasyon
{
    public partial class yks : Form
    {
        public yks()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo = dbHelper.KursList("Yks");
            dataGridView1.DataSource = doluTablo;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cins = comboBox1.SelectedItem?.ToString();
            string alan = comboBox3.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(cins) && !string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltrCins("Yks", alan, cins);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltr("Yks", alan);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(cins))
            {
                DataTable doluTablo = dbHelper.KursFltrJustCins("Yks", cins);
                dataGridView1.DataSource = doluTablo;
            }
            else
            {
                listele();
            }
        }

        private void yks_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cins = comboBox1.SelectedItem?.ToString();
            string alan = comboBox3.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(cins) && !string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltrCins("Yks", alan, cins);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(cins))
            {
                DataTable doluTablo = dbHelper.KursFltrJustCins("Yks", cins);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltr("Yks", alan);
                dataGridView1.DataSource = doluTablo;
            }
            else
            {
                listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable doluTablo = dbHelper.KursArama("Yks", textBox1.Text);
            dataGridView1.DataSource = doluTablo;
        }
    }
}
