using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC.Models;
using NEGOCIOS;

namespace MVC.Controllers
{
    public class LlamadosController : Controller
    {
        // GET: Llamados
        public ActionResult Index() //Tengo que terminar el index, empece a probar nuevas cosas en la vista.
        {
            LlamadosModel Modelo = new LlamadosModel();

            ClientesBL BaoClientes = new ClientesBL();
            Modelo.ListaClientes = BaoClientes.ListarClientes();

            LlamadosBL BaoLlamados = new LlamadosBL();
            Modelo.ListaLlamados = BaoLlamados.ListaLlamados();

          
          

            return View(Modelo);
        }

        // GET: Llamados/Details/5
        public ActionResult Details(int id)
        {
            LlamadosModel Modelo = new LlamadosModel();
           
            LlamadosBL BaoLlamados = new LlamadosBL();

            Modelo.Llamado = BaoLlamados.ObtenerDetalles(id);
       
            Modelo.UsuariosDestinatariosCoincidentes = BaoLlamados.UsuariosDestinatariosCoincidentes(id);

            //Para mostrar los Motivos que actuales que correspondan al momento de hacer la consulta.
            Modelo.MotivosCoincidentes = BaoLlamados.MotivosCoincidentes(id); 
            //Devuelvo en una lista los Motivos en los que el id de parametro coincide con el campo llamadoId de la tabla intermedia LlamadoMotivosLlamados

            return View(Modelo);
        }



        // GET: Llamados/Create
        public ActionResult Create()
        {
            LlamadosModel Modelo = new LlamadosModel();

            ClientesBL BaoClientes = new ClientesBL();
            Modelo.ListaClientes = BaoClientes.ListarClientes();

            UsuariosBL BaoUsuarios = new UsuariosBL();
            Modelo.ListaUsuarios = BaoUsuarios.ListarUsuarios();

            MotivosLlamadoBL BaoMotivosLlamado = new MotivosLlamadoBL();
            Modelo.ListaMotivos = BaoMotivosLlamado.ListaMotivos();
            
            
            return View(Modelo);
        }


        // POST: Llamados/Create
        [HttpPost]
        public ActionResult Create(LlamadosModel LlamadoNuevo)
        {
            try
            {
                if (LlamadoNuevo.Llamado == null)
                {
                    ModelState.AddModelError("", "Debe agregar un llamado.");
                }
                else if (LlamadoNuevo.Llamado.DescripcionLLamado.Length >= 300)
                {
                    ModelState.AddModelError(LlamadoNuevo.Llamado.DescripcionLLamado, "El campo no puede tener mas de 300 caracteres");
                }


                if (LlamadoNuevo.ListaDestinatarios != null)
                {
                    foreach (var UsuarioDestinatarioId in LlamadoNuevo.DestinatariosSeleccionados)
                    {

                        LlamadoNuevo.Llamado.LlamadosDestinatarios.Add(new ENTIDADES.LlamadosDestinatarios()
                        {
                            LlamadoId = LlamadoNuevo.Llamado.Id,
                            UsuarioId = UsuarioDestinatarioId
                        });

                    }
                }
                


                foreach (var motivoId in LlamadoNuevo.MotivosSeleccionados)
                {
                    
                    LlamadoNuevo.Llamado.LlamadosMotivosLlamados.Add(new ENTIDADES.LlamadosMotivosLlamados()
                    {
                        MotivoLlamadoId = motivoId,
                        LlamadoId = LlamadoNuevo.Llamado.Id,
                    });

                }


                LlamadosBL BaoLlamados = new LlamadosBL();
                BaoLlamados.Crear(LlamadoNuevo.Llamado);
        

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Surgio un error de tipo catch.");
                return View();
            }
        }






        // GET: Llamados/Edit/5
        public ActionResult Edit(int id)
        {
            LlamadosModel Modelo = new LlamadosModel();

            LlamadosBL BaoLlamados = new LlamadosBL();
            
            Modelo.Llamado = BaoLlamados.ObtenerDetalles(id);

            ClientesBL BaoClientes = new ClientesBL();

            Modelo.ListaClientes = BaoClientes.ListarClientes();   
           
            MotivosLlamadoBL BaoMotivosLlamado = new MotivosLlamadoBL();
            Modelo.ListaMotivos = BaoMotivosLlamado.ListaMotivos();

            UsuariosBL BaoUsuarios = new UsuariosBL(); 
            Modelo.ListaUsuarios = BaoUsuarios.ListarUsuarios(); //Lista a todos los usuarios

            //Para mostrar los Motivos que actuales que correspondan al momento de hacer la consulta.
            Modelo.MotivosCoincidentes = BaoLlamados.MotivosCoincidentes(id);
            //Devuelvo en una lista los Motivos en los que el id de parametro coincide con el campo llamadoId de la tabla intermedia LlamadoMotivosLlamados

            Modelo.UsuariosDestinatariosCoincidentes = BaoLlamados.UsuariosDestinatariosCoincidentes(id); //Para mostrar los destinatarios (usuarios) actualmente en vigencia.

            

            return View(Modelo);
        }

        // POST: Llamados/Edit/5
        [HttpPost]
        public ActionResult Edit(LlamadosModel llamadoNuevo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "El formulario debe estar completado adecuadamente");
                }

              


                LlamadosBL BaoLlamados = new LlamadosBL();
                BaoLlamados.Editar(llamadoNuevo.Llamado, llamadoNuevo.MotivosSeleccionados, llamadoNuevo.DestinatariosSeleccionados);  

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Surgio un error de tipo catch.", ex);
                return View();
            }
        }


        // GET: Llamados/Delete/5
        public ActionResult Delete(int? id)
        {
            LlamadosModel Modelo = new LlamadosModel();

            LlamadosBL BaoLlamados = new LlamadosBL();

            Modelo.Llamado = BaoLlamados.ObtenerDetalles(id.Value);

            return View(Modelo);
        }

        // POST: Llamados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                LlamadosModel Modelo = new LlamadosModel();

                LlamadosBL BaoLlamados = new LlamadosBL();

                BaoLlamados.Elminar(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ha surgido un error de tipo catch.");
                return View();
            }
        }
    }
}
