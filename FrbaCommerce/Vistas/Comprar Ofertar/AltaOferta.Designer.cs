namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    partial class AltaOferta
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
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Ofertar = new System.Windows.Forms.Button();
            this.gb_Ofertar = new System.Windows.Forms.GroupBox();
            this.tb_Monto_actual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Ingresar_monto_a_ofertar = new System.Windows.Forms.NumericUpDown();
            this.lbl_Ingresar_cantidad = new System.Windows.Forms.Label();
            this.gb_Ofertar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Ingresar_monto_a_ofertar)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(31, 115);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(104, 23);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Ofertar
            // 
            this.btn_Ofertar.Location = new System.Drawing.Point(174, 115);
            this.btn_Ofertar.Name = "btn_Ofertar";
            this.btn_Ofertar.Size = new System.Drawing.Size(103, 23);
            this.btn_Ofertar.TabIndex = 5;
            this.btn_Ofertar.Text = "Ofertar";
            this.btn_Ofertar.UseVisualStyleBackColor = true;
            this.btn_Ofertar.Click += new System.EventHandler(this.btn_Ofertar_Click);
            // 
            // gb_Ofertar
            // 
            this.gb_Ofertar.Controls.Add(this.tb_Monto_actual);
            this.gb_Ofertar.Controls.Add(this.label1);
            this.gb_Ofertar.Controls.Add(this.nud_Ingresar_monto_a_ofertar);
            this.gb_Ofertar.Controls.Add(this.lbl_Ingresar_cantidad);
            this.gb_Ofertar.Location = new System.Drawing.Point(12, 12);
            this.gb_Ofertar.Name = "gb_Ofertar";
            this.gb_Ofertar.Size = new System.Drawing.Size(286, 95);
            this.gb_Ofertar.TabIndex = 4;
            this.gb_Ofertar.TabStop = false;
            this.gb_Ofertar.Text = "Ofertar";
            // 
            // tb_Monto_actual
            // 
            this.tb_Monto_actual.Enabled = false;
            this.tb_Monto_actual.Location = new System.Drawing.Point(112, 59);
            this.tb_Monto_actual.Name = "tb_Monto_actual";
            this.tb_Monto_actual.Size = new System.Drawing.Size(153, 20);
            this.tb_Monto_actual.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto actual:";
            // 
            // nud_Ingresar_monto_a_ofertar
            // 
            this.nud_Ingresar_monto_a_ofertar.Location = new System.Drawing.Point(112, 25);
            this.nud_Ingresar_monto_a_ofertar.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nud_Ingresar_monto_a_ofertar.Name = "nud_Ingresar_monto_a_ofertar";
            this.nud_Ingresar_monto_a_ofertar.Size = new System.Drawing.Size(153, 20);
            this.nud_Ingresar_monto_a_ofertar.TabIndex = 1;
            this.nud_Ingresar_monto_a_ofertar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Ingresar_monto_a_ofertar.ValueChanged += new System.EventHandler(this.nud_Ingresar_monto_a_ofertar_ValueChanged);
            // 
            // lbl_Ingresar_cantidad
            // 
            this.lbl_Ingresar_cantidad.AutoSize = true;
            this.lbl_Ingresar_cantidad.Location = new System.Drawing.Point(16, 27);
            this.lbl_Ingresar_cantidad.Name = "lbl_Ingresar_cantidad";
            this.lbl_Ingresar_cantidad.Size = new System.Drawing.Size(82, 13);
            this.lbl_Ingresar_cantidad.TabIndex = 0;
            this.lbl_Ingresar_cantidad.Text = "Monto a ofertar:";
            // 
            // AltaOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 150);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Ofertar);
            this.Controls.Add(this.gb_Ofertar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaOferta";
            this.Text = "Oferta";
            this.Load += new System.EventHandler(this.AltaOferta_Load);
            this.gb_Ofertar.ResumeLayout(false);
            this.gb_Ofertar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Ingresar_monto_a_ofertar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Ofertar;
        private System.Windows.Forms.GroupBox gb_Ofertar;
        private System.Windows.Forms.TextBox tb_Monto_actual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Ingresar_monto_a_ofertar;
        private System.Windows.Forms.Label lbl_Ingresar_cantidad;

    }
}