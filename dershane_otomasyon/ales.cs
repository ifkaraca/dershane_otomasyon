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
    public partial class ales : Form
    {
        public ales()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo = dbHelper.KursList("Ales");
            dataGridView1.DataSource = doluTablo;
        }
        private void ales_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cins = comboBox1.SelectedItem?.ToString();
            string alan = comboBox3.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(cins) && !string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltrCins("Ales", alan, cins);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltr("Ales", alan);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(cins))
            {
                DataTable doluTablo = dbHelper.KursFltrJustCins("Ales", cins);
                dataGridView1.DataSource = doluTablo;
            }
            else
            {
                listele();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cins = comboBox1.SelectedItem?.ToString();
            string alan = comboBox3.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(cins) && !string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltrCins("Ales", alan, cins);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(cins))
            {
                DataTable doluTablo = dbHelper.KursFltrJustCins("Ales", cins);
                dataGridView1.DataSource = doluTablo;
            }
            else if (!string.IsNullOrEmpty(alan))
            {
                DataTable doluTablo = dbHelper.KursFltr("Ales", alan);
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
            listele();
        }
    }
}
