namespace FrbaCommerce.Vistas.Registro_de_Usuario
{
    partial class RegistroDeCliente
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
            this.textBox_Nombre_de_usuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.textBox_Contraseña = new System.Windows.Forms.TextBox();
            this.comboBox_Tipo_de_usuario = new System.Windows.Forms.ComboBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.textBox_Telefono = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.groupBoxDatosCliente = new System.Windows.Forms.GroupBox();
            this.comboBox_Tipo_de_documento = new System.Windows.Forms.ComboBox();
            this.textBox_Numero_de_documento = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.textBox_Correo_electronico = new System.Windows.Forms.TextBox();
            this.dp_Fecha_de_nacimiento = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Sexo = new System.Windows.Forms.ComboBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.labelFechaNacimiento = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.labelSexo = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.groupBoxDomicilioCliente = new System.Windows.Forms.GroupBox();
            this.textBox_Calle = new System.Windows.Forms.TextBox();
            this.textBox_Piso = new System.Windows.Forms.TextBox();
            this.textBox_Departamento = new System.Windows.Forms.TextBox();
            this.textBox_Codigo_postal = new System.Windows.Forms.TextBox();
            this.textBox_Localidad = new System.Windows.Forms.TextBox();
            this.labelLocalidad = new System.Windows.Forms.Label();
            this.labelCodPostal = new System.Windows.Forms.Label();
            this.labelDepto = new System.Windows.Forms.Label();
            this.labelPiso = new System.Windows.Forms.Label();
            this.labelCalle = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistracion = new System.Windows.Forms.Button();
            this.labelInfoAsterizco = new System.Windows.Forms.Label();
            this.label_Ingrese_datos = new System.Windows.Forms.Label();
            this.groupBox_Datos_de_usuario.SuspendLayout();
            this.groupBoxDatosCliente.SuspendLayout();
            this.groupBoxDomicilioCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Datos_de_usuario
            // 
            this.groupBox_Datos_de_usuario.Controls.Add(this.textBox_Nombre_de_usuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblUsuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.textBox_Contraseña);
            this.groupBox_Datos_de_usuario.Controls.Add(this.comboBox_Tipo_de_usuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblContraseña);
            this.groupBox_Datos_de_usuario.Controls.Add(this.textBox_Telefono);
            this.groupBox_Datos_de_usuario.Controls.Add(this.labelTelefono);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblRol);
            this.groupBox_Datos_de_usuario.Location = new System.Drawing.Point(26, 32);
            this.groupBox_Datos_de_usuario.Name = "groupBox_Datos_de_usuario";
            this.groupBox_Datos_de_usuario.Size = new System.Drawing.Size(412, 125);
            this.groupBox_Datos_de_usuario.TabIndex = 36;
            this.groupBox_Datos_de_usuario.TabStop = false;
            this.groupBox_Datos_de_usuario.Text = "Datos de usuarios";
            // 
            // textBox_Nombre_de_usuario
            // 
            this.textBox_Nombre_de_usuario.Location = new System.Drawing.Point(161, 19);
            this.textBox_Nombre_de_usuario.Name = "textBox_Nombre_de_usuario";
            this.textBox_Nombre_de_usuario.Size = new System.Drawing.Size(216, 20);
            this.textBox_Nombre_de_usuario.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(23, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(96, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Nombre de usuario";
            // 
            // textBox_Contraseña
            // 
            this.textBox_Contraseña.Location = new System.Drawing.Point(161, 45);
            this.textBox_Contraseña.Name = "textBox_Contraseña";
            this.textBox_Contraseña.PasswordChar = '*';
            this.textBox_Contraseña.Size = new System.Drawing.Size(216, 20);
            this.textBox_Contraseña.TabIndex = 1;
            // 
            // comboBox_Tipo_de_usuario
            // 
            this.comboBox_Tipo_de_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo_de_usuario.FormattingEnabled = true;
            this.comboBox_Tipo_de_usuario.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.comboBox_Tipo_de_usuario.Location = new System.Drawing.Point(161, 96);
            this.comboBox_Tipo_de_usuario.Name = "comboBox_Tipo_de_usuario";
            this.comboBox_Tipo_de_usuario.Size = new System.Drawing.Size(216, 21);
            this.comboBox_Tipo_de_usuario.TabIndex = 2;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(23, 48);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(61, 13);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Contraseña";
            // 
            // textBox_Telefono
            // 
            this.textBox_Telefono.Location = new System.Drawing.Point(161, 70);
            this.textBox_Telefono.Name = "textBox_Telefono";
            this.textBox_Telefono.Size = new System.Drawing.Size(216, 20);
            this.textBox_Telefono.TabIndex = 27;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(23, 73);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(49, 13);
            this.labelTelefono.TabIndex = 26;
            this.labelTelefono.Text = "Telefono";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(23, 100);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(80, 13);
            this.lblRol.TabIndex = 5;
            this.lblRol.Text = "Tipo de usuario";
            // 
            // groupBoxDatosCliente
            // 
            this.groupBoxDatosCliente.Controls.Add(this.comboBox_Tipo_de_documento);
            this.groupBoxDatosCliente.Controls.Add(this.textBox_Numero_de_documento);
            this.groupBoxDatosCliente.Controls.Add(this.textBox_Nombre);
            this.groupBoxDatosCliente.Controls.Add(this.textBox_Apellido);
            this.groupBoxDatosCliente.Controls.Add(this.textBox_Correo_electronico);
            this.groupBoxDatosCliente.Controls.Add(this.dp_Fecha_de_nacimiento);
            this.groupBoxDatosCliente.Controls.Add(this.comboBox_Sexo);
            this.groupBoxDatosCliente.Controls.Add(this.lblMail);
            this.groupBoxDatosCliente.Controls.Add(this.labelFechaNacimiento);
            this.groupBoxDatosCliente.Controls.Add(this.lblNombre);
            this.groupBoxDatosCliente.Controls.Add(this.lblApellido);
            this.groupBoxDatosCliente.Controls.Add(this.labelSexo);
            this.groupBoxDatosCliente.Controls.Add(this.lblNroDoc);
            this.groupBoxDatosCliente.Controls.Add(this.lblTipoDoc);
            this.groupBoxDatosCliente.Location = new System.Drawing.Point(26, 167);
            this.groupBoxDatosCliente.Name = "groupBoxDatosCliente";
            this.groupBoxDatosCliente.Size = new System.Drawing.Size(412, 222);
            this.groupBoxDatosCliente.TabIndex = 34;
            this.groupBoxDatosCliente.TabStop = false;
            this.groupBoxDatosCliente.Text = "Datos de cliente";
            // 
            // comboBox_Tipo_de_documento
            // 
            this.comboBox_Tipo_de_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo_de_documento.FormattingEnabled = true;
            this.comboBox_Tipo_de_documento.Location = new System.Drawing.Point(167, 24);
            this.comboBox_Tipo_de_documento.Name = "comboBox_Tipo_de_documento";
            this.comboBox_Tipo_de_documento.Size = new System.Drawing.Size(216, 21);
            this.comboBox_Tipo_de_documento.TabIndex = 29;
            // 
            // textBox_Numero_de_documento
            // 
            this.textBox_Numero_de_documento.Location = new System.Drawing.Point(167, 51);
            this.textBox_Numero_de_documento.Name = "textBox_Numero_de_documento";
            this.textBox_Numero_de_documento.Size = new System.Drawing.Size(216, 20);
            this.textBox_Numero_de_documento.TabIndex = 31;
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(167, 77);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(216, 20);
            this.textBox_Nombre.TabIndex = 35;
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.Location = new System.Drawing.Point(167, 103);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(216, 20);
            this.textBox_Apellido.TabIndex = 36;
            // 
            // textBox_Correo_electronico
            // 
            this.textBox_Correo_electronico.Location = new System.Drawing.Point(167, 129);
            this.textBox_Correo_electronico.Name = "textBox_Correo_electronico";
            this.textBox_Correo_electronico.Size = new System.Drawing.Size(216, 20);
            this.textBox_Correo_electronico.TabIndex = 40;
            // 
            // dp_Fecha_de_nacimiento
            // 
            this.dp_Fecha_de_nacimiento.Location = new System.Drawing.Point(167, 185);
            this.dp_Fecha_de_nacimiento.Name = "dp_Fecha_de_nacimiento";
            this.dp_Fecha_de_nacimiento.Size = new System.Drawing.Size(216, 20);
            this.dp_Fecha_de_nacimiento.TabIndex = 39;
            // 
            // comboBox_Sexo
            // 
            this.comboBox_Sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sexo.FormattingEnabled = true;
            this.comboBox_Sexo.Location = new System.Drawing.Point(167, 155);
            this.comboBox_Sexo.Name = "comboBox_Sexo";
            this.comboBox_Sexo.Size = new System.Drawing.Size(216, 21);
            this.comboBox_Sexo.TabIndex = 37;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(29, 132);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(93, 13);
            this.lblMail.TabIndex = 41;
            this.lblMail.Text = "Correo electrónico";
            // 
            // labelFechaNacimiento
            // 
            this.labelFechaNacimiento.AutoSize = true;
            this.labelFechaNacimiento.Location = new System.Drawing.Point(29, 185);
            this.labelFechaNacimiento.Name = "labelFechaNacimiento";
            this.labelFechaNacimiento.Size = new System.Drawing.Size(106, 13);
            this.labelFechaNacimiento.TabIndex = 38;
            this.labelFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(29, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 32;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(29, 106);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 33;
            this.lblApellido.Text = "Apellido";
            // 
            // labelSexo
            // 
            this.labelSexo.AutoSize = true;
            this.labelSexo.Location = new System.Drawing.Point(29, 158);
            this.labelSexo.Name = "labelSexo";
            this.labelSexo.Size = new System.Drawing.Size(31, 13);
            this.labelSexo.TabIndex = 34;
            this.labelSexo.Text = "Sexo";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(29, 54);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(115, 13);
            this.lblNroDoc.TabIndex = 30;
            this.lblNroDoc.Text = "Numero de documento";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(29, 27);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(99, 13);
            this.lblTipoDoc.TabIndex = 28;
            this.lblTipoDoc.Text = "Tipo de documento";
            // 
            // groupBoxDomicilioCliente
            // 
            this.groupBoxDomicilioCliente.Controls.Add(this.textBox_Calle);
            this.groupBoxDomicilioCliente.Controls.Add(this.textBox_Piso);
            this.groupBoxDomicilioCliente.Controls.Add(this.textBox_Departamento);
            this.groupBoxDomicilioCliente.Controls.Add(this.textBox_Codigo_postal);
            this.groupBoxDomicilioCliente.Controls.Add(this.textBox_Localidad);
            this.groupBoxDomicilioCliente.Controls.Add(this.labelLocalidad);
            this.groupBoxDomicilioCliente.Controls.Add(this.labelCodPostal);
            this.groupBoxDomicilioCliente.Controls.Add(this.labelDepto);
            this.groupBoxDomicilioCliente.Controls.Add(this.labelPiso);
            this.groupBoxDomicilioCliente.Controls.Add(this.labelCalle);
            this.groupBoxDomicilioCliente.Location = new System.Drawing.Point(26, 395);
            this.groupBoxDomicilioCliente.Name = "groupBoxDomicilioCliente";
            this.groupBoxDomicilioCliente.Size = new System.Drawing.Size(412, 108);
            this.groupBoxDomicilioCliente.TabIndex = 35;
            this.groupBoxDomicilioCliente.TabStop = false;
            this.groupBoxDomicilioCliente.Text = "Domicilio";
            // 
            // textBox_Calle
            // 
            this.textBox_Calle.Location = new System.Drawing.Point(67, 26);
            this.textBox_Calle.Name = "textBox_Calle";
            this.textBox_Calle.Size = new System.Drawing.Size(318, 20);
            this.textBox_Calle.TabIndex = 24;
            // 
            // textBox_Piso
            // 
            this.textBox_Piso.Location = new System.Drawing.Point(67, 52);
            this.textBox_Piso.Name = "textBox_Piso";
            this.textBox_Piso.Size = new System.Drawing.Size(37, 20);
            this.textBox_Piso.TabIndex = 25;
            // 
            // textBox_Departamento
            // 
            this.textBox_Departamento.Location = new System.Drawing.Point(190, 52);
            this.textBox_Departamento.Name = "textBox_Departamento";
            this.textBox_Departamento.Size = new System.Drawing.Size(38, 20);
            this.textBox_Departamento.TabIndex = 28;
            // 
            // textBox_Codigo_postal
            // 
            this.textBox_Codigo_postal.Location = new System.Drawing.Point(311, 52);
            this.textBox_Codigo_postal.Name = "textBox_Codigo_postal";
            this.textBox_Codigo_postal.Size = new System.Drawing.Size(74, 20);
            this.textBox_Codigo_postal.TabIndex = 30;
            // 
            // textBox_Localidad
            // 
            this.textBox_Localidad.Location = new System.Drawing.Point(89, 78);
            this.textBox_Localidad.Name = "textBox_Localidad";
            this.textBox_Localidad.Size = new System.Drawing.Size(296, 20);
            this.textBox_Localidad.TabIndex = 32;
            // 
            // labelLocalidad
            // 
            this.labelLocalidad.AutoSize = true;
            this.labelLocalidad.Location = new System.Drawing.Point(30, 81);
            this.labelLocalidad.Name = "labelLocalidad";
            this.labelLocalidad.Size = new System.Drawing.Size(53, 13);
            this.labelLocalidad.TabIndex = 31;
            this.labelLocalidad.Text = "Localidad";
            // 
            // labelCodPostal
            // 
            this.labelCodPostal.AutoSize = true;
            this.labelCodPostal.Location = new System.Drawing.Point(234, 55);
            this.labelCodPostal.Name = "labelCodPostal";
            this.labelCodPostal.Size = new System.Drawing.Size(71, 13);
            this.labelCodPostal.TabIndex = 29;
            this.labelCodPostal.Text = "Codigo postal";
            // 
            // labelDepto
            // 
            this.labelDepto.AutoSize = true;
            this.labelDepto.Location = new System.Drawing.Point(110, 53);
            this.labelDepto.Name = "labelDepto";
            this.labelDepto.Size = new System.Drawing.Size(74, 13);
            this.labelDepto.TabIndex = 27;
            this.labelDepto.Text = "Departamento";
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Location = new System.Drawing.Point(30, 55);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(27, 13);
            this.labelPiso.TabIndex = 26;
            this.labelPiso.Text = "Piso";
            // 
            // labelCalle
            // 
            this.labelCalle.AutoSize = true;
            this.labelCalle.Location = new System.Drawing.Point(31, 29);
            this.labelCalle.Name = "labelCalle";
            this.labelCalle.Size = new System.Drawing.Size(30, 13);
            this.labelCalle.TabIndex = 24;
            this.labelCalle.Text = "Calle";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(53, 534);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(164, 23);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnRegistracion
            // 
            this.btnRegistracion.Location = new System.Drawing.Point(236, 534);
            this.btnRegistracion.Name = "btnRegistracion";
            this.btnRegistracion.Size = new System.Drawing.Size(182, 23);
            this.btnRegistracion.TabIndex = 31;
            this.btnRegistracion.Text = "Confirmar";
            this.btnRegistracion.UseVisualStyleBackColor = true;
            // 
            // labelInfoAsterizco
            // 
            this.labelInfoAsterizco.AutoSize = true;
            this.labelInfoAsterizco.Location = new System.Drawing.Point(50, 510);
            this.labelInfoAsterizco.Name = "labelInfoAsterizco";
            this.labelInfoAsterizco.Size = new System.Drawing.Size(180, 13);
            this.labelInfoAsterizco.TabIndex = 32;
            this.labelInfoAsterizco.Text = "( * )  Todos los datos son obligatorios";
            // 
            // label_Ingrese_datos
            // 
            this.label_Ingrese_datos.AutoSize = true;
            this.label_Ingrese_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ingrese_datos.Location = new System.Drawing.Point(12, 9);
            this.label_Ingrese_datos.Name = "label_Ingrese_datos";
            this.label_Ingrese_datos.Size = new System.Drawing.Size(226, 16);
            this.label_Ingrese_datos.TabIndex = 37;
            this.label_Ingrese_datos.Text = "Complete los datos solicitados:";
            // 
            // RegistroDeCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 588);
            this.Controls.Add(this.label_Ingrese_datos);
            this.Controls.Add(this.groupBox_Datos_de_usuario);
            this.Controls.Add(this.groupBoxDatosCliente);
            this.Controls.Add(this.groupBoxDomicilioCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistracion);
            this.Controls.Add(this.labelInfoAsterizco);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistroDeCliente";
            this.Text = "Nuevo cliente";
            this.Load += new System.EventHandler(this.RegistroDeCliente_Load);
            this.groupBox_Datos_de_usuario.ResumeLayout(false);
            this.groupBox_Datos_de_usuario.PerformLayout();
            this.groupBoxDatosCliente.ResumeLayout(false);
            this.groupBoxDatosCliente.PerformLayout();
            this.groupBoxDomicilioCliente.ResumeLayout(false);
            this.groupBoxDomicilioCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Datos_de_usuario;
        private System.Windows.Forms.TextBox textBox_Nombre_de_usuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox textBox_Contraseña;
        private System.Windows.Forms.ComboBox comboBox_Tipo_de_usuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox textBox_Telefono;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.GroupBox groupBoxDatosCliente;
        private System.Windows.Forms.ComboBox comboBox_Tipo_de_documento;
        private System.Windows.Forms.TextBox textBox_Numero_de_documento;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.TextBox textBox_Correo_electronico;
        private System.Windows.Forms.DateTimePicker dp_Fecha_de_nacimiento;
        private System.Windows.Forms.ComboBox comboBox_Sexo;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label labelFechaNacimiento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label labelSexo;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.GroupBox groupBoxDomicilioCliente;
        private System.Windows.Forms.TextBox textBox_Calle;
        private System.Windows.Forms.TextBox textBox_Piso;
        private System.Windows.Forms.TextBox textBox_Departamento;
        private System.Windows.Forms.TextBox textBox_Codigo_postal;
        private System.Windows.Forms.TextBox textBox_Localidad;
        private System.Windows.Forms.Label labelLocalidad;
        private System.Windows.Forms.Label labelCodPostal;
        private System.Windows.Forms.Label labelDepto;
        private System.Windows.Forms.Label labelPiso;
        private System.Windows.Forms.Label labelCalle;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistracion;
        private System.Windows.Forms.Label labelInfoAsterizco;
        private System.Windows.Forms.Label label_Ingrese_datos;

    }
}