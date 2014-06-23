using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Compra
    {
        public decimal id_compra {get; set;} 
        public Publicacion publicacion {get; set;} 
        public Usuario usuario_comprador {get; set;}
        public Calificacion calificacion { get; set; } 
        public DateTime? fecha {get; set;}
        public decimal cantidad;
    }
}
