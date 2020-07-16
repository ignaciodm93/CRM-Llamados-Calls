using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class ClientesDireccionesBL
    {

        

        public List<ClientesDirecciones> ListarDireciones()
        {
            ClientesDireccionesDAL dao = new ClientesDireccionesDAL();
            return dao.ListarDirecciones();
        }


        public ClientesDirecciones GetClientesDirecciones(int id)
        {
            ClientesDireccionesDAL dao = new ClientesDireccionesDAL();
            return dao.GetClientesDirecciones(id);
             
        }


        public void Agregar(ClientesDirecciones cliDir)
        {
            ClientesDireccionesDAL dao = new ClientesDireccionesDAL();
            dao.Agregar(cliDir);
        }


        public void Editar(ClientesDirecciones cliDir)
        {
            ClientesDireccionesDAL dao = new ClientesDireccionesDAL();
            dao.Editar(cliDir);
        }

        public void Eliminar(int id)
        {
            ClientesDireccionesDAL dao = new ClientesDireccionesDAL();
            dao.Eliminar(id);
        }


    }
}
