using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunTakip.Controllers
{
    public class ModelSatis
    {
        //Musteri
        public int MusteriId { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        //SAtıs
        public int SatisId { get; set; }
        public int Urun { get; set; }
        public int Musteri { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public System.DateTime SevkTarihi { get; set; }
        public string KamyonPlaka { get; set; }
        public int KamyonDurum { get; set; }
        //
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal UrunFiyat { get; set; }
        public int Stok { get; set; }
    }
}