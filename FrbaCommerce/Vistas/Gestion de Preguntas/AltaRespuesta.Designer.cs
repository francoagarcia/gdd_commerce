namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    partial class AltaRespuesta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_preguntas = new System.Windows.Forms.DataGridView();
            this.btn_responder = new System.Windows.Forms.Button();
            this.txt_respuesta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_preguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dg_preguntas);
            this.groupBox1.Controls.Add(this.btn_responder);
            this.groupBox1.Controls.Add(this.txt_respuesta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar";
            // 
            // dg_preguntas
            // 
            this.dg_preguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_preguntas.Location = new System.Drawing.Point(15, 20);
            this.dg_preguntas.Name = "dg_preguntas";
            this.dg_preguntas.Size = new System.Drawing.Size(407, 153);
            this.dg_preguntas.TabIndex = 3;
            // 
            // btn_responder
            // 
            this.btn_responder.Location = new System.Drawing.Point(354, 193);
            this.btn_responder.Name = "btn_responder";
            this.btn_responder.Size = new System.Drawing.Size(78, 23);
            this.btn_responder.TabIndex = 2;
            this.btn_responder.Text = "Enviar";
            this.btn_responder.UseVisualStyleBackColor = true;
            this.btn_responder.Click += new System.EventHandler(this.btn_responder_Click);
            // 
            // txt_respuesta
            // 
            this.txt_respuesta.Location = new System.Drawing.Point(74, 195);
            this.txt_respuesta.Name = "txt_respuesta";
            this.txt_respuesta.Size = new System.Drawing.Size(274, 20);
            this.txt_respuesta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Responder:";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(366, 257);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(78, 23);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Atras";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // AltaRespuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 292);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaRespuesta";
            this.Text = "AltaPregunta";
            this.Load += new System.EventHandler(this.AltaRespuesta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_preguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_preguntas;
        private System.Windows.Forms.Button btn_responder;
        private System.Windows.Forms.TextBox txt_respuesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancelar;
    }
}