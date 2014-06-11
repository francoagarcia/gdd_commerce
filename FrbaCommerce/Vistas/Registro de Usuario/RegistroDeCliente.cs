using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.DataAccess;
using System.Data.Sql;
using System.Data.SqlClient;
using FrbaCommerce.GUIMethods;

namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    public partial class RegistroDeCliente : FormBaseAlta
    {
        public RegistroDeCliente()
        {
            InitializeComponent();
            this.comboBox_Tipo_de_usuario.SelectedIndex = 0;
            this.comboBox_Tipo_de_usuario.Enabled = false;
        }

        #region [AccionCancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion 

        #region [AccionAceptar]
        private void btnRegistracion_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            Cliente nuevoPosibleCliente = this.armarNuevoCliente();
            this.AltaCliente(nuevoPosibleCliente);
        }

        private void AltaCliente(Cliente clienteAlta) {

            bool insertSalioBien = this.CrearClienteDB(clienteAlta);
            if (insertSalioBien == true)
            {
                MessageDialog.MensajeInformativo(this, "Se registro correctamente");
                this.Close();
            }
        }

        private bool CrearClienteDB(Cliente cliente) {
            try
            {
                decimal id = ClienteDB.nuevoCliente(cliente);
                cliente.id_usuario = id;
            }
            catch (SqlException ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;

        }

        private Cliente armarNuevoCliente() {

            Cliente cliente = new Cliente();
            cliente.id_usuario = 0; //no tiene ninguno asignado por ahora
            cliente.username = this.textBox_Nombre_de_usuario.Text;
            cliente.contrasenia = Encryptation.get_hash(this.textBox_Contraseña.Text);
            cliente.telefono = this.textBox_Telefono.Text;
            cliente.nombre = this.textBox_Nombre.Text;
            cliente.apellido = this.textBox_Apellido.Text;
            cliente.nro_documento = Convert.ToDecimal(this.textBox_Numero_de_documento.Text);
            cliente.tipo_documento = (TipoDocumento)this.comboBox_Tipo_de_documento.SelectedItem;
            cliente.sexo = (Sexo)this.comboBox_Sexo.SelectedItem;
            cliente.mail = this.textBox_Correo_electronico.Text;
            cliente.fecha_nacimiento = this.dp_Fecha_de_nacimiento.Value;
            cliente.dom_calle = this.textBox_Calle.Text;
            cliente.piso = Convert.ToDecimal(this.textBox_Piso.Text);
            cliente.depto = this.textBox_Departamento.Text;
            cliente.localidad = this.textBox_Localidad.Text;
            cliente.cod_postal = this.textBox_Codigo_postal.Text;

            return cliente;
        }


        #endregion

        #region [EventoLoad]
        private void RegistroDeCliente_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(this.textBox_Nombre_de_usuario, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Contraseña, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Nombre, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Apellido, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Correo_electronico, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Calle, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Localidad, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.textBox_Departamento, 1, 50));
            this.AgregarValidacion(new ValidadorString(this.textBox_Codigo_postal, 1, 50));
            this.AgregarValidacion(new ValidadorNumerico(this.textBox_Telefono));
            this.AgregarValidacion(new ValidadorNumerico(this.textBox_Numero_de_documento));
            this.AgregarValidacion(new ValidadorNumerico(this.textBox_Piso));
            this.AgregarValidacion(new ValidadorCombobox(this.comboBox_Sexo));
            this.AgregarValidacion(new ValidadorCombobox(this.comboBox_Tipo_de_documento));
            this.AgregarValidacion(new ValidadorMail(this.textBox_Correo_electronico));
            this.AgregarValidacion(new ValidadorDateTimeUntil(this.dp_Fecha_de_nacimiento, DateManager.Ahora()));

            this.cargarCombos();
        }

        private void cargarCombos()
        {
            ListaSexo sexos = new ListaSexo();
            comboBox_Sexo.DataSource = sexos.Todos;
            comboBox_Sexo.DisplayMember = "Nombre";
            comboBox_Sexo.ValueMember = "Id";

            ListaTipoDocumento documentos = new ListaTipoDocumento();
            comboBox_Tipo_de_documento.DataSource = documentos.Todos;
            comboBox_Tipo_de_documento.DisplayMember = "Nombre";
            comboBox_Tipo_de_documento.ValueMember = "Id";
        }
        #endregion
    }
}
