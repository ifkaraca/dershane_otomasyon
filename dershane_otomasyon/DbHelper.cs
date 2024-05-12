using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dershane_otomasyon
{
    public class DbHelper
    {
        //debug path    C:\Users\ifkar\Desktop\proje\dershane_otomasyon\dershane_otomasyon\bin\Debug
        //db path       C:\Users\ifkar\Desktop\proje\dershane_otomasyon
        //OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../dershaneas.mdb");
        OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dershaneas.mdb");
        private void KomutCalistir(OleDbCommand komut)
        {
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void OgrKyt(string dogumTarihi,
                            string ogr_ad,
                            string ogr_soyad,
                            string cinsiyet,
                            string ogr_telno,
                            string mail,
                            string adres,
                            string veli_ad,
                            string veli_soyad,
                            string veli_telno,
                            string kurs,
                            string alan)
        {
            OleDbCommand komut = new OleDbCommand($@"
insert into ogr(ogr_ad,ogr_soyad,cinsiyet,d_tarihi,telefon,email,adres,veli_ad,veli_soyad,veli_tlfn,kurs_ad,alani) 
values('{ogr_ad}', '{ogr_soyad}','{cinsiyet}','{dogumTarihi}','{ogr_telno}','{mail}','{adres}','{veli_ad}','{veli_soyad}','{veli_telno}','{kurs}','{alan}')"
, baglanti);
            KomutCalistir(komut);
        }

        //        public void NotDuzKyt()
        //        {
        //            OleDbCommand komut = new OleDbCommand($@"
        //insert into puan(ogr_id,ogr_ad,ogr_soyad,ogr_kurs,alan,puan)
        //values('" + ogr_id.Text + "','" + ogr_ad.Text + "','" + ogr_soyad.Text + "','" + kurs.Text + "','" + alan.Text + "','" + puan.Text + "')", baglanti);
        //            KomutCalistir(komut);
        //        }


        public void NotDelete(string ogr_id)
        {
            OleDbCommand komut = new OleDbCommand($"delete * from puan where ogr_id='{ogr_id}'", baglanti);
            KomutCalistir(komut);
        }

        public DataTable GetOgrTable()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter($"select * from ogr", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();

            return tablo;
        }
    }

}
