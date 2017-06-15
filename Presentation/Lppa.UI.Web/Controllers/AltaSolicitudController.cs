using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lppa.Entities.Domain;
using Lppa.UI.Process;

namespace Lppa.UI.Web.Controllers
{
    public class AltaSolicitudController : Controller
    {

        private ProcessSolicitud PSol = new ProcessSolicitud();
        // GET: AltaSolicitud
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Solicitud solicitud)

        {
            solicitud.Titular.Apellido = Request.Form.Get("nombre");
            PSol.Create(solicitud);
            return RedirectToAction("Index");
        }

    }
}