//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Gastos
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public System.DateTime Data { get; set; }
        public int SubTiposGastosId { get; set; }
        public int VeiculosId { get; set; }
    
        public virtual SubTiposGastos SubTiposGastos { get; set; }
        public virtual Veiculos Veiculos { get; set; }
    }
}
