using EjemploPersona.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploPersona.ViewModel.Reportes
{
    public class reporteGralVM
    {
        private List<SexoItemVM> listaSexo;
        private List<PersonaItemVM> listaPersonas;

        public List<SexoItemVM> ListaSexo { get => listaSexo; set => listaSexo = value; }
        public List<PersonaItemVM> ListaPersonas { get => listaPersonas; set => listaPersonas = value; }

        public reporteGralVM()
        {
            listaSexo = new List<SexoItemVM>();
            ListaPersonas = new List<PersonaItemVM>();
            cargarVariables();
        }
        private void cargarVariables()
        {
            listaSexo = Ad_Reporte.obtenerCantidadPorSexoa();
            listaPersonas = Ad_Reporte.obtenerListaPersona();
        }

    }
}