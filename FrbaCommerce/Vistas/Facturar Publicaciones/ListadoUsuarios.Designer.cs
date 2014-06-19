namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    partial class ListadoUsuarios
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
            this.lbl_Nombre_de_usuario = new System.Windows.Forms.Label();
            this.tb_Nombre_de_usuario = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_Telefono = new System.Windows.Forms.Label();
            this.tb_Telefono = new System.Windows.Forms.TextBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Controls.Add(this.btn_Cancelar);
            this.gbAcciones.Size = new System.Drawing.Size(370, 47);
            this.gbAcciones.Controls.SetChildIndex(this.btnAlta, 0);
            this.gbAcciones.Controls.SetChildIndex(this.btnModificacion, 0);
            this.gbAcciones.Controls.SetChildIndex(this.btn_Habilitacion, 0);
            this.gbAcciones.Controls.SetChildIndex(this.btn_Seleccionar, 0);
            this.gbAcciones.Controls.SetChildIndex(this.btn_Cancelar, 0);
            // 
            // btn_Habilitacion
            // 
            this.btn_Habilitacion.Size = new System.Drawing.Size(57, 23);
            this.btn_Habilitacion.Visible = false;
            // 
            // btnModificacion
            // 
            this.btnModificacion.Size = new System.Drawing.Size(51, 23);
            this.btnModificacion.Visible = false;
            // 
            // btnAlta
            // 
            this.btnAlta.Size = new System.Drawing.Size(52, 23);
            this.btnAlta.Visible = false;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Size = new System.Drawing.Size(370, 254);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lbl_Telefono);
            this.gbFiltros.Controls.Add(this.tb_Telefono);
            this.gbFiltros.Controls.Add(this.lbl_Nombre_de_usuario);
            this.gbFiltros.Controls.Add(this.tb_Nombre_de_usuario);
            this.gbFiltros.Size = new System.Drawing.Size(369, 106);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Nombre_de_usuario, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lbl_Nombre_de_usuario, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Telefono, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lbl_Telefono, 0);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(288, 77);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(289, 18);
            // 
            // lbl_Nombre_de_usuario
            // 
            this.lbl_Nombre_de_usuario.AutoSize = true;
            this.lbl_Nombre_de_usuario.Location = new System.Drawing.Point(6, 25);
            this.lbl_Nombre_de_usuario.Name = "lbl_Nombre_de_usuario";
            this.lbl_Nombre_de_usuario.Size = new System.Drawing.Size(99, 13);
            this.lbl_Nombre_de_usuario.TabIndex = 4;
            this.lbl_Nombre_de_usuario.Text = "Nombre de usuario:";
            // 
            // tb_Nombre_de_usuario
            // 
            this.tb_Nombre_de_usuario.Location = new System.Drawing.Point(111, 22);
            this.tb_Nombre_de_usuario.Name = "tb_Nombre_de_usuario";
            this.tb_Nombre_de_usuario.Size = new System.Drawing.Size(241, 20);
            this.tb_Nombre_de_usuario.TabIndex = 3;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(7, 18);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_Telefono
            // 
            this.lbl_Telefono.AutoSize = true;
            this.lbl_Telefono.Location = new System.Drawing.Point(6, 54);
            this.lbl_Telefono.Name = "lbl_Telefono";
            this.lbl_Telefono.Size = new System.Drawing.Size(52, 13);
            this.lbl_Telefono.TabIndex = 6;
            this.lbl_Telefono.Text = "Telefono:";
            // 
            // tb_Telefono
            // 
            this.tb_Telefono.Location = new System.Drawing.Point(111, 51);
            this.tb_Telefono.Name = "tb_Telefono";
            this.tb_Telefono.Size = new System.Drawing.Size(241, 20);
            this.tb_Telefono.TabIndex = 5;
            // 
            // ListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 444);
            this.Name = "ListadoUsuarios";
            this.Text = "Frba Commerce - Listado de usuarios";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Nombre_de_usuario;
        private System.Windows.Forms.TextBox tb_Nombre_de_usuario;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Telefono;
        private System.Windows.Forms.TextBox tb_Telefono;
    }
}