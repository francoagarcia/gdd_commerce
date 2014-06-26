using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorCheckedListBox : IValidador
    {
        private CheckedListBox _control;

        public ValidadorCheckedListBox(CheckedListBox control)
        {
            this._control = control;
        }

        public bool Validar()
        {
            if (_control.CheckedItems.Count == 1)
            {
                return true;
            }
            else {
                MessageDialog.MensajeValidacionCheckedListBox(NameVariableParser.getNameWithoutUnderscore(_control));
                return false;
            }
        }
    }
}
