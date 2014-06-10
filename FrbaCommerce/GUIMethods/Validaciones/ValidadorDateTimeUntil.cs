using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.Validaciones;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorDateTimeUntil :IValidador
    {
        private DateTimePicker _control;
        private DateTime _until;

        public ValidadorDateTimeUntil(DateTimePicker control, DateTime until)
        {
            _control = control;
            _until = until;
        }

        public bool Validar()
        {
            if (_control.Value <= _until)
            {
                return true;
            }
            else
            {
                MessageDialog.MensajeValidacionDateTime(NameVariableParser.getNameWithoutUnderscore(_control), _until);
                return false;
            }
        }
    }
}
