using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public class TipoEstados : TipoGenerico
    {
    }

    public class TipoPublicada : TipoEstados
    {
        public TipoPublicada()
        {
            this.Id = 1;
            this.Nombre = "Publicada";
        }
    }

    public class TipoBorrador : TipoEstados
    {
        public TipoBorrador()
        {
            this.Id = 2;
            this.Nombre = "Borrador";
        }
    }

    public class TipoPausada : TipoEstados
    {
        public TipoPausada()
        {
            this.Id = 3;
            this.Nombre = "Pausada";
        }
    }

    public class TipoFinalizada : TipoEstados
    {
        public TipoFinalizada()
        {
            this.Id = 4;
            this.Nombre = "Finalizada";
        }
    }

    public class ListaTipoEstados : ListaTipoGenerico
    {

        public ListaTipoEstados()
            : base()
        {
        }

        public IList<TipoEstados> EstadosPublicacionActiva
        {
            get
            {
                IList<TipoEstados> estadosPublicacionActiva = new List<TipoEstados>();
                estadosPublicacionActiva.Add(new TipoPublicada());
                estadosPublicacionActiva.Add(new TipoPausada());
                estadosPublicacionActiva.Add(new TipoFinalizada());
                return estadosPublicacionActiva;
            }
        }

        public IList<TipoEstados> EstadosPublicacionBorrada
        {
            get
            {
                return Todos as IList<TipoEstados>;
            }
        }

        public IList<TipoEstados> EstadosPublicacionFinalizada
        {
            get
            {
                IList<TipoEstados> finalizada = new List<TipoEstados>();
                finalizada.Add((TipoEstados)base.Obtener("Finalizada"));
                return finalizada;
            }
        }

        public IList<TipoEstados> EstadosPublicacionPausada
        {
            get
            {
                IList<TipoEstados> pausada = new List<TipoEstados>();
                pausada.Add((TipoEstados)base.Obtener("Pausada"));
                return pausada;
            }
        }

        protected override void GenerarSubTipos()
        {
            Todos.Add(new TipoPublicada());
            Todos.Add(new TipoBorrador());
            Todos.Add(new TipoPausada());
            Todos.Add(new TipoFinalizada());
        }
    }
}
