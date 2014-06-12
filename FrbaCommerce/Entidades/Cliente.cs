using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades
{
    public class Cliente : Usuario
    {
        public TipoDocumento tipo_documento{get; set;}
        public decimal nro_documento {get; set;}
        public decimal id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dom_calle { get; set; }
        public decimal piso { get; set; }
        public string depto { get; set; }
        public string localidad { get; set; }
        public string cod_postal { get; set; }
        public string mail { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public Sexo sexo { get; set; }
        public decimal? telefono { get; set; }
    }
}
