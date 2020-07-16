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
    public class RubrosController : Controller
    {

      

        //PROBAR ARMAR CON EL MODEL ACA AFUERA

        // GET: Rubros
        public ActionResult Index()
        {
            RubrosModel Modelo = new RubrosModel();
            RubrosBL objNeg = new RubrosBL();

            Modelo.rubros = objNeg.ListarRubros();
            return View(Modelo);
        }
        //VISTA INDEX LISTA, HAY QUE SEGUIR CON DETALLES, Y UA VEZ TERINADAS TODAS, RETOMAR CLIENTES CREAR, PARA PODER REPLICAR EL DROPDOWN LIST DE RUBROS AL CREAR UN CLIENTE


        // GET: Rubros/Details/5
        public ActionResult Details(int id)
        {
            RubrosModel Modelo = new RubrosModel();
            RubrosBL objNeg = new RubrosBL();

            Modelo.Rubro = objNeg.GetRubros(id);
            return View(Modelo);
        }

        // GET: Rubros/Create
        public ActionResult Create()
        {
            RubrosModel Modelo = new RubrosModel();
            Modelo.Rubro = new Rubros();


            return View(Modelo);
        }

        // POST: Rubros/Create
        [HttpPost]
        public ActionResult Create(RubrosModel rub)
        {
            RubrosBL objNeg = new RubrosBL();

            try
            {
                if (rub.Rubro.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, debe ingresar un nombre");
                    return View(rub);
                }

                objNeg.Crear(rub.Rubro);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Ocurrio un error al intentar agregar un rubro", ex.Message);          
                return View(rub);
            }
        }

        // GET: Rubros/Edit/5
        public ActionResult Edit(int id) //WORKS
        {

            RubrosModel Modelo = new RubrosModel();
           

            Modelo.Rubro = new RubrosBL().GetRubros(id);
            

            return View(Modelo);


        }


        //SEGUIR ACA

        // POST: Rubros/Edit/5
        [HttpPost]
        public ActionResult Edit(RubrosModel rub)
        {
           

            try
            {
                RubrosBL objNeg = new RubrosBL();
                if (rub.Rubro.Nombre == null)
                {
                    ModelState.AddModelError("", "Error, el nombre no puede estar vacio");
                    return View(rub);
                }

                objNeg.Editar(rub.Rubro);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Ocurrio un error al intentar modificar un rubro", ex.Message);
                return View();
            }
        }



        // GET: Rubros/Delete/5
        public ActionResult Delete(int? id)
        {
            RubrosModel Modelo = new RubrosModel();
            RubrosBL objNeg = new RubrosBL();

            Modelo.Rubro = objNeg.GetRubros(id.Value);
            return View(Modelo);
        }

        // POST: Rubros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {
                RubrosBL objNeg = new RubrosBL();
                objNeg.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Ocurrio un error al intentar eliminar el rubro.", ex.Message);
                return View();
            }
        }


    
    }
}
