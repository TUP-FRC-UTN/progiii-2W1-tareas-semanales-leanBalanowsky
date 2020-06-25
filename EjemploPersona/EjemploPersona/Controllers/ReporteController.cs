using EjemploPersona.ViewModel.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploPersona.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            reporteGralVM resultado = new reporteGralVM();
            return View(resultado);
        }
    }
}