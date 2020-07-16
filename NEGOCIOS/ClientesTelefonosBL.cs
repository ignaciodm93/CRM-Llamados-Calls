using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class ClientesTelefonosBL
    {

        public List<ClientesTelefonos> ListarTelefonos()
        {
            ClientesTelefonosDAL tao = new ClientesTelefonosDAL();
            return tao.ListarTelefonos();
        }


        public ClientesTelefonos Detalles(int n, int? c)
        {
            ClientesTelefonosDAL tao = new ClientesTelefonosDAL();
            return tao.Detalles(n, c);
        }


        public void Agregar(ClientesTelefonos cliTel)
        {
            ClientesTelefonosDAL tao = new ClientesTelefonosDAL();
            tao.Agregar(cliTel);
        }


        public void Editar(ClientesTelefonos cliTel, string tel, int cliId)
        {
            ClientesTelefonosDAL tao = new ClientesTelefonosDAL();
            tao.Editar(cliTel, tel, cliId);
        }


        public void Eliminar(string tel)
        {
            ClientesTelefonosDAL tao = new ClientesTelefonosDAL();
            tao.Eliminar(tel);
        }


    }
}
