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
    
    public partial class TBL_Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Urunler()
        {
            this.TBL_Satislar = new HashSet<TBL_Satislar>();
        }
    
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<decimal> UrunFiyat { get; set; }
        public Nullable<int> Stok { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Satislar> TBL_Satislar { get; set; }
    }
}
