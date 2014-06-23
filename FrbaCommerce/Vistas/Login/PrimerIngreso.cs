using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Entidades;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods.FormBase;
using FrbaCommerce.GUIMethods.Validaciones;
using FrbaCommerce.Generics;
using FrbaCommerce.GUIMethods;
using System.Data.SqlClient;

namespace FrbaCommerce.Vistas.Login
{
    public partial class PrimerIngreso : FormBaseAlta
    {
        private Usuario usuario;
        private UsuarioDB usuarioDB;

        public PrimerIngreso(Usuario us)
        {
            this.usuario = us;
            this.usuarioDB = new UsuarioDB();
            InitializeComponent();
        }

        private void tb_Constrasenia_MouseClick(object sender, MouseEventArgs e)
        {
            this.tb_Constrasenia.Text = "";
            this.AgregarValidacion(new ValidadorString(this.tb_Constrasenia, 1, 255));
        }

        private void PrimerIngreso_Load(object sender, EventArgs e)
        {
            this.tb_Constrasenia.Text = "pass_usu_nuevo";
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }

        protected override void AccionAceptar()
        {
            if (this.modificoLaContrasenia())
            {
                Usuario usuarioModif = this.armarUsuario();
                if(actualizarContraseniaPrimerIngresoDB(usuarioModif))
                {
                    MessageDialog.MensajeInformativo(this, "Se modifico la contraseña correctamente. Puede continuar!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else 
            {
                MessageDialog.MensajeInformativo(this, "Debe modificar la contraseña");
            }
        }

        private bool actualizarContraseniaPrimerIngresoDB(Usuario usuarioModif) 
        {
            try
            {
                this.usuarioDB.actualizarContraseniaPrimerIngreso(usuarioModif);
                this.usuario.contrasenia = usuarioModif.contrasenia;
            }
            catch (SqlException e)
            {
                MessageDialog.MensajeError(e.Message);
                this.Close();
                return false;
            }
            catch (Exception e) 
            {
                MessageDialog.MensajeError(e.Message);
                return false;
            }
            return true;
        }

        private Usuario armarUsuario() 
        {
            Usuario usu = new Usuario();
            usu.cantidadIntentos = this.usuario.cantidadIntentos;
            usu.contrasenia = Encryptation.get_hash(this.tb_Constrasenia.Text);
            usu.habilitada = this.usuario.habilitada;
            usu.habilitada_comprar = this.usuario.habilitada_comprar;
            usu.id_usuario = this.usuario.id_usuario;
            usu.telefono = this.usuario.telefono;
            usu.username = this.usuario.username;
            return usu;
        }

        private bool modificoLaContrasenia()
        {
            string pass_usu_nuevo = Encryptation.get_hash("pass_usu_nuevo");
            return !this.tb_Constrasenia.Text.Equals(pass_usu_nuevo);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
