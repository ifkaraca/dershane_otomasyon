using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershane_otomasyon
{
    public partial class ana_sayfa : Form
    {
        public ana_sayfa()
        {
            InitializeComponent();
            
        }
        ogr_kyt ogr = new ogr_kyt();
        ogr_list list = new ogr_list();
        veli vel = new veli();
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void ana_sayfa_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                ogr.MdiParent = this.ParentForm;
                ogr.Dock = DockStyle.Fill;
                ogr.Show();
            }
            else
            {
                ogr.Activate();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(this.MdiParent != null) 
            {
            list.MdiParent = this.ParentForm;
            list.Dock = DockStyle.Fill; 
            list.Show();
            }
            else 
            { 
             ogr.Activate(); 
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(this.MdiParent != null)
            {
                vel.MdiParent = this.ParentForm;
                vel.Dock = DockStyle.Fill;
                vel.Show();
            }
            else
            {
                vel.Activate();
            }
        }
    }
}
