using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class PuntosEmisionTarjetas : EntityBase
    {
        public string CodigoReferencia { get; set; }
        public virtual Direccion Direccion { get; set; }
        public Telefono Telefono { get; set; }
        public string Mail { get; set; }
    }
}
