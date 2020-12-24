using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Logistica.Procesos
{
    public class SolicitudPedidoCompra_E
    {
        public int idPedidoCompra { get; set; }
        public string idEstado { get; set; }
        public string descripcionEstado { get; set; }
        public string nroPedido { get; set; }

        public string fecha { get; set; }
        public string fechaHora_envioPedido { get; set; }
        public string nroObra { get; set; }
        public string centroCosto { get; set; }
        public string solicitante { get; set; }
        public string aprobadoJefe { get; set; }
        public string fechaAprobacionJefe { get; set; }
        public string aprobadoGerente { get; set; }
        public string fechaAprobacionGerente { get; set; }
        public string usuarioRechazo { get; set; }
        public string fechaRechazo { get; set; }
        public string aprobadoLogistica { get; set; }
        public string fechaAprobacionLogistica { get; set; }
    }
}
