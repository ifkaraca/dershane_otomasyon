using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershane_otomasyon
{
    public partial class ogr_list : Form
    {
        public ogr_list()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Alansız")
            {
                DataTable doluTablo = dbHelper.KursFltr("Kpss", "Alansız");
                dataGridView1.DataSource = doluTablo;
            }
        }
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo = dbHelper.ListAllCalistir("ogr");
            dataGridView1.DataSource = doluTablo;
        }
        private void ogr_list_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Erkek")
            {
                DataTable doluTablo = dbHelper.AllJustCinsFltr("ogr","Erkek");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox1.SelectedItem.ToString() == "Kız")
            {
                DataTable doluTablo = dbHelper.AllJustCinsFltr("ogr", "Kız");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Sayısal")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Yks", "Sayısal");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox3.SelectedItem.ToString() == "Eşit Ağırlık")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Yks", "Eşit Ağırlık");
                dataGridView1.DataSource = doluTablo;
            }
            else if(comboBox3.SelectedItem.ToString() =="Sözel")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Yks", "Sözel");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Sayısal")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Dgs", "Sayısal");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox4.SelectedItem.ToString() == "Eşit Ağırlık")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Dgs", "Eşit Ağırlık");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox4.SelectedItem.ToString() == "Sözel")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Dgs", "Sözel");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString() == "Sayısal")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Ales", "Sayısal");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox5.SelectedItem.ToString() == "Eşit Ağırlık")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Ales", "Eşit Ağırlık");
                dataGridView1.DataSource = doluTablo;
            }
            else if (comboBox5.SelectedItem.ToString() == "Sözel")
            {
                DataTable doluTablo = dbHelper.AllAlanFltr("ogr", "Ales", "Sözel");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable doluTablo = dbHelper.AllArama("ogr", textBox1.Text);
            dataGridView1.DataSource = doluTablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
