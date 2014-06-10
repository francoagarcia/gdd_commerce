using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorDateTimeFrom : IValidador
    {
        private DateTimePicker _control;
        private DateTime _from;

        public ValidadorDateTimeFrom(DateTimePicker control, DateTime from)
        {
            _control = control;
            _from = from;
        }

        public bool Validar()
        {
            if (_control.Value >= _from)
            {
                return true;
            }
            else
            {
                MessageDialog.MensajeValidacionDateTimeFrom(NameVariableParser.getNameWithoutUnderscore(_control), _from);
                return false;
            }
        }

    }
}
