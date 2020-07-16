using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using System.Data.Entity;

namespace DATOS
{
    public class ClientesTelefonosDAL
    {


        public List<ClientesTelefonos> ListarTelefonos()
        {
            using (var db = new ABM11Entities())
            {
                db.ClientesTelefonos.Include(p => p.Ciudades).ToList();
                db.ClientesTelefonos.Include(p => p.Clientes).ToList();


                return db.ClientesTelefonos.ToList();
            }
        }



        public ClientesTelefonos Detalles(int telefono, int? clienteid)
        {
            using (var db = new ABM11Entities())
            {

                db.ClientesTelefonos.Include(p => p.Ciudades.Provincias.Paises).ToList();
                db.ClientesTelefonos.Include(p => p.Clientes).ToList();

                //Lo paso a string, porque es varchar, no int
                var num = telefono.ToString();//correcto

                var t = db.ClientesTelefonos.Find(num, clienteid);//correcto
                

                return t;
            }
        }



        public void Agregar(ClientesTelefonos cliTel)
        {
            using (var db = new ABM11Entities())
            {
                
                db.ClientesTelefonos.Include(p => p.Ciudades).ToList();
                db.ClientesTelefonos.Include(p => p.Clientes).ToList();

                

                db.ClientesTelefonos.Add(cliTel);
                

                db.SaveChanges();
            }
        }


        public void Editar(ClientesTelefonos cliTel, string tel, int cliId)
        {
            using (var db = new ABM11Entities())
            {
                
                var original = db.ClientesTelefonos.Where(c => c.Telefono == tel && c.ClienteId == cliId).FirstOrDefault();
               
                db.ClientesTelefonos.Remove(original);
                db.ClientesTelefonos.Add(cliTel);
                                    

                db.SaveChanges();
            }
        }


        public void Eliminar(string tel)
        {
            using (var db = new ABM11Entities())
            {
                //string cel = tel.ToString();

                var original = db.ClientesTelefonos.Where(c => c.Telefono == tel /*&& c.ClienteId == cliid*/ ).FirstOrDefault();

                db.ClientesTelefonos.Remove(original);
               


                db.SaveChanges();
            }
        }




    }
}
