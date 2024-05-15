using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dershane_otomasyon
{
    public partial class kpss : Form
    {
        public kpss()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo = dbHelper.KursList("Kpss");
            dataGridView1.DataSource = doluTablo;
        }
        private void kpss_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.ToString() == "Alansız")
            {
                DataTable doluTablo = dbHelper.KursFltr("Kpss","Alansız");
                dataGridView1.DataSource = doluTablo;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Erkek")
            {
                DataTable doluTablo = dbHelper.KursFltrJustCins("Kpss", "Erkek");
                dataGridView1.DataSource = doluTablo;
            }
            if (comboBox1.SelectedItem.ToString() == "Kız")
            {
                DataTable doluTablo = dbHelper.KursFltrJustCins("Kpss", "Kız");
                dataGridView1.DataSource = doluTablo;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable doluTablo = dbHelper.KursArama("Kpss", textBox1.Text);
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
