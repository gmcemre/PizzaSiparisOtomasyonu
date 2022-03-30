using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSiparisOtomasyonu
{
    class Pizza
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public Ebat Ebat { get; set; }
        public KenarTip KenarTipi { get; set; }
        public List<string> Malzemeler { get; set; }
        public decimal Tutar
        {
            get
            {
                decimal tutar = 0;
                tutar = (Fiyat * Ebat.Carpan);
                tutar += KenarTipi.EkFiyat;
                return tutar;
            }
        }
        public override string ToString()
        {
            return Adi;
        }

    }
}
