using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Rol
    {
        public decimal idRol { get; set; }
        public string nombre { get; set; }
        public bool habilitada { get; set; }

        public Rol() { 
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
