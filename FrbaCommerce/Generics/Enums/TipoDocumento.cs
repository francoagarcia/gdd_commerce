using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{

    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public class TipoDocumentoDNI : TipoDocumento
    {
        public TipoDocumentoDNI()
        {
            Id = 1;
            Nombre = "DNI";
        }
    }
    public class TipoDocumentoLC : TipoDocumento
    {
        public TipoDocumentoLC()
        {
            Id = 2;
            Nombre = "LC";
        }
    }
    public class TipoDocumentoLE : TipoDocumento
    {
        public TipoDocumentoLE()
        {
            Id = 3;
            Nombre = "LE";
        }
    }
    public class TipoDocumentoCUIT : TipoDocumento
    {
        public TipoDocumentoCUIT()
        {
            Id = 4;
            Nombre = "CUIT";
        }
    }

    public class ListaTipoDocumento
    {
        public IList<TipoDocumento> Todos { get; set; }

        public ListaTipoDocumento()
        {
            Todos = new List<TipoDocumento>();
            Todos.Add(new TipoDocumentoDNI());
            Todos.Add(new TipoDocumentoLC());
            Todos.Add(new TipoDocumentoLE());
            Todos.Add(new TipoDocumentoCUIT());
        }

        public TipoDocumento Obtener(int id)
        {
            return Todos.Where(t => t.Id == id).FirstOrDefault();
        }
        public TipoDocumento Obtener(string nombre)
        {
            return Todos.Where(t => t.Nombre == nombre).FirstOrDefault();
        }
    }
}
