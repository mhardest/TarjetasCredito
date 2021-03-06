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
    
    public partial class TitularExtensiones
    {
        public long TarjetaDeCreditoId { get; set; }
        public long TitularId { get; set; }
        public int DNI { get; set; }
        public string CUIT { get; set; }
        public System.DateTime FechaDeNacimiento { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Nacionalidad { get; set; }
        public long EstadoCivilId { get; set; }
        public int Sexo { get; set; }
        public Nullable<decimal> IngresosMensuales { get; set; }
        public string Ocupacion { get; set; }
        public long DireccionId { get; set; }
        public int TelefonoCelular_CodigoArea { get; set; }
        public long TelefonoCelular_Numero { get; set; }
        public int TelefonoParticular_CodigoArea { get; set; }
        public long TelefonoParticular_Numero { get; set; }
        public System.Guid RowId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> ChangedOn { get; set; }
        public Nullable<System.Guid> ChangedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<System.Guid> DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ClienteTitular ClienteTitular { get; set; }
        public virtual Direccion Direccion { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual TarjetaDeCredito TarjetaDeCredito { get; set; }
    }
}
