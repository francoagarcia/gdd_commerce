namespace FrbaCommerce.Vistas.Facturar_Publicaciones
{
    partial class FacturaVista
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
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.gb_Datos_del_usuario = new System.Windows.Forms.GroupBox();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.gb_Items_facturadas = new System.Windows.Forms.GroupBox();
            this.list_Items = new System.Windows.Forms.ListBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.lblProfesional = new System.Windows.Forms.Label();
            this.tb_Total_facturado = new System.Windows.Forms.TextBox();
            this.tb_Fecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_Datos_del_usuario.SuspendLayout();
            this.gb_Items_facturadas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.Location = new System.Drawing.Point(217, 9);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(222, 27);
            this.lbl_Titulo.TabIndex = 8;
            this.lbl_Titulo.Text = "Nro de factura:";
            // 
            // gb_Datos_del_usuario
            // 
            this.gb_Datos_del_usuario.Controls.Add(this.tb_Username);
            this.gb_Datos_del_usuario.Controls.Add(this.lbl_Username);
            this.gb_Datos_del_usuario.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Datos_del_usuario.Location = new System.Drawing.Point(17, 39);
            this.gb_Datos_del_usuario.Name = "gb_Datos_del_usuario";
            this.gb_Datos_del_usuario.Size = new System.Drawing.Size(725, 70);
            this.gb_Datos_del_usuario.TabIndex = 9;
            this.gb_Datos_del_usuario.TabStop = false;
            this.gb_Datos_del_usuario.Text = "Datos del usuario";
            // 
            // tb_Username
            // 
            this.tb_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Username.Location = new System.Drawing.Point(248, 32);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(471, 24);
            this.tb_Username.TabIndex = 2;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(7, 31);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(244, 23);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "Nombre de usuario:";
            // 
            // gb_Items_facturadas
            // 
            this.gb_Items_facturadas.Controls.Add(this.list_Items);
            this.gb_Items_facturadas.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Items_facturadas.Location = new System.Drawing.Point(17, 115);
            this.gb_Items_facturadas.Name = "gb_Items_facturadas";
            this.gb_Items_facturadas.Size = new System.Drawing.Size(725, 338);
            this.gb_Items_facturadas.TabIndex = 10;
            this.gb_Items_facturadas.TabStop = false;
            this.gb_Items_facturadas.Text = "Items facturados";
            // 
            // list_Items
            // 
            this.list_Items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Items.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Items.FormattingEnabled = true;
            this.list_Items.ItemHeight = 16;
            this.list_Items.Location = new System.Drawing.Point(6, 19);
            this.list_Items.Name = "list_Items";
            this.list_Items.Size = new System.Drawing.Size(713, 304);
            this.list_Items.TabIndex = 0;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(667, 484);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cerrar.TabIndex = 13;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // lblProfesional
            // 
            this.lblProfesional.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesional.Location = new System.Drawing.Point(278, 461);
            this.lblProfesional.Name = "lblProfesional";
            this.lblProfesional.Size = new System.Drawing.Size(170, 23);
            this.lblProfesional.TabIndex = 14;
            this.lblProfesional.Text = "Total facturado:";
            // 
            // tb_Total_facturado
            // 
            this.tb_Total_facturado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Total_facturado.Location = new System.Drawing.Point(449, 461);
            this.tb_Total_facturado.Name = "tb_Total_facturado";
            this.tb_Total_facturado.Size = new System.Drawing.Size(162, 20);
            this.tb_Total_facturado.TabIndex = 15;
            // 
            // tb_Fecha
            // 
            this.tb_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Fecha.Location = new System.Drawing.Point(77, 460);
            this.tb_Fecha.Name = "tb_Fecha";
            this.tb_Fecha.Size = new System.Drawing.Size(197, 20);
            this.tb_Fecha.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fecha:";
            // 
            // FacturaVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 519);
            this.Controls.Add(this.tb_Fecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Total_facturado);
            this.Controls.Add(this.lblProfesional);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.gb_Items_facturadas);
            this.Controls.Add(this.gb_Datos_del_usuario);
            this.Controls.Add(this.lbl_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FacturaVista";
            this.Text = "FRBA Commerce - Facturacion";
            this.Load += new System.EventHandler(this.FacturaVista_Load);
            this.gb_Datos_del_usuario.ResumeLayout(false);
            this.gb_Datos_del_usuario.PerformLayout();
            this.gb_Items_facturadas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.GroupBox gb_Datos_del_usuario;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.GroupBox gb_Items_facturadas;
        private System.Windows.Forms.ListBox list_Items;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.TextBox tb_Total_facturado;
        private System.Windows.Forms.TextBox tb_Fecha;
        private System.Windows.Forms.Label label1;
    }
}