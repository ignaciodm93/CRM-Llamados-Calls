using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using NEGOCIOS;
using MVC.Models;

namespace MVC.Controllers
{
    public class MailsController : Controller
    {
        // GET: Mails
        public ActionResult Index()
        {
            MailsBL bao = new MailsBL();
            MailsModel mailModel = new MailsModel();
            mailModel.MailsLista = bao.ListaMails();

            ClientesBL cao = new ClientesBL();
            mailModel.ClientesLista = cao.ListarClientes();

            return View(mailModel);
        }

        // GET: Mails/Details/5
        public ActionResult Details(int id)
        {
            MailsBL bao = new MailsBL();
            MailsModel Modelo = new MailsModel();
            Modelo.Mails = bao.GetMails(id);

            return View(Modelo);
        }

        // GET: Mails/Create
        public ActionResult Create()
        {
            MailsModel mailModel = new MailsModel();

            ClientesBL cao = new ClientesBL();
            mailModel.ClientesLista = cao.ListarClientes();


            return View(mailModel);
        }

        // POST: Mails/Create
        [HttpPost]
        public ActionResult Create(MailsModel mailModel)
        {
            try
            {
                //Me estaba andando mal porque tenia esto
                /*
                  if (mailModel.Mails == 0) //tal vez el que no estuviese definiendo que atributo particular de Mails, me daba error. El identity se crea ya en la base de datos.
                 {
                     ModelState.AddModelError(mailModel.Mails.Mail, "Algun campo esta vacio.");
                 }
                  */

                MailsBL bao = new MailsBL();
                bao.Agregar(mailModel.Mails);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Surgio un error de tipo catch.");
                return View();
            }
        }

        // GET: Mails/Edit/5
        public ActionResult Edit(int id)
        {
            MailsModel Modelo = new MailsModel();
            MailsBL bao = new MailsBL();

            ClientesBL cao = new ClientesBL();
            Modelo.ClientesLista = cao.ListarClientes();

            Modelo.Mails = bao.GetMails(id);

            return View(Modelo);
        }

        // POST: Mails/Edit/5
        [HttpPost]
        public ActionResult Edit(MailsModel mail)
        {
            try
            {
                if (mail.Mails.Mail == null) {
                    ModelState.AddModelError("", "agregue un nombre");
                }

                MailsBL bao = new MailsBL();
                bao.Editar(mail.Mails);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error de tipo catch");
                return View();
            }
        }

        // GET: Mails/Delete/5
        public ActionResult Delete(int? id)
        {
            MailsModel Modelo = new MailsModel();
            MailsBL bao = new MailsBL();

            ClientesBL cao = new ClientesBL();


            Modelo.Mails = new MailsBL().GetMails(id.Value);
            Modelo.ClientesLista = cao.ListarClientes();

            return View(Modelo);
        }

        // POST: Mails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                MailsBL bao = new MailsBL();
                bao.Eliminar(id);




                //return RedirectToAction("Index");

                /*
                MailsModel Modelo = new MailsModel();
                Modelo.Mails = bao.GetMails(id);
                var MailExistente = Modelo.Mails;
                if (MailExistente.ClienteId != null)
                {
                    return RedirectToRoute("VueltaDeMails");
                }
                else
                {
                    
                }
                */
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Ha surgido un error de tipo catch");
                return View();
            }
        }
    }
}
