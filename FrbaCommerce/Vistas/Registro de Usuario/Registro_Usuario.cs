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

namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    public partial class Registro_Usuario : FormBaseAlta
    {
        public Registro_Usuario() 
            : base()
        {
            InitializeComponent();
        }

        #region [EventoLoad]
        private void Registro_Usuario_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorCombobox(this.comboBox_Tipo_de_usuario));
        }
        #endregion

        #region [Evento Aceptar]
        private void btnRegistracion_Click_1(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                TipoDeUsuario tipoDeUsuario = this.getTipoDeUsuario(this.comboBox_Tipo_de_usuario);
                if (tipoDeUsuario.Equals(TipoDeUsuario.TipoCliente))
                {
                    this.mostrarVentanaSiguiente(new RegistroDeCliente());
                }
                else if (tipoDeUsuario.Equals(TipoDeUsuario.TipoEmpresa))
                {
                    this.mostrarVentanaSiguiente(new RegistroDeEmpresa());
                }
            }
        }
        #endregion

        #region [Evento Cancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        #region [Metodos privados]
        private void mostrarVentanaSiguiente(Form formToShow)
        {
            this.Hide();
            formToShow.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            DialogResult resultado = formToShow.ShowDialog(this);
            if (resultado == DialogResult.OK || resultado == DialogResult.Cancel || resultado == DialogResult.Abort || resultado == DialogResult.No)
            {
                this.Close();
            }
        }

        private TipoDeUsuario getTipoDeUsuario(ComboBox comboBoxTipoDeUsuario)
        {
            TipoDeUsuario tipoDeUsuario = 0;
            int resultadoCombo = comboBoxTipoDeUsuario.SelectedIndex;
            switch (resultadoCombo)
            {
                case 0:
                    tipoDeUsuario = TipoDeUsuario.TipoCliente;
                    break;
                case 1:
                    tipoDeUsuario = TipoDeUsuario.TipoEmpresa;
                    break;
            }
            return tipoDeUsuario;
        }
        #endregion

        


    }
}
