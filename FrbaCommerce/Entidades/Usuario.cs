using System;
using System.Collections.Generic;
using System.Text;


namespace FrbaCommerce.Entidades
{
    public class Usuario
    {
        public decimal id_usuario { get; set; }
        public string username { get; set;}
        public decimal? telefono { get; set; }
        public string contrasenia { get; set; }
        public int cantidadIntentos { get; set; }
        public bool habilitada { get; set; }

        public Usuario()
        {
        }
    }
}
