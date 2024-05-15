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
using System.Data.OleDb;
using System.Data.Common;

namespace dershane_otomasyon
{
    public partial class ogr_kyt : Form
    {
        public ogr_kyt()
        {
            InitializeComponent();
        }
        MsgHelper msgHelper = new MsgHelper();
        DbHelper dbHelper = new DbHelper();
        ogr_list ogr_List = new ogr_list();

        private void button2_Click(object sender, EventArgs e)
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
        }
        private void ogr_kyt_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dershaneas.mdb");
            baglanti.Open();
            string query = "Select count(*) from ogr";
            OleDbCommand komut = new OleDbCommand(query, baglanti);
            int ogr_sayi = Convert.ToInt32(komut.ExecuteScalar());
            ogr_sayisi.Text = ogr_sayi.ToString();
            baglanti.Close();

        }

        private void kurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kurs.SelectedItem.ToString() == "Kpss")
            {
                alan.Items.Clear();
                alan.Items.Add("Alansız");
            }
            else if(kurs.SelectedItem.ToString()=="Yks")
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

        private void button1_Click(object sender, EventArgs e)
        {
            string dogumTarihi = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dbHelper.OgrKyt(dogumTarihi,
                            ogr_ad.Text,
                            ogr_soyad.Text,
                            cinsiyet.Text,
                            ogr_telno.Text,
                            mail.Text,
                            adres.Text,
                            veli_ad.Text,
                            veli_soyad.Text,
                            veli_telno.Text,
                            kurs.Text,
                            alan.Text);

            msgHelper.IslemMsg("eklendi", "Ekleme");

          ogr_List.Activate();
        }
    }
}
