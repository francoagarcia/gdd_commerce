namespace FrbaCommerce.Vistas.Abm_Cliente
{
    partial class ListadoCliente
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
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Numero_de_Documento = new System.Windows.Forms.TextBox();
            this.cb_Tipo_de_documento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Mail = new System.Windows.Forms.TextBox();
            this.tb_Telefono = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.tb_Apellido = new System.Windows.Forms.TextBox();
            this.lbl_Mail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Nombre = new System.Windows.Forms.TextBox();
            this.chBox_Habilitados = new System.Windows.Forms.CheckBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Location = new System.Drawing.Point(11, 431);
            this.gbAcciones.Size = new System.Drawing.Size(609, 47);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Location = new System.Drawing.Point(11, 192);
            this.gbBusqueda.Size = new System.Drawing.Size(609, 233);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.chBox_Habilitados);
            this.gbFiltros.Controls.Add(this.tb_Mail);
            this.gbFiltros.Controls.Add(this.labelTelefono);
            this.gbFiltros.Controls.Add(this.tb_Apellido);
            this.gbFiltros.Controls.Add(this.lbl_Mail);
            this.gbFiltros.Controls.Add(this.label4);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.tb_Telefono);
            this.gbFiltros.Controls.Add(this.tb_Nombre);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.label5);
            this.gbFiltros.Controls.Add(this.tb_Numero_de_Documento);
            this.gbFiltros.Controls.Add(this.cb_Tipo_de_documento);
            this.gbFiltros.Size = new System.Drawing.Size(608, 174);
            this.gbFiltros.Controls.SetChildIndex(this.cb_Tipo_de_documento, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Numero_de_Documento, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label5, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Nombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Telefono, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label3, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label4, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lbl_Mail, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Apellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.labelTelefono, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Mail, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.chBox_Habilitados, 0);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(6, 145);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(527, 145);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(528, 18);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Documento";
            // 
            // tb_Numero_de_Documento
            // 
            this.tb_Numero_de_Documento.AcceptsTab = true;
            this.tb_Numero_de_Documento.Location = new System.Drawing.Point(356, 28);
            this.tb_Numero_de_Documento.Name = "tb_Numero_de_Documento";
            this.tb_Numero_de_Documento.Size = new System.Drawing.Size(219, 20);
            this.tb_Numero_de_Documento.TabIndex = 10;
            // 
            // cb_Tipo_de_documento
            // 
            this.cb_Tipo_de_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_de_documento.FormattingEnabled = true;
            this.cb_Tipo_de_documento.ItemHeight = 13;
            this.cb_Tipo_de_documento.Location = new System.Drawing.Point(111, 28);
            this.cb_Tipo_de_documento.Name = "cb_Tipo_de_documento";
            this.cb_Tipo_de_documento.Size = new System.Drawing.Size(168, 21);
            this.cb_Tipo_de_documento.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tipo de documento";
            // 
            // tb_Mail
            // 
            this.tb_Mail.AcceptsTab = true;
            this.tb_Mail.Location = new System.Drawing.Point(356, 86);
            this.tb_Mail.Name = "tb_Mail";
            this.tb_Mail.Size = new System.Drawing.Size(219, 20);
            this.tb_Mail.TabIndex = 27;
            // 
            // tb_Telefono
            // 
            this.tb_Telefono.AcceptsTab = true;
            this.tb_Telefono.Location = new System.Drawing.Point(356, 57);
            this.tb_Telefono.Name = "tb_Telefono";
            this.tb_Telefono.Size = new System.Drawing.Size(219, 20);
            this.tb_Telefono.TabIndex = 26;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(288, 60);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(49, 13);
            this.labelTelefono.TabIndex = 32;
            this.labelTelefono.Text = "Telefono";
            // 
            // tb_Apellido
            // 
            this.tb_Apellido.AcceptsTab = true;
            this.tb_Apellido.Location = new System.Drawing.Point(60, 86);
            this.tb_Apellido.Name = "tb_Apellido";
            this.tb_Apellido.Size = new System.Drawing.Size(219, 20);
            this.tb_Apellido.TabIndex = 24;
            // 
            // lbl_Mail
            // 
            this.lbl_Mail.AutoSize = true;
            this.lbl_Mail.Location = new System.Drawing.Point(288, 89);
            this.lbl_Mail.Name = "lbl_Mail";
            this.lbl_Mail.Size = new System.Drawing.Size(26, 13);
            this.lbl_Mail.TabIndex = 33;
            this.lbl_Mail.Text = "Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nombre";
            // 
            // tb_Nombre
            // 
            this.tb_Nombre.AcceptsTab = true;
            this.tb_Nombre.Location = new System.Drawing.Point(60, 57);
            this.tb_Nombre.Name = "tb_Nombre";
            this.tb_Nombre.Size = new System.Drawing.Size(219, 20);
            this.tb_Nombre.TabIndex = 22;
            // 
            // chBox_Habilitados
            // 
            this.chBox_Habilitados.AutoSize = true;
            this.chBox_Habilitados.Location = new System.Drawing.Point(291, 112);
            this.chBox_Habilitados.Name = "chBox_Habilitados";
            this.chBox_Habilitados.Size = new System.Drawing.Size(78, 17);
            this.chBox_Habilitados.TabIndex = 35;
            this.chBox_Habilitados.Text = "Habilitados";
            this.chBox_Habilitados.UseVisualStyleBackColor = true;
            // 
            // ListadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 490);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ListadoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce - Listado de clientes";
            this.Load += new System.EventHandler(this.ListadoCliente_Load);
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Mail;
        private System.Windows.Forms.TextBox tb_Telefono;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.TextBox tb_Apellido;
        private System.Windows.Forms.Label lbl_Mail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Numero_de_Documento;
        private System.Windows.Forms.ComboBox cb_Tipo_de_documento;
        private System.Windows.Forms.CheckBox chBox_Habilitados;
    }
}