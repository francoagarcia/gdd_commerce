using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Filtros
{
    public class FiltroEmpresa
    {
        public string CUIT { get; set; }
        public string razon_social { get; set; }
        public string mail { get; set; }
        public bool? habilitada { get; set; }
    }
}
