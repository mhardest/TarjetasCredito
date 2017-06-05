using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public class Direccion : EntityBase
    {
        public string _Calle { get; set; }
        public string _Numero { get; set; }
        public string _CodigoPostal { get; set; }
        public string _Piso { get; set; }
        public string _Departamento { get; set; }
        public string _Localidad { get; set; }
        public string _Provincia { get; set; }
        public string _Pais { get; set; }

        public override string ToString()   
        {
            return string.Concat("Calle: ", this._Calle, " - N°: ", this._Numero, " - Localidad: ", this._Localidad, "Provincia: ", this._Provincia);
        }
    }
}