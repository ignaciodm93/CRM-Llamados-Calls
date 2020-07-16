using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class ClientesBL
    {

        

        public List<Clientes> ListarClientes()
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.ListarClientes();
        }



        //el void no retorna datos
        public void Agregar(Clientes clienteNuevo)
        {
            ClientesDAL obj = new ClientesDAL();
            obj.Agregar(clienteNuevo);
        }

        //ver si puedo pasarlo todo dentro de solamente client.

        //Detalles
        public Clientes ObtenerDetalles(int id)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.ObtenerDetalles(id);
        }

        //para Editar
        public ClientesTelefonos DevuelveTelefono(int id)
        {
            ClientesDAL DaoClientes = new ClientesDAL();
            return DaoClientes.DevuelveTelefono(id);
        }
        
        
        //editar para mostrar y editar registros acutuales 
        public List<ClientesTelefonos> DevuelveTelefonosExistentes(int id)
        {
            ClientesDAL DaoClientes = new ClientesDAL();
            return DaoClientes.DevuelveTelefonosExistentes(id);
        }


        public Paises DevolverPais(int id)
        {
            ClientesDAL DaoClientes = new ClientesDAL();
            return DaoClientes.ObtenerPais(id);
        }


        //Editar
        public void Editar(Clientes clienteNuevo, IEnumerable<byte> fuenteSeleccionada)
        {
            ClientesDAL obj = new ClientesDAL();
            obj.Editar(clienteNuevo, fuenteSeleccionada);
        }


        //Para Edit Get
        public List<ClientesFuentesContacto> DevuelveClienteFuentes(int id)
        {
            ClientesDAL DaoClientes = new ClientesDAL();
            return DaoClientes.DevuelveClienteFuentes(id);
        }

        //prueba
        //NO sirve
        public List<ClientesFuentesContacto> ListarClientesFuentesContacto()
        {
            ClientesDAL DaoClientes = new ClientesDAL();
            return DaoClientes.ListarClientesFuentesContactos();
        }

        //end prueba

        //Eliminar
        public void Eliminar(int id)
        {
            ClientesDAL obj = new ClientesDAL();
            obj.EliminarCliente(id);
        }

    }
}
