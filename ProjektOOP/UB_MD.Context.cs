﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektOOP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UbezpieczalniaEntities : DbContext
    {
        public UbezpieczalniaEntities()
            : base("name=UbezpieczalniaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Platnosci> Platnosci { get; set; }
        public virtual DbSet<Pojazdy> Pojazdy { get; set; }
        public virtual DbSet<Polisy> Polisy { get; set; }
        public virtual DbSet<Wlasciciele> Wlasciciele { get; set; }
    }
}
