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

        public IList<FuncionalidaXRol> getFuncDeUnRolHabilYNoHabilitadas(Rol unRol)
        {

            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pIdRol = new SqlParameter("@id_rol", System.Data.SqlDbType.Decimal, 18, "id_rol");
            pIdRol.Value = unRol.idRol;
            parametros.Add(pIdRol);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getFuncDeUnRolHabilYNoHabilitadas", parametros);

            List<FuncionalidaXRol> funcionalidades = new List<FuncionalidaXRol>();
            BuilderFuncionalidadXRol builder = new BuilderFuncionalidadXRol();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                funcionalidades.Add(builder.Build(row));
            }

            funcionalidades.All(f => { f.rol = unRol; return true; });

            return funcionalidades;
        }

        public DataSet pedir_func()
        {
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodasLasFuncionalidades");
            return ds;
        }

        public IList<Funcionalidad> getTodasFuncionalidades() {
            IList<Funcionalidad> list = new List<Funcionalidad>();
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodasLasFuncionalidades");

            BuilderFuncionalidad builder = new BuilderFuncionalidad();
            foreach (DataRow row in ds.Tables[0].Rows) {
                list.Add(builder.Build(row));
            }
            return list;        
        }
    }

}