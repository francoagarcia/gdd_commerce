namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    partial class GestionPregunta
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
            this.dg_respuestas = new System.Windows.Forms.DataGridView();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_responder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_respuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_respuestas
            // 
            this.dg_respuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_respuestas.Location = new System.Drawing.Point(12, 47);
            this.dg_respuestas.Name = "dg_respuestas";
            this.dg_respuestas.Size = new System.Drawing.Size(432, 221);
            this.dg_respuestas.TabIndex = 0;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(15, 288);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(78, 23);
            this.btn_cerrar.TabIndex = 2;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Respuestas realizadas:";
            // 
            // btn_responder
            // 
            this.btn_responder.Location = new System.Drawing.Point(369, 288);
            this.btn_responder.Name = "btn_responder";
            this.btn_responder.Size = new System.Drawing.Size(75, 23);
            this.btn_responder.TabIndex = 4;
            this.btn_responder.Text = "Responder";
            this.btn_responder.UseVisualStyleBackColor = true;
            this.btn_responder.Click += new System.EventHandler(this.btn_responder_Click);
            // 
            // GestionPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 323);
            this.Controls.Add(this.btn_responder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_respuestas);
            this.Controls.Add(this.btn_cerrar);
            this.Name = "GestionPregunta";
            this.Text = "Preguntas";
            this.Load += new System.EventHandler(this.GestionPregunta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_respuestas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.DataGridView dg_respuestas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_responder;
    }
}