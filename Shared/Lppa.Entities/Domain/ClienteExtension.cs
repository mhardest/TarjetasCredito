using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class ClienteExtension : Persona
    {
        public long TitularId { get; set; }
        public virtual ClienteTitular Titular { get; set; }

        public long TarjetaDeCreditoId { get; set; }
        public virtual TarjetaDeCredito TarjetaDeCredito { get; set; }
    }
}