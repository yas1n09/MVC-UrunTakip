﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UrunTakipEntities2 : DbContext
    {
        public UrunTakipEntities2()
            : base("name=UrunTakipEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBL_Musteriler> TBL_Musteriler { get; set; }
        public virtual DbSet<TBL_Urunler> TBL_Urunler { get; set; }
        public virtual DbSet<TBL_Users> TBL_Users { get; set; }
        public virtual DbSet<TBL_Satislar> TBL_Satislar { get; set; }
    }
}