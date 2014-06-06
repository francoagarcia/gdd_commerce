using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderRol : IBuilder<Rol>
    {
        #region Miembros de IBuilder<Rol>

        public Rol Build(System.Data.DataRow row)
        {
            Rol rol = new Rol();
            rol.idRol = Convert.ToDecimal(row["id_rol"]);
            rol.nombre = Convert.ToString(row["nombre"]);
            rol.habilitada = Convert.ToBoolean(row["habilitada"]);
            return rol;
        }
        
        #endregion
    }
}
