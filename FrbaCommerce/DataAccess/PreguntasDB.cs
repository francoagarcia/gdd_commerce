using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;

namespace FrbaCommerce.DataAccess
{
    class PreguntasDB
    {
        public DataSet dame_Preguntas(string usuario)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usuario;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getPreguntas", parametros);

            return ds;

        }

        public DataSet dame_Respuestas(string usuario)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@username", SqlDbType.NVarChar, 255, "username");
            pUsuario.Value = usuario;
            parametros.Add(pUsuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getRespuestas", parametros);

            return ds;

        }

        public void guarda_Respuesta(decimal id, string resp)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pId = new SqlParameter("@id_pregunta", SqlDbType.Decimal, 18, "id_pregunta");
            pId.Value = id;
            parametros.Add(pId);

            var pRespuesta = new SqlParameter("@respuesta ", SqlDbType.NVarChar, 400, "respuesta");
            pRespuesta.Value = resp;
            parametros.Add(pRespuesta);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.getRespuestas", parametros);
        }
    }
}
