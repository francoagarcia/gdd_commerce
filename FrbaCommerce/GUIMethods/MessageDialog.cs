using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generics;

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
            return MessageBox.Show(string.Format("El valor ingresado en el campo '{0}' debe ser numérico", controlName), "Error al validar");
        }

        public static DialogResult MensajeValidacionString(string controlName, int minSize, int maxSize)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo '{0}' debe tener entre '{1}' y '{2}' caracteres", controlName, minSize, maxSize), "Error al validar");
        }

        public static DialogResult MensajeVacio(string lugar)
        {
            return MessageBox.Show(string.Format("No ha ingresado ningun valor en el campo '{0}'.", lugar), "Completar");
        }

        public static DialogResult MensajeListaVacia()
        {
            return MessageBox.Show(string.Format("No ha ingresado ningun valor en la lista."), "Completar");
        }

        public static DialogResult MensajeValidacionDateTime(string controlName, DateTime until)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo '{0}' debe ser menor a la fecha '{1}'", controlName, DateManager.Format(until)), "Error al validar");
        }

        public static DialogResult MensajeValidacionDateTimeFrom(string controlName, DateTime from)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo '{0}' debe ser mayor a la fecha {1}", controlName, DateManager.Format(from)), "Error al validar");
        }

        public static DialogResult MensajeValidacionDateTime(string controlName, DateTime from, DateTime until)
        {
            var sUntil = DateManager.Format(until);
            var sFrom = DateManager.Format(from);
            return MessageBox.Show(string.Format("El valor ingresado en el campo '{0}' debe ser mayor a '{1}' y menor a '{2}'", controlName, sFrom, sUntil), "Error al validar");
        }

        internal static void MensajeValidacionCombobox(string controlName)
        {
            MessageBox.Show(string.Format("Debe seleccionar un elemento del control '{0}'", controlName), "Error al validar");
        }

        internal static void MensajeValidacionCheckedListBox(string controlName)
        {
            MessageBox.Show(string.Format("Debe seleccionar un elemento del control '{0}'", controlName), "Error al validar");
        }
    }
}
