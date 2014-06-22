using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Builder;
using FrbaCommerce.Entidades.Filtros;

namespace FrbaCommerce.DataAccess
{
    public class RolDB : EntidadBaseDB<Rol, FiltroRol>
    {
        public RolDB()
            : base(new BuilderRol(), "rol")
        {
        }

        

        public List<Rol> ObtenerRoles(string username)
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

        public void crearRolCompleto(Rol rol, IList<FuncionalidaXRol> list_fun_rol) 
        {

            decimal id_rol = this.crearRolNombre(rol);
            list_fun_rol.All(fr => { fr.rol.idRol = id_rol;  return true; });
            this.crearFuncionalidadesPorRol(list_fun_rol);
        
        }

        public void crearFuncionalidadesPorRol(IList<FuncionalidaXRol> list_fun_rol)
        {
            foreach (FuncionalidaXRol fun_rol in list_fun_rol)
            {
                IList<SqlParameter> parametros = this.GenerarParametrosCrearFuncXRol(fun_rol);
                HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregarFuncionalidadXRol", parametros);
            }
        }

        public decimal crearRolNombre(Rol rol)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var nombreRolNuevo = new SqlParameter("@nombreRolNuevo", SqlDbType.NVarChar, 255, "nombreRolNuevo");
            nombreRolNuevo.Value = rol.nombre;
            parametros.Add(nombreRolNuevo);

            var habilitada = new SqlParameter("@habilitada", SqlDbType.Bit);
            habilitada.Value = rol.habilitada;
            habilitada.SourceColumn = "habilitada";
            parametros.Add(habilitada);

            var id_rol_nuevo = new SqlParameter("@id_rol_nuevo", SqlDbType.Decimal, 18, "id_rol");
            id_rol_nuevo.Direction = ParameterDirection.Output;
            parametros.Add(id_rol_nuevo);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_crearRol", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_rol_nuevo").FirstOrDefault();
            rol.idRol = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return rol.idRol;
        }

        public DataSet Mostrar_Roles() {

            DataSet ds = (DataSet)HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodosLosRoles");
        return ds;
        }

        public void modificarRolConFuncionalidades(Rol rol, IList<FuncionalidaXRol> list_fun_rol)
        {
            this.modificarNombreRol(rol);
            this.modificarFuncionalidadesDeUnRol(list_fun_rol);
        }
        
        private void modificarNombreRol(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var id_rol = new SqlParameter("@id_rol ", SqlDbType.Decimal, 18, "id_rol");
            id_rol.Value = rol.idRol;
            parametros.Add(id_rol);

            var nombre = new SqlParameter("@nombre", SqlDbType.NVarChar, 255, "nombre");
            nombre.Value = rol.nombre;
            parametros.Add(nombre);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.modificarRol", parametros);

        }

        private void modificarFuncionalidadesDeUnRol(IList<FuncionalidaXRol> list_fun_rol)
        {
            foreach (FuncionalidaXRol fun_rol in list_fun_rol) 
            {
                IList<SqlParameter> parametros = this.GenerarParametrosCrearFuncXRol(fun_rol);
                HomeDB.ExecuteStoredProcedured("DATA_GROUP.modificarFuncionalidadDeUnRol", parametros);
            }
        }

        public void habilitarRol(Rol rol)
        {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_rol = new SqlParameter("@id_rol", SqlDbType.Decimal, 18, "id_rol");
            id_rol.Value = rol.idRol;
            parametros.Add(id_rol);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_habilitarRol", parametros);
        }

        public void deshabilitarRol(Rol rol)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_rol = new SqlParameter("@id_rol", SqlDbType.Decimal, 18, "id_rol");
            id_rol.Value = rol.idRol;
            parametros.Add(id_rol);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_deshabilitarRol", parametros);
        }


        #region Generadores de parametros
        private IList<SqlParameter> GenerarParametrosCrearFuncXRol(FuncionalidaXRol fun_rol) 
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_rol = new SqlParameter("@id_rol ", SqlDbType.Decimal, 18, "id_rol");
            id_rol.Value = fun_rol.rol.idRol;
            parametros.Add(id_rol);

            var id_funcionalidad = new SqlParameter("@id_funcionalidad ", SqlDbType.Decimal, 18, "id_funcionalidad");
            id_funcionalidad.Value = fun_rol.funcionalidad.IdFuncionalidad;
            parametros.Add(id_funcionalidad);

            var habilitada = new SqlParameter("@habilitada ", SqlDbType.Bit);
            habilitada.Value = fun_rol.habilitada;
            habilitada.SourceColumn = "habilitada";
            parametros.Add(habilitada);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroRol entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var nombre = new SqlParameter("@nombre", SqlDbType.NVarChar, 255, "nombre");
            nombre.Value = entidad.nombre;
            parametros.Add(nombre);

            return parametros;
        }
        #endregion

    }
}
