using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public abstract class TipoGenerico : ITipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public abstract class ListaTipoGenerico : IListaTipo
    {
        public IList<TipoGenerico> Todos { get; set; }
        public ListaTipoGenerico() { 
            Todos = new List<TipoGenerico>();
            this.GenerarSubTipos();
        }

        protected virtual void GenerarSubTipos() { 
        }

        public TipoGenerico Obtener(int id)
        {
            return Todos.Where(t => t.Id == id).FirstOrDefault();
        }
        public TipoGenerico Obtener(string nombre)
        {
            return Todos.Where(t => t.Nombre == nombre).FirstOrDefault();
        }
    }
}
