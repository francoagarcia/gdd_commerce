using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderItemPendiente : IBuilder<ItemPendiente>
    {
        public ItemPendiente Build(System.Data.DataRow row) 
        {
            ItemPendiente item = new ItemPendiente();
            item.Facturar = Convert.ToBoolean(row["facturar"]);
            item.cantidad_a_rendir = Convert.ToDecimal(row["cantidad_a_rendir"]);
            item.fecha_inicio = Convert.ToDateTime(row["fecha_inicio"]);
            item.id_compra = Convert.ToDecimal(row["id_compra"]);
            item.id_publicacion = Convert.ToDecimal(row["id_publicacion"]);
            item.id_visibilidad = Convert.ToDecimal(row["id_visibilidad"]);
            item.importe_a_rendir = Convert.ToDecimal(row["importe_a_rendir"]);
            item.resumen = Convert.ToString(row["resumen"]);
            item.tipo_item_a_facturar = Convert.ToString(row["tipo_item_a_facturar"]);
            return item;
        }
    }
}
