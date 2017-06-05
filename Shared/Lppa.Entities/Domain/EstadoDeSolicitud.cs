using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities.Domain
{
    public enum EstadoDeSolicitud
    {
        Nuevo = 0,
        EnGeneracionTarjetaDeCredito = 1,
        EnImpresionTarjetaDeCredito = 2,
        Cerrado = 3,
        Anulado = 4
    }
}