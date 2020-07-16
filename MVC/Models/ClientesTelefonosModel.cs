using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class ClientesTelefonosModel
    {

        public ClientesTelefonos ClientesTels { get; set; }
        
        //Lista de los telefonos para el index
        public List<ClientesTelefonos> CliTelsLista { get; set; }

        //Propiedades adicionales listas (que ya son propiedades individuales de la clase, pero no listadas):

        public List<Clientes> clients { get; set; } = new List<Clientes>();

        public List<Ciudades> cities { get; set; } = new List<Ciudades>();


        public string teleoriginal { get; set; }

        public int clientoriginal { get; set; }
        
    }
}