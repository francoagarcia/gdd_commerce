using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class VisibilidadDB : EntidadBaseDB<Visibilidad, FiltroVisibilidades>
    {

        public VisibilidadDB() 
            : base(new BuilderVisibilidad(), "Visibilidad") 
        {         
        
        }

        public decimal crearVisibilidad(Visibilidad visibilidad) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pDesc = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255, "descripcion");
            pDesc.Value = visibilidad.descripcion;
            parametros.Add(pDesc);

            SqlParameter pPrec = new SqlParameter("@precio", SqlDbType.Decimal);
            pPrec.Value = visibilidad.precio;
            pPrec.SourceColumn = "precio";
            pPrec.Precision = 18;
            pPrec.Scale = 2;
            parametros.Add(pPrec);

            SqlParameter pPorc = new SqlParameter("@porcentaje", SqlDbType.Decimal);
            pPorc.Value = visibilidad.porcentaje;
            pPorc.SourceColumn = "porcentaje";
            pPorc.Precision = 18;
            pPorc.Scale = 2;
            parametros.Add(pPorc);

            SqlParameter idNuevoOUTPUT = new SqlParameter("@id_visibilidad_agregado", SqlDbType.Decimal, 18);
            idNuevoOUTPUT.Direction = ParameterDirection.Output;
            parametros.Add(idNuevoOUTPUT);     

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.nuevaVisibilidad", parametros);
            visibilidad.id_visibilidad = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return Convert.ToDecimal(idNuevoOUTPUT);
        }

        public void inHabilitarVisibilidad(Visibilidad visi) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_visibilidad = new SqlParameter("@id_visibilidad", SqlDbType.Decimal, 18, "id_visibilidad");
            id_visibilidad.Value = visi.id_visibilidad;
            parametros.Add(id_visibilidad);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.inhabilitarVisibilidad", parametros);

            visi.habilitada = false;
        }

        public void habilitarVisibilidad(Visibilidad visi) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_visibilidad = new SqlParameter("@id_visibilidad", SqlDbType.Decimal, 18, "id_visibilidad");
            id_visibilidad.Value = visi.id_visibilidad;
            parametros.Add(id_visibilidad);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.habilitarVisibilidad", parametros);

            visi.habilitada = true;
        
        }

        public void modificarVisibilidad(Visibilidad visibilidadModificada) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_visibilidad = new SqlParameter("@id_visibilidad_a_modificar", SqlDbType.Decimal, 18, "id_visibilidad");
            id_visibilidad.Value = visibilidadModificada.id_visibilidad;
            parametros.Add(id_visibilidad);

            SqlParameter pDesc = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255, "descripcion");
            pDesc.Value = visibilidadModificada.descripcion;
            parametros.Add(pDesc);

            SqlParameter pPrec = new SqlParameter("@precio", SqlDbType.Decimal);
            pPrec.Value = visibilidadModificada.precio;
            pPrec.SourceColumn = "precio";
            pPrec.Precision = 18;
            pPrec.Scale = 2;
            parametros.Add(pPrec);

            SqlParameter pPorc = new SqlParameter("@porcentaje", SqlDbType.Decimal);
            pPorc.Value = visibilidadModificada.porcentaje;
            pPorc.SourceColumn = "porcentaje";
            pPorc.Precision = 18;
            pPorc.Scale = 2;
            parametros.Add(pPorc);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.modificarVisibilidad", parametros);        
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroVisibilidades filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var pDescripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.NVarChar, 255, "descripcion");
            if (!string.IsNullOrEmpty(filtro.Nombre))
            {
                pDescripcion.Value = filtro.Nombre;
                parametros.Add(pDescripcion);
            }

            var pPrecio = new SqlParameter("@precio", System.Data.SqlDbType.Decimal);
            if (filtro.Precio.HasValue)
            {
                pPrecio.Precision = 18;
                pPrecio.SourceColumn = "precio";
                pPrecio.Scale = 2;
                pPrecio.Value = filtro.Precio.Value;
                parametros.Add(pPrecio);
            }

            var pPorcentaje = new SqlParameter("@porcentaje", System.Data.SqlDbType.Decimal);
            if (filtro.Porcentaje.HasValue)
            {
                pPorcentaje.Precision = 18;
                pPorcentaje.SourceColumn = "porcentaje";
                pPorcentaje.Scale = 2;
                pPorcentaje.Value = filtro.Porcentaje.Value;
                parametros.Add(pPorcentaje);
            }
            return parametros;
        }
    }
}
