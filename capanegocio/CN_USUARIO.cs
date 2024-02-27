using capadedatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capadedatos;
using capaentidad;

namespace capanegocio
{
    public class CN_USUARIO
    {
        private CD_USUARIO objcd_usuario= new CD_USUARIO();

        public List<USUARIO> listar()
        {

            return objcd_usuario.listar();
        }

        public int Registrar(USUARIO obj, out String Mensaje)
        {
            Mensaje = String.Empty;

            if(obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";

            }

            if (obj.Nombrecompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";

            }

            if (obj.clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";

            }

            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);

            }


        }

        public bool Editar(USUARIO obj, out String Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";

            }

            if (obj.Nombrecompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";

            }

            if (obj.clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";

            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }


            
        }

        public bool Eliminar(USUARIO obj, out String Mensaje)
        {

            return objcd_usuario.Eliminar(obj, out Mensaje);
        }

    }
}
