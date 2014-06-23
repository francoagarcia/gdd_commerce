using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    class BuilderCompra : IBuilder<Compra>
    {
        public Compra Build(System.Data.DataRow row) 
        {
            Compra compra = new Compra();
            compra.cantidad = Convert.ToDecimal(row["cantidad"]);
            compra.fecha = Convert.ToDateTime(row["fecha"]);
            compra.calificacion = new Calificacion();
            compra.calificacion.id_calificacion = row["id_calificacion"] != System.DBNull.Value ? Convert.ToDecimal(row["id_calificacion"]) : 0;
            if(row.Table.Columns.Contains("estrellas_calificacion"))
                compra.calificacion.estrellas_calificacion = row["estrellas_calificacion"] != System.DBNull.Value ? Convert.ToDecimal(row["estrellas_calificacion"]) : 0;
            if (row.Table.Columns.Contains("detalle_calificacion"))
            compra.calificacion.detalle_calificacion = row["detalle_calificacion"] != System.DBNull.Value ? Convert.ToString(row["detalle_calificacion"]) : string.Empty;
            compra.id_compra = Convert.ToDecimal(row["id_compra"]);
            compra.publicacion = new Publicacion();
            compra.publicacion.id_publicacion = Convert.ToDecimal(row["id_publicacion"]);
            compra.usuario_comprador = new Usuario();
            compra.usuario_comprador.id_usuario = Convert.ToDecimal(row["id_usuario_comprador"]);
            return compra;
        }
    }
}
