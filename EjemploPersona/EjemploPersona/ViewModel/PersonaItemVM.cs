using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploPersona.ViewModel
{
    public class PersonaItemVM
    {
        private int id;
        
        private string nombre;
        private string apellido;
        private int dni;
        private int edad;
        private string nombreSexo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
        public string NombreSexo { get => nombreSexo; set => nombreSexo = value; }
    }
}