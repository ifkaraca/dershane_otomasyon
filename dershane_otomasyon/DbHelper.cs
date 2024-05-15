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

        public void OgrNotKyt(string ogr_id, 
                              string ogr_ad, 
                              string ogr_soyad, 
                              string kurs, 
                              string alan, 
                              string puan)
        {
            OleDbCommand komut = new OleDbCommand($@"insert into puan(ogr_id,ogr_ad,ogr_soyad,ogr_kurs,alan,puan) 
values('{ogr_id}','{ogr_ad}','{ogr_soyad}','{kurs}','{alan}','{puan}')", baglanti);
            KomutCalistir(komut);
        }

        public void AllDeleteSayi(string tablo_ad, string sart, int deger)
        {
            OleDbCommand komut = new OleDbCommand($"delete * from {tablo_ad} where {sart}={deger}", baglanti);
            KomutCalistir(komut);
        }
       
        //Listeleme
        public DataTable ListAllCalistir(string tablo_ad)
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter($"select * from {tablo_ad}", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        } 
        public DataTable KursList(string prmtr_kurs)
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select ogr_id, ogr_ad, ogr_soyad, cinsiyet, email, kurs_ad, alani  from ogr 
            where kurs_ad= '{prmtr_kurs}'", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable KursFltr(string prmtr_kurs,  string prmtr_alan)
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select ogr_id, ogr_ad, ogr_soyad, cinsiyet, email, kurs_ad, alani  from ogr 
            where kurs_ad= '{prmtr_kurs}' and alani= '{prmtr_alan}' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable KursFltrCins(string prmtr_kurs, string prmtr_alan, string prmtr_cins)
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select ogr_id, ogr_ad, ogr_soyad, cinsiyet, email, kurs_ad, alani  from ogr 
            where kurs_ad= '{prmtr_kurs}' and alani= '{prmtr_alan}' and cinsiyet= '{prmtr_cins}' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable KursFltrJustCins(string prmtr_kurs, string prmtr_cins)
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select ogr_id, ogr_ad, ogr_soyad, cinsiyet, email, kurs_ad, alani  from ogr 
            where kurs_ad= '{prmtr_kurs}'  and cinsiyet= '{prmtr_cins}' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        
        //Öğrenci listesi
        public DataTable AllJustCinsFltr(string tbl,string prmtr_cins)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select *  from {tbl} 
            where cinsiyet= '{prmtr_cins}' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable AllAlanFltr(string tbl,string kurs , string alan)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select *  from {tbl} 
            where kurs_ad='{kurs}' and alani= '{alan}' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable PuanAlanFltr(string kurs , string alan)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select *  from puan 
            where ogr_kurs='{kurs}' and alan= '{alan}' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        //Arama
        public DataTable AllArama(string prmt_tbl,string ad)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select *  from {prmt_tbl} 
            Where ogr_ad Like '%{ad}%' ", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable KursArama(string kurs,string ad)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter($@"select ogr_id, ogr_ad, ogr_soyad, cinsiyet, email, kurs_ad, alani from ogr 
            where kurs_ad = '{kurs}' and ogr_ad like '%{ad}%'", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

    }
}
