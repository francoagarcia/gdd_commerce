using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderEstadoPublicacion : IBuilder<EstadoPublicacion>
    {
        public EstadoPublicacion Build(System.Data.DataRow row) {

            EstadoPublicacion estado = new EstadoPublicacion();
            estado.id_estado = Convert.ToDecimal(row["id_estado"]);
            estado.descripcion = Convert.ToString(row["descripcion"]);
            return estado;
        } 
    }
}
