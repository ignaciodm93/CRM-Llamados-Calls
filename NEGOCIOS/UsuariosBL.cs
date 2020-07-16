using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class UsuariosBL
    {

        public List<Usuarios> ListarUsuarios()
        {
            UsuariosDAL dao = new UsuariosDAL();
            return dao.ListarUsuarios();
        }


        public Usuarios ObtenerDetalles(int id)
        {
            UsuariosDAL dao = new UsuariosDAL();
            return dao.ObtenerDetalles(id);
        }


        public void Agregar(Usuarios usuarioNuevo)
        {
            UsuariosDAL dao = new UsuariosDAL();
            dao.Agregar(usuarioNuevo);
        }


        public void Editar(Usuarios usuarioNuevo)
        {
           

            UsuariosDAL dao = new UsuariosDAL();
            dao.Editar(usuarioNuevo);
        }


        public void Eliminar(int id)
        {
            UsuariosDAL dao = new UsuariosDAL();
            dao.Eliminar(id);
        }


    }
}
