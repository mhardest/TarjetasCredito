using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain  
{
    public class EstadoCivil : EntityBase
    {
        public string _Descripcion { get; set; }

        public override string ToString()
        {
            return this._Descripcion;
        }
    }
}
