﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using FrbaCommerce.Generics.Enums;
using FrbaCommerce.Generics;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.Entidades;

namespace FrbaCommerce.Vistas.Login
{
    public partial class Login : Form
    {

        #region [Atributos]
        private bool rol_seleccionado;
        private RolDB rolDB;
        public Usuario UsuarioIniciado { get; private set; }
        public Rol RolUsuarioIniciado { get; private set; }
        #endregion

        public Login()
        {
            this.rolDB = new RolDB();
            this.rol_seleccionado = true;
            InitializeComponent();
        }

        private void login() {
            try
            {
                if (this.realizar_login())
                {
                    IList<Rol> roles_usuario = this.rolDB.ObtenerRoles(this.textBoxUsername.Text);

                    if (roles_usuario.Count > 1 && rol_seleccionado)
                    {
                        this.textBoxUsername.Enabled = false;
                        this.textBoxPassword.Enabled = false;
                        this.labelRol.Visible = true;
                        this.comboBoxRol.Visible = true;
                        this.comboBoxRol.DataSource = roles_usuario;
                        this.comboBoxRol.SelectedIndex = 0;

                        MessageDialog.MensajeInformativo(this, "Debe seleccionar un rol para continuar");
                        rol_seleccionado = false;
                    }
                    else if (roles_usuario.Count > 1 && !rol_seleccionado)
                    {
                        this.RolUsuarioIniciado = (Rol)this.comboBoxRol.SelectedItem;
                        this.obtenerUsuarioLogueadoCorrectamente();
                    }
                    else 
                    {
                        if (roles_usuario.Count.Equals(0))
                        {
                            MessageDialog.MensajeInformativo(this,"No puede ingresar al sistema debido a que se encuentra inhabilitado o todos sus roles lo están.");
                            this.Close();
                        }
                        else
                        {
                            this.RolUsuarioIniciado = roles_usuario.First();
                            this.obtenerUsuarioLogueadoCorrectamente();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
                this.limpiarTextBoxes();
            }
        
        }

        private void obtenerUsuarioLogueadoCorrectamente()
        {
            this.UsuarioIniciado = UsuarioDB.ObtenerPorUsername(this.textBoxUsername.Text);
            this.Close();
        }

        private void limpiarTextBoxes() {
            this.textBoxPassword.Text = "";
            this.textBoxUsername.Text = "";
        }

        private bool realizar_login()
        {
            string password_hash = Encryptation.get_hash(this.textBoxPassword.Text);

            IdentificacionUsuario resultadoLogin = this.ValidarLogin(this.textBoxUsername.Text, password_hash);

            if (loginSuccess(resultadoLogin))
            {
                return true;
            }
            else 
            {
                MessageDialog.MensajeError(this.getMensajeLogin(resultadoLogin));
                return false;
            }

        }

        protected bool loginSuccess(IdentificacionUsuario resultadoLogin) {
            return resultadoLogin == 0;
        }

        private IdentificacionUsuario ValidarLogin(string username, string hashPassword)
        {
            IdentificacionUsuario identificacion;
            int codigoRetorno = UsuarioDB.RealizarLogin(username, hashPassword);
            switch (codigoRetorno)
            {
                case -2:
                    identificacion = IdentificacionUsuario.UsuarioInvalido;
                    break;
                case -1:
                    identificacion = IdentificacionUsuario.UsuarioBloqueado;
                    break;
                case 0:
                    identificacion = IdentificacionUsuario.UsuarioIdentificado;
                    break;
                default:
                    identificacion = IdentificacionUsuario.UsuarioInvalido;
                    break;
            }
            return identificacion;
        }

        private string getMensajeLogin(IdentificacionUsuario resultadoIdentificacion)
        {
            switch (resultadoIdentificacion)
            {
                case IdentificacionUsuario.UsuarioIdentificado:
                    return "Usuario identificado correctamente";
                case IdentificacionUsuario.UsuarioBloqueado:
                    return "El usuario ha sido bloqueado por reiterados intentos erróneos de login";
                case IdentificacionUsuario.UsuarioInvalido:
                    return "El usuario o la contraseña son inválidos";
                default:
                    return "Error al querer identificar";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.login();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.RegistroDeUsuario frm = new Registro_de_Usuario.RegistroDeUsuario();
            frm.ShowDialog();
        }

       
    }
}
