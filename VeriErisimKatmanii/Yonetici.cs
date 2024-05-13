using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmanii
{
    public class Yonetici
    {
        public int ID { get; set; }

        public int YöneticiTur_ID { get; set; }

        public string YoneticiTur { get; set; }

        public string Isim { get; set; }

        public string SoyIsim { get; set; }

        public string Mail { get; set; }

        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string ProfilFotografi { get; set; }

        public bool Durum { get; set; }

        public bool Silinmis { get; set; }
    }
}
