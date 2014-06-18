using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderUsuarioFactura : IBuilder<Usuario>
    {
        public Usuario Build(System.Data.DataRow row)
        {
            Usuario usuario = new Usuario();
            usuario.username = Convert.ToString(row["username"]);
            usuario.id_usuario = Convert.ToDecimal(row["id_usuario"]);
            usuario.habilitada = Convert.ToBoolean(row["habilitada"]);
            usuario.telefono = row["telefono"] != System.DBNull.Value ? Convert.ToDecimal(row["telefono"]) : 0;
            return usuario;
        }
    }
}
