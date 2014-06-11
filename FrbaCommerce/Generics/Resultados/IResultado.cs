using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Resultados
{
    public interface IResultado<T>
    {
        bool Correcto { get; }
        T Retorno { get; }
        IList<string> Mensajes { get; }
    }
}
