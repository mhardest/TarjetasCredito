using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Entities.Domain;
using Lppa.Business;

namespace Lppa.UI.Process
{
    public class ProcessSolicitud
    {
        private BLLSolicitud BLLSol = new BLLSolicitud();

        public void Create(Solicitud solicitud)
        {
            BLLSol.Create(solicitud);

        }
    }
}
