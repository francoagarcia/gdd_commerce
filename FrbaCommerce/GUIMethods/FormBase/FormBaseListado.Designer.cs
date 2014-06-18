namespace FrbaCommerce.GUIMethods.FormBase
{
    partial class FormBaseListado
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.btn_Habilitacion = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.gbAcciones.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAcciones.Controls.Add(this.btn_Seleccionar);
            this.gbAcciones.Controls.Add(this.btn_Habilitacion);
            this.gbAcciones.Controls.Add(this.btnModificacion);
            this.gbAcciones.Controls.Add(this.btnAlta);
            this.gbAcciones.Location = new System.Drawing.Point(11, 385);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(652, 47);
            this.gbAcciones.TabIndex = 7;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Seleccionar.Enabled = false;
            this.btn_Seleccionar.Location = new System.Drawing.Point(571, 18);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.btn_Seleccionar.TabIndex = 6;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Visible = false;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btn_Habilitacion
            // 
            this.btn_Habilitacion.Location = new System.Drawing.Point(169, 18);
            this.btn_Habilitacion.Name = "btn_Habilitacion";
            this.btn_Habilitacion.Size = new System.Drawing.Size(142, 23);
            this.btn_Habilitacion.TabIndex = 5;
            this.btn_Habilitacion.Text = "Habilitar/Deshabilitar";
            this.btn_Habilitacion.UseVisualStyleBackColor = true;
            this.btn_Habilitacion.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(88, 18);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(75, 23);
            this.btnModificacion.TabIndex = 4;
            this.btnModificacion.Text = "Modificación";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(6, 18);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 3;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.Controls.Add(this.dgvBusqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(11, 125);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(652, 254);
            this.gbBusqueda.TabIndex = 6;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.AllowDrop = true;
            this.dgvBusqueda.AllowUserToAddRows = false;
            this.dgvBusqueda.AllowUserToDeleteRows = false;
            this.dgvBusqueda.AllowUserToOrderColumns = true;
            this.dgvBusqueda.AllowUserToResizeRows = false;
            this.dgvBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.Location = new System.Drawing.Point(6, 19);
            this.dgvBusqueda.MultiSelect = false;
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.ReadOnly = true;
            this.dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusqueda.Size = new System.Drawing.Size(640, 229);
            this.dgvBusqueda.TabIndex = 1;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.btnLimpiar);
            this.gbFiltros.Controls.Add(this.btnFiltrar);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(651, 106);
            this.gbFiltros.TabIndex = 5;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros de búsqueda";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(6, 77);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.Location = new System.Drawing.Point(570, 77);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FormBaseListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 444);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBaseListado";
            this.Text = "FormularioBaseListado";
            this.Load += new System.EventHandler(this.FormularioBaseListado_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormularioBaseListado_KeyPress);
            this.gbAcciones.ResumeLayout(false);
            this.gbBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbAcciones;
        protected System.Windows.Forms.Button btn_Habilitacion;
        protected System.Windows.Forms.Button btnModificacion;
        protected System.Windows.Forms.Button btnAlta;
        protected System.Windows.Forms.GroupBox gbBusqueda;
        protected System.Windows.Forms.GroupBox gbFiltros;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnFiltrar;
        protected System.Windows.Forms.Button btn_Seleccionar;
        protected System.Windows.Forms.DataGridView dgvBusqueda;
    }
}