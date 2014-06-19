using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades
{
    public class Factura
    {
        public decimal nro_factura {get; set;} 
        public Usuario vendedor {get; set;} 
        public DateTime fecha {get; set;} 
        public decimal total {get; set;}
        public FormaDePago forma_pago {get; set;}
        public string forma_pago_datos { get; set; }
    }
}
