using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Entities.Domain;
using Lppa.Data.Clases;
namespace Lppa.Business
{
   public class BLLSolicitud
    {
        private DALSolicitud DALSol = new DALSolicitud();
        public void Create (Solicitud solicitud){

            DALSol.Create(solicitud);


        }
    }
}
