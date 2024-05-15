using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dershane_otomasyon
{
    public partial class not_duz : Form
    {
        public not_duz()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        MsgHelper MsgHelper = new MsgHelper();
        private void button4_Click(object sender, EventArgs e)
        {
           dbHelper.OgrNotKyt(ogr_id.Text, ogr_ad.Text, ogr_soyad.Text, kurs.Text, alan.Text, puan.Text);
            MsgHelper.IslemMsg("eklendi", "Ekleme");
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
            id.Text = "";
            arama.Text = "";
            listele();
        }
        private void listele()
        {
            DataTable doluTablo = dbHelper.ListAllCalistir("puan");
            dataGridView1.DataSource = doluTablo;
        }
        private void not_duz_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int Sil_id = int.Parse(id.Text);
            dbHelper.AllDeleteSayi("puan" , "id" ,Sil_id);
            MsgHelper.IslemMsg("silindi", "Silme");
            listele();
        }

        private void arama_TextChanged(object sender, EventArgs e)
        {
            DataTable doluTablo = dbHelper.AllArama("puan",arama.Text);
            dataGridView1.DataSource = doluTablo;
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int Gun_id = int.Parse(id.Text);
                if (!string.IsNullOrWhiteSpace(ogr_ad.Text))
                {
                    dbHelper.AllGunc("puan", "ogr_ad", ogr_ad.Text, "id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(ogr_soyad.Text))
                {
                    dbHelper.AllGunc("puan", "ogr_soyad", ogr_soyad.Text, "id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(ogr_id.Text))
                {
                    dbHelper.AllGunc("puan", "ogr_id", ogr_id.Text, "id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(kurs.Text))
                {
                    dbHelper.AllGunc("puan", "ogr_kurs", kurs.Text, "id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(alan.Text))
                {
                    dbHelper.AllGunc("puan", "alan", alan.Text, "id", Gun_id);
                }
                if (!string.IsNullOrWhiteSpace(puan.Text))
                {
                    dbHelper.AllGunc("puan", "puan", puan.Text, "id", Gun_id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            MsgHelper.IslemMsg("Güncellendi", "Güncelleme");
            listele();
        }
    }
}
