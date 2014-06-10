using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorCombobox : IValidador
    {
        private ComboBox _control;

        public ValidadorCombobox(ComboBox control)
        {
            this._control = control;
        }

        public bool Validar()
        {
            if (_control.DropDownStyle == ComboBoxStyle.DropDown && _control.SelectedIndex > 0)
            {
                return true;
            }
            else if (_control.DropDownStyle == ComboBoxStyle.DropDownList && _control.SelectedIndex >= 0)
            {
                return true;
            }
            else
            {
                MessageDialog.MensajeValidacionCombobox(NameVariableParser.getNameWithoutUnderscore(_control));
                return false;
            }
        }
    }
}
