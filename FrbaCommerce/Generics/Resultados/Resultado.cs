using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Resultados
{
    public class Resultado<T> : IResultado<T>
    {
        public bool Correcto { get; set; }
        public IList<string> Mensajes { get; set; }
        public T Retorno { get; set; }

        public Resultado()
        {
            Mensajes = new List<string>();
            Retorno = default(T);
            Correcto = true;
        }

        public Resultado(T resultado)
        {
            Retorno = resultado;
            Correcto = true;
            Mensajes = new List<string>();
        }

        public Resultado(string mensaje)
        {
            Mensajes = new List<string>();
            Mensajes.Add(mensaje);

            Retorno = default(T);
            Correcto = false;
        }
    }
}
