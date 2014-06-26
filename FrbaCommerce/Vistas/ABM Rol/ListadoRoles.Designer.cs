namespace FrbaCommerce.Vistas.ABM_Rol
{
    partial class ListadoRoles
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
            this.lbl_Descripcion = new System.Windows.Forms.Label();
            this.tb_Descripcion_del_rol = new System.Windows.Forms.TextBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Size = new System.Drawing.Size(475, 47);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Size = new System.Drawing.Size(475, 254);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.tb_Descripcion_del_rol);
            this.gbFiltros.Controls.Add(this.lbl_Descripcion);
            this.gbFiltros.Size = new System.Drawing.Size(474, 107);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lbl_Descripcion, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Descripcion_del_rol, 0);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(6, 78);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(393, 78);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(394, 18);
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.AutoSize = true;
            this.lbl_Descripcion.Location = new System.Drawing.Point(12, 40);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(97, 13);
            this.lbl_Descripcion.TabIndex = 2;
            this.lbl_Descripcion.Text = "Descripcion del rol:";
            // 
            // tb_Descripcion_del_rol
            // 
            this.tb_Descripcion_del_rol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Descripcion_del_rol.Location = new System.Drawing.Point(115, 37);
            this.tb_Descripcion_del_rol.Name = "tb_Descripcion_del_rol";
            this.tb_Descripcion_del_rol.Size = new System.Drawing.Size(288, 20);
            this.tb_Descripcion_del_rol.TabIndex = 3;
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 444);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ListadoRoles";
            this.Text = "Listado de roles";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Descripcion_del_rol;
        private System.Windows.Forms.Label lbl_Descripcion;
    }
}