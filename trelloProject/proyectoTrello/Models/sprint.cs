//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyectoTrello.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sprint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sprint()
        {
            this.requisitos = new HashSet<requisito>();
        }
    
        public int idSprint { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaIncio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<short> Estados { get; set; }
        public int idProyecto { get; set; }
    
        public virtual proyecto proyecto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requisito> requisitos { get; set; }
    }
}
