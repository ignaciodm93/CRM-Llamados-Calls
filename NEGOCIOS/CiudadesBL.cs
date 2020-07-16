using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class CiudadesBL
    {

        //Creo el contexto:
        CiudadesDAL objCiudad = new CiudadesDAL();


        public List<Ciudades> ListarCiudades()
        {
            return objCiudad.ListarCiudades();
        }



        public Ciudades GetCiudades(int id)
        {
            return objCiudad.GetCiudad(id);
        }


        public void Crear(Ciudades city)
        {
            objCiudad.Crear(city);
        }


        public void Editar(Ciudades city)
        {          
            objCiudad.Editar(city);
        }

        public void Eliminar(int id)
        {
            objCiudad.Eliminar(id);
        }

    }
}
