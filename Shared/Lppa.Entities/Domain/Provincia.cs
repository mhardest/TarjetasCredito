using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Provincia : EntityBase
    {
        public string _Nombre { get; set; }
        public long _PaisId { get; set; }
        public virtual Pais _Pais { get; set; }
        public virtual IList<Localidad> _Localidades { get; set; }

        public override string ToString()
        {
            return this._Nombre;
        }
    }
}