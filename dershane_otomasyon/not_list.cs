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
    public partial class not_list : Form
    {
        public not_list()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo = dbHelper.ListAllCalistir("puan");
            dataGridView1.DataSource = doluTablo;
        }
        private void not_list_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable doluTablo = dbHelper.AllArama("puan", textBox1.Text);
            dataGridView1.DataSource = doluTablo;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Alansız")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Kpss", "Alansız");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Sayısal")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Yks", "Sayısal");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox3.SelectedItem.ToString() == "Eşit Ağırlık")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Yks", "Eşit Ağırlık");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox3.SelectedItem.ToString() == "Sözel")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Yks", "Sözel");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Sayısal")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Dgs", "Sayısal");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox4.SelectedItem.ToString() == "Eşit Ağırlık")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Dgs", "Eşit AĞırlık");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox4.SelectedItem.ToString() == "Sözel")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Dgs", "Sözel");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString() == "Sayısal")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Ales", "Sayısal");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox5.SelectedItem.ToString() == "Eşit Ağırlık")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Ales", "Eşit Ağırlık");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox5.SelectedItem.ToString() == "Sözel")
            {
                DataTable doluTablo = dbHelper.PuanAlanFltr("Ales", "Sözel");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox1.Text = "";
        }
    }
}
