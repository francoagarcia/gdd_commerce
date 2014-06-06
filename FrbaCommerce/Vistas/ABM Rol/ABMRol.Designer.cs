namespace FrbaCommerce.Vistas.ABM_Rol
{
    partial class ABMRol
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
            this.listFunc = new System.Windows.Forms.ListBox();
            this.listFuncActivas = new System.Windows.Forms.ListBox();
            this.bAgregar = new System.Windows.Forms.Button();
            this.bQuitar = new System.Windows.Forms.Button();
            this.ModificacionFunc = new System.Windows.Forms.GroupBox();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.labelComboRoles = new System.Windows.Forms.Label();
            this.labelNomRol = new System.Windows.Forms.Label();
            this.textBoxNomRol = new System.Windows.Forms.TextBox();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.buttonAplicar = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.ModificacionFunc.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFunc
            // 
            this.listFunc.FormattingEnabled = true;
            this.listFunc.Location = new System.Drawing.Point(35, 45);
            this.listFunc.Name = "listFunc";
            this.listFunc.Size = new System.Drawing.Size(160, 199);
            this.listFunc.TabIndex = 0;
            // 
            // listFuncActivas
            // 
            this.listFuncActivas.FormattingEnabled = true;
            this.listFuncActivas.Location = new System.Drawing.Point(351, 45);
            this.listFuncActivas.Name = "listFuncActivas";
            this.listFuncActivas.Size = new System.Drawing.Size(160, 199);
            this.listFuncActivas.TabIndex = 1;
            // 
            // bAgregar
            // 
            this.bAgregar.Location = new System.Drawing.Point(235, 94);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(75, 23);
            this.bAgregar.TabIndex = 2;
            this.bAgregar.Text = "Agregar";
            this.bAgregar.UseVisualStyleBackColor = true;
            // 
            // bQuitar
            // 
            this.bQuitar.Location = new System.Drawing.Point(235, 160);
            this.bQuitar.Name = "bQuitar";
            this.bQuitar.Size = new System.Drawing.Size(75, 23);
            this.bQuitar.TabIndex = 3;
            this.bQuitar.Text = "Quitar";
            this.bQuitar.UseVisualStyleBackColor = true;
            this.bQuitar.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModificacionFunc
            // 
            this.ModificacionFunc.Controls.Add(this.listFuncActivas);
            this.ModificacionFunc.Controls.Add(this.bQuitar);
            this.ModificacionFunc.Controls.Add(this.listFunc);
            this.ModificacionFunc.Controls.Add(this.bAgregar);
            this.ModificacionFunc.Location = new System.Drawing.Point(21, 102);
            this.ModificacionFunc.Name = "ModificacionFunc";
            this.ModificacionFunc.Size = new System.Drawing.Size(546, 265);
            this.ModificacionFunc.TabIndex = 4;
            this.ModificacionFunc.TabStop = false;
            this.ModificacionFunc.Text = "Asignacion de Funcionalidades";
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(116, 26);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(137, 21);
            this.comboBoxRoles.TabIndex = 5;
            // 
            // labelComboRoles
            // 
            this.labelComboRoles.AutoSize = true;
            this.labelComboRoles.Location = new System.Drawing.Point(28, 29);
            this.labelComboRoles.Name = "labelComboRoles";
            this.labelComboRoles.Size = new System.Drawing.Size(82, 13);
            this.labelComboRoles.TabIndex = 6;
            this.labelComboRoles.Text = "Seleccionar Rol";
            this.labelComboRoles.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelNomRol
            // 
            this.labelNomRol.AutoSize = true;
            this.labelNomRol.Location = new System.Drawing.Point(327, 29);
            this.labelNomRol.Name = "labelNomRol";
            this.labelNomRol.Size = new System.Drawing.Size(83, 13);
            this.labelNomRol.TabIndex = 8;
            this.labelNomRol.Text = "Nombre del Rol:";
            this.labelNomRol.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // textBoxNomRol
            // 
            this.textBoxNomRol.Location = new System.Drawing.Point(416, 26);
            this.textBoxNomRol.Name = "textBoxNomRol";
            this.textBoxNomRol.Size = new System.Drawing.Size(137, 20);
            this.textBoxNomRol.TabIndex = 9;
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(256, 67);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 10;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // buttonAplicar
            // 
            this.buttonAplicar.Location = new System.Drawing.Point(351, 389);
            this.buttonAplicar.Name = "buttonAplicar";
            this.buttonAplicar.Size = new System.Drawing.Size(75, 23);
            this.buttonAplicar.TabIndex = 11;
            this.buttonAplicar.Text = "Aplicar";
            this.buttonAplicar.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(478, 389);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(31, 389);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 13;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // FormABMRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 432);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonAplicar);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.textBoxNomRol);
            this.Controls.Add(this.labelNomRol);
            this.Controls.Add(this.labelComboRoles);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.ModificacionFunc);
            this.Name = "FormABMRoles";
            this.Text = "Roles de Usuarios";
            this.ModificacionFunc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFunc;
        private System.Windows.Forms.ListBox listFuncActivas;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Button bQuitar;
        private System.Windows.Forms.GroupBox ModificacionFunc;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Label labelComboRoles;
        private System.Windows.Forms.Label labelNomRol;
        private System.Windows.Forms.TextBox textBoxNomRol;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Button buttonAplicar;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancelar;

    }
}