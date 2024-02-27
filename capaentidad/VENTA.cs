using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class VENTA
    {
        public int ID_venta { get; set; }
        public USUARIO oUSUARIO { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCLiente { get; set; }
        public string NombreCLiente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public List<DETALLEVENTA> oDETALLEVENTA { get; set; }

        public string FechaRegistro { get; set; }

    }
}
