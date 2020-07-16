using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class ClientesDireccionesModel
    {

        public ClientesDirecciones CliDireccion { get; set; }


        //Listas
        public List<ClientesDirecciones> ListaDirecciones { get; set; } = new List<ClientesDirecciones>();


        
        public List<Ciudades> Cities { get; set; } = new List<Ciudades>();

        public List<Clientes> ListaClientes { get; set; } = new List<Clientes>();

      
       

    }
}