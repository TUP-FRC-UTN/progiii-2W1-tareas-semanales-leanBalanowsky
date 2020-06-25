using EjemploPersona.AccesoDatos;
using EjemploPersona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploPersona.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult CargarPersona()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CargarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.Insertar(model);
                if (resultado)
                {
                    return RedirectToAction("ListaPersona", "Persona");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult ListaPersona()
        {
            List<Persona> lista = AD_Persona.obtenerListaPersona();
            return View(lista);
        }
    }
}