using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.Entity;



namespace DATOS
{
    public class ProvinciasDAL
    {

        

        public List<Provincias> ListarProvincias()
        {

            using (var db = new ABM11Entities())
            {
          
                db.Provincias.Include(p => p.Paises).ToList();            
                return db.Provincias.ToList();
            }

        }



     



        public void Agregar(Provincias provNueva)
        {
            using (var db = new ABM11Entities())
            {

                db.Provincias.Include(p => p.Paises).ToList();
                db.Provincias.Add(provNueva);
                db.SaveChanges();
            }
        }



        //DETALLES
        public Provincias GetProvincias(int id)
        {
            using (var db = new ABM11Entities())
            {
                db.Provincias.Include(p => p.Paises).ToList();
                return db.Provincias.Where(d => d.Id == id).FirstOrDefault();
            }
        }



        //EDTIAR
        public void EditProvincias(Provincias prov)
        {
            using (var db = new ABM11Entities())
            {               
                var c = db.Provincias.Find(prov.Id); 
                c.Nombre = prov.Nombre;
                //
                c.PaisId = prov.PaisId; 
                //Funciona, de esta forma, guardo tambien el id del pais, que se esta renderizando con el dropdownlistfor con el nobmre del pais.
                //
                db.SaveChanges();
            }
        }



        //Eliminar
        public void EliminarProvincia(int id)
        {
            using (var db = new ABM11Entities())
            {
                db.Provincias.Include(p => p.Paises).ToList();
                var pro = db.Provincias.Find(id);

                db.Provincias.Remove(pro);

                db.SaveChanges();
            }
        }







    }
}
