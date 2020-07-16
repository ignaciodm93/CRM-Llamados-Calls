using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class LlamadosBL
    {

        public List<Llamados> ListaLlamados()
        {
            LlamadosDAL dao = new LlamadosDAL();
            return dao.ListaLlamados();
        }


        public Llamados ObtenerDetalles(int id)
        {
            LlamadosDAL dao = new LlamadosDAL();
            return dao.ObtenerDetalles(id);
        }



        public void Crear(Llamados llamadoNuevo)
        {
            LlamadosDAL dao = new LlamadosDAL();
            dao.Crear(llamadoNuevo);
        }


        public List<Usuarios> UsuariosDestinatariosCoincidentes(int id)
        {
            LlamadosDAL dao = new LlamadosDAL();
            return dao.UsuariosDestinatariosCoincidentes(id);
        }



        public List<MotivosLlamado> MotivosCoincidentes(int id)
        {
            LlamadosDAL dao = new LlamadosDAL();
            return dao.MotivosCoincidentes(id);
        }
     


        public void Editar(Llamados llamadoNuevo, IEnumerable<byte> MotivosSeleccionados, IEnumerable<byte> byteDestinatario)
        {
            LlamadosDAL dao = new LlamadosDAL();
            dao.Editar(llamadoNuevo, MotivosSeleccionados, byteDestinatario);
        }


    
        public void Elminar(int id)
        {
            LlamadosDAL dao = new LlamadosDAL();
            dao.Eliminar(id);
        }

    }
}
