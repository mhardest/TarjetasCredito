using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class ClienteTitular : Persona
    {
        #region Titular

        public virtual IList<TarjetaDeCredito> TarjetasDeCreditos { get; set; }
        public virtual IList<ClienteExtension> TarjetasDeCreditosAdicionales { get; set; }
        public virtual IList<CuentaBancaria> CuentasBancarias { get; set; }

        #endregion

        #region Conyuge

        public string DNIConyuge { get; set; }
        public string NombreConyuge { get; set; }
        public string ApellidoConyuge { get; set; }

        #endregion


    }
}