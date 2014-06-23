namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    partial class DatosDelVendedor
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
            this.dgv_Datos_del_vendedor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Datos_del_vendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Datos_del_vendedor
            // 
            this.dgv_Datos_del_vendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Datos_del_vendedor.Location = new System.Drawing.Point(12, 12);
            this.dgv_Datos_del_vendedor.Name = "dgv_Datos_del_vendedor";
            this.dgv_Datos_del_vendedor.Size = new System.Drawing.Size(865, 112);
            this.dgv_Datos_del_vendedor.TabIndex = 0;
            // 
            // DatosDelVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 136);
            this.Controls.Add(this.dgv_Datos_del_vendedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DatosDelVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos del vendedor";
            this.Load += new System.EventHandler(this.DatosDelVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Datos_del_vendedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Datos_del_vendedor;

    }
}