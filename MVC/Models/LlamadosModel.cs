using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using ENTIDADES;
using System.Web.Mvc;

namespace MVC.Models
{
    public class LlamadosModel
    {

        public Llamados Llamado { get; set; }

        public List<Llamados> ListaLlamados { get; set; } = new List<Llamados>();
        public List<Clientes> ListaClientes { get; set; } = new List<Clientes>();  
  
        public List<Usuarios> ListaUsuarios { get; set; } = new List<Usuarios>();
        public List<Usuarios> UsuariosDestinatariosCoincidentes { get; set; } = new List<Usuarios>(); //USANDOLO EN DETALLES Para mostrar los destinatarios registrados


        public List<LlamadosDestinatarios> ListaDestinatarios { get; set; } = new List<LlamadosDestinatarios>();
 
        public IEnumerable<byte> DestinatariosSeleccionados { get; set; }       
        public IEnumerable<byte> MotivosSeleccionados { get; set; } //Usandolo en vistas Editar y Crear y sus metodos en el controlador.


        public List<MotivosLlamado> ListaMotivos { get; set; } = new List<MotivosLlamado>();// Usandolo en Editar tambien
        public List<MotivosLlamado> MotivosCoincidentes { get; set; } = new List<MotivosLlamado>(); // Usandolo en Edit y Details






    }
}