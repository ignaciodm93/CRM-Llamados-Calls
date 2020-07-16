using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class RubrosBL
    {
        //Capa de datos
        RubrosDAL daoRub = new RubrosDAL();



        public List<Rubros> ListarRubros()
        {
           return  daoRub.ListarRubros();
        }


        public Rubros GetRubros(int id)
        {
            return daoRub.GetRubros(id);
        }


        public void Crear(Rubros rub)
        {
            daoRub.Crear(rub);
        }



        public void Editar(Rubros rub)
        {
            daoRub.Editar(rub);
        }



        public void Eliminar(int id)
        {
            daoRub.Eliminar(id);
        }

    }
}
