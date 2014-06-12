using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderCliente : IBuilder<Cliente>
    {
        public Cliente Build(System.Data.DataRow row)
        {
            Cliente cli = new Cliente();

            cli.tipo_documento = new ListaTipoDocumento().Obtener(Convert.ToInt32(row["id_tipo_documento"]));
            cli.nro_documento = Convert.ToDecimal(row["nro_documento"]);
            cli.id_usuario = Convert.ToDecimal(row["id_usuario"]);
            cli.username = Convert.ToString(row["username"]);
            cli.nombre = Convert.ToString(row["nombre"]);
            cli.apellido = Convert.ToString(row["apellido"]);
            cli.telefono = row["telefono"]!=System.DBNull.Value ? Convert.ToDecimal(row["telefono"]) : 0;
            cli.sexo = row["sexo"] != System.DBNull.Value ? new ListaSexo().Obtener(Convert.ToInt32(row["sexo"])) : new Indefinido();
            cli.fecha_nacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
            cli.dom_calle = Convert.ToString(row["dom_calle"]);
            cli.depto = Convert.ToString(row["depto"]);
            cli.piso = Convert.ToDecimal(row["piso"]);
            cli.localidad = Convert.ToString(row["localidad"]);
            cli.mail = Convert.ToString(row["mail"]);
            cli.cod_postal = Convert.ToString(row["cod_postal"]);
            cli.habilitada = Convert.ToBoolean(row["habilitada"]);

            return cli;
        }

    }
}
