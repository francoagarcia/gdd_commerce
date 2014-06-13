using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.GUIMethods.FormBase;

namespace FrbaCommerce.GUIMethods.FormBase
{
    public partial class FormBaseSeleccionTipo : FormBaseAlta
    {
        protected ListaTipoGenerico ListaCombo { get; set; }
        protected Form FormSiguiente;

        #region [Constructores]
        public FormBaseSeleccionTipo(ListaTipoGenerico listadoDelCombo)
            : base()
        {
            InitializeComponent();
            this.ListaCombo = listadoDelCombo;
            this.CargarNombres();
        }
        #endregion

        #region [EventoLoad]
        private void FormBaseSeleccionTipo_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorCombobox(this.cb_Tipo));
            this.CargarCombo();
        }

        protected virtual void CargarNombres()
        {
            throw new NotImplementedException();
        }

        private void CargarCombo()
        {
            cb_Tipo.DataSource = ListaCombo.Todos;
            cb_Tipo.DisplayMember = "Nombre";
            cb_Tipo.ValueMember = "Id";
        }
        #endregion

        #region [Evento Aceptar]
        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            this.AccionAceptar();
        }

        protected override void AccionAceptar()
        {
            TipoGenerico tipoElegido = this.getTipoDeSeleccionado();
            this.AccionMostrarSiguiente(tipoElegido);
        }

        protected virtual void AccionMostrarSiguiente(TipoGenerico tipoElegido)
        {
            throw new NotImplementedException();
        }

        private TipoGenerico getTipoDeSeleccionado()
        {
            return (TipoGenerico)this.cb_Tipo.SelectedItem;
        }
        #endregion

        #region [Evento Cancelar]
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        protected void mostrarVentanaSiguiente()
        {
            this.Hide();
            this.FormSiguiente.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            DialogResult resultado = this.FormSiguiente.ShowDialog(this);
            if (resultado == DialogResult.OK || resultado == DialogResult.Cancel || resultado == DialogResult.Abort || resultado == DialogResult.No)
            {
                this.Close();
            }
            else if (resultado == DialogResult.Retry) {
                this.Show();
            }
        }


    }
}
