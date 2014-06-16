using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;

namespace FrbaCommerce.DataAccess
{
    class ComprarOfertarDB
    {
        public DataSet dame_Publicaciones(int scroll, string descrip, string rubro) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDescripcion = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255, "descripcion");
            pDescripcion.Value = descrip;
            parametros.Add(pDescripcion);

            var pRubro = new SqlParameter("@rubro", SqlDbType.NVarChar, 255, "rubro");
            pRubro.Value = rubro;
            parametros.Add(pRubro);

            DataSet ds = HomeDB.ExecuteStoredProceduredPaginado(scroll, "DATA_GROUP.filtro_ComprasFalso2", parametros);

            return ds;


        }

        public DataSet dame_PublicacionesCantidad(string descrip, string rubro)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDescripcion = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255, "descripcion");
            pDescripcion.Value = descrip;
            parametros.Add(pDescripcion);

            var pRubro = new SqlParameter("@rubro", SqlDbType.NVarChar, 255, "rubro");
            pRubro.Value = rubro;
            parametros.Add(pRubro);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.filtro_ComprasFalso2", parametros);

            return ds;


        }
    }
}
