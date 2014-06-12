using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Empresa : Usuario
    {
        public string cuit { get; set; }
        public string razon_social { get; set; }
        public string nombre_de_contacto { get; set; }
        public string dom_calle { get; set; }
        public decimal piso { get; set; }
        public string depto { get; set; }
        public string localidad { get; set; }
        public string cod_postal { get; set; }
        public string mail { get; set; }
        public DateTime fecha_creacion { get; set; }
        public decimal telefono { get; set; }
        public string ciudad { get; set; }
    }
}
