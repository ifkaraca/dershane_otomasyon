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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 5;
            timer1.Start();
            if (panel2.Width >= 704)
            {
                timer1.Stop();
                login2 login = new login2();
                login.Show();
                this.Hide();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
