namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    partial class FacturarPublicaciones
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
            this.gb_Acciones = new System.Windows.Forms.GroupBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Generar = new System.Windows.Forms.Button();
            this.gb_Busqueda = new System.Windows.Forms.GroupBox();
            this.dgv_Busqueda = new System.Windows.Forms.DataGridView();
            this.gb_Seleccionar_Usuario = new System.Windows.Forms.GroupBox();
            this.btn_Limpiar_usuario_seleccion = new System.Windows.Forms.Button();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.tb_Seleccionar_usuario = new System.Windows.Forms.TextBox();
            this.btn_Seleccionar_usuario = new System.Windows.Forms.Button();
            this.tb_Bonificacion_monto = new System.Windows.Forms.TextBox();
            this.tb_Cantidad_de_bonificaciones = new System.Windows.Forms.TextBox();
            this.lbl_Bonificaciones = new System.Windows.Forms.Label();
            this.lblInfoTarjeta = new System.Windows.Forms.Label();
            this.txtAcum = new System.Windows.Forms.TextBox();
            this.lbl_Total_adeudado = new System.Windows.Forms.Label();
            this.tb_Total_a_facturar = new System.Windows.Forms.TextBox();
            this.lbl_Total_a_facturar = new System.Windows.Forms.Label();
            this.tb_Cantidad_de_items = new System.Windows.Forms.TextBox();
            this.lbl_Cantidad_de_items = new System.Windows.Forms.Label();
            this.cb_Forma_pago = new System.Windows.Forms.ComboBox();
            this.tb_Datos_de_pago = new System.Windows.Forms.TextBox();
            this.lbl_Forma_de_pago = new System.Windows.Forms.Label();
            this.gb_Acciones.SuspendLayout();
            this.gb_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).BeginInit();
            this.gb_Seleccionar_Usuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Acciones
            // 
            this.gb_Acciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Acciones.Controls.Add(this.btn_Cancelar);
            this.gb_Acciones.Controls.Add(this.btn_Limpiar);
            this.gb_Acciones.Controls.Add(this.btn_Generar);
            this.gb_Acciones.Enabled = false;
            this.gb_Acciones.Location = new System.Drawing.Point(11, 514);
            this.gb_Acciones.Name = "gb_Acciones";
            this.gb_Acciones.Size = new System.Drawing.Size(657, 46);
            this.gb_Acciones.TabIndex = 7;
            this.gb_Acciones.TabStop = false;
            this.gb_Acciones.Text = "Acciones";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(6, 19);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(76, 23);
            this.btn_Cancelar.TabIndex = 5;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(490, 17);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar.TabIndex = 4;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Generar
            // 
            this.btn_Generar.Location = new System.Drawing.Point(571, 17);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(75, 23);
            this.btn_Generar.TabIndex = 3;
            this.btn_Generar.Text = "Generar";
            this.btn_Generar.UseVisualStyleBackColor = true;
            // 
            // gb_Busqueda
            // 
            this.gb_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Busqueda.Controls.Add(this.tb_Bonificacion_monto);
            this.gb_Busqueda.Controls.Add(this.dgv_Busqueda);
            this.gb_Busqueda.Controls.Add(this.tb_Cantidad_de_bonificaciones);
            this.gb_Busqueda.Controls.Add(this.lbl_Total_adeudado);
            this.gb_Busqueda.Controls.Add(this.lbl_Bonificaciones);
            this.gb_Busqueda.Controls.Add(this.lbl_Forma_de_pago);
            this.gb_Busqueda.Controls.Add(this.tb_Datos_de_pago);
            this.gb_Busqueda.Controls.Add(this.cb_Forma_pago);
            this.gb_Busqueda.Controls.Add(this.lblInfoTarjeta);
            this.gb_Busqueda.Controls.Add(this.lbl_Cantidad_de_items);
            this.gb_Busqueda.Controls.Add(this.txtAcum);
            this.gb_Busqueda.Controls.Add(this.tb_Cantidad_de_items);
            this.gb_Busqueda.Controls.Add(this.lbl_Total_a_facturar);
            this.gb_Busqueda.Controls.Add(this.tb_Total_a_facturar);
            this.gb_Busqueda.Enabled = false;
            this.gb_Busqueda.Location = new System.Drawing.Point(11, 106);
            this.gb_Busqueda.Name = "gb_Busqueda";
            this.gb_Busqueda.Size = new System.Drawing.Size(657, 402);
            this.gb_Busqueda.TabIndex = 6;
            this.gb_Busqueda.TabStop = false;
            this.gb_Busqueda.Text = "Búsqueda";
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
            this.dgv_Busqueda.Size = new System.Drawing.Size(645, 302);
            this.dgv_Busqueda.TabIndex = 1;
            // 
            // gb_Seleccionar_Usuario
            // 
            this.gb_Seleccionar_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Seleccionar_Usuario.Controls.Add(this.btn_Seleccionar_usuario);
            this.gb_Seleccionar_Usuario.Controls.Add(this.tb_Seleccionar_usuario);
            this.gb_Seleccionar_Usuario.Controls.Add(this.lbl_Usuario);
            this.gb_Seleccionar_Usuario.Controls.Add(this.btn_Limpiar_usuario_seleccion);
            this.gb_Seleccionar_Usuario.Controls.Add(this.btn_Aceptar);
            this.gb_Seleccionar_Usuario.Location = new System.Drawing.Point(12, 12);
            this.gb_Seleccionar_Usuario.Name = "gb_Seleccionar_Usuario";
            this.gb_Seleccionar_Usuario.Size = new System.Drawing.Size(656, 88);
            this.gb_Seleccionar_Usuario.TabIndex = 5;
            this.gb_Seleccionar_Usuario.TabStop = false;
            this.gb_Seleccionar_Usuario.Text = "Seleccionar usuario";
            // 
            // btn_Limpiar_usuario_seleccion
            // 
            this.btn_Limpiar_usuario_seleccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Limpiar_usuario_seleccion.Location = new System.Drawing.Point(6, 59);
            this.btn_Limpiar_usuario_seleccion.Name = "btn_Limpiar_usuario_seleccion";
            this.btn_Limpiar_usuario_seleccion.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar_usuario_seleccion.TabIndex = 1;
            this.btn_Limpiar_usuario_seleccion.Text = "Limpiar";
            this.btn_Limpiar_usuario_seleccion.UseVisualStyleBackColor = true;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Aceptar.Location = new System.Drawing.Point(575, 59);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_Aceptar.TabIndex = 0;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.Location = new System.Drawing.Point(40, 32);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(189, 13);
            this.lbl_Usuario.TabIndex = 2;
            this.lbl_Usuario.Text = "Seleccionar un usuario para continuar:";
            // 
            // tb_Seleccionar_usuario
            // 
            this.tb_Seleccionar_usuario.Enabled = false;
            this.tb_Seleccionar_usuario.Location = new System.Drawing.Point(235, 29);
            this.tb_Seleccionar_usuario.Name = "tb_Seleccionar_usuario";
            this.tb_Seleccionar_usuario.Size = new System.Drawing.Size(242, 20);
            this.tb_Seleccionar_usuario.TabIndex = 8;
            // 
            // btn_Seleccionar_usuario
            // 
            this.btn_Seleccionar_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Seleccionar_usuario.Location = new System.Drawing.Point(489, 27);
            this.btn_Seleccionar_usuario.Name = "btn_Seleccionar_usuario";
            this.btn_Seleccionar_usuario.Size = new System.Drawing.Size(75, 23);
            this.btn_Seleccionar_usuario.TabIndex = 9;
            this.btn_Seleccionar_usuario.Text = "Seleccionar";
            this.btn_Seleccionar_usuario.UseVisualStyleBackColor = true;
            this.btn_Seleccionar_usuario.Click += new System.EventHandler(this.btn_Seleccionar_usuario_Click);
            // 
            // tb_Bonificacion_monto
            // 
            this.tb_Bonificacion_monto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Bonificacion_monto.BackColor = System.Drawing.Color.LightYellow;
            this.tb_Bonificacion_monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Bonificacion_monto.Location = new System.Drawing.Point(175, 353);
            this.tb_Bonificacion_monto.Name = "tb_Bonificacion_monto";
            this.tb_Bonificacion_monto.ReadOnly = true;
            this.tb_Bonificacion_monto.Size = new System.Drawing.Size(80, 20);
            this.tb_Bonificacion_monto.TabIndex = 29;
            this.tb_Bonificacion_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_Cantidad_de_bonificaciones
            // 
            this.tb_Cantidad_de_bonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Cantidad_de_bonificaciones.BackColor = System.Drawing.Color.LightYellow;
            this.tb_Cantidad_de_bonificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Cantidad_de_bonificaciones.Location = new System.Drawing.Point(140, 353);
            this.tb_Cantidad_de_bonificaciones.Name = "tb_Cantidad_de_bonificaciones";
            this.tb_Cantidad_de_bonificaciones.ReadOnly = true;
            this.tb_Cantidad_de_bonificaciones.Size = new System.Drawing.Size(29, 20);
            this.tb_Cantidad_de_bonificaciones.TabIndex = 28;
            this.tb_Cantidad_de_bonificaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Bonificaciones
            // 
            this.lbl_Bonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Bonificaciones.AutoSize = true;
            this.lbl_Bonificaciones.Location = new System.Drawing.Point(32, 356);
            this.lbl_Bonificaciones.Name = "lbl_Bonificaciones";
            this.lbl_Bonificaciones.Size = new System.Drawing.Size(88, 13);
            this.lbl_Bonificaciones.TabIndex = 37;
            this.lbl_Bonificaciones.Text = "Bonnificaciones :";
            // 
            // lblInfoTarjeta
            // 
            this.lblInfoTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoTarjeta.AutoSize = true;
            this.lblInfoTarjeta.Location = new System.Drawing.Point(273, 380);
            this.lblInfoTarjeta.Name = "lblInfoTarjeta";
            this.lblInfoTarjeta.Size = new System.Drawing.Size(80, 13);
            this.lblInfoTarjeta.TabIndex = 35;
            this.lblInfoTarjeta.Text = "Datos de pago:";
            // 
            // txtAcum
            // 
            this.txtAcum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAcum.BackColor = System.Drawing.SystemColors.Info;
            this.txtAcum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcum.Location = new System.Drawing.Point(140, 327);
            this.txtAcum.Name = "txtAcum";
            this.txtAcum.ReadOnly = true;
            this.txtAcum.Size = new System.Drawing.Size(115, 20);
            this.txtAcum.TabIndex = 23;
            this.txtAcum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Total_adeudado
            // 
            this.lbl_Total_adeudado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Total_adeudado.AutoSize = true;
            this.lbl_Total_adeudado.Location = new System.Drawing.Point(31, 330);
            this.lbl_Total_adeudado.Name = "lbl_Total_adeudado";
            this.lbl_Total_adeudado.Size = new System.Drawing.Size(88, 13);
            this.lbl_Total_adeudado.TabIndex = 34;
            this.lbl_Total_adeudado.Text = "Total adeudado :";
            // 
            // tb_Total_a_facturar
            // 
            this.tb_Total_a_facturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Total_a_facturar.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Total_a_facturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Total_a_facturar.Location = new System.Drawing.Point(380, 353);
            this.tb_Total_a_facturar.Name = "tb_Total_a_facturar";
            this.tb_Total_a_facturar.ReadOnly = true;
            this.tb_Total_a_facturar.Size = new System.Drawing.Size(98, 20);
            this.tb_Total_a_facturar.TabIndex = 30;
            this.tb_Total_a_facturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Total_a_facturar
            // 
            this.lbl_Total_a_facturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Total_a_facturar.AutoSize = true;
            this.lbl_Total_a_facturar.Location = new System.Drawing.Point(273, 356);
            this.lbl_Total_a_facturar.Name = "lbl_Total_a_facturar";
            this.lbl_Total_a_facturar.Size = new System.Drawing.Size(85, 13);
            this.lbl_Total_a_facturar.TabIndex = 33;
            this.lbl_Total_a_facturar.Text = "Total a facturar :";
            // 
            // tb_Cantidad_de_items
            // 
            this.tb_Cantidad_de_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Cantidad_de_items.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Cantidad_de_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Cantidad_de_items.Location = new System.Drawing.Point(380, 327);
            this.tb_Cantidad_de_items.Name = "tb_Cantidad_de_items";
            this.tb_Cantidad_de_items.ReadOnly = true;
            this.tb_Cantidad_de_items.Size = new System.Drawing.Size(98, 20);
            this.tb_Cantidad_de_items.TabIndex = 25;
            this.tb_Cantidad_de_items.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Cantidad_de_items
            // 
            this.lbl_Cantidad_de_items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Cantidad_de_items.AutoSize = true;
            this.lbl_Cantidad_de_items.Location = new System.Drawing.Point(273, 330);
            this.lbl_Cantidad_de_items.Name = "lbl_Cantidad_de_items";
            this.lbl_Cantidad_de_items.Size = new System.Drawing.Size(97, 13);
            this.lbl_Cantidad_de_items.TabIndex = 31;
            this.lbl_Cantidad_de_items.Text = "Cantidad de items :";
            // 
            // cb_Forma_pago
            // 
            this.cb_Forma_pago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Forma_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Forma_pago.FormattingEnabled = true;
            this.cb_Forma_pago.Location = new System.Drawing.Point(140, 375);
            this.cb_Forma_pago.Name = "cb_Forma_pago";
            this.cb_Forma_pago.Size = new System.Drawing.Size(115, 21);
            this.cb_Forma_pago.TabIndex = 27;
            // 
            // tb_Datos_de_pago
            // 
            this.tb_Datos_de_pago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Datos_de_pago.BackColor = System.Drawing.Color.LightYellow;
            this.tb_Datos_de_pago.Location = new System.Drawing.Point(380, 377);
            this.tb_Datos_de_pago.MaxLength = 255;
            this.tb_Datos_de_pago.Name = "tb_Datos_de_pago";
            this.tb_Datos_de_pago.Size = new System.Drawing.Size(266, 20);
            this.tb_Datos_de_pago.TabIndex = 32;
            // 
            // lbl_Forma_de_pago
            // 
            this.lbl_Forma_de_pago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Forma_de_pago.AutoSize = true;
            this.lbl_Forma_de_pago.Location = new System.Drawing.Point(31, 380);
            this.lbl_Forma_de_pago.Name = "lbl_Forma_de_pago";
            this.lbl_Forma_de_pago.Size = new System.Drawing.Size(84, 13);
            this.lbl_Forma_de_pago.TabIndex = 26;
            this.lbl_Forma_de_pago.Text = "Forma de pago :";
            // 
            // FacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 572);
            this.Controls.Add(this.gb_Acciones);
            this.Controls.Add(this.gb_Busqueda);
            this.Controls.Add(this.gb_Seleccionar_Usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacturarPublicaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioBaseListado";
            this.Load += new System.EventHandler(this.FacturarPublicaciones_Load);
            this.gb_Acciones.ResumeLayout(false);
            this.gb_Busqueda.ResumeLayout(false);
            this.gb_Busqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).EndInit();
            this.gb_Seleccionar_Usuario.ResumeLayout(false);
            this.gb_Seleccionar_Usuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gb_Acciones;
        protected System.Windows.Forms.Button btn_Cancelar;
        protected System.Windows.Forms.Button btn_Limpiar;
        protected System.Windows.Forms.Button btn_Generar;
        protected System.Windows.Forms.GroupBox gb_Busqueda;
        protected System.Windows.Forms.GroupBox gb_Seleccionar_Usuario;
        protected System.Windows.Forms.Button btn_Limpiar_usuario_seleccion;
        protected System.Windows.Forms.Button btn_Aceptar;
        protected System.Windows.Forms.DataGridView dgv_Busqueda;
        private System.Windows.Forms.Label lbl_Usuario;
        protected System.Windows.Forms.Button btn_Seleccionar_usuario;
        private System.Windows.Forms.TextBox tb_Seleccionar_usuario;
        private System.Windows.Forms.TextBox tb_Bonificacion_monto;
        private System.Windows.Forms.TextBox tb_Cantidad_de_bonificaciones;
        private System.Windows.Forms.Label lbl_Total_adeudado;
        private System.Windows.Forms.Label lbl_Bonificaciones;
        private System.Windows.Forms.Label lbl_Forma_de_pago;
        private System.Windows.Forms.TextBox tb_Datos_de_pago;
        private System.Windows.Forms.ComboBox cb_Forma_pago;
        private System.Windows.Forms.Label lblInfoTarjeta;
        private System.Windows.Forms.Label lbl_Cantidad_de_items;
        private System.Windows.Forms.TextBox txtAcum;
        private System.Windows.Forms.TextBox tb_Cantidad_de_items;
        private System.Windows.Forms.Label lbl_Total_a_facturar;
        private System.Windows.Forms.TextBox tb_Total_a_facturar;
    }
}