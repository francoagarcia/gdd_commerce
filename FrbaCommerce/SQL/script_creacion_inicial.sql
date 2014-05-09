/* 
****************************************************************************************************
**********************************************NOTA**************************************************
****************************************************************************************************

	1) Me falta crear las tablas Factura e Item_factura pero estoy averiguando bien como hacerlo porque me queda dudas todavia
	  con respecto a la forma de pago y no quiero crear las tablas hasta que esten bien
	2) Le puse el nombre PEPITO al esquema por ahora, porque no sabia que ponerle, creo que se le ponia el nombre del grupo o algo asi
	3) En el DER que genera el SQL MANAGEMENT las "llaves" son relacion de a 1, y los "rombos" son de muchos

*/

-------------------------------------------------------------------------------------
---------------------------------CREANDO EL ESQUEMA----------------------------------
-------------------------------------------------------------------------------------
BEGIN TRANSACTION --Comienza transaccion

USE [GD1C2014]
GO
CREATE SCHEMA [PEPITO] AUTHORIZATION [gd]
GO

-------------------------------------------------------------------------------------
---------------------------------CREANDO LAS TABLAS----------------------------------
-------------------------------------------------------------------------------------

CREATE TABLE PEPITO.Rol(
	id_rol NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --IDENTITY(valor 1° fila, increment) para hacer que sea auto-increment
	nombre varchar(255),
	habilitada bit DEFAULT 1, --Por default esta habilitada
);

CREATE TABLE PEPITO.Funcionalidad (
	id_funcionalidad NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	nombre varchar(255),
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.FuncionalidadXRol (
	id_rol NUMERIC(18,0) NOT NULL,
	id_funcionalidad NUMERIC(18,0) NOT NULL,
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.Usuario (
	id_usuario NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	username varchar(255),
	contrasenia varchar(255),
	telefono NUMERIC(18,0),
	intentos_login NUMERIC(1, 0) DEFAULT 0, --Lo pongo aqui nomas al contador de intentos
	tipo_usario varchar(3), --Cli, adm, o emp, 
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.Administrador ( --TODO ver que mas poner aqui
	id_usuario NUMERIC(18,0) NOT NULL, --FK de usuario
	nombre nvarchar(255),
	apellido nvarchar(255),
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.Cliente (
	id_usuario NUMERIC(18,0) NOT NULL, --FK usuario && PK cliente
	nombre nvarchar(255), --En la tabla MAESTRA dice tipo de dato nvarchar, no varchar
	apellido nvarchar (255),
	tipo_documento varchar(255), --Tal vez pueda crear una tabla "Tipo documento" y aqui poner la clave
	numero_documento NUMERIC(18,0),
	dom_calle nvarchar(255), --Nombre de calle ---> NORMALIZAR LAS DIRECCIONES ?
	piso NUMERIC(18,0),      --Piso del dpto
	depto nvarchar(50),      --Numeracion del Depto
	localidad varchar(255),
	nro_calle NUMERIC(18,0), --Este campo esta en la tabla MAESTRA pero no veo para que dejarlo, es al dope me parece
	cod_postal nvarchar(50),
	mail nvarchar(255), --Tiene distinto tipo de datos que el usuario EMPRESA
	fecha_nacimiento datetime,
	sexo bit DEFAULT NULL,
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.Empresa (
	id_usuario NUMERIC(18,0) NOT NULL, --FK usuario && PK cliente
	razon_social nvarchar(255), --En la tabla MAESTRA dice tipo de dato nvarchar, no varchar
	mail nvarchar(50), --Tiene distinto tipo de datos que el usuario EMPRESA
	dom_calle nvarchar(255),
	piso NUMERIC(18,0) , 
	depto nvarchar(50),
	localidad nvarchar(255),
	nro_calle NUMERIC(18,0), --Este campo esta en la tabla MAESTRA pero no veo para que dejarlo, es al dope me parece
	cod_postal nvarchar(50),
	ciudad nvarchar(255),
	CUIT nvarchar(50),
	nombre_de_contacto nvarchar(255),
	fecha_creacion datetime,
);

CREATE TABLE PEPITO.UsuarioXRol (
	id_usuario NUMERIC(18,0) NOT NULL, --PK compuesta: id_usuario&&id_rol --Ademas estas dos son FK de su tabla correspondiente
	id_rol NUMERIC(18,0) NOT NULL, --PK
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.Rubro( --TODO agregar esto a publicacion, relaciond e muchos a muchos
	id_rubro NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --PK
	descripcion nvarchar(255),
);

CREATE TABLE PEPITO.TipoPublicacion(
	id_tipo_publicacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --PK
	descripcion nvarchar(255),
);

CREATE TABLE PEPITO.VisibilidadPublicacion(
	id_visibilidad NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --PK
	descripcion nvarchar(255),
	precio NUMERIC(18, 2),
	porcentaje NUMERIC(18, 2),
);

CREATE TABLE PEPITO.EstadoPublicacion(
	id_estado NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --PK
	descripcion nvarchar(255),
);

CREATE TABLE PEPITO.Calificacion(
	id_calificacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL, --PK
	cantidad_estrellas NUMERIC(18, 0),
	descripcion nvarchar(255),
);

CREATE TABLE PEPITO.Publicacion(
	id_publicacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	descripcion nvarchar(255),
	stock NUMERIC(18,0),
	fecha_inicio datetime,
	fecha_vencimiento datetime,
	precio NUMERIC(18,2),
	id_tipo_publicacion NUMERIC(18,0), --FK
	id_visibilidad NUMERIC(18,0), --FK
	id_estado NUMERIC(18,0), --FK
	id_usuario_publicador NUMERIC(18,0),
	habilitada bit DEFAULT 1,
);

CREATE TABLE PEPITO.Pregunta(
	id_pregunta NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18,0), --FK
	id_usuario NUMERIC(18, 0), --FK: Usuario que pregunta
	pregunta nvarchar(255),
	respuesta nvarchar(400),
);

--TODO guardarme tambien las OFERTAS
CREATE TABLE PEPITO.Compra( --PK compuesta por:	id_publicacion&&id_usuario_comprador => ademas son FK de sus tablas
	id_compra NUMERIC(18,0) NOT NULL, --PK
	id_publicacion NUMERIC(18,0), --FK
	id_usuario_comprador NUMERIC(18,0), --FK
	id_calificacion NUMERIC(18,0), --FK
	detalle_calificacion nvarchar(255),
	fecha datetime,
	cantidad numeric(18, 0),
);

CREATE TABLE PEPITO.RubroXPublicacion(
	id_rubro NUMERIC(18, 0) NOT NULL, --PK && FK
	id_publicacion NUMERIC(18, 0) NOT NULL, --PK && FK
	habilitada bit DEFAULT 1,
);
/*
CREATE TABLE PEPITO.Factura(
nro_factura NUMERIC(18,0) NOT NULL,
fecha,
total,
vendedor,
);

CREATE TABLE PEPITO.ItemFactura(

);
*/

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
ALTER TABLE PEPITO.Compra ADD CONSTRAINT pk_publicacion_comprador PRIMARY KEY ( id_compra );

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

ALTER TABLE PEPITO.Compra ADD CONSTRAINT fk_Compra_to_Calificacion
FOREIGN KEY (id_calificacion) REFERENCES PEPITO.Calificacion (id_calificacion);

--Completo la transaccion
COMMIT
















