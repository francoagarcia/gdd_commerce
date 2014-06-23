using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics.Excepciones
{
    public class TelefonoRepetidoException : Exception
    {
        public override string Message
        {
            get
            {
                StringBuilder sb = new StringBuilder("El telefono ingresado ya se encuentra registrado en el sistema");
                return sb.ToString();
            }
        }
    }
}
