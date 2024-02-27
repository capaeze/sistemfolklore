using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class ENTRADA
    {
        public int ID_entrada { get; set; }
        public string Codigo { get; set; }
        public CATEGORIA oCATEGORIA { get; set; }
        public decimal Precio_venta { get; set; }
        public string FechaRegistro { get; set; }
        public BUTACA oBUTACA { get; set; }
    }
}
