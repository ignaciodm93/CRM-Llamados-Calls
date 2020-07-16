using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;

namespace DATOS
{
    public class LlamadosDestinatariosDAL
    {

        public List<LlamadosDestinatarios> ListarLlamadosDestinatarios()
        {
            using (var db = new ABM11Entities())
            {
                return db.LlamadosDestinatarios.ToList();
            }
        }



        public LlamadosDestinatarios ObtenerDetalles(int id)
        {
            using (var db = new ABM11Entities())
            {
                return db.LlamadosDestinatarios.Find(id);
            }
        }



        public void Agregar(LlamadosDestinatarios destinatarioNuevo)
        {
            using (var db = new ABM11Entities())
            {
                db.LlamadosDestinatarios.Add(destinatarioNuevo);
                db.SaveChanges();
            }
        }


        public void Editar(LlamadosDestinatarios destinatarioNuevo)
        {
            using (var db = new ABM11Entities())
            {
                var destinatarioOriginal = db.LlamadosDestinatarios.Find(destinatarioNuevo.UsuarioId);

                //!! UsuarioId y LlamadoId son pk, no se pueden editar, solo eliminar.
                //Aca solo vamos a hacer que se modifique el comentario.

                destinatarioOriginal.Comentarios = destinatarioNuevo.Comentarios;
                //destinatarioOriginal.LlamadoId = destinatarioNuevo.LlamadoId;
                //destinatarioOriginal.UsuarioId = destinatarioNuevo.UsuarioId;

                db.SaveChanges();
            }
        }



        public void Elminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                var destinatarioABorrar = db.LlamadosDestinatarios.Find(id);
                db.LlamadosDestinatarios.Remove(destinatarioABorrar);
                db.SaveChanges();
            }
        }

    }
}
