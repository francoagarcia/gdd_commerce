using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Visibilidad
    {
        public decimal IdVisibilidad { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Habilitada { get; set; }
    }
    
}
