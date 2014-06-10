namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    partial class Registro_Usuario
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
            this.comboBox_Tipo_de_usuario = new System.Windows.Forms.ComboBox();
            this.btnRegistracion = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxDatosDeUsuario = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDatosDeUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Tipo_de_usuario
            // 
            this.comboBox_Tipo_de_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo_de_usuario.FormattingEnabled = true;
            this.comboBox_Tipo_de_usuario.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.comboBox_Tipo_de_usuario.Location = new System.Drawing.Point(127, 36);
            this.comboBox_Tipo_de_usuario.Name = "comboBox_Tipo_de_usuario";
            this.comboBox_Tipo_de_usuario.Size = new System.Drawing.Size(178, 21);
            this.comboBox_Tipo_de_usuario.TabIndex = 2;
            // 
            // btnRegistracion
            // 
            this.btnRegistracion.Location = new System.Drawing.Point(188, 118);
            this.btnRegistracion.Name = "btnRegistracion";
            this.btnRegistracion.Size = new System.Drawing.Size(129, 23);
            this.btnRegistracion.TabIndex = 6;
            this.btnRegistracion.Text = "Siguiente";
            this.btnRegistracion.UseVisualStyleBackColor = true;
            this.btnRegistracion.Click += new System.EventHandler(this.btnRegistracion_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(21, 118);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 22;
            // 
            // groupBoxDatosDeUsuario
            // 
            this.groupBoxDatosDeUsuario.Controls.Add(this.label1);
            this.groupBoxDatosDeUsuario.Controls.Add(this.label10);
            this.groupBoxDatosDeUsuario.Controls.Add(this.comboBox_Tipo_de_usuario);
            this.groupBoxDatosDeUsuario.Location = new System.Drawing.Point(12, 19);
            this.groupBoxDatosDeUsuario.Name = "groupBoxDatosDeUsuario";
            this.groupBoxDatosDeUsuario.Size = new System.Drawing.Size(318, 85);
            this.groupBoxDatosDeUsuario.TabIndex = 8;
            this.groupBoxDatosDeUsuario.TabStop = false;
            this.groupBoxDatosDeUsuario.Text = "Seleccione el tipo de usuario con el que se va a registrar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tipo de usuario:";
            // 
            // Registro_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 154);
            this.Controls.Add(this.groupBoxDatosDeUsuario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistracion);
            this.Name = "Registro_Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrarme";
            this.Load += new System.EventHandler(this.Registro_Usuario_Load);
            this.groupBoxDatosDeUsuario.ResumeLayout(false);
            this.groupBoxDatosDeUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Tipo_de_usuario;
        private System.Windows.Forms.Button btnRegistracion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxDatosDeUsuario;
        private System.Windows.Forms.Label label1;

    }
}