using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using MVC.Models;
using NEGOCIOS;

namespace MVC.Controllers
{
    public class PaisesController : Controller
    {



        PaisesBL objNeg = new PaisesBL();


        // GET: Paises
        public ActionResult Index()
        {

            PaisesModel Modelo = new PaisesModel();
            Modelo.Paises = objNeg.ListarPaises();


            ProvinciasBL ModeloPRO = new ProvinciasBL();
            Modelo.provincies = ModeloPRO.ListarProvincias();

            return View(Modelo);
        }




        public ActionResult GetPais(int id)
        {
            //PaisesBL paiNeg = new PaisesBL();
            PaisesModel Modelo = new PaisesModel();

            Modelo.Pais = objNeg.GetPaises(id);
            //Modelo.country = paiNeg.ListarPaises();

            return View(Modelo);
        }



        public ActionResult Crear()
        {

            //Declaracion de capa de negocios (Necesitaremos las ciudades)
            PaisesBL paiNeg = new PaisesBL();

            //Declaracion del Modelo de MVC
            PaisesModel moodelo = new PaisesModel();

            //Accedemos 
            //moodelo.country = paiNeg.ListarPaises();

            return View(moodelo);
            //
            //Hasta aca, la vista esta perfecta. Se replican adecuadamente los paises.
        }



        [HttpPost]
        public ActionResult Crear(PaisesModel paises) //Clase Modelo de MVC
        {

            try
            {


                if (paises.Pais.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, debe ingresar un nombre");
                    return View(paises);
                }


               


                objNeg.Crear(paises.Pais);
                //La propiedad provi.Provincia es la que acabo de declarar que me dijiste vos en el Model de MVC

                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("Ocurrio un error al intentar agregar una pais, tal vez ya exista", ex.Message);
                ModelState.AddModelError("", "El pais ya esta en la base de datos");
                return View(paises);
            }

        }





        // GET: Provincias/Edit/5
        public ActionResult Editar(int id) //W GB
        {
            //PaisesBL paiNeg = new PaisesBL();
            PaisesModel Modelo = new PaisesModel();

            Modelo.Pais = objNeg.GetPaises(id);
            //Modelo.country = paiNeg.ListarPaises();

            return View(Modelo);

        }



        // POST: Provincias/Edit/5
        [HttpPost]
        public ActionResult Editar(PaisesModel paises) //W GB
        {
            try
            {
                

                if (paises.Pais.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, debe ingresar un nombre");
                    return View(paises);
                }

                    objNeg.Editar(paises.Pais);
                    

            }
            catch (Exception ex)
            {
               
                /*
                 Actualmente el ciclo es este:
                 Evalua si es nulo.
                 Si no es nulo intenta registrarlo.
                 Por alguna razon si el nombre ya esta registrado, entra en el catch el ciclo.
                 Ahora no entiendo como que es que asocia el nombre al Id.
                 */

                MessageBox.Show("En pais ya se enceuntra registrado, no puede dubplicar el registro");
                return View(paises);
            }

            

            return RedirectToAction("Index");
        }




        

        // GET: Provincias/Delete/5
        public ActionResult Eliminar(int? id)
        {
            //PaisesBL paiNeg = new PaisesBL();
            PaisesModel Modelo = new PaisesModel();

            Modelo.Pais = objNeg.GetPaises(id.Value);
            //Modelo.country = paiNeg.ListarPaises();

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