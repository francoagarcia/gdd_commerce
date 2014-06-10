using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.GUIMethods.FormBase
{
    public class FormBaseAlta : FormBase
    {
        #region [Constructor]
        public FormBaseAlta()
            : base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioBaseAlta
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormularioBaseAlta";
            this.ResumeLayout(false);

        }
        #endregion
        
        #region [Aceptar]
        protected virtual void Aceptar()
        {
            DialogResult dr = MessageDialog.MensajeInformativo(this, "¿Confirma la creación del registro?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (base.Validar())
                {
                    this.AccionAceptar();
                }
            }

        }

        protected virtual void AccionAceptar()
        {
            throw new NotImplementedException("Implementar AccionAceptar");
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
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea limpiar los campos?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.AccionLimpiar();
            }
        }

        protected virtual void AccionLimpiar()
        {
            throw new NotImplementedException("Implementar AcciónLimpiar");
        }
        #endregion

    }
}
