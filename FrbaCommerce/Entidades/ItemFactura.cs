using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class ItemFactura
    {
        public decimal nro_factura { get; set; }
        public decimal id_publicacion {get; set;}
        public decimal id_compra {get; set;} 
        public decimal cantidad {get; set;} 
        public decimal monto {get; set;}
        public string resumen { get; set; }
    }
}
