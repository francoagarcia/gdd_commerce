namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    partial class PreguntaRespuestaView
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
            this.tb_Pregunta = new System.Windows.Forms.TextBox();
            this.lbl_Pregunta = new System.Windows.Forms.Label();
            this.lbl_Respuesta = new System.Windows.Forms.Label();
            this.tb_Respuesta = new System.Windows.Forms.TextBox();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Pregunta
            // 
            this.tb_Pregunta.Enabled = false;
            this.tb_Pregunta.Location = new System.Drawing.Point(15, 31);
            this.tb_Pregunta.MaxLength = 255;
            this.tb_Pregunta.Multiline = true;
            this.tb_Pregunta.Name = "tb_Pregunta";
            this.tb_Pregunta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Pregunta.Size = new System.Drawing.Size(446, 75);
            this.tb_Pregunta.TabIndex = 23;
            // 
            // lbl_Pregunta
            // 
            this.lbl_Pregunta.AutoSize = true;
            this.lbl_Pregunta.Location = new System.Drawing.Point(12, 9);
            this.lbl_Pregunta.Name = "lbl_Pregunta";
            this.lbl_Pregunta.Size = new System.Drawing.Size(50, 13);
            this.lbl_Pregunta.TabIndex = 24;
            this.lbl_Pregunta.Text = "Pregunta";
            // 
            // lbl_Respuesta
            // 
            this.lbl_Respuesta.AutoSize = true;
            this.lbl_Respuesta.Location = new System.Drawing.Point(12, 114);
            this.lbl_Respuesta.Name = "lbl_Respuesta";
            this.lbl_Respuesta.Size = new System.Drawing.Size(58, 13);
            this.lbl_Respuesta.TabIndex = 26;
            this.lbl_Respuesta.Text = "Respuesta";
            // 
            // tb_Respuesta
            // 
            this.tb_Respuesta.Enabled = false;
            this.tb_Respuesta.Location = new System.Drawing.Point(15, 135);
            this.tb_Respuesta.MaxLength = 255;
            this.tb_Respuesta.Multiline = true;
            this.tb_Respuesta.Name = "tb_Respuesta";
            this.tb_Respuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Respuesta.Size = new System.Drawing.Size(446, 69);
            this.tb_Respuesta.TabIndex = 25;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(281, 210);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(180, 23);
            this.btn_Aceptar.TabIndex = 27;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // PreguntaRespuestaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 245);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.lbl_Respuesta);
            this.Controls.Add(this.tb_Respuesta);
            this.Controls.Add(this.lbl_Pregunta);
            this.Controls.Add(this.tb_Pregunta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PreguntaRespuestaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver pregunta completa";
            this.Load += new System.EventHandler(this.PreguntaRespuestaView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Pregunta;
        private System.Windows.Forms.Label lbl_Pregunta;
        private System.Windows.Forms.Label lbl_Respuesta;
        private System.Windows.Forms.TextBox tb_Respuesta;
        private System.Windows.Forms.Button btn_Aceptar;
    }
}