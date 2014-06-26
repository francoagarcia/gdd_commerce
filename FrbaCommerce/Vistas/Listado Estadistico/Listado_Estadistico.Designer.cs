namespace FrbaCommerce.Vistas.Listado_Estadistico
{
    partial class Listado_Estadistico
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
            this.gb_Opciones_estadisticas = new System.Windows.Forms.GroupBox();
            this.lbl_Visibilidad = new System.Windows.Forms.Label();
            this.cb_Visibilidad = new System.Windows.Forms.ComboBox();
            this.lbl_Mes = new System.Windows.Forms.Label();
            this.cb_Mes = new System.Windows.Forms.ComboBox();
            this.cb_Vista = new System.Windows.Forms.ComboBox();
            this.cb_Trimestre = new System.Windows.Forms.ComboBox();
            this.lbl_Año = new System.Windows.Forms.Label();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.cb_Año = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Trimestre = new System.Windows.Forms.Label();
            this.gb_Resultado = new System.Windows.Forms.GroupBox();
            this.dgv_Resultado = new System.Windows.Forms.DataGridView();
            this.gb_Opciones_estadisticas.SuspendLayout();
            this.gb_Resultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Opciones_estadisticas
            // 
            this.gb_Opciones_estadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Opciones_estadisticas.Controls.Add(this.lbl_Visibilidad);
            this.gb_Opciones_estadisticas.Controls.Add(this.cb_Visibilidad);
            this.gb_Opciones_estadisticas.Controls.Add(this.lbl_Mes);
            this.gb_Opciones_estadisticas.Controls.Add(this.cb_Mes);
            this.gb_Opciones_estadisticas.Controls.Add(this.cb_Vista);
            this.gb_Opciones_estadisticas.Controls.Add(this.cb_Trimestre);
            this.gb_Opciones_estadisticas.Controls.Add(this.lbl_Año);
            this.gb_Opciones_estadisticas.Controls.Add(this.btn_Consultar);
            this.gb_Opciones_estadisticas.Controls.Add(this.cb_Año);
            this.gb_Opciones_estadisticas.Controls.Add(this.label2);
            this.gb_Opciones_estadisticas.Controls.Add(this.lbl_Trimestre);
            this.gb_Opciones_estadisticas.Location = new System.Drawing.Point(12, 12);
            this.gb_Opciones_estadisticas.Name = "gb_Opciones_estadisticas";
            this.gb_Opciones_estadisticas.Size = new System.Drawing.Size(668, 100);
            this.gb_Opciones_estadisticas.TabIndex = 0;
            this.gb_Opciones_estadisticas.TabStop = false;
            this.gb_Opciones_estadisticas.Text = "Complete todas las opciones de estadísticas";
            // 
            // lbl_Visibilidad
            // 
            this.lbl_Visibilidad.AutoSize = true;
            this.lbl_Visibilidad.Location = new System.Drawing.Point(149, 54);
            this.lbl_Visibilidad.Name = "lbl_Visibilidad";
            this.lbl_Visibilidad.Size = new System.Drawing.Size(53, 13);
            this.lbl_Visibilidad.TabIndex = 11;
            this.lbl_Visibilidad.Text = "Visibilidad";
            this.lbl_Visibilidad.Visible = false;
            // 
            // cb_Visibilidad
            // 
            this.cb_Visibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Visibilidad.FormattingEnabled = true;
            this.cb_Visibilidad.Location = new System.Drawing.Point(203, 51);
            this.cb_Visibilidad.Name = "cb_Visibilidad";
            this.cb_Visibilidad.Size = new System.Drawing.Size(115, 21);
            this.cb_Visibilidad.TabIndex = 10;
            this.cb_Visibilidad.Visible = false;
            this.cb_Visibilidad.SelectedIndexChanged += new System.EventHandler(this.cb_Visibilidad_SelectedIndexChanged);
            // 
            // lbl_Mes
            // 
            this.lbl_Mes.AutoSize = true;
            this.lbl_Mes.Location = new System.Drawing.Point(6, 54);
            this.lbl_Mes.Name = "lbl_Mes";
            this.lbl_Mes.Size = new System.Drawing.Size(27, 13);
            this.lbl_Mes.TabIndex = 9;
            this.lbl_Mes.Text = "Mes";
            this.lbl_Mes.Visible = false;
            // 
            // cb_Mes
            // 
            this.cb_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Mes.FormattingEnabled = true;
            this.cb_Mes.Location = new System.Drawing.Point(38, 51);
            this.cb_Mes.Name = "cb_Mes";
            this.cb_Mes.Size = new System.Drawing.Size(103, 21);
            this.cb_Mes.TabIndex = 8;
            this.cb_Mes.Visible = false;
            this.cb_Mes.SelectedIndexChanged += new System.EventHandler(this.cb_Mes_SelectedIndexChanged);
            // 
            // cb_Vista
            // 
            this.cb_Vista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Vista.FormattingEnabled = true;
            this.cb_Vista.Location = new System.Drawing.Point(360, 24);
            this.cb_Vista.Name = "cb_Vista";
            this.cb_Vista.Size = new System.Drawing.Size(302, 21);
            this.cb_Vista.TabIndex = 7;
            this.cb_Vista.SelectedIndexChanged += new System.EventHandler(this.cb_Vista_SelectedIndexChanged);
            // 
            // cb_Trimestre
            // 
            this.cb_Trimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Trimestre.FormattingEnabled = true;
            this.cb_Trimestre.Location = new System.Drawing.Point(203, 24);
            this.cb_Trimestre.Name = "cb_Trimestre";
            this.cb_Trimestre.Size = new System.Drawing.Size(115, 21);
            this.cb_Trimestre.TabIndex = 6;
            this.cb_Trimestre.SelectedIndexChanged += new System.EventHandler(this.cb_Trimestre_SelectedIndexChanged);
            // 
            // lbl_Año
            // 
            this.lbl_Año.AutoSize = true;
            this.lbl_Año.Location = new System.Drawing.Point(6, 27);
            this.lbl_Año.Name = "lbl_Año";
            this.lbl_Año.Size = new System.Drawing.Size(26, 13);
            this.lbl_Año.TabIndex = 5;
            this.lbl_Año.Text = "Año";
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Consultar.Enabled = false;
            this.btn_Consultar.Location = new System.Drawing.Point(587, 71);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_Consultar.TabIndex = 3;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = true;
            this.btn_Consultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cb_Año
            // 
            this.cb_Año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Año.FormattingEnabled = true;
            this.cb_Año.Location = new System.Drawing.Point(38, 24);
            this.cb_Año.Name = "cb_Año";
            this.cb_Año.Size = new System.Drawing.Size(103, 21);
            this.cb_Año.TabIndex = 2;
            this.cb_Año.SelectedIndexChanged += new System.EventHandler(this.cb_Año_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vista";
            // 
            // lbl_Trimestre
            // 
            this.lbl_Trimestre.AutoSize = true;
            this.lbl_Trimestre.Location = new System.Drawing.Point(147, 27);
            this.lbl_Trimestre.Name = "lbl_Trimestre";
            this.lbl_Trimestre.Size = new System.Drawing.Size(50, 13);
            this.lbl_Trimestre.TabIndex = 0;
            this.lbl_Trimestre.Text = "Trimestre";
            // 
            // gb_Resultado
            // 
            this.gb_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Resultado.Controls.Add(this.dgv_Resultado);
            this.gb_Resultado.Location = new System.Drawing.Point(12, 118);
            this.gb_Resultado.Name = "gb_Resultado";
            this.gb_Resultado.Size = new System.Drawing.Size(668, 266);
            this.gb_Resultado.TabIndex = 1;
            this.gb_Resultado.TabStop = false;
            this.gb_Resultado.Text = "Resultados";
            // 
            // dgv_Resultado
            // 
            this.dgv_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Resultado.Location = new System.Drawing.Point(9, 19);
            this.dgv_Resultado.Name = "dgv_Resultado";
            this.dgv_Resultado.Size = new System.Drawing.Size(653, 241);
            this.dgv_Resultado.TabIndex = 0;
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 396);
            this.Controls.Add(this.gb_Resultado);
            this.Controls.Add(this.gb_Opciones_estadisticas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Listado_Estadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce - Listados estadísticos";
            this.Load += new System.EventHandler(this.Listado_Estadistico_Load_1);
            this.gb_Opciones_estadisticas.ResumeLayout(false);
            this.gb_Opciones_estadisticas.PerformLayout();
            this.gb_Resultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Opciones_estadisticas;
        private System.Windows.Forms.GroupBox gb_Resultado;
        private System.Windows.Forms.ComboBox cb_Año;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Trimestre;
        private System.Windows.Forms.DataGridView dgv_Resultado;
        private System.Windows.Forms.Button btn_Consultar;
        private System.Windows.Forms.Label lbl_Mes;
        private System.Windows.Forms.ComboBox cb_Mes;
        private System.Windows.Forms.ComboBox cb_Vista;
        private System.Windows.Forms.ComboBox cb_Trimestre;
        private System.Windows.Forms.Label lbl_Año;
        private System.Windows.Forms.Label lbl_Visibilidad;
        private System.Windows.Forms.ComboBox cb_Visibilidad;

    }
}