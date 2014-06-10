using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorMail : IValidador
    {
        private Control _control;
        public ValidadorMail(Control control)
        {
            _control = control;
        }

        public bool Validar()
        {
            bool esCorrecto = this.Validar(_control.Text);
            if (!esCorrecto)
            {
                MessageDialog.MensajeError("Ingrese un mail válido");
            }
            return esCorrecto;
        }

        private bool Validar(string cadena)
        {
            string email = cadena;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

    }
}
