using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Entidades.Filtros;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;
using FrbaCommerce.Generics;
using FrbaCommerce.Generics.Enums;

namespace FrbaCommerce.Vistas.Abm_Cliente
{
    public partial class ModificacionCliente : FormBaseModificacion
    {

        private Cliente clienteEntidad;
        private ClienteDB clienteDB;

        public ModificacionCliente(Cliente clienteModi)
        {
            this.clienteEntidad = clienteModi;
            this.clienteDB = new ClienteDB();
            InitializeComponent();
            this.Text = "FRBA Commerce - Modificacion de cliente";
            this.cb_Tipo_de_usuario.SelectedIndex = 0;
            this.cb_Tipo_de_usuario.Enabled = false;
        }

        #region [AccionIniciar]
        protected override void AccionIniciar()
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Nombre_de_usuario, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.tb_Contraseña, 1, 255));
            //this.AgregarValidacion(new ValidadorNumerico(tb_Telefono));
            this.AgregarValidacion(new ValidadorCombobox(cb_Tipo_de_documento));
            this.AgregarValidacion(new ValidadorString(tb_Numero_de_documento, 1, 50));
            this.AgregarValidacion(new ValidadorString(tb_Nombre, 0, 255));
            this.AgregarValidacion(new ValidadorString(tb_Apellido, 0, 255));
            this.AgregarValidacion(new ValidadorString(tb_Correo_electronico, 1, 255));
            this.AgregarValidacion(new ValidadorMail(tb_Correo_electronico));
            this.AgregarValidacion(new ValidadorCombobox(cb_Sexo));
            this.AgregarValidacion(new ValidadorDateTimeUntil(this.dp_Fecha_de_nacimiento, DateManager.Ahora()));
            this.AgregarValidacion(new ValidadorString(tb_Calle, 1, 255));
            this.AgregarValidacion(new ValidadorNumerico(tb_Piso));
            this.AgregarValidacion(new ValidadorString(tb_Departamento, 1, 255));
            this.AgregarValidacion(new ValidadorString(tb_Codigo_postal, 1, 255));
            //this.AgregarValidacion(new ValidadorString(tb_Localidad, 1, 255));

            this.CargarCombos();
            this.CargarClienteAModificar();
        }

        private void CargarClienteAModificar() {
            tb_Apellido.Text = this.clienteEntidad.apellido;
            tb_Calle.Text = clienteEntidad.dom_calle;
            tb_Altura.Text = clienteEntidad.altura.ToString();
            tb_Codigo_postal.Text = clienteEntidad.cod_postal;
            tb_Contraseña.Text = "123456";
            tb_Correo_electronico.Text = clienteEntidad.mail;
            tb_Departamento.Text = clienteEntidad.depto;
            tb_Localidad.Text = clienteEntidad.localidad;
            tb_Nombre.Text = clienteEntidad.nombre;
            tb_Nombre_de_usuario.Text = clienteEntidad.username;
            tb_Numero_de_documento.Text = clienteEntidad.nro_documento.ToString();
            tb_Piso.Text = clienteEntidad.piso.ToString();
            tb_Telefono.Text = clienteEntidad.telefono.ToString();
            cb_Sexo.SelectedItem = clienteEntidad.sexo;
            cb_Tipo_de_documento.SelectedItem = clienteEntidad.tipo_documento;
            dp_Fecha_de_nacimiento.Value = clienteEntidad.fecha_nacimiento;        
        }

        private void CargarCombos() {
            ListaSexo sexos = new ListaSexo();
            cb_Sexo.DataSource = sexos.Todos;
            cb_Sexo.DisplayMember = "Nombre";
            cb_Sexo.ValueMember = "Id";

            ListaTipoDocumento documentos = new ListaTipoDocumento();
            cb_Tipo_de_documento.DataSource = documentos.Todos;
            cb_Tipo_de_documento.DisplayMember = "Nombre";
            cb_Tipo_de_documento.ValueMember = "Id";
        }
        #endregion

        #region [AccionAceptar]

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            bool resultadoUpdate = this.ModificarClienteDB();
            if (resultadoUpdate == true)
                base.Cancelar();
        }

        private bool ModificarClienteDB()
        {
            try
            {
                this.armarClienteModificado();
                this.clienteDB.modificarCliente(this.clienteEntidad);
            }
            catch (SqlException exSQL)
            {
                MessageDialog.MensajeError(exSQL.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;
        }

        private void armarClienteModificado()
        {
            this.clienteEntidad.nombre = tb_Nombre.Text;
            this.clienteEntidad.apellido = tb_Apellido.Text;
            this.clienteEntidad.contrasenia = tb_Contraseña.Text!="123456" ? Encryptation.get_hash(tb_Contraseña.Text) : "123456";
            this.clienteEntidad.username = tb_Nombre_de_usuario.Text;
            this.clienteEntidad.localidad = tb_Localidad.Text;
            this.clienteEntidad.mail = tb_Correo_electronico.Text;
            this.clienteEntidad.cod_postal = tb_Codigo_postal.Text;
            this.clienteEntidad.depto = tb_Departamento.Text;
            this.clienteEntidad.dom_calle = tb_Calle.Text;
            this.clienteEntidad.altura = Convert.ToDecimal(tb_Altura.Text);
            this.clienteEntidad.fecha_nacimiento = dp_Fecha_de_nacimiento.Value;
            this.clienteEntidad.nro_documento =tb_Numero_de_documento.Text;
            this.clienteEntidad.piso = Convert.ToDecimal(tb_Piso.Text);
            this.clienteEntidad.telefono = Convert.ToDecimal(tb_Telefono.Text);
            this.clienteEntidad.tipo_documento = (TipoDocumento)cb_Tipo_de_documento.SelectedItem;
            this.clienteEntidad.sexo = (Sexo)cb_Sexo.SelectedItem;
        }


        #endregion

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            base.Limpiar();
        }

        protected override void AccionLimpiar()
        {
            this.tb_Apellido.Text = "";
            this.tb_Calle.Text = "";
            this.tb_Codigo_postal.Text = "";
            this.tb_Contraseña.Text = "";
            this.tb_Correo_electronico.Text = "";
            this.tb_Departamento.Text = "";
            this.tb_Localidad.Text = "";
            this.tb_Nombre.Text = "";
            this.tb_Nombre_de_usuario.Text = "";
            this.tb_Numero_de_documento.Text = "";
            this.tb_Piso.Text = "";
            this.tb_Telefono.Text = "";
            this.tb_Altura.Text = "";
            this.dp_Fecha_de_nacimiento.Value = DateManager.Ahora();
            this.cb_Sexo.SelectedIndex = 0;
            this.cb_Tipo_de_documento.SelectedIndex = 0;
        }

        


    }
}
