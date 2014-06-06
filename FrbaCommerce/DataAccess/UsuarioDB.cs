using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;

namespace FrbaCommerce.DataAccess
{
    public static class UsuarioDB
    {
        public static int RealizarIdentificacion(string nombre, string hashPassword)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsername = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsername.Value = nombre;
            parametros.Add(pUsername);

            var pPasswordHash = new SqlParameter("@passwordHash", SqlDbType.NVarChar, 255, "passwordHash");
            pPasswordHash.Value = hashPassword;
            parametros.Add(pPasswordHash);

            int resultado = -1;
            var pResultado = new SqlParameter("@resultado", SqlDbType.Int, 4, "resultado");
            pResultado.Direction = ParameterDirection.Output;
            pResultado.Value = resultado;
            parametros.Add(pResultado);

            //Ejecuto el stored procedure
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.realizar_identificacion", parametros);

            return (int)pResultado.Value;
        }
    }
}
