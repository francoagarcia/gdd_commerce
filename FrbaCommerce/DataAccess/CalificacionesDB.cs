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
    class CalificacionesDB
    {
        public DataSet dame_pubsXCalificar(Usuario usu)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usu.username;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getCalificaciones", parametros);

            return ds;

        }

        public void agrega_Calificaciones(Calificacion cali)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDetalle = new SqlParameter("@detalle", SqlDbType.NVarChar, 255, "detalle");
            pDetalle.Value = cali.comentario;
            parametros.Add(pDetalle);

            var pEstrella = new SqlParameter("@estrellas", SqlDbType.Decimal, 18, "estrellas");
            pEstrella.Value = cali.calificacion;
            parametros.Add(pEstrella);

            var pId = new SqlParameter("@id_calificacion", SqlDbType.Decimal, 18, "id_calificacion");
            pId.Value = cali.id_calificacion;
            parametros.Add(pId);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregrarCalificacion", parametros);

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
