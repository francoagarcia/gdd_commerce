using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data.SqlClient;
using System.Data;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class FuncionalidadDB
    {

        public static IList<Funcionalidad> getFuncionalidadesDeUnRol(decimal idRol)
        {

            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pIdRol = new SqlParameter("@id_rol", System.Data.SqlDbType.Decimal, 18, "id_rol");
            pIdRol.Value = idRol;
            parametros.Add(pIdRol);

            DataSet dataSet = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getFuncionalidadDeUnRol", parametros);

            List<Funcionalidad> funcionalidadesDeUnRol = new List<Funcionalidad>();
            BuilderFuncionalidad builder = new BuilderFuncionalidad();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                funcionalidadesDeUnRol.Add(builder.Build(row));
            }

            return funcionalidadesDeUnRol;
        }

        public DataSet pedir_func()
        {
            DataSet ds = (DataSet)HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodasLasFuncionalidades");
            return ds;
        }

        public bool funcionalidadXRol(string rol, string fun)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pRol_to = new SqlParameter("@rol_to_func", SqlDbType.NVarChar, 255, "rol_to_func");
            pRol_to.Value = rol;
            parametros.Add(pRol_to);

            var pFun_to = new SqlParameter("@func_to_rol", SqlDbType.NVarChar, 255, "func_to_rol");
            pFun_to.Value = fun;
            parametros.Add(pFun_to);

            //Ejecuto el stored procedure
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregarFuncionalidadXRol", parametros);

            return true;
        }
    }

}