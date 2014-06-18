using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades
{
    public class Preguntas
    {
        public decimal id_pregunta {get; set;} 
        public decimal id_publicacion {get; set;} 
        public Usuario usuario {get; set;} 
        public string pregunta {get; set;} 
        public DateTime fecha_pregunta {get; set;} 
        public string respuesta {get; set;}
        public DateTime? fecha_respuesta { get; set; }
    }
}
