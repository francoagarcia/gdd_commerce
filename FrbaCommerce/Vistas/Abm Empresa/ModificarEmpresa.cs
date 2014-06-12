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

namespace FrbaCommerce.Vistas.Abm_Empresa
{
    public partial class ModificarEmpresa : FormBaseModificacion
    {
        private Empresa empresaModificar;
        private EmpresaDB empresaDB;

        public ModificarEmpresa(Empresa empresaModi)
        {
            this.empresaModificar = empresaModi;
            this.empresaDB = new EmpresaDB();
            InitializeComponent();
            this.Text = "FRBA Commerce - Modificacion de empresa";
            this.cb_Tipo_de_usuario.SelectedIndex = 1;
            this.cb_Tipo_de_usuario.Enabled = false;
        }
        #region [AccionIniciar]
        protected override void AccionIniciar()
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Nombre_de_contacto, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.tb_Contraseña, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.tb_Razon_Social, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.tb_CUIT, 1, 50));
            this.AgregarValidacion(new ValidadorString(this.tb_Correo_electronico, 1, 50));
            this.AgregarValidacion(new ValidadorString(this.tb_Calle, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.tb_Localidad, 1, 255));
            this.AgregarValidacion(new ValidadorString(this.tb_Departamento, 1, 50));
            this.AgregarValidacion(new ValidadorString(this.tb_Codigo_postal, 1, 50));
            this.AgregarValidacion(new ValidadorString(this.tb_Ciudad, 1, 255));
            this.AgregarValidacion(new ValidadorNumerico(this.tb_Telefono));
            this.AgregarValidacion(new ValidadorNumerico(this.tb_Piso));
            this.AgregarValidacion(new ValidadorMail(this.tb_Correo_electronico));
            this.AgregarValidacion(new ValidadorDateTimeUntil(this.dp_Fecha_de_creacion, DateManager.Ahora()));

            this.CargarEmpresaModificar();
        }

        private void CargarEmpresaModificar() 
        {
            this.tb_Calle.Text = this.empresaModificar.dom_calle;
            this.tb_Ciudad.Text = this.empresaModificar.ciudad;
            this.tb_Codigo_postal.Text = this.empresaModificar.cod_postal;
            this.tb_Contraseña.Text = "123456"; //TODO revisar esto que es una poronga, lo mismo en ModificacionCliente
            this.tb_Correo_electronico.Text = empresaModificar.mail;
            this.tb_CUIT.Text = empresaModificar.cuit;
            this.tb_Departamento.Text = empresaModificar.depto;
            this.tb_Localidad.Text = empresaModificar.localidad;
            this.tb_Nombre_de_contacto.Text = empresaModificar.nombre_de_contacto;
            this.tb_Piso.Text = Convert.ToString(empresaModificar.piso);
            this.tb_Razon_Social.Text = empresaModificar.razon_social;
            this.tb_Telefono.Text = Convert.ToString(empresaModificar.telefono);
            this.tb_Username.Text = empresaModificar.username;
            this.dp_Fecha_de_creacion.Value = empresaModificar.fecha_creacion;
        }
        #endregion

        #region [AccionLimpiar]
        protected override void AccionLimpiar()
        {
            this.tb_Calle.Text = "";
            this.tb_Ciudad.Text = "";
            this.tb_Codigo_postal.Text = "";
            this.tb_Contraseña.Text = "";
            this.tb_Correo_electronico.Text = "";
            this.tb_CUIT.Text = "";
            this.tb_Departamento.Text = "";
            this.tb_Localidad.Text = "";
            this.tb_Nombre_de_contacto.Text = "";
            this.tb_Piso.Text = "";
            this.tb_Razon_Social.Text = "";
            this.tb_Telefono.Text = "";
            this.tb_Username.Text = "";
            this.dp_Fecha_de_creacion.Value = DateManager.Ahora();
        }
        #endregion

        #region [AccionAceptar]
        protected override void AccionAceptar()
        {
            bool resultadoupdate = this.ModificarClienteDB();
            if (resultadoupdate == true)
                base.Cancelar();
        }

        private bool ModificarClienteDB()
        {
            try
            {
                this.armarClienteModificado();
                this.empresaDB.modificarEmpresa(this.empresaModificar);
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
            this.empresaModificar.ciudad = tb_Ciudad.Text;
            this.empresaModificar.cod_postal = tb_Codigo_postal.Text;
            this.empresaModificar.contrasenia = tb_Contraseña.Text != "123456" ? Encryptation.get_hash(tb_Contraseña.Text) : "123456";
            this.empresaModificar.username = tb_Username.Text;
            this.empresaModificar.localidad = tb_Localidad.Text;
            this.empresaModificar.mail = tb_Correo_electronico.Text;
            this.empresaModificar.cod_postal = tb_Codigo_postal.Text;
            this.empresaModificar.depto = tb_Departamento.Text;
            this.empresaModificar.dom_calle = tb_Calle.Text;
            this.empresaModificar.fecha_creacion = dp_Fecha_de_creacion.Value;
            this.empresaModificar.piso = Convert.ToDecimal(tb_Piso.Text);
            this.empresaModificar.telefono = Convert.ToDecimal(tb_Telefono.Text);
            this.empresaModificar.razon_social = tb_Razon_Social.Text;
            this.empresaModificar.cuit = tb_CUIT.Text;
        }
        #endregion

        #region [ButtonActions]
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            this.AccionLimpiar();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        #endregion


    }
}
