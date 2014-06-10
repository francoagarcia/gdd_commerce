using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorNumerico : IValidador 
    {
        private Control _control;
        public ValidadorNumerico(Control control)
        {
            _control = control;
        }

        public bool Validar()
        {
            try
            {
                int valor = Convert.ToInt32(_control.Text);
                return true;
            }
            catch (Exception)
            {
                MessageDialog.MensajeValidacionNumerico(NameVariableParser.getNameWithoutUnderscore(_control));
                return false;
            }
        }

    }
}
