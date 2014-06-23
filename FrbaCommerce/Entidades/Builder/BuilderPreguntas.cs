using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderPreguntas
    {

        public Preguntas Build(System.Data.DataRow row) {

            Preguntas preg = new Preguntas();
            preg.id_pregunta = Convert.ToDecimal(row["id_pregunta"]);
            preg.id_publicacion = Convert.ToDecimal(row["id_publicacion"]);
            preg.usuario = new Usuario();
            preg.usuario.id_usuario = Convert.ToDecimal(row["id_usuario"]);
            if (row.Table.Columns.Contains("username"))
                preg.usuario.username = Convert.ToString(row["username"]);
            if (row.Table.Columns.Contains("habilitada"))
                preg.usuario.habilitada = Convert.ToBoolean(row["habilitada"]);
            preg.pregunta = Convert.ToString(row["pregunta"]);
            preg.respuesta = row["respuesta"] != DBNull.Value ? Convert.ToString(row["respuesta"]) : "Sin responder";
            preg.fecha_pregunta = Convert.ToDateTime(row["fecha_pregunta"]);
            if (row["fecha_respuesta"] != DBNull.Value)
                preg.fecha_respuesta = Convert.ToDateTime(row["fecha_respuesta"]);

            return preg;
        }


    }
}
