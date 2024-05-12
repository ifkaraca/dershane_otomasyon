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
        DataTable tablo = new DataTable();
        DbHelper dbHelper = new DbHelper();
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into puan(ogr_id,ogr_ad,ogr_soyad,ogr_kurs,alan,puan) values('"+ogr_id.Text+"','"+ogr_ad.Text+"','"+ogr_soyad.Text+"','"+kurs.Text+"','"+alan.Text+"','"+ puan.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarılı bir şekilde yapıldı", "Kayıt");
            tablo.Clear();
            listele();
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
        private void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from puan", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void not_duz_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            dbHelper.NotDelete(dataGridView1.CurrentRow.Cells["ogr_id"].Value.ToString());
            MessageBox.Show("Kayıt başarılı bir şekilde silindi", "Silme İşlemi");
            listele();
        }
    }
}
