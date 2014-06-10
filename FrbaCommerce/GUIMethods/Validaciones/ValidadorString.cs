using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorString : IValidador
    {
        private Control _control;
        private int _minSize;
        private int _maxSize;

        public ValidadorString(Control control, int minSize, int maxSize)
        {
            _control = control;
            _minSize = minSize;
            _maxSize = maxSize;
        }

        #region Miembros de IValidador

        public bool Validar()
        {
            if ((!string.IsNullOrEmpty(_control.Text)) && (_control.Text.Length >= _minSize) && (_control.Text.Length <= _maxSize))
            {
                return true;
            }
            else
            {
                MessageDialog.MensajeValidacionString(NameVariableParser.getNameWithoutUnderscore(_control), _minSize, _maxSize);
                return false;
            }
        }

        #endregion
    }
}
