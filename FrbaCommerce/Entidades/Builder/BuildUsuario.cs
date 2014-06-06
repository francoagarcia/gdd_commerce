using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics;

namespace FrbaCommerce.Entidades.Builder
{
    class BuildUsuario : IBuilder<Usuario>
    {
        #region Miembros de IBuilder<Usuario>

        public Usuario Build(System.Data.DataRow row)
        {
            Usuario usuario = new Usuario();
            usuario.username = Convert.ToString(row["username"]);
            usuario.habilitado = Convert.ToBoolean(row["habilitada"]);
            usuario.cantidadIntentos = Convert.ToInt32(row["intentos_login"]);
            return usuario;
        }

        #endregion
    }
}
