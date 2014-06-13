namespace FrbaCommerce.Vistas.ABM_Rol
{
    partial class AltaRol
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
            this.bAgregar1 = new System.Windows.Forms.Button();
            this.bQuitar1 = new System.Windows.Forms.Button();
            this.ModificacionFunc1 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelNomRol1 = new System.Windows.Forms.Label();
            this.textBoxNomRol1 = new System.Windows.Forms.TextBox();
            this.buttonOK1 = new System.Windows.Forms.Button();
            this.buttonCancelar1 = new System.Windows.Forms.Button();
            this.ModificacionFunc1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAgregar1
            // 
            this.bAgregar1.Location = new System.Drawing.Point(193, 88);
            this.bAgregar1.Name = "bAgregar1";
            this.bAgregar1.Size = new System.Drawing.Size(75, 23);
            this.bAgregar1.TabIndex = 2;
            this.bAgregar1.Text = "Agregar";
            this.bAgregar1.UseVisualStyleBackColor = true;
            this.bAgregar1.Click += new System.EventHandler(this.bAgregar_Click);
            // 
            // bQuitar1
            // 
            this.bQuitar1.Location = new System.Drawing.Point(193, 154);
            this.bQuitar1.Name = "bQuitar1";
            this.bQuitar1.Size = new System.Drawing.Size(75, 23);
            this.bQuitar1.TabIndex = 3;
            this.bQuitar1.Text = "Limpiar";
            this.bQuitar1.UseVisualStyleBackColor = true;
            this.bQuitar1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModificacionFunc1
            // 
            this.ModificacionFunc1.Controls.Add(this.listBox2);
            this.ModificacionFunc1.Controls.Add(this.listBox1);
            this.ModificacionFunc1.Controls.Add(this.bQuitar1);
            this.ModificacionFunc1.Controls.Add(this.bAgregar1);
            this.ModificacionFunc1.Location = new System.Drawing.Point(12, 63);
            this.ModificacionFunc1.Name = "ModificacionFunc1";
            this.ModificacionFunc1.Size = new System.Drawing.Size(460, 286);
            this.ModificacionFunc1.TabIndex = 4;
            this.ModificacionFunc1.TabStop = false;
            this.ModificacionFunc1.Text = "Asignacion de Funcionalidades";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(274, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(169, 225);
            this.listBox2.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(169, 225);
            this.listBox1.TabIndex = 4;
            // 
            // labelNomRol1
            // 
            this.labelNomRol1.AutoSize = true;
            this.labelNomRol1.Location = new System.Drawing.Point(25, 24);
            this.labelNomRol1.Name = "labelNomRol1";
            this.labelNomRol1.Size = new System.Drawing.Size(83, 13);
            this.labelNomRol1.TabIndex = 8;
            this.labelNomRol1.Text = "Nombre del Rol:";
            // 
            // textBoxNomRol1
            // 
            this.textBoxNomRol1.Location = new System.Drawing.Point(114, 21);
            this.textBoxNomRol1.Name = "textBoxNomRol1";
            this.textBoxNomRol1.Size = new System.Drawing.Size(341, 20);
            this.textBoxNomRol1.TabIndex = 9;
            // 
            // buttonOK1
            // 
            this.buttonOK1.Location = new System.Drawing.Point(286, 355);
            this.buttonOK1.Name = "buttonOK1";
            this.buttonOK1.Size = new System.Drawing.Size(169, 23);
            this.buttonOK1.TabIndex = 12;
            this.buttonOK1.Text = "Crear";
            this.buttonOK1.UseVisualStyleBackColor = true;
            this.buttonOK1.Click += new System.EventHandler(this.buttonOK1_Click);
            // 
            // buttonCancelar1
            // 
            this.buttonCancelar1.Location = new System.Drawing.Point(27, 352);
            this.buttonCancelar1.Name = "buttonCancelar1";
            this.buttonCancelar1.Size = new System.Drawing.Size(169, 23);
            this.buttonCancelar1.TabIndex = 13;
            this.buttonCancelar1.Text = "Cancelar";
            this.buttonCancelar1.UseVisualStyleBackColor = true;
            this.buttonCancelar1.Click += new System.EventHandler(this.buttonCancelar1_Click);
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 387);
            this.Controls.Add(this.buttonCancelar1);
            this.Controls.Add(this.buttonOK1);
            this.Controls.Add(this.textBoxNomRol1);
            this.Controls.Add(this.labelNomRol1);
            this.Controls.Add(this.ModificacionFunc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AltaRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Roles";
            this.ModificacionFunc1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ListBox listFunc;
        //private System.Windows.Forms.ListBox listFuncActivas;
        private System.Windows.Forms.Button bAgregar1;
        private System.Windows.Forms.Button bQuitar1;
        private System.Windows.Forms.GroupBox ModificacionFunc1;
        private System.Windows.Forms.Label labelNomRol1;
        private System.Windows.Forms.TextBox textBoxNomRol1;
        private System.Windows.Forms.Button buttonOK1;
        private System.Windows.Forms.Button buttonCancelar1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;

    }
}