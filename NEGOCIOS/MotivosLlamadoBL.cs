using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class MotivosLlamadoBL
    {

        public List<MotivosLlamado> ListaMotivos()
        {
            MotivosLlamadoDAL dao = new MotivosLlamadoDAL();
            return dao.ListaMotivos();
        }


        public MotivosLlamado ObtenerDetalles(int id)
        {
            MotivosLlamadoDAL dao = new MotivosLlamadoDAL();
            return dao.ObtenerDetalles(id);
        }


        public void Agregar(MotivosLlamado motivoNuevo)
        {
            MotivosLlamadoDAL dao = new MotivosLlamadoDAL();
            dao.Agregar(motivoNuevo);
        }


        public void Editar(MotivosLlamado motivoNuevo)
        {
            MotivosLlamadoDAL dao = new MotivosLlamadoDAL();
            dao.Editar(motivoNuevo);
        }


        public void Eliminar(int id)
        {
            MotivosLlamadoDAL dao = new MotivosLlamadoDAL();
            dao.Elminar(id);
        }

    }
}
