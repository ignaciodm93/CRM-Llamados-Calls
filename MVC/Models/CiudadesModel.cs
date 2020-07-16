using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENTIDADES;

namespace MVC.Models
{
    public class CiudadesModel
    {
        //Entidad ciudad
        public Ciudades Ciudad { get; set; }

        //Lista de Ciudades
        public List<Ciudades> Ciudades { get; set; }

        //Lista de Provincias
        public List<Provincias> provinces { get; set; } = new List<Provincias>();

        //Lista de Paises
        public List<Paises> countries { get; set; } = new List<Paises>();
    }
}