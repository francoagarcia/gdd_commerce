using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics.Enums;


namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderEmpresa : IBuilder<Empresa>
    {
        public Empresa Build(System.Data.DataRow row)
        {
            Empresa emp = new Empresa();
            emp.username = Convert.ToString(row["username"]);
            emp.telefono = row["telefono"] != System.DBNull.Value ? Convert.ToDecimal(row["telefono"]) : 0;
            emp.cuit = Convert.ToString(row["cuit"]);
            emp.razon_social = Convert.ToString(row["razon_social"]);
            emp.id_usuario = Convert.ToDecimal(row["id_usuario"]);
            emp.nombre_de_contacto = Convert.ToString(row["nombre_de_contacto"]);
            emp.dom_calle = Convert.ToString(row["dom_calle"]);
            emp.depto = Convert.ToString(row["depto"]);
            emp.piso = Convert.ToDecimal(row["piso"]);
            emp.localidad = Convert.ToString(row["localidad"]);
            emp.ciudad = Convert.ToString(row["ciudad"]);
            emp.mail = Convert.ToString(row["mail"]);
            emp.cod_postal = Convert.ToString(row["cod_postal"]);
            emp.fecha_creacion = Convert.ToDateTime(row["fecha_creacion"]);
            emp.habilitada = Convert.ToBoolean(row["habilitada"]);

            return emp;
        }
    }
}
