using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEGOCIOS;
using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.Controllers
{
    public class ClientsController : Controller
    {

        // GET: Clients
        public ActionResult Index()
        {
            ClientesModel modelo = new ClientesModel();
            modelo.ListaClientes = new ClientesBL().ListarClientes();




            return View(modelo);
        }



        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            ClientesModel Modelo = new ClientesModel();
            ClientesBL ClientesBao = new ClientesBL();
            //Para esto hice un metodo porque quiero devolver el pais, y esta tabla tiene 3 tablas entre medio con Clientes.
            Modelo.Cliente = ClientesBao.ObtenerDetalles(id);
            Modelo.Pais = ClientesBao.DevolverPais(id);


            ClientesDireccionesBL ClientesDireccionesBao = new ClientesDireccionesBL();
            Modelo.ListaDirecciones = ClientesDireccionesBao.ListarDireciones();


            MailsBL BaoMails = new MailsBL();
            Modelo.Cliente.Mails = BaoMails.ListaMails().Where(m => m.ClienteId == id).ToList();


            return View(Modelo);
        }







        // GET: Clients/Create
        public ActionResult Create()
        {
            ClientesModel Modelo = new ClientesModel();

            Modelo.ListaRubros = new RubrosBL().ListarRubros();

            CiudadesBL BaoCiudades = new CiudadesBL();
            Modelo.ListaCiudades = BaoCiudades.ListarCiudades();

            FuentesContactosBL BaoFuentesContactos = new FuentesContactosBL();
            Modelo.ListaFuentes = BaoFuentesContactos.ListaFuentes();
       

            return View(Modelo);
        }





        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(ClientesModel clienteNuevo)  //Para agregar/crear nos vamos a manejar con un solo registro de los que no sean tan imperativos, luego lo trabajamos desde el edit.
        {
            try
            {
                if (
                    clienteNuevo.Cliente.Nombre == null ||
                    clienteNuevo.Cliente.Apellido == null ||
                    clienteNuevo.Cliente.RubroId == null ||
                    clienteNuevo.Cliente.FechaNacimiento == null
                    )
                {
                    ModelState.AddModelError("", "Llene todos los campos adecuadamente.");
                }

                //Paso los datos al Modelo base
                if (clienteNuevo.FuentesSeleccionadas != null)
                {
                    foreach (var item in clienteNuevo.FuentesSeleccionadas)
                    {

                        clienteNuevo.Cliente.ClientesFuentesContacto.Add(new ENTIDADES.ClientesFuentesContacto()
                        {
                            ClienteId = clienteNuevo.Cliente.Id,
                            FuenteContactoId = item
                        });

                    }
                    //Esto funciona, ahora la pregunta es por que no me  lo guarda directamente desde la vista? Tal vez porque en client.Cliente.ClientesFuentesContacto es una lista comun?
                }

                if (clienteNuevo.Direccion != null) //eventualmente voy a tener que crear una lista de direcciones para guardar mas de una
                {
                    clienteNuevo.Cliente.ClientesDirecciones.Add(clienteNuevo.Direccion);
                }


                //Todos estos ifs despues voy a tenerque cambiarlos por algo que tome listas del controlador probablemente
                if (clienteNuevo.ClienteTelefono != null)
                {
                    clienteNuevo.Cliente.ClientesTelefonos.Add(clienteNuevo.ClienteTelefono);
                }


                
                if (clienteNuevo.ClienteMail != null)
                {
                    clienteNuevo.Cliente.Mails.Add(clienteNuevo.ClienteMail);
                }


                //aseguremonos de que esta todo siendo filtrado al clienteNuevo.Cliente
                ClientesBL BaoClientes = new ClientesBL();
                BaoClientes.Agregar(clienteNuevo.Cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Ha surgido un imprevisto, revise la logica de la aplicacion", ex);
                return View(clienteNuevo);
            }
        }





        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            ClientesModel Modelo = new ClientesModel();
            ClientesBL BaoClientes = new ClientesBL();

            Modelo.Cliente = BaoClientes.ObtenerDetalles(id);
            Modelo.ListaClientes = new ClientesBL().ListarClientes();
            Modelo.ListaRubros = new RubrosBL().ListarRubros();
       
            ClientesTelefonosBL BaoClientesTelefonos = new ClientesTelefonosBL();
            Modelo.Agenda = BaoClientesTelefonos.ListarTelefonos().Where(m => m.ClienteId == id).ToList(); 

            FuentesContactosBL BaoFuentesContactos = new FuentesContactosBL();
            Modelo.ListaFuentes = BaoFuentesContactos.ListaFuentes();
        
            MailsBL BaoMails = new MailsBL();
            Modelo.EmailsEditados = BaoMails.ListaMails().Where(m => m.ClienteId == id).ToList();

            CiudadesBL BaoCiudades = new CiudadesBL();
            Modelo.ListaCiudades = BaoCiudades.ListarCiudades();

            RubrosBL BaoRubros = new RubrosBL();
            Modelo.Domicilios = Modelo.Cliente.ClientesDirecciones.ToList();  

            return View(Modelo);
        }




        // POST: Clients/Edit/5 //Y si pruebo usando una lsita de mails desde la capa mails?
        [HttpPost]
        public ActionResult Edit(ClientesModel client)
        {
            try
            {
                if (
                    client.Cliente.Nombre == null ||
                    client.Cliente.Apellido == null ||
                    client.Cliente.RubroId == null ||
                    client.Cliente.FechaNacimiento == null
                    )
                {
                    ModelState.AddModelError("", "Para realizar los cambios no pueden haber campos vacíos.");
                }

                ClientesBL BaoClientes = new ClientesBL();
                MailsBL BaoMails = new MailsBL();

                //vamos a tratar de pasarlos como client.Cliente.ClientesFuentesCOntactos asi puedo eliminar un campo del model (obviamente para poder ahcer esto, si logro hacer esto aca voy a tner que replicarlo en el create porque lo tengo qhecho de la otra forma)
                //quiero pasar los datos de fuentesSelected al client.Cliente asi envio menos cosas a la bl. Aunque tal vez valg la pena dejarlo como esta. Pero si cambiar los nombres para que sean mas legibles

                if (client.FuentesSeleccionadas != null)//CHEQUEAR PORQUE PENSE QUE LO ESTABA HACIENDOEN CREAR, NO SE SI ESTO ESTA BIEN
                {
                    foreach (var item in client.FuentesSeleccionadas)
                    {

                        client.Cliente.ClientesFuentesContacto.Add(new ENTIDADES.ClientesFuentesContacto()
                        {
                            ClienteId = client.Cliente.Id,
                            FuenteContactoId = item
                        });

                    }                 
                }
                /*
                 Tengo que probar ahora que pasa si mando los datos sacando el parametro de fuentesSelected que se envia al bl, tambien tengo que modificar lo que sehace en el  DAL!! Si no funciona, borro esto y me quedo con el parametro que ya estoy enviando a parte de client
                 */




                //Paso los datos que se guardan en el modelo a la entidad asi puedo mandarlos al bl (esto seguramente peude simplificarse)
                if (client.Direccion.Calle != null || client.Direccion.Altura == null)   //Si tengo algo guardado en Direccion (individual nuevo)
                {
                    client.Cliente.ClientesDirecciones.Add(client.Direccion);
                }

                if (client.Domicilios != null)
                {
                    foreach (var antiguosRegistrosEditados in client.Domicilios)
                    {
                        client.Cliente.ClientesDirecciones.Add(antiguosRegistrosEditados);
                    }
                }

                //Mails
                //Filtro si estan llenos alguno de los dos campos, EmailsEditados o ClienteMail.Mail y los acomodo para poder enviarlos al BL.
                if (client.ClienteMail.Mail != null)
                {
                    client.Cliente.Mails.Add(client.ClienteMail);
                }
                if (client.EmailsEditados != null)
                {
                    foreach (var item in client.EmailsEditados)
                    {
                        client.Cliente.Mails.Add(item);
                    }
                }



                //Telefonos: Paso los resultados guardados de Agenda a client.Cliente.ClienteTelefonos
                if (client.Agenda != null)
                {              
                    foreach (var telefono in client.Agenda)
                    {
                        client.Cliente.ClientesTelefonos.Add(telefono);
                    }
                }

                if (client.ClienteTelefono.Telefono != null)
                {
                    client.Cliente.ClientesTelefonos.Add(client.ClienteTelefono);         
                }
               


                BaoClientes.Editar(client.Cliente, client.FuentesSeleccionadas);

                return RedirectToAction("Index");
            }
            catch (Exception ex)    //El error esta en clientesDirecciones -> ciudades
            {
                ModelState.AddModelError("", "Ha surgido un imprevisto, revise la logica de la aplicacion");
                return View(client);
            }


        }




        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            ClientesModel modelo = new ClientesModel();
            ClientesBL objCli = new ClientesBL();

            modelo.Cliente = objCli.ObtenerDetalles(id.Value);
            modelo.ListaClientes = new ClientesBL().ListarClientes();
            modelo.ListaRubros = new RubrosBL().ListarRubros();





            return View(modelo);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ClientesBL objNeg = new ClientesBL();

                objNeg.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Surgió un imprevisto al intentar borrar el registro del cliente");
                return View();
            }
        }








    }
}
