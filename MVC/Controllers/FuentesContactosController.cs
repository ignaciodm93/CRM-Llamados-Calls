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
    public class FuentesContactosController : Controller
    {
        // GET: FuentesContactos
        public ActionResult Index()
        {
            FuentesContactosBL bao = new FuentesContactosBL();
            FuentesContactosModel Modelo = new FuentesContactosModel();
            Modelo.ListaFuentesContactos = bao.ListaFuentes();
            return View(Modelo);
        }

        // GET: FuentesContactos/Details/5
        public ActionResult Details(int id) { 
            FuentesContactosBL bao = new FuentesContactosBL();
            FuentesContactosModel Modelo = new FuentesContactosModel();

            Modelo.FuentesContactos = bao.Details(id);

            return View(Modelo);
        }

        // GET: FuentesContactos/Create
        public ActionResult Create()
        {

            
            FuentesContactosModel Modelo = new FuentesContactosModel();

            

            return View(Modelo);
        }

        // POST: FuentesContactos/Create
        [HttpPost]
        public ActionResult Create(FuentesContactosModel fuenteNueva)
        {
            try
            {
                if (fuenteNueva.FuentesContactos.Nombre == null)
                {
                    ModelState.AddModelError("", "Agregue un nombre");
                }

                FuentesContactosModel Modelo = new FuentesContactosModel();
                FuentesContactosBL bao = new FuentesContactosBL();

                bao.Create(fuenteNueva.FuentesContactos);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "surgio un error de tipo catch");
                return View();
            }
        }

        // GET: FuentesContactos/Edit/5
        public ActionResult Edit(int id)    
        {
            FuentesContactosModel Modelo = new FuentesContactosModel();
            FuentesContactosBL bao = new FuentesContactosBL();

            Modelo.FuentesContactos = bao.Details(id);

            return View(Modelo);
        }

        // POST: FuentesContactos/Edit/5
        [HttpPost]
        public ActionResult Edit(FuentesContactosModel fuenteNueva)
        {
            try
            {
                if (fuenteNueva.FuentesContactos.Nombre == null)
                {
                    ModelState.AddModelError("", "Ingrese un nombre");
                }

                FuentesContactosModel Modelo = new FuentesContactosModel();
                FuentesContactosBL bao = new FuentesContactosBL();

                bao.Editar(fuenteNueva.FuentesContactos);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FuentesContactos/Delete/5
        public ActionResult Delete(int? id)
        {
            FuentesContactosModel Modelo = new FuentesContactosModel();
            FuentesContactosBL bao = new FuentesContactosBL();

            Modelo.FuentesContactos = bao.Details(id.Value);

            return View(Modelo);
        }

        // POST: FuentesContactos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                FuentesContactosModel Modelo = new FuentesContactosModel();
                FuentesContactosBL bao = new FuentesContactosBL();

                bao.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Surgio un error de tipo catch.");
                return View();
            }
        }
    }
}
