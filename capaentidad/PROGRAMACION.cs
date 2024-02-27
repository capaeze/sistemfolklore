using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class PROGRAMACION
    {
        public int ID_programacion { get; set; }
        public GRUPOMUSICAL oGRUPOMUSICAL { get; set; }

        public NOCHEFESTIVAL oNOCHEFESTIVAL { get; set; }

        public string FechaRegistro { get; set; }
    }
}
