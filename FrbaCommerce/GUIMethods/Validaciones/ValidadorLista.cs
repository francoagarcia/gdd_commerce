using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.Validaciones
{
    public class ValidadorLista : IValidador
    {
        public ListBox Lista { get; private set; }
        public ValidadorLista(ListBox lista)
        {
            Lista = lista;
        }
        #region Miembros de IValidador

        public bool Validar()
        {
            bool esCorrecto = Lista.Items.Count > 0;
            if (!esCorrecto)
            {
                MessageDialog.MensajeError("La lista " + Lista.Name + " debe contener al menos un elemento.");
            }
            return esCorrecto;
        }

        #endregion
    }
}
