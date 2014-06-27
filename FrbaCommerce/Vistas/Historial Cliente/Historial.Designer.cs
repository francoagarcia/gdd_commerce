namespace FrbaCommerce.Vistas.Historial_Cliente
{
    partial class Historial
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
            this.gb_Elegir_historial = new System.Windows.Forms.GroupBox();
            this.btn_Ver_historial_calificaciones = new System.Windows.Forms.Button();
            this.btn_Ver_historial_de_ofertas = new System.Windows.Forms.Button();
            this.btn_Ver_historial_de_compras = new System.Windows.Forms.Button();
            this.gb_Elegir_historial.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Elegir_historial
            // 
            this.gb_Elegir_historial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Elegir_historial.Controls.Add(this.btn_Ver_historial_calificaciones);
            this.gb_Elegir_historial.Controls.Add(this.btn_Ver_historial_de_ofertas);
            this.gb_Elegir_historial.Controls.Add(this.btn_Ver_historial_de_compras);
            this.gb_Elegir_historial.Location = new System.Drawing.Point(12, 12);
            this.gb_Elegir_historial.Name = "gb_Elegir_historial";
            this.gb_Elegir_historial.Size = new System.Drawing.Size(257, 245);
            this.gb_Elegir_historial.TabIndex = 0;
            this.gb_Elegir_historial.TabStop = false;
            this.gb_Elegir_historial.Text = "Elija un historial para ver";
            // 
            // btn_Ver_historial_calificaciones
            // 
            this.btn_Ver_historial_calificaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Ver_historial_calificaciones.Location = new System.Drawing.Point(29, 172);
            this.btn_Ver_historial_calificaciones.Name = "btn_Ver_historial_calificaciones";
            this.btn_Ver_historial_calificaciones.Size = new System.Drawing.Size(201, 42);
            this.btn_Ver_historial_calificaciones.TabIndex = 5;
            this.btn_Ver_historial_calificaciones.Text = "Ver Historial de Calificaciones";
            this.btn_Ver_historial_calificaciones.UseVisualStyleBackColor = true;
            this.btn_Ver_historial_calificaciones.Click += new System.EventHandler(this.btn_Ver_historial_calificaciones_Click);
            // 
            // btn_Ver_historial_de_ofertas
            // 
            this.btn_Ver_historial_de_ofertas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Ver_historial_de_ofertas.Location = new System.Drawing.Point(29, 105);
            this.btn_Ver_historial_de_ofertas.Name = "btn_Ver_historial_de_ofertas";
            this.btn_Ver_historial_de_ofertas.Size = new System.Drawing.Size(201, 42);
            this.btn_Ver_historial_de_ofertas.TabIndex = 4;
            this.btn_Ver_historial_de_ofertas.Text = "Ver Historial de Ofertas";
            this.btn_Ver_historial_de_ofertas.UseVisualStyleBackColor = true;
            this.btn_Ver_historial_de_ofertas.Click += new System.EventHandler(this.btn_Ver_historial_de_ofertas_Click);
            // 
            // btn_Ver_historial_de_compras
            // 
            this.btn_Ver_historial_de_compras.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Ver_historial_de_compras.Location = new System.Drawing.Point(29, 41);
            this.btn_Ver_historial_de_compras.Name = "btn_Ver_historial_de_compras";
            this.btn_Ver_historial_de_compras.Size = new System.Drawing.Size(201, 42);
            this.btn_Ver_historial_de_compras.TabIndex = 3;
            this.btn_Ver_historial_de_compras.Text = "Ver Historial de compras";
            this.btn_Ver_historial_de_compras.UseVisualStyleBackColor = true;
            this.btn_Ver_historial_de_compras.Click += new System.EventHandler(this.btn_Ver_historial_de_compras_Click);
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 269);
            this.Controls.Add(this.gb_Elegir_historial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Historial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce - Historial";
            this.gb_Elegir_historial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Elegir_historial;
        private System.Windows.Forms.Button btn_Ver_historial_calificaciones;
        private System.Windows.Forms.Button btn_Ver_historial_de_ofertas;
        private System.Windows.Forms.Button btn_Ver_historial_de_compras;

    }
}