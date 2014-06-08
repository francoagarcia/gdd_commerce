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

        public bool Crear_Rol(string rol) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pRol = new SqlParameter("@nombreRolNuevo", SqlDbType.NVarChar, 255, "nombreRolNuevo");
            pRol.Value = rol;
            parametros.Add(pRol);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_crearRol", parametros);

            return true;
        }

        public DataSet Mostrar_Roles() {

            DataSet ds = (DataSet)HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodosLosRoles");
        return ds;
        }

        public bool Modificar_Rol(string nombreV, string nombreN) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pNombreVie = new SqlParameter("@nombreViejo ", SqlDbType.NVarChar, 255, "nombreViejo");
            pNombreVie.Value = nombreN;
            parametros.Add(pNombreVie);

            var pNombreNue = new SqlParameter("@nombreNuevo  ", SqlDbType.NVarChar, 255, "nombreNuevo");
            pNombreNue.Value = nombreN;
            parametros.Add(pNombreNue);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_modificar_Rol");

            return true;
        }

        public bool habilitar(string nom) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pHabili = new SqlParameter("@nombreRol  ", SqlDbType.NVarChar, 255, "nombreRol");
            pHabili.Value = nom;
            parametros.Add(pHabili);

            return true;
        }

        public bool deshabilitar(string nom)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pHabili = new SqlParameter("@nombreRol  ", SqlDbType.NVarChar, 255, "nombreRol");
            pHabili.Value = nom;
            parametros.Add(pHabili);

            return true;
        }

    }
}
