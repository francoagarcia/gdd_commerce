namespace FrbaCommerce.GUIMethods.FormBase
{
    partial class FormBaseSeleccionTipo
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
            this.groupBox_Tipo = new System.Windows.Forms.GroupBox();
            this.label_Tipo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_Tipo = new System.Windows.Forms.ComboBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Siguiente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_Tipo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Tipo
            // 
            this.groupBox_Tipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox_Tipo.Controls.Add(this.label_Tipo);
            this.groupBox_Tipo.Controls.Add(this.label10);
            this.groupBox_Tipo.Controls.Add(this.cb_Tipo);
            this.groupBox_Tipo.Location = new System.Drawing.Point(11, 12);
            this.groupBox_Tipo.Name = "groupBox_Tipo";
            this.groupBox_Tipo.Size = new System.Drawing.Size(318, 85);
            this.groupBox_Tipo.TabIndex = 8;
            this.groupBox_Tipo.TabStop = false;
            this.groupBox_Tipo.Text = "Seleccione el tipo de";
            // 
            // label_Tipo
            // 
            this.label_Tipo.AutoSize = true;
            this.label_Tipo.Location = new System.Drawing.Point(6, 39);
            this.label_Tipo.Name = "label_Tipo";
            this.label_Tipo.Size = new System.Drawing.Size(31, 13);
            this.label_Tipo.TabIndex = 23;
            this.label_Tipo.Text = "Tipo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 22;
            // 
            // cb_Tipo
            // 
            this.cb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo.FormattingEnabled = true;
            this.cb_Tipo.Location = new System.Drawing.Point(127, 36);
            this.cb_Tipo.Name = "cb_Tipo";
            this.cb_Tipo.Size = new System.Drawing.Size(178, 21);
            this.cb_Tipo.TabIndex = 2;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Location = new System.Drawing.Point(32, 111);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(125, 23);
            this.btn_Cancelar.TabIndex = 15;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Siguiente
            // 
            this.btn_Siguiente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Siguiente.Location = new System.Drawing.Point(179, 111);
            this.btn_Siguiente.Name = "btn_Siguiente";
            this.btn_Siguiente.Size = new System.Drawing.Size(125, 23);
            this.btn_Siguiente.TabIndex = 6;
            this.btn_Siguiente.Text = "Siguiente";
            this.btn_Siguiente.UseVisualStyleBackColor = true;
            this.btn_Siguiente.Click += new System.EventHandler(this.btn_Siguiente_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox_Tipo);
            this.panel1.Controls.Add(this.btn_Siguiente);
            this.panel1.Controls.Add(this.btn_Cancelar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 149);
            this.panel1.TabIndex = 16;
            // 
            // FormBaseSeleccionTipo
            // 
            this.AcceptButton = this.btn_Siguiente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancelar;
            this.ClientSize = new System.Drawing.Size(365, 174);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBaseSeleccionTipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionDeTipo";
            this.Load += new System.EventHandler(this.FormBaseSeleccionTipo_Load);
            this.groupBox_Tipo.ResumeLayout(false);
            this.groupBox_Tipo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Tipo;
        private System.Windows.Forms.Button btn_Siguiente;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.GroupBox groupBox_Tipo;
        protected System.Windows.Forms.Label label_Tipo;
        private System.Windows.Forms.Panel panel1;
    }
}