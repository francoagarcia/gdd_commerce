using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class ItemPendiente
    {
        public bool Facturar { get; set; } 
        public decimal id_publicacion {get; set;}
        public decimal id_compra {get; set;}
        public string tipo_item_a_facturar {get; set;}
        public string resumen {get; set;}
        public decimal cantidad_a_rendir {get; set;}
        public decimal importe_a_rendir {get; set;}
        public decimal id_visibilidad {get; set;}
        public DateTime fecha_inicio { get; set; }
    }
}
