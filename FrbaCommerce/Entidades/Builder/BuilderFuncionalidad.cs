using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderFuncionalidad : IBuilder<Funcionalidad>
    {
        #region Miembros de IBuilder<Funcionalidad>

        public Funcionalidad Build(System.Data.DataRow row)
        {
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.IdFuncionalidad = Convert.ToDecimal(row["id_funcionalidad"]);
            funcionalidad.Nombre = Convert.ToString(row["nombre"]);
            funcionalidad.Habilitado = Convert.ToBoolean(row["habilitada"]);
            return funcionalidad;
        }

        #endregion
    }
}
