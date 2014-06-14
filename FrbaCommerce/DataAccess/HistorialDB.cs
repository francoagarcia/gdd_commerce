using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.DataAccess
{
    public class HistorialDB
    {

        public DataSet pedir_Compras(Usuario usuarioActual)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usuarioActual.username;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodasComprasRealizadas", parametros);

            return ds;
        
        }

        public DataSet pedir_Ofertas(Usuario usuarioActual)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usuarioActual.username;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodasLasOfertasRealizadas", parametros);

            return ds;

        }

        public DataSet pedir_Calificaciones(Usuario usuarioActual)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usuarioActual.username;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getCalificacionesDelUsuario", parametros);

            return ds;
        }


    }
}
