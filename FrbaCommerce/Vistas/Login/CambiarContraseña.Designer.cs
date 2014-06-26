namespace FrbaCommerce.Vistas.Login
{
    partial class CambiarContraseña
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
            this.pnl_Contrasenia = new System.Windows.Forms.Panel();
            this.tb_Confirmar_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Constrasenia = new System.Windows.Forms.Label();
            this.tb_Constrasenia = new System.Windows.Forms.TextBox();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.lbl_Texto_informativo = new System.Windows.Forms.Label();
            this.pnl_Contrasenia.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Contrasenia
            // 
            this.pnl_Contrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Contrasenia.Controls.Add(this.tb_Confirmar_pass);
            this.pnl_Contrasenia.Controls.Add(this.label2);
            this.pnl_Contrasenia.Controls.Add(this.lbl_Constrasenia);
            this.pnl_Contrasenia.Controls.Add(this.tb_Constrasenia);
            this.pnl_Contrasenia.Location = new System.Drawing.Point(9, 33);
            this.pnl_Contrasenia.Name = "pnl_Contrasenia";
            this.pnl_Contrasenia.Size = new System.Drawing.Size(321, 66);
            this.pnl_Contrasenia.TabIndex = 2;
            // 
            // tb_Confirmar_pass
            // 
            this.tb_Confirmar_pass.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Confirmar_pass.Location = new System.Drawing.Point(134, 36);
            this.tb_Confirmar_pass.Name = "tb_Confirmar_pass";
            this.tb_Confirmar_pass.PasswordChar = '*';
            this.tb_Confirmar_pass.Size = new System.Drawing.Size(170, 20);
            this.tb_Confirmar_pass.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirmar contraseña:";
            // 
            // lbl_Constrasenia
            // 
            this.lbl_Constrasenia.AutoSize = true;
            this.lbl_Constrasenia.Location = new System.Drawing.Point(12, 11);
            this.lbl_Constrasenia.Name = "lbl_Constrasenia";
            this.lbl_Constrasenia.Size = new System.Drawing.Size(64, 13);
            this.lbl_Constrasenia.TabIndex = 3;
            this.lbl_Constrasenia.Text = "Contraseña:";
            // 
            // tb_Constrasenia
            // 
            this.tb_Constrasenia.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Constrasenia.Location = new System.Drawing.Point(134, 8);
            this.tb_Constrasenia.Name = "tb_Constrasenia";
            this.tb_Constrasenia.PasswordChar = '*';
            this.tb_Constrasenia.Size = new System.Drawing.Size(170, 20);
            this.tb_Constrasenia.TabIndex = 4;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(244, 111);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(89, 23);
            this.btn_Aceptar.TabIndex = 5;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Location = new System.Drawing.Point(12, 111);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(89, 23);
            this.btn_Salir.TabIndex = 6;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // lbl_Texto_informativo
            // 
            this.lbl_Texto_informativo.AutoSize = true;
            this.lbl_Texto_informativo.Location = new System.Drawing.Point(9, 9);
            this.lbl_Texto_informativo.Name = "lbl_Texto_informativo";
            this.lbl_Texto_informativo.Size = new System.Drawing.Size(145, 13);
            this.lbl_Texto_informativo.TabIndex = 5;
            this.lbl_Texto_informativo.Text = "Ingrese la nueva contraseña:";
            // 
            // CambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 138);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Texto_informativo);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.pnl_Contrasenia);
            this.Controls.Add(this.btn_Aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambiarContraseña";
            this.Text = "Modificar contraseña";
            this.Load += new System.EventHandler(this.PrimerIngreso_Load);
            this.pnl_Contrasenia.ResumeLayout(false);
            this.pnl_Contrasenia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Contrasenia;
        private System.Windows.Forms.Label lbl_Constrasenia;
        private System.Windows.Forms.TextBox tb_Constrasenia;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label lbl_Texto_informativo;
        private System.Windows.Forms.TextBox tb_Confirmar_pass;
        private System.Windows.Forms.Label label2;
    }
}