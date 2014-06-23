namespace FrbaCommerce.Vistas.Gestion_de_Preguntas
{
    partial class GestionPreguntas
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
            this.pnl_Seleccion = new System.Windows.Forms.Panel();
            this.btn_Ver_respuestas = new System.Windows.Forms.Button();
            this.btn_Ver_preguntas_pendientes = new System.Windows.Forms.Button();
            this.pnl_Busqueda = new System.Windows.Forms.Panel();
            this.dgv_Busqueda = new System.Windows.Forms.DataGridView();
            this.pnl_Acciones = new System.Windows.Forms.Panel();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.pnl_Seleccion.SuspendLayout();
            this.pnl_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).BeginInit();
            this.pnl_Acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Seleccion
            // 
            this.pnl_Seleccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Seleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Seleccion.Controls.Add(this.btn_Ver_respuestas);
            this.pnl_Seleccion.Controls.Add(this.btn_Ver_preguntas_pendientes);
            this.pnl_Seleccion.Location = new System.Drawing.Point(12, 12);
            this.pnl_Seleccion.Name = "pnl_Seleccion";
            this.pnl_Seleccion.Size = new System.Drawing.Size(557, 56);
            this.pnl_Seleccion.TabIndex = 0;
            // 
            // btn_Ver_respuestas
            // 
            this.btn_Ver_respuestas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Ver_respuestas.Location = new System.Drawing.Point(289, 13);
            this.btn_Ver_respuestas.Name = "btn_Ver_respuestas";
            this.btn_Ver_respuestas.Size = new System.Drawing.Size(193, 29);
            this.btn_Ver_respuestas.TabIndex = 1;
            this.btn_Ver_respuestas.Text = "Ver respuestas";
            this.btn_Ver_respuestas.UseVisualStyleBackColor = true;
            this.btn_Ver_respuestas.Click += new System.EventHandler(this.btn_Ver_respuestas_Click);
            // 
            // btn_Ver_preguntas_pendientes
            // 
            this.btn_Ver_preguntas_pendientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Ver_preguntas_pendientes.Location = new System.Drawing.Point(68, 13);
            this.btn_Ver_preguntas_pendientes.Name = "btn_Ver_preguntas_pendientes";
            this.btn_Ver_preguntas_pendientes.Size = new System.Drawing.Size(204, 29);
            this.btn_Ver_preguntas_pendientes.TabIndex = 0;
            this.btn_Ver_preguntas_pendientes.Text = "Ver preguntas pendientes";
            this.btn_Ver_preguntas_pendientes.UseVisualStyleBackColor = true;
            this.btn_Ver_preguntas_pendientes.Click += new System.EventHandler(this.btn_Ver_preguntas_pendientes_Click);
            // 
            // pnl_Busqueda
            // 
            this.pnl_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Busqueda.Controls.Add(this.dgv_Busqueda);
            this.pnl_Busqueda.Location = new System.Drawing.Point(12, 74);
            this.pnl_Busqueda.Name = "pnl_Busqueda";
            this.pnl_Busqueda.Size = new System.Drawing.Size(557, 280);
            this.pnl_Busqueda.TabIndex = 1;
            // 
            // dgv_Busqueda
            // 
            this.dgv_Busqueda.AllowDrop = true;
            this.dgv_Busqueda.AllowUserToAddRows = false;
            this.dgv_Busqueda.AllowUserToDeleteRows = false;
            this.dgv_Busqueda.AllowUserToOrderColumns = true;
            this.dgv_Busqueda.AllowUserToResizeRows = false;
            this.dgv_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Busqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Busqueda.Location = new System.Drawing.Point(3, 3);
            this.dgv_Busqueda.MultiSelect = false;
            this.dgv_Busqueda.Name = "dgv_Busqueda";
            this.dgv_Busqueda.ReadOnly = true;
            this.dgv_Busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Busqueda.Size = new System.Drawing.Size(549, 272);
            this.dgv_Busqueda.TabIndex = 2;
            // 
            // pnl_Acciones
            // 
            this.pnl_Acciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Acciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Acciones.Controls.Add(this.btn_Seleccionar);
            this.pnl_Acciones.Controls.Add(this.btn_Salir);
            this.pnl_Acciones.Location = new System.Drawing.Point(12, 360);
            this.pnl_Acciones.Name = "pnl_Acciones";
            this.pnl_Acciones.Size = new System.Drawing.Size(557, 56);
            this.pnl_Acciones.TabIndex = 2;
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Seleccionar.Enabled = false;
            this.btn_Seleccionar.Location = new System.Drawing.Point(380, 12);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(158, 29);
            this.btn_Seleccionar.TabIndex = 3;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Seleccionar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Salir.Location = new System.Drawing.Point(17, 12);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(158, 29);
            this.btn_Salir.TabIndex = 2;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // GestionPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 424);
            this.Controls.Add(this.pnl_Acciones);
            this.Controls.Add(this.pnl_Busqueda);
            this.Controls.Add(this.pnl_Seleccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GestionPreguntas";
            this.Text = "Gestion de preguntas";
            this.Load += new System.EventHandler(this.GestionPreguntas_Load);
            this.pnl_Seleccion.ResumeLayout(false);
            this.pnl_Busqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busqueda)).EndInit();
            this.pnl_Acciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Seleccion;
        private System.Windows.Forms.Button btn_Ver_respuestas;
        private System.Windows.Forms.Button btn_Ver_preguntas_pendientes;
        private System.Windows.Forms.Panel pnl_Busqueda;
        private System.Windows.Forms.Panel pnl_Acciones;
        protected System.Windows.Forms.DataGridView dgv_Busqueda;
        private System.Windows.Forms.Button btn_Seleccionar;
        private System.Windows.Forms.Button btn_Salir;

    }
}