using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades.Builder;
using System.Data.SqlClient;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.DataAccess
{
    public class EstadisticasDB
    {

        private const string VENDEDORES_CON_MAS_PRODUCTOS_NO_VENDIDOS = "DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos";
        private const string VENDEDORES_CON_MAYOR_FACTURACION = "DATA_GROUP.getTop5VendedoresConMayorFacturacion";
        private const string VENDEDORES_CON_MAYOR_CALIFICACION = "DATA_GROUP.getTop5VendedoresConMayorCalificaciones";
        private const string CLIENTES_CON_MAS_PUBLICACIONES_SIN_CALIFICAR = "DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar";

        public IList<int> getTodosAnios() {
            IList<int> todos = new List<int>();
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getTodosAnios");
            foreach (DataRow registro in ds.Tables[0].Rows)
            {
                todos.Add( Convert.ToInt32( registro["anio"]) );
            }
            return todos;
        }

        public DataSet getTop5VendedoresConMasProductosNoVendidos(Estadistica est) {
            return this.EjecutarConsulta(est, VENDEDORES_CON_MAS_PRODUCTOS_NO_VENDIDOS);
        }

        public DataSet getTop5VendedoresConMayorFacturacion(Estadistica est) {
            return this.EjecutarConsulta(est, VENDEDORES_CON_MAYOR_FACTURACION);
        }

        public DataSet getTop5VendedoresConMayorCalificaciones(Estadistica est) {
            return this.EjecutarConsulta(est, VENDEDORES_CON_MAYOR_CALIFICACION);
        }

        public DataSet getTop5ClientesConMasPublicacionesSinCalificar(Estadistica est) {
            return this.EjecutarConsulta(est, CLIENTES_CON_MAS_PUBLICACIONES_SIN_CALIFICAR);
        }

        private DataSet EjecutarConsulta(Estadistica est, string command)
        {
            IList<SqlParameter> parametros = this.GenerarParametrosListados(est);
            DataSet ds = HomeDB.ExecuteStoredProcedured(command, parametros);
            return ds;
        }

        private IList<SqlParameter> GenerarParametrosListados(Estadistica est)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var anio = new SqlParameter("@anio", SqlDbType.Int);
            anio.Value = est.anio;
            parametros.Add(anio);

            var trimestre = new SqlParameter("@trimestre", SqlDbType.Int, 4, "trimestre");
            trimestre.Value = est.trimestre;
            parametros.Add(trimestre);

            var mes = new SqlParameter("@mes", SqlDbType.Int);
            if(est.mes!=-1)
                mes.Value = est.mes;
            parametros.Add(mes);

            var visibilidad_desc = new SqlParameter("@visibilidad_desc", SqlDbType.Int);
            if (est.visibilidad != null)
            {
                visibilidad_desc.SourceColumn = "descripcion";
                visibilidad_desc.Value = est.visibilidad;
            }
            parametros.Add(visibilidad_desc);

            return parametros;
        }
        
    }
}
