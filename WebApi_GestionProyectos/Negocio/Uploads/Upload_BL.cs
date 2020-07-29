using Negocio.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Uploads
{
    public class Upload_BL
    {        
        public int crear_archivoOrdenCompra( string idOrdenCompra, string nroOc, string tipoDoc, string opcionModal,string nombreArchivo)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(bdConexion.cadenaBDcx()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DSIGE_PROY_W_ORDENCOMPRA_ADJUNTAR_GRABAR", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idOrdenCompra", SqlDbType.VarChar).Value = idOrdenCompra;
                        cmd.Parameters.Add("@nroOc", SqlDbType.VarChar).Value = nroOc;
                        cmd.Parameters.Add("@tipoDoc", SqlDbType.VarChar).Value = tipoDoc;
                        cmd.Parameters.Add("@opcionImportacion", SqlDbType.Int).Value = (opcionModal == "cotizacion") ? 1 : 2 ;
                        cmd.Parameters.Add("@nombreArchivo", SqlDbType.VarChar).Value = nombreArchivo;
                        cmd.Parameters.Add("@name_bd", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        resultado = Convert.ToInt32(cmd.Parameters["@name_bd"].Value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }


    }
}
