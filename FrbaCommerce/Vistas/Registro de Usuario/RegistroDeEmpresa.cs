using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.DataAccess;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    public partial class RegistroDeEmpresa : Form
    {
        public RegistroDeEmpresa()
        {
            InitializeComponent();
            this.comboBoxTipoDeUsuario.SelectedIndex = 1;
            this.comboBoxTipoDeUsuario.Enabled = false;
        }

        private void RegistroDeEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private bool validacionesEnGeneral()
        {
            if (!this.camposCompletos())
            {
                MessageDialog.MensajeError("Por favor ingrese todos los datos solicidatos");
                return false;
            }
            else if (this.existeNombreDeUsuario(this.textBoxUsername.Text))
            {
                MessageDialog.MensajeError("EL nombre de usuario ya se encuentra registrado. Por favor ingrese otro");
                return false;
            }
            return true;
        }

        private bool camposCompletos()
        {
            foreach (Control groupBox in this.Controls)
            {
                if (groupBox is GroupBox)
                {
                    foreach (Control control in groupBox.Controls)
                    {
                        if (this.campoVacio(control))
                            return false;
                    }
                }
            }
            return true;
        }

        private bool campoVacio(Control control)
        {
            return (this.textBoxEstaVacio(control) || this.comboBoxEstaVacio(control) || this.dateTimePickerEstaVacio(control));
        }

        private bool dateTimePickerEstaVacio(Control control)
        {
            return (control is DateTimePicker && ((DateTimePicker)control).Value == null);
        }

        private bool comboBoxEstaVacio(Control control)
        {
            return (control is ComboBox && ((ComboBox)control).SelectedItem == null);
        }

        private bool textBoxEstaVacio(Control control)
        {
            return (control is TextBox && String.IsNullOrEmpty(((TextBox)control).Text));
        }

        private bool existeNombreDeUsuario(string nombreDeUsuarioNuevo)
        {
            return UsuarioDB.existeNombreDeUsuario(nombreDeUsuarioNuevo);
        }

        private void btnRegistracion_Click_1(object sender, EventArgs e)
        {
            if (validacionesEnGeneral())
            {

            }
        }

    }
}
