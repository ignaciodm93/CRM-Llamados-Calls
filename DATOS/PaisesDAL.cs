using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
//using System.Data.Entity; Si fuese a implementar el metodo Include

//Una vez que termine de armar todo paises, tengo que predisponerme a replicar EN EL METODO CREAR PAIS lo que hice con geri, del dropdownlist.

namespace DATOS
{
    public class PaisesDAL
    {


        public List<Paises> ListarPaises()
        {
            using (var db = new ABM11Entities())
            {



                //Aca si hubiese ua categoria SUPERIOR podriamos empelar el Include.
                return db.Paises.ToList();



            }
        }



        public void Crear(Paises paisNuevo)
        {
            using (var db = new ABM11Entities())
            {
                //Include si lo necesitase

                db.Paises.Add(paisNuevo);
                db.SaveChanges();
            }
        }




        public Paises GetPaises(int id)
        {
            using (var db = new ABM11Entities())
            {
                //Include si lo necesitase
                return db.Paises.Where(d => d.Id == id).FirstOrDefault();
            }
        }


        public void EditPaises(Paises pais)
        {
            using (var db = new ABM11Entities())
            {
                var p = db.Paises.Find(pais.Id);
                p.Nombre = pais.Nombre;


                db.SaveChanges();
            }
        }


        public void EliminarPais(int id)
        {
            using (var db = new ABM11Entities())
            {
                var p = db.Paises.Find(id);
                db.Paises.Remove(p);

                db.SaveChanges();
            };
        }

    }
}
