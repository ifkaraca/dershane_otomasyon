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
        MsgHelper msgHelper = new MsgHelper();
        DbHelper dbHelper = new DbHelper();
        private void listele()
        {
            DataTable doluTablo = dbHelper.ListAllCalistir("ogr");
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
            int ogrSayi = int.Parse(ogr_id.Text);
            dbHelper.AllDeleteSayi("ogr", "ogr_id",ogrSayi);
            msgHelper.IslemMsg("silindi", "Silme");
            listele();
        }

        private void arama_TextChanged(object sender, EventArgs e)
        {
            DataTable doluTablo = dbHelper.AllArama("ogr", arama.Text);
            dataGridView1.DataSource = doluTablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dogumTarihi = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                int Gun_id = int.Parse(ogr_id.Text);
                if (!string.IsNullOrWhiteSpace(ogr_ad.Text))
                {
                    dbHelper.AllGunc("ogr", "ogr_ad", ogr_ad.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(ogr_soyad.Text))
                {
                    dbHelper.AllGunc("ogr", "ogr_soyad", ogr_soyad.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(cinsiyet.Text))
                {
                    dbHelper.AllGunc("ogr", "cinsiyet", cinsiyet.Text, "ogr_id", Gun_id);
                }
                //if (!string.IsNullOrWhiteSpace(dateTimePicker1.Text))
                //{
                //    dbHelper.AllGunc("ogr", "d_tarihi", dogumTarihi, "ogr_id", Gun_id);
                //}
                if (!string.IsNullOrWhiteSpace(veli_ad.Text))
                {
                    dbHelper.AllGunc("ogr", "veli_ad", veli_ad.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(veli_soyad.Text))
                {
                    dbHelper.AllGunc("ogr", "veli_soyad", veli_soyad.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(veli_telno.Text))
                {
                    dbHelper.AllGunc("ogr", "veli_tlfn", veli_telno.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(ogr_telno.Text))
                {
                    dbHelper.AllGunc("ogr", "telefon", ogr_telno.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(mail.Text))
                {
                    dbHelper.AllGunc("ogr", "email", mail.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(adres.Text))
                {
                    dbHelper.AllGunc("ogr", "adres", adres.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(kurs.Text))
                {
                    dbHelper.AllGunc("ogr", "kurs_ad", kurs.Text, "ogr_id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(alan.Text))
                {
                    dbHelper.AllGunc("ogr", "alani", alan.Text, "ogr_id", Gun_id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            msgHelper.IslemMsg("Güncellendi", "Güncelleme");
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
    }
}
