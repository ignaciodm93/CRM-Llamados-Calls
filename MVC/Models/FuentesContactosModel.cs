using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class FuentesContactosModel
    {

        public FuentesContacto FuentesContactos { get; set; }


        public List<FuentesContacto> ListaFuentesContactos { get; set; } = new List<FuentesContacto>();

    }
}