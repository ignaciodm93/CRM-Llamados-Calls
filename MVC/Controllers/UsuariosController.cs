using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NEGOCIOS;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            UsuariosBL bao = new UsuariosBL();
            UsuariosModel Modelo = new UsuariosModel();

            Modelo.ListarUsuarios = bao.ListarUsuarios();

            return View(Modelo);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            UsuariosBL bao = new UsuariosBL();
            UsuariosModel Modelo = new UsuariosModel();

            Modelo.Usuario = bao.ObtenerDetalles(id);

            return View(Modelo);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            UsuariosBL bao = new UsuariosBL();
            UsuariosModel Modelo = new UsuariosModel();

            return View(Modelo);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(UsuariosModel Modelo)
        {
            try
            {
                //validaciones acao en la capa de negocios
                if (Modelo.Usuario.Nombre.Count() > 12)
                {
                    ModelState.AddModelError("", "El nombre debe tener menos de 12 caracteres");
                }

                UsuariosBL bao = new UsuariosBL();
                

                bao.Agregar(Modelo.Usuario);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            UsuariosBL bao = new UsuariosBL();
            UsuariosModel Modelo = new UsuariosModel();
            Modelo.Usuario = bao.ObtenerDetalles(id);

            return View(Modelo);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuariosModel usuarioNuevo) //No me funciona el Edit, me quede aca!
        {
            try
            {
                //posibles validaciones aca o en la bl
                UsuariosBL bao = new UsuariosBL();
                


                bao.Editar(usuarioNuevo.Usuario);

                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Surgio un error de tipo catch");

                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            UsuariosBL bao = new UsuariosBL();
            UsuariosModel Modelo = new UsuariosModel();
            Modelo.Usuario = bao.ObtenerDetalles(id.Value);

            return View(Modelo);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                UsuariosBL bao = new UsuariosBL();

                bao.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
