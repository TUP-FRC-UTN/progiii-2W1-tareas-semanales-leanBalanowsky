﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploPersona.Models
{
    public class Persona
    {
        private int id;
        [Required]
        private string nombre;
        [Required]
        private string apellido;
        [Required]
        private int dni;
        [Required]
        private int edad;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}