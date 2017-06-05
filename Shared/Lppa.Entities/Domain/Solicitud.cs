using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Solicitud : EntityBase
    {
        #region Static

        public static Solicitud Crear()
        {
            return new Solicitud
            {
                EstadoSolicitud = EstadoDeSolicitud.Nuevo,
                TarjetaDeCredito = new TarjetaDeCredito(),
                AceptaRecibirEstadoCuentaEnCorreoElectronico = false,
                Foto = new Foto(),
                Firma = new Firma(),
            };
        }

        #endregion

        #region Propiedades Solicitud

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public EstadoDeSolicitud EstadoSolicitud { get; set; }

        public long TitularId { get; set; }
        public ClienteTitular Titular { get; set; }

        public long TarjetaDeCreditoId { get; set; }
        public TarjetaDeCredito TarjetaDeCredito { get; set; }

        public long PuntoDeVentaId { get; set; }
        public virtual PuntosEmisionTarjetas PuntoDeVenta { get; set; }

        public string ServicioEstatal { get; set; }
        public string Observacion { get; set; }

        #endregion

        #region Propiedades Foto / Firma

        public virtual Foto Foto { get; set; }
        public virtual Firma Firma { get; set; }

        #endregion

        #region Consentimientos

        public bool AceptaRecibirEstadoCuentaEnCorreoElectronico { get; set; }

        #endregion

        #region Propiedades Calculadas

        public bool TarjetaDeCreditoAsignada
        {
            get
            {
                return (this.TarjetaDeCredito != null);
            }
        }

        #endregion

        #region Métodos Públicos

        public void AsignarTarjetaDeCredito(TarjetaDeCredito tarjeta)
        {
            if (this.EstadoSolicitud == EstadoDeSolicitud.EnGeneracionTarjetaDeCredito)
            {
                this.TarjetaDeCredito = tarjeta;
                this.EstadoSolicitud = EstadoDeSolicitud.EnImpresionTarjetaDeCredito;
            }
            else
            {
                throw new Exception("EstadoSolicitudInvalidoException");
            }
        }

        public void DeshacerAsignacionTarjetaDeCredito()
        {
            if (this.EstadoSolicitud == EstadoDeSolicitud.EnImpresionTarjetaDeCredito && this.TarjetaDeCredito.EstadoTarjeta == EstadoTarjetaCredito.Nuevo)
            {
                this.TarjetaDeCredito = null;
                this.EstadoSolicitud = EstadoDeSolicitud.EnGeneracionTarjetaDeCredito;
            }
            else
            {
                throw new Exception("EstadoSolicitudInvalidoException");
            }
        }

        public bool VerificarTarjetaDeCredito(string numero)
        {
            if (this.TarjetaDeCredito != null)
            {
                if (this.TarjetaDeCredito.Numero == numero)
                {
                    this.TarjetaDeCredito.EstadoTarjeta = EstadoTarjetaCredito.Asignado;
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}