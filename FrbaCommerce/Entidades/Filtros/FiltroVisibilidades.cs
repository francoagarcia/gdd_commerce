using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Filtros
{
    public class FiltroVisibilidades
    {

        public string Nombre { get; set; }
        public decimal? Precio { get; set; } //El ? significa que admite valores null
        public decimal? Porcentaje { get; set; }

        public FiltroVisibilidades()
        {
            this.Precio = null;
            this.Porcentaje = null;
        }
    }
}
