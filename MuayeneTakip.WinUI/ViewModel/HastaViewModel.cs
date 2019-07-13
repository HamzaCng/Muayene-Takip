using MuayeneTakip.WinUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayeneTakip.WinUI.ViewModel
{
    class HastaViewModel
    {
        public int HastaID { get; set; }
        public string  TcKimlikNo { get; set; }
        public string  Ad { get; set; }
        public string  Soyad { get; set; }
        public CinsiyetEnum Cinsiyet { get; set; }
        public MedeniHalEnum MedeniHal { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string  ResimYolu { get; set; }
        public string Telefon { get; set; }
        public string  Adres { get; set; }
        public KanGrubuEnum KanGrubu { get; set; }
        public string Notlar { get; set; }
    }
}
