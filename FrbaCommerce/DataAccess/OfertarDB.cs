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
    public class OfertarDB
    {
        public decimal nuevaOferta(Oferta oferta)
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(oferta);
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.sp_nuevaOferta", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_oferta").FirstOrDefault();
            oferta.id_oferta = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return oferta.id_oferta;
        }

        private IList<SqlParameter> GenerarParametrosCrear(Oferta oferta)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_publicacion = new SqlParameter("@id_publicacion", SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion.Value = oferta.publicacion.id_publicacion;
            parametros.Add(id_publicacion);

            var id_usuario = new SqlParameter("@id_usuario_ofertador", SqlDbType.Decimal, 18, "id_usuario_ofertador");
            id_usuario.Value = oferta.usuario_ofertador.id_usuario;
            parametros.Add(id_usuario);

            var monto = new SqlParameter("@monto", SqlDbType.Decimal);
            monto.Scale = 2;
            monto.Precision = 18;
            monto.SourceColumn = "monto";
            monto.Value = oferta.monto;
            parametros.Add(monto);

            var id_oferta = new SqlParameter("@id_oferta", SqlDbType.Decimal, 18, "id_oferta");
            id_oferta.Direction = ParameterDirection.Output;
            parametros.Add(id_oferta);

            return parametros;
        }

    }
}
