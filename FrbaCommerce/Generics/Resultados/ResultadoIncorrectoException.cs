using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Resultados
{
    public class ResultadoIncorrectoException<T> : Exception
    {
        private IResultado<T> _resultado;

        public ResultadoIncorrectoException(IResultado<T> resultado)
        {
            this._resultado = resultado;
        }

        public override string Message
        {
            get
            {
                StringBuilder sb = new StringBuilder("Ha ocurrido un error al intentar procesar el requerimiento:\n");
                foreach (string mensaje in _resultado.Mensajes)
                {
                    sb.AppendFormat("{0}\n", mensaje);
                }
                return sb.ToString();
            }
        }
    }
}
