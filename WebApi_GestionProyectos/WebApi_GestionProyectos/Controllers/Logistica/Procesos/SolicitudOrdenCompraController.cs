using Negocio.Logistisca.Proceso;
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
    public class SolicitudOrdenCompraController : ApiController
    {

        public object GetSolicitudPedidoCompra(int opcion, string filtro)
        {
            Resultado res = new Resultado();
            SolicitudOrdenCompra_BL obj_negocio = new SolicitudOrdenCompra_BL();

            object resul = null;
            try
            {
 
                if (opcion == 1)
                {
                    string[] parametros = filtro.Split('|');
                    string idLocal = parametros[0].ToString();
                    string idDelegacion = parametros[1].ToString();
                    string idCentroCosto = parametros[2].ToString();

                    string fechaIni = parametros[3].ToString();
                    string fechaFin = parametros[4].ToString();
                    string nroOc = parametros[5].ToString();

                    string razonSocial = parametros[6].ToString();
                    string idusuarioLogistica = parametros[7].ToString();
                    string idEstado = parametros[8].ToString();
                    string idUsuario = parametros[9].ToString();

                    res.ok = true;
                    res.data = obj_negocio.get_solicitudes_ordenCompra_cab(idLocal, idDelegacion, idCentroCosto, fechaIni, fechaFin, nroOc, razonSocial, idusuarioLogistica, idEstado, idUsuario);
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
