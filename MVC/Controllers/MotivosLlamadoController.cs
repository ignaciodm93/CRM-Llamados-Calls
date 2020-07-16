using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NEGOCIOS;
using MVC.Models;


namespace MVC.Controllers
{
    public class MotivosLlamadoController : Controller
    {
        // GET: MotivosLlamado
        public ActionResult Index()
        {
            MotivosLlamadoBL bao = new MotivosLlamadoBL();
            MotivosLlamadoModel Modelo = new MotivosLlamadoModel();

            Modelo.ListaMotivos = bao.ListaMotivos();

            return View(Modelo);
        }

        // GET: MotivosLlamado/Details/5
        public ActionResult Details(int id) //seguir aca
        {
            MotivosLlamadoBL bao = new MotivosLlamadoBL();
            MotivosLlamadoModel Modelo = new MotivosLlamadoModel();

            Modelo.MotivoLlamado = bao.ObtenerDetalles(id);

            return View(Modelo);
        }

        // GET: MotivosLlamado/Create
        public ActionResult Create()
        {
            MotivosLlamadoModel Modelo = new MotivosLlamadoModel();
            return View(Modelo);
        }

        // POST: MotivosLlamado/Create
        [HttpPost]
        public ActionResult Create(MotivosLlamadoModel motivoNuevo)
        {
            try
            {
                if (motivoNuevo.MotivoLlamado.Nombre == null)
                {
                    ModelState.AddModelError("", "El campo nombre esta vacio.");
                }

                MotivosLlamadoBL bao = new MotivosLlamadoBL();
                

                bao.Agregar(motivoNuevo.MotivoLlamado);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Surgio un error de tipo catch.");
                return View();
            }
        }

        // GET: MotivosLlamado/Edit/5
        public ActionResult Edit(int id)
        {
            MotivosLlamadoBL bao = new MotivosLlamadoBL();
            MotivosLlamadoModel Modelo = new MotivosLlamadoModel();

            Modelo.MotivoLlamado = bao.ObtenerDetalles(id);

            return View(Modelo);
        }

        // POST: MotivosLlamado/Edit/5
        [HttpPost]
        public ActionResult Edit(MotivosLlamadoModel motivoNuevo)
        {
            try
            {
                if (motivoNuevo.MotivoLlamado.Nombre == null)
                {
                    ModelState.AddModelError("", "El campo nombre no puede estar vacio.");
                }

                MotivosLlamadoBL bao = new MotivosLlamadoBL();
                MotivosLlamadoModel Modelo = new MotivosLlamadoModel();

                bao.Editar(motivoNuevo.MotivoLlamado);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Surgio un error de tipo catch.");
                return View();
            }
        }

        // GET: MotivosLlamado/Delete/5
        public ActionResult Delete(int? id)
        {
            MotivosLlamadoBL bao = new MotivosLlamadoBL();
            MotivosLlamadoModel Modelo = new MotivosLlamadoModel();

            Modelo.MotivoLlamado = bao.ObtenerDetalles(id.Value);

            return View(Modelo);
        }

        // POST: MotivosLlamado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                MotivosLlamadoBL bao = new MotivosLlamadoBL();
                MotivosLlamadoModel Modelo = new MotivosLlamadoModel();

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
