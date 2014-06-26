using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderVisibilidadesFacturadas : IBuilder<VisibilidadesFacturadas>
    {
        public VisibilidadesFacturadas Build(System.Data.DataRow row) 
        {
            VisibilidadesFacturadas visiFactu = new VisibilidadesFacturadas();
            visiFactu.cantidad_fact = visiFactu.cantidad_marcada = Convert.ToDecimal(row["cantidad_fact"]);
            visiFactu.id_usuario = Convert.ToDecimal(row["id_usuario_fact"]);
            visiFactu.id_visibilidad_fact = Convert.ToDecimal(row["id_visibilidad_fact"]);
            visiFactu.descripcion = Convert.ToString(row["descripcion"]);
            return visiFactu;
        }
    }
}
