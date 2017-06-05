using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public abstract class Persona : EntityBase
    {
        
        #region Datos Personales

        public int DNI { get; set; }
        public string CUIT { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Nacionalidad { get; set; }
        public long EstadoCivilId { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public Sexo Sexo { get; set; }
        public decimal IngresosMensuales { get; set; }
        public string Ocupacion { get; set; }
        public long DireccionId { get; set; }
        public virtual Direccion Direccion { get; set; }

        #endregion

        #region Propiedades Telefonicas

        public Telefono TelefonoCelular { get; set; }
        public Telefono TelefonoParticular { get; set; }

        #endregion

    }
}