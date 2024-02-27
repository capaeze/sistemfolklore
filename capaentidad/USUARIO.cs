using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class USUARIO
    {
        public int ID_usuario {  get; set; }
        public string Documento { get; set; }

        public string Nombrecompleto { get; set; }

        public string correo {  get; set; }

        public string clave { get; set; }

        public bool Estado { get; set; }

        public ROL oROL { get; set; }

        public string FechaRegistro { get; set; }

    }
}
