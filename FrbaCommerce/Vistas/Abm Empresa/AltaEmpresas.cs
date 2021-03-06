﻿using System;
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
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.Generics.Resultados;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Entidades;
using FrbaCommerce.Generics;
using System.Data.SqlClient;
using FrbaCommerce.Vistas.Abm_Cliente;

namespace FrbaCommerce.Vistas.Abm_Empresa
{
    public partial class AltaEmpresas : FormBaseAlta
    {
        private EmpresaDB empresaDB;

        public AltaEmpresas()
        {
            InitializeComponent();
            this.empresaDB = new EmpresaDB();
            //this.cb_Tipo_de_usuario.SelectedIndex = 1;
            //this.cb_Tipo_de_usuario.Enabled = false;
        }

        #region [AccionAceptar]
        private void btnRegistracion_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            Usuario nuevaPosibleEmpresa = this.armarNueva();
            this.AltaUsuario(nuevaPosibleEmpresa);

        }

        private void AltaUsuario(Usuario empresaAlta)
        {
            bool insertSalioBien = this.CrearUsuario(empresaAlta); 
            if (insertSalioBien == true)
            {
                DatosUsuarioNuevo frm = new DatosUsuarioNuevo(empresaAlta.username, "pass_emp_nueva");
                frm.ShowDialog(this);
                this.Close();
            }
        }

        private bool CrearUsuario(Usuario empresa)
        {
            try
            {
                this.CrearUsuarioDB(empresa);
            }
            catch (SqlException ex)
            {
                MessageDialog.MensajeError(ex.Message);
                base.Cancelar();
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(ex.Message);
                return false;
            }
            return true;
        }

        private void CrearUsuarioDB(Usuario unUsuario) {
            decimal id = this.empresaDB.nuevaEmpresa((Empresa)unUsuario);
            ((Empresa)unUsuario).id_usuario = id;
        } 

        private Usuario armarNueva()
        {
            Empresa empresa = new Empresa();
            //Datos del usuario
            empresa.id_usuario = 0; //no tiene ninguno asignado por ahora
            empresa.username = this.tb_CUIT.Text;
            empresa.contrasenia = Encryptation.get_hash("pass_emp_nueva");
            empresa.telefono = Convert.ToDecimal(this.tb_Telefono.Text);

            //Datos particulares
            empresa.mail = this.tb_Correo_electronico.Text;
            empresa.nombre_de_contacto = this.tb_Nombre_de_contacto.Text;
            empresa.razon_social = this.tb_Razon_Social.Text;
            empresa.cuit = this.tb_CUIT.Text;           
            empresa.fecha_creacion = this.dp_Fecha_de_creacion.Value;
            empresa.nombre_de_contacto = this.tb_Nombre_de_contacto.Text;

            //Domicilio
            empresa.dom_calle = this.tb_Calle.Text;
            empresa.piso = Convert.ToDecimal(this.tb_Piso.Text);
            empresa.depto = this.tb_Departamento.Text;
            empresa.localidad = this.tb_Localidad.Text;
            empresa.cod_postal = this.tb_Codigo_postal.Text;
            empresa.ciudad = this.tb_Ciudad.Text;
            empresa.altura = Convert.ToDecimal(this.tb_Altura.Text);

            return empresa;
        }
        #endregion

        #region [EventoLoad]
        private void RegistroDeEmpresa_Load(object sender, EventArgs e)
        {
            this.AgregarValidacion(new ValidadorString(this.tb_Nombre_de_contacto, 1, 255));
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
            this.AgregarValidacion(new ValidadorNumerico(this.tb_Altura));
            this.AgregarValidacion(new ValidadorMail(this.tb_Correo_electronico));
            this.AgregarValidacion(new ValidadorDateTimeUntil(this.dp_Fecha_de_creacion, DateManager.Ahora()));
        }
        #endregion

        #region [Accion Cancelar]
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            base.Cancelar();
        }
        #endregion

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            base.Cancelar();
        }
    }
}
