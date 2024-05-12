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
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dershaneas.mdb");
        DbHelper dbHelper = new DbHelper();


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
            //baglanti.Open();
            //OleDbCommand komut=new OleDbCommand("insert into ogr(ogr_ad,ogr_soyad,cinsiyet,d_tarihi,telefon,email,adres,veli_ad,veli_soyad,veli_tlfn,kurs_ad,alani) values" +
            //    "('"+ ogr_ad.Text +"', '"+ ogr_soyad.Text +"','"+ cinsiyet.Text +"','"+ dogumTarihi +"','"+ ogr_telno.Text +"','"+ mail.Text +"','"+ adres.Text +"','"+ veli_ad.Text +"','"+ veli_soyad.Text +"','"+ veli_telno.Text +"','"+ kurs.Text +"','"+ alan.Text +"')" , baglanti);
            //komut.ExecuteNonQuery();
            
            //baglanti.Close();
            MessageBox.Show("Kayıt başarılı bir şekilde yapıldı", "Kayıt");
        }
    }
}
