using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.Entidades.Builder;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using FrbaCommerce.Generics.Excepciones;

namespace FrbaCommerce.DataAccess
{
    public class PublicacionDB : EntidadBaseDB<Publicacion, FiltroPublicacion>
    {
        public PublicacionDB() 
            : base(new BuilderPublicacion(), "Publicacion") 
        { 
        }

        public void modificarPublicacion(Publicacion publiMod) {
            IList<SqlParameter> parametros = this.GenerarParametrosModificar(publiMod);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.modificarPublicacion", parametros);
        }

        public decimal nuevaPublicacion(Publicacion publi) 
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(publi);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaPublicacion", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_publicacion_nueva").FirstOrDefault();
            if (idNuevoOUTPUT.Value != System.DBNull.Value)
            {
                publi.id_publicacion = Convert.ToDecimal(idNuevoOUTPUT.Value);
                return publi.id_publicacion;
            }
            else
            {
                throw new TresPublicacionesGratuitasException();
            }
        }

        #region [Generadores de parametros]
        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroPublicacion filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter descripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.NVarChar, 255, "descripcion");
            descripcion.Value = filtro.descripcion;
            parametros.Add(descripcion);

            SqlParameter fecha_inicio = new SqlParameter("@fecha_inicio", System.Data.SqlDbType.DateTime);
            if (filtro.fecha_inicio.HasValue)
                fecha_inicio.Value = filtro.fecha_inicio;
            fecha_inicio.SourceColumn = "fecha_inicio";
            parametros.Add(fecha_inicio);

            SqlParameter fecha_vencimiento = new SqlParameter("@fecha_vencimiento", System.Data.SqlDbType.DateTime);
            if (filtro.fecha_vencimiento.HasValue)
                fecha_vencimiento.Value = filtro.fecha_vencimiento;
            fecha_vencimiento.SourceColumn = "fecha_vencimiento";
            parametros.Add(fecha_vencimiento);

            SqlParameter id_visibilidad = new SqlParameter("@id_visibilidad", System.Data.SqlDbType.Decimal, 18, "id_visibilidad");
            if (filtro.visibilidad != null)
                id_visibilidad.Value = filtro.visibilidad.id_visibilidad;
            parametros.Add(id_visibilidad);

            SqlParameter id_estado = new SqlParameter("@id_estado", System.Data.SqlDbType.Decimal, 18, "id_estado");
            if (filtro.estado != null)
                id_estado.Value = filtro.estado.id_estado;
            parametros.Add(id_estado);

            SqlParameter id_rubro = new SqlParameter("@id_rubro", System.Data.SqlDbType.Decimal, 18, "id_rubro");
            if (filtro.rubro!=null)
                id_rubro.Value = filtro.rubro.id_rubro;
            parametros.Add(id_rubro);

            SqlParameter id_tipo_publicacion = new SqlParameter("@id_tipo_publicacion", System.Data.SqlDbType.Decimal, 18, "id_tipo_publicacion");
            if (filtro.tipo_publicacion!=null)
                id_tipo_publicacion.Value = filtro.tipo_publicacion.Id;
            parametros.Add(id_tipo_publicacion);

            SqlParameter id_usuario_publicador = new SqlParameter("@id_usuario_publicador", System.Data.SqlDbType.Decimal, 18, "id_usuario_publicador");
            if(filtro.id_usuario_publicador!=0)
                id_usuario_publicador.Value = filtro.id_usuario_publicador;
            parametros.Add(id_usuario_publicador);

            return parametros;
        }

        private IList<SqlParameter> GenerarParametrosModificar(Publicacion publiMod) {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_publicacion_modificar = new SqlParameter("@id_publicacion_modificar", System.Data.SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion_modificar.Value = publiMod.id_publicacion;
            parametros.Add(id_publicacion_modificar);

            SqlParameter descripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.NVarChar, 255, "descripcion");
            descripcion.Value = publiMod.descripcion;
            parametros.Add(descripcion);

            SqlParameter stock = new SqlParameter("@stock", System.Data.SqlDbType.Decimal);
            stock.SourceColumn = "stock";
            stock.Precision = 18;
            stock.Scale = 2;
            stock.Value = publiMod.stock;
            parametros.Add(stock);

            SqlParameter fecha_inicio = new SqlParameter("@fecha_inicio", System.Data.SqlDbType.DateTime);
            fecha_inicio.SourceColumn = "fecha_inicio";
            fecha_inicio.Value = publiMod.fecha_inicio;
            parametros.Add(fecha_inicio);

            SqlParameter fecha_vencimiento = new SqlParameter("@fecha_vencimiento", System.Data.SqlDbType.DateTime);
            fecha_vencimiento.SourceColumn = "fecha_vencimiento";
            fecha_vencimiento.Value = publiMod.fecha_vencimiento;
            parametros.Add(fecha_vencimiento);

            SqlParameter precio = new SqlParameter("@precio", System.Data.SqlDbType.Decimal);
            precio.SourceColumn = "precio";
            precio.Precision = 18;
            precio.Scale = 2;
            precio.Value = publiMod.precio;
            parametros.Add(precio);

            SqlParameter permite_preguntas = new SqlParameter("@permite_preguntas", System.Data.SqlDbType.Bit);
            permite_preguntas.SourceColumn = "permite_preguntas";
            permite_preguntas.Value = publiMod.permite_preguntas;
            parametros.Add(permite_preguntas);

            SqlParameter id_tipo_publicacion = new SqlParameter("@id_tipo_publicacion", System.Data.SqlDbType.Decimal, 18, "id_tipo_publicacion");
            id_tipo_publicacion.Value = publiMod.tipo_publicacion.Id;
            parametros.Add(id_tipo_publicacion);

            SqlParameter id_visibilidad = new SqlParameter("@id_visibilidad", System.Data.SqlDbType.Decimal, 18, "id_visibilidad");
            id_visibilidad.Value = publiMod.visibilidad.id_visibilidad;
            parametros.Add(id_visibilidad);

            SqlParameter id_estado = new SqlParameter("@id_estado", System.Data.SqlDbType.Decimal, 18, "id_estado");
            id_estado.Value = publiMod.estado.id_estado;
            parametros.Add(id_estado);

            SqlParameter id_rubro = new SqlParameter("@id_rubro", System.Data.SqlDbType.Decimal, 18, "id_rubro");
            id_rubro.Value = publiMod.rubro.id_rubro;
            parametros.Add(id_rubro);

            return parametros;
        }

        private IList<SqlParameter> GenerarParametrosCrear(Publicacion publi) {

            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_publicacion_nueva = new SqlParameter("@id_publicacion_nueva", System.Data.SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion_nueva.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(id_publicacion_nueva);

            SqlParameter descripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.NVarChar, 255, "descripcion");
            descripcion.Value = publi.descripcion;
            parametros.Add(descripcion);

            SqlParameter stock = new SqlParameter("@stock", System.Data.SqlDbType.Decimal);
            stock.SourceColumn = "stock";
            stock.Precision = 18;
            stock.Scale = 2;
            stock.Value = publi.stock;
            parametros.Add(stock);

            SqlParameter fecha_inicio = new SqlParameter("@fecha_inicio", System.Data.SqlDbType.DateTime);
            fecha_inicio.SourceColumn = "fecha_inicio";
            fecha_inicio.Value = publi.fecha_inicio;
            parametros.Add(fecha_inicio);

            SqlParameter fecha_vencimiento = new SqlParameter("@fecha_vencimiento", System.Data.SqlDbType.DateTime);
            fecha_vencimiento.SourceColumn = "fecha_vencimiento";
            fecha_vencimiento.Value = publi.fecha_vencimiento;
            parametros.Add(fecha_vencimiento);

            SqlParameter precio = new SqlParameter("@precio", System.Data.SqlDbType.Decimal);
            precio.SourceColumn = "precio";
            precio.Precision = 18;
            precio.Scale = 2;
            precio.Value = publi.precio;
            parametros.Add(precio);

            SqlParameter permite_preguntas = new SqlParameter("@permite_preguntas", System.Data.SqlDbType.Bit);
            permite_preguntas.SourceColumn = "permite_preguntas";
            permite_preguntas.Value = publi.permite_preguntas;
            parametros.Add(permite_preguntas);

            SqlParameter id_tipo_publicacion = new SqlParameter("@id_tipo_publicacion", System.Data.SqlDbType.Decimal, 18, "id_tipo_publicacion");
            id_tipo_publicacion.Value = publi.tipo_publicacion.Id;
            parametros.Add(id_tipo_publicacion);

            SqlParameter id_visibilidad = new SqlParameter("@id_visibilidad", System.Data.SqlDbType.Decimal, 18, "id_visibilidad");
            id_visibilidad.Value = publi.visibilidad.id_visibilidad;
            parametros.Add(id_visibilidad);

            SqlParameter id_estado = new SqlParameter("@id_estado", System.Data.SqlDbType.Decimal, 18, "id_estado");
            id_estado.Value = publi.estado.id_estado;
            parametros.Add(id_estado);

            SqlParameter id_usuario_publicador = new SqlParameter("@id_usuario_publicador", System.Data.SqlDbType.Decimal, 18, "id_usuario_publicador");
            id_usuario_publicador.Value = publi.usuario_publicador.id_usuario;
            parametros.Add(id_usuario_publicador);

            SqlParameter id_rubro = new SqlParameter("@id_rubro", System.Data.SqlDbType.Decimal, 18, "id_rubro");
            id_rubro.Value = publi.rubro.id_rubro;
            parametros.Add(id_rubro);

            SqlParameter habilitada = new SqlParameter("@habilitada", System.Data.SqlDbType.Bit);
            habilitada.SourceColumn = "habilitada";
            habilitada.Value = publi.habilitada;
            parametros.Add(habilitada);

            return parametros;
        }
        #endregion
    }
}
