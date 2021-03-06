//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lppa.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PuntosDeVentas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PuntosDeVentas()
        {
            this.Solicitudes = new HashSet<Solicitudes>();
        }
    
        public long Id { get; set; }
        public string CodigoReferencia { get; set; }
        public int Telefono_CodigoArea { get; set; }
        public long Telefono_Numero { get; set; }
        public string Mail { get; set; }
        public System.Guid RowId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ChangedOn { get; set; }
        public Nullable<System.Guid> ChangedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<System.Guid> DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public long DireccionId { get; set; }
    
        public virtual Direccion Direccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitudes> Solicitudes { get; set; }
    }
}
