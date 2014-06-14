using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades.Filtros
{
    public class FiltroPublicacion
    {
        public string descripcion { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_vencimiento { get; set; }
        public Rubro rubro { get; set; }
        public EstadoPublicacion estado { get; set; }
        public Visibilidad visibilidad { get; set; }
        public TipoPublicacion tipo_publicacion { get; set; }
        public decimal id_usuario_publicador { get; set; }
    }
}
