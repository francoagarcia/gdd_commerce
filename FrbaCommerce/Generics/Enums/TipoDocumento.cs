using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public class TipoDocumento : TipoGenerico
    {
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

    public class ListaTipoDocumento : ListaTipoGenerico
    {
        public ListaTipoDocumento() 
            : base()
        {            
        }

        protected override void GenerarSubTipos()
        {
            Todos.Add(new TipoDocumentoDNI());
            Todos.Add(new TipoDocumentoLC());
            Todos.Add(new TipoDocumentoLE());
            Todos.Add(new TipoDocumentoCUIT());
        }
    }
}
