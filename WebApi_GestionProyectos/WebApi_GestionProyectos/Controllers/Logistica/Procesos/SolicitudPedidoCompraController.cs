using Negocio.Logistisca;
using Negocio.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi_GestionProyectos.Controllers.Logistica.Procesos
{
    [EnableCors("*", "*", "*")]
    public class SolicitudPedidoCompraController : ApiController
    {
        public object GetSolicitudPedidoCompra(int opcion, string filtro)
        {
            Resultado res = new Resultado();
            SolicitudPedidoCompra_BL obj_negocio = new SolicitudPedidoCompra_BL();
            object resul = null;
            try
            {
                if (opcion == 1)
                {
                    string[] parametros = filtro.Split('|');
                    string idUsuario = parametros[0].ToString();                    

                    res.ok = true;
                    res.data = obj_negocio.get_locales(idUsuario);
                    res.totalpage = 0;

                    resul = res;
                }
                else if (opcion == 2)
                {
                    string[] parametros = filtro.Split('|');
                    string idUsuario = parametros[0].ToString();

                    res.ok = true;
                    res.data = obj_negocio.get_delegaciones(idUsuario);
                    res.totalpage = 0;

                    resul = res;
                }
                else if (opcion == 3)
                {
                    string[] parametros = filtro.Split('|');
                    string idUsuario = parametros[0].ToString();

                    res.ok = true;
                    res.data = obj_negocio.get_centroCostos(idUsuario);
                    res.totalpage = 0;

                    resul = res;
                }
                else if (opcion == 4)
                {
                    string[] parametros = filtro.Split('|');
                    string idUsuario = parametros[0].ToString();

                    res.ok = true;
                    res.data = obj_negocio.get_estados(idUsuario);
                    res.totalpage = 0;

                    resul = res;
                }
                else if (opcion == 5)
                {
                    string[] parametros = filtro.Split('|');
                    string idLocal = parametros[0].ToString();
                    string idDelegacion = parametros[1].ToString();
                    string idCentroCosto = parametros[2].ToString();

                    string fechaIni = parametros[3].ToString();
                    string fechaFin = parametros[4].ToString();
                    string nroPedido = parametros[5].ToString();

                    string nroObra = parametros[6].ToString();
                    string nombreSolicitante = parametros[7].ToString();
                    string idEstado = parametros[8].ToString();
                    string idUsuario = parametros[9].ToString();

                    res.ok = true;
                    res.data = obj_negocio.get_solicitudesPedidoCompra_cab(idLocal, idDelegacion, idCentroCosto, fechaIni, fechaFin, nroPedido, nroObra, nombreSolicitante, idEstado, idUsuario);
                    res.totalpage = 0;

                    resul = res;
                }
                else if (opcion == 6)
                {

                    res.ok = true;
                    res.data = obj_negocio.get_usuariosLogisticas();
                    res.totalpage = 0;

                    resul = res;
                }
                else
                {
                    res.ok = false;
                    res.data = "Opcion seleccionada invalida";
                    res.totalpage = 0;

                    resul = res;
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
                res.totalpage = 0;
                resul = res;
            }
            return resul;
        }
    }
}
