using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.Entity;

namespace DATOS
{
    public class ClientesDireccionesDAL
    {


        public List<ClientesDirecciones> ListarDirecciones()
        {
            using (var db = new ABM11Entities())
            {
                //Si hace falta el Include, agregarlo
                db.ClientesDirecciones.Include(p => p.Ciudades ).ToList();

                //Prueba 9.5.20
                //db.ClientesDirecciones.Include(p => p.ClienteId);
                //end prueba 9.5.20

                return db.ClientesDirecciones.ToList();
            }
        }




        public ClientesDirecciones GetClientesDirecciones(int id)
        {
            using (var db = new ABM11Entities())
            {
                //return db.Paises.Where(d => d.Id == id).FirstOrDefault();
                db.ClientesDirecciones.Include(p => p.Ciudades.Provincias.Paises).ToList();                
                var direccionHallada = db.ClientesDirecciones.Find(id);
                return direccionHallada;
            }
        }



        public void Agregar(ClientesDirecciones DireccionNueva)
        {
            using (var db = new ABM11Entities())
            {
                

                db.ClientesDirecciones.Add(DireccionNueva);
                db.SaveChanges();
            }
        }



        public void Editar(ClientesDirecciones DireccionNueva)
        {
            using (var db = new ABM11Entities())
            {
                

                var direccionOriginal = db.ClientesDirecciones.Find(DireccionNueva.Id);




                //db.ClientesDirecciones.Include(p => p.Ciudades.Id).ToList();
                //db.ClientesDirecciones.Include(p => p.CiudadId);
                //db.ClientesDirecciones.Include(p => p.CiudadId).ToList();

                direccionOriginal.Ciudades = DireccionNueva.Ciudades;

                direccionOriginal.Calle = DireccionNueva.Calle;
                direccionOriginal.Altura = DireccionNueva.Altura;
                direccionOriginal.Piso = DireccionNueva.Piso;
                direccionOriginal.CiudadId = DireccionNueva.CiudadId;
                direccionOriginal.ClienteId = DireccionNueva.ClienteId;



                //test a tirar
                //cd.Ciudades.ClientesDirecciones = cliDir.Ciudades.ClientesDirecciones;
                

                //cd.Ciudades = cliDir.Ciudades;

                //cd.Ciudades.Nombre = cliDir.Ciudades.Nombre;


                db.SaveChanges();


            }
        }



        public void Eliminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                db.ClientesDirecciones.Include(p => p.Ciudades.Provincias.Paises).ToList();
                var direccionAEliminar = db.ClientesDirecciones.Find(id);
                //Agregar Include si hace falta
                db.ClientesDirecciones.Remove(direccionAEliminar);

                db.SaveChanges();
            }
        }


    }
}
