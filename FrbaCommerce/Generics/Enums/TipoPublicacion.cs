using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public class TipoPublicacion : TipoGenerico
    {
    }

    public class TipoCompraInmediata : TipoPublicacion {
        public TipoCompraInmediata() {
            this.Id = 1;
            this.Nombre = "Compra inmediata";
        }
    }

    public class TipoSubasta : TipoPublicacion {
        public TipoSubasta() {
            this.Id = 2;
            this.Nombre = "Subasta";
        }
    }

    public class TipoCualquiera : TipoPublicacion
    {
        public TipoCualquiera()
        {
            this.Id = 99;
            this.Nombre = "";
        }
    }

    public class ListaTipoPublicacion : ListaTipoGenerico {

        public ListaTipoPublicacion() 
            : base()
        {            
        }

        protected override void GenerarSubTipos()
        {
            Todos.Add(new TipoCualquiera());
            Todos.Add(new TipoCompraInmediata());
            Todos.Add(new TipoSubasta());
        }
    
    }
}
