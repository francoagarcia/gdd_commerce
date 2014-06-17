using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class UsuarioDB
    {
        public static int RealizarLogin(string nombre, string hashPassword)
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

        public void inHabilitarUsuario(Usuario usuarioBaja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            id_usuario.Value = usuarioBaja.id_usuario;
            parametros.Add(id_usuario);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.inHabilitarUsuario", parametros);
            usuarioBaja.habilitada = false;
        }

        public void habilitarUsuario(Usuario usuarioBaja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            id_usuario.Value = usuarioBaja.id_usuario;
            parametros.Add(id_usuario);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.habilitarUsuario", parametros);
            usuarioBaja.habilitada = true;
        }

        public static Usuario ObtenerPorUsername(string username)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var pNombre = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pNombre.Value = username;
            parametros.Add(pNombre);

            var dataSet = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getUsuarioByUsername", parametros);

            BuilderUsuario builder = new BuilderUsuario();
            return builder.Build(dataSet.Tables[0].Rows[0]);

        }

        public static bool existeNombreDeUsuario(string username) {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            var pNombre = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pNombre.Value = username;
            parametros.Add(pNombre);

            int resultado = -1;
            var pResultado = new SqlParameter("@resultado", SqlDbType.Bit);
            pResultado.Value = resultado;
            pResultado.Direction = ParameterDirection.Output;
            parametros.Add(pResultado);

            var dataSet = HomeDB.ExecuteStoredProcedured("DATA_GROUP.existeUsuario", parametros);

            return ((bool)pResultado.Value);
        }

        public DataSet dame_TusDatos(decimal usu)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pU = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            pU.Value = usu;
            parametros.Add(pU);


            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getCliente", parametros);

            return ds;
        }
    }
}
