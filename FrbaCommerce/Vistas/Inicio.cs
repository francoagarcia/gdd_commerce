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
using FrbaCommerce.Vistas.Gestion_de_Preguntas;
using FrbaCommerce.Vistas.Comprar_Ofertar;
using FrbaCommerce.Vistas.Calificar_Vendedor;

namespace FrbaCommerce
{
    public partial class Inicio : Form
    {
        private MenuItemsHelper menuItems { get; set; }
        private Listado_Estadistico frm_estadisticas;
        private ListadoRoles frm_roles;
        private ListadoCliente frm_clientes;
        private ListadoEmpresa frm_empresas;
        private ListadoRubros frm_rubros;
        private ListadoVisibilidad frm_visibilidades;
        private SeleccionTipoPublicacion frm_seleccionTipoPublicacion;
        private ListadoPublicacionesDeVendedor frm_publicacionesVendedor;
        private FacturarPublicaciones frm_facturar;
        private Historial frm_historial;
        private GestionPreguntas frm_gestionPreguntas;
        private ListadoPublicacionesCompra frm_comprar;
        private SeleccionarCompra frm_Calificar;

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
                this.ValidarUsuario(usuario);
            }
            if (rol != null)
            {
                Program.ContextoActual.RegistrarRol(rol);         
            }
        }

        private void ValidarUsuario(Usuario usuario) 
        {
            if (esUnUsuarioRegistradoPorElAdministrador(usuario))
            {
                PrimerIngreso frm = new PrimerIngreso(usuario);
                frm.ShowDialog(this);
                if (frm.DialogResult == DialogResult.Cancel)
                    this.Close();
                Program.ContextoActual.RegistrarUsuario(usuario);
                this.lblUsuario.Text = usuario.username;
            }
            else 
            {
                Program.ContextoActual.RegistrarUsuario(usuario);
                this.lblUsuario.Text = usuario.username;
            }
        }

        private bool esUnUsuarioRegistradoPorElAdministrador(Usuario usuario) 
        {
            string pass_cli_nuevo = Encryptation.get_hash("pass_cli_nuevo");
            string pass_emp_nueva = Encryptation.get_hash("pass_emp_nueva");
            return usuario.contrasenia.Equals(pass_cli_nuevo) || usuario.contrasenia.Equals(pass_emp_nueva);
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
            //this.lblLogPath.Text = "Almacenando log en: " + Program.ContextoActual.LogPath;
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

        #region Salir
        private void itm_Const_Salir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea salir?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.cerrarFormsChildren();
                this.Close();
            }
            
        }
        #endregion

        #region Iniciar sesion
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

        #region Cerrar sesion
        private void itm_Const_Sesion_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.MensajeInterrogativo(this, "¿Está seguro que desea cerrar su sesión?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cerrarFormsChildren();
                this.itm_Const_Sesion_CerrarSesion_Aceptado();
            }
        }

        private void cerrarFormsChildren()
        {
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form childForm in this.MdiChildren)
                    childForm.Close();
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

        #region Estadisticas
        private void itm_Var_Listado_Estadistico_Click(object sender, EventArgs e)
        {
            try
            {
                frm_estadisticas = null;
                frm_estadisticas = new Listado_Estadistico();
                frm_estadisticas.StartPosition = FormStartPosition.CenterParent;
                frm_estadisticas.WindowState = FormWindowState.Maximized;
                frm_estadisticas.MdiParent = this;
                frm_estadisticas.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region ABM de rol
        private void itm_Var_ABM_de_Rol_Click(object sender, EventArgs e)
        {
            try
            {
                frm_roles = null;
                frm_roles = new ListadoRoles();
                frm_roles.StartPosition = FormStartPosition.CenterParent;
                frm_roles.WindowState = FormWindowState.Maximized;
                frm_roles.MdiParent = this;
                frm_roles.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region ABM de clientes
        private void itm_Var_ABM_de_Cliente_Click(object sender, EventArgs e)
        {
            try
            {
                frm_clientes = null;
                frm_clientes = new ListadoCliente();
                frm_clientes.StartPosition = FormStartPosition.CenterParent;
                frm_clientes.WindowState = FormWindowState.Maximized;
                frm_clientes.MdiParent = this;
                frm_clientes.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region ABM de empresa
        private void itm_Var_ABM_de_Empresa_Click(object sender, EventArgs e)
        {
            try
            {
                frm_empresas = null;
                frm_empresas = new ListadoEmpresa();
                frm_empresas.StartPosition = FormStartPosition.CenterParent;
                frm_empresas.WindowState = FormWindowState.Maximized;
                frm_empresas.MdiParent = this;
                frm_empresas.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region ABM de rubros
        private void itm_Var_ABM_de_Rubro_Click(object sender, EventArgs e)
        {
            try
            {
                frm_rubros = null;
                frm_rubros = new ListadoRubros();
                frm_rubros.StartPosition = FormStartPosition.CenterParent;
                frm_rubros.WindowState = FormWindowState.Maximized;
                frm_rubros.MdiParent = this;
                frm_rubros.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region ABM de visibilidad de publicaciones
        private void itm_Var_ABM_de_Visibilidad_de_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                frm_visibilidades = null;
                frm_visibilidades = new ListadoVisibilidad();
                frm_visibilidades.StartPosition = FormStartPosition.CenterParent;
                frm_visibilidades.WindowState = FormWindowState.Maximized;
                frm_visibilidades.MdiParent = this;
                frm_visibilidades.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region Nueva publicacoin
        private void itm_Var_Nueva_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                frm_seleccionTipoPublicacion = null;
                frm_seleccionTipoPublicacion = new SeleccionTipoPublicacion(Program.ContextoActual.UsuarioActual);
                frm_seleccionTipoPublicacion.StartPosition = FormStartPosition.CenterScreen;
                //frm_seleccionTipoPublicacion.WindowState = FormWindowState.Maximized;
                frm_seleccionTipoPublicacion.MdiParent = this;
                frm_seleccionTipoPublicacion.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion 

        #region Editar publicacion
        private void itm_Var_Editar_Publicacion_Click(object sender, EventArgs e)
        {
            try
            {
                frm_publicacionesVendedor = null;
                frm_publicacionesVendedor = new ListadoPublicacionesDeVendedor(Program.ContextoActual.UsuarioActual);
                frm_publicacionesVendedor.StartPosition = FormStartPosition.CenterParent;
                frm_publicacionesVendedor.WindowState = FormWindowState.Maximized;
                frm_publicacionesVendedor.MdiParent = this;
                frm_publicacionesVendedor.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region Facturar publicaciones
        private void itm_Var_Facturar_Publicaciones_Click(object sender, EventArgs e)
        {
            try
            {
                frm_facturar = null;
                frm_facturar = new FacturarPublicaciones();
                frm_facturar.StartPosition = FormStartPosition.CenterParent;
                frm_facturar.WindowState = FormWindowState.Maximized;
                frm_facturar.MdiParent = this;
                frm_facturar.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region Historial de operaciones
        private void itm_Var_Historial_de_Operaciones_Click(object sender, EventArgs e)
        {
            try
            {
                frm_historial = new Historial(Program.ContextoActual.UsuarioActual);
                frm_historial.StartPosition = FormStartPosition.CenterParent;
                frm_historial.WindowState = FormWindowState.Maximized;
                frm_historial.MdiParent = this;
                frm_historial.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }

        }
        #endregion

        #region Gestion de preguntas
        private void itm_Var_Gestion_de_Preguntas_Click(object sender, EventArgs e)
        {
            try
            {
                frm_gestionPreguntas = null;
                frm_gestionPreguntas = new GestionPreguntas(Program.ContextoActual.UsuarioActual);
                frm_gestionPreguntas.StartPosition = FormStartPosition.CenterParent;
                frm_gestionPreguntas.WindowState = FormWindowState.Maximized;
                frm_gestionPreguntas.MdiParent = this;
                frm_gestionPreguntas.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region Comprar/Ofertar
        private void itm_Var_Comprar_Ofertar_Click(object sender, EventArgs e)
        {
            try
            {
                frm_comprar = null;
                frm_comprar = new ListadoPublicacionesCompra(Program.ContextoActual.UsuarioActual);
                frm_comprar.StartPosition = FormStartPosition.CenterParent;
                frm_comprar.WindowState = FormWindowState.Maximized;
                frm_comprar.MdiParent = this;
                frm_comprar.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

        #region Calificar al vendedor
        private void itm_Var_Calificar_al_Vendedor_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Calificar = null;
                frm_Calificar = new SeleccionarCompra(Program.ContextoActual.UsuarioActual);
                frm_Calificar.StartPosition = FormStartPosition.CenterParent;
                frm_Calificar.WindowState = FormWindowState.Maximized;
                frm_Calificar.MdiParent = this;
                frm_Calificar.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.MensajeError(this, ex.Message);
            }
        }
        #endregion

    }
}