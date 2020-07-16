using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class RubrosDAL
    {

        public List<Rubros> ListarRubros()
        {
            using (ABM11Entities db = new ABM11Entities())
            {
                return db.Rubros.ToList();
            }
        }




        public Rubros GetRubros(int id)
        {
            using (ABM11Entities db = new ABM11Entities())
            {
                return db.Rubros.Find(id);
               
            }
        }



        public void Crear(Rubros rub)
        {
            using (ABM11Entities db = new ABM11Entities())
            {
                db.Rubros.Add(rub);
                db.SaveChanges();
            }
        }




        public void Editar(Rubros rub)
        {
            using (ABM11Entities db = new ABM11Entities())
            {
                var original = db.Rubros.Find(rub.Id);

                original.Nombre = rub.Nombre;
                //Aca irian otros atributos si hiciese falta. El id no porque no se modifica.

                db.SaveChanges();
            
            }
        }



        public void Eliminar(int id)
        {
            using (ABM11Entities db = new ABM11Entities())
            {

                var ClienteDelrubroAsignado = db.Clientes.Where(m => m.RubroId == id).ToList();


                Clientes cli = new Clientes();
                if (ClienteDelrubroAsignado.Any())
                {
                    foreach (var cliente in ClienteDelrubroAsignado)
                    {                     
                        cliente.RubroId = null;
                    }
                }


                var r = db.Rubros.Find(id);
                db.Rubros.Remove(r);
                db.SaveChanges();
            }
        }




       



    }
}
