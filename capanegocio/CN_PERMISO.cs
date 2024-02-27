using capaentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capadedatos;

namespace capanegocio
{
    public class CN_PERMISO
    {
        private CD_PERMISO objcd_permiso = new CD_PERMISO();

        public List<PERMISO> listar(int ID_usuario)
        {

            return objcd_permiso.listar(ID_usuario);
        }


    }
}
