namespace FrbaCommerce.Vistas.Calificar_Vendedor
{
    partial class SeleccionarCompra
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
            this.gb_Seleccionar_compra = new System.Windows.Forms.GroupBox();
            this.dgv_Busqueda = new System.Windows.Forms.DataGridView();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.gb_Acciones = new System.Windows.Forms.GroupBox();
            this.gb_Seleccionar_compra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).BeginInit();
            this.gb_Acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Seleccionar_compra
            // 
            this.gb_Seleccionar_compra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Seleccionar_compra.Controls.Add(this.dgv_Busqueda);
            this.gb_Seleccionar_compra.Location = new System.Drawing.Point(12, 12);
            this.gb_Seleccionar_compra.Name = "gb_Seleccionar_compra";
            this.gb_Seleccionar_compra.Size = new System.Drawing.Size(654, 257);
            this.gb_Seleccionar_compra.TabIndex = 0;
            this.gb_Seleccionar_compra.TabStop = false;
            this.gb_Seleccionar_compra.Text = "Elija una compra realizada para calificarla:";
            // 
            // dgv_Busqueda
            // 
            this.dgv_Busqueda.AllowDrop = true;
            this.dgv_Busqueda.AllowUserToAddRows = false;
            this.dgv_Busqueda.AllowUserToDeleteRows = false;
            this.dgv_Busqueda.AllowUserToOrderColumns = true;
            this.dgv_Busqueda.AllowUserToResizeRows = false;
            this.dgv_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Busqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Busqueda.Location = new System.Drawing.Point(6, 19);
            this.dgv_Busqueda.MultiSelect = false;
            this.dgv_Busqueda.Name = "dgv_Busqueda";
            this.dgv_Busqueda.ReadOnly = true;
            this.dgv_Busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Busqueda.Size = new System.Drawing.Size(640, 229);
            this.dgv_Busqueda.TabIndex = 2;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Location = new System.Drawing.Point(6, 14);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(141, 29);
            this.btn_Cancelar.TabIndex = 1;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Seleccionar.Location = new System.Drawing.Point(497, 14);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(150, 29);
            this.btn_Seleccionar.TabIndex = 2;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Seleccionar_Click);
            // 
            // gb_Acciones
            // 
            this.gb_Acciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Acciones.Controls.Add(this.btn_Seleccionar);
            this.gb_Acciones.Controls.Add(this.btn_Cancelar);
            this.gb_Acciones.Location = new System.Drawing.Point(12, 275);
            this.gb_Acciones.Name = "gb_Acciones";
            this.gb_Acciones.Size = new System.Drawing.Size(654, 52);
            this.gb_Acciones.TabIndex = 3;
            this.gb_Acciones.TabStop = false;
            // 
            // SeleccionarCompra
            // 
            this.AcceptButton = this.btn_Seleccionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancelar;
            this.ClientSize = new System.Drawing.Size(671, 333);
            this.Controls.Add(this.gb_Acciones);
            this.Controls.Add(this.gb_Seleccionar_compra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SeleccionarCompra";
            this.Text = "Calificar compras";
            this.Load += new System.EventHandler(this.SeleccionarCompra_Load);
            this.gb_Seleccionar_compra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).EndInit();
            this.gb_Acciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Seleccionar_compra;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Seleccionar;
        private System.Windows.Forms.GroupBox gb_Acciones;
        protected System.Windows.Forms.DataGridView dgv_Busqueda;
    }
}