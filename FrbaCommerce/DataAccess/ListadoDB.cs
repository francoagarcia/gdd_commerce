using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;

namespace FrbaCommerce.DataAccess
{
    class ListadoDB
    {
        public DataSet pedimeLista(string lista, int ano, int tri)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pAnio = new SqlParameter("@anio", SqlDbType.Int, 4, "anio");
            pAnio.Value = ano;
            parametros.Add(pAnio);

            var pTrim = new SqlParameter("@trimestre", SqlDbType.Int, 4, "trimestre");
            pTrim.Value = tri;
            parametros.Add(pTrim);


            DataSet ds = HomeDB.ExecuteStoredProcedured(lista, parametros);

            return ds;
        }
    }
}
