using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class PERMISO
    {
        public  int ID_permiso {  get; set; }

        public ROL oROL {  get; set; }

        public string NombreMenu {  get; set; }

        public string FechaRegistro {  get; set; }
    }
}
