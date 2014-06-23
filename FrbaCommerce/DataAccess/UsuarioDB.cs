using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;
using FrbaCommerce.Entidades.Filtros;

namespace FrbaCommerce.DataAccess
{
    public class UsuarioDB : EntidadBaseDB<Usuario, FiltroUsuario>
    {
        public UsuarioDB()
            : base(new BuilderUsuarioFactura(), "Usuario") //Esto es para los filtros
        {
        }

        

        public void actualizarContraseniaPrimerIngreso(Usuario usuario) 
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            var id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            id_usuario.Value = usuario.id_usuario;
            parametros.Add(id_usuario);

            var contrasenia = new SqlParameter("@contrasenia", SqlDbType.NVarChar, 255, "contrasenia");
            contrasenia.Value = usuario.contrasenia;
            parametros.Add(contrasenia);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.actualizarContraseniaPrimerIngreso", parametros);
        }

        public bool puedeComprar(Usuario usuario) {

            IList<SqlParameter> parametros = new List<SqlParameter>();
            var id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            id_usuario.Value = usuario.id_usuario;
            parametros.Add(id_usuario);

            var puedeComprar = new SqlParameter("@puedeComprar", SqlDbType.Bit);
            puedeComprar.Direction = ParameterDirection.Output;
            parametros.Add(puedeComprar);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.puedeComprar", parametros);

            var puedeComprarOUTPUT = parametros.Where(p => p.ParameterName == "@puedeComprar").FirstOrDefault();
            bool puede_comprar = Convert.ToBoolean(puedeComprarOUTPUT.Value);
            return puede_comprar;
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroUsuario entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter username = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            username.Value = entidad.username;
            parametros.Add(username);

            SqlParameter telefono = new SqlParameter("@telefono", System.Data.SqlDbType.Decimal, 18, "telefono");
            if (entidad.telefono != null)
                telefono.Value = entidad.telefono;
            parametros.Add(telefono);

            return parametros;
        }

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
            Usuario usuario = new Usuario();
            usuario.username = Convert.ToString(dataSet.Tables[0].Rows[0]["username"]);
            usuario.contrasenia = Convert.ToString(dataSet.Tables[0].Rows[0]["contrasenia"]);
            usuario.habilitada = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["habilitada"]);
            usuario.cantidadIntentos = Convert.ToInt32(dataSet.Tables[0].Rows[0]["intentos_login"]);
            usuario.id_usuario = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["id_usuario"]);
            usuario.habilitada_comprar = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["habilitada_comprar"]);
            usuario.telefono = dataSet.Tables[0].Rows[0]["telefono"]!=System.DBNull.Value ? Convert.ToDecimal(dataSet.Tables[0].Rows[0]["telefono"]) : 0;
            return usuario;

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
