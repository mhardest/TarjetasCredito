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
    
    public partial class Fotos
    {
        public long SolicitudId { get; set; }
        public byte[] Imagen { get; set; }
        public System.Guid RowId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ChangedOn { get; set; }
        public Nullable<System.Guid> ChangedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<System.Guid> DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Solicitudes Solicitudes { get; set; }
    }
}
