namespace FrbaCommerce.Vistas.Abm_Empresa
{
    partial class ListadoEmpresa
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
            this.tb_Mail = new System.Windows.Forms.TextBox();
            this.tb_CUIT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_CUIT = new System.Windows.Forms.Label();
            this.label_Razon_social = new System.Windows.Forms.Label();
            this.tb_Razon_social = new System.Windows.Forms.TextBox();
            this.chBox_Habilitados = new System.Windows.Forms.CheckBox();
            this.gbAcciones.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAcciones
            // 
            this.gbAcciones.Size = new System.Drawing.Size(588, 47);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Size = new System.Drawing.Size(588, 254);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.chBox_Habilitados);
            this.gbFiltros.Controls.Add(this.tb_Mail);
            this.gbFiltros.Controls.Add(this.tb_CUIT);
            this.gbFiltros.Controls.Add(this.label8);
            this.gbFiltros.Controls.Add(this.label_CUIT);
            this.gbFiltros.Controls.Add(this.label_Razon_social);
            this.gbFiltros.Controls.Add(this.tb_Razon_social);
            this.gbFiltros.Size = new System.Drawing.Size(587, 106);
            this.gbFiltros.Controls.SetChildIndex(this.btnFiltrar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Razon_social, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label_Razon_social, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label_CUIT, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label8, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_CUIT, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tb_Mail, 0);
            this.gbFiltros.Controls.SetChildIndex(this.chBox_Habilitados, 0);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(506, 77);
            // 
            // tb_Mail
            // 
            this.tb_Mail.Location = new System.Drawing.Point(353, 18);
            this.tb_Mail.Name = "tb_Mail";
            this.tb_Mail.Size = new System.Drawing.Size(219, 20);
            this.tb_Mail.TabIndex = 38;
            // 
            // tb_CUIT
            // 
            this.tb_CUIT.Location = new System.Drawing.Point(80, 46);
            this.tb_CUIT.Name = "tb_CUIT";
            this.tb_CUIT.Size = new System.Drawing.Size(219, 20);
            this.tb_CUIT.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Mail";
            // 
            // label_CUIT
            // 
            this.label_CUIT.AutoSize = true;
            this.label_CUIT.Location = new System.Drawing.Point(6, 49);
            this.label_CUIT.Name = "label_CUIT";
            this.label_CUIT.Size = new System.Drawing.Size(32, 13);
            this.label_CUIT.TabIndex = 37;
            this.label_CUIT.Text = "CUIT";
            // 
            // label_Razon_social
            // 
            this.label_Razon_social.AutoSize = true;
            this.label_Razon_social.Location = new System.Drawing.Point(6, 21);
            this.label_Razon_social.Name = "label_Razon_social";
            this.label_Razon_social.Size = new System.Drawing.Size(68, 13);
            this.label_Razon_social.TabIndex = 35;
            this.label_Razon_social.Text = "Razon social";
            // 
            // tb_Razon_social
            // 
            this.tb_Razon_social.Location = new System.Drawing.Point(80, 18);
            this.tb_Razon_social.Name = "tb_Razon_social";
            this.tb_Razon_social.Size = new System.Drawing.Size(219, 20);
            this.tb_Razon_social.TabIndex = 34;
            // 
            // chBox_Habilitados
            // 
            this.chBox_Habilitados.AutoSize = true;
            this.chBox_Habilitados.Location = new System.Drawing.Point(324, 49);
            this.chBox_Habilitados.Name = "chBox_Habilitados";
            this.chBox_Habilitados.Size = new System.Drawing.Size(78, 17);
            this.chBox_Habilitados.TabIndex = 36;
            this.chBox_Habilitados.Text = "Habilitados";
            this.chBox_Habilitados.UseVisualStyleBackColor = true;
            // 
            // ListadoEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 444);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ListadoEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce - Listado de empresas";
            this.Load += new System.EventHandler(this.ListadoEmpresa_Load);
            this.gbAcciones.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Mail;
        private System.Windows.Forms.TextBox tb_CUIT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_CUIT;
        private System.Windows.Forms.Label label_Razon_social;
        private System.Windows.Forms.TextBox tb_Razon_social;
        private System.Windows.Forms.CheckBox chBox_Habilitados;
    }
}