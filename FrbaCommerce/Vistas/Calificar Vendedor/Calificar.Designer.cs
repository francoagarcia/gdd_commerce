namespace FrbaCommerce.Vistas.Calificar_Vendedor
{
    partial class Calificar
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
            this.cb_calificacion = new System.Windows.Forms.ComboBox();
            this.tb_comentario = new System.Windows.Forms.TextBox();
            this.lbl_Comentario = new System.Windows.Forms.Label();
            this.lbl_Calificacion = new System.Windows.Forms.Label();
            this.btn_Comprar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.pnl_Calificacion = new System.Windows.Forms.Panel();
            this.pnl_Calificacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_calificacion
            // 
            this.cb_calificacion.FormattingEnabled = true;
            this.cb_calificacion.Location = new System.Drawing.Point(74, 14);
            this.cb_calificacion.Name = "cb_calificacion";
            this.cb_calificacion.Size = new System.Drawing.Size(140, 21);
            this.cb_calificacion.TabIndex = 3;
            // 
            // tb_comentario
            // 
            this.tb_comentario.Location = new System.Drawing.Point(74, 46);
            this.tb_comentario.Multiline = true;
            this.tb_comentario.Name = "tb_comentario";
            this.tb_comentario.Size = new System.Drawing.Size(351, 66);
            this.tb_comentario.TabIndex = 5;
            // 
            // lbl_Comentario
            // 
            this.lbl_Comentario.AutoSize = true;
            this.lbl_Comentario.Location = new System.Drawing.Point(5, 71);
            this.lbl_Comentario.Name = "lbl_Comentario";
            this.lbl_Comentario.Size = new System.Drawing.Size(63, 13);
            this.lbl_Comentario.TabIndex = 4;
            this.lbl_Comentario.Text = "Comentario:";
            // 
            // lbl_Calificacion
            // 
            this.lbl_Calificacion.AutoSize = true;
            this.lbl_Calificacion.Location = new System.Drawing.Point(4, 17);
            this.lbl_Calificacion.Name = "lbl_Calificacion";
            this.lbl_Calificacion.Size = new System.Drawing.Size(64, 13);
            this.lbl_Calificacion.TabIndex = 2;
            this.lbl_Calificacion.Text = "Calificación:";
            // 
            // btn_Comprar
            // 
            this.btn_Comprar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Comprar.Location = new System.Drawing.Point(360, 144);
            this.btn_Comprar.Name = "btn_Comprar";
            this.btn_Comprar.Size = new System.Drawing.Size(78, 23);
            this.btn_Comprar.TabIndex = 6;
            this.btn_Comprar.Text = "Comprar";
            this.btn_Comprar.UseVisualStyleBackColor = true;
            this.btn_Comprar.Click += new System.EventHandler(this.btn_Comprar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Location = new System.Drawing.Point(20, 144);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // pnl_Calificacion
            // 
            this.pnl_Calificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Calificacion.Controls.Add(this.lbl_Calificacion);
            this.pnl_Calificacion.Controls.Add(this.tb_comentario);
            this.pnl_Calificacion.Controls.Add(this.cb_calificacion);
            this.pnl_Calificacion.Controls.Add(this.lbl_Comentario);
            this.pnl_Calificacion.Location = new System.Drawing.Point(12, 12);
            this.pnl_Calificacion.Name = "pnl_Calificacion";
            this.pnl_Calificacion.Size = new System.Drawing.Size(438, 126);
            this.pnl_Calificacion.TabIndex = 1;
            // 
            // Calificar
            // 
            this.AcceptButton = this.btn_Comprar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancelar;
            this.ClientSize = new System.Drawing.Size(462, 177);
            this.Controls.Add(this.pnl_Calificacion);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Comprar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calificar";
            this.Text = "Calificar compra";
            this.Load += new System.EventHandler(this.Calificar_Load);
            this.pnl_Calificacion.ResumeLayout(false);
            this.pnl_Calificacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Calificacion;
        private System.Windows.Forms.Button btn_Comprar;
        private System.Windows.Forms.Label lbl_Comentario;
        private System.Windows.Forms.TextBox tb_comentario;
        private System.Windows.Forms.ComboBox cb_calificacion;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Panel pnl_Calificacion;
    }
}