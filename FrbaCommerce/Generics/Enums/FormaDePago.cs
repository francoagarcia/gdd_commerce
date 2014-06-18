using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public class FormaDePago : TipoGenerico
    {
    }

    public class FormaContado : FormaDePago 
    {
        public FormaContado() {
            this.Id = 1;
            this.Nombre = "Contado";
        }
    }

    public class FormaTarjetaDeCredito : FormaDePago 
    {
        public FormaTarjetaDeCredito() 
        {
            this.Id = 2;
            this.Nombre = "Tarjeta de credito";
        }
    }

    public class ListaFormasDePago : ListaTipoGenerico 
    {

        public ListaFormasDePago() : base() 
        { 
        }

        protected override void GenerarSubTipos()
        {
            this.Todos.Add(new FormaContado());
            this.Todos.Add(new FormaTarjetaDeCredito());
        }
    }
}
