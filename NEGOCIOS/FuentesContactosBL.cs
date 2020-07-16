using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class FuentesContactosBL
    {



        public List<FuentesContacto> ListaFuentes()
        {
            FuentesContactosDAL dao = new FuentesContactosDAL();
            return dao.ListaFuentes();
        }


        public FuentesContacto Details(int id)
        {
            FuentesContactosDAL dao = new FuentesContactosDAL();
            return dao.Details(id);
        }


        public void Create(FuentesContacto fuenteNueva)
        {
            FuentesContactosDAL dao = new FuentesContactosDAL();
            dao.Create(fuenteNueva);
        }

        public void Editar(FuentesContacto fuenteExistente)
        {
            FuentesContactosDAL dao = new FuentesContactosDAL();
            dao.Edit(fuenteExistente);
        }

        public void Eliminar(int id)
        {
            FuentesContactosDAL dao = new FuentesContactosDAL();
            dao.Eliminar(id);
        }

    }
}
