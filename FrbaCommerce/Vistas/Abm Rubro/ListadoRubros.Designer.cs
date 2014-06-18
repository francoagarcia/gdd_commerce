namespace FrbaCommerce.Vistas.Abm_Rubro
{
    partial class ListadoRubros
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
            this.tb_Descripcion = new System.Windows.Forms.TextBox();
            this.lbl_Descripcion = new System.Windows.Forms.Label();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Size = new System.Drawing.Size(428, 47);
            // 
            // btn_Habilitacion
            // 
            this.btn_Habilitacion.Enabled = false;
            // 
            // btnModificacion
            // 
            this.btnModificacion.Enabled = false;
            // 
            // btnAlta
            // 
            this.btnAlta.Enabled = false;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Size = new System.Drawing.Size(428, 254);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lbl_Descripcion);
            this.gbFiltros.Controls.Add(this.tb_Descripcion);
            this.gbFiltros.Size = new System.Drawing.Size(427, 106);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Descripcion, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lbl_Descripcion, 0);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(346, 77);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(347, 18);
            // 
            // tb_Descripcion
            // 
            this.tb_Descripcion.Location = new System.Drawing.Point(78, 37);
            this.tb_Descripcion.Name = "tb_Descripcion";
            this.tb_Descripcion.Size = new System.Drawing.Size(343, 20);
            this.tb_Descripcion.TabIndex = 2;
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.AutoSize = true;
            this.lbl_Descripcion.Location = new System.Drawing.Point(6, 40);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(66, 13);
            this.lbl_Descripcion.TabIndex = 3;
            this.lbl_Descripcion.Text = "Descripcion:";
            // 
            // ListadoRubros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 444);
            this.Name = "ListadoRubros";
            this.Text = "FRBA Commerce - Listado de rubros";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Descripcion;
        private System.Windows.Forms.Label lbl_Descripcion;
    }
}