using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Logistica.Procesos
{
    public class SolicitudOrdenCompra_E
    {
        public int idOrdenCompra { get; set; }
        public string tipoCompra { get; set; }
        public string fecha { get; set; }
        public string centroCosto { get; set; }
        public string proveedor { get; set; }
        public string moneda { get; set; }
        public string totalBase { get; set; }
        public string igv { get; set; }
        public string totalFinal { get; set; }
        public string usuarioLogistica { get; set; }
        public string idEstado { get; set; }
        public string descripcionEstado { get; set; }
        public string aprobadoGerente { get; set; }
        public string fechaAprobacionGerente { get; set; }
    }
}
