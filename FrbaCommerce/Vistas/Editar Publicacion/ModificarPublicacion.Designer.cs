namespace FrbaCommerce.Vistas.Editar_Publicacion
{
    partial class ModificarPublicacion
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
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Generar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Fecha_de_vencimiento = new System.Windows.Forms.TextBox();
            this.dp_Fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.nud_Stock = new System.Windows.Forms.NumericUpDown();
            this.nud_Precio = new System.Windows.Forms.NumericUpDown();
            this.chk_Permite_preguntas = new System.Windows.Forms.CheckBox();
            this.cb_Estado = new System.Windows.Forms.ComboBox();
            this.lbl_Estado = new System.Windows.Forms.Label();
            this.cb_Visibilidad = new System.Windows.Forms.ComboBox();
            this.lbl_Visibilidad = new System.Windows.Forms.Label();
            this.lbl_Seleccion_de_rubros = new System.Windows.Forms.Label();
            this.list_Rubros = new System.Windows.Forms.CheckedListBox();
            this.lbl_Precio = new System.Windows.Forms.Label();
            this.lbl_Fecha_de_vencimiento = new System.Windows.Forms.Label();
            this.lbl_Fecha_de_inicio = new System.Windows.Forms.Label();
            this.lbl_Stock = new System.Windows.Forms.Label();
            this.tb_Descripcion = new System.Windows.Forms.TextBox();
            this.lbl_Descripcion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Precio)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar.Location = new System.Drawing.Point(428, 436);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 25;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Limpiar.Location = new System.Drawing.Point(509, 436);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar.TabIndex = 24;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Generar
            // 
            this.btn_Generar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Generar.Location = new System.Drawing.Point(590, 436);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(75, 23);
            this.btn_Generar.TabIndex = 23;
            this.btn_Generar.Text = "Guardar";
            this.btn_Generar.UseVisualStyleBackColor = true;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Fecha_de_vencimiento);
            this.groupBox1.Controls.Add(this.dp_Fecha_inicio);
            this.groupBox1.Controls.Add(this.nud_Stock);
            this.groupBox1.Controls.Add(this.nud_Precio);
            this.groupBox1.Controls.Add(this.chk_Permite_preguntas);
            this.groupBox1.Controls.Add(this.cb_Estado);
            this.groupBox1.Controls.Add(this.lbl_Estado);
            this.groupBox1.Controls.Add(this.cb_Visibilidad);
            this.groupBox1.Controls.Add(this.lbl_Visibilidad);
            this.groupBox1.Controls.Add(this.lbl_Seleccion_de_rubros);
            this.groupBox1.Controls.Add(this.list_Rubros);
            this.groupBox1.Controls.Add(this.lbl_Precio);
            this.groupBox1.Controls.Add(this.lbl_Fecha_de_vencimiento);
            this.groupBox1.Controls.Add(this.lbl_Fecha_de_inicio);
            this.groupBox1.Controls.Add(this.lbl_Stock);
            this.groupBox1.Controls.Add(this.tb_Descripcion);
            this.groupBox1.Controls.Add(this.lbl_Descripcion);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 418);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese los datos solicitados";
            // 
            // tb_Fecha_de_vencimiento
            // 
            this.tb_Fecha_de_vencimiento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tb_Fecha_de_vencimiento.Location = new System.Drawing.Point(93, 295);
            this.tb_Fecha_de_vencimiento.Name = "tb_Fecha_de_vencimiento";
            this.tb_Fecha_de_vencimiento.ReadOnly = true;
            this.tb_Fecha_de_vencimiento.Size = new System.Drawing.Size(197, 21);
            this.tb_Fecha_de_vencimiento.TabIndex = 39;
            // 
            // dp_Fecha_inicio
            // 
            this.dp_Fecha_inicio.Location = new System.Drawing.Point(92, 268);
            this.dp_Fecha_inicio.Name = "dp_Fecha_inicio";
            this.dp_Fecha_inicio.Size = new System.Drawing.Size(198, 21);
            this.dp_Fecha_inicio.TabIndex = 37;
            this.dp_Fecha_inicio.ValueChanged += new System.EventHandler(this.dp_Fecha_inicio_ValueChanged);
            // 
            // nud_Stock
            // 
            this.nud_Stock.Location = new System.Drawing.Point(93, 214);
            this.nud_Stock.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nud_Stock.Name = "nud_Stock";
            this.nud_Stock.Size = new System.Drawing.Size(197, 21);
            this.nud_Stock.TabIndex = 27;
            this.nud_Stock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Stock.ValueChanged += new System.EventHandler(this.nud_Stock_ValueChanged);
            // 
            // nud_Precio
            // 
            this.nud_Precio.DecimalPlaces = 2;
            this.nud_Precio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_Precio.Location = new System.Drawing.Point(93, 240);
            this.nud_Precio.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nud_Precio.Name = "nud_Precio";
            this.nud_Precio.Size = new System.Drawing.Size(197, 21);
            this.nud_Precio.TabIndex = 28;
            this.nud_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Precio.ThousandsSeparator = true;
            // 
            // chk_Permite_preguntas
            // 
            this.chk_Permite_preguntas.AutoSize = true;
            this.chk_Permite_preguntas.Location = new System.Drawing.Point(19, 355);
            this.chk_Permite_preguntas.Name = "chk_Permite_preguntas";
            this.chk_Permite_preguntas.Size = new System.Drawing.Size(128, 19);
            this.chk_Permite_preguntas.TabIndex = 31;
            this.chk_Permite_preguntas.Text = "Permite Preguntas";
            this.chk_Permite_preguntas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Permite_preguntas.UseVisualStyleBackColor = true;
            // 
            // cb_Estado
            // 
            this.cb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Estado.FormattingEnabled = true;
            this.cb_Estado.Location = new System.Drawing.Point(93, 186);
            this.cb_Estado.Name = "cb_Estado";
            this.cb_Estado.Size = new System.Drawing.Size(197, 23);
            this.cb_Estado.TabIndex = 25;
            // 
            // lbl_Estado
            // 
            this.lbl_Estado.AutoSize = true;
            this.lbl_Estado.Location = new System.Drawing.Point(16, 189);
            this.lbl_Estado.Name = "lbl_Estado";
            this.lbl_Estado.Size = new System.Drawing.Size(51, 15);
            this.lbl_Estado.TabIndex = 36;
            this.lbl_Estado.Text = "Estado :";
            // 
            // cb_Visibilidad
            // 
            this.cb_Visibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Visibilidad.FormattingEnabled = true;
            this.cb_Visibilidad.Location = new System.Drawing.Point(93, 159);
            this.cb_Visibilidad.Name = "cb_Visibilidad";
            this.cb_Visibilidad.Size = new System.Drawing.Size(197, 23);
            this.cb_Visibilidad.TabIndex = 24;
            this.cb_Visibilidad.SelectedIndexChanged += new System.EventHandler(this.cb_Visibilidad_SelectedIndexChanged);
            // 
            // lbl_Visibilidad
            // 
            this.lbl_Visibilidad.AutoSize = true;
            this.lbl_Visibilidad.Location = new System.Drawing.Point(16, 162);
            this.lbl_Visibilidad.Name = "lbl_Visibilidad";
            this.lbl_Visibilidad.Size = new System.Drawing.Size(69, 15);
            this.lbl_Visibilidad.TabIndex = 35;
            this.lbl_Visibilidad.Text = "Visibilidad :";
            // 
            // lbl_Seleccion_de_rubros
            // 
            this.lbl_Seleccion_de_rubros.AutoSize = true;
            this.lbl_Seleccion_de_rubros.Location = new System.Drawing.Point(310, 162);
            this.lbl_Seleccion_de_rubros.Name = "lbl_Seleccion_de_rubros";
            this.lbl_Seleccion_de_rubros.Size = new System.Drawing.Size(121, 15);
            this.lbl_Seleccion_de_rubros.TabIndex = 34;
            this.lbl_Seleccion_de_rubros.Text = "Selección de Rubro :";
            // 
            // list_Rubros
            // 
            this.list_Rubros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list_Rubros.CheckOnClick = true;
            this.list_Rubros.FormattingEnabled = true;
            this.list_Rubros.Location = new System.Drawing.Point(313, 178);
            this.list_Rubros.Name = "list_Rubros";
            this.list_Rubros.Size = new System.Drawing.Size(342, 196);
            this.list_Rubros.TabIndex = 32;
            this.list_Rubros.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.list_Rubros_ItemCheck);
            // 
            // lbl_Precio
            // 
            this.lbl_Precio.AutoSize = true;
            this.lbl_Precio.Location = new System.Drawing.Point(16, 242);
            this.lbl_Precio.Name = "lbl_Precio";
            this.lbl_Precio.Size = new System.Drawing.Size(48, 15);
            this.lbl_Precio.TabIndex = 33;
            this.lbl_Precio.Text = "Precio :";
            // 
            // lbl_Fecha_de_vencimiento
            // 
            this.lbl_Fecha_de_vencimiento.AutoSize = true;
            this.lbl_Fecha_de_vencimiento.Location = new System.Drawing.Point(16, 294);
            this.lbl_Fecha_de_vencimiento.Name = "lbl_Fecha_de_vencimiento";
            this.lbl_Fecha_de_vencimiento.Size = new System.Drawing.Size(70, 15);
            this.lbl_Fecha_de_vencimiento.TabIndex = 30;
            this.lbl_Fecha_de_vencimiento.Text = "Fecha Vto. :";
            // 
            // lbl_Fecha_de_inicio
            // 
            this.lbl_Fecha_de_inicio.AutoSize = true;
            this.lbl_Fecha_de_inicio.Location = new System.Drawing.Point(16, 268);
            this.lbl_Fecha_de_inicio.Name = "lbl_Fecha_de_inicio";
            this.lbl_Fecha_de_inicio.Size = new System.Drawing.Size(79, 15);
            this.lbl_Fecha_de_inicio.TabIndex = 29;
            this.lbl_Fecha_de_inicio.Text = "Fecha Inicio :";
            // 
            // lbl_Stock
            // 
            this.lbl_Stock.AutoSize = true;
            this.lbl_Stock.Location = new System.Drawing.Point(16, 216);
            this.lbl_Stock.Name = "lbl_Stock";
            this.lbl_Stock.Size = new System.Drawing.Size(43, 15);
            this.lbl_Stock.TabIndex = 26;
            this.lbl_Stock.Text = "Stock :";
            // 
            // tb_Descripcion
            // 
            this.tb_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Descripcion.Location = new System.Drawing.Point(19, 37);
            this.tb_Descripcion.MaxLength = 255;
            this.tb_Descripcion.Multiline = true;
            this.tb_Descripcion.Name = "tb_Descripcion";
            this.tb_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Descripcion.Size = new System.Drawing.Size(636, 107);
            this.tb_Descripcion.TabIndex = 22;
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.AutoSize = true;
            this.lbl_Descripcion.Location = new System.Drawing.Point(16, 21);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(78, 15);
            this.lbl_Descripcion.TabIndex = 23;
            this.lbl_Descripcion.Text = "Descripción :";
            // 
            // ModificarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Generar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModificarPublicacion";
            this.Text = "FRBA Commerce -Editar publicación";
            this.Load += new System.EventHandler(this.ModificarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Precio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Generar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dp_Fecha_inicio;
        private System.Windows.Forms.NumericUpDown nud_Stock;
        private System.Windows.Forms.NumericUpDown nud_Precio;
        private System.Windows.Forms.CheckBox chk_Permite_preguntas;
        private System.Windows.Forms.ComboBox cb_Estado;
        private System.Windows.Forms.Label lbl_Estado;
        private System.Windows.Forms.ComboBox cb_Visibilidad;
        private System.Windows.Forms.Label lbl_Visibilidad;
        private System.Windows.Forms.Label lbl_Seleccion_de_rubros;
        private System.Windows.Forms.CheckedListBox list_Rubros;
        private System.Windows.Forms.Label lbl_Precio;
        private System.Windows.Forms.Label lbl_Fecha_de_vencimiento;
        private System.Windows.Forms.Label lbl_Fecha_de_inicio;
        private System.Windows.Forms.Label lbl_Stock;
        private System.Windows.Forms.TextBox tb_Descripcion;
        private System.Windows.Forms.Label lbl_Descripcion;
        private System.Windows.Forms.TextBox tb_Fecha_de_vencimiento;


    }
}