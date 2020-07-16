using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ENTIDADES;

namespace DATOS
{
    public class ClientesDAL
    {

        public List<Clientes> ListarClientes()
        {

            using (var db = new ABM11Entities())
            {
                db.Clientes.Include(p => p.Rubros).ToList();

                // TEST
                /*
                db.ClientesDirecciones.Include(p => p.CiudadId );
                db.ClientesDirecciones.Include(p => p.Ciudades ).ToList() ;
                db.Clientes.Include(p => p.ClientesDirecciones).ToList() ;
                db.ClientesDirecciones.Include(p => p.Ciudades.Nombre);
                db.Clientes.Include(p => p.ClientesDirecciones );
                db.ClientesDirecciones.Include(p => p.Ciudades.Id );
                */
                //ENDTEST

                return db.Clientes.ToList();
            }

        }



        public void Agregar(Clientes clienteNuevo)
        {

            using (var db = new ABM11Entities())
            {
                //Agrego los datos principales del cliente.
                db.Clientes.Add(clienteNuevo);

                //Creo el registro en tabla Direcciones con el id correspondiente a este cliente.
                if (clienteNuevo.ClientesDirecciones != null)
                {
                    foreach (var direccionNueva in clienteNuevo.ClientesDirecciones)
                    {
                        db.ClientesDirecciones.Add(direccionNueva);
                    }
                }



                //Agrego las las fuentes seleccionadas
                if (clienteNuevo.ClientesFuentesContacto != null)
                {
                    foreach (var nuevaFuente in clienteNuevo.ClientesFuentesContacto)
                    {
                        db.ClientesFuentesContacto.Add(nuevaFuente);
                    }
                }

                if (clienteNuevo.ClientesTelefonos != null)
                {
                    foreach (var nuevoTelefono in clienteNuevo.ClientesTelefonos)
                    {
                        db.ClientesTelefonos.Add(nuevoTelefono);
                    }
                }





                //Asi si funciona, no se por que de la otra forma ams detallada no.
                foreach (var it in clienteNuevo.Mails)
                {
                    db.Mails.Add(it);

                }



                db.SaveChanges();
            }

        }



        //DETALLES
        public Clientes ObtenerDetalles(int id)//cambiar por castellano
        {

            using (var db = new ABM11Entities())
            {

                db.Clientes.Include(p => p.Mails).ToList();

                db.Clientes.Include(p => p.ClientesDirecciones).ToList();

                db.ClientesDirecciones.Include(m => m.Ciudades.Provincias.Paises).ToList();

                db.Clientes.Include(p => p.ClientesTelefonos).ToList();

                db.Clientes.Include(p => p.Rubros).ToList();

                db.Clientes.Include(p => p.ClientesFuentesContacto).ToList();

                //Este tipo de Include me sirve si tengo tablas intermedias, asi anexo la ultima tabla.
                db.ClientesFuentesContacto.Include(p => p.FuentesContacto).ToList();

                return db.Clientes.Find(id);
            }

        }

        public Paises ObtenerPais(int id)
        {
            using (var db = new ABM11Entities())
            {
                var cliente = db.Clientes.Find(id);

                var direccion = db.ClientesDirecciones.Where(m => m.ClienteId == cliente.Id).FirstOrDefault();

                Paises pais = new Paises();

                if (direccion != null)
                {
                    var ciudad = db.Ciudades.Where(m => m.Id == direccion.CiudadId).FirstOrDefault();

                    var provincia = db.Provincias.Where(m => m.Id == ciudad.ProvinciaId).FirstOrDefault();

                    pais = db.Paises.Where(m => m.Id == provincia.PaisId).FirstOrDefault();

                }
                else
                {
                    //Es lo unico que tengo que especificar de pais porque es lo unico que requiero en la vista.
                    pais.Nombre = "Indefinido";
                }

                return pais;
            }
        }

        //Metodo para devolver el telefono en detalles, comentado porque halle una forma de hacerlo directamente por tablas en Detalles, pero en Editar no pude hacerlo de esa forma asi que lo requiero.
        public ClientesTelefonos DevuelveTelefono(int id)
        {
            using (var db = new ABM11Entities())
            {
                var telefono = db.ClientesTelefonos.Where(t => t.ClienteId == id).FirstOrDefault();
                db.Clientes.Include(p => p.ClientesTelefonos).ToList();
                return telefono;
            }

        }   //Tal vez tengo que chequear detalles porque este metodo lo voy a modificar para poder mostrar y editar los registros.


