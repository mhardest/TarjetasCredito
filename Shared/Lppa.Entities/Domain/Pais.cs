using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Pais : EntityBase
    {
        public string _Nombre { get; set; }
        public virtual IList<Provincia> _Provincias { get; set; }

        public override string ToString()
        {
            return this._Nombre;
        }
    }
}