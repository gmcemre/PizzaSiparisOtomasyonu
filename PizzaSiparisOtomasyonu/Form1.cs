using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaSiparisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucuk = new Ebat { Adi = "Küçük", Carpan = 1 };
            Ebat orta = new Ebat { Adi = "Orta", Carpan = 1.25m };
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan = 1.75m };
            Ebat maxi = new Ebat { Adi = "Maxi", Carpan = 2 };

            List<Ebat> ebatlar = new List<Ebat> { kucuk, orta, buyuk, maxi };
            foreach (Ebat item in ebatlar)
            {
                cmbEbat.Items.Add(item);
            }

            Pizza klasik = new Pizza { Adi = "Klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Adi = "Karışık", Fiyat = 17 };
            Pizza turkish = new Pizza { Adi = "Turkish", Fiyat = 20 };
            Pizza tuna = new Pizza { Adi = "Tuna", Fiyat = 21 };
            Pizza akdeniz = new Pizza { Adi = "Akdeniz", Fiyat = 19 };
            Pizza karadeniz = new Pizza { Adi = "Karadeniz", Fiyat = 22 };

            List<Pizza> pizzalar = new List<Pizza> { klasik, karisik, turkish, tuna, akdeniz, karadeniz };
            foreach (Pizza item in pizzalar)
            {
                listPizzalar.Items.Add(item);
            }

            KenarTip ince = new KenarTip { Adi = "İnce Kenar", EkFiyat = 0 };
            rdbInceKenar.Tag = ince;
            KenarTip kalin = new KenarTip { Adi = "Kalın Kenar", EkFiyat = 2 };
            rdbKalinKenar.Tag = kalin;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza p = (Pizza)listPizzalar.SelectedItem;
            p.Ebat = (Ebat)cmbEbat.SelectedItem;
            p.KenarTipi = rdbInceKenar.Checked ? (KenarTip)rdbInceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;
            p.Malzemeler = new List<string>();

            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    p.Malzemeler.Add(item.Text);
                }
            }
            decimal tutar = nudAdet.Value * p.Tutar;
            txtTutar.Text = tutar.ToString();
            s = new Siparis();
            s.Pizza = p;
            s.Adet = (int)nudAdet.Value;
        }

        Siparis s;
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (s != null)
            {
                listSepet.Items.Add(s);
            }
        }

        private void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int adet = 0;
            foreach (Siparis item in listSepet.Items)
            {
                toplamTutar += item.Adet * item.Pizza.Tutar;
                adet++;
            }
            lblToplamTutar.Text = toplamTutar.ToString();
            MessageBox.Show(string.Format("Toplam Sipariş Adediniz : {0} {1}Toplam Sipariş Tutarınız : {2}", adet, Environment.NewLine, toplamTutar));
        }
    }
}
