using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace dershane_otomasyon
{
    public partial class Form1 : Form
    {
        ana_sayfa g_ana;
        dgs g_k_duz;
        kpss g_k_kyt;
        yks g_k_list;
        not_duz g_n_duz;
        not_list g_n_list;
        veli g_odeme;
        ogr_duz g_ogr_duz;
        ogr_kyt g_ogr_kyt;
        ogr_list g_ogr_list;
        ales g_ales;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(g_ana == null)
            {
                g_ana = new ana_sayfa();
                g_ana.FormClosed += G_ana_FormClosed;
                g_ana.MdiParent = this;
                g_ana.Dock = DockStyle.Fill;
                g_ana.Show();
            }
            else
            {
                g_ana.Activate  ();
            }
        }

        private void G_ana_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_ana =null;
        }

        bool menuExpand = false;
        private void ogrT_Tick(object sender, EventArgs e)
        {
            if ( menuExpand == false ) 
            {
                pnl_ogr.Height += 10;
                if(pnl_ogr.Height >=203)
                {
                    ogrT.Stop();
                    menuExpand = true;
                }
                ogr_up.Visible = true;
                ogr_down.Visible = false;
              
            }
            else
            {
                pnl_ogr.Height -= 10;
                if(pnl_ogr.Height <=43)
                {
                    ogrT.Stop();
                    menuExpand = false;
                }
                ogr_down.Visible = true;
                ogr_up.Visible = false;
            }
        }

        private void but_ogr_Click(object sender, EventArgs e)
        {
            ogrT.Start();
        }
        bool sideExpand = true;
        private void sidebarT_Tick(object sender, EventArgs e)
        {

            if (sideExpand)
            {
                sideBar.Width -= 10;
                if (sideBar.Width <= 67)
                {
                    sideExpand = false;
                    sidebarT.Stop();
                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width >= 255)
                {
                    sideExpand = true;
                    sidebarT.Stop();
                }
            }
        }

        private void ham_but_Click(object sender, EventArgs e)
        {
            sidebarT.Start();
        }

        private void but_kurs_Click(object sender, EventArgs e)
        {
            kursT.Start();
        }
        bool kursExpand = false;
        private void kursT_Tick(object sender, EventArgs e)
        {
            if (kursExpand == false)
            {
                pnl_kurs.Height += 10;
                if (pnl_kurs.Height >= 247)
                {
                    kursT.Stop();
                    kursExpand = true;
                }
                kurs_up.Visible = true;
                kurs_down.Visible = false;
            }
            else
            {
                pnl_kurs.Height -= 10;
                if (pnl_kurs.Height <= 43)
                {
                    kursT.Stop();
                    kursExpand = false;
                }
                kurs_down.Visible=true;
                kurs_up.Visible=false;
            }
        }
        bool notExpand = false;
        private void notT_Tick(object sender, EventArgs e)
        {
            if (notExpand == false)
            {
                pnl_not.Height += 10;
                if (pnl_not.Height >= 150)
                {
                    notT.Stop();
                    notExpand = true;
                }
                not_up.Visible = true;
                not_down.Visible=false;
            }
            else
            {
                pnl_not.Height -= 10;
                if (pnl_not.Height <= 43)
                {
                    notT.Stop();
                    notExpand = false;
                }
                not_down.Visible=true ;
                not_up.Visible=false ;
            }
        }

        private void but_not_Click(object sender, EventArgs e)
        {
            notT.Start();
        }

        private void close_but_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void close_but_MouseEnter(object sender, EventArgs e)
        {
            close_but.BackColor = Color.Red;
        }

        private void close_but_MouseLeave(object sender, EventArgs e)
        {
            close_but.BackColor = Color.Transparent;
        }

        private void but_ana_MouseEnter(object sender, EventArgs e)
        {
            but_ana.BackColor = Color.FromArgb(54,54 ,54) ;
        }

        private void but_ana_MouseLeave(object sender, EventArgs e)
        {
            but_ana.BackColor = Color.FromArgb(30,30,30);
        }

        private void but_ogr_MouseEnter(object sender, EventArgs e)
        {
            but_ogr.BackColor = Color.FromArgb(54, 54, 54);
        }

        private void but_ogr_MouseLeave(object sender, EventArgs e)
        {
            but_ogr.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void but_kurs_MouseEnter(object sender, EventArgs e)
        {
            but_kurs.BackColor = Color.FromArgb(54, 54, 54);
        }

        private void but_kurs_MouseLeave(object sender, EventArgs e)
        {
            but_kurs.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void but_not_MouseEnter(object sender, EventArgs e)
        {
            but_not.BackColor =Color.FromArgb(54,54,54);
        }

        private void but_not_MouseLeave(object sender, EventArgs e)
        {
            but_not.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void but_odeme_MouseEnter(object sender, EventArgs e)
        {
            but_odeme.BackColor = Color.FromArgb(54, 54, 54);
        }

        private void but_odeme_MouseLeave(object sender, EventArgs e)
        {
            but_odeme.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void kurs_duz_MouseEnter(object sender, EventArgs e)
        {
            dgs.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void kurs_duz_MouseLeave(object sender, EventArgs e)
        {
            dgs.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void kurs_kyt_MouseEnter(object sender, EventArgs e)
        {
            kpss.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void kurs_kyt_MouseLeave(object sender, EventArgs e)
        {
            kpss.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void kurs_list_MouseEnter(object sender, EventArgs e)
        {
            yks.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void kurs_list_MouseLeave(object sender, EventArgs e)
        {
            yks.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void not_duz_MouseEnter(object sender, EventArgs e)
        {
            not_duz.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void not_duz_MouseLeave(object sender, EventArgs e)
        {
            not_duz.BackColor = Color.FromArgb(38, 38, 38);
        }
        private void not_list_MouseEnter(object sender, EventArgs e)
        {
            not_list.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void not_list_MouseLeave(object sender, EventArgs e)
        {
            not_list.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void ogr_duz_MouseEnter(object sender, EventArgs e)
        {
            ogr_duz.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void ogr_duz_MouseLeave(object sender, EventArgs e)
        {
            ogr_duz.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void ogr_kyt_MouseEnter(object sender, EventArgs e)
        {
            ogr_kyt.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void ogr_kyt_MouseLeave(object sender, EventArgs e)
        {
            ogr_kyt.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void ogr_list_MouseEnter(object sender, EventArgs e)
        {
            ogr_list.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void ogr_list_MouseLeave(object sender, EventArgs e)
        {
            ogr_list.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void ogr_duz_Click(object sender, EventArgs e)
        {
            if(g_ogr_duz == null)
            {
                g_ogr_duz = new ogr_duz();
                g_ogr_duz.FormClosed += G_ogr_duz_FormClosed;
                g_ogr_duz.MdiParent = this;
                g_ogr_duz.Dock = DockStyle.Fill;
                g_ogr_duz.Show();
            }
            else
            {
                g_ogr_duz.Activate();
            }
        }

        private void G_ogr_duz_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_ogr_duz = null;
        }

        private void ogr_kyt_Click(object sender, EventArgs e)
        {
            if(g_ogr_kyt == null)
            {
                g_ogr_kyt = new ogr_kyt();
                g_ogr_kyt.FormClosed += G_ogr_kyt_FormClosed;
                g_ogr_kyt .MdiParent = this;
                g_ogr_kyt.Dock = DockStyle.Fill;
                g_ogr_kyt .Show();
            }
            else
            {
                g_ogr_kyt?.Activate();
            }

        }

        private void G_ogr_kyt_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_ogr_kyt = null;
        }

        private void ogr_list_Click(object sender, EventArgs e)
        {
            if(g_ogr_list == null)
            {
                g_ogr_list = new ogr_list();
                g_ogr_list.FormClosed += G_ogr_list_FormClosed;
                g_ogr_list .MdiParent = this;
                g_ogr_list.Dock = DockStyle.Fill;
                g_ogr_list .Show();
            }
            else
            {
                g_ogr_list?.Activate();
            }
        }

        private void G_ogr_list_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_ogr_list = null;
        }

        private void but_odeme_Click(object sender, EventArgs e)
        {
            if(g_odeme == null)
            {
                g_odeme = new veli();
                g_odeme.FormClosed += G_odeme_FormClosed;
                g_odeme.MdiParent= this;
                g_odeme .Dock = DockStyle.Fill;
                g_odeme .Show();
            }
            else
            {
                g_odeme.Activate();
            }
        }

        private void G_odeme_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_odeme=null;
        }

        private void kurs_duz_Click(object sender, EventArgs e)
        {
            if(g_k_duz == null)
            {
                g_k_duz = new dgs();
                g_k_duz.FormClosed += G_k_duz_FormClosed;
                g_k_duz.MdiParent = this;
                g_k_duz .Dock = DockStyle.Fill;
                g_k_duz .Show();
            }
            else
            {
                g_k_duz.Activate();
            }
        }

        private void G_k_duz_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_k_duz=null;
        }

        private void kurs_kyt_Click(object sender, EventArgs e)
        {
            if (g_k_kyt == null)
            {
                g_k_kyt = new kpss();
                g_k_kyt.FormClosed += G_k_kyt_FormClosed;
                g_k_kyt.MdiParent =this;
                g_k_kyt .Dock = DockStyle.Fill;
                g_k_kyt .Show();
            }
            else
            {
                g_k_kyt.Activate();
            }
        }

        private void G_k_kyt_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_k_kyt=null;
        }

        private void kurs_list_Click(object sender, EventArgs e)
        {
            if(g_k_list == null)
            {
                g_k_list = new yks();
                g_k_list.FormClosed += G_k_list_FormClosed;
                g_k_list.MdiParent=this;
                g_k_list .Dock = DockStyle.Fill;
                g_k_list .Show();
            }
            else
            { g_k_list.Activate(); }
        }

        private void G_k_list_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_k_list=null;
        }

        private void not_duz_Click(object sender, EventArgs e)
        {
            if(g_n_duz == null)
            {
                g_n_duz = new not_duz();
                g_n_duz.FormClosed += G_n_duz_FormClosed;
                g_n_duz .MdiParent=this;
                g_n_duz.Dock = DockStyle.Fill;
                g_n_duz .Show();
            }
            else
            {
                g_n_duz.Activate();
            }
        }

        private void G_n_duz_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_n_duz=null;
        }


        private void not_list_Click(object sender, EventArgs e)
        {
            if (g_n_list == null)
            {
                g_n_list = new not_list();
                g_n_list.FormClosed += G_n_list_FormClosed;
                g_n_list.MdiParent=this;
                g_n_list .Dock = DockStyle.Fill;
                g_n_list .Show();
            }
            else
            { g_n_list.Activate(); }
        }

        private void G_n_list_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_n_list=null;
        }

        private void but_ana_Click(object sender, EventArgs e)
        {
            if (g_ana == null)
            {
                g_ana = new ana_sayfa();
                g_ana.FormClosed += G_ana_FormClosed;
                g_ana.MdiParent = this;
                g_ana.Dock = DockStyle.Fill;
                g_ana.Show();
            }
            else
            {
                g_ana.Activate();
            }
        }

        private void ales_Click(object sender, EventArgs e)
        {
            if(g_ales == null)
            {
                g_ales = new ales();
                g_ales.FormClosed += G_ales_FormClosed;
                g_ales.MdiParent = this;
                g_ales .Dock = DockStyle.Fill;
                g_ales .Show();
            }
            else
            {
                g_ales.Activate();
            }
        }

        private void G_ales_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_ales = null;
        }
    } 
}