using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderVisibilidad : IBuilder<Visibilidad>
    {
        public Visibilidad Build(System.Data.DataRow row)
        {
            Visibilidad visibilidad = new Visibilidad();
            visibilidad.IdVisibilidad = Convert.ToDecimal(row["id_visibilidad"]);
            visibilidad.Descripcion = Convert.ToString(row["descripcion"]);
            visibilidad.Precio = Convert.ToDecimal(row["precio"]);
            visibilidad.Porcentaje = Convert.ToDecimal(row["porcentaje"]);
            visibilidad.Habilitada = Convert.ToBoolean(row["habilitada"]);
            return visibilidad;
        }
    }
}
