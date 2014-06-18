using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Oferta
    {
        public decimal id_oferta { get; set; }
        public Publicacion publicacion { get; set; }
        public Usuario usuario_ofertador { get; set; }
        public DateTime? fecha { get; set; }
        public decimal monto {get; set;}
    }
}
