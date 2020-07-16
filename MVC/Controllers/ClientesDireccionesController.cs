using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEGOCIOS;

using MVC.Models;

namespace MVC.Controllers
{
    public class ClientesDireccionesController : Controller
    {


        // GET: ClientesDirecciones
        public ActionResult Index()
        {

            ClientesDireccionesModel Modelo = new ClientesDireccionesModel();
            ClientesDireccionesBL bao = new ClientesDireccionesBL();

            Modelo.ListaDirecciones = bao.ListarDireciones();

            return View(Modelo);




        }

        // GET: ClientesDirecciones/Details/5
        public ActionResult Details(int id)
        {

            ClientesDireccionesModel Modelo = new ClientesDireccionesModel();
            ClientesDireccionesBL bao = new ClientesDireccionesBL();

            Modelo.CliDireccion = bao.GetClientesDirecciones(id);

            return View(Modelo);
        }




        // GET: ClientesDirecciones/Create
        public ActionResult Create()
        {
            //agregar Ciudades para hacer el dropbox
            ClientesDireccionesModel Modelo = new ClientesDireccionesModel();

            CiudadesBL daoCiu = new CiudadesBL();
            ClientesBL ClientesBao = new ClientesBL();


            Modelo.Cities = daoCiu.ListarCiudades();
            Modelo.ListaClientes = ClientesBao.ListarClientes();



            return View(Modelo);
        }



        // POST: ClientesDirecciones/Create
        [HttpPost]
        public ActionResult Create(ClientesDireccionesModel cliDir)
        {
            //EL CREATE YA FUNCIONA!!!!!



            try
            {
                ClientesDireccionesBL bao = new ClientesDireccionesBL();


                if (cliDir.CliDireccion.Calle == null)
                {
                    ModelState.AddModelError("", "Error al guardar un registro");

                }
                else if (cliDir.CliDireccion.Id == 0)
                {
                    ModelState.AddModelError("", "Error con Ciudades");
                }
                else if (cliDir.CliDireccion.Altura == 0)
                {
                    ModelState.AddModelError("", "Error con Ciudades");
                }
                else if (cliDir.CliDireccion.Piso == 0)
                {
                    ModelState.AddModelError("", "Error con Clientes ");
                }

                else if (cliDir.CliDireccion.ClienteId == null)
                {
                    ModelState.AddModelError("", "Error con Cliente Id");
                }
                else if (cliDir.CliDireccion.CiudadId == 0)
                {
                    ModelState.AddModelError("", "Error con Ciudades Id ");
                }
                else
                {
                    ModelState.AddModelError("", "Error ind");


                }

                bao.Agregar(cliDir.CliDireccion);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Surgió un error de tipo catch", ex);
                return View();
            }
        }










      
        public ActionResult Edit(int id)
        {

            CiudadesBL objNeg = new CiudadesBL();
            ClientesDireccionesModel Modelo = new ClientesDireccionesModel();
            

            Modelo.CliDireccion = new ClientesDireccionesBL().GetClientesDirecciones(id);
            Modelo.Cities = objNeg.ListarCiudades();

        

            return View(Modelo);
        }

        // POST: ClientesDirecciones/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientesDireccionesModel cliDir) {


            try
            {
                if (cliDir.CliDireccion.Calle == null) //Y demas validaciones que en realidad van en la capa de negocios
                {
                    ModelState.AddModelError("", "El campo Calle no puede estar vacio");
                }
               

                ClientesDireccionesBL bao = new ClientesDireccionesBL();
                bao.Editar(cliDir.CliDireccion);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Surgio un error de tipo catch", ex);
                return View();
            }
        }






        // GET: ClientesDirecciones/Delete/5
        public ActionResult Delete(int? id)
        {
            ClientesDireccionesModel Modelo = new ClientesDireccionesModel();
            ClientesDireccionesBL bao = new ClientesDireccionesBL();

            Modelo.CliDireccion = bao.GetClientesDirecciones(id.Value);

            return View(Modelo);
        }

        // POST: ClientesDirecciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ClientesDireccionesBL bao = new ClientesDireccionesBL();
                bao.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Ha surgido un error de tipo catch", ex);
                return View();
            }
        }
    }
}
