using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class DETALLEVENTA
    {
        public int ID_detalleventa { get; set; }
        public ENTRADA oENTRADA { get; set; }
        public decimal Precio_venta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public string FechaRegistro { get; set; }
    }
}
