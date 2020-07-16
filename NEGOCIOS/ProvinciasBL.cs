using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class ProvinciasBL
    {


        ProvinciasDAL obj = new ProvinciasDAL();

        public List<Provincias> ListarProvincias()
        {
            return obj.ListarProvincias();
        }



        //el void no retorna datos
        public void Agregar(Provincias provNueva)
        {
        

            obj.Agregar(provNueva);
        }



        //Detalles
        public Provincias GetProvincia(int id)
        {
            return obj.GetProvincias(id);
        }



        //Editar
        public void Editar(Provincias pro)
        {
            obj.EditProvincias(pro);

        }



        //Eliminar
        public void Eliminar(int id)
        {
            obj.EliminarProvincia(id);
        }



    }
}
