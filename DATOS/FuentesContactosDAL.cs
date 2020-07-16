using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;

namespace DATOS
{
    public class FuentesContactosDAL
    {

        public List<FuentesContacto> ListaFuentes()
        {
            using (var db = new ABM11Entities())
            {
                return db.FuentesContacto.ToList();
            }
        }




        public FuentesContacto Details(int id)
        {
            using (var db = new ABM11Entities())
            {
                return db.FuentesContacto.Find(id);
            }
        }



        public void Create(FuentesContacto fuenteNueva)
        {
            using (var db = new ABM11Entities())
            {
                db.FuentesContacto.Add(fuenteNueva);
                db.SaveChanges();
            }
        }



        public void Edit(FuentesContacto fuente)
        {
            using (var db = new ABM11Entities())
            {
                var fuenteExistente = db.FuentesContacto.Find(fuente.Id);
                fuenteExistente.Nombre = fuente.Nombre;
                
                db.SaveChanges();
            }
        }


        public void Eliminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                var fuenteExistente = db.FuentesContacto.Find(id);
                db.FuentesContacto.Remove(fuenteExistente);
                db.SaveChanges();
            }
        }

    }
}
