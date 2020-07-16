using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.Entity;

namespace DATOS
{
    public class CiudadesDAL
    {



        public List<Ciudades> ListarCiudades()
        {

            using (var db = new ABM11Entities())
            {
                


                db.Ciudades.Include(p => p.Provincias).ToList();
                
                return db.Ciudades.ToList();
            }

        }



      

        public Ciudades GetCiudad(int id)
        {
            using (var db = new ABM11Entities())
            {
                db.Ciudades.Include(p => p.Provincias).ToList();
                return db.Ciudades.Find(id);
            }
        }






        public void Crear(Ciudades city)
        {
            using (var db = new ABM11Entities())
            {
                
                db.Ciudades.Add(city);
                db.SaveChanges();
            }
        }



        public void Editar(Ciudades city)
        {
            using (var db = new ABM11Entities())
            {

                var original = db.Ciudades.Find(city.Id);

                original.Nombre = city.Nombre;
                original.ProvinciaId = city.ProvinciaId;

                db.SaveChanges();


            }
        }



        public void Eliminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                var dis = db.Ciudades.Find(id);
                db.Ciudades.Remove(dis);
                db.SaveChanges();

            }
        }





    }
}
