using Entidades.Logistica.Procesos;
using Negocio.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logistisca.Proceso
{
    public class OrdenCompraAprobar_BL
    {

        public object get_ordenCompraAdjuntarCab(string nroOC)
        {
            List<OrdenCompraCab_E> list_detalle = new List<OrdenCompraCab_E>();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_PROY_W_ORDENCOMPRA_APROBAR_CAB", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nroOC", SqlDbType.VarChar).Value = nroOC;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                OrdenCompraCab_E obj_entidad = new OrdenCompraCab_E();

                                obj_entidad.idOrdenCompra = dr["idOrdenCompra"].ToString();

                                obj_entidad.tipoOc = dr["tipoOc"].ToString();
                                obj_entidad.nroOC = dr["nroOC"].ToString();
                                obj_entidad.fechaEmision = dr["fechaEmision"].ToString();
                                obj_entidad.moneda = dr["moneda"].ToString();

                                obj_entidad.subTotal = dr["subTotal"].ToString();
                                obj_entidad.igv = dr["igv"].ToString();
                                obj_entidad.total = dr["total"].ToString();
                                
                                obj_entidad.formaPago = dr["formaPago"].ToString();
                                obj_entidad.proveedor = dr["proveedor"].ToString();

                                obj_entidad.aprobadorJefe = dr["aprobadorJefe"].ToString();
                                obj_entidad.solicitante = dr["solicitante"].ToString();

                                list_detalle.Add(obj_entidad);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list_detalle;
        }


        public object get_ordenCompraAdjuntarDet(string idOrdenCompra)
        {
            List<OrdenCompraCab_E> list_detalle = new List<OrdenCompraCab_E>();
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_PROY_W_ORDENCOMPRA_APROBAR_DET", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idOrdenCompraCab", SqlDbType.VarChar).Value = idOrdenCompra;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                OrdenCompraCab_E obj_entidad = new OrdenCompraCab_E();

                                obj_entidad.idOrdenCompra = dr["idOrdenCompra"].ToString();

                                obj_entidad.tipoOc = dr["tipoOc"].ToString();
                                obj_entidad.nroOC = dr["nroOC"].ToString();
                                obj_entidad.fechaEmision = dr["fechaEmision"].ToString();
                                obj_entidad.moneda = dr["moneda"].ToString();

                                obj_entidad.subTotal = dr["subTotal"].ToString();
                                obj_entidad.igv = dr["igv"].ToString();
                                obj_entidad.total = dr["total"].ToString();

                                obj_entidad.formaPago = dr["formaPago"].ToString();
                                obj_entidad.proveedor = dr["proveedor"].ToString();

                                obj_entidad.aprobadorJefe = dr["aprobadorJefe"].ToString();
                                obj_entidad.solicitante = dr["solicitante"].ToString();

                                list_detalle.Add(obj_entidad);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list_detalle;
        }

    }
}
