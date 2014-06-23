namespace FrbaCommerce
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.itm_Const_Archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Const_Sesion = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Const_Sesion_IniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Const_Sesion_CerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Var_Listado_Estadistico = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Const_Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Admin = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Facturar_Publicaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Var_ABM_de_Rol = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_ABM_de_Empresa = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_ABM_de_Cliente = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Var_ABM_de_Rubro = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_ABM_de_Visibilidad_de_Publicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Publicaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Nueva_Publicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Editar_Publicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Var_Historial_de_Operaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Var_Gestion_de_Preguntas = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.itm_Var_Comprar_Ofertar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itm_Var_Calificar_al_Vendedor = new System.Windows.Forms.ToolStripMenuItem();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.lblFechaSistema = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tstNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.tstBarraDebug = new System.Windows.Forms.StatusStrip();
            this.lblConnectionString = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLogPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuPrincipal.SuspendLayout();
            this.stsBarraEstado.SuspendLayout();
            this.tstBarraDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Const_Archivo,
            this.itm_Var_Admin,
            this.itm_Var_Publicaciones,
            this.itm_Var_Clientes});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1281, 24);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // itm_Const_Archivo
            // 
            this.itm_Const_Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Const_Sesion,
            this.toolStripSeparator4,
            this.itm_Var_Listado_Estadistico,
            this.toolStripSeparator5,
            this.itm_Const_Salir});
            this.itm_Const_Archivo.Name = "itm_Const_Archivo";
            this.itm_Const_Archivo.Size = new System.Drawing.Size(60, 20);
            this.itm_Const_Archivo.Text = "Archivo";
            // 
            // itm_Const_Sesion
            // 
            this.itm_Const_Sesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Const_Sesion_IniciarSesion,
            this.itm_Const_Sesion_CerrarSesion});
            this.itm_Const_Sesion.Name = "itm_Const_Sesion";
            this.itm_Const_Sesion.Size = new System.Drawing.Size(134, 22);
            this.itm_Const_Sesion.Text = "Sesión";
            // 
            // itm_Const_Sesion_IniciarSesion
            // 
            this.itm_Const_Sesion_IniciarSesion.Name = "itm_Const_Sesion_IniciarSesion";
            this.itm_Const_Sesion_IniciarSesion.Size = new System.Drawing.Size(142, 22);
            this.itm_Const_Sesion_IniciarSesion.Text = "Iniciar sesión";
            this.itm_Const_Sesion_IniciarSesion.Click += new System.EventHandler(this.itm_Const_Sesion_IniciarSesion_Click);
            // 
            // itm_Const_Sesion_CerrarSesion
            // 
            this.itm_Const_Sesion_CerrarSesion.Name = "itm_Const_Sesion_CerrarSesion";
            this.itm_Const_Sesion_CerrarSesion.Size = new System.Drawing.Size(142, 22);
            this.itm_Const_Sesion_CerrarSesion.Text = "Cerrar sesión";
            this.itm_Const_Sesion_CerrarSesion.Click += new System.EventHandler(this.itm_Const_Sesion_CerrarSesion_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(131, 6);
            // 
            // itm_Var_Listado_Estadistico
            // 
            this.itm_Var_Listado_Estadistico.Name = "itm_Var_Listado_Estadistico";
            this.itm_Var_Listado_Estadistico.Size = new System.Drawing.Size(134, 22);
            this.itm_Var_Listado_Estadistico.Text = "Estadísticas";
            this.itm_Var_Listado_Estadistico.Click += new System.EventHandler(this.itm_Var_Listado_Estadistico_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(131, 6);
            // 
            // itm_Const_Salir
            // 
            this.itm_Const_Salir.Name = "itm_Const_Salir";
            this.itm_Const_Salir.Size = new System.Drawing.Size(134, 22);
            this.itm_Const_Salir.Text = "Salir";
            this.itm_Const_Salir.Click += new System.EventHandler(this.itm_Const_Salir_Click);
            // 
            // itm_Var_Admin
            // 
            this.itm_Var_Admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Var_Facturar_Publicaciones,
            this.toolStripSeparator6,
            this.itm_Var_ABM_de_Rol,
            this.itm_Var_Usuarios,
            this.toolStripSeparator7,
            this.itm_Var_ABM_de_Rubro,
            this.itm_Var_ABM_de_Visibilidad_de_Publicacion});
            this.itm_Var_Admin.Name = "itm_Var_Admin";
            this.itm_Var_Admin.Size = new System.Drawing.Size(100, 20);
            this.itm_Var_Admin.Text = "Administracion";
            // 
            // itm_Var_Facturar_Publicaciones
            // 
            this.itm_Var_Facturar_Publicaciones.Name = "itm_Var_Facturar_Publicaciones";
            this.itm_Var_Facturar_Publicaciones.Size = new System.Drawing.Size(220, 22);
            this.itm_Var_Facturar_Publicaciones.Text = "Facturar publicaciones";
            this.itm_Var_Facturar_Publicaciones.Click += new System.EventHandler(this.itm_Var_Facturar_Publicaciones_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(217, 6);
            // 
            // itm_Var_ABM_de_Rol
            // 
            this.itm_Var_ABM_de_Rol.Name = "itm_Var_ABM_de_Rol";
            this.itm_Var_ABM_de_Rol.Size = new System.Drawing.Size(220, 22);
            this.itm_Var_ABM_de_Rol.Text = "Roles";
            this.itm_Var_ABM_de_Rol.Click += new System.EventHandler(this.itm_Var_ABM_de_Rol_Click);
            // 
            // itm_Var_Usuarios
            // 
            this.itm_Var_Usuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Var_ABM_de_Empresa,
            this.itm_Var_ABM_de_Cliente});
            this.itm_Var_Usuarios.Name = "itm_Var_Usuarios";
            this.itm_Var_Usuarios.Size = new System.Drawing.Size(220, 22);
            this.itm_Var_Usuarios.Text = "Usuarios";
            // 
            // itm_Var_ABM_de_Empresa
            // 
            this.itm_Var_ABM_de_Empresa.Name = "itm_Var_ABM_de_Empresa";
            this.itm_Var_ABM_de_Empresa.Size = new System.Drawing.Size(124, 22);
            this.itm_Var_ABM_de_Empresa.Text = "Empresas";
            this.itm_Var_ABM_de_Empresa.Click += new System.EventHandler(this.itm_Var_ABM_de_Empresa_Click);
            // 
            // itm_Var_ABM_de_Cliente
            // 
            this.itm_Var_ABM_de_Cliente.Name = "itm_Var_ABM_de_Cliente";
            this.itm_Var_ABM_de_Cliente.Size = new System.Drawing.Size(124, 22);
            this.itm_Var_ABM_de_Cliente.Text = "Clientes";
            this.itm_Var_ABM_de_Cliente.Click += new System.EventHandler(this.itm_Var_ABM_de_Cliente_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(217, 6);
            // 
            // itm_Var_ABM_de_Rubro
            // 
            this.itm_Var_ABM_de_Rubro.Name = "itm_Var_ABM_de_Rubro";
            this.itm_Var_ABM_de_Rubro.Size = new System.Drawing.Size(220, 22);
            this.itm_Var_ABM_de_Rubro.Text = "Rubros de publicaciones";
            this.itm_Var_ABM_de_Rubro.Click += new System.EventHandler(this.itm_Var_ABM_de_Rubro_Click);
            // 
            // itm_Var_ABM_de_Visibilidad_de_Publicacion
            // 
            this.itm_Var_ABM_de_Visibilidad_de_Publicacion.Name = "itm_Var_ABM_de_Visibilidad_de_Publicacion";
            this.itm_Var_ABM_de_Visibilidad_de_Publicacion.Size = new System.Drawing.Size(220, 22);
            this.itm_Var_ABM_de_Visibilidad_de_Publicacion.Text = "Visibilidad de publicaciones";
            this.itm_Var_ABM_de_Visibilidad_de_Publicacion.Click += new System.EventHandler(this.itm_Var_ABM_de_Visibilidad_de_Publicacion_Click);
            // 
            // itm_Var_Publicaciones
            // 
            this.itm_Var_Publicaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Var_Nueva_Publicacion,
            this.itm_Var_Editar_Publicacion,
            this.toolStripSeparator9,
            this.itm_Var_Historial_de_Operaciones,
            this.toolStripSeparator8,
            this.itm_Var_Gestion_de_Preguntas});
            this.itm_Var_Publicaciones.Name = "itm_Var_Publicaciones";
            this.itm_Var_Publicaciones.Size = new System.Drawing.Size(92, 20);
            this.itm_Var_Publicaciones.Text = "Publicaciones";
            // 
            // itm_Var_Nueva_Publicacion
            // 
            this.itm_Var_Nueva_Publicacion.Name = "itm_Var_Nueva_Publicacion";
            this.itm_Var_Nueva_Publicacion.Size = new System.Drawing.Size(201, 22);
            this.itm_Var_Nueva_Publicacion.Text = "Nueva publicación";
            this.itm_Var_Nueva_Publicacion.Click += new System.EventHandler(this.itm_Var_Nueva_Publicacion_Click);
            // 
            // itm_Var_Editar_Publicacion
            // 
            this.itm_Var_Editar_Publicacion.Name = "itm_Var_Editar_Publicacion";
            this.itm_Var_Editar_Publicacion.Size = new System.Drawing.Size(201, 22);
            this.itm_Var_Editar_Publicacion.Text = "Editar publicación";
            this.itm_Var_Editar_Publicacion.Click += new System.EventHandler(this.itm_Var_Editar_Publicacion_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(198, 6);
            // 
            // itm_Var_Historial_de_Operaciones
            // 
            this.itm_Var_Historial_de_Operaciones.Name = "itm_Var_Historial_de_Operaciones";
            this.itm_Var_Historial_de_Operaciones.Size = new System.Drawing.Size(201, 22);
            this.itm_Var_Historial_de_Operaciones.Text = "Historial de operaciones";
            this.itm_Var_Historial_de_Operaciones.Click += new System.EventHandler(this.itm_Var_Historial_de_Operaciones_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(198, 6);
            // 
            // itm_Var_Gestion_de_Preguntas
            // 
            this.itm_Var_Gestion_de_Preguntas.Name = "itm_Var_Gestion_de_Preguntas";
            this.itm_Var_Gestion_de_Preguntas.Size = new System.Drawing.Size(201, 22);
            this.itm_Var_Gestion_de_Preguntas.Text = "Gestion de preguntas";
            this.itm_Var_Gestion_de_Preguntas.Click += new System.EventHandler(this.itm_Var_Gestion_de_Preguntas_Click);
            // 
            // itm_Var_Clientes
            // 
            this.itm_Var_Clientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itm_Var_Comprar_Ofertar,
            this.toolStripSeparator1,
            this.itm_Var_Calificar_al_Vendedor});
            this.itm_Var_Clientes.Name = "itm_Var_Clientes";
            this.itm_Var_Clientes.Size = new System.Drawing.Size(61, 20);
            this.itm_Var_Clientes.Text = "Clientes";
            // 
            // itm_Var_Comprar_Ofertar
            // 
            this.itm_Var_Comprar_Ofertar.Name = "itm_Var_Comprar_Ofertar";
            this.itm_Var_Comprar_Ofertar.Size = new System.Drawing.Size(182, 22);
            this.itm_Var_Comprar_Ofertar.Text = "Comprar/Ofertar";
            this.itm_Var_Comprar_Ofertar.Click += new System.EventHandler(this.itm_Var_Comprar_Ofertar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // itm_Var_Calificar_al_Vendedor
            // 
            this.itm_Var_Calificar_al_Vendedor.Name = "itm_Var_Calificar_al_Vendedor";
            this.itm_Var_Calificar_al_Vendedor.Size = new System.Drawing.Size(182, 22);
            this.itm_Var_Calificar_al_Vendedor.Text = "Calificar al vendedor";
            this.itm_Var_Calificar_al_Vendedor.Click += new System.EventHandler(this.itm_Var_Calificar_al_Vendedor_Click);
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFechaSistema,
            this.lblUsuario,
            this.tstNombre});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 467);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1281, 22);
            this.stsBarraEstado.TabIndex = 1;
            this.stsBarraEstado.Text = "statusStrip1";
            // 
            // lblFechaSistema
            // 
            this.lblFechaSistema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblFechaSistema.Name = "lblFechaSistema";
            this.lblFechaSistema.Size = new System.Drawing.Size(41, 17);
            this.lblFechaSistema.Text = "Fecha:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 17);
            this.lblUsuario.Text = "- Usuario: ";
            // 
            // tstNombre
            // 
            this.tstNombre.Name = "tstNombre";
            this.tstNombre.Size = new System.Drawing.Size(0, 17);
            // 
            // tstBarraDebug
            // 
            this.tstBarraDebug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionString,
            this.lblLogPath});
            this.tstBarraDebug.Location = new System.Drawing.Point(0, 445);
            this.tstBarraDebug.Name = "tstBarraDebug";
            this.tstBarraDebug.Size = new System.Drawing.Size(1281, 22);
            this.tstBarraDebug.TabIndex = 2;
            this.tstBarraDebug.Text = "statusStrip1";
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(71, 17);
            this.lblConnectionString.Text = "Conectado: ";
            // 
            // lblLogPath
            // 
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(41, 17);
            this.lblLogPath.Text = " - Log:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1281, 489);
            this.Controls.Add(this.tstBarraDebug);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.mnuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "Inicio";
            this.Text = "FRBA Commerce";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.tstBarraDebug.ResumeLayout(false);
            this.tstBarraDebug.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblFechaSistema;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.StatusStrip tstBarraDebug;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionString;
        private System.Windows.Forms.ToolStripStatusLabel lblLogPath;
        private System.Windows.Forms.ToolStripStatusLabel tstNombre;
        private System.Windows.Forms.ToolStripMenuItem itm_Const_Archivo;
        private System.Windows.Forms.ToolStripMenuItem itm_Const_Sesion;
        private System.Windows.Forms.ToolStripMenuItem itm_Const_Sesion_IniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem itm_Const_Sesion_CerrarSesion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Listado_Estadistico;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem itm_Const_Salir;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Admin;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Facturar_Publicaciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_ABM_de_Rol;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Usuarios;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_ABM_de_Empresa;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_ABM_de_Cliente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_ABM_de_Rubro;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_ABM_de_Visibilidad_de_Publicacion;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Publicaciones;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Nueva_Publicacion;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Editar_Publicacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Historial_de_Operaciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Gestion_de_Preguntas;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Clientes;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Comprar_Ofertar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itm_Var_Calificar_al_Vendedor;

    }
}

