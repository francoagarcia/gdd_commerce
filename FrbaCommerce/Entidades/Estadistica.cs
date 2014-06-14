using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Estadistica
    {
        public int anio { get; set; }
        public int mes { get; set; }
        public int trimestre { get; set; }
        public string visibilidad { get; set; }
        public IList<Usuario> resultado { get; set; }
    }
}
