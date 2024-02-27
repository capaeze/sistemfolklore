using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class BUTACA
    {
        public int ID_butaca { get; set; }
        public int NroButaca { get; set; }
        public SECTORESTADIO oSECTORESTADIO { get; set; }
        public int Fila { get; set; }
        public string FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
