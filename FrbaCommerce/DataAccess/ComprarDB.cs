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
    public class ComprarDB
    {

        public decimal nuevaCompra(Compra comp) {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(comp);
            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.sp_nuevaCompra", parametros);

            var idNuevoOUTPUT = parametros.Where(p => p.ParameterName == "@id_compra_nueva").FirstOrDefault();
            comp.id_compra = Convert.ToDecimal(idNuevoOUTPUT.Value);
            return comp.id_compra;
        }

        private IList<SqlParameter> GenerarParametrosCrear(Compra comp) {
            
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var id_publicacion = new SqlParameter("@id_publicacion", SqlDbType.Decimal, 18, "id_publicacion");
            id_publicacion.Value = comp.publicacion.id_publicacion;
            parametros.Add(id_publicacion);

            var id_usuario = new SqlParameter("@id_usuario", SqlDbType.Decimal, 18, "id_usuario");
            id_usuario.Value = comp.usuario_comprador.id_usuario;
            parametros.Add(id_usuario);

            var cantidad = new SqlParameter("@cantidad", SqlDbType.Decimal, 18, "cantidad");
            cantidad.Value = comp.cantidad;
            parametros.Add(cantidad);

            var id_compra_nueva = new SqlParameter("@id_compra_nueva", SqlDbType.Decimal, 18, "id_compra");
            id_compra_nueva.Direction = ParameterDirection.Output;
            parametros.Add(id_compra_nueva);

            return parametros;
        }

        public DataSet dame_Publicaciones(int scroll, string descrip, string rubro) {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDescripcion = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255, "descripcion");
            pDescripcion.Value = descrip;
            parametros.Add(pDescripcion);

            var pRubro = new SqlParameter("@rubro", SqlDbType.NVarChar, 255, "rubro");
            pRubro.Value = rubro;
            parametros.Add(pRubro);

            DataSet ds = HomeDB.ExecuteStoredProceduredPaginado(scroll, "DATA_GROUP.filtro_ComprasFalso2", parametros);

            return ds;
        }

        public DataSet dame_PublicacionesCantidad(string descrip, string rubro)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pDescripcion = new SqlParameter("@descripcion", SqlDbType.NVarChar, 255, "descripcion");
            pDescripcion.Value = descrip;
            parametros.Add(pDescripcion);

            var pRubro = new SqlParameter("@rubro", SqlDbType.NVarChar, 255, "rubro");
            pRubro.Value = rubro;
            parametros.Add(pRubro);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.filtro_ComprasFalso2", parametros);

            return ds;

        }

        public void update_Publicacion(decimal id_pub, decimal stk)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pid_Pub = new SqlParameter("@id_pub", SqlDbType.Decimal, 18, "id_pub");
            pid_Pub.Value = id_pub;
            parametros.Add(pid_Pub);

            var pStk = new SqlParameter("@stk", SqlDbType.Decimal, 18, "stk");
            pStk.Value = stk;
            parametros.Add(pStk);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_actualizarPublicacion", parametros);
        }

        public void agregar_Compra(decimal id_pub, decimal id_usu, decimal can)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pid_Pub = new SqlParameter("@id_pub", SqlDbType.Decimal, 18, "id_pub");
            pid_Pub.Value = id_pub;
            parametros.Add(pid_Pub);

            var pUs = new SqlParameter("@id_usu", SqlDbType.Decimal, 18, "id_usu");
            pUs.Value = id_usu;
            parametros.Add(pUs);


            var pCa = new SqlParameter("@cant", SqlDbType.Decimal, 18, "cant");
            pCa.Value = can;
            parametros.Add(pCa);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregrarCompra", parametros);
        }

        public void agregar_Oferta(decimal id_pub, decimal id_usu, decimal oferta)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pid_Pub = new SqlParameter("@id_pub", SqlDbType.Decimal, 18, "id_pub");
            pid_Pub.Value = id_pub;
            parametros.Add(pid_Pub);

            var pUs = new SqlParameter("@id_usu", SqlDbType.Decimal, 18, "id_usu");
            pUs.Value = id_usu;
            parametros.Add(pUs);


            var pMonto = new SqlParameter("@mont", SqlDbType.Decimal, 18, "mont");
            pMonto.Value = oferta;
            parametros.Add(pMonto);

            HomeDB.ExecuteStoredProcedured("DATA_GROUP.SP_agregrarOferta", parametros);
        }

        public DataSet get_Monto(decimal id_pub)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            var pid_Pub = new SqlParameter("@id_pub", SqlDbType.Decimal, 18, "id_pub");
            pid_Pub.Value = id_pub;
            parametros.Add(pid_Pub);

            DataSet ds = HomeDB.ExecuteStoredProcedured("DATA_GROUP.getOfertaMayor", parametros);
            return ds;
        }
    }
}
