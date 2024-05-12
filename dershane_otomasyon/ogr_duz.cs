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
    public partial class ogr_duz : Form
    {
        public ogr_duz()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dershaneas.mdb");
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo= dbHelper.GetOgrTable();
            dataGridView1.DataSource = doluTablo;
        }
        private void ogr_duz_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogr_ad.Text = "";
            ogr_soyad.Text = "";
            ogr_telno.Text = "";
            cinsiyet.Text = "";
            veli_ad.Text = "";
            veli_soyad.Text = "";
            veli_telno.Text = "";
            adres.Text = "";
            mail.Text = "";
            alan.Text = "";
            kurs.Text = "";
            ogr_id.Text = "";
            arama.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete * from ogr where ogr_id='" + dataGridView1.CurrentRow.Cells["ogr_id"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarılı bir şekilde silindi", "Silme İşlemi");
            listele();
        }
    }
}
