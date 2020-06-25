using EjemploPersona.AccesoDatos;
using EjemploPersona.Models;
using EjemploPersona.ViewModel;
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
            List<SexoItemVM> listaSexos = AD_Persona.obtenerListaSexos();

            List<SelectListItem> lista = listaSexos.ConvertAll(s =>
            {
                return new SelectListItem()
                {
                    Text = s.Nombre,
                    Value = s.IdSexo.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = lista;
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
        public ActionResult DatosPersona(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Persona.obtenerListaSexos();

            List<SelectListItem> lista = listaSexos.ConvertAll(s =>
            {
                return new SelectListItem()
                {
                    Text = s.Nombre,
                    Value = s.IdSexo.ToString(),
                    Selected = false
                };
            });

            Persona resultado = AD_Persona.ObtenerPersona(idPersona);

            foreach (var item in lista)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                }
            }
            ViewBag.items = lista;

            ViewBag.Nombre = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult DatosPersona(Persona model)
        {

            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.Actualizar(model);
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
        public ActionResult EliminarPersona(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Persona.obtenerListaSexos();

            List<SelectListItem> lista = listaSexos.ConvertAll(s =>
            {
                return new SelectListItem()
                {
                    Text = s.Nombre,
                    Value = s.IdSexo.ToString(),
                    Selected = false
                };
            });

            Persona resultado = AD_Persona.ObtenerPersona(idPersona);

            foreach (var item in lista)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                }
            }
            ViewBag.items = lista;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {

            if (ModelState.IsValid)
            {
                bool resultado = AD_Persona.Eliminar(model);
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

    }
}