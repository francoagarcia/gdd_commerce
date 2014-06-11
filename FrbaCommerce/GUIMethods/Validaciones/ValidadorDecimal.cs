using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorDecimal : IValidador
    {
        private Control _control;
        public ValidadorDecimal(Control control)
        {
            _control = control;
        }

        public bool Validar()
        {
            try
            {
                decimal valor = Convert.ToDecimal(_control.Text);
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
