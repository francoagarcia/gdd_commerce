using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class EstadoPublicacionDB : EntidadBaseDB<EstadoPublicacion, EstadoPublicacion>
    {
        public EstadoPublicacionDB() 
            : base(new BuilderEstadoPublicacion(), "EstadoPublicacion")
        { 
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(EstadoPublicacion entidad)
        {
            throw new NotImplementedException();
        }
    }
}
