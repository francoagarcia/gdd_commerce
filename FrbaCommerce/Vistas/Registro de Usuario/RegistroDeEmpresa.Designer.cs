namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    partial class RegistroDeEmpresa
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_Datos_de_usuario = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Contraseña = new System.Windows.Forms.TextBox();
            this.tb_Telefono = new System.Windows.Forms.TextBox();
            this.cb_Tipo_de_usuario = new System.Windows.Forms.ComboBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Ciudad = new System.Windows.Forms.TextBox();
            this.tb_Localidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Codigo_postal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Departamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Piso = new System.Windows.Forms.TextBox();
            this.tb_Calle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxDatosEmpresa = new System.Windows.Forms.GroupBox();
            this.tb_Razon_Social = new System.Windows.Forms.TextBox();
            this.tb_CUIT = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.tb_Correo_electronico = new System.Windows.Forms.TextBox();
            this.dp_Fecha_de_creacion = new System.Windows.Forms.DateTimePicker();
            this.labelFechaCreacion = new System.Windows.Forms.Label();
            this.tb_Nombre_de_contacto = new System.Windows.Forms.TextBox();
            this.lblNomDeContacto = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelInfoAsterizco = new System.Windows.Forms.Label();
            this.btnRegistracion = new System.Windows.Forms.Button();
            this.label_Ingrese_datos = new System.Windows.Forms.Label();
            this.groupBox_Datos_de_usuario.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxDatosEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Datos_de_usuario
            // 
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblUsuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.tb_Username);
            this.groupBox_Datos_de_usuario.Controls.Add(this.tb_Contraseña);
            this.groupBox_Datos_de_usuario.Controls.Add(this.tb_Telefono);
            this.groupBox_Datos_de_usuario.Controls.Add(this.cb_Tipo_de_usuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.labelTelefono);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblPassword);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblRol);
            this.groupBox_Datos_de_usuario.Location = new System.Drawing.Point(28, 32);
            this.groupBox_Datos_de_usuario.Name = "groupBox_Datos_de_usuario";
            this.groupBox_Datos_de_usuario.Size = new System.Drawing.Size(412, 136);
            this.groupBox_Datos_de_usuario.TabIndex = 41;
            this.groupBox_Datos_de_usuario.TabStop = false;
            this.groupBox_Datos_de_usuario.Text = "Datos de usuario";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(29, 26);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario";
            // 
            // tb_Username
            // 
            this.tb_Username.AcceptsTab = true;
            this.tb_Username.Location = new System.Drawing.Point(167, 23);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(216, 20);
            this.tb_Username.TabIndex = 0;
            // 
            // tb_Contraseña
            // 
            this.tb_Contraseña.AcceptsTab = true;
            this.tb_Contraseña.Location = new System.Drawing.Point(167, 49);
            this.tb_Contraseña.Name = "tb_Contraseña";
            this.tb_Contraseña.PasswordChar = '*';
            this.tb_Contraseña.Size = new System.Drawing.Size(216, 20);
            this.tb_Contraseña.TabIndex = 1;
            // 
            // tb_Telefono
            // 
            this.tb_Telefono.Location = new System.Drawing.Point(167, 74);
            this.tb_Telefono.Name = "tb_Telefono";
            this.tb_Telefono.Size = new System.Drawing.Size(216, 20);
            this.tb_Telefono.TabIndex = 27;
            // 
            // cb_Tipo_de_usuario
            // 
            this.cb_Tipo_de_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_de_usuario.FormattingEnabled = true;
            this.cb_Tipo_de_usuario.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.cb_Tipo_de_usuario.Location = new System.Drawing.Point(167, 101);
            this.cb_Tipo_de_usuario.Name = "cb_Tipo_de_usuario";
            this.cb_Tipo_de_usuario.Size = new System.Drawing.Size(216, 21);
            this.cb_Tipo_de_usuario.TabIndex = 2;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(29, 77);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(49, 13);
            this.labelTelefono.TabIndex = 26;
            this.labelTelefono.Text = "Telefono";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(29, 52);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(29, 104);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(80, 13);
            this.lblRol.TabIndex = 5;
            this.lblRol.Text = "Tipo de usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_Ciudad);
            this.groupBox2.Controls.Add(this.tb_Localidad);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tb_Codigo_postal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tb_Departamento);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_Piso);
            this.groupBox2.Controls.Add(this.tb_Calle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(28, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 134);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Domicilio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Ciudad";
            // 
            // tb_Ciudad
            // 
            this.tb_Ciudad.AcceptsTab = true;
            this.tb_Ciudad.Location = new System.Drawing.Point(87, 103);
            this.tb_Ciudad.Name = "tb_Ciudad";
            this.tb_Ciudad.Size = new System.Drawing.Size(296, 20);
            this.tb_Ciudad.TabIndex = 33;
            // 
            // tb_Localidad
            // 
            this.tb_Localidad.AcceptsTab = true;
            this.tb_Localidad.Location = new System.Drawing.Point(87, 78);
            this.tb_Localidad.Name = "tb_Localidad";
            this.tb_Localidad.Size = new System.Drawing.Size(296, 20);
            this.tb_Localidad.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Localidad";
            // 
            // tb_Codigo_postal
            // 
            this.tb_Codigo_postal.AcceptsTab = true;
            this.tb_Codigo_postal.Location = new System.Drawing.Point(309, 52);
            this.tb_Codigo_postal.Name = "tb_Codigo_postal";
            this.tb_Codigo_postal.Size = new System.Drawing.Size(74, 20);
            this.tb_Codigo_postal.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Codigo postal";
            // 
            // tb_Departamento
            // 
            this.tb_Departamento.AcceptsTab = true;
            this.tb_Departamento.Location = new System.Drawing.Point(188, 52);
            this.tb_Departamento.Name = "tb_Departamento";
            this.tb_Departamento.Size = new System.Drawing.Size(38, 20);
            this.tb_Departamento.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Departamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Piso";
            // 
            // tb_Piso
            // 
            this.tb_Piso.AcceptsTab = true;
            this.tb_Piso.Location = new System.Drawing.Point(65, 52);
            this.tb_Piso.Name = "tb_Piso";
            this.tb_Piso.Size = new System.Drawing.Size(37, 20);
            this.tb_Piso.TabIndex = 25;
            // 
            // tb_Calle
            // 
            this.tb_Calle.AcceptsTab = true;
            this.tb_Calle.Location = new System.Drawing.Point(65, 26);
            this.tb_Calle.Name = "tb_Calle";
            this.tb_Calle.Size = new System.Drawing.Size(318, 20);
            this.tb_Calle.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Calle";
            // 
            // groupBoxDatosEmpresa
            // 
            this.groupBoxDatosEmpresa.Controls.Add(this.tb_Razon_Social);
            this.groupBoxDatosEmpresa.Controls.Add(this.tb_CUIT);
            this.groupBoxDatosEmpresa.Controls.Add(this.lblMail);
            this.groupBoxDatosEmpresa.Controls.Add(this.tb_Correo_electronico);
            this.groupBoxDatosEmpresa.Controls.Add(this.dp_Fecha_de_creacion);
            this.groupBoxDatosEmpresa.Controls.Add(this.labelFechaCreacion);
            this.groupBoxDatosEmpresa.Controls.Add(this.tb_Nombre_de_contacto);
            this.groupBoxDatosEmpresa.Controls.Add(this.lblNomDeContacto);
            this.groupBoxDatosEmpresa.Controls.Add(this.lblCUIT);
            this.groupBoxDatosEmpresa.Controls.Add(this.lblRazonSocial);
            this.groupBoxDatosEmpresa.Location = new System.Drawing.Point(28, 173);
            this.groupBoxDatosEmpresa.Name = "groupBoxDatosEmpresa";
            this.groupBoxDatosEmpresa.Size = new System.Drawing.Size(412, 174);
            this.groupBoxDatosEmpresa.TabIndex = 39;
            this.groupBoxDatosEmpresa.TabStop = false;
            this.groupBoxDatosEmpresa.Text = "Datos de empresa";
            // 
            // tb_Razon_Social
            // 
            this.tb_Razon_Social.AcceptsTab = true;
            this.tb_Razon_Social.Location = new System.Drawing.Point(166, 27);
            this.tb_Razon_Social.Name = "tb_Razon_Social";
            this.tb_Razon_Social.Size = new System.Drawing.Size(216, 20);
            this.tb_Razon_Social.TabIndex = 43;
            // 
            // tb_CUIT
            // 
            this.tb_CUIT.AcceptsTab = true;
            this.tb_CUIT.Location = new System.Drawing.Point(166, 53);
            this.tb_CUIT.Name = "tb_CUIT";
            this.tb_CUIT.Size = new System.Drawing.Size(216, 20);
            this.tb_CUIT.TabIndex = 42;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(28, 109);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(93, 13);
            this.lblMail.TabIndex = 41;
            this.lblMail.Text = "Correo electrónico";
            // 
            // tb_Correo_electronico
            // 
            this.tb_Correo_electronico.AcceptsTab = true;
            this.tb_Correo_electronico.Location = new System.Drawing.Point(166, 106);
            this.tb_Correo_electronico.Name = "tb_Correo_electronico";
            this.tb_Correo_electronico.Size = new System.Drawing.Size(216, 20);
            this.tb_Correo_electronico.TabIndex = 40;
            // 
            // dp_Fecha_de_creacion
            // 
            this.dp_Fecha_de_creacion.Location = new System.Drawing.Point(166, 132);
            this.dp_Fecha_de_creacion.Name = "dp_Fecha_de_creacion";
            this.dp_Fecha_de_creacion.Size = new System.Drawing.Size(216, 20);
            this.dp_Fecha_de_creacion.TabIndex = 39;
            // 
            // labelFechaCreacion
            // 
            this.labelFechaCreacion.AutoSize = true;
            this.labelFechaCreacion.Location = new System.Drawing.Point(28, 138);
            this.labelFechaCreacion.Name = "labelFechaCreacion";
            this.labelFechaCreacion.Size = new System.Drawing.Size(96, 13);
            this.labelFechaCreacion.TabIndex = 38;
            this.labelFechaCreacion.Text = "Fecha de creación";
            // 
            // tb_Nombre_de_contacto
            // 
            this.tb_Nombre_de_contacto.AcceptsTab = true;
            this.tb_Nombre_de_contacto.Location = new System.Drawing.Point(166, 80);
            this.tb_Nombre_de_contacto.Name = "tb_Nombre_de_contacto";
            this.tb_Nombre_de_contacto.Size = new System.Drawing.Size(216, 20);
            this.tb_Nombre_de_contacto.TabIndex = 31;
            // 
            // lblNomDeContacto
            // 
            this.lblNomDeContacto.AutoSize = true;
            this.lblNomDeContacto.Location = new System.Drawing.Point(28, 83);
            this.lblNomDeContacto.Name = "lblNomDeContacto";
            this.lblNomDeContacto.Size = new System.Drawing.Size(104, 13);
            this.lblNomDeContacto.TabIndex = 30;
            this.lblNomDeContacto.Text = "Nombre de contacto";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(28, 56);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(32, 13);
            this.lblCUIT.TabIndex = 28;
            this.lblCUIT.Text = "CUIT";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(28, 29);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(68, 13);
            this.lblRazonSocial.TabIndex = 27;
            this.lblRazonSocial.Text = "Razon social";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(55, 523);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(164, 23);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // labelInfoAsterizco
            // 
            this.labelInfoAsterizco.AutoSize = true;
            this.labelInfoAsterizco.Location = new System.Drawing.Point(52, 499);
            this.labelInfoAsterizco.Name = "labelInfoAsterizco";
            this.labelInfoAsterizco.Size = new System.Drawing.Size(180, 13);
            this.labelInfoAsterizco.TabIndex = 37;
            this.labelInfoAsterizco.Text = "( * )  Todos los datos son obligatorios";
            // 
            // btnRegistracion
            // 
            this.btnRegistracion.Location = new System.Drawing.Point(225, 523);
            this.btnRegistracion.Name = "btnRegistracion";
            this.btnRegistracion.Size = new System.Drawing.Size(182, 23);
            this.btnRegistracion.TabIndex = 36;
            this.btnRegistracion.Text = "Confirmar";
            this.btnRegistracion.UseVisualStyleBackColor = true;
            // 
            // label_Ingrese_datos
            // 
            this.label_Ingrese_datos.AutoSize = true;
            this.label_Ingrese_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ingrese_datos.Location = new System.Drawing.Point(12, 9);
            this.label_Ingrese_datos.Name = "label_Ingrese_datos";
            this.label_Ingrese_datos.Size = new System.Drawing.Size(226, 16);
            this.label_Ingrese_datos.TabIndex = 42;
            this.label_Ingrese_datos.Text = "Complete los datos solicitados:";
            // 
            // RegistroDeEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 558);
            this.Controls.Add(this.label_Ingrese_datos);
            this.Controls.Add(this.groupBox_Datos_de_usuario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxDatosEmpresa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelInfoAsterizco);
            this.Controls.Add(this.btnRegistracion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistroDeEmpresa";
            this.Text = "Nueva empresa";
            this.Load += new System.EventHandler(this.RegistroDeEmpresa_Load);
            this.groupBox_Datos_de_usuario.ResumeLayout(false);
            this.groupBox_Datos_de_usuario.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxDatosEmpresa.ResumeLayout(false);
            this.groupBoxDatosEmpresa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Datos_de_usuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Contraseña;
        private System.Windows.Forms.TextBox tb_Telefono;
        private System.Windows.Forms.ComboBox cb_Tipo_de_usuario;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Ciudad;
        private System.Windows.Forms.TextBox tb_Localidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Codigo_postal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Departamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Piso;
        private System.Windows.Forms.TextBox tb_Calle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxDatosEmpresa;
        private System.Windows.Forms.TextBox tb_Razon_Social;
        private System.Windows.Forms.TextBox tb_CUIT;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox tb_Correo_electronico;
        private System.Windows.Forms.DateTimePicker dp_Fecha_de_creacion;
        private System.Windows.Forms.Label labelFechaCreacion;
        private System.Windows.Forms.TextBox tb_Nombre_de_contacto;
        private System.Windows.Forms.Label lblNomDeContacto;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelInfoAsterizco;
        private System.Windows.Forms.Button btnRegistracion;
        private System.Windows.Forms.Label label_Ingrese_datos;

    }
}