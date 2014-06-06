using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.GUIMethods
{
    public static class MessageDialog
    {
        public static DialogResult MensajeInformativo(IWin32Window formulario, string mensaje)
        {
            return MessageBox.Show(formulario, mensaje, "FRBA Commerce - Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult MensajeInformativo(IWin32Window formulario, string mensaje, MessageBoxButtons botones)
        {
            return MessageBox.Show(formulario, mensaje, "FRBA Commerce - Información", botones, MessageBoxIcon.Information);
        }

        public static DialogResult MensajeInterrogativo(IWin32Window formulario, string mensaje, MessageBoxButtons botones)
        {
            return MessageBox.Show(formulario, mensaje, "FRBA Commerce - Consulta", botones, MessageBoxIcon.Question);
        }

        public static DialogResult MensajeError(IWin32Window formulario, string mensaje)
        {
            return MessageBox.Show(formulario, mensaje, "FRBA Commerce - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MensajeError(string mensaje)
        {
            return MessageBox.Show(mensaje, "FRBA Commerce - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MensajeValidacionNumerico(string controlName)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo {0} debe ser numérico", controlName), "Error al validar");
        }

        public static DialogResult MensajeValidacionString(string controlName, int minSize, int maxSize)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo {0} debe tener entre {1} y {2} caracteres", controlName, minSize, maxSize), "Error al validar");
        }
    }
}
