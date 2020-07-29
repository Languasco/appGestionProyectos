
using Negocio.Resultados;
using Negocio.Uploads;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi_GestionProyectos.Controllers.Upload
{
    [EnableCors("*", "*", "*")]
    public class UploadsController : ApiController
    {

        [HttpPost]
        [Route("api/Uploads/post_archivosOrdenCompra")]
        public object post_archivosOrdenCompra(string filtros)
        {
            Resultado res = new Resultado();
            int nombreFileBD;
            string sPath = "";

            try
            {
                //--- obteniendo los parametros que vienen por el FormData
                var file = HttpContext.Current.Request.Files["file"];
                //--- obteniendo los parametros que vienen por el FormData
                //string extension = Path.GetExtension(file.FileName);

                string[] parametros = filtros.Split('|');
 
                string idOrdenCompra = parametros[0].ToString();
                string nroOc = parametros[1].ToString();
                string tipoDoc = parametros[2].ToString();
                string opcionModal = parametros[3].ToString();
                string idUsuario = parametros[4].ToString();

                Upload_BL obj_negocios = new Upload_BL();
                nombreFileBD = obj_negocios.crear_archivoOrdenCompra(idOrdenCompra, nroOc, tipoDoc, opcionModal, file.FileName );

                //-------almacenando la archivo---
                sPath = HttpContext.Current.Server.MapPath("~/Archivos/OrdenCompra/" + nombreFileBD);
                file.SaveAs(sPath);

                //-------almacenando la archivo---
                if (File.Exists(sPath))
                {
                    res.ok = true;
                    res.data = "OK";
                    res.totalpage = 0;
                }
                else
                {
                    res.ok = false;
                    res.data = "No se pudo almacenar el archivo en el servidor";
                    res.totalpage = 0;
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
                res.totalpage = 0;
            }
            return res;
        }


    }
}
