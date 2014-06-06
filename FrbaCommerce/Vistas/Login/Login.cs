using System;
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

namespace FrbaCommerce.Vistas.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login() {
            try
            {
                if (this.realizar_login())
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
                this.limpiarTextBoxes();
            }
        
        }

        private void limpiarTextBoxes() {
            this.textBoxPassword.Text = "";
            this.textBoxUsername.Text = "";
        }

        private bool realizar_login()
        {
            string password_hash = Encryptation.get_hash(this.textBoxPassword.Text);

            IdentificacionUsuario resultadoLogin = this.ValidarLogin(this.textBoxUsername.Text, password_hash);

            string[] lines3 = { Convert.ToString(resultadoLogin) };
            System.IO.File.WriteAllLines(@"C:\Franco\pene.txt", lines3);
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

        private bool loginSuccess(IdentificacionUsuario resultadoLogin) {
            return resultadoLogin == 0;
        }

        private IdentificacionUsuario ValidarLogin(string username, string hashPassword)
        {
            IdentificacionUsuario identificacion;
            int codigoRetorno = UsuarioDB.RealizarIdentificacion(username, hashPassword);
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
                    return "El usuario, el rol o la contraseña son inválidos";
                default:
                    return "Error al querer identificar";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login();
        }
   
    }
}
