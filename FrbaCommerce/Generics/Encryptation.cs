using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace FrbaCommerce.Generics
{
    public static class Encryptation
    {
        static public string get_hash(string pass_ingresada)
        {
            byte[] pass_hash;
            //convierto contrasenia en un array de bytes para poder usarla en las funciones de encriptacion
            byte[] pass_en_bytes = Encoding.UTF8.GetBytes(pass_ingresada);
            SHA256 shaManag = new SHA256Managed();
            //calculamos valor hash de la contraseña
            pass_hash = shaManag.ComputeHash(pass_en_bytes);

            //convertimos hash en string
            StringBuilder pass_string = new StringBuilder();

            //concatenamos bytes
            for (int i = 0; i < pass_hash.Length; i++)
                pass_string.Append(pass_hash[i].ToString("x2").ToLower());

            return pass_string.ToString();
        }




    }
}
