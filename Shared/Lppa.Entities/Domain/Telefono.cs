using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Telefono
    {
        public int _CodigoArea { get; set; }
        public long _Numero { get; set; }

        public override string ToString()
        {
            if (this._CodigoArea > 0)
            {
                return string.Format("{0}-{1}", this._CodigoArea, this._Numero);
            }
            return this._Numero.ToString();
        }
    }
}