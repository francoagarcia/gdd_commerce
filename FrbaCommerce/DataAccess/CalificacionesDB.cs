using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.DataAccess
{
    public class CalificacionesDB
    {

        public decimal nuevaCalificacion(Compra compra) 
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(compra);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaCalificacion", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_calificacion").FirstOrDefault();

            if (idNuevoOUTPUT.Value != System.DBNull.Value)
            {
                compra.calificacion.id_calificacion = Convert.ToDecimal(idNuevoOUTPUT.Value);
                return compra.calificacion.id_calificacion;
            }
            else 
            {
                return 0;
            }
        }

        private IList<SqlParameter> GenerarParametrosCrear(Compra compra) 
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_compra = new SqlParameter("@id_compra", SqlDbType.Decimal, 18, "id_compra");
            id_compra.Value = compra.id_compra;
            parametros.Add(id_compra);

            var estrellas_calificacion = new SqlParameter("@estrellas_calificacion", SqlDbType.Decimal, 18, "estrellas_calificacion");
            estrellas_calificacion.Value = compra.calificacion.estrellas_calificacion;
            parametros.Add(estrellas_calificacion);

            var detalle_calificacion = new SqlParameter("@detalle_calificacion", SqlDbType.NVarChar, 255, "detalle_calificacion");
            detalle_calificacion.Value = compra.calificacion.detalle_calificacion;
            parametros.Add(detalle_calificacion);

            var id_calificacion = new SqlParameter("@id_calificacion", SqlDbType.Decimal, 18, "id_calificacion");
            id_calificacion.Direction = ParameterDirection.Output;
            parametros.Add(id_calificacion);

            return parametros;


        }
    }
}
