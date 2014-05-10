
-------------------------------------------------------------------------------------
---------------------------------CREANDO EL ESQUEMA----------------------------------
-------------------------------------------------------------------------------------
BEGIN TRANSACTION --Comienza transaccion

USE [GD1C2014]
GO

DECLARE @SchemaName AS VARCHAR(100) = 'PEPITO'
DECLARE @sql VARCHAR(100) = 'CREATE SCHEMA '+ @SchemaName +' AUTHORIZATION [gd]'

IF NOT EXISTS(SELECT name FROM sys.schemas WHERE name = @SchemaName)
	BEGIN
		PRINT 'Creating ' + @SchemaName + ' schema'
		EXEC(@sql)
		PRINT @SchemaName + ' schema created'
	END
ELSE
  PRINT @SchemaName + ' schema already exists.'
-------------------------------------------------------------------------------------
---------------------------------CREANDO LAS TABLAS----------------------------------
-------------------------------------------------------------------------------------

IF OBJECT_ID('PEPITO.Rol', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Rol;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Rol(
	id_rol NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	nombre varchar(255),
	habilitada bit DEFAULT 1, 
);



IF OBJECT_ID('PEPITO.Funcionalidad', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Funcionalidad;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Funcionalidad (
	id_funcionalidad NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	nombre varchar(255),
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.FuncionalidadXRol', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.FuncionalidadXRol;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.FuncionalidadXRol (
	id_rol NUMERIC(18,0) NOT NULL,
	id_funcionalidad NUMERIC(18,0) NOT NULL,
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.Usuario', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Usuario;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Usuario (
	id_usuario NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	username varchar(255),
	contrasenia varchar(255),
	telefono NUMERIC(18,0),
	intentos_login NUMERIC(1, 0) DEFAULT 0, 
	tipo_usario varchar(3), 
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.Administrador', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Administrador;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Administrador ( 
	id_usuario NUMERIC(18,0) NOT NULL, 
	nombre nvarchar(255),
	apellido nvarchar(255),
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.Cliente', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Cliente;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Cliente (
	id_usuario NUMERIC(18,0) NOT NULL,
	nombre nvarchar(255), 
	apellido nvarchar (255),
	tipo_documento varchar(255), 
	numero_documento NUMERIC(18,0),
	dom_calle nvarchar(255),
	nro_calle NUMERIC(18, 0),
	piso NUMERIC(18,0),      
	depto nvarchar(50),      
	localidad varchar(255),
	cod_postal nvarchar(50),
	mail nvarchar(255),
	fecha_nacimiento datetime,
	sexo bit DEFAULT NULL,
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.Empresa', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Empresa;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Empresa (
	id_usuario NUMERIC(18,0) NOT NULL, 
	razon_social nvarchar(255), 
	mail nvarchar(50),
	dom_calle nvarchar(255),
	piso NUMERIC(18,0) , 
	depto nvarchar(50),
	localidad nvarchar(255),
	nro_calle NUMERIC(18,0),
	cod_postal nvarchar(50),
	ciudad nvarchar(255),
	CUIT nvarchar(50),
	nombre_de_contacto nvarchar(255),
	fecha_creacion datetime,
);

IF OBJECT_ID('PEPITO.UsuarioXRol', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.UsuarioXRol;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.UsuarioXRol (
	id_usuario NUMERIC(18,0) NOT NULL, 
	id_rol NUMERIC(18,0) NOT NULL,
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.Rubro', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Rubro;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Rubro(
	id_rubro NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255),
);

IF OBJECT_ID('PEPITO.TipoPublicacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.TipoPublicacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.TipoPublicacion(
	id_tipo_publicacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255),
);

IF OBJECT_ID('PEPITO.VisibilidadPublicacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.VisibilidadPublicacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.VisibilidadPublicacion(
	id_visibilidad NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	descripcion nvarchar(255),
	precio NUMERIC(18, 2),
	porcentaje NUMERIC(18, 2),
);

IF OBJECT_ID('PEPITO.EstadoPublicacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.EstadoPublicacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.EstadoPublicacion(
	id_estado NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255),
);

