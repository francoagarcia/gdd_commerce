using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.Validaciones;

namespace FrbaCommerce.GUIMethods.FormBase
{
    public class FormBase : Form
    {
        #region Propiedades
        public IList<IValidador> validadores { get; set; }
        #endregion

        #region Constructor
        public FormBase()
        {
            validadores = new List<IValidador>();
            this.StartPosition = FormStartPosition.CenterParent;
            //this.InitializeComponent();
        }
        #endregion

        #region Métodos protegidos
        protected void AgregarValidacion(IValidador validacion)
        {
            this.validadores.Add(validacion);
        }
        protected virtual bool Validar()
        {
            bool datosCorrectos = true;

            for (int i = 0; i < validadores.Count && datosCorrectos; i++)
            {
                datosCorrectos = validadores[i].Validar();
            }

            return datosCorrectos;
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormularioBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
    }
}