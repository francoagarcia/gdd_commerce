namespace FrbaCommerce.Vistas.Abm_Cliente
{
    partial class ModificacionCliente
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
            this.tb_Nombre_de_usuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.tb_Contraseña = new System.Windows.Forms.TextBox();
            this.cb_Tipo_de_usuario = new System.Windows.Forms.ComboBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.tb_Telefono = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.groupBoxDatosCliente = new System.Windows.Forms.GroupBox();
            this.cb_Tipo_de_documento = new System.Windows.Forms.ComboBox();
            this.tb_Numero_de_documento = new System.Windows.Forms.TextBox();
            this.tb_Nombre = new System.Windows.Forms.TextBox();
            this.tb_Apellido = new System.Windows.Forms.TextBox();
            this.tb_Correo_electronico = new System.Windows.Forms.TextBox();
            this.dp_Fecha_de_nacimiento = new System.Windows.Forms.DateTimePicker();
            this.cb_Sexo = new System.Windows.Forms.ComboBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.labelFechaNacimiento = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.labelSexo = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.groupBoxDomicilioCliente = new System.Windows.Forms.GroupBox();
            this.tb_Calle = new System.Windows.Forms.TextBox();
            this.tb_Piso = new System.Windows.Forms.TextBox();
            this.tb_Departamento = new System.Windows.Forms.TextBox();
            this.tb_Codigo_postal = new System.Windows.Forms.TextBox();
            this.tb_Localidad = new System.Windows.Forms.TextBox();
            this.labelLocalidad = new System.Windows.Forms.Label();
            this.labelCodPostal = new System.Windows.Forms.Label();
            this.labelDepto = new System.Windows.Forms.Label();
            this.labelPiso = new System.Windows.Forms.Label();
            this.labelCalle = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.labelInfoAsterizco = new System.Windows.Forms.Label();
            this.label_Ingrese_datos = new System.Windows.Forms.Label();
            this.groupBox_Datos_de_usuario.SuspendLayout();
            this.groupBoxDatosCliente.SuspendLayout();
            this.groupBoxDomicilioCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Datos_de_usuario
            // 
            this.groupBox_Datos_de_usuario.Controls.Add(this.tb_Nombre_de_usuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblUsuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.tb_Contraseña);
            this.groupBox_Datos_de_usuario.Controls.Add(this.cb_Tipo_de_usuario);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblContraseña);
            this.groupBox_Datos_de_usuario.Controls.Add(this.tb_Telefono);
            this.groupBox_Datos_de_usuario.Controls.Add(this.labelTelefono);
            this.groupBox_Datos_de_usuario.Controls.Add(this.lblRol);
            this.groupBox_Datos_de_usuario.Location = new System.Drawing.Point(26, 32);
            this.groupBox_Datos_de_usuario.Name = "groupBox_Datos_de_usuario";
            this.groupBox_Datos_de_usuario.Size = new System.Drawing.Size(412, 125);
            this.groupBox_Datos_de_usuario.TabIndex = 36;
            this.groupBox_Datos_de_usuario.TabStop = false;
            this.groupBox_Datos_de_usuario.Text = "Datos de usuarios";
            // 
            // tb_Nombre_de_usuario
            // 
            this.tb_Nombre_de_usuario.Location = new System.Drawing.Point(161, 19);
            this.tb_Nombre_de_usuario.Name = "tb_Nombre_de_usuario";
            this.tb_Nombre_de_usuario.Size = new System.Drawing.Size(216, 20);
            this.tb_Nombre_de_usuario.TabIndex = 0;
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
            // tb_Contraseña
            // 
            this.tb_Contraseña.Location = new System.Drawing.Point(161, 45);
            this.tb_Contraseña.Name = "tb_Contraseña";
            this.tb_Contraseña.PasswordChar = '*';
            this.tb_Contraseña.Size = new System.Drawing.Size(216, 20);
            this.tb_Contraseña.TabIndex = 1;
            // 
            // cb_Tipo_de_usuario
            // 
            this.cb_Tipo_de_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_de_usuario.FormattingEnabled = true;
            this.cb_Tipo_de_usuario.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.cb_Tipo_de_usuario.Location = new System.Drawing.Point(161, 96);
            this.cb_Tipo_de_usuario.Name = "cb_Tipo_de_usuario";
            this.cb_Tipo_de_usuario.Size = new System.Drawing.Size(216, 21);
            this.cb_Tipo_de_usuario.TabIndex = 2;
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
            // tb_Telefono
            // 
            this.tb_Telefono.Location = new System.Drawing.Point(161, 70);
            this.tb_Telefono.Name = "tb_Telefono";
            this.tb_Telefono.Size = new System.Drawing.Size(216, 20);
            this.tb_Telefono.TabIndex = 27;
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
            this.groupBoxDatosCliente.Controls.Add(this.cb_Tipo_de_documento);
            this.groupBoxDatosCliente.Controls.Add(this.tb_Numero_de_documento);
            this.groupBoxDatosCliente.Controls.Add(this.tb_Nombre);
            this.groupBoxDatosCliente.Controls.Add(this.tb_Apellido);
            this.groupBoxDatosCliente.Controls.Add(this.tb_Correo_electronico);
            this.groupBoxDatosCliente.Controls.Add(this.dp_Fecha_de_nacimiento);
            this.groupBoxDatosCliente.Controls.Add(this.cb_Sexo);
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
            // cb_Tipo_de_documento
            // 
            this.cb_Tipo_de_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Tipo_de_documento.FormattingEnabled = true;
            this.cb_Tipo_de_documento.Location = new System.Drawing.Point(167, 24);
            this.cb_Tipo_de_documento.Name = "cb_Tipo_de_documento";
            this.cb_Tipo_de_documento.Size = new System.Drawing.Size(216, 21);
            this.cb_Tipo_de_documento.TabIndex = 29;
            // 
            // tb_Numero_de_documento
            // 
            this.tb_Numero_de_documento.Location = new System.Drawing.Point(167, 51);
            this.tb_Numero_de_documento.Name = "tb_Numero_de_documento";
            this.tb_Numero_de_documento.Size = new System.Drawing.Size(216, 20);
            this.tb_Numero_de_documento.TabIndex = 31;
            // 
            // tb_Nombre
            // 
            this.tb_Nombre.Location = new System.Drawing.Point(167, 77);
            this.tb_Nombre.Name = "tb_Nombre";
            this.tb_Nombre.Size = new System.Drawing.Size(216, 20);
            this.tb_Nombre.TabIndex = 35;
            // 
            // tb_Apellido
            // 
            this.tb_Apellido.Location = new System.Drawing.Point(167, 103);
            this.tb_Apellido.Name = "tb_Apellido";
            this.tb_Apellido.Size = new System.Drawing.Size(216, 20);
            this.tb_Apellido.TabIndex = 36;
            // 
            // tb_Correo_electronico
            // 
            this.tb_Correo_electronico.Location = new System.Drawing.Point(167, 129);
            this.tb_Correo_electronico.Name = "tb_Correo_electronico";
            this.tb_Correo_electronico.Size = new System.Drawing.Size(216, 20);
            this.tb_Correo_electronico.TabIndex = 40;
            // 
            // dp_Fecha_de_nacimiento
            // 
            this.dp_Fecha_de_nacimiento.Location = new System.Drawing.Point(167, 185);
            this.dp_Fecha_de_nacimiento.Name = "dp_Fecha_de_nacimiento";
            this.dp_Fecha_de_nacimiento.Size = new System.Drawing.Size(216, 20);
            this.dp_Fecha_de_nacimiento.TabIndex = 39;
            // 
            // cb_Sexo
            // 
            this.cb_Sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Sexo.FormattingEnabled = true;
            this.cb_Sexo.Location = new System.Drawing.Point(167, 155);
            this.cb_Sexo.Name = "cb_Sexo";
            this.cb_Sexo.Size = new System.Drawing.Size(216, 21);
            this.cb_Sexo.TabIndex = 37;
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
            this.groupBoxDomicilioCliente.Controls.Add(this.tb_Calle);
            this.groupBoxDomicilioCliente.Controls.Add(this.tb_Piso);
            this.groupBoxDomicilioCliente.Controls.Add(this.tb_Departamento);
            this.groupBoxDomicilioCliente.Controls.Add(this.tb_Codigo_postal);
            this.groupBoxDomicilioCliente.Controls.Add(this.tb_Localidad);
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
            // tb_Calle
            // 
            this.tb_Calle.Location = new System.Drawing.Point(67, 26);
            this.tb_Calle.Name = "tb_Calle";
            this.tb_Calle.Size = new System.Drawing.Size(318, 20);
            this.tb_Calle.TabIndex = 24;
            // 
            // tb_Piso
            // 
            this.tb_Piso.Location = new System.Drawing.Point(67, 52);
            this.tb_Piso.Name = "tb_Piso";
            this.tb_Piso.Size = new System.Drawing.Size(37, 20);
            this.tb_Piso.TabIndex = 25;
            // 
            // tb_Departamento
            // 
            this.tb_Departamento.Location = new System.Drawing.Point(190, 52);
            this.tb_Departamento.Name = "tb_Departamento";
            this.tb_Departamento.Size = new System.Drawing.Size(38, 20);
            this.tb_Departamento.TabIndex = 28;
            // 
            // tb_Codigo_postal
            // 
            this.tb_Codigo_postal.Location = new System.Drawing.Point(311, 52);
            this.tb_Codigo_postal.Name = "tb_Codigo_postal";
            this.tb_Codigo_postal.Size = new System.Drawing.Size(74, 20);
            this.tb_Codigo_postal.TabIndex = 30;
            // 
            // tb_Localidad
            // 
            this.tb_Localidad.Location = new System.Drawing.Point(89, 78);
            this.tb_Localidad.Name = "tb_Localidad";
            this.tb_Localidad.Size = new System.Drawing.Size(296, 20);
            this.tb_Localidad.TabIndex = 32;
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
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(53, 534);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(164, 23);
            this.btn_Cancelar.TabIndex = 33;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.Location = new System.Drawing.Point(236, 534);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(182, 23);
            this.btn_Confirmar.TabIndex = 31;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
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
            // ModificacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 588);
            this.Controls.Add(this.label_Ingrese_datos);
            this.Controls.Add(this.groupBox_Datos_de_usuario);
            this.Controls.Add(this.groupBoxDatosCliente);
            this.Controls.Add(this.groupBoxDomicilioCliente);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Confirmar);
            this.Controls.Add(this.labelInfoAsterizco);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificacionCliente";
            this.Text = "Nuevo cliente";
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
        private System.Windows.Forms.TextBox tb_Nombre_de_usuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox tb_Contraseña;
        private System.Windows.Forms.ComboBox cb_Tipo_de_usuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox tb_Telefono;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.GroupBox groupBoxDatosCliente;
        private System.Windows.Forms.ComboBox cb_Tipo_de_documento;
        private System.Windows.Forms.TextBox tb_Numero_de_documento;
        private System.Windows.Forms.TextBox tb_Nombre;
        private System.Windows.Forms.TextBox tb_Apellido;
        private System.Windows.Forms.TextBox tb_Correo_electronico;
        private System.Windows.Forms.DateTimePicker dp_Fecha_de_nacimiento;
        private System.Windows.Forms.ComboBox cb_Sexo;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label labelFechaNacimiento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label labelSexo;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.GroupBox groupBoxDomicilioCliente;
        private System.Windows.Forms.TextBox tb_Calle;
        private System.Windows.Forms.TextBox tb_Piso;
        private System.Windows.Forms.TextBox tb_Departamento;
        private System.Windows.Forms.TextBox tb_Codigo_postal;
        private System.Windows.Forms.TextBox tb_Localidad;
        private System.Windows.Forms.Label labelLocalidad;
        private System.Windows.Forms.Label labelCodPostal;
        private System.Windows.Forms.Label labelDepto;
        private System.Windows.Forms.Label labelPiso;
        private System.Windows.Forms.Label labelCalle;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Label labelInfoAsterizco;
        private System.Windows.Forms.Label label_Ingrese_datos;

    }
}