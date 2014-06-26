namespace FrbaCommerce.Vistas.Abm_Visibilidad
{
    partial class ListadoVisibilidad
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
            this.label_Nombre_de_visibilidad = new System.Windows.Forms.Label();
            this.tb_Nombre_de_visibilidad = new System.Windows.Forms.TextBox();
            this.label_Precio = new System.Windows.Forms.Label();
            this.label_Porcentaje = new System.Windows.Forms.Label();
            this.tb_Precio = new System.Windows.Forms.TextBox();
            this.tb_Porcentaje = new System.Windows.Forms.TextBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Habilitacion
            // 
            this.btn_Habilitacion.TabIndex = 7;
            // 
            // btnModificacion
            // 
            this.btnModificacion.TabIndex = 6;
            // 
            // btnAlta
            // 
            this.btnAlta.TabIndex = 5;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.tb_Porcentaje);
            this.gbFiltros.Controls.Add(this.label_Nombre_de_visibilidad);
            this.gbFiltros.Controls.Add(this.label_Porcentaje);
            this.gbFiltros.Controls.Add(this.tb_Precio);
            this.gbFiltros.Controls.Add(this.label_Precio);
            this.gbFiltros.Controls.Add(this.tb_Nombre_de_visibilidad);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Nombre_de_visibilidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label_Precio, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Precio, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label_Porcentaje, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label_Nombre_de_visibilidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Porcentaje, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.TabIndex = 4;
            // 
            // label_Nombre_de_visibilidad
            // 
            this.label_Nombre_de_visibilidad.AutoSize = true;
            this.label_Nombre_de_visibilidad.Location = new System.Drawing.Point(6, 27);
            this.label_Nombre_de_visibilidad.Name = "label_Nombre_de_visibilidad";
            this.label_Nombre_de_visibilidad.Size = new System.Drawing.Size(63, 13);
            this.label_Nombre_de_visibilidad.TabIndex = 2;
            this.label_Nombre_de_visibilidad.Text = "Descripcion";
            // 
            // tb_Nombre_de_visibilidad
            // 
            this.tb_Nombre_de_visibilidad.Location = new System.Drawing.Point(75, 24);
            this.tb_Nombre_de_visibilidad.Name = "tb_Nombre_de_visibilidad";
            this.tb_Nombre_de_visibilidad.Size = new System.Drawing.Size(495, 20);
            this.tb_Nombre_de_visibilidad.TabIndex = 0;
            // 
            // label_Precio
            // 
            this.label_Precio.AutoSize = true;
            this.label_Precio.Location = new System.Drawing.Point(6, 53);
            this.label_Precio.Name = "label_Precio";
            this.label_Precio.Size = new System.Drawing.Size(37, 13);
            this.label_Precio.TabIndex = 4;
            this.label_Precio.Text = "Precio";
            // 
            // label_Porcentaje
            // 
            this.label_Porcentaje.AutoSize = true;
            this.label_Porcentaje.Location = new System.Drawing.Point(191, 53);
            this.label_Porcentaje.Name = "label_Porcentaje";
            this.label_Porcentaje.Size = new System.Drawing.Size(58, 13);
            this.label_Porcentaje.TabIndex = 5;
            this.label_Porcentaje.Text = "Porcentaje";
            // 
            // tb_Precio
            // 
            this.tb_Precio.Location = new System.Drawing.Point(75, 50);
            this.tb_Precio.Name = "tb_Precio";
            this.tb_Precio.Size = new System.Drawing.Size(100, 20);
            this.tb_Precio.TabIndex = 1;
            this.tb_Precio.Text = "0";
            // 
            // tb_Porcentaje
            // 
            this.tb_Porcentaje.Location = new System.Drawing.Point(255, 50);
            this.tb_Porcentaje.Name = "tb_Porcentaje";
            this.tb_Porcentaje.Size = new System.Drawing.Size(100, 20);
            this.tb_Porcentaje.TabIndex = 2;
            this.tb_Porcentaje.Text = "0";
            // 
            // ListadoVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 440);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ListadoVisibilidad";
            this.Text = "FRBA Commerce - Listado de visibilidades";
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Nombre_de_visibilidad;
        private System.Windows.Forms.TextBox tb_Nombre_de_visibilidad;
        private System.Windows.Forms.TextBox tb_Porcentaje;
        private System.Windows.Forms.Label label_Porcentaje;
        private System.Windows.Forms.TextBox tb_Precio;
        private System.Windows.Forms.Label label_Precio;
    }
}