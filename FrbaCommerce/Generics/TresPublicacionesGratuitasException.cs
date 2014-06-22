using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics
{
    public class TresPublicacionesGratuitasException : Exception
    {
        public override string Message
        {
            get
            {
                StringBuilder sb = new StringBuilder("No se puede tener mas de 3 publicaciones activas y gratuitas al mismo tiempo");
                return sb.ToString();
            }
        }
    }
}
