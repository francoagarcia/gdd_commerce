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
            visibilidad.id_visibilidad = Convert.ToDecimal(row["id_visibilidad"]);
            visibilidad.descripcion = Convert.ToString(row["descripcion"]);
            visibilidad.precio = Convert.ToDecimal(row["precio"]);
            visibilidad.porcentaje = Convert.ToDecimal(row["porcentaje"]);
            visibilidad.habilitada = Convert.ToBoolean(row["habilitada"]);
            return visibilidad;
        }
    }
}
