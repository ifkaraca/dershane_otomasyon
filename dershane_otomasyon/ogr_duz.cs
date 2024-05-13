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
    }
}
