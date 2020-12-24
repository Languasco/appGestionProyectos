using Entidades.Logistica.Procesos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logistisca.Proceso
{
    public class SolicitudOrdenCompra_BL
    {
        public object get_solicitudes_ordenCompra_cab(string idLocal, string idDelegacion, string idCentroCosto, string fechaIni, string fechaFin, string nroOc, string razonSocial, string idusuarioLogistica, string idEstado, string idUsuario)
        {
            List<SolicitudOrdenCompra_E> list_cabecera = new List<SolicitudOrdenCompra_E>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_PROY_W_SOLICITUD_ORDEN_COMPRA_LISTADO_CAB", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idLocal", SqlDbType.VarChar).Value = idLocal;
                        cmd.Parameters.Add("@idDelegacion", SqlDbType.VarChar).Value = idDelegacion;
                        cmd.Parameters.Add("@idCentroCosto", SqlDbType.VarChar).Value = idCentroCosto;
                        cmd.Parameters.Add("@fechaIni", SqlDbType.VarChar).Value = fechaIni;
                        cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = fechaFin;

                        cmd.Parameters.Add("@nroOc", SqlDbType.VarChar).Value = nroOc;
                        cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar).Value = razonSocial;
                        cmd.Parameters.Add("@idusuarioLogistica", SqlDbType.VarChar).Value = idusuarioLogistica;
                        cmd.Parameters.Add("@idEstado", SqlDbType.VarChar).Value = idEstado;
                        cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = idUsuario;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SolicitudOrdenCompra_E obj_entidad = new SolicitudOrdenCompra_E();

                                    obj_entidad.idOrdenCompra = Convert.ToInt32(dr["idOrdenCompra"].ToString()); 
                                    obj_entidad.tipoCompra = dr["tipoCompra"].ToString();
                                    obj_entidad.fecha = dr["fecha"].ToString();
                                    obj_entidad.centroCosto = dr["centroCosto"].ToString();
                                    obj_entidad.proveedor = dr["proveedor"].ToString();
                                    obj_entidad.moneda = dr["moneda"].ToString();

                                    obj_entidad.totalBase = dr["totalBase"].ToString();
                                    obj_entidad.igv = dr["igv"].ToString();
                                    obj_entidad.totalFinal = dr["totalFinal"].ToString();
                                    obj_entidad.usuarioLogistica = dr["usuarioLogistica"].ToString();
                                    obj_entidad.idEstado = dr["idEstado"].ToString();

                                    obj_entidad.descripcionEstado = dr["descripcionEstado"].ToString();
                                    obj_entidad.aprobadoGerente = dr["aprobadoGerente"].ToString();
                                    obj_entidad.fechaAprobacionGerente = dr["fechaAprobacionGerente"].ToString();

                                list_cabecera.Add(obj_entidad);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list_cabecera;
        }
        
    }
}
