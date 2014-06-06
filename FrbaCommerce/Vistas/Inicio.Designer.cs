namespace FrbaCommerce
{
    partial class Inicio
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
            this.buttonClienteAlta = new System.Windows.Forms.Button();
            this.BusquedaCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClienteAlta
            // 
            this.buttonClienteAlta.Location = new System.Drawing.Point(208, 319);
            this.buttonClienteAlta.Name = "buttonClienteAlta";
            this.buttonClienteAlta.Size = new System.Drawing.Size(75, 23);
            this.buttonClienteAlta.TabIndex = 0;
            this.buttonClienteAlta.Text = "Alta Cliente";
            this.buttonClienteAlta.UseVisualStyleBackColor = true;
            this.buttonClienteAlta.Click += new System.EventHandler(this.buttonClienteAlta_Click);
            // 
            // BusquedaCliente
            // 
            this.BusquedaCliente.Location = new System.Drawing.Point(323, 319);
            this.BusquedaCliente.Name = "BusquedaCliente";
            this.BusquedaCliente.Size = new System.Drawing.Size(75, 23);
            this.BusquedaCliente.TabIndex = 1;
            this.BusquedaCliente.Text = "Busqueda Cliente";
            this.BusquedaCliente.UseVisualStyleBackColor = true;
            this.BusquedaCliente.Click += new System.EventHandler(this.BusquedaCliente_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 408);
            this.Controls.Add(this.BusquedaCliente);
            this.Controls.Add(this.buttonClienteAlta);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA Commerce";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClienteAlta;
        private System.Windows.Forms.Button BusquedaCliente;
    }
}

