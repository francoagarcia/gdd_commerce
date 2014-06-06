using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class RolDB
    {
        public static List<Rol> ObtenerRoles(string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = username;
            parametros.Add(pUsuario);

            //Ejecuto el stored procedure
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getRolesDeUsuario", parametros);

            var roles = new List<Rol>();
            IBuilder<Rol> rolBuilder = new BuilderRol();
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                roles.Add(rolBuilder.Build(fila));
            }

            return roles;
        }
    }
}
