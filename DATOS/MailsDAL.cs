using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.Entity;


namespace DATOS
{
    public class MailsDAL
    {


        public List<Mails> ListaMails()
        {
            using (var db = new ABM11Entities())
            {
                db.Mails.Include(p => p.Clientes).ToList();
                return db.Mails.ToList();
            }
        }


        public Mails GetMails(int id)
        {
            using (var db = new ABM11Entities())
            {
                var m = db.Mails.Find(id);
                return m;
            }
        }


        public void Agregar(Mails mail)
        {
            using (var db = new ABM11Entities())
            {
                db.Mails.Include(p => p.Clientes).ToList();
                db.Mails.Add(mail);
                db.SaveChanges();
            }
        }


        public void Editar(Mails mail)
        {
            using (var db = new ABM11Entities())
            {
                var m = db.Mails.Find(mail.Id);

                m.Mail = mail.Mail;
                m.ClienteId = mail.ClienteId;

                db.SaveChanges();

            }
        }


        public void Eliminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                

                var m = db.Mails.Find(id);
                //db.Mails.Include(p => p.Clientes).ToList();
                db.Mails.Remove(m);

                db.SaveChanges();
            }
        }

    }



}
