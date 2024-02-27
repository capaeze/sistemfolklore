using capadedatos;
using capaentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capanegocio
{
    public class CN_ROL
    {
        private CD_ROL objcd_rol = new CD_ROL();

        public List<ROL> listar()
        {

            return objcd_rol.listar();
        }

    }
}
