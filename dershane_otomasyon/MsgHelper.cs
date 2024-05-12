using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershane_otomasyon
{
    public class MsgHelper
    {

      public void IslemMsg(string mesaj, string islem) 
        {
            MessageBox.Show($"Kayıt başarılı bir şekilde {mesaj}", $"{islem} İşlemi");
        }
    }
}
