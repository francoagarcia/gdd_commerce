using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.ConnectorDB;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace FrbaCommerce.DataAccess
{
    public class FacturacionDB
    {

        public decimal CrearFacturaCompleta( Factura factura, IList<ItemFactura> items) 
        {
            decimal nro_factura = this.crearNuevaFactura(factura);
            items.All(i => { i.nro_factura = nro_factura; return true; });
            foreach (ItemFactura item in items) 
            {
                this.crearNuevoItem(item);
            }
            return nro_factura;
        }


        public void crearNuevoItem(ItemFactura item) 
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrearItem(item);
            HomeDB.ExecuteStoredProcedured("DATA_GROUP.crearItemFactura", parametros);
        }

        public decimal crearNuevaFactura(Factura fact) 
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrearFactura(fact);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.crearFactura", parametros);

            var nro_factura_OUTPUT = parametros.Where(p => p.ParameterName == "@nro_factura").FirstOrDefault();
            fact.nro_factura = Convert.ToDecimal(nro_factura_OUTPUT.Value);
            return fact.nro_factura;
        }

        public IList<VisibilidadesFacturadas> getBonificados(Usuario usuario)
        {
            IList<VisibilidadesFacturadas> items = new List<VisibilidadesFacturadas>();
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario_fact");
            id_usuario.Value = usuario.id_usuario;
            parametros.Add(id_usuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getBonificados", parametros);
            BuilderVisibilidadesFacturadas builder = new BuilderVisibilidadesFacturadas();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                items.Add(builder.Build(row));
            }
            return items;
        }

        public IList<ItemPendiente> getPendientesDeFacturar(Usuario usuario) 
        {
            IList<ItemPendiente> items = new List<ItemPendiente>();
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario_publicador");
            id_usuario.Value = usuario.id_usuario;
            parametros.Add(id_usuario);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getPendientesDeFacturar", parametros);
            BuilderItemPendiente builder = new BuilderItemPendiente();
            foreach (DataRow row in ds.Tables[0].Rows) 
            {
                items.Add(builder.Build(row));
            }
            return items;
        }

        #region Generadores de parametros
        private IList<SqlParameter> GenerarParametrosCrearFactura(Factura fact)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var nro_factura = new SqlParameter("@nro_factura", SqlDbType.Decimal, 18, "nro_factura");
            nro_factura.Direction = ParameterDirection.Output;
            parametros.Add(nro_factura);

            var id_vendedor = new SqlParameter("@id_vendedor", SqlDbType.Decimal, 18, "id_vendedor");
            id_vendedor.Value = fact.vendedor.id_usuario;
            parametros.Add(id_vendedor);

            var total = new SqlParameter("@total", SqlDbType.Decimal);
            total.Precision = 18;
            total.Scale = 2;
            total.SourceColumn = "total";
            total.Value = fact.total;
            parametros.Add(total);

            var id_forma_pago = new SqlParameter("@id_forma_pago", SqlDbType.Decimal, 18, "id_forma_pago");
            id_forma_pago.Value = fact.forma_pago.Id;
            parametros.Add(id_forma_pago);

            var forma_pago_datos = new SqlParameter("@forma_pago_datos", SqlDbType.NVarChar, 255, "forma_pago_datos");
            forma_pago_datos.Value = fact.forma_pago_datos;
            parametros.Add(forma_pago_datos);

            return parametros;

        }

        private IList<SqlParameter> GenerarParametrosCrearItem(ItemFactura item)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var nro_factura = new SqlParameter("@nro_factura", SqlDbType.Decimal, 18, "nro_factura");
            nro_factura.Value = item.nro_factura;
            parametros.Add(nro_factura);

            var id_publicacion = new SqlParameter("@id_publicacion", SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion.Value = item.id_publicacion;
            parametros.Add(id_publicacion);

            var id_compra = new SqlParameter("@id_compra", SqlDbType.Decimal, 18, "id_compra");
            id_compra.Value = item.id_compra;
            parametros.Add(id_compra);

            var cantidad = new SqlParameter("@cantidad", SqlDbType.Decimal, 18, "cantidad");
            cantidad.Value = item.cantidad;
            parametros.Add(cantidad);

            var monto = new SqlParameter("@monto", SqlDbType.Decimal);
            monto.Precision = 18;
            monto.Scale = 2;
            monto.SourceColumn = "monto";
            monto.Value = item.monto;
            parametros.Add(monto);

            var resumen = new SqlParameter("@resumen", SqlDbType.NVarChar, 255, "resumen");
            resumen.Value = item.resumen;
            parametros.Add(resumen);

            return parametros;
        }
        #endregion


    }
}
