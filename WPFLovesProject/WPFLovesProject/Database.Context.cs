﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFLovesProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_128040_lovesEntities : DbContext
    {
        public DB_128040_lovesEntities()
            : base("name=DB_128040_lovesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StorePrice> StorePrices { get; set; }
    }
}