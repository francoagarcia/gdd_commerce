using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class FuncionalidaXRol
    {
        public Rol rol { get; set; }
        public Funcionalidad funcionalidad { get; set; }
        public bool habilitada { get; set; }
    }
}
