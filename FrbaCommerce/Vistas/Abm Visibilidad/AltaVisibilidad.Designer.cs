﻿namespace FrbaCommerce.Vistas.Abm_Visibilidad
{
    partial class AltaVisibilidad
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Porcentaje = new System.Windows.Forms.TextBox();
            this.tb_Precio = new System.Windows.Forms.TextBox();
            this.tb_Descripcion = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.tb_Dias_habilitados = new System.Windows.Forms.TextBox();
            this.nud_Dias_habilitados = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Dias_habilitados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Porcentaje:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_Dias_habilitados);
            this.groupBox1.Controls.Add(this.tb_Dias_habilitados);
            this.groupBox1.Controls.Add(this.tb_Porcentaje);
            this.groupBox1.Controls.Add(this.tb_Precio);
            this.groupBox1.Controls.Add(this.tb_Descripcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese datos";
            // 
            // tb_Porcentaje
            // 
            this.tb_Porcentaje.Location = new System.Drawing.Point(105, 96);
            this.tb_Porcentaje.Name = "tb_Porcentaje";
            this.tb_Porcentaje.Size = new System.Drawing.Size(157, 20);
            this.tb_Porcentaje.TabIndex = 7;
            // 
            // tb_Precio
            // 
            this.tb_Precio.Location = new System.Drawing.Point(105, 64);
            this.tb_Precio.Name = "tb_Precio";
            this.tb_Precio.Size = new System.Drawing.Size(157, 20);
            this.tb_Precio.TabIndex = 6;
            // 
            // tb_Descripcion
            // 
            this.tb_Descripcion.Location = new System.Drawing.Point(105, 30);
            this.tb_Descripcion.Name = "tb_Descripcion";
            this.tb_Descripcion.Size = new System.Drawing.Size(157, 20);
            this.tb_Descripcion.TabIndex = 5;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(47, 191);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(99, 23);
            this.button_Cancelar.TabIndex = 5;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(173, 191);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(101, 23);
            this.button_Guardar.TabIndex = 6;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // tb_Dias_habilitados
            // 
            this.tb_Dias_habilitados.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Dias_habilitados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Dias_habilitados.Location = new System.Drawing.Point(34, 124);
            this.tb_Dias_habilitados.Multiline = true;
            this.tb_Dias_habilitados.Name = "tb_Dias_habilitados";
            this.tb_Dias_habilitados.Size = new System.Drawing.Size(63, 34);
            this.tb_Dias_habilitados.TabIndex = 8;
            this.tb_Dias_habilitados.Text = "Dias habilitados:";
            // 
            // nud_Dias_habilitados
            // 
            this.nud_Dias_habilitados.Location = new System.Drawing.Point(105, 129);
            this.nud_Dias_habilitados.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nud_Dias_habilitados.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Dias_habilitados.Name = "nud_Dias_habilitados";
            this.nud_Dias_habilitados.Size = new System.Drawing.Size(157, 20);
            this.nud_Dias_habilitados.TabIndex = 9;
            this.nud_Dias_habilitados.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AltaVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 222);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaVisibilidad";
            this.Text = "Alta de visibilidad";
            this.Load += new System.EventHandler(this.AltaVisibilidad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Dias_habilitados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Descripcion;
        private System.Windows.Forms.TextBox tb_Porcentaje;
        private System.Windows.Forms.TextBox tb_Precio;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.NumericUpDown nud_Dias_habilitados;
        private System.Windows.Forms.TextBox tb_Dias_habilitados;
    }
}