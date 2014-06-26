namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    partial class ListadoPublicacionesCompra
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
            this.btn_Salir = new System.Windows.Forms.Button();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.lbl_Paginas = new System.Windows.Forms.Label();
            this.btn_Ultima_pagina = new System.Windows.Forms.Button();
            this.btn_Siguiente = new System.Windows.Forms.Button();
            this.btn_Primer_pagina = new System.Windows.Forms.Button();
            this.btn_Anterior = new System.Windows.Forms.Button();
            this.dgv_Busqueda = new System.Windows.Forms.DataGridView();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btn_Seleccionar_rubro = new System.Windows.Forms.Button();
            this.tb_Rubro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Filtrar = new System.Windows.Forms.Button();
            this.gbAcciones.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAcciones.Controls.Add(this.btn_Salir);
            this.gbAcciones.Controls.Add(this.btn_Seleccionar);
            this.gbAcciones.Location = new System.Drawing.Point(11, 411);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(748, 47);
            this.gbAcciones.TabIndex = 7;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btn_Salir
            // 
            this.btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Salir.Location = new System.Drawing.Point(6, 18);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(131, 23);
            this.btn_Salir.TabIndex = 31;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Seleccionar.Location = new System.Drawing.Point(611, 18);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(131, 23);
            this.btn_Seleccionar.TabIndex = 6;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Ver_publicacion_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.Controls.Add(this.lbl_Paginas);
            this.gbBusqueda.Controls.Add(this.btn_Ultima_pagina);
            this.gbBusqueda.Controls.Add(this.btn_Siguiente);
            this.gbBusqueda.Controls.Add(this.btn_Primer_pagina);
            this.gbBusqueda.Controls.Add(this.btn_Anterior);
            this.gbBusqueda.Controls.Add(this.dgv_Busqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(11, 140);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(748, 265);
            this.gbBusqueda.TabIndex = 6;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // lbl_Paginas
            // 
            this.lbl_Paginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_Paginas.AutoSize = true;
            this.lbl_Paginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Paginas.Location = new System.Drawing.Point(318, 234);
            this.lbl_Paginas.Name = "lbl_Paginas";
            this.lbl_Paginas.Size = new System.Drawing.Size(87, 15);
            this.lbl_Paginas.TabIndex = 26;
            this.lbl_Paginas.Text = "Página X/XX";
            // 
            // btn_Ultima_pagina
            // 
            this.btn_Ultima_pagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ultima_pagina.Location = new System.Drawing.Point(631, 231);
            this.btn_Ultima_pagina.Name = "btn_Ultima_pagina";
            this.btn_Ultima_pagina.Size = new System.Drawing.Size(92, 23);
            this.btn_Ultima_pagina.TabIndex = 30;
            this.btn_Ultima_pagina.Text = "Ultima";
            this.btn_Ultima_pagina.UseVisualStyleBackColor = true;
            this.btn_Ultima_pagina.Click += new System.EventHandler(this.btn_Ultima_pagina_Click);
            // 
            // btn_Siguiente
            // 
            this.btn_Siguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Siguiente.Location = new System.Drawing.Point(533, 231);
            this.btn_Siguiente.Name = "btn_Siguiente";
            this.btn_Siguiente.Size = new System.Drawing.Size(92, 23);
            this.btn_Siguiente.TabIndex = 29;
            this.btn_Siguiente.Text = "Siguiente >>";
            this.btn_Siguiente.UseVisualStyleBackColor = true;
            this.btn_Siguiente.Click += new System.EventHandler(this.btn_Siguiente_Click);
            // 
            // btn_Primer_pagina
            // 
            this.btn_Primer_pagina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Primer_pagina.Location = new System.Drawing.Point(24, 231);
            this.btn_Primer_pagina.Name = "btn_Primer_pagina";
            this.btn_Primer_pagina.Size = new System.Drawing.Size(92, 23);
            this.btn_Primer_pagina.TabIndex = 27;
            this.btn_Primer_pagina.Text = "Primera";
            this.btn_Primer_pagina.UseVisualStyleBackColor = true;
            this.btn_Primer_pagina.Click += new System.EventHandler(this.btn_Primer_pagina_Click);
            // 
            // btn_Anterior
            // 
            this.btn_Anterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Anterior.Location = new System.Drawing.Point(122, 231);
            this.btn_Anterior.Name = "btn_Anterior";
            this.btn_Anterior.Size = new System.Drawing.Size(92, 23);
            this.btn_Anterior.TabIndex = 28;
            this.btn_Anterior.Text = "<< Anterior";
            this.btn_Anterior.UseVisualStyleBackColor = true;
            this.btn_Anterior.Click += new System.EventHandler(this.btn_Anterior_Click);
            // 
            // dgv_Busqueda
            // 
            this.dgv_Busqueda.AllowDrop = true;
            this.dgv_Busqueda.AllowUserToAddRows = false;
            this.dgv_Busqueda.AllowUserToDeleteRows = false;
            this.dgv_Busqueda.AllowUserToOrderColumns = true;
            this.dgv_Busqueda.AllowUserToResizeRows = false;
            this.dgv_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Busqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Busqueda.Location = new System.Drawing.Point(6, 19);
            this.dgv_Busqueda.MultiSelect = false;
            this.dgv_Busqueda.Name = "dgv_Busqueda";
            this.dgv_Busqueda.ReadOnly = true;
            this.dgv_Busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Busqueda.Size = new System.Drawing.Size(736, 203);
            this.dgv_Busqueda.TabIndex = 1;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.btn_Seleccionar_rubro);
            this.gbFiltros.Controls.Add(this.tb_Rubro);
            this.gbFiltros.Controls.Add(this.label6);
            this.gbFiltros.Controls.Add(this.tb_Descripcion);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.btn_Limpiar);
            this.gbFiltros.Controls.Add(this.btn_Filtrar);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(747, 122);
            this.gbFiltros.TabIndex = 5;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros de búsqueda";
            // 
            // btn_Seleccionar_rubro
            // 
            this.btn_Seleccionar_rubro.Location = new System.Drawing.Point(651, 54);
            this.btn_Seleccionar_rubro.Name = "btn_Seleccionar_rubro";
            this.btn_Seleccionar_rubro.Size = new System.Drawing.Size(90, 23);
            this.btn_Seleccionar_rubro.TabIndex = 19;
            this.btn_Seleccionar_rubro.Text = "Seleccionar";
            this.btn_Seleccionar_rubro.UseVisualStyleBackColor = true;
            this.btn_Seleccionar_rubro.Click += new System.EventHandler(this.btn_Seleccionar_rubro_Click);
            // 
            // tb_Rubro
            // 
            this.tb_Rubro.Enabled = false;
            this.tb_Rubro.Location = new System.Drawing.Point(87, 56);
            this.tb_Rubro.Name = "tb_Rubro";
            this.tb_Rubro.Size = new System.Drawing.Size(558, 20);
            this.tb_Rubro.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Rubro:";
            // 
            // tb_Descripcion
            // 
            this.tb_Descripcion.Location = new System.Drawing.Point(87, 23);
            this.tb_Descripcion.Name = "tb_Descripcion";
            this.tb_Descripcion.Size = new System.Drawing.Size(558, 20);
            this.tb_Descripcion.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descripcion:";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Limpiar.Location = new System.Drawing.Point(6, 93);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar.TabIndex = 1;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Filtrar
            // 
            this.btn_Filtrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Filtrar.Location = new System.Drawing.Point(666, 93);
            this.btn_Filtrar.Name = "btn_Filtrar";
            this.btn_Filtrar.Size = new System.Drawing.Size(75, 23);
            this.btn_Filtrar.TabIndex = 0;
            this.btn_Filtrar.Text = "Filtrar";
            this.btn_Filtrar.UseVisualStyleBackColor = true;
            this.btn_Filtrar.Click += new System.EventHandler(this.btn_Filtrar_Click);
            // 
            // ListadoPublicacionesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 470);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListadoPublicacionesCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce - Publicaciones";
            this.Load += new System.EventHandler(this.LisadoPublicacionesCompra_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListadoPublicacionesCompra_KeyPress);
            this.gbAcciones.ResumeLayout(false);
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbAcciones;
        protected System.Windows.Forms.GroupBox gbBusqueda;
        protected System.Windows.Forms.GroupBox gbFiltros;
        protected System.Windows.Forms.Button btn_Limpiar;
        protected System.Windows.Forms.Button btn_Filtrar;
        protected System.Windows.Forms.Button btn_Seleccionar;
        protected System.Windows.Forms.DataGridView dgv_Busqueda;
        private System.Windows.Forms.Label lbl_Paginas;
        private System.Windows.Forms.Button btn_Ultima_pagina;
        private System.Windows.Forms.Button btn_Siguiente;
        private System.Windows.Forms.Button btn_Primer_pagina;
        private System.Windows.Forms.Button btn_Anterior;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_Seleccionar_rubro;
        private System.Windows.Forms.TextBox tb_Rubro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Descripcion;
        private System.Windows.Forms.Label label1;
    }
}