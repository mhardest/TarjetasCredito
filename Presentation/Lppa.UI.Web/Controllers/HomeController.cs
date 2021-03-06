﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lppa.UI.Process;
using Lppa.Entities.Domain;


namespace Lppa.UI.Web.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AltaSolicitud()
        {
            ViewBag.Message = "Alta de Tarjetas.";

            return View();
        }
        

     
        public ActionResult DatosAdicionales()
        {
            ViewBag.Message = "Datos Adicionales.";

            return View();
        }
        
        public ActionResult TarjetaAdicional()
        {
            ViewBag.Message = "Alta Tarjeta Adicional.";

            return View();
        }
    }
}