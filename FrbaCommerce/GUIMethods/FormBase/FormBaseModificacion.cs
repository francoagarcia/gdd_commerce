using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;

namespace FrbaCommerce.GUIMethods.FormBase
{
    public partial class FormBaseModificacion : FormBase
    {
        #region [Constructor]
        public FormBaseModificacion() : base()
        {
            InitializeComponent();
        }
        #endregion

        #region [EventoLoad]
        private void FormBaseModificacion_Load(object sender, EventArgs e)
        {
            this.AccionIniciar();
        }

        /// <summary>
        /// Carga en la pantalla los datos de la filtro poniendo sus propiedades en los campos correspondientes
        /// </summary>
        protected virtual void AccionIniciar()
        {
            //throw new NotImplementedException("Debe implementar la acción iniciar");
        }
        #endregion

        #region [Aceptar]
        protected virtual void Aceptar()
        {
            if (base.Validar())
            {
                DialogResult dr = MessageDialog.MensajeInformativo(this, "¿Confirma la modificación del registro?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.AccionAceptar();
                }
            }

        }
        /// <summary>
        /// Acción que se dispara desde el botón Aceptar luego de validar todos los campos.
        /// </summary>
        protected virtual void AccionAceptar()
        {
            //throw new NotImplementedException("Debe implementar la acción aceptar");
        }
        #endregion

        #region [Cancelar]
        protected virtual void Cancelar()
        {
            this.Close();
        }
        #endregion

        #region [Limpiar]
        protected void Limpiar()
        {
            this.AccionLimpiar();
        }

        protected virtual void AccionLimpiar()
        {
            //throw new NotImplementedException("Implementar AcciónLimpiar");
        }
        #endregion

    }
}
