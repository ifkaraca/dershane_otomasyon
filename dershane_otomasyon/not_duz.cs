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
    public partial class not_duz : Form
    {
        public not_duz()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dershaneas.mdb");
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into puan(ogr_id,ogr_ad,ogr_soyad,ogr_kurs,alan,puan) values('"+ogr_id.Text+"','"+ogr_ad.Text+"','"+ogr_soyad.Text+"','"+kurs.Text+"','"+alan.Text+"','"+ puan.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarılı bir şekilde yapıldı", "Kayıt");
        }

        private void kurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kurs.SelectedItem.ToString() == "Kpss")
            {
                alan.Items.Clear();
                alan.Items.Add("Alansız");
            }
            else if (kurs.SelectedItem.ToString() == "Yks")
            {
                alan.Items.Clear();
                alan.Items.Add("Sayısal");
                alan.Items.Add("Eşit Ağırlık");
                alan.Items.Add("Sözel");
            }
            else if (kurs.SelectedItem.ToString() == "Dgs")
            {
                alan.Items.Clear();
                alan.Items.Add("Sayısal");
                alan.Items.Add("Eşit Ağırlık");
                alan.Items.Add("Sözel");
            }
            else if (kurs.SelectedItem.ToString() == "Ales")
            {
                alan.Items.Clear();
                alan.Items.Add("Sayısal");
                alan.Items.Add("Eşit Ağırlık");
                alan.Items.Add("Sözel");
            }
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            ogr_ad.Text = "";
            ogr_soyad.Text = "";
            ogr_id.Text = "";
            kurs.Text = "";
            alan.Text = "";
            puan.Text = "";
        }
    }
}
