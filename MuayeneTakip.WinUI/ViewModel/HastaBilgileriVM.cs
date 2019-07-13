using MuayeneTakip.WinUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayeneTakip.WinUI.ViewModel
{
    class HastaBilgileriVM
    {
        public int HastaID { get; set; }
        public string TcKimlikNo { get; set; }
        public string  AdSoyad { get; set; }
        public CinsiyetEnum Cinsiyet { get; set; }
        public string  Telefon { get; set; }
        public string  Notlar { get; set; }
    }
}
