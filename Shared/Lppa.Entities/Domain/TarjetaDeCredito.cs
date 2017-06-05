using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class TarjetaDeCredito : EntityBase
    {
        #region Propiedades

        public string Numero { get; set; }
        public string CodigoSeguridad { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public EstadoTarjetaCredito EstadoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public decimal Limite { get; set; }
        public bool Internacional { get; set; }
        public DateTime? FechaAnulacion { get; set; }

        public long EmpresaTarjetasCreditoId { get; set; }

        public virtual EmisorTarjetaCredito EmpresaTarjetasCredito { get; set; }

        public long TitularId { get; set; }
        public virtual ClienteTitular Titular { get; set; }

        #endregion

        #region Static

        public static TarjetaDeCredito Crear(string numero)
        {
            TarjetaDeCredito tarjeta = new TarjetaDeCredito
            {
                FechaDeCreacion = new DateTime(),
                EstadoTarjeta = EstadoTarjetaCredito.EnImpresion
            };
            return tarjeta;
        }

        #endregion

        #region Métodos Públicos

        public void Confirmar()
        {
            this.EstadoTarjeta = EstadoTarjetaCredito.Asignado;
        }

        public void Anular()
        {
            this.EstadoTarjeta = EstadoTarjetaCredito.Anulado;
            this.FechaAnulacion = DateTime.Now;
        }

        #endregion
    }
}