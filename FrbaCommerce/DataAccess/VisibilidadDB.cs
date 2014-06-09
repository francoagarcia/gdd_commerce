using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;

namespace FrbaCommerce.DataAccess
{
    class VisibilidadDB
    {
        public bool crearVisibilidad(string desc, decimal prec, decimal porc) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDesc = new SqlParameter("@descripcion ", SqlDbType.NVarChar, 255, "descripcion ");
            pDesc.Value = desc;
            parametros.Add(pDesc);

            var pPrec = new SqlParameter("@precio ", SqlDbType.Decimal, 18, "precio");
            pPrec.Value = prec;
            parametros.Add(pPrec);

            var pPorc = new SqlParameter("@porcentaje ", SqlDbType.Decimal, 18, "porcentaje ");
            pPorc.Value = porc;
            parametros.Add(pPorc);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaVisibilidad", parametros);
            return true;
        }
    }
}