        //Una vez hecho este y empleado en detalles y edit, eliminar el anterior
        public List<ClientesTelefonos> DevuelveTelefonosExistentes(int id)
        {
            List<ClientesTelefonos> TelefonosHallados = new List<ClientesTelefonos>();
            using (var db = new ABM11Entities())
            {
                TelefonosHallados = db.ClientesTelefonos.Where(m => m.ClienteId == id).ToList();
            }

            return TelefonosHallados;
        }


        //Devuelve las coincidencias para saber que cliente tiene cada fuente.
        //Lo hice aca porque no tengo clase entidad ClientesFuentesContactos, por lo tanto no puedo listarlas todas desde su BL en el controlados Get (Edit)
        public List<ClientesFuentesContacto> DevuelveClienteFuentes(int id)
        {
            List<ClientesFuentesContacto> coincidencias = new List<ClientesFuentesContacto>();

            using (var db = new ABM11Entities())
            {
                coincidencias = db.ClientesFuentesContacto.Where(m => m.ClienteId == id).ToList();
            }

            return coincidencias;
        }

        //Prueba que NO sirve
        public List<ClientesFuentesContacto> ListarClientesFuentesContactos()
        {
            List<ClientesFuentesContacto> ListarClientesFuentesContactos = new List<ClientesFuentesContacto>();
            using (var db = new ABM11Entities())
            {
                ListarClientesFuentesContactos = db.ClientesFuentesContacto.ToList();
            }

            return ListarClientesFuentesContactos;
        }


        public void Editar(Clientes clienteNuevo, IEnumerable<byte> fuentesSeleccionadas)
        {
            using (var db = new ABM11Entities())
            {
                
                var clienteAEditar = db.Clientes.Find(clienteNuevo.Id);

                clienteAEditar.Nombre = clienteNuevo.Nombre;
                clienteAEditar.Apellido = clienteNuevo.Apellido;
                clienteAEditar.RubroId = clienteNuevo.RubroId;
                clienteAEditar.FechaNacimiento = clienteNuevo.FechaNacimiento;

                //Fuentes de Contacto
                var fuentesHalladas = db.ClientesFuentesContacto.Where(m => m.ClienteId == clienteNuevo.Id).ToList();

             
                if (fuentesSeleccionadas != null)
                {
                    if (fuentesHalladas.Any() && fuentesSeleccionadas.Any())
                    {
                        foreach (var fuenteVieja in fuentesHalladas)
                        {
                            db.ClientesFuentesContacto.Remove(fuenteVieja);
                        }

                        foreach (var fuenteNueva in fuentesSeleccionadas)
                        {
                            db.ClientesFuentesContacto.Add(new ClientesFuentesContacto()
                            {
                                ClienteId = clienteNuevo.Id,
                                FuenteContactoId = fuenteNueva
                            });
                        }

                    }
                    else if (fuentesSeleccionadas.Any() && !fuentesHalladas.Any())
                    {
                        foreach (var fuenteNueva in fuentesSeleccionadas)
                        {
                            db.ClientesFuentesContacto.Add(new ClientesFuentesContacto()
                            {
                                ClienteId = clienteNuevo.Id,
                                FuenteContactoId = fuenteNueva
                            });
                        }
                    }
                }







                //Direccion
                if (clienteNuevo.ClientesDirecciones.Count() >= 1) 
                {
                    var resultadosExistentes = db.ClientesDirecciones.Where(m => m.ClienteId == clienteNuevo.Id).ToList();

                    if (resultadosExistentes != null)
                    {
                        foreach (var encontrado in resultadosExistentes)
                        {                         
                            db.ClientesDirecciones.Remove(encontrado);
                        }
                    }
                  
                    foreach (var nuevosRegistros in clienteNuevo.ClientesDirecciones)
                    {
                        nuevosRegistros.ClienteId = clienteNuevo.Id; //Le asigno el id del cliente a la direccion para que quede asociado.

                        db.ClientesDirecciones.Add(nuevosRegistros);
                    }
                }

               


                //Telefono
                if (clienteNuevo.ClientesTelefonos.Count() >= 1)
                {
                    //Los que tienen el numero como "nulo", o sea que fueron vaciados en la vista, automaticamente vamos a eliminarlos del registro:
                    foreach (var item in clienteNuevo.ClientesTelefonos)
                    {
                        if (item.Telefono == "vacio")
                        {
                            item.Telefono = "vacio";
                            db.ClientesTelefonos.Attach(item);
                            db.ClientesTelefonos.Remove(item);
                        }
                    }

                    var telefonosRegistrados = db.ClientesTelefonos.Where(m => m.ClienteId == clienteNuevo.Id).ToList();

                    foreach (var registroABorrar in telefonosRegistrados)
                    {
                        db.ClientesTelefonos.Remove(registroABorrar);
                    }

                    foreach (var registroAAgregar in clienteNuevo.ClientesTelefonos)
                    {
                        db.ClientesTelefonos.Add(new ClientesTelefonos()
                        {

                            Telefono = registroAAgregar.Telefono,
                            ClienteId = clienteNuevo.Id,
                            CiudadId = registroAAgregar.CiudadId
                            //Tal vez estaria bueno considerar que si esta vacio, se le asigne la ciudad del cliente. Tambien hay que tener presente que se suelen usar paises aca.

                        });
                    }

                }



                //Edicion de Mails
                var mailsHallados = db.Mails.Where(m => m.ClienteId == clienteNuevo.Id).ToList();
 
                //borro todos los mails registrados (si los hay)
                if (mailsHallados.Any())
                {
                    foreach (var mailABorrar in mailsHallados)
                    {
                        db.Mails.Remove(mailABorrar);
                    }                                   
                }


                //Agrego los mails aunque no haya resultados hallados previos
                if (clienteNuevo.Mails.Any())
                {
                    foreach (var item in clienteNuevo.Mails)
                    {
                        item.ClienteId = clienteNuevo.Id;
                        db.Mails.Add(item);
                    }
                }


                db.SaveChanges();
            }
        }



