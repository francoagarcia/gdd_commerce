using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;

namespace FrbaCommerce.DataAccess
{
    class CalificacionesDB
    {
        public DataSet dame_Calificaciones(string usuario)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usuario;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getCalificaciones", parametros);

            return ds;

        }

        public decimal agrega_Calificaciones(string detalle, decimal estrellas)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDetalle = new SqlParameter("@detalle", SqlDbType.NVarChar, 255, "detalle");
            pDetalle.Value = detalle;
            parametros.Add(pDetalle);

            var pEstrella = new SqlParameter("@estrellas", SqlDbType.Decimal, 18, "estrellas");
            pEstrella.Value = estrellas;
            parametros.Add(pEstrella);

            decimal id_calificacion = -1;
            var pId = new SqlParameter("@id_calificacion", SqlDbType.Decimal, 18, "id_calificacion");
            pId.Value = id_calificacion;
            parametros.Add(pId);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregrarCalificacion", parametros);

            return (decimal)pId.Value;

        }

        public void actualizar_Compras(decimal calificacion, decimal compra)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pCalifica = new SqlParameter("@id_calificacion", SqlDbType.Decimal, 18, "id_calificacion");
            pCalifica.Value = calificacion;
            parametros.Add(pCalifica);

            var pCompra = new SqlParameter("@id_compra", SqlDbType.Decimal, 18, "id_compra");
            pCompra.Value = compra;
            parametros.Add(pCompra);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_actualizarCompra", parametros);
        }
    }
}
