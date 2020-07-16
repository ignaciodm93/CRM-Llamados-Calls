using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class UsuariosModel
    {


        public Usuarios Usuario { get; set; }

        public List<Usuarios> ListarUsuarios { get; set; } = new List<Usuarios>();

        //creo que no hace falta nada mas, porque no tienemas FKs


    }
}