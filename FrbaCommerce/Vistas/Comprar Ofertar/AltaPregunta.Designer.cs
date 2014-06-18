namespace FrbaCommerce.Vistas.Comprar_Ofertar
{
    partial class AltaPregunta
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
            this.btn_Preguntar = new System.Windows.Forms.Button();
            this.tb_Pregunta = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_Pregunta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Preguntar
            // 
            this.btn_Preguntar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Preguntar.Location = new System.Drawing.Point(345, 134);
            this.btn_Preguntar.Name = "btn_Preguntar";
            this.btn_Preguntar.Size = new System.Drawing.Size(83, 23);
            this.btn_Preguntar.TabIndex = 8;
            this.btn_Preguntar.Text = "Preguntar";
            this.btn_Preguntar.UseVisualStyleBackColor = true;
            this.btn_Preguntar.Click += new System.EventHandler(this.btn_Preguntar_Click);
            // 
            // tb_Pregunta
            // 
            this.tb_Pregunta.Location = new System.Drawing.Point(12, 25);
            this.tb_Pregunta.MaxLength = 255;
            this.tb_Pregunta.Multiline = true;
            this.tb_Pregunta.Name = "tb_Pregunta";
            this.tb_Pregunta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Pregunta.Size = new System.Drawing.Size(416, 103);
            this.tb_Pregunta.TabIndex = 7;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Cancelar.Location = new System.Drawing.Point(12, 134);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(83, 23);
            this.btn_Cancelar.TabIndex = 9;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_Pregunta
            // 
            this.lbl_Pregunta.AutoSize = true;
            this.lbl_Pregunta.Location = new System.Drawing.Point(12, 8);
            this.lbl_Pregunta.Name = "lbl_Pregunta";
            this.lbl_Pregunta.Size = new System.Drawing.Size(53, 13);
            this.lbl_Pregunta.TabIndex = 11;
            this.lbl_Pregunta.Text = "Pregunta:";
            // 
            // AltaPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 169);
            this.Controls.Add(this.lbl_Pregunta);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Preguntar);
            this.Controls.Add(this.tb_Pregunta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaPregunta";
            this.Text = "Preguntar";
            this.Load += new System.EventHandler(this.AltaPregunta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Preguntar;
        private System.Windows.Forms.TextBox tb_Pregunta;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Pregunta;
    }
}