using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DATOS;
using ENTIDADES;

namespace NEGOCIOS
{
    public class LlamadosDestinatariosBL
    {


        public List<LlamadosDestinatarios> ListarLlamadosDestinatarios()
        {
            LlamadosDestinatariosDAL dao = new LlamadosDestinatariosDAL();
            return dao.ListarLlamadosDestinatarios();
        }


        public LlamadosDestinatarios ObtenerDetalles(int id)
        {
            LlamadosDestinatariosDAL dao = new LlamadosDestinatariosDAL();
            return dao.ObtenerDetalles(id);
        }


        public void Agregar(LlamadosDestinatarios llamadoNuevo)
        {
            LlamadosDestinatariosDAL dao = new LlamadosDestinatariosDAL();
            dao.Agregar(llamadoNuevo);
        }


        public void Editar(LlamadosDestinatarios llamadoNuevo)
        {
            LlamadosDestinatariosDAL dao = new LlamadosDestinatariosDAL();
            dao.Editar(llamadoNuevo);
        }

        public void Eliminar(int id)
        {
            LlamadosDestinatariosDAL dao = new LlamadosDestinatariosDAL();
            dao.Elminar(id);
        }

    }
}
