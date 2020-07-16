using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENTIDADES;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ProvinciasModel
    {


        //Propiedad adicional GERI NO TOCAR
        public List<Paises> country { get; set; } = new List<Paises>();

        public  Provincias Provincia { get; set; }


        //PARA el index
        public List<Provincias> Provincias { get; set; } = new List<Provincias>();
        //

    }
}