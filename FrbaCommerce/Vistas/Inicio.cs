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
using FrbaCommerce.Vistas.ABM_Rol;
using FrbaCommerce.Vistas.Abm_Empresa;
using FrbaCommerce.Vistas.Abm_Rubro;
using FrbaCommerce.Vistas.Abm_Visibilidad;
using FrbaCommerce.Vistas.Generar_Publicacion;
using FrbaCommerce.Vistas.Editar_Publicacion;
using FrbaCommerce.Vistas.Facturar_Publicaciones;
using FrbaCommerce.Vistas.Historial_Cliente;

namespace FrbaCommerce
{
    public partial class Inicio : Form
    {
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
                this.menuItems.manejarItemsAll(this.mnuPrincipal.Items, (IList<string>)nombresFuncionalidades.ToList());
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
            this.ReestrablecerTodo();
            this.Inicio_Load_CargarFuncionalidadesBase(new List<Funcionalidad>());
            this.Inicio_Load_MostrarLogin();
            
            this.Inicio_Load_CargarMenues();
            this.Inicio_Load_CargarBarrasDeEstado();
        }

        private void ReestrablecerTodo() 
        {

            itm_Var_Calificar_al_Vendedor.Enabled = itm_Var_Calificar_al_Vendedor.Visible = true;
            itm_Var_Gestion_de_Preguntas.Enabled = itm_Var_Gestion_de_Preguntas.Visible = true;
            toolStripSeparator8.Enabled = toolStripSeparator8.Visible = true;
            itm_Var_Historial_de_Operaciones.Enabled = itm_Var_Historial_de_Operaciones.Visible = true;
            toolStripSeparator9.Enabled = toolStripSeparator9.Visible = true;
            itm_Var_Editar_Publicacion.Enabled = itm_Var_Editar_Publicacion.Visible = true;
            itm_Var_Nueva_Publicacion.Enabled = itm_Var_Nueva_Publicacion.Visible = true;
            itm_Var_Publicaciones.Enabled = itm_Var_Publicaciones.Visible = true;
            itm_Var_ABM_de_Visibilidad_de_Publicacion.Enabled = itm_Var_ABM_de_Visibilidad_de_Publicacion.Visible = true;
            itm_Var_ABM_de_Rubro.Enabled = itm_Var_ABM_de_Rubro.Visible = true;
            toolStripSeparator7.Enabled = toolStripSeparator7.Visible = true;
            itm_Var_ABM_de_Cliente.Enabled = itm_Var_ABM_de_Cliente.Visible = true;
            itm_Var_ABM_de_Empresa.Enabled = itm_Var_ABM_de_Empresa.Visible = true;
            itm_Var_Usuarios.Enabled = itm_Var_Usuarios.Visible = true;
            itm_Var_ABM_de_Rol.Enabled = itm_Var_ABM_de_Rol.Visible = true;
            toolStripSeparator6.Enabled = toolStripSeparator6.Visible = true;
            itm_Var_Facturar_Publicaciones.Enabled = itm_Var_Facturar_Publicaciones.Visible = true;
            itm_Var_Admin.Enabled = itm_Var_Admin.Visible = true;
            itm_Const_Salir.Enabled = itm_Const_Salir.Visible = true;
            toolStripSeparator5.Enabled = toolStripSeparator5.Visible = true;
            itm_Var_Listado_Estadistico.Enabled = itm_Var_Listado_Estadistico.Visible = true;
            toolStripSeparator4.Enabled = toolStripSeparator4.Visible = true;
            itm_Const_Sesion_CerrarSesion.Enabled = itm_Const_Sesion_CerrarSesion.Visible = true;
            itm_Const_Sesion_IniciarSesion.Enabled = itm_Const_Sesion_IniciarSesion.Visible = true;
            itm_Const_Sesion.Enabled = itm_Const_Sesion.Visible = true;
            itm_Const_Archivo.Enabled = itm_Const_Archivo.Visible = true;

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

        #region Menu Administracion
        private void itm_Var_ABM_de_Rol_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoRoles frm = new ListadoRoles();
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

        private void itm_Var_ABM_de_Cliente_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoCliente frm = new ListadoCliente();
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

        private void itm_Var_ABM_de_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoEmpresa frm = new ListadoEmpresa();
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

        private void itm_Var_ABM_de_Rubro_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoRubros frm = new ListadoRubros();
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

        private void itm_Var_ABM_de_Visibilidad_de_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoVisibilidad frm = new ListadoVisibilidad();
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

        private void itm_Var_Nueva_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionTipoPublicacion frm = new SeleccionTipoPublicacion(Program.ContextoActual.UsuarioActual);
                frm.StartPosition = FormStartPosition.CenterScreen;
                //frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }

        private void itm_Var_Editar_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoPublicacionesDeVendedor frm = new ListadoPublicacionesDeVendedor(Program.ContextoActual.UsuarioActual);
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

        private void itm_Var_Facturar_Publicaciones_Click(object sender, EventArgs e)
        {
            try
            {
                FacturarPublicaciones frm = new FacturarPublicaciones();
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

        private void itm_Var_Historial_de_Operaciones_Click(object sender, EventArgs e)
        {
            try
            {
                Historial frm = new Historial(Program.ContextoActual.UsuarioActual);
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

        private void itm_Var_Gestion_de_Preguntas_Click(object sender, EventArgs e)
        {

        }

        

        






    }
}
