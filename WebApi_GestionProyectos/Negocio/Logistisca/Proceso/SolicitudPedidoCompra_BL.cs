using Entidades.Logistica.Procesos;
using Negocio.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logistisca
{
    public class SolicitudPedidoCompra_BL
    {
        public DataTable get_locales(string idUsuario)
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_Proy_M_Locales_Usuario", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = idUsuario;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt_detalle;
        }

        public DataTable get_delegaciones(string idUsuario )
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_Proy_M_Delegacion_Usuario", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = idUsuario;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt_detalle;
        }
        
        public DataTable get_centroCostos(string idUsuario)
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_Proy_W_CentroCostos", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = idUsuario;
                        cmd.Parameters.Add("@Delegacion", SqlDbType.VarChar).Value = "";

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt_detalle;
        }
        
        public DataTable get_estados(string idUsuario)
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_Proy_W_Estados_Orden_Compra", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = idUsuario;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt_detalle;
        }
        
        public DataTable get_usuariosLogisticas()
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_Proy_W_Usuario_Orden_Compra", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt_detalle;
        }


        public object get_solicitudesPedidoCompra_cab(string idLocal, string idDelegacion, string idCentroCosto, string fechaIni, string fechaFin, string nroPedido, string nroObra, string nombreSolicitante, string idEstado, string idUsuario)
        {
            List<SolicitudPedidoCompra_E> list_cabecera = new List<SolicitudPedidoCompra_E>();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_PROY_W_SOLICITUD_PEDIDO_COMPRA_LISTADO_CAB", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
 
                        cmd.Parameters.Add("@idLocal", SqlDbType.VarChar).Value = idLocal;
                        cmd.Parameters.Add("@idDelegacion", SqlDbType.VarChar).Value = idDelegacion;
                        cmd.Parameters.Add("@idCentroCosto", SqlDbType.VarChar).Value = idCentroCosto;
                        cmd.Parameters.Add("@fechaIni", SqlDbType.VarChar).Value = fechaIni;
                        cmd.Parameters.Add("@fechaFin", SqlDbType.VarChar).Value = fechaFin;

                        cmd.Parameters.Add("@nroPedido", SqlDbType.VarChar).Value = nroPedido;
                        cmd.Parameters.Add("@nroObra", SqlDbType.VarChar).Value = nroObra;
                        cmd.Parameters.Add("@nombreSolicitante", SqlDbType.VarChar).Value = nombreSolicitante;
                        cmd.Parameters.Add("@idEstado", SqlDbType.VarChar).Value = idEstado;
                        cmd.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = idUsuario;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                SolicitudPedidoCompra_E obj_entidad = new SolicitudPedidoCompra_E();
                                
                                obj_entidad.idPedidoCompra = Convert.ToInt32(dr["idPedidoCompra"].ToString());
                                obj_entidad.idEstado = dr["idEstado"].ToString();
                                obj_entidad.descripcionEstado = dr["descripcionEstado"].ToString();
                                obj_entidad.nroPedido = dr["nroPedido"].ToString();
                                obj_entidad.fecha = dr["fecha"].ToString();
                                obj_entidad.fechaHora_envioPedido = dr["fechaHora_envioPedido"].ToString();

                                obj_entidad.nroObra = dr["nroObra"].ToString();
                                obj_entidad.centroCosto = dr["centroCosto"].ToString();
                                obj_entidad.solicitante = dr["solicitante"].ToString();
                                obj_entidad.aprobadoJefe = dr["aprobadoJefe"].ToString();
                                obj_entidad.fechaAprobacionJefe = dr["fechaAprobacionJefe"].ToString();

                                obj_entidad.aprobadoGerente = dr["aprobadoGerente"].ToString();
                                obj_entidad.fechaAprobacionGerente = dr["fechaAprobacionGerente"].ToString();
                                obj_entidad.usuarioRechazo = dr["usuarioRechazo"].ToString();
                                obj_entidad.fechaRechazo = dr["fechaRechazo"].ToString();
                                obj_entidad.aprobadoLogistica = dr["aprobadoLogistica"].ToString();
                                obj_entidad.fechaAprobacionLogistica = dr["fechaAprobacionLogistica"].ToString();
                                                                                             
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
