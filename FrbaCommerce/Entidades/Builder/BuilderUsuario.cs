using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Generics;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderUsuario : IBuilder<Usuario>
    {
        #region Miembros de IBuilder<Usuario>

        public Usuario Build(System.Data.DataRow row)
        {

            Usuario usuario = new Usuario();
            usuario.username = Convert.ToString(row["username"]);
            usuario.contrasenia = Convert.ToString(row["contrasenia"]);
            usuario.habilitada = Convert.ToBoolean(row["habilitada"]);
            usuario.cantidadIntentos = Convert.ToInt32(row["intentos_login"]);
            usuario.habilitada_comprar = Convert.ToBoolean(row["habilitada_comprar"]);
            return usuario;
        }

        #endregion
    }
}