        //Eliminar
        public void EliminarCliente(int id)
        {
            using (var db = new ABM11Entities())
            {


                var clienteHallado = db.Clientes.Find(id);
                db.Clientes.Include(p => p.Rubros).ToList();


                //Ver con geri
                //de aca para abajo-----------------------------------------------------------------------------------------------
                //tal vez usar cascade delete/pense que era un error de lazy loading

                //Chequeo si el cliente tiene dependencias y si es asi, las elimino:
                if (db.Llamados.Where(m => m.ClienteId == id).Any())
                {

                    //Busco los llamados realizados con el id del cliente que voy a eliminar
                    var llamadosHallados = db.Llamados.Where(m => m.ClienteId == id).ToList();

                   
                    //Por cada uno de los resultados voy a ver si tienen una conexion (el .Any) con llamadosMotivosLlamados.
                    //Si es asi voy a almacenarlos  y voy a eliminarlos.
                    foreach (var llamado in llamadosHallados)
                    {

                        if (llamado.LlamadosMotivosLlamados.Any())
                        {
                            var llamadosLInk = llamado.LlamadosMotivosLlamados.ToList();


                            foreach (var item in llamadosLInk)
                            {
                                db.LlamadosMotivosLlamados.Remove(item);
                            }

                        }


                        var llamadosDestinatariosRelacionados = db.LlamadosDestinatarios.Where(m => m.LlamadoId == llamado.Id).ToList();

                        foreach (var item in llamadosDestinatariosRelacionados)
                        {
                            db.LlamadosDestinatarios.Remove(item);
                        }

                    }   


                    foreach (var llamado in llamadosHallados)
                    {
                        db.Llamados.Remove(llamado);
                    }
                }
                

                    //Chequeo si tiene algun mail
                  if (db.Mails.Where(m => m.ClienteId == id).Any())
                  {
                      var mailsRelacionados = db.Mails.Where(m => m.ClienteId == id).ToList();

                      foreach (var mail in mailsRelacionados)
                      {
                          db.Mails.Remove(mail);
                      }
                  }

                  //Chequeo si tiene alguna fuente de contacto
                  if (db.ClientesFuentesContacto.Where(m => m.ClienteId == id).Any())
                  {
                      var cfcRelacionados = db.ClientesFuentesContacto.Where(m => m.ClienteId == id).ToList();

                      foreach (var item in cfcRelacionados)
                      {
                          db.ClientesFuentesContacto.Remove(item);
                      }
                  }


                //Chequeo si tiene algun telefono
                if (db.ClientesTelefonos.Where(m => m.ClienteId == id).Any())
                 {
                     var clientesTelefonosRelacionados = db.ClientesTelefonos.Where(m => m.ClienteId == id).ToList();

                     foreach (var item in clientesTelefonosRelacionados)
                     {
                         db.ClientesTelefonos.Remove(item);
                     }
                 }

                //Chequeo si tiene alguna direccion
                
                if (db.ClientesDirecciones.Where(m => m.ClienteId == id).Any())
                {
                    var direccionesRelacionadas = db.ClientesDirecciones.Where(m => m.ClienteId == id).ToList();

                    foreach (var item in direccionesRelacionadas)
                    {
                        db.ClientesDirecciones.Remove(item);
                    }


                    
                  }
                //de aca para arriba----------------------------------------------------------------------------------------------

                db.Clientes.Remove(clienteHallado);
                db.SaveChanges();

                
            }
        }



    }
}
