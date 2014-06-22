using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class VisibilidadesFacturadas
    {
        public decimal id_visibilidad_fact { get; set; }
        public string descripcion { get; set; }
        public decimal id_usuario { get; set; }
        public decimal cantidad_fact { get; set; }
    }
}
