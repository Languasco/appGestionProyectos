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
    public class OrdenCompraAprobarController : ApiController
    {
        public object GetOrdenCompraAdjuntar(int opcion, string filtro)
        {
            Resultado res = new Resultado();
            object resul = null;
            try
            {
                if (opcion == 1)
                {
                    string[] parametros = filtro.Split('|');

                    string nroOC = parametros[0].ToString();

                    OrdenCompraAprobar_BL obj_negocio = new OrdenCompraAprobar_BL();
                    res.ok = true;
                    res.data = obj_negocio.get_ordenCompraAdjuntarCab(nroOC);
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
