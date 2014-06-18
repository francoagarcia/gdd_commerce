using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class PreguntasDB
    {
        public IList<Preguntas> getPreguntasDeUnaPublicacion(Publicacion publi) 
        {
            IList<Preguntas> preguntas = new List<Preguntas>();
            BuilderPreguntas builder = new BuilderPreguntas();

            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter id_publicacion = new SqlParameter("@id_publicacion", SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion.Value = publi.id_publicacion;
            parametros.Add(id_publicacion);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getRespuestasDeUnaPublicacion", parametros);

            foreach (DataRow row in ds.Tables[0].Rows) {
                preguntas.Add(builder.Build(row));
            }
            return preguntas;
        }

        public decimal nuevaPreguntaEnPublicacion(Preguntas preg)
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(preg);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaPregunta", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_pregunta").FirstOrDefault();
            preg.id_pregunta = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return preg.id_pregunta;
        }

        private IList<SqlParameter> GenerarParametrosCrear(Preguntas preg) {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_pregunta = new SqlParameter("@id_pregunta", SqlDbType.Decimal, 18, "id_pregunta");
            id_pregunta.Direction = ParameterDirection.Output;
            parametros.Add(id_pregunta);

            var id_publicacion = new SqlParameter("@id_publicacion", SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion.Value = preg.id_publicacion;
            parametros.Add(id_publicacion);

            var id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            id_usuario.Value = preg.usuario.id_usuario;
            parametros.Add(id_usuario);

            var pregunta = new SqlParameter("@pregunta", SqlDbType.NVarChar, 255, "pregunta");
            pregunta.Value = preg.pregunta;
            parametros.Add(pregunta);

            var fecha_pregunta = new SqlParameter("@fecha_pregunta", SqlDbType.DateTime);
            fecha_pregunta.Value = preg.fecha_pregunta;
            fecha_pregunta.SourceColumn = "fecha_pregunta";
            parametros.Add(fecha_pregunta);

            return parametros;
        }

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
