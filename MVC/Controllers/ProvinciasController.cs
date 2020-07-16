using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDADES;
using NEGOCIOS;


using MVC.Models;

namespace MVC.Controllers
{
    public class ProvinciasController : Controller
    {

        ProvinciasBL objNeg = new ProvinciasBL();




        // GET: Provincias
        public ActionResult Index()
        {
            ProvinciasModel Modelo = new ProvinciasModel();
            Modelo.Provincias = new ProvinciasBL().ListarProvincias();

            return View(Modelo);
        }







        // GET: Provincias/Details/5


        public ActionResult GetProvincia(int id)
        {
            PaisesBL paiNeg = new PaisesBL();
            ProvinciasModel Modelo = new ProvinciasModel();

            Modelo.Provincia = new ProvinciasBL().GetProvincia(id);
            Modelo.country = paiNeg.ListarPaises();

            return View(Modelo);
        }





        public ActionResult Crear()
        {

            //Declaracion de capa de negocios (Necesitaremos las ciudades)
            PaisesBL paiNeg = new PaisesBL();

            //Declaracion del Modelo de MVC
            ProvinciasModel moodelo = new ProvinciasModel();

            //Accedemos 
            moodelo.country = paiNeg.ListarPaises();

            return View(moodelo);
            //
            //Hasta aca, la vista esta perfecta. Se replican adecuadamente los paises.
        }



        [HttpPost]
        public ActionResult Crear(ProvinciasModel provi) //Clase Modelo de MVC
        {

           

            try
            {
                if (provi.Provincia.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, debe ingresar un nombre");
                    return View(provi);
                }

               

                objNeg.Agregar(provi.Provincia);
                //La propiedad provi.Provincia es la que acabo de declarar que me dijiste vos en el Model de MVC

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "La Provincia ya esta en la base de datos");
                return View(provi);
            }




        }





        // GET: Provincias/Edit/5
        public ActionResult Editar(int id) //W GB
        {
            PaisesBL paiNeg = new PaisesBL();
            ProvinciasModel Modelo = new ProvinciasModel();

            Modelo.Provincia = new ProvinciasBL().GetProvincia(id);
            Modelo.country = paiNeg.ListarPaises();

            return View(Modelo);
           
        }



        // POST: Provincias/Edit/5
        [HttpPost]
        public ActionResult Editar(ProvinciasModel provincias) //W GB
        {
            try
            {


                if (provincias.Provincia.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, debe ingresar un nombre");
                    return View(provincias);
                }


                ProvinciasBL objPro = new ProvinciasBL();
                objPro.Editar(provincias.Provincia);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Ocurrio un error al intentar modificar una provincia", ex.Message);
                throw;
            }


            return RedirectToAction("Index");
        }


       


        // GET: Provincias/Delete/5
        public ActionResult Eliminar(int? id)
        {
            PaisesBL paiNeg = new PaisesBL();
            ProvinciasModel Modelo = new ProvinciasModel();

            Modelo.Provincia = new ProvinciasBL().GetProvincia(id.Value);
            Modelo.country = paiNeg.ListarPaises();

            return View(Modelo);
        }


        // POST: Provincias/Delete/5
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                objNeg.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }



      







    }
}
