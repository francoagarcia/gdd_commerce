using System;
using System.Collections.Generic;
using System.Text;


namespace FrbaCommerce.Entidades
{
    public class Usuario
    {
        //public decimal id;
        public string username { get; set;}
        public string contrasenia { get; set; }
        public int cantidadIntentos { get; set; }
        public bool habilitada { get; set; }

        public Usuario()
        {
        }
    }
}
