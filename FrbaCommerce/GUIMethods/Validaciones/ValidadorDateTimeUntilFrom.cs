using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.Validaciones;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidarDateTimeUntilFrom : IValidador
    {
        private DateTimePicker _control;
        DateTime _from;
        DateTime _until;

        public ValidarDateTimeUntilFrom(DateTimePicker control, DateTime from, DateTime until)
        {
            _control = control;
            _from = from;
            _until = until;
        }

        public bool Validar()
        {
            return true;
        }
    }
}
