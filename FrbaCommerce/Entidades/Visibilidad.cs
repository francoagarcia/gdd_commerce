using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Visibilidad
    {
        public decimal id_visibilidad { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public decimal porcentaje { get; set; }
        public decimal dias_vencimiento_publi { get; set; }
        public bool habilitada { get; set; }
    }
    
}
