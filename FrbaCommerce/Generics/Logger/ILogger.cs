using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Logger
{
    public interface ILogger
    {
        void Iniciar();
        void Log(string mensaje);
        void Log(Exception ex);
        void Finalizar();
    }
}
