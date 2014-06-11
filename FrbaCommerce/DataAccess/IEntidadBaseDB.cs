using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.DataAccess
{
    public interface IEntidadBaseDB<T, W>
    {
        IList<T> Filtrar(W filtro);
    }
}
