namespace FrbaCommerce.Vistas.ABM_Rol
{
    partial class AltaDeRol
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
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Crear = new System.Windows.Forms.Button();
            this.tb_Nombre_del_rol = new System.Windows.Forms.TextBox();
            this.lbl_Nombre_nuevo = new System.Windows.Forms.Label();
            this.gb_Asignacion_de_funcionalidades = new System.Windows.Forms.GroupBox();
            this.list_funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.ch_Habilitado = new System.Windows.Forms.CheckBox();
            this.gb_Asignacion_de_funcionalidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(18, 312);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(111, 23);
            this.btn_Cancelar.TabIndex = 29;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Crear
            // 
            this.btn_Crear.Location = new System.Drawing.Point(304, 312);
            this.btn_Crear.Name = "btn_Crear";
            this.btn_Crear.Size = new System.Drawing.Size(111, 23);
            this.btn_Crear.TabIndex = 28;
            this.btn_Crear.Text = "Crear";
            this.btn_Crear.UseVisualStyleBackColor = true;
            this.btn_Crear.Click += new System.EventHandler(this.btn_Crear_Click);
            // 
            // tb_Nombre_del_rol
            // 
            this.tb_Nombre_del_rol.Location = new System.Drawing.Point(98, 12);
            this.tb_Nombre_del_rol.Name = "tb_Nombre_del_rol";
            this.tb_Nombre_del_rol.Size = new System.Drawing.Size(224, 20);
            this.tb_Nombre_del_rol.TabIndex = 25;
            // 
            // lbl_Nombre_nuevo
            // 
            this.lbl_Nombre_nuevo.AutoSize = true;
            this.lbl_Nombre_nuevo.Location = new System.Drawing.Point(15, 15);
            this.lbl_Nombre_nuevo.Name = "lbl_Nombre_nuevo";
            this.lbl_Nombre_nuevo.Size = new System.Drawing.Size(75, 13);
            this.lbl_Nombre_nuevo.TabIndex = 24;
            this.lbl_Nombre_nuevo.Text = "Nombre del rol";
            // 
            // gb_Asignacion_de_funcionalidades
            // 
            this.gb_Asignacion_de_funcionalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Asignacion_de_funcionalidades.Controls.Add(this.list_funcionalidades);
            this.gb_Asignacion_de_funcionalidades.Location = new System.Drawing.Point(12, 38);
            this.gb_Asignacion_de_funcionalidades.Name = "gb_Asignacion_de_funcionalidades";
            this.gb_Asignacion_de_funcionalidades.Size = new System.Drawing.Size(409, 269);
            this.gb_Asignacion_de_funcionalidades.TabIndex = 30;
            this.gb_Asignacion_de_funcionalidades.TabStop = false;
            this.gb_Asignacion_de_funcionalidades.Text = "Asignacion de funcionalidades";
            // 
            // list_funcionalidades
            // 
            this.list_funcionalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list_funcionalidades.CheckOnClick = true;
            this.list_funcionalidades.FormattingEnabled = true;
            this.list_funcionalidades.Location = new System.Drawing.Point(6, 19);
            this.list_funcionalidades.Name = "list_funcionalidades";
            this.list_funcionalidades.Size = new System.Drawing.Size(397, 244);
            this.list_funcionalidades.TabIndex = 0;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(164, 312);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(111, 23);
            this.btn_Limpiar.TabIndex = 31;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // ch_Habilitado
            // 
            this.ch_Habilitado.AutoSize = true;
            this.ch_Habilitado.Location = new System.Drawing.Point(342, 14);
            this.ch_Habilitado.Name = "ch_Habilitado";
            this.ch_Habilitado.Size = new System.Drawing.Size(73, 17);
            this.ch_Habilitado.TabIndex = 32;
            this.ch_Habilitado.Text = "Habilitado";
            this.ch_Habilitado.UseVisualStyleBackColor = true;
            // 
            // AltaDeRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 347);
            this.Controls.Add(this.ch_Habilitado);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.gb_Asignacion_de_funcionalidades);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Crear);
            this.Controls.Add(this.tb_Nombre_del_rol);
            this.Controls.Add(this.lbl_Nombre_nuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AltaDeRol";
            this.Text = "Crear un rol";
            this.Load += new System.EventHandler(this.AltaDeRol_Load);
            this.gb_Asignacion_de_funcionalidades.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Crear;
        private System.Windows.Forms.TextBox tb_Nombre_del_rol;
        private System.Windows.Forms.Label lbl_Nombre_nuevo;
        private System.Windows.Forms.GroupBox gb_Asignacion_de_funcionalidades;
        private System.Windows.Forms.CheckedListBox list_funcionalidades;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.CheckBox ch_Habilitado;
    }
}