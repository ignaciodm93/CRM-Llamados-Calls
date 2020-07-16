using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENTIDADES;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ClientesModel
    {

        public Clientes Cliente { get; set; }



        public List<Rubros> ListaRubros { get; set; } = new List<Rubros>();

        public List<Clientes> ListaClientes { get; set; } = new List<Clientes>();

        public List<Mails> ListaMails { get; set; } = new List<Mails>();    //ya esta usada para algo, que no se que es, calculo que detalles, tal vez no. Ahora voy a usarla para pasar los datos que edite y guarde desde editar al contorlador para la capa bl.

        public List<ClientesDirecciones> ListaDirecciones { get; set; } = new List<ClientesDirecciones>();

        public List<Ciudades> ListaCiudades { get; set; } = new List<Ciudades>(); 

        
     
        

        public IEnumerable<byte> FuentesSeleccionadas { get; set; }
        public List<FuentesContacto> ListaFuentes { get; set; } = new List<FuentesContacto>();


        public ClientesDirecciones Direccion { get; set; } = new ClientesDirecciones(); //usando en crear y edit para crear un campo nuevo. En edit es usado para crear el campo adicional a los ya existentes.
        public IList<ClientesDirecciones> Domicilios { get; set; }   //Funciona, lo use en edit para mostrar y editar todos los registros acutales (si los hay)        


        public Mails ClienteMail { get; set; }  //works crear
        public IList<Mails> EmailsEditados { get; set; }  //Usandolo en el Edit para pasar los datos editados de los mails


        public ClientesTelefonos ClienteTelefono { get; set; } //usandolo en Crear y Editar
        public IList<ClientesTelefonos> Agenda { get; set; }    //usado para en editar mostrar los resultados ya registrados con el for. Eventualmente, cambiar el nombre a algo mas facil de entender.


        public Paises Pais { get; set; } //Lo uso en detalles, porque quiero citar el pais al que pertenece la direccion, pero tengo varias tablas en el medio, asi que uso un metodo.
        

    }
}