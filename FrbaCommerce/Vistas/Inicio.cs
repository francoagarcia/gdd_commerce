using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Vistas.Abm_Cliente;
using FrbaCommerce.Entidades;
using FrbaCommerce.Vistas.Login;
using FrbaCommerce.DataAccess;
using FrbaCommerce.GUIMethods;
using FrbaCommerce.Generics;
using FrbaCommerce.Vistas.Listado_Estadistico;

namespace FrbaCommerce
{
    public partial class Inicio : Form
    {
        //ClienteDomain clienteDomain;
        //EmpresaDomain empresaDomain;
        private MenuItemsHelper menuItems { get; set; }
        
        public Inicio()
        {
            this.menuItems = new MenuItemsHelper();
            InitializeComponent();
        }

        #region [Inicio_Load]
        private void Inicio_Load(object sender, EventArgs e)
        {
            this.Inicio_Load_CargarFuncionalidadesBase( new List<Funcionalidad>() );
            this.Inicio_Load_MostrarLogin();
            this.Inicio_Load_CargarMenues();
            this.Inicio_Load_CargarBarrasDeEstado();
            
        }

        private void Inicio_Load_sesionItem() {
            if (Program.ContextoActual.SesionIniciada)
            {
                this.itm_Const_Sesion_CerrarSesion.Enabled = true;
                this.itm_Const_Sesion_CerrarSesion.Visible = true;

                this.itm_Const_Sesion_IniciarSesion.Enabled = false;
                this.itm_Const_Sesion_IniciarSesion.Visible = false;

                this.itm_Var_Listado_Estadistico.Enabled = true;
                this.itm_Var_Listado_Estadistico.Visible = true;
            }
            else
            {
                this.itm_Const_Sesion_CerrarSesion.Enabled = false;
                this.itm_Const_Sesion_CerrarSesion.Visible = false;

                this.itm_Const_Sesion_IniciarSesion.Enabled = true;
                this.itm_Const_Sesion_IniciarSesion.Visible = true;

                this.itm_Var_Listado_Estadistico.Enabled = false;
                this.itm_Var_Listado_Estadistico.Visible = false;
            }
        }
        private void Inicio_Load_inhabilitarTodosLosItems() {
            foreach (ToolStripItem item in mnuPrincipal.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    item.Enabled = false;
                    item.Visible = false;

                    this.itm_Const_Archivo.Visible = itm_Const_Archivo.Enabled = true;
                    this.itm_Const_Salir.Visible = itm_Const_Salir.Enabled = true;
                    this.itm_Const_Sesion.Visible = itm_Const_Sesion.Enabled = true;

                    this.Inicio_Load_sesionItem();
                }
            }
        }

        private void Inicio_Load_CargarFuncionalidadesBase(IList<Funcionalidad> funcionalidades)
        {
            this.Inicio_Load_inhabilitarTodosLosItems();

            if (funcionalidades != null && funcionalidades.Count > 0)
            {
                var nombresFuncionalidades = funcionalidades.Select(f => f.Nombre.Trim());
                this.menuItems.manejarItems(this.mnuPrincipal.Items, (IList<string>)nombresFuncionalidades.ToList());
            }

            this.Inicio_Load_sesionItem();
        }

        private void Inicio_Load_MostrarLogin()
        {
            Usuario usuario = null;
            Rol rol = null;
            using (Login frm = new Login())
            {
                frm.ShowDialog(this);
                usuario = frm.UsuarioIniciado;
                rol = frm.RolUsuarioIniciado;
            }
            if (usuario != null)
            {
                Program.ContextoActual.RegistrarUsuario(usuario);
                this.lblUsuario.Text = usuario.username;
            }
            if (rol != null)
            {
                Program.ContextoActual.RegistrarRol(rol);         
            }
        }

        private void Inicio_Load_CargarMenues()
        {
            IList<Funcionalidad> funcionalidadesFromDB = this.getFuncionalidadesDeUnRol(Program.ContextoActual.RolActual.idRol);
            if (funcionalidadesFromDB != null && funcionalidadesFromDB.Count>0)
            {
                Inicio_Load_CargarFuncionalidadesBase(funcionalidadesFromDB);
            }
           
        }

        private void Inicio_Load_CargarBarrasDeEstado()
        {
            this.lblUsuario.Text = "Usuario: " + Program.ContextoActual.UsuarioActual.username;
            this.lblLogPath.Text = "Almacenando log en: " + Program.ContextoActual.LogPath;
            this.lblFechaSistema.Text = "Fecha: " + DateManager.Format(Program.ContextoActual.FechaActual);
            this.lblConnectionString.Text = "Conectado: " + AppConfigReader.Get("connection_string");
        }

        public IList<Funcionalidad> getFuncionalidadesDeUnRol(decimal idRol)
        {
            IList<Funcionalidad> funcionalidades = null;
            if (idRol > 0)
            {
                try
                {
                    funcionalidades = FuncionalidadDB.getFuncionalidadesDeUnRol(idRol);
                }
                catch (Exception ex)
                {
                    MessageDialog.MensajeError(ex.Message);
                }
            }
            else
            {
                funcionalidades = new List<Funcionalidad>();
            }
            return funcionalidades;
        }

       #endregion

        #region [Inicio_Closing]
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea salir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region [Menu Archivo]
        #region [itm_Const_Salir]
        private void itm_Const_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region [itm_Const_Sesion_IniciarSesion]
        private void itm_Const_Sesion_IniciarSesion_Click(object sender, EventArgs e)
        {
            this.Inicio_Load_MostrarLogin();
            this.Inicio_Load_CargarMenues();
            this.Inicio_Load_CargarBarrasDeEstado();
        }
        #endregion

        #region [itm_Const_Sesion_CerrarSesion]
        private void itm_Const_Sesion_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea cerrar su sesión?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.itm_Const_Sesion_CerrarSesion_Aceptado();
            }
        }

        private void itm_Const_Sesion_CerrarSesion_Aceptado()
        {
            Program.ContextoActual.DesregistrarUsuario();
            Program.ContextoActual.DesregistrarRol();

            this.Inicio_Load_CargarFuncionalidadesBase(null);
            this.Inicio_Load_CargarBarrasDeEstado();
        }
        #endregion

        #region [estadísticasToolStripMenuItem]
        private void itm_Var_Listado_Estadistico_Click(object sender, EventArgs e)
        {
            try
            {
                Listado_Estadistico frm = new Listado_Estadistico();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }

        #endregion
        #endregion




    }
}
