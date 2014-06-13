using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderRubro : IBuilder<Rubro>
    {

        public Rubro Build(System.Data.DataRow row) {
            Rubro rubro = new Rubro();
            rubro.id_rubro = Convert.ToDecimal(row["id_rubro"]);
            rubro.descripcion = Convert.ToString(row["descripcion"]);
            return rubro;
        }
    }
}
