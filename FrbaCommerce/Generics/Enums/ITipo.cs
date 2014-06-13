using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Enums
{
    public interface ITipo
    {
        string ToString();
    }

    public interface IListaTipo 
    {
        TipoGenerico Obtener(int id);
        TipoGenerico Obtener(string nombre);
    }
}
