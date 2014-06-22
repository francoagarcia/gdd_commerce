using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Entidades.Builder
{
    public class BuilderFuncionalidadXRol : IBuilder<FuncionalidaXRol>
    {
        public FuncionalidaXRol Build(System.Data.DataRow row) {
            FuncionalidaXRol fun_rol = new FuncionalidaXRol();
            fun_rol.funcionalidad = new Funcionalidad();
            fun_rol.funcionalidad.IdFuncionalidad = Convert.ToDecimal(row["id_funcionalidad"]);
            fun_rol.funcionalidad.Nombre = Convert.ToString(row["nombre"]);
            fun_rol.habilitada = Convert.ToBoolean(row["habilitada"]);
            fun_rol.rol = new Rol();
            return fun_rol;
        }
    }
}
