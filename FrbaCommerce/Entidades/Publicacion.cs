using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades
{
    public class Publicacion
    {
        public decimal id_publicacion {get; set;}
        public string descripcion {get; set;}
        public decimal stock {get; set;}
        public DateTime fecha_inicio {get; set;}
        public DateTime fecha_vencimiento {get; set;}
        public decimal precio {get; set;}
        public bool permite_preguntas {get; set;}
        public TipoPublicacion tipo_publicacion {get; set;}
        public Visibilidad visibilidad {get; set;}
        public EstadoPublicacion estado {get; set;}
        public Usuario usuario_publicador {get; set;}
        public Rubro rubro {get; set;}
        public bool habilitada { get; set; }
    }
}
