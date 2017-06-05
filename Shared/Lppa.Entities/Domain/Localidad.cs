using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Localidad : EntityBase
    {
        public string _Nombre { get; set; }
        public long _ProvinciaId { get; set; }

        public virtual Provincia _Provincia { get; set; }

        public override string ToString()
        {
            return this._Nombre;    
        }
    }
}