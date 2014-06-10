using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.GUIMethods
{
    public class NameVariableParser
    {
        public static string getNameWithoutUnderscore(Control unControl){
            int indiceUndescore = NameVariableParser.getIndexOfFirstUnderscore(unControl.Name);
            if (indiceUndescore != 0)
            {
                string nombreCrudo = unControl.Name.Substring(indiceUndescore);
                return nombreCrudo.Replace('_', ' ');
            }
            return unControl.Name;
        }

        private static int getIndexOfFirstUnderscore(string cadena) {
            return cadena.IndexOf('_');
        }


    }
}
