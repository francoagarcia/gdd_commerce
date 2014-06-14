using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;
using FrbaCommerce.Entidades.Filtros;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DataAccess
{
    public class RubroDB : EntidadBaseDB<Rubro, FiltroRubros>
    {
        public RubroDB()
            : base(new BuilderRubro(), "rubro")
        { 
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(FiltroRubros filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter descripcion = new SqlParameter("@descripcion", System.Data.SqlDbType.NVarChar, 255, "descripcion");
            descripcion.Value = filtro.descripcion;
            parametros.Add(descripcion);

            return parametros;
        }
    }
}
