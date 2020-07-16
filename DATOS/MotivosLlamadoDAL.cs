using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;

namespace DATOS
{ 
    public class MotivosLlamadoDAL
    {


        public List<MotivosLlamado> ListaMotivos()
        {
            using (var db = new ABM11Entities())
            {
                return db.MotivosLlamado.ToList();
            }
        }




        public MotivosLlamado ObtenerDetalles(int id)
        {
            using (var db = new ABM11Entities())
            {
                return db.MotivosLlamado.Find(id);
            }
        }


        public void Agregar(MotivosLlamado motivoNuevo)
        {
            using (var db = new ABM11Entities())
            {
                db.MotivosLlamado.Add(motivoNuevo);
                db.SaveChanges();
            }
        }


        public void Editar(MotivosLlamado motivoNuevo)
        {
            using (var db = new ABM11Entities())
            {
                var motivoOriginal = db.MotivosLlamado.Find(motivoNuevo.Id);
                motivoOriginal.Nombre = motivoNuevo.Nombre;

                db.SaveChanges();
            }
        }


        public void Elminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                var motivoABorrar = db.MotivosLlamado.Find(id);
                db.MotivosLlamado.Remove(motivoABorrar);
                db.SaveChanges();
            }
        }


    }
}
