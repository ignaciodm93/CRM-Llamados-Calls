using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class LlamadosDestinatariosModel
    {


        public LlamadosDestinatarios LlamadosDestinatarios { get; set; }

        public List<LlamadosDestinatarios> ListarLlamadosDestinatarios { get; set; } = new List<LlamadosDestinatarios>();

        //

            //Listas que no estoy complemtanete seguro si  las voy a usar, chequear como funciona este controlador, que funcion posee
        public List<Usuarios> ListarUsuarios { get; set; } = new List<Usuarios>();

        public List<Llamados> ListarLlamados { get; set; } = new List<Llamados>();



    }
}