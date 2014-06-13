using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public class TipoUsuario : TipoGenerico
    {
    }

    public class TipoUsuarioCliente : TipoUsuario
    {
        public TipoUsuarioCliente()
        {
            Id = 0;
            Nombre = "Cliente";
        }
    }

    public class TipoUsuarioEmpresa : TipoUsuario
    {
        public TipoUsuarioEmpresa()
        {
            Id = 1;
            Nombre = "Empresa";
        }
    }

    public class ListaTipoUsuario : ListaTipoGenerico
    {
        public ListaTipoUsuario()
            :base()
        {
        }

        protected override void GenerarSubTipos()
        {
            Todos.Add(new TipoUsuarioCliente());
            Todos.Add(new TipoUsuarioEmpresa());
        }
    }
}
