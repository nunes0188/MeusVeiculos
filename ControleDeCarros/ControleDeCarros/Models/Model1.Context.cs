﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleDeCarros.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Veiculos> VeiculosSet { get; set; }
        public virtual DbSet<Categorias> CategoriasSet { get; set; }
        public virtual DbSet<Marcas> MarcasSet { get; set; }
        public virtual DbSet<Gastos> GastosSet { get; set; }
        public virtual DbSet<SubTiposGastos> SubTiposGastosSet { get; set; }
        public virtual DbSet<TiposGastos> TiposGastosSet { get; set; }
    }
}
