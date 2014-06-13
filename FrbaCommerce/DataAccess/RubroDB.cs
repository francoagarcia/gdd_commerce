using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Entidades.Builder;

namespace FrbaCommerce.DataAccess
{
    public class RubroDB : EntidadBaseDB<Rubro, Rubro>
    {
        public RubroDB()
            : base(new BuilderRubro(), "rubro")
        { 
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(Rubro entidad)
        {
            throw new NotImplementedException();
        }
    }
}
