namespace FrbaCommerce.Vistas.Abm_Cliente
{
    partial class DatosUsuarioNuevo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Usuario = new System.Windows.Forms.TextBox();
            this.tb_Constrasenia = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña:";
            // 
            // tb_Usuario
            // 
            this.tb_Usuario.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Usuario.Location = new System.Drawing.Point(84, 11);
            this.tb_Usuario.Name = "tb_Usuario";
            this.tb_Usuario.ReadOnly = true;
            this.tb_Usuario.Size = new System.Drawing.Size(170, 20);
            this.tb_Usuario.TabIndex = 3;
            // 
            // tb_Constrasenia
            // 
            this.tb_Constrasenia.BackColor = System.Drawing.SystemColors.Info;
            this.tb_Constrasenia.Location = new System.Drawing.Point(84, 35);
            this.tb_Constrasenia.Name = "tb_Constrasenia";
            this.tb_Constrasenia.ReadOnly = true;
            this.tb_Constrasenia.Size = new System.Drawing.Size(170, 20);
            this.tb_Constrasenia.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_Constrasenia);
            this.panel1.Controls.Add(this.tb_Usuario);
            this.panel1.Location = new System.Drawing.Point(19, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 67);
            this.panel1.TabIndex = 6;
            // 
            // DatosClienteNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 116);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DatosClienteNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro exitoso";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Usuario;
        private System.Windows.Forms.TextBox tb_Constrasenia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}