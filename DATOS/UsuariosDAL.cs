using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;

namespace DATOS
{
    public class UsuariosDAL
    {

        public List<Usuarios> ListarUsuarios()
        {
            using (var db = new ABM11Entities())
            {
                return db.Usuarios.ToList();
            }
        }


        public Usuarios ObtenerDetalles(int id)
        {
            using (var db = new ABM11Entities())
            {
                return db.Usuarios.Find(id);
            }
        }


        public void Agregar(Usuarios usuarioNuevo)
        {
            using (var db = new ABM11Entities())
            {
                db.Usuarios.Add(usuarioNuevo);
                db.SaveChanges();
            }
        }


        public void Editar(Usuarios usuarioNuevo)
        {
            using (var db = new ABM11Entities())
            {
                var usuarioOriginal = db.Usuarios.Find(usuarioNuevo.Id);

                //usuarioOriginal.Id = usuarioNuevo.Id;
                usuarioOriginal.Login = usuarioNuevo.Login;
                usuarioOriginal.Nombre = usuarioNuevo.Nombre;
                usuarioOriginal.Clave = usuarioNuevo.Clave;
                usuarioOriginal.Mail = usuarioNuevo.Mail;

                db.SaveChanges();
            }
        }


        public void Eliminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                var usuarioABorrar = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuarioABorrar);
                db.SaveChanges();
            }
        }


    }
}
