//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrunTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Satislar
    {
        public int SatisId { get; set; }
        public int Urun { get; set; }
        public int Musteri { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public System.DateTime SevkTarihi { get; set; }
        public string KamyonPlaka { get; set; }
        public Nullable<int> KamyonDurum { get; set; }
    
        public virtual TBL_Musteriler TBL_Musteriler { get; set; }
        public virtual TBL_Urunler TBL_Urunler { get; set; }
    }
}
