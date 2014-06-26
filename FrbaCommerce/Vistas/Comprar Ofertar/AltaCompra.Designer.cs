namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    partial class AltaCompra
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
            this.gb_Cantidad = new System.Windows.Forms.GroupBox();
            this.tb_Precio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Ingresar_cantidad = new System.Windows.Forms.NumericUpDown();
            this.lbl_Ingresar_cantidad = new System.Windows.Forms.Label();
            this.btn_Comprar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.gb_Cantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Ingresar_cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Cantidad
            // 
            this.gb_Cantidad.Controls.Add(this.tb_Precio);
            this.gb_Cantidad.Controls.Add(this.label1);
            this.gb_Cantidad.Controls.Add(this.nud_Ingresar_cantidad);
            this.gb_Cantidad.Controls.Add(this.lbl_Ingresar_cantidad);
            this.gb_Cantidad.Location = new System.Drawing.Point(12, 12);
            this.gb_Cantidad.Name = "gb_Cantidad";
            this.gb_Cantidad.Size = new System.Drawing.Size(286, 107);
            this.gb_Cantidad.TabIndex = 1;
            this.gb_Cantidad.TabStop = false;
            // 
            // tb_Precio
            // 
            this.tb_Precio.Enabled = false;
            this.tb_Precio.Location = new System.Drawing.Point(112, 59);
            this.tb_Precio.Name = "tb_Precio";
            this.tb_Precio.Size = new System.Drawing.Size(153, 20);
            this.tb_Precio.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Precio:";
            // 
            // nud_Ingresar_cantidad
            // 
            this.nud_Ingresar_cantidad.Location = new System.Drawing.Point(112, 25);
            this.nud_Ingresar_cantidad.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nud_Ingresar_cantidad.Name = "nud_Ingresar_cantidad";
            this.nud_Ingresar_cantidad.Size = new System.Drawing.Size(153, 20);
            this.nud_Ingresar_cantidad.TabIndex = 2;
            this.nud_Ingresar_cantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Ingresar_cantidad.ValueChanged += new System.EventHandler(this.nud_Ingresar_cantidad_ValueChanged);
            // 
            // lbl_Ingresar_cantidad
            // 
            this.lbl_Ingresar_cantidad.AutoSize = true;
            this.lbl_Ingresar_cantidad.Location = new System.Drawing.Point(16, 27);
            this.lbl_Ingresar_cantidad.Name = "lbl_Ingresar_cantidad";
            this.lbl_Ingresar_cantidad.Size = new System.Drawing.Size(89, 13);
            this.lbl_Ingresar_cantidad.TabIndex = 0;
            this.lbl_Ingresar_cantidad.Text = "Ingrese cantidad:";
            // 
            // btn_Comprar
            // 
            this.btn_Comprar.Location = new System.Drawing.Point(174, 125);
            this.btn_Comprar.Name = "btn_Comprar";
            this.btn_Comprar.Size = new System.Drawing.Size(103, 23);
            this.btn_Comprar.TabIndex = 5;
            this.btn_Comprar.Text = "Comprar";
            this.btn_Comprar.UseVisualStyleBackColor = true;
            this.btn_Comprar.Click += new System.EventHandler(this.btn_Comprar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(31, 125);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(104, 23);
            this.btn_Cancelar.TabIndex = 4;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // AltaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 160);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Comprar);
            this.Controls.Add(this.gb_Cantidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaCompra";
            this.Text = "Comprar";
            this.Load += new System.EventHandler(this.AltaCompra_Load);
            this.gb_Cantidad.ResumeLayout(false);
            this.gb_Cantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Ingresar_cantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Cantidad;
        private System.Windows.Forms.Button btn_Comprar;
        private System.Windows.Forms.Label lbl_Ingresar_cantidad;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.TextBox tb_Precio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Ingresar_cantidad;
    }
}