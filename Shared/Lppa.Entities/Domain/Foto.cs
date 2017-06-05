using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Foto : EntityBase
    {
        public long _SolicitudId { get; set; }
        public virtual Solicitud Solicitud { get; set; }

        public byte[] Imagen { get; set; }
    }
}