IF OBJECT_ID('PEPITO.Calificacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Calificacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Calificacion(
	id_calificacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	cantidad_estrellas NUMERIC(18, 0),
	descripcion nvarchar(255),
);

IF OBJECT_ID('PEPITO.Publicacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Publicacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Publicacion(
	id_publicacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	descripcion nvarchar(255),
	stock NUMERIC(18,0),
	fecha_inicio datetime,
	fecha_vencimiento datetime,
	precio NUMERIC(18,2),
	id_tipo_publicacion NUMERIC(18,0),
	id_visibilidad NUMERIC(18,0), 
	id_estado NUMERIC(18,0), 
	id_usuario_publicador NUMERIC(18,0),
	habilitada bit DEFAULT 1,
);

IF OBJECT_ID('PEPITO.Pregunta', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Pregunta;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Pregunta(
	id_pregunta NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18,0),
	id_usuario NUMERIC(18, 0),
	pregunta nvarchar(255),
	fecha_pregunta datetime,
	respuesta nvarchar(400),
	fecha_respuesta datetime,
);

IF OBJECT_ID('PEPITO.CalificacionPublicacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.CalificacionPublicacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.CalificacionPublicacion(
	id_publicacion NUMERIC(18, 0) NOT NULL,
	id_usuario NUMERIC(18, 0) NOT NULL,
	id_calificacion NUMERIC(18, 0),
	detalle_calificacion nvarchar(255),
);

