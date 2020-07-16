using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class MotivosLlamadoModel
    {

        public MotivosLlamado MotivoLlamado { get; set; }

        public List<MotivosLlamado> ListaMotivos { get; set; } = new List<MotivosLlamado>();

        //Lista de prueba
        public List<Llamados> ListaLlamados { get; set; } = new List<Llamados>();

    }
}