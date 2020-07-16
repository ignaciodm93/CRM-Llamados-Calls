using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class PaisesBL
    {

        PaisesDAL obj = new PaisesDAL();


        public List<Paises> ListarPaises()
        {
            return obj.ListarPaises();
        }


        public void Crear(Paises paisNuevo)
        {
            obj.Crear(paisNuevo);
        }

        public Paises GetPaises(int id)
        {
            return obj.GetPaises(id);
        }

        public void Editar(Paises pais)
        {
            obj.EditPaises(pais);
        }   

        public void Eliminar(int id)
        {
            obj.EliminarPais(id);
        }

    }
}
