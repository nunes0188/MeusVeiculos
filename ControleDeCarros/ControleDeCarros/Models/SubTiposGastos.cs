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
    
    public partial class SubTiposGastos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubTiposGastos()
        {
            this.Gastos = new HashSet<Gastos>();
        }
    
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TiposGastosId { get; set; }
    
        public virtual TiposGastos TiposGastos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gastos> Gastos { get; set; }
    }
}
