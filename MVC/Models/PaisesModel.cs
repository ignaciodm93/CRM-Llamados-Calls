using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENTIDADES;

namespace MVC.Models
{
    public class PaisesModel
    {

        public Paises Pais { get; set; }

        public List<Paises> Paises { get; set; }  = new List<Paises>();

        public List<Provincias> provincies { get; set; } = new List<Provincias>();

        public List<Ciudades> cities { get; set; } = new List<Ciudades>();


    }
}