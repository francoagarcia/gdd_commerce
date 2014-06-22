namespace FrbaCommerce.Vistas.Generar_Publicacion
{
    partial class GenerarPublicacion
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
            this.btn_Atras = new System.Windows.Forms.Button();
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
            this.label9 = new System.Windows.Forms.Label();
            this.cb_Visibilidad = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.list_Rubros = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Precio)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Atras
            // 
            this.btn_Atras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Atras.Location = new System.Drawing.Point(29, 436);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 26;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
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
            this.btn_Generar.Text = "Generar";
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
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cb_Visibilidad);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.list_Rubros);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_Descripcion);
            this.groupBox1.Controls.Add(this.label2);
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
            this.tb_Fecha_de_vencimiento.Location = new System.Drawing.Point(93, 291);
            this.tb_Fecha_de_vencimiento.Name = "tb_Fecha_de_vencimiento";
            this.tb_Fecha_de_vencimiento.ReadOnly = true;
            this.tb_Fecha_de_vencimiento.Size = new System.Drawing.Size(197, 21);
            this.tb_Fecha_de_vencimiento.TabIndex = 38;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Estado :";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "Visibilidad :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Selección de Rubro :";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "Precio :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Fecha Vto. :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Fecha Inicio :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Stock :";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Descripción :";
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Generar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerarPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce - Generar publicación";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Precio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Generar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dp_Fecha_inicio;
        private System.Windows.Forms.NumericUpDown nud_Stock;
        private System.Windows.Forms.NumericUpDown nud_Precio;
        private System.Windows.Forms.CheckBox chk_Permite_preguntas;
        private System.Windows.Forms.ComboBox cb_Estado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_Visibilidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox list_Rubros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Fecha_de_vencimiento;
    }
}