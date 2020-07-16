using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using System.Data.Entity;



namespace DATOS
{
    public class LlamadosDAL
    {


        public List<Llamados> ListaLlamados()
        {
            using (var db = new ABM11Entities())
            {
                db.ClientesDirecciones.Include(cd => cd.Clientes).ToList();

                db.Llamados.Include(m => m.Clientes).ToList();
                db.Llamados.Include(m => m.LlamadosMotivosLlamados).ToList();
                
                return db.Llamados.ToList();



            }
        }


        public Llamados ObtenerDetalles(int id)
        {
            using (var db = new ABM11Entities())
            {
                db.Llamados.Include(u => u.Usuarios).ToList();  //Para mostrar el login y nombre del usuario que recibio el llamado             
                db.Llamados.Include(c => c.Clientes).ToList();  //Para mostrar el nombre del cliente que llama en Detalles

                return db.Llamados.Find(id);
            }
        }



        //Usado en Editar y Detalles del contorlador y vistas.
        //Este metodo devuelve los motivos correspondientes en los que el id del llamado (parametro) coincide con algun resultado del campo llamadoId de la tabla intermedia llamadosMotivosLlamados.
        public List<MotivosLlamado> MotivosCoincidentes(int id)
        {
            using (var db = new ABM11Entities())
            {
                var LMLCoincidentes = db.LlamadosMotivosLlamados.Where(a => a.LlamadoId == id).ToList();
           
                var LMLIdMotivos = LMLCoincidentes.Select(m => m.MotivoLlamadoId).ToList();

                List<MotivosLlamado> MotivosFinales = new List<MotivosLlamado>();

       
                foreach (var item in LMLIdMotivos)
                {                 

                    var m = db.MotivosLlamado.Where(ml => ml.Id == item).FirstOrDefault();
              
                    MotivosFinales.Add(m);

                }

                return MotivosFinales;
            }
        }







        //Metodo para mostrar la lista (y por ende los registrados) de llamadosDestinatarios

        public List<Usuarios> UsuariosDestinatariosCoincidentes(int id)  //Para mostrar los usuarios (Destinatarios) actuales DETAILS y tal vez en edit(este ultimo a chequear)
        {
            using (var db = new ABM11Entities())
            {
                var hallados = db.LlamadosDestinatarios.Where(m => m.LlamadoId == id).ToList();

                List<Usuarios> resultadosFinales = new List<Usuarios>();

                foreach (var item in hallados)
                {

                    var usuario = db.Usuarios.Where(m => m.Id == item.UsuarioId);
                    var user = usuario.FirstOrDefault();
                    resultadosFinales.Add(user);
                }

                return resultadosFinales;    
            }
        }

        

       




        public void Crear(Llamados llamadoNuevo)
        {
            using (var db = new ABM11Entities())
            {
                db.Llamados.Include(m => m.LlamadosMotivosLlamados).ToList();

                db.Llamados.Add(llamadoNuevo);
                db.SaveChanges();
            }
        }





        public void Editar(Llamados llamadoNuevo, IEnumerable<byte> MotivosSeleccionados, IEnumerable<byte> DestinatariosSeleccionados)
        {
            using (var db = new ABM11Entities())
            {

                var llamadoOriginal = db.Llamados.Find(llamadoNuevo.Id);

                llamadoOriginal.ClienteId = llamadoNuevo.ClienteId;
                llamadoOriginal.Fecha = llamadoNuevo.Fecha;
                llamadoOriginal.DescripcionLLamado = llamadoNuevo.DescripcionLLamado;
                llamadoOriginal.UsuarioAtiendeId = llamadoNuevo.UsuarioAtiendeId;




                var coincidencias = db.LlamadosMotivosLlamados.Where(m => m.LlamadoId == llamadoNuevo.Id).ToList();

                //Motivos
                if (MotivosSeleccionados != null)
                {
                    if (coincidencias.Count() >= 1)
                    {
                        foreach (var hallada in coincidencias)
                        {
                            db.LlamadosMotivosLlamados.Remove(hallada);
                        }
                    }

                    foreach (var motivo in MotivosSeleccionados)
                    {
                        db.LlamadosMotivosLlamados.Add(new LlamadosMotivosLlamados()
                        {
                            MotivoLlamadoId = motivo,
                            LlamadoId = llamadoNuevo.Id

                        });
                    }
                }
               


                //Llamados Destinatarios
                var coincidenciasLlamadosDestinatarios = db.LlamadosDestinatarios.Where(m => m.LlamadoId == llamadoNuevo.Id).ToList();
            
                if (DestinatariosSeleccionados != null)
                {

                    foreach (var result in coincidenciasLlamadosDestinatarios)
                    {
                        db.LlamadosDestinatarios.Remove(result);
                    }

                    foreach (var item in DestinatariosSeleccionados)
                    {
                        
                            db.LlamadosDestinatarios.Add(new ENTIDADES.LlamadosDestinatarios()
                            {

                                LlamadoId = llamadoNuevo.Id,
                                UsuarioId = item

                            });

                    }                
                    
                }

                db.SaveChanges();
            }
        }






        public void Eliminar(int id)
        {
            using (var db = new ABM11Entities())
            {
                var llamadoGuardado = db.Llamados.Find(id);


                
                //Busco las relaciones con otras tablas

                //LlamadosDestinatarios
                var llamadosDestinatariosHallados = db.LlamadosDestinatarios.Where(m => m.LlamadoId == id).ToList();

                if (llamadosDestinatariosHallados.Count() >= 1)
                {
                    foreach (var llamado in llamadosDestinatariosHallados)
                    {
                        db.LlamadosDestinatarios.Remove(llamado);
                    }
                }

                //LamadosMotivosLlamados
                var llamadosMotivosLlamadosHallados = db.LlamadosMotivosLlamados.Where(m => m.LlamadoId == id).ToList();

                if (llamadosMotivosLlamadosHallados.Count() >= 1)
                {
                    foreach (var motivoLlamado in llamadosMotivosLlamadosHallados)
                    {
                        db.LlamadosMotivosLlamados.Remove(motivoLlamado);
                    }
                }
                







                db.Llamados.Remove(llamadoGuardado);
                db.SaveChanges();
            }
        }

    }
}
