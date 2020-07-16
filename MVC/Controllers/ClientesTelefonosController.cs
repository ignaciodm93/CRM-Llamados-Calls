using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NEGOCIOS;
using MVC.Models;
using ENTIDADES;

namespace MVC.Controllers
{
    public class ClientesTelefonosController : Controller
    {
        // GET: ClientesTelefonos
        public ActionResult Index()
        {
            
            ClientesTelefonosModel Modelo = new ClientesTelefonosModel();

            ClientesTelefonosBL bao = new ClientesTelefonosBL();
            Modelo.CliTelsLista = bao.ListarTelefonos();
            //Esto es necesario para listar los resultados Telefono de ESTA LISTA Y CLASE

            //TABLAS EXTERNAS a las que accedemos por la fk de su Id:
            ClientesBL cao = new ClientesBL();
            Modelo.clients = cao.ListarClientes();

            CiudadesBL ciao = new CiudadesBL();           
            Modelo.cities = ciao.ListarCiudades();


            return View(Modelo);
        }



        // GET: ClientesTelefonos/Details/5
        public ActionResult Details(int n, int? c)
        {
            ClientesTelefonosBL bao = new ClientesTelefonosBL();
            ClientesTelefonosModel Modelo = new ClientesTelefonosModel();


            ClientesBL clao = new ClientesBL();
            Modelo.clients = clao.ListarClientes();
            CiudadesBL ciao = new CiudadesBL();
            Modelo.cities = ciao.ListarCiudades();


            Modelo.ClientesTels = bao.Detalles(n, c);

          


            return View(Modelo);
        }

        // GET: ClientesTelefonos/Create
        public ActionResult Create()
        {
            
            
            


            ClientesTelefonosModel Modelo = new ClientesTelefonosModel();
            //Modelo.ClientesTels = new ClientesTelefonos();

            ClientesBL cao = new ClientesBL();
            Modelo.clients = cao.ListarClientes();

            CiudadesBL ciao = new CiudadesBL();
            Modelo.cities = ciao.ListarCiudades();

            return View(Modelo);
        }

        // POST: ClientesTelefonos/Create
        [HttpPost]
        public ActionResult Create(ClientesTelefonosModel cliTelefonosModel)
        {
            try
            {
               

                if (cliTelefonosModel.ClientesTels.Telefono == null )
                {
                    ModelState.AddModelError("", "El campo Telefono no puede estar vacio.");
                }

                var bao = new ClientesTelefonosBL();
                bao.Agregar(cliTelefonosModel.ClientesTels );

                return RedirectToAction("Index");
            }

            catch(Exception ex)
            {
                ModelState.AddModelError("Ha surgido un error de tipo catch", ex);
                return View();
            }
        }



        // GET: ClientesTelefonos/Edit/5
        /*public ActionResult Edit(int n)
        {
            ClientesTelefonosBL bao = new ClientesTelefonosBL();
            ClientesTelefonosModel Modelo = new ClientesTelefonosModel();

            CiudadesBL ciao = new CiudadesBL();
            Modelo.cities = ciao.ListarCiudades();

            //Modelo.ClientesTels = bao.Detalles(n);

            return View(Modelo);
        }*/

        public ActionResult Edit(int n, int? c)
        {
            ClientesTelefonosBL bao = new ClientesTelefonosBL();
            ClientesTelefonosModel Modelo = new ClientesTelefonosModel();

            Modelo.ClientesTels = bao.Detalles(n, c.Value);
            Modelo.CliTelsLista = bao.ListarTelefonos();

            ClientesBL clao = new ClientesBL();
            Modelo.clients = clao.ListarClientes();

            CiudadesBL ciao = new CiudadesBL();
            Modelo.cities = ciao.ListarCiudades();


            Modelo.teleoriginal = n.ToString();
            Modelo.clientoriginal = c.Value;
           

            return View(Modelo);
        }






        [HttpPost]
        public ActionResult Edit(ClientesTelefonosModel cliTelMod)
        {
            try
            {
                if (cliTelMod.ClientesTels.Telefono == null)
                {
                    ModelState.AddModelError("", "El campo telefono no puede encontrarse vacio.");
                }             

                ClientesTelefonosBL bao = new ClientesTelefonosBL();
                bao.Editar(cliTelMod.ClientesTels, cliTelMod.teleoriginal, cliTelMod.clientoriginal);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Ha surgido un error de tipo catch.", ex);
                return View();
            }
        }




        // GET: ClientesTelefonos/Delete/5
        public ActionResult Delete(int n, int? c)
        {
            

            ClientesTelefonosBL bao = new ClientesTelefonosBL();
            ClientesTelefonosModel Modelo = new ClientesTelefonosModel();

            //Prueba nueva para almacenar todos los resultados existentes 
            Modelo.CliTelsLista = bao.ListarTelefonos().Where(m => m.ClienteId == c.Value).ToList();


            //ver si lo borro, depende cual use para replicar
            Modelo.ClientesTels = bao.Detalles(n, c.Value); //por ahora este me da nulo
            

            return View(Modelo);
        }



        // POST: ClientesTelefonos/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientesTelefonosModel clitelmod) //Eliminar no funciona
        {
            try
            {
                ClientesTelefonosBL bao = new ClientesTelefonosBL();
                bao.Eliminar(clitelmod.ClientesTels.Telefono);
                
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Ha surgido un error de tipo catch.");
                return View();
            }
        }
    }
}
