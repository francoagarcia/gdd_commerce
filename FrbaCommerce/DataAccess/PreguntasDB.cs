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

        public void guarda_Pregunta(string pre, decimal id_pub, decimal id_usu)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pid_Pub = new SqlParameter("@id_pub", SqlDbType.Decimal, 18, "id_pub");
            pid_Pub.Value = id_pub;
            parametros.Add(pid_Pub);

            var pid_Usu = new SqlParameter("@id_usu", SqlDbType.Decimal, 18, "id_usu");
            pid_Usu.Value = id_usu;
            parametros.Add(pid_Usu);

            var pPregunta = new SqlParameter("@pregunta", SqlDbType.NVarChar, 400, "pregunta");
            pPregunta.Value = pre;
            parametros.Add(pPregunta);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregrarPregunta", parametros);
        }


    }
}
