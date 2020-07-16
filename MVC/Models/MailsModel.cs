using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ENTIDADES;

namespace MVC.Models
{
    public class MailsModel
    {

        public Mails Mails { get; set; }

        public List<Mails> MailsLista { get; set; } = new List<Mails>();


        //Propiedad adicional

        public List<Clientes> ClientesLista { get; set; } = new List<Clientes>();

    }
}