IF OBJECT_ID('PEPITO.Compra', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Compra;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Compra (
	id_compra NUMERIC(18, 0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18, 0),
	id_usuario_comprador NUMERIC(18, 0),
	fecha datetime,
	cantidad NUMERIC(18, 0),
);

IF OBJECT_ID('PEPITO.Oferta', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Oferta;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Oferta(
	id_oferta NUMERIC(18, 0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18, 0),
	id_usuario_ofertador NUMERIC(18, 0),
	fecha datetime,
	monto NUMERIC(18, 2),
);

IF OBJECT_ID('PEPITO.RubroXPublicacion', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.RubroXPublicacion;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.RubroXPublicacion(
	id_rubro NUMERIC(18, 0) NOT NULL, 
	id_publicacion NUMERIC(18, 0) NOT NULL, 
	habilitada bit DEFAULT 1,
);


IF OBJECT_ID('PEPITO.Factura', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.Factura;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.Factura(
	nro_factura NUMERIC(18, 0) NOT NULL,
	id_vendedor NUMERIC(18, 0),
	fecha datetime,
	total NUMERIC(18, 2),
	forma_pago_descripcion nvarchar(255),
);


IF OBJECT_ID('PEPITO.ItemFactura', 'U') IS NOT NULL 
	BEGIN
		DROP TABLE PEPITO.ItemFactura;
		PRINT 'Table already exists: DROP TABLE and CREATE again.'
	END
CREATE TABLE PEPITO.ItemFactura(
	nro_factura NUMERIC(18, 0) NOT NULL,
	id_publicacion NUMERIC(18, 0) NOT NULL,
	cantidad NUMERIC(18, 0),
	monto NUMERIC(18, 2),
);

-------------------------------------------------------------------------------------
----------------------------------CREANDO LAS PKS------------------------------------
-------------------------------------------------------------------------------------

ALTER TABLE PEPITO.Rol ADD CONSTRAINT pk_id_rol PRIMARY KEY ( id_rol );
ALTER TABLE PEPITO.Funcionalidad ADD CONSTRAINT pk_id_funcionalidad PRIMARY KEY ( id_funcionalidad );
ALTER TABLE PEPITO.FuncionalidadXRol ADD CONSTRAINT pk_funcionalidad_rol PRIMARY KEY ( id_rol,id_funcionalidad  );
ALTER TABLE PEPITO.Usuario ADD CONSTRAINT pk_id_usuario PRIMARY KEY ( id_usuario );
ALTER TABLE PEPITO.Administrador ADD CONSTRAINT pk_id_administrador PRIMARY KEY ( id_usuario );
ALTER TABLE PEPITO.Cliente ADD CONSTRAINT pk_id_cliente PRIMARY KEY ( id_usuario );
ALTER TABLE PEPITO.Empresa ADD CONSTRAINT pk_id_empresa PRIMARY KEY ( id_usuario );
ALTER TABLE PEPITO.UsuarioXRol ADD CONSTRAINT pk_usuario_rol PRIMARY KEY ( id_usuario,id_rol );
ALTER TABLE PEPITO.Rubro ADD CONSTRAINT pk_id_rubro PRIMARY KEY ( id_rubro );
ALTER TABLE PEPITO.RubroXPublicacion ADD CONSTRAINT pk_rubro_publicacion PRIMARY KEY ( id_rubro, id_publicacion );
ALTER TABLE PEPITO.TipoPublicacion ADD CONSTRAINT pk_id_tipo_publicacion PRIMARY KEY ( id_tipo_publicacion );
ALTER TABLE PEPITO.VisibilidadPublicacion ADD CONSTRAINT pk_id_visibilidad PRIMARY KEY ( id_visibilidad );
ALTER TABLE PEPITO.EstadoPublicacion ADD CONSTRAINT pk_id_estado PRIMARY KEY ( id_estado );
ALTER TABLE PEPITO.Calificacion ADD CONSTRAINT pk_id_calificacion PRIMARY KEY ( id_calificacion );
ALTER TABLE PEPITO.Publicacion ADD CONSTRAINT pk_id_publicacion PRIMARY KEY ( id_publicacion );
ALTER TABLE PEPITO.Pregunta ADD CONSTRAINT pk_id_pregunta PRIMARY KEY ( id_pregunta );
ALTER TABLE PEPITO.Compra ADD CONSTRAINT pk_id_compra PRIMARY KEY (id_compra);
ALTER TABLE PEPITO.Oferta ADD CONSTRAINT pk_id_oferta PRIMARY KEY (id_oferta);
ALTER TABLE PEPITO.CalificacionPublicacion ADD CONSTRAINT pk_id_calificacion_publicacion PRIMARY KEY(id_publicacion);
ALTER TABLE PEPITO.Factura ADD CONSTRAINT pk_nro_factura PRIMARY KEY (nro_factura);
ALTER TABLE PEPITO.ItemFactura ADD CONSTRAINT pk_item_factura PRIMARY KEY (nro_factura, id_publicacion);


-------------------------------------------------------------------------------------
----------------------------------CREANDO LAS FKS------------------------------------
-------------------------------------------------------------------------------------

--Roles, funcionalidades, usuarios
ALTER TABLE PEPITO.FuncionalidadXRol ADD CONSTRAINT fk_FuncionalidadXRol_to_Funcionalidad
FOREIGN KEY (id_funcionalidad) REFERENCES PEPITO.Funcionalidad (id_funcionalidad);

ALTER TABLE PEPITO.FuncionalidadXRol ADD CONSTRAINT fk_FuncionalidadXRol_to_Rol
FOREIGN KEY (id_rol) REFERENCES PEPITO.Rol (id_rol);

ALTER TABLE PEPITO.Administrador ADD CONSTRAINT fk_Administrador_to_Usuario
FOREIGN KEY (id_usuario) REFERENCES PEPITO.Usuario (id_usuario);

ALTER TABLE PEPITO.Cliente ADD CONSTRAINT fk_Cliente_to_Usuario
FOREIGN KEY (id_usuario) REFERENCES PEPITO.Usuario (id_usuario);

ALTER TABLE PEPITO.Empresa ADD CONSTRAINT fk_Empresa_to_Usuario
FOREIGN KEY (id_usuario) REFERENCES PEPITO.Usuario (id_usuario);

ALTER TABLE PEPITO.UsuarioXRol ADD CONSTRAINT fk_UsuarioXRol_to_Usuario
FOREIGN KEY (id_usuario) REFERENCES PEPITO.Usuario (id_usuario);

ALTER TABLE PEPITO.UsuarioXRol ADD CONSTRAINT fk_UsuarioXRol_to_Rol
FOREIGN KEY (id_rol) REFERENCES PEPITO.Rol (id_rol);

--Publicacoin
ALTER TABLE PEPITO.Publicacion ADD CONSTRAINT fk_Publicacion_to_TipoPublicacion
FOREIGN KEY (id_tipo_publicacion) REFERENCES PEPITO.TipoPublicacion (id_tipo_publicacion);

ALTER TABLE PEPITO.Publicacion ADD CONSTRAINT fk_Publicacion_to_EstadoPublicacion
FOREIGN KEY (id_estado) REFERENCES PEPITO.EstadoPublicacion (id_estado);

ALTER TABLE PEPITO.Publicacion ADD CONSTRAINT fk_Publicacion_to_VisibilidadPublicacion
FOREIGN KEY (id_visibilidad) REFERENCES PEPITO.VisibilidadPublicacion (id_visibilidad);

ALTER TABLE PEPITO.Publicacion ADD CONSTRAINT fk_Publicacion_to_Usuario
FOREIGN KEY (id_usuario_publicador) REFERENCES PEPITO.Usuario (id_usuario);

--Rubro x publicacion
ALTER TABLE PEPITO.RubroXPublicacion ADD CONSTRAINT fk_RubroXPublicacion_to_Rubro
FOREIGN KEY (id_rubro) REFERENCES PEPITO.Rubro (id_rubro);

ALTER TABLE PEPITO.RubroXPublicacion ADD CONSTRAINT fk_RubroXPublicacion_to_Publicacion
FOREIGN KEY (id_publicacion) REFERENCES PEPITO.Publicacion (id_publicacion);

--Preguntas
ALTER TABLE PEPITO.Pregunta ADD CONSTRAINT fk_Pregunta_to_Publicacion
FOREIGN KEY (id_publicacion) REFERENCES PEPITO.Publicacion (id_publicacion);

ALTER TABLE PEPITO.Pregunta ADD CONSTRAINT fk_Pregunta_to_Usuario
FOREIGN KEY (id_usuario) REFERENCES PEPITO.Usuario (id_usuario);

--Compra
ALTER TABLE PEPITO.Compra ADD CONSTRAINT fk_Compra_to_Publicacion 
FOREIGN KEY (id_publicacion) REFERENCES PEPITO.Publicacion (id_publicacion);

ALTER TABLE PEPITO.Compra ADD CONSTRAINT fk_Compra_to_Usuario 
FOREIGN KEY (id_usuario_comprador) REFERENCES PEPITO.Usuario (id_usuario);

--CalificacionPublicacion
ALTER TABLE PEPITO.CalificacionPublicacion ADD CONSTRAINT fk_CalificacionPublicacion_to_Publicacion 
FOREIGN KEY (id_publicacion) REFERENCES PEPITO.Publicacion (id_publicacion);

ALTER TABLE PEPITO.CalificacionPublicacion  ADD CONSTRAINT fk_CalificacionPublicacion_to_Usuario 
FOREIGN KEY (id_usuario) REFERENCES PEPITO.Usuario (id_usuario);

ALTER TABLE PEPITO.CalificacionPublicacion  ADD CONSTRAINT fk_CalificacionPublicacion_to_Calificacion 
FOREIGN KEY (id_calificacion) REFERENCES PEPITO.Calificacion (id_calificacion);

--Oferta
ALTER TABLE PEPITO.Oferta ADD CONSTRAINT fk_Oferta_to_Publicacion 
FOREIGN KEY (id_publicacion) REFERENCES PEPITO.Publicacion (id_publicacion);

ALTER TABLE PEPITO.Oferta ADD CONSTRAINT fk_Oferta_to_Usuario 
FOREIGN KEY (id_usuario_ofertador) REFERENCES PEPITO.Usuario (id_usuario);

--Facturas
ALTER TABLE PEPITO.Factura ADD CONSTRAINT fk_Factura_to_Usuario 
FOREIGN KEY (id_vendedor) REFERENCES PEPITO.Usuario (id_usuario);

ALTER TABLE PEPITO.ItemFactura ADD CONSTRAINT fk_ItemFactura_to_Publicacion 
FOREIGN KEY (id_publicacion) REFERENCES PEPITO.Publicacion ( id_publicacion );

ALTER TABLE PEPITO.ItemFactura ADD CONSTRAINT fk_ItemFactura_to_Factura 
FOREIGN KEY (nro_factura) REFERENCES PEPITO.Factura ( nro_factura );


--Completo la transaccion
COMMIT