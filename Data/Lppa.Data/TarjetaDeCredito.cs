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
    
    public partial class TarjetaDeCredito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TarjetaDeCredito()
        {
            this.Solicitudes = new HashSet<Solicitudes>();
        }
    
        public long Id { get; set; }
        public string Numero { get; set; }
        public string CodigoSeguridad { get; set; }
        public System.DateTime FechaDeVencimiento { get; set; }
        public System.DateTime FechaDeCreacion { get; set; }
        public int EstadoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public decimal Limite { get; set; }
        public bool Internacional { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public long EmisorTarjetaCreditoId { get; set; }
        public long TitularId { get; set; }
        public System.Guid RowId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ChangedOn { get; set; }
        public Nullable<System.Guid> ChangedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<System.Guid> DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ClienteTitular ClienteTitular { get; set; }
        public virtual EmisorTarjetaCredito EmisorTarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitudes> Solicitudes { get; set; }
        public virtual TitularExtensiones TitularExtensiones { get; set; }
    }
}