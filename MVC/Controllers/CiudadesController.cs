using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NEGOCIOS;
using ENTIDADES;
using MVC.Models;

namespace MVC.Controllers
{
    
    public class CiudadesController : Controller
    {

        //Contexto Negocios
        CiudadesBL negCiu = new CiudadesBL();









        // GET: Ciudades
        public ActionResult Index()
        {
            CiudadesModel modelo = new CiudadesModel();
            modelo.Ciudades = negCiu.ListarCiudades();

            return View(modelo);
        }



        // GET: Ciudades/Details/5
        public ActionResult GetCiudad(int id)
        {
            /*
            PaisesBL paiNeg = new PaisesBL();
            ProvinciasModel modelo = new ProvinciasModel();

            modelo.Provincia = new ProvinciasBL().GetProvincia(id);

            modelo.country = paiNeg.ListarPaises();

            return View(modelo);
            */



            ProvinciasBL proNeg = new ProvinciasBL();
            CiudadesModel modelo = new CiudadesModel();
            PaisesBL paiNeg = new PaisesBL();

            modelo.Ciudad = new CiudadesBL().GetCiudades(id);

            //Listo las provincias
            modelo.provinces = proNeg.ListarProvincias();
            //Listo los paises
            modelo.countries = paiNeg.ListarPaises();

            return View(modelo);

        }


       




        // GET: Ciudades/Create
        public ActionResult Crear()
        {
            ProvinciasBL proNeg = new ProvinciasBL();
            CiudadesModel modelo = new CiudadesModel();
            modelo.Ciudad = new Ciudades();
            modelo.countries = new PaisesBL().ListarPaises();
            modelo.provinces = proNeg.ListarProvincias();

            return View(modelo); 
        }





        // POST: Ciudades/Create
        [HttpPost]
        public ActionResult Crear(CiudadesModel city)
        {
            CiudadesBL negocio = new CiudadesBL();
            negocio.Crear(city.Ciudad);

            return RedirectToAction("Index");
        }




        // GET: Ciudades/Edit/5
        public ActionResult Editar(int id)
        {
            ProvinciasBL proNeg = new ProvinciasBL();
            CiudadesModel modelo = new CiudadesModel();

            modelo.Ciudad = new CiudadesBL().GetCiudades(id);
            modelo.provinces = proNeg.ListarProvincias();

            return View(modelo);

        }

        // POST: Ciudades/Edit/5

        [HttpPost]
        public ActionResult Editar(CiudadesModel city)
        {
            try
            {


                if (city.Ciudad.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, debe ingresar un nombre");
                    return View(city);
                }


                var negocio = new CiudadesBL();
                negocio.Editar(city.Ciudad);



            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Ocurrio un error al intentar modificar una ciudad", ex.Message);
                throw;
            }


            return RedirectToAction("Index");
        }



        // GET: Ciudades/Delete/5
        public ActionResult Eliminar(int? id)
        {
            ProvinciasBL proNeg = new ProvinciasBL();
            CiudadesModel modelo = new CiudadesModel();

            modelo.Ciudad = new CiudadesBL().GetCiudades(id.Value);
            modelo.provinces = proNeg.ListarProvincias();

            return View(modelo);
        }

        // POST: Ciudades/Delete/5
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                negCiu.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
    }
}
