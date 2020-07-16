using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class MailsBL
    {

        public List<Mails> ListaMails()
        {
            MailsDAL dao = new MailsDAL();

            return dao.ListaMails();
        }



        public Mails GetMails(int id)
        {
            MailsDAL dao = new MailsDAL();
            return dao.GetMails(id);
        }


        public void Agregar(Mails mail)
        {
            MailsDAL dao = new MailsDAL();
            dao.Agregar(mail);
        }


        public void Editar(Mails mail)
        {
            MailsDAL dao = new MailsDAL();
            dao.Editar(mail);
        }


        public void Eliminar(int id)
        {
            MailsDAL dao = new MailsDAL();
            dao.Eliminar(id);
        }
    }
}
