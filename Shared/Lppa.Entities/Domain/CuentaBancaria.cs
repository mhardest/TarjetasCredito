using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class CuentaBancaria : EntityBase
    {
        public long _TitularId { get; set; }
        public virtual ClienteTitular _Titular { get; set; }    

        public string _Banco { get; set; }
        public string _CuentaCorriente { get; set; }
        public string _CuentaDeAhorro { get; set; }
    }
}
