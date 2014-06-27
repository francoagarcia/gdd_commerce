
-------------------------------------------------------------------------------------
---------------------------------CREANDO EL ESQUEMA----------------------------------
-------------------------------------------------------------------------------------
USE [GD1C2014]
GO

CREATE SCHEMA [DATA_GROUP] AUTHORIZATION [gd]
GO

-------------------------------------------------------------------------------------
---------------------------------CREANDO LAS TABLAS----------------------------------
-------------------------------------------------------------------------------------

CREATE TABLE DATA_GROUP.Funcionalidad (
	id_funcionalidad NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	nombre nvarchar(255) NOT NULL,
	habilitada bit DEFAULT 1 NOT NULL,
	CONSTRAINT pk_id_funcionalidad PRIMARY KEY ( id_funcionalidad )
)
GO

CREATE TABLE DATA_GROUP.Rol(
	id_rol NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	nombre nvarchar(255) NOT NULL,
	habilitada bit DEFAULT 1 NOT NULL,
	CONSTRAINT pk_id_rol PRIMARY KEY ( id_rol )
)
GO

CREATE TABLE DATA_GROUP.FuncionalidadXRol (
	id_rol NUMERIC(18,0) NOT NULL,
	id_funcionalidad NUMERIC(18,0) NOT NULL,
	habilitada bit DEFAULT 1 NOT NULL,
	CONSTRAINT pk_funcionalidad_rol PRIMARY KEY ( id_rol, id_funcionalidad ),
	CONSTRAINT fk_FuncionalidadXRol_to_Funcionalidad FOREIGN KEY (id_funcionalidad) 
	REFERENCES DATA_GROUP.Funcionalidad (id_funcionalidad),
	CONSTRAINT fk_FuncionalidadXRol_to_Rol
	FOREIGN KEY (id_rol) REFERENCES DATA_GROUP.Rol (id_rol)
)
GO

CREATE TABLE DATA_GROUP.Usuario (
	id_usuario NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	username nvarchar(255) NOT NULL UNIQUE,
	contrasenia nvarchar(255) NOT NULL,
	telefono numeric(18,0),
	intentos_login int DEFAULT 0 NOT NULL, 
	tipo_usuario nvarchar(3), 
	habilitada bit DEFAULT 1,
	habilitada_comprar bit DEFAULT 1,
	CONSTRAINT pk_id_usuario PRIMARY KEY ( id_usuario )
)
GO

CREATE TABLE DATA_GROUP.UsuarioXRol (
	id_usuario NUMERIC(18,0) NOT NULL, 
	id_rol NUMERIC(18,0) NOT NULL,
	habilitada bit DEFAULT 1 NOT NULL,
	CONSTRAINT pk_usuario_rol PRIMARY KEY ( id_usuario,id_rol ),
	CONSTRAINT fk_UsuarioXRol_to_Usuario FOREIGN KEY (id_usuario) 
	REFERENCES DATA_GROUP.Usuario (id_usuario),
	CONSTRAINT fk_UsuarioXRol_to_Rol FOREIGN KEY (id_rol) 
	REFERENCES DATA_GROUP.Rol (id_rol)
)
GO

CREATE TABLE DATA_GROUP.TipoDocumento (
	id_tipo_documento NUMERIC(18, 0) IDENTITY (1,1) NOT NULL,
	descripcion nvarchar(255) NOT NULL,
	CONSTRAINT pk_tipo_documento PRIMARY KEY (id_tipo_documento)
)
GO


CREATE TABLE DATA_GROUP.Administrador ( 
	id_administrador NUMERIC(18, 0) IDENTITY(1,1) NOT NULL,
	id_usuario NUMERIC(18,0) NOT NULL, 
	habilitada bit DEFAULT 1 NOT NULL,
	CONSTRAINT pk_id_administrador PRIMARY KEY ( id_usuario ),
	CONSTRAINT fk_Administrador_to_Usuario
	FOREIGN KEY (id_usuario) REFERENCES DATA_GROUP.Usuario (id_usuario)
)
GO

CREATE TABLE DATA_GROUP.Cliente (
	id_tipo_documento NUMERIC(18, 0) NOT NULL,
	nro_documento nvarchar(50) NOT NULL,
	id_usuario NUMERIC(18,0),
	nombre nvarchar(255), 
	apellido nvarchar (255),
	dom_calle nvarchar(255),
	nro_calle NUMERIC(18, 0),
	piso NUMERIC(18,0),      
	depto nvarchar(50),      
	localidad nvarchar(255),
	cod_postal nvarchar(50),
	mail nvarchar(255),
	fecha_nacimiento datetime,
	sexo int DEFAULT 2,
	CONSTRAINT pk_id_cliente PRIMARY KEY ( id_tipo_documento, nro_documento ),
	CONSTRAINT fk_Cliente_to_Usuario FOREIGN KEY (id_usuario) 
	REFERENCES DATA_GROUP.Usuario (id_usuario),
	CONSTRAINT fk_Cliente_to_TipoDocumento FOREIGN KEY (id_tipo_documento) 
	REFERENCES DATA_GROUP.TipoDocumento(id_tipo_documento)
)
GO

CREATE TABLE DATA_GROUP.Empresa (
	cuit nvarchar(50) NOT NULL,
	razon_social nvarchar(255) NOT NULL, 
	id_usuario NUMERIC(18,0), 
	mail nvarchar(50),
	dom_calle nvarchar(255),
	piso NUMERIC(18,0) , 
	depto nvarchar(50),
	localidad nvarchar(255),
	nro_calle NUMERIC(18,0),
	cod_postal nvarchar(50),
	ciudad nvarchar(255),
	nombre_de_contacto nvarchar(255),
	fecha_creacion datetime,
	CONSTRAINT pk_id_empresa PRIMARY KEY ( cuit, razon_social ),
	CONSTRAINT fk_Empresa_to_Usuario
	FOREIGN KEY (id_usuario) REFERENCES DATA_GROUP.Usuario (id_usuario)
)
GO

CREATE TABLE DATA_GROUP.Rubro(
	id_rubro NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255) NOT NULL,
	CONSTRAINT pk_id_rubro PRIMARY KEY ( id_rubro )
)
GO

CREATE TABLE DATA_GROUP.TipoPublicacion(
	id_tipo_publicacion NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255) NOT NULL,
	CONSTRAINT pk_id_tipo_publicacion PRIMARY KEY ( id_tipo_publicacion )
)
GO

CREATE TABLE DATA_GROUP.VisibilidadPublicacion(
	id_visibilidad NUMERIC(18,0) NOT NULL,
	descripcion nvarchar(255) NOT NULL UNIQUE,
	precio NUMERIC(18, 2) NOT NULL,
	porcentaje NUMERIC(18, 2) NOT NULL,
	dias_vencimiento_publi NUMERIC(18, 0) NOT NULL,
	habilitada bit DEFAULT 1,
	CONSTRAINT pk_id_visibilidad PRIMARY KEY ( id_visibilidad )
)
GO

CREATE TABLE DATA_GROUP.EstadoPublicacion(
	id_estado NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255) NOT NULL,
	CONSTRAINT pk_id_estado PRIMARY KEY ( id_estado )
)
GO

CREATE TABLE DATA_GROUP.FormaDePago(
	id_forma_pago NUMERIC(18,0) IDENTITY(1,1) NOT NULL, 
	descripcion nvarchar(255) NOT NULL,
	CONSTRAINT pk_id_forma_pago PRIMARY KEY ( id_forma_pago )
)
GO

CREATE TABLE DATA_GROUP.Publicacion(
	id_publicacion NUMERIC(18,0) NOT NULL,
	descripcion nvarchar(255),
	stock NUMERIC(18,0),
	fecha_inicio datetime,
	fecha_vencimiento datetime,
	precio NUMERIC(18,2),
	permite_preguntas bit DEFAULT 1 NOT NULL,
	id_tipo_publicacion NUMERIC(18,0) NOT NULL,
	id_visibilidad NUMERIC(18,0) NOT NULL, 
	id_estado NUMERIC(18,0) NOT NULL, 
	id_usuario_publicador NUMERIC(18,0) NOT NULL,
	id_rubro NUMERIC(18, 0),
	facturada bit DEFAULT 1,
	habilitada bit DEFAULT 1 NOT NULL,
	CONSTRAINT pk_id_publicacion PRIMARY KEY ( id_publicacion ),
	CONSTRAINT fk_Publicacion_to_TipoPublicacion
	FOREIGN KEY (id_tipo_publicacion) REFERENCES DATA_GROUP.TipoPublicacion (id_tipo_publicacion),
	CONSTRAINT fk_Publicacion_to_EstadoPublicacion FOREIGN KEY (id_estado) 
	REFERENCES DATA_GROUP.EstadoPublicacion (id_estado),
	CONSTRAINT fk_Publicacion_to_VisibilidadPublicacion FOREIGN KEY (id_visibilidad) 
	REFERENCES DATA_GROUP.VisibilidadPublicacion (id_visibilidad),
	CONSTRAINT fk_Publicacion_to_Usuario FOREIGN KEY (id_usuario_publicador) 
	REFERENCES DATA_GROUP.Usuario (id_usuario),
	CONSTRAINT fk_Publicacion_to_Rubro FOREIGN KEY (id_rubro) 
	REFERENCES DATA_GROUP.Rubro (id_rubro)
)
GO

CREATE TABLE DATA_GROUP.CalificacionPublicacion(
	id_calificacion NUMERIC(18, 0) NOT NULL,
	estrellas_calificacion NUMERIC(18, 0),
	detalle_calificacion nvarchar(255),
	CONSTRAINT pk_id_calificacion_publicacion PRIMARY KEY(id_calificacion)
)
GO

CREATE TABLE DATA_GROUP.Compra (
	id_compra NUMERIC(18, 0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18, 0) NOT NULL,
	id_usuario_comprador NUMERIC(18, 0) NOT NULL,
	id_calificacion NUMERIC(18, 0),
	fecha datetime NOT NULL,
	cantidad NUMERIC(18, 0) NOT NULL,
	facturada bit DEFAULT 1, --1 es facturada, 0 no facturada
	comision numeric(18,2) NOT NULL DEFAULT 0,
	CONSTRAINT pk_id_compra PRIMARY KEY (id_compra),
	CONSTRAINT fk_Compra_to_Publicacion FOREIGN KEY (id_publicacion) 
	REFERENCES DATA_GROUP.Publicacion (id_publicacion),
	CONSTRAINT fk_Compra_to_Usuario FOREIGN KEY (id_usuario_comprador) 
	REFERENCES DATA_GROUP.Usuario (id_usuario),
	CONSTRAINT fk_Compra_to_CalificacionPublicacion FOREIGN KEY (id_calificacion) 
	REFERENCES DATA_GROUP.CalificacionPublicacion (id_calificacion)
)
GO

CREATE TABLE DATA_GROUP.Oferta(
	id_oferta NUMERIC(18, 0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18, 0) NOT NULL,
	id_usuario_ofertador NUMERIC(18, 0) NOT NULL,
	fecha datetime NOT NULL,
	monto NUMERIC(18, 2) NOT NULL,
	CONSTRAINT pk_id_oferta PRIMARY KEY (id_oferta),
	CONSTRAINT fk_Oferta_to_Publicacion FOREIGN KEY (id_publicacion) 
	REFERENCES DATA_GROUP.Publicacion (id_publicacion),
	CONSTRAINT fk_Oferta_to_Usuario FOREIGN KEY (id_usuario_ofertador) 
	REFERENCES DATA_GROUP.Usuario (id_usuario)
)
GO

CREATE TABLE DATA_GROUP.Factura(
	nro_factura NUMERIC(18, 0) NOT NULL,
	id_vendedor NUMERIC(18, 0) NOT NULL,
	fecha datetime NOT NULL,
	total NUMERIC(18, 2) NOT NULL,
	id_forma_pago Numeric(18, 0) NOT NULL,
	forma_pago_datos nvarchar(255) NOT NULL,
	CONSTRAINT pk_nro_factura PRIMARY KEY (nro_factura),
	CONSTRAINT fk_Factura_to_Usuario FOREIGN KEY (id_vendedor) 
	REFERENCES DATA_GROUP.Usuario (id_usuario),
	CONSTRAINT fk_Factura_to_FormaDePago FOREIGN KEY (id_forma_pago) 
	REFERENCES DATA_GROUP.FormaDePago (id_forma_pago)
)
GO

CREATE TABLE DATA_GROUP.ItemFactura(
	nro_factura NUMERIC(18, 0) NOT NULL,
	id_publicacion NUMERIC(18, 0) NOT NULL,
	id_compra NUMERIC(18, 0) NOT NULL,
	cantidad NUMERIC(18, 0) NOT NULL,
	monto NUMERIC(18, 2) NOT NULL,
	resumen nvarchar(255),
	CONSTRAINT fk_ItemFactura_to_Publicacion FOREIGN KEY (id_publicacion) 
	REFERENCES DATA_GROUP.Publicacion ( id_publicacion ),
	CONSTRAINT fk_ItemFactura_to_Factura FOREIGN KEY (nro_factura) 
	REFERENCES DATA_GROUP.Factura ( nro_factura )
)
GO

CREATE TABLE DATA_GROUP.Pregunta(
	id_pregunta NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
	id_publicacion NUMERIC(18,0) NOT NULL,
	id_usuario NUMERIC(18, 0) NOT NULL,
	pregunta nvarchar(255),
	fecha_pregunta datetime,
	respuesta nvarchar(400),
	fecha_respuesta datetime,
	CONSTRAINT pk_id_pregunta PRIMARY KEY ( id_pregunta ),
	CONSTRAINT fk_Pregunta_to_Publicacion FOREIGN KEY (id_publicacion) 
	REFERENCES DATA_GROUP.Publicacion (id_publicacion),
	CONSTRAINT fk_Pregunta_to_Usuario FOREIGN KEY (id_usuario) 
	REFERENCES DATA_GROUP.Usuario (id_usuario)
)
GO

CREATE TABLE DATA_GROUP.CantVisibilidadesFacturadasPorUsuario (
	id_visibilidad_fact NUMERIC(18,0),
	id_usuario_fact NUMERIC(18,0),
	cantidad_fact NUMERIC(18,0),
	CONSTRAINT fk_CantVisibilidadesFacturadasPorUsuario_to_VisibilidadPublicacion
	FOREIGN KEY (id_visibilidad_fact) REFERENCES DATA_GROUP.VisibilidadPublicacion ( id_visibilidad ),
	CONSTRAINT fk_CantVisibilidadesFacturadasPorUsuario_to_Usuario 
	FOREIGN KEY (id_usuario_fact) REFERENCES DATA_GROUP.Usuario ( id_usuario )
)
GO

-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
------------------------------------MIGRACION----------------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------


--------------------------------------------------------
----------------------FormaDePago-----------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.FormaDePago(descripcion)
VALUES ('Contado'), ('Tarjeta de credito')
GO

--------------------------------------------------------
----------------------TipoDocumento---------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.TipoDocumento(descripcion)
VALUES ('DNI'), ('LC'), ('LE'), ('CUIT')
GO

--------------------------------------------------------
--------------------EstadoPublicacion-------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.EstadoPublicacion(descripcion)
VALUES ('Publicada'),('Borrador'),('Pausada'),('Finalizada')
GO

--------------------------------------------------------
------------------VisibilidadPublicacion----------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.VisibilidadPublicacion(id_visibilidad, descripcion, precio, porcentaje, dias_vencimiento_publi)
SELECT DISTINCT Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje, 7
FROM gd_esquema.Maestra
GO

--------------------------------------------------------
------------------------Rol-----------------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.Rol(nombre)
VALUES ('Administrador General'),('Cliente'),('Empresa')
GO

--------------------------------------------------------
----------------------Funcionalidad---------------------
--------------------------------------------------------

INSERT INTO DATA_GROUP.Funcionalidad(nombre)
VALUES  ('ABM de Rol'), --1
		('Registro de Usuario'), --2
		('ABM de Cliente'), --3
		('ABM de Empresa'), --4
		('ABM de Rubro'), --5
	    ('ABM de Visibilidad de Publicacion'), --6
		('Nueva Publicacion'), --7
		('Editar Publicacion'), --8
	    ('Gestion de Preguntas'), --9
		('Comprar/Ofertar'), --10
		('Historial de Operaciones'), --11
		('Calificar al Vendedor'), --12
	    ('Facturar Publicaciones'), --13
		('Listado Estadistico') --14
GO
	   
--------------------------------------------------------
-------------------FuncionalidadXRol--------------------
--------------------------------------------------------
--Rol Administrador General
INSERT INTO DATA_GROUP.FuncionalidadXRol(id_rol, id_funcionalidad)
VALUES (1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8), (1,9), (1,10), (1,11), (1,12), (1,13), (1, 14)
GO
--Rol Cliente
INSERT INTO DATA_GROUP.FuncionalidadXRol(id_rol, id_funcionalidad)
VALUES (2,7), (2,8), (2,9), (2,10), (2,11), (2, 12), (2, 14)
GO
--Rol Empresa
INSERT INTO DATA_GROUP.FuncionalidadXRol(id_rol, id_funcionalidad)
VALUES  (3,7), (3,8), (3,9), (3, 11), (3, 14)
GO
--------------------------------------------------------
------------------------Rubro---------------------------
--------------------------------------------------------

INSERT INTO DATA_GROUP.Rubro(descripcion)
SELECT DISTINCT Publicacion_Rubro_Descripcion
FROM gd_esquema.Maestra
GO

--------------------------------------------------------
---------------------TipoPublicacion--------------------
--------------------------------------------------------

INSERT INTO DATA_GROUP.TipoPublicacion(descripcion)
VALUES ('Compra inmediata'), ('Subasta')
GO

--------------------------------------------------------
-------------------------Usuarios-----------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.Usuario(username, contrasenia, tipo_usuario)	--pass_cli_migrados
SELECT DISTINCT LTRIM(RTRIM(CONVERT(nvarchar(255), Publ_Cli_Dni))), 'b34d9e1f824369575b069ae374f616b5e8e50b248cfb1a9fb19ec9a7a119ce5b', 'CLI'
FROM gd_esquema.Maestra
WHERE Publ_Cli_Dni IS NOT NULL
UNION																		--pass: pass_emp_migrados
SELECT DISTINCT LTRIM(RTRIM(CONVERT(nvarchar(255), Publ_Empresa_Cuit))), 'ef9e14d5e625e301a7daa1163c515578f6c37891d63eb1a9139fc4af530c70b4', 'EMP'
FROM gd_esquema.Maestra
WHERE Publ_Empresa_Cuit IS NOT NULL
GO

INSERT INTO DATA_GROUP.Usuario(username, contrasenia, tipo_usuario)
VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 'ADM')
GO

--------------------------------------------------------
----------------------Administrador---------------------
--------------------------------------------------------

INSERT INTO DATA_GROUP.Administrador(id_usuario)
SELECT U.id_usuario
FROM DATA_GROUP.Usuario U
WHERE U.tipo_usuario='ADM' AND U.username ='admin' AND U.contrasenia='e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
GO

--------------------------------------------------------
-------------------------Cliente------------------------
--------------------------------------------------------

INSERT INTO DATA_GROUP.Cliente(nro_documento, id_tipo_documento, id_usuario, apellido, nombre, fecha_nacimiento, mail, dom_calle, nro_calle, piso, depto, cod_postal)
SELECT DISTINCT LTRIM(RTRIM(STR(maes.Publ_Cli_Dni))), 1, usu.id_usuario, maes.Publ_Cli_Apeliido, maes.Publ_Cli_Nombre, maes.Publ_Cli_Fecha_Nac, maes.Publ_Cli_Mail, Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal
FROM gd_esquema.Maestra maes
JOIN DATA_GROUP.Usuario usu
ON usu.tipo_usuario='CLI' AND usu.username=CAST(maes.Publ_Cli_Dni AS NVARCHAR(255))
GO

--------------------------------------------------------
-------------------------Empresa------------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.Empresa(razon_social, cuit, id_usuario, fecha_creacion, mail, dom_calle, nro_calle, piso, depto, cod_postal)
SELECT DISTINCT m.Publ_Empresa_Razon_Social, m.Publ_Empresa_Cuit, u.id_usuario, m.Publ_Empresa_Fecha_Creacion, m.Publ_Empresa_Mail, m.Publ_Empresa_Dom_Calle, m.Publ_Empresa_Nro_Calle, m.Publ_Empresa_Piso, m.Publ_Empresa_Depto, m.Publ_Empresa_Cod_Postal
FROM gd_esquema.Maestra m
JOIN DATA_GROUP.Usuario u
ON u.tipo_usuario='EMP' AND u.username=CAST(m.Publ_Empresa_Cuit AS NVARCHAR(255))
WHERE m.Publ_Empresa_Cuit is not null
GO

--------------------------------------------------------
------------------------RolXUsuario---------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.UsuarioXRol(id_usuario, id_rol)
SELECT DISTINCT c.id_usuario, 2
FROM DATA_GROUP.Cliente c
UNION
SELECT DISTINCT e.id_usuario, 3
FROM DATA_GROUP.Empresa e
UNION
SELECT DISTINCT a.id_usuario, 1
FROM DATA_GROUP.Administrador a
GO


--------------------------------------------------------
------------------------Publicacion---------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.Publicacion (id_publicacion, descripcion, stock, fecha_inicio, fecha_vencimiento, precio, id_tipo_publicacion, id_visibilidad, id_estado, id_usuario_publicador, id_rubro)
SELECT DISTINCT m.Publicacion_Cod, 
				m.Publicacion_Descripcion, 
				m.Publicacion_Stock, 
				m.Publicacion_Fecha, 
				m.Publicacion_Fecha_Venc, 
				m.Publicacion_Precio, 
				case m.Publicacion_Tipo WHEN 'Compra Inmediata' THEN 1 WHEN 'Subasta' THEN 2 END, 
				m.Publicacion_Visibilidad_Cod,
				case WHEN m.Publicacion_Fecha_Venc > CAST('20140618' as datetime) THEN 1 ELSE 4 END,
				u.id_usuario, 
				r.id_rubro
FROM gd_esquema.Maestra m
INNER JOIN DATA_GROUP.Usuario u
ON CONVERT(nvarchar, m.Publ_Cli_Dni)=u.username OR CONVERT(nvarchar, m.Publ_Empresa_Cuit)=u.username
INNER JOIN DATA_GROUP.Rubro r
ON m.Publicacion_Rubro_Descripcion=r.descripcion
WHERE m.Publicacion_Cod is not null
GO

--------------------------------------------------------
-----------------CalificacionPublicacion----------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.CalificacionPublicacion(id_calificacion, estrellas_calificacion, detalle_calificacion)
SELECT DISTINCT m.Calificacion_Codigo, m.Calificacion_Cant_Estrellas, m.Calificacion_Descripcion
FROM gd_esquema.Maestra m
WHERE m.Calificacion_Codigo is not null
GO

--------------------------------------------------------
-------------------------Compras------------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.Compra(fecha, cantidad, id_calificacion, id_usuario_comprador, id_publicacion)
SELECT m.Compra_Fecha, m.Compra_Cantidad, m.Calificacion_Codigo, u.id_usuario, m.Publicacion_Cod
FROM gd_esquema.Maestra m
JOIN DATA_GROUP.Usuario u
ON u.username=CAST(m.Cli_Dni as nvarchar(255))
WHERE m.Compra_Fecha is not null AND
		m.Cli_Dni is not null AND
		m.Publicacion_Cod is not null AND
		M.Calificacion_Codigo is not null
GO

--------------------------------------------------------
-------------------------Ofertas------------------------
--------------------------------------------------------		
INSERT INTO DATA_GROUP.Oferta(fecha, monto, id_publicacion, id_usuario_ofertador)
SELECT m.Oferta_Fecha, m.Oferta_Monto, m.Publicacion_Cod, u.id_usuario
FROM gd_esquema.Maestra m
JOIN DATA_GROUP.Usuario u
ON u.username=CAST(m.Cli_Dni as nvarchar(255))
WHERE m.Oferta_Fecha is not null and
		m.Cli_Dni is not null
GO

--------------------------------------------------------
------------------------Facturas------------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.Factura(nro_factura, fecha, forma_pago_datos, total, id_vendedor, id_forma_pago)
SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Forma_Pago_Desc, m.Factura_Total, p.id_usuario_publicador, 1
FROM gd_esquema.Maestra m
JOIN DATA_GROUP.Publicacion p
ON m.Publicacion_Cod=p.id_publicacion
WHERE m.Factura_Nro is not null
GO

--------------------------------------------------------
----------------------ItemFactura-----------------------
--------------------------------------------------------
INSERT INTO DATA_GROUP.ItemFactura(cantidad, monto, id_publicacion, nro_factura, resumen, id_compra)
SELECT m.Item_Factura_Cantidad, m.Item_Factura_Monto, m.Publicacion_Cod, m.Factura_Nro, 'Factura de publicacion ' + LTRIM(RTRIM(STR(m.Publicacion_Cod))), 0
FROM gd_esquema.Maestra m
WHERE m.Factura_Nro is not null
GO

----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
-----------------------------------------------Stored Procedures------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_rubro_select_all]
AS
BEGIN
	SELECT id_rubro, descripcion
	FROM DATA_GROUP.Rubro;
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_rubro_filter](
	@descripcion nvarchar(255) = NULL
)
AS
BEGIN

	SELECT  r.id_rubro,r.descripcion
	FROM DATA_GROUP.Rubro r
	WHERE ((@descripcion IS NULL) OR ( r.descripcion like '%'+ @descripcion +'%'))
	  
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevaVisibilidad
@descripcion nvarchar(255),
@precio numeric(18, 2),
@porcentaje numeric(18, 2),
@dias_vencimiento_publi numeric(18,0),
@id_visibilidad_agregado numeric(18, 0) OUTPUT
AS
BEGIN

	BEGIN TRAN
		DECLARE @id_nuevo numeric(18, 0)
		SET @id_nuevo=(SELECT MAX(id_visibilidad) FROM DATA_GROUP.VisibilidadPublicacion)+1
		
		INSERT INTO DATA_GROUP.VisibilidadPublicacion(id_visibilidad, descripcion, porcentaje, precio, dias_vencimiento_publi)
		VALUES(@id_nuevo, @descripcion, @porcentaje, @precio, @dias_vencimiento_publi)
		
		SET @id_visibilidad_agregado = @id_nuevo;
	COMMIT TRAN
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.modificarVisibilidad
@id_visibilidad_a_modificar numeric(18,0),
@descripcion nvarchar(255),
@precio numeric(18, 2),
@porcentaje numeric(18, 2),
@dias_vencimiento_publi numeric(18,0)
AS
BEGIN
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET descripcion=@descripcion, 
		precio=@precio, 
		porcentaje=@porcentaje,
		dias_vencimiento_publi=@dias_vencimiento_publi
	WHERE id_visibilidad=@id_visibilidad_a_modificar;
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.inhabilitarVisibilidad
@id_visibilidad numeric(18,0)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET habilitada=0
	WHERE id_visibilidad=@id_visibilidad
	
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.habilitarVisibilidad
@id_visibilidad numeric(18,0)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET habilitada=1
	WHERE id_visibilidad=@id_visibilidad
	
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_Visibilidad_filter](
	@descripcion nvarchar(255) = NULL,
	@precio numeric(18, 2)  = NULL,
	@porcentaje numeric(18, 2) = NULL
)
AS
BEGIN

	SELECT id_visibilidad, descripcion, precio, porcentaje, habilitada, dias_vencimiento_publi
	FROM DATA_GROUP.VisibilidadPublicacion
	WHERE ((@descripcion IS NULL) OR (descripcion like '%' + @descripcion + '%'))
		  AND ((@precio IS NULL) OR (@precio = precio ))
		  AND ((@porcentaje IS NULL) OR ((@porcentaje = porcentaje)))

END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_Visibilidad_select_all]
AS
BEGIN
	SELECT id_visibilidad, descripcion, precio, porcentaje, habilitada, dias_vencimiento_publi
	FROM DATA_GROUP.VisibilidadPublicacion
	WHERE habilitada = 1;
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevoUsuario
@username nvarchar(255),
@contrasenia nvarchar(255),
@telefono numeric(18, 0),
@tipoUsuario nvarchar(3),
@id_usuario numeric(18, 0) OUTPUT
AS
BEGIN
	INSERT INTO DATA_GROUP.Usuario(username, contrasenia, telefono, intentos_login, tipo_usuario)
	VALUES(@username, @contrasenia, @telefono, 0, @tipoUsuario)
	
	SET @id_usuario = SCOPE_IDENTITY(); --Me devuelve el id de la ultima fila insertada
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.asociarRolAUsuario
@id_rol numeric(18, 0),
@id_usuario numeric(18, 0)
AS
BEGIN
	INSERT INTO DATA_GROUP.UsuarioXRol(id_rol, id_usuario)
	VALUES(@id_rol, @id_usuario);
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevoCliente(
@id_usuario_agregado numeric(18, 0) OUTPUT,
@id_tipo_doc numeric(18, 0),  
@nro_documento nvarchar(50), 
@nombre_de_usuario nvarchar(255), 
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@nombre nvarchar(255), 
@apellido nvarchar(255), 
@dom_calle nvarchar(255), 
@nro_calle numeric(18,0),
@piso numeric(18, 0), 
@depto nvarchar(50), 
@localidad nvarchar(255), 
@cod_postal nvarchar(50), 
@mail nvarchar(255), 
@fecha_nacimiento datetime, 
@sexo bit --1 es masculino, 0 es femenino
)
AS
BEGIN
	BEGIN TRY
		
		DECLARE @telefonoRepetido numeric(18, 0) = null
	
		SET @telefonoRepetido = (SELECT TOP 1 telefono FROM DATA_GROUP.Usuario WHERE telefono is not null and telefono=@telefono_usuario)
		
		if @telefonoRepetido is null
		BEGIN		
			BEGIN TRAN	
			DECLARE @id_usuario_new numeric(18,0);
			
			EXEC DATA_GROUP.nuevoUsuario  @nombre_de_usuario, @contrasenia_usuario, @telefono_usuario, 'CLI', @id_usuario_new OUTPUT
			SET @id_usuario_agregado = @id_usuario_new
			
			DECLARE @id_rol_for_new_user numeric(18) = (SELECT TOP 1 id_rol FROM DATA_GROUP.Rol WHERE nombre = 'Cliente')
			
			EXECUTE DATA_GROUP.asociarRolAUsuario @id_rol_for_new_user, @id_usuario_new
			
			-- Creo el registro del cliente
			INSERT INTO DATA_GROUP.Cliente(id_tipo_documento, 
										   nro_documento, 
										   id_usuario, 
										   nombre, 
										   apellido, 
										   dom_calle, 
										   piso, 
										   depto, 
										   localidad, 
										   cod_postal, 
										   mail, 
										   fecha_nacimiento, 
										   sexo)
			VALUES (@id_tipo_doc, 
					@nro_documento, 
					@id_usuario_new, 
					@nombre, 
					@apellido, 
					@dom_calle, 
					@piso, 
					@depto, 
					@localidad, 
					@cod_postal, 
					@mail, 
					@fecha_nacimiento, 
					@sexo)

			COMMIT TRAN
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
	END CATCH

END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.modificarUsuario
@id_usuario numeric(18, 0),
@username nvarchar(255),
@contrasenia nvarchar(255),
@telefono numeric(18, 0)
AS
BEGIN
	if @contrasenia!='123456'
	BEGIN
		UPDATE DATA_GROUP.Usuario
		SET contrasenia=@contrasenia, telefono=@telefono, username=@username
		WHERE id_usuario=@id_usuario
	END
	ELSE
	BEGIN
		UPDATE DATA_GROUP.Usuario
		SET telefono=@telefono, username=@username
		WHERE id_usuario=@id_usuario
	END
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.modificarCliente
(	
	@id_usuario_a_modificar numeric(18, 0),
	@id_tipo_documento nvarchar(50),
	@nro_documento nvarchar(50), 
	@nombre_de_usuario nvarchar(255),
	@contrasenia_usuario nvarchar(255),
	@telefono_usuario numeric(18, 0),
	@nombre nvarchar(255), 
	@apellido nvarchar(255), 
	@dom_calle nvarchar(255),
	@nro_calle numeric(18,0),	
	@piso numeric(18, 0), 
	@depto nvarchar(50), 
	@localidad nvarchar(255), 
	@cod_postal nvarchar(50), 
	@mail nvarchar(255), 
	@fecha_nacimiento datetime,
	@sexo bit --1 es masculino, 0 es femenino
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		
		EXEC DATA_GROUP.modificarUsuario @id_usuario=@id_usuario_a_modificar, @username=@nombre_de_usuario, @contrasenia=@contrasenia_usuario, @telefono=@telefono_usuario
		
		UPDATE DATA_GROUP.Cliente
		SET 
			nro_documento = @nro_documento,
			id_tipo_documento = @id_tipo_documento,
			nombre=@nombre, 
			apellido=@apellido, 
			dom_calle=@dom_calle, 
			piso=@piso, 
			depto=@depto, 
			localidad=@localidad, 
			cod_postal=@cod_postal, 
			mail=@mail,
			fecha_nacimiento=@fecha_nacimiento, 
			sexo=@sexo
		WHERE id_usuario = @id_usuario_a_modificar

		COMMIT TRAN
	END TRY
	BEGIN CATCH
	
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
	END CATCH
END
GO

--------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_cliente_filter](
	@id_tipo_doc numeric(18, 0) = NULL,  
	@nro_documento nvarchar(50) = NULL, 
	@telefono_usuario numeric(18, 0) = NULL,
	@nombre nvarchar(255) = NULL, 
	@apellido nvarchar(255) = NULL, 
	@dom_calle nvarchar(255) = NULL, 
	@piso numeric(18, 0) = NULL, 
	@depto nvarchar(50) = NULL, 
	@localidad nvarchar(255) = NULL, 
	@cod_postal nvarchar(50) = NULL, 
	@mail nvarchar(255) = NULL, 
	@fecha_nacimiento datetime = NULL, 
	@habilitada bit = NULL,
	@sexo bit = NULL --1 es masculino, 0 es femenino
)
AS
BEGIN

	if @habilitada is null
		SET @habilitada=1

	SELECT  c.id_tipo_documento,
			c.nro_documento,
			c.id_usuario,
			c.nombre,
			c.apellido,
			c.dom_calle,
			c.nro_calle,
			c.piso,
			c.depto,
			c.localidad,
			c.cod_postal,
			c.mail,
			c.fecha_nacimiento,
			c.sexo,
			u.telefono,
			u.habilitada,
			u.habilitada_comprar,
			u.username
	FROM DATA_GROUP.Cliente c
	INNER JOIN DATA_GROUP.Usuario u
	ON u.id_usuario = c.id_usuario AND u.tipo_usuario='CLI'
	WHERE  ((@id_tipo_doc IS NULL) OR (c.id_tipo_documento = @id_tipo_doc ))
	  AND ((@nro_documento IS NULL) OR (c.nro_documento = @nro_documento))
	  AND ((@telefono_usuario IS NULL) OR (u.telefono = @telefono_usuario))
	  AND ((@nombre IS NULL) OR ( c.nombre like '%'+ @nombre +'%'))
	  AND ((@apellido IS NULL) OR (c.apellido like '%'+ @apellido +'%'))
	  AND ((@dom_calle IS NULL) OR (c.dom_calle like '%'+ @dom_calle +'%'))
	  AND ((@piso IS NULL) OR (c.piso=@piso))
	  AND ((@depto IS NULL) OR (c.depto like '%'+ @depto +'%'))
	  AND ((@localidad IS NULL) OR (c.localidad like '%'+ @localidad +'%'))
	  AND ((@cod_postal IS NULL) OR (c.cod_postal like '%'+ @cod_postal +'%'))
	  AND ((@fecha_nacimiento IS NULL) OR (c.fecha_nacimiento = @fecha_nacimiento))
	  AND ((@sexo IS NULL) OR (c.sexo = @sexo))
	  AND ((@mail IS NULL) OR (c.mail like '%'+@mail+'%'))
	  AND ((u.habilitada=@habilitada))
	  
END
GO

--------------------------Nueva Empresa---------------------------

CREATE PROCEDURE DATA_GROUP.nuevaEmpresa(
@id_usuario_agregado numeric(18, 0) OUTPUT,
@nombre_de_usuario nvarchar(255), 
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@cuit nvarchar(50), 
@razon_social nvarchar(50), 
@mail nvarchar(50), 
@dom_calle nvarchar(255),
@nro_calle numeric(18,0), 
@piso numeric(18, 0),
@depto nvarchar(50),
@localidad nvarchar(255),
@cod_postal nvarchar(50),
@ciudad nvarchar(255),
@nombre_de_contacto nvarchar(255),
@fecha_creacion datetime
)
AS
BEGIN
	BEGIN TRY
	
		DECLARE @telefonoRepetido numeric(18, 0) = null
	
		SET @telefonoRepetido = (SELECT TOP 1 telefono FROM DATA_GROUP.Usuario WHERE telefono is not null and telefono=@telefono_usuario)
		
		if @telefonoRepetido is null
		BEGIN		
			BEGIN TRAN	
			DECLARE @id_usuario_new numeric(18,0);
			
			EXEC DATA_GROUP.nuevoUsuario @nombre_de_usuario, @contrasenia_usuario, @telefono_usuario, 'EMP', @id_usuario_new OUTPUT
			SET @id_usuario_agregado = @id_usuario_new
			
			DECLARE @id_rol_for_new_user numeric(18) = (SELECT TOP 1 id_rol FROM DATA_GROUP.Rol WHERE nombre = 'Empresa')
			
			EXECUTE DATA_GROUP.asociarRolAUsuario @id_rol_for_new_user, @id_usuario_new
			
			-- Creo el registro del cliente
			INSERT INTO DATA_GROUP.Empresa(cuit, 
										   razon_social, 
										   id_usuario, 
										   mail, 
										   dom_calle,
										   nro_calle,
										   piso, 
										   depto, 
										   localidad, 
										   cod_postal, 
										   ciudad, 
										   nombre_de_contacto, 
										   fecha_creacion)
			VALUES (@cuit, 
				@razon_social, 
				@id_usuario_new, 
				@mail, 
				@dom_calle,
				@nro_calle,
				@piso, 
				@depto, 
				@localidad, 
				@cod_postal, 
				@ciudad, 
				@nombre_de_contacto, 
				@fecha_creacion)

			COMMIT TRAN
		END
	
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
	END CATCH
END
GO

---------------------------------Modificar Empresa-------------------------------

CREATE PROCEDURE DATA_GROUP.modificarEmpresa
@id_usuario_a_modificar numeric(18,0),
@cuit nvarchar(50), 
@razon_social nvarchar(50), 
@nombre_de_usuario nvarchar(255),
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@mail nvarchar(50), 
@dom_calle nvarchar(255), 
@nro_calle numeric(18,0),
@piso numeric(18, 0),
@depto nvarchar(50),
@localidad nvarchar(255),
@cod_postal nvarchar(50),
@ciudad nvarchar(255),
@nombre_de_contacto nvarchar(255),
@fecha_creacion datetime
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
		
		EXEC DATA_GROUP.modificarUsuario @id_usuario=@id_usuario_a_modificar, @username=@nombre_de_usuario, @contrasenia=@contrasenia_usuario, @telefono=@telefono_usuario
		
		UPDATE DATA_GROUP.Empresa
		SET razon_social = @razon_social,
			cuit = @cuit,
			fecha_creacion=@fecha_creacion,
			mail=@mail, 
			dom_calle=@dom_calle,
			nro_calle=@nro_calle,
			piso=@piso, 
			depto=@depto, 
			localidad=@localidad,  
			cod_postal=@cod_postal, 
			ciudad=@ciudad, 
			nombre_de_contacto=@nombre_de_contacto
		WHERE id_usuario=@id_usuario_a_modificar

		COMMIT TRAN
	END TRY
	BEGIN CATCH
	
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
	END CATCH
END
GO

---------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_empresa_filter]
(
	@CUIT nvarchar(50) = NULL, 
	@razon_social nvarchar(255) = NULL, 
	@mail nvarchar(50) = NULL, 
	@habilitada bit = NULL
)
AS
BEGIN

	if @habilitada is null
		SET @habilitada=1

	SELECT  e.cuit,
			e.razon_social, 
			e.id_usuario, 
			e.mail, 
			e.dom_calle,
			e.nro_calle,
			e.piso, 
			e.depto, 
			e.localidad, 
			e.cod_postal, 
			e.ciudad, 
			e.nombre_de_contacto, 
			e.fecha_creacion,
			u.telefono,
			u.habilitada,
			u.habilitada_comprar,
			u.username
	FROM DATA_GROUP.Empresa e
	INNER JOIN DATA_GROUP.Usuario u
	ON u.id_usuario = e.id_usuario AND u.tipo_usuario='EMP'
	WHERE  ((@CUIT IS NULL) OR (e.cuit = @CUIT ))
	  AND ((@razon_social IS NULL) OR ( e.razon_social like '%'+ @razon_social +'%'))
	  AND ((@mail IS NULL) OR (e.mail like '%'+@mail+'%'))
	  AND ((u.habilitada=@habilitada))
END
GO

-----------------------------------------------------

CREATE FUNCTION DATA_GROUP.getIdRolPorNombre( @nombre_rol nvarchar(255))
	RETURNS NUMERIC(18, 0)
AS
BEGIN
	DECLARE @id_rol_return NUMERIC(18, 0)
	
	SELECT @id_rol_return=id_rol 
	FROM DATA_GROUP.Rol 
	WHERE nombre=@nombre_rol
	
	RETURN @id_rol_return
END
GO

-----------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTodosLosRoles
AS
BEGIN
	select id_rol, nombre, habilitada
	from DATA_GROUP.Rol
END
GO

-----------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getRolesDeUsuario 
	@username nvarchar(255)
AS
BEGIN

	SELECT r.id_rol, r.nombre, r.habilitada
	FROM DATA_GROUP.Rol r
	INNER JOIN DATA_GROUP.UsuarioXRol ur
	ON r.id_rol=ur.id_rol
	INNER JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=ur.id_usuario AND u.username=@username
	WHERE r.habilitada=1 AND u.habilitada=1

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_rol_filter](
	@nombre nvarchar(255) = NULL
)
AS
BEGIN

SELECT id_rol, nombre, habilitada 
FROM DATA_GROUP.Rol
WHERE ((@nombre is null) OR (nombre like '%' + @nombre + '%'))

END
GO
-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.modificarRol
@id_rol numeric(18,0),
@nombre nvarchar(255)
AS
BEGIN
	UPDATE DATA_GROUP.Rol
	SET nombre = @nombre
	WHERE id_rol=@id_rol
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.modificarFuncionalidadDeUnRol
@id_rol numeric(18,0),
@id_funcionalidad numeric(18,0),
@habilitada bit
AS
BEGIN
	
	Declare @id_funcionalidad_buscado numeric(18,0)
	
	SELECT @id_funcionalidad_buscado=id_funcionalidad
	FROM DATA_GROUP.FuncionalidadXRol
	WHERE id_funcionalidad=@id_funcionalidad AND id_rol=@id_rol
	
	if @id_funcionalidad_buscado is not null
		update DATA_GROUP.FuncionalidadXRol
		Set habilitada=@habilitada
		where id_funcionalidad=@id_funcionalidad and id_rol=@id_rol
	else
	begin
	if @habilitada=1
		insert into DATA_GROUP.FuncionalidadXRol(id_rol, id_funcionalidad, habilitada)
		values(@id_rol, @id_funcionalidad, @habilitada)
	end
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.SP_deshabilitarRol
(@id_rol numeric(18,0))
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE DATA_GROUP.Rol 
			SET habilitada=0 
			WHERE id_rol=@id_rol
			
			UPDATE DATA_GROUP.UsuarioXRol
			SET habilitada = 0
			where id_rol=@id_rol
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
		
	END CATCH
END
GO
-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.SP_habilitarRol
@id_rol numeric(18,0)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE DATA_GROUP.Rol 
			SET habilitada=1 
			WHERE id_rol=@id_rol
			
			UPDATE DATA_GROUP.UsuarioXRol
			SET habilitada = 1
			where id_rol=@id_rol
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
		
	END CATCH

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.SP_agregarFuncionalidadXRol
@id_rol numeric(18,0),
@id_funcionalidad numeric(18,0),
@habilitada bit=1
AS
BEGIN
	INSERT INTO DATA_GROUP.FuncionalidadXRol(id_funcionalidad, id_rol, habilitada)
	VALUES (@id_funcionalidad, @id_rol, 1);	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.SP_crearRol
@nombreRolNuevo nvarchar(255),
@habilitada bit,
@id_rol_nuevo numeric(18, 0) OUTPUT
AS
BEGIN
	IF(NOT EXISTS(SELECT nombre FROM DATA_GROUP.Rol WHERE nombre=@nombreRolNuevo))
	BEGIN
		INSERT INTO DATA_GROUP.Rol (nombre, habilitada) VALUES (@nombreRolNuevo, @habilitada);
		
		SET @id_rol_nuevo = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		RAISERROR ('El nombre de rol seleccionado ya existe. Debe ser unico', -- Message text.
			   -1, -- Severity.
			   -1 -- State.
			   );
	END
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTodosAnios
AS
BEGIN
	SELECT DISTINCT YEAR(fecha) anio
	FROM DATA_GROUP.Compra
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos
@anio int,
@trimestre int,
@mes int,
@visibilidad_desc nvarchar(255)
AS
BEGIN

	select TOP 5 
			u.username 'Username', 
			SUM(p.stock) 'Cantidad_no_vendida',
			@anio as 'Anio',
			@mes as 'Mes',
			@visibilidad_desc as 'Visibilidad'
	from DATA_GROUP.Publicacion p
	join DATA_GROUP.Usuario u
	on u.id_usuario=p.id_usuario_publicador
	join DATA_GROUP.VisibilidadPublicacion v
	ON p.id_visibilidad=v.id_visibilidad AND v.descripcion=@visibilidad_desc
	where 	YEAR(p.fecha_inicio)=@anio
			AND MONTH(p.fecha_inicio)=@mes
			AND MONTH(p.fecha_inicio)>(@trimestre-1)*3 AND MONTH(p.fecha_inicio)<=@trimestre*3	
	group by u.username
	order by sum(p.stock) desc

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMayorFacturacion
@anio int, 
@trimestre int,
@mes int = NULL,
@visibilidad_desc nvarchar(255) = NULL
AS
BEGIN

	SELECT top 5 f.id_vendedor, SUM(f.total) Facturacion
	FROM DATA_GROUP.Factura f
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=f.id_vendedor 
		AND YEAR(f.fecha)=@anio 
		AND MONTH(f.fecha)>(@trimestre-1)*3 AND MONTH(f.fecha)<=@trimestre*3 
	GROUP BY f.id_vendedor
	ORDER BY Facturacion DESC
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMayorCalificaciones
@anio int, 
@trimestre int,
@mes int = NULL,
@visibilidad_desc nvarchar(255) = NULL
AS
BEGIN
	SELECT TOP 5 
			p.id_usuario_publicador Vendedor, 
			@anio as 'Año',
			AVG(cal.estrellas_calificacion) as 'Calificacio promedio'
	FROM DATA_GROUP.CalificacionPublicacion cal
	JOIN DATA_GROUP.Compra comp
	ON comp.id_calificacion=cal.id_calificacion
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=comp.id_publicacion
	WHERE YEAR(comp.fecha)=@anio 
		AND MONTH(comp.fecha)>(@trimestre-1)*3 AND MONTH(comp.fecha)<=@trimestre*3 
	GROUP BY p.id_usuario_publicador
	ORDER BY AVG(cal.estrellas_calificacion) DESC
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar
@anio int,
@trimestre int,
@mes int = NULL,
@visibilidad_desc nvarchar(255) = NULL
AS
BEGIN
	SELECT TOP 5 
			usu.username as 'Username', 
			COUNT(*) as 'Cantidad',
			@anio as 'Año',
			CASE WHEN @trimestre=1 THEN 'Primer trimestre'
				 WHEN @trimestre=2 THEN 'Segundo trimestre'
				 WHEN @trimestre=3 THEN 'Tercer trimestre'
				 WHEN @trimestre=4 THEN 'Cuarto trimestre'
			END as 'Trimestre'
	FROM DATA_GROUP.Compra com
	JOIN DATA_GROUP.Usuario usu
	ON com.id_usuario_comprador=usu.id_usuario 
		AND com.id_calificacion is null
		AND YEAR(com.fecha)=@anio 
		AND MONTH(com.fecha)>(@trimestre-1)*3 AND MONTH(com.fecha)<=@trimestre*3 
	GROUP BY usu.username
	ORDER BY COUNT(*) DESC
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTodasComprasRealizadas
@username nvarchar(255)
AS
BEGIN
	SELECT c.id_compra 'Id de compra', c.id_publicacion 'Nro de Publicacion',c.fecha 'Fecha', c.cantidad 'Cantidad'
	FROM DATA_GROUP.Compra c
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=c.id_usuario_comprador AND u.username=@username
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=c.id_publicacion AND p.id_tipo_publicacion=1
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTodasLasOfertasRealizadas
@username nvarchar(255)
AS
BEGIN
	
	DECLARE @id_usuario numeric(18, 0)
	SET @id_usuario=(SELECT id_usuario FROM DATA_GROUP.Usuario WHERE username=@username)

	SELECT  c.id_compra 'Id', 
			0 as 'Monto ofertado',
			'Ganada' as 'Resultado de la oferta',
			c.fecha as 'Fecha'
	FROM DATA_GROUP.Compra c
	JOIN DATA_GROUP.Publicacion p
	ON c.id_publicacion=p.id_publicacion 
		AND p.id_tipo_publicacion=2
		AND c.id_usuario_comprador=@id_usuario
	UNION
	SELECT  o.id_oferta 'Id', 
			o.monto 'Monto ofertado',
			'No ganada' as 'Resultado de la oferta',
			o.fecha as 'Fecha'
	FROM DATA_GROUP.Oferta o
	WHERE o.id_usuario_ofertador=@id_usuario
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getCalificacionesDelUsuario
@username nvarchar(255)
AS
BEGIN
	
	DECLARE @id_usuario numeric(18, 0)
	SET @id_usuario=(SELECT id_usuario FROM DATA_GROUP.Usuario WHERE username=@username)
	
	SELECT  cal.estrellas_calificacion as 'Puntuacion', 
			'Recibida de: '+u.username as Calificacion,
			CASE WHEN cal.detalle_calificacion is null OR cal.detalle_calificacion='' THEN '-Sin comentarios-'
				 ELSE cal.detalle_calificacion
			END as Comentario
	FROM DATA_GROUP.Compra com
	JOIN DATA_GROUP.CalificacionPublicacion cal
	ON com.id_calificacion=cal.id_calificacion 
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=com.id_publicacion AND p.id_usuario_publicador=@id_usuario
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=com.id_usuario_comprador
	UNION
	SELECT  cal.estrellas_calificacion as 'Puntuacion', 
			'Otorgada a: '+u.username as Calificacion,
			CASE WHEN cal.detalle_calificacion is null OR cal.detalle_calificacion='' THEN '-Sin comentarios-'
				 ELSE cal.detalle_calificacion
			END as Comentario
	FROM DATA_GROUP.Compra com
	JOIN DATA_GROUP.CalificacionPublicacion cal
	ON com.id_calificacion=cal.id_calificacion
		AND com.id_usuario_comprador=@id_usuario
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=com.id_publicacion
	JOIN DATA_GROUP.Usuario u
	ON p.id_usuario_publicador=u.id_usuario
	
END
GO


-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.cantidadDeComprasSinCalificar
@id_usuario numeric(18, 0),
@cantidad_sin_calificar int OUTPUT
AS
BEGIN

	SELECT @cantidad_sin_calificar=COUNT(*) 
	from DATA_GROUP.Compra c
	WHERE c.id_calificacion is null AND c.id_usuario_comprador=@id_usuario
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador
@id_usuario numeric(18, 0),
@puede_comprar bit OUTPUT
AS
BEGIN

	DECLARE @cantidadComprasSinCalificar int
	EXEC DATA_GROUP.cantidadDeComprasSinCalificar @id_usuario, @cantidadComprasSinCalificar OUTPUT
	
	if @cantidadComprasSinCalificar>5
	BEGIN
		UPDATE DATA_GROUP.Usuario
		SET habilitada_comprar=0
		WHERE id_usuario=@id_usuario
		
		SET @puede_comprar=0
	END
	ELSE
		SET @puede_comprar=1
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.sp_nuevaOferta
@id_publicacion numeric(18, 0),
@id_usuario_ofertador numeric(18, 0),
@monto numeric(18, 2),
@id_oferta numeric(18, 0) OUTPUT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		
			UPDATE DATA_GROUP.Publicacion 
			SET precio = @monto
			WHERE id_publicacion = @id_publicacion
		
			INSERT INTO DATA_GROUP.Oferta(id_publicacion, id_usuario_ofertador, monto, fecha)
			VALUES(@id_publicacion, @id_usuario_ofertador, @monto, GETDATE())
			
			SET @id_oferta = SCOPE_IDENTITY();
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

			RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );
	END CATCH
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.habilitarParaComprar
@id_usuario numeric(18,0)
AS
BEGIN
	
	UPDATE DATA_GROUP.Usuario
	SET habilitada_comprar=1
	WHERE id_usuario=@id_usuario;
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevaCalificacion
@id_compra numeric(18,0),
@estrellas_calificacion numeric(18, 0),
@detalle_calificacion nvarchar(255),
@id_calificacion numeric(18,0) OUTPUT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		
			SELECT @id_calificacion = MAX(id_calificacion)+1
			FROM DATA_GROUP.CalificacionPublicacion

			INSERT INTO DATA_GROUP.CalificacionPublicacion(id_calificacion, estrellas_calificacion, detalle_calificacion)
			VALUES (@id_calificacion, @estrellas_calificacion, @detalle_calificacion)
			
			UPDATE DATA_GROUP.Compra
			SET id_calificacion=@id_calificacion
			WHERE id_compra=@id_compra

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
	END CATCH
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getComprasSinCalificar
@id_usuario numeric(18, 0)
AS
BEGIN
	SELECT c.id_compra, c.id_publicacion, c.id_usuario_comprador, c.id_calificacion, c.fecha, c.cantidad
	FROM DATA_GROUP.Compra c
	WHERE id_calificacion is null AND id_usuario_comprador=@id_usuario
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.inHabilitarUsuario
@id_usuario numeric(18, 0)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE DATA_GROUP.Usuario
			SET habilitada=0
			WHERE id_usuario=@id_usuario
			
			DECLARE @id_pausada numeric(18,0)
			SET @id_pausada = 3

			UPDATE DATA_GROUP.Publicacion
			SET id_estado=@id_pausada
			WHERE id_usuario_publicador=@id_usuario
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

			RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );
	END CATCH
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.habilitarUsuario
@id_usuario numeric(18, 0)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			UPDATE DATA_GROUP.Usuario
			SET habilitada=1
			WHERE id_usuario=@id_usuario
			
			DECLARE @id_publicada numeric(18,0)
			SET @id_publicada = 1

			UPDATE DATA_GROUP.Publicacion
			SET id_estado=@id_publicada
			WHERE id_usuario_publicador=@id_usuario
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

			RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );
	END CATCH
	
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.cantidadDeComprasSinRendir
@id_vendedor numeric(18, 0),
@cantidad_sin_rendir int OUTPUT
AS
BEGIN

	SELECT @cantidad_sin_rendir = COUNT(*)
	FROM DATA_GROUP.Compra c
	JOIN DATA_GROUP.Publicacion p ON p.id_usuario_publicador=@id_vendedor AND c.id_publicacion=p.id_publicacion
	WHERE c.facturada=0

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.ValidarComprasRendidasDelVendedor
@id_publicacion numeric(18, 0)
AS
BEGIN

	DECLARE @cantidad_sin_rendir int;
	DECLARE @id_vendedor numeric(18,0);
	
	SELECT @id_vendedor=p.id_usuario_publicador
	FROM DATA_GROUP.Publicacion p
	WHERE p.id_publicacion=@id_publicacion
	
	EXEC DATA_GROUP.cantidadDeComprasSinRendir @id_vendedor, @cantidad_sin_rendir OUTPUT
	
	if @cantidad_sin_rendir>10
		EXEC DATA_GROUP.inHabilitarUsuario @id_vendedor
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.sp_nuevaCompra
@id_publicacion numeric(18, 0),
@id_usuario numeric(18, 0),
@cantidad numeric(18, 0),
@id_compra_nueva numeric(18, 0) OUTPUT,
@puede_comprar bit OUTPUT
AS
BEGIN		
	BEGIN TRY
		BEGIN TRAN
		
			DECLARE @cantidad_nueva numeric(18, 0)
			SELECT @cantidad_nueva=stock-@cantidad
			FROM DATA_GROUP.Publicacion
			WHERE id_publicacion = @id_publicacion
			
			UPDATE DATA_GROUP.Publicacion
			SET stock = @cantidad_nueva
			WHERE id_publicacion = @id_publicacion
			
			if @cantidad_nueva = 0
			BEGIN
				UPDATE DATA_GROUP.Publicacion
				SET id_estado = (SELECT e.id_estado FROM DATA_GROUP.EstadoPublicacion e WHERE e.descripcion='Finalizada')
				WHERE id_publicacion = @id_publicacion
			END
			
			DECLARE @comision numeric(18,2)
			
			SELECT @comision=p.precio*v.porcentaje*@cantidad
			FROM DATA_GROUP.Publicacion p
			JOIN DATA_GROUP.VisibilidadPublicacion v ON v.id_visibilidad=p.id_visibilidad
			
			INSERT INTO DATA_GROUP.Compra(  id_publicacion, 
											id_usuario_comprador, 
											fecha, 
											cantidad,
											comision,
											facturada)
			VALUES (@id_publicacion, 
					@id_usuario, 
					GETDATE(), 
					@cantidad,
					@comision,
					0)
					
			SET @id_compra_nueva = SCOPE_IDENTITY();
			
			EXEC DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador @id_usuario, @puede_comprar OUTPUT
			
			EXEC DATA_GROUP.ValidarComprasRendidasDelVendedor @id_publicacion

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

			RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );
	END CATCH
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.puedeComprar
@id_usuario numeric(18,0),
@puedeComprar bit OUTPUT
AS
BEGIN
	
	SELECT @puedeComprar = habilitada_comprar
	FROM DATA_GROUP.Usuarios
	WHERE id_usuario = @id_usuario
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.actualizarContraseniaPrimerIngreso
@id_usuario numeric(18,0),
@contrasenia nvarchar(255)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET contrasenia=@contrasenia
	WHERE id_usuario=@id_usuario;
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.setCantidadIntentos
@username nvarchar(255),
@cantidad int
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET intentos_login=@cantidad
	WHERE username=@username
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getUsuarioByUsername(
	@username nvarchar(255))
AS
BEGIN

	SELECT  u.id_usuario, 
			u.username, 
			u.contrasenia, 
			u.intentos_login, 
			u.habilitada, 
			u.habilitada_comprar, 
			u.telefono
	FROM DATA_GROUP.Usuario u
	WHERE u.username=@username AND u.habilitada=1

 END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.existeUsuario
@username nvarchar(255),
@resultado bit OUTPUT
AS
BEGIN
	DECLARE @busquedaUser nvarchar(255)=null

	SELECT @busquedaUser=username
	FROM DATA_GROUP.Usuario
	WHERE username = @username;

	if @busquedaUser is not null
		SET @resultado=1
	else
		SET @resultado=0
		
	RETURN @resultado
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_Usuario_filter](
	@username nvarchar(255) = NULL,
	@telefono numeric(18, 0) = NULL
)
AS
BEGIN
	SELECT username, id_usuario, telefono, habilitada, habilitada_comprar
	FROM DATA_GROUP.Usuario
	WHERE ((@username is null) OR (username like '%' + @username + '%'))
		AND ((@telefono is null) OR (@telefono = telefono))
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.promedioCalificaciones
@id_usuario numeric(18,0),
@promedio numeric(18,2) OUTPUT
AS
BEGIN

	SELECT @promedio=AVG(cal.estrellas_calificacion)
	from DATA_GROUP.Compra c
	join DATA_GROUP.Publicacion p 
		on p.id_publicacion=c.id_publicacion and p.id_usuario_publicador=@id_usuario
	join DATA_GROUP.CalificacionPublicacion cal 
		on c.id_calificacion=cal.id_calificacion;

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getDatosDelVendedor
@id_usuario numeric(18,0)
AS
BEGIN
	DECLARE @tipo_usuario nvarchar(3)
	 
	SELECT @tipo_usuario=tipo_usuario
	FROM DATA_GROUP.Usuario
	WHERE id_usuario=@id_usuario
	
	DECLARE @prom numeric(18,2)
	
	EXEC DATA_GROUP.promedioCalificaciones @id_usuario, @prom output
	
	if @tipo_usuario='CLI'
			SELECT  t.descripcion 'Tipo de documento', 
					c.nro_documento 'Numero de documento',
					c.nombre Nombre,
					c.apellido Apellido,
					c.dom_calle 'Calle de domicilio',
					c.piso Piso,
					c.depto Departamento,
					c.localidad Localidad,
					c.cod_postal 'Codigo postal',
					c.mail 'Mail',
					c.fecha_nacimiento 'Fecha de nacimiento',
					CASE c.sexo WHEN 0 THEN 'Masculino' WHEN 1 THEN 'Femenino' WHEN 2 THEN 'Indefinido' END as 'Sexo',
					u.telefono Telefono,
					u.username 'Nombre de usuario', 
					@prom 'Promedio de calificaciones'
			FROM DATA_GROUP.Cliente c
			INNER JOIN DATA_GROUP.Usuario u
			ON u.id_usuario = c.id_usuario AND u.tipo_usuario='CLI' AND u.id_usuario=@id_usuario
			INNER JOIN DATA_GROUP.TipoDocumento t
			on t.id_tipo_documento=c.id_tipo_documento
	if @tipo_usuario='EMP'
		SELECT  e.cuit CUIT,
			e.razon_social 'Razon social', 
			e.mail Mail, 
			e.dom_calle 'Calle de domicilio', 
			e.piso Piso, 
			e.depto Departamento, 
			e.localidad Localidad, 
			e.cod_postal 'Codigo postal', 
			e.ciudad Ciudad, 
			e.nombre_de_contacto 'Nombre de contacto', 
			e.fecha_creacion 'Fecha de creacion',
			u.telefono 'Telefono',
			u.username 'Nombre de usuario',
			@prom 'Promedio de calificaciones'
		FROM DATA_GROUP.Empresa e
		INNER JOIN DATA_GROUP.Usuario u
		ON u.id_usuario = e.id_usuario AND u.tipo_usuario='EMP' AND u.id_usuario=@id_usuario
	if @tipo_usuario='ADM'
		SELECT  u.id_usuario 'Nro de usuario', 
				u.username 'Nombre de usuario', 
				u.telefono 'Telefono',
				@prom 'Promedio de calificaciones'
		FROM DATA_GROUP.Usuario u
		WHERE u.id_usuario=@id_usuario AND u.tipo_usuario='ADM'

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_EstadoPublicacion_select_all]
AS
BEGIN
	SELECT id_estado, descripcion
	FROM DATA_GROUP.EstadoPublicacion;
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getBonificados
@id_usuario numeric(18,0)
AS
BEGIN
	
	SELECT  c.id_visibilidad_fact, v.descripcion, c.id_usuario_fact, c.cantidad_fact
	FROM DATA_GROUP.CantVisibilidadesFacturadasPorUsuario c
	JOIN DATA_GROUP.VisibilidadPublicacion v ON v.id_visibilidad=c.id_visibilidad_fact
	WHERE c.id_usuario_fact=@id_usuario
	Order by c.id_visibilidad_fact ASC
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getPendientesDeFacturar
@id_usuario numeric(18,0)
AS
BEGIN

	CREATE TABLE temp_pendientes(
	facturar bit,
	id_publicacion numeric(18,0),
	id_compra numeric(18,0),
	tipo_item_a_facturar nvarchar(10),
	resumen nvarchar(255),
	cantidad_a_rendir numeric(18,0),
	importe_a_rendir numeric(18,2),
	id_visibilidad numeric(18,0),
	fecha_inicio datetime
	);

	INSERT INTO temp_pendientes(id_publicacion, 
								id_compra, 
								facturar, 
								tipo_item_a_facturar, 
								resumen, 
								cantidad_a_rendir, 
								importe_a_rendir,
								id_visibilidad,
								fecha_inicio)
	Select	P.id_publicacion, 
			id_compra = 0,
			[Facturar] = CONVERT(Bit, 0), 
			[Tipo] = 'PUBL',
			[Resumen] = 'Costo por publicacion(' + LTRIM(RTRIM(STR(P.id_publicacion))) + ') - Visibilidad: ' + V.descripcion +' - Importe: $' +LTRIM(RTRIM(STR(V.precio))),
			[Cantidad] = 1, 
			[Importe] = V.precio,
			P.id_visibilidad,
			[FechaDte] = P.fecha_inicio
	From DATA_GROUP.Publicacion P
	Inner Join DATA_GROUP.VisibilidadPublicacion V On V.id_visibilidad = P.id_visibilidad
	Where P.id_usuario_publicador = @id_usuario
	AND P.facturada = 0
	
	Union All
	
	Select	P.id_publicacion, 
			C.id_compra, 
			[Facturar] = CONVERT(Bit, 0),
			[Tipo] = 'COMP',
			[Resumen] = 'Comision por compra en publicacion(' + LTRIM(RTRIM(STR(P.id_publicacion))) +') - Comision: $' + LTRIM(RTRIM(STR(C.comision))), 
			[Cantidad] = C.cantidad,
			[Importe] = C.comision,
			P.id_visibilidad,
			[FechaDte] = C.fecha
	From DATA_GROUP.Compra C
	Inner Join DATA_GROUP.Publicacion P On P.id_publicacion = C.id_publicacion
	Inner Join DATA_GROUP.Usuario U On U.id_usuario = C.id_usuario_comprador
	Where P.id_usuario_publicador = @id_usuario
	AND C.facturada = 0;

	SELECT  facturar,
			id_publicacion, 
			id_compra, 
			tipo_item_a_facturar, 
			resumen, 
			cantidad_a_rendir, 
			importe_a_rendir,
			id_visibilidad,
			fecha_inicio 
	FROM temp_pendientes 
	ORDER BY fecha_inicio ASC;

	DROP TABLE temp_pendientes;
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.crearFactura
@nro_factura numeric(18,0) OUTPUT, 
@id_vendedor numeric(18,0), 
@total numeric(18,2), 
@id_forma_pago numeric(18,0), 
@forma_pago_datos nvarchar(255)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN

		SELECT @nro_factura = MAX(nro_factura) + 1 
		FROM DATA_GROUP.Factura
		
		INSERT INTO DATA_GROUP.Factura( nro_factura, 
										id_vendedor, 
										fecha, 
										total, 
										id_forma_pago, 
										forma_pago_datos)
		Values(@nro_factura, @id_vendedor, GETDATE(), @total, @id_forma_pago, @forma_pago_datos);

		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			@ErrorSeverity, -- Severity.
			@ErrorState -- State.
			);

	END CATCH
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.crearItemFactura
@nro_factura numeric(18,0), 
@id_publicacion numeric(18,0),
@id_compra numeric(18,0),
@cantidad numeric(18,0), 
@monto numeric(18,2),
@resumen nvarchar(255)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			DECLARE @pub_visibilidad_Id INT
			DECLARE @pub_usu_Id INT
			DECLARE @esCompra bit
			
			INSERT INTO DATA_GROUP.ItemFactura( nro_factura, 
												id_publicacion,
												id_compra,
												cantidad, 
												monto, 
												resumen)
			Values(@nro_factura, @id_publicacion, @id_compra, @cantidad, @monto, @resumen)
			
			if @id_compra=0 --Es publicacion
			BEGIN
				UPDATE DATA_GROUP.Publicacion
				SET facturada = 1
				WHERE id_publicacion=@id_publicacion
			END
			ELSE
			BEGIN
				UPDATE DATA_GROUP.Compra
				SET facturada = 1
				WHERE id_compra = @id_compra
			END
			
			DECLARE @id_visibilidad_fact numeric(18,0)
			DECLARE @id_usuario_fact numeric(18,0)
			
			SELECT @id_visibilidad_fact=id_visibilidad, @id_usuario_fact=id_usuario_publicador
			FROM DATA_GROUP.Publicacion 
			WHERE id_publicacion=@id_publicacion
			
			if @resumen not like '%bonif%'
				UPDATE DATA_GROUP.CantVisibilidadesFacturadasPorUsuario
				SET cantidad_fact=cantidad_fact+1
				WHERE id_visibilidad_fact=@id_visibilidad_fact AND id_usuario_fact=@id_usuario_fact
		
		 COMMIT TRAN
	 END TRY
	 BEGIN CATCH
		 ROLLBACK TRAN
		
		 DECLARE @ErrorMessage NVARCHAR(4000);
		 DECLARE @ErrorSeverity INT;
		 DECLARE @ErrorState INT;

		 SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		 RAISERROR (@ErrorMessage, -- Message text.
				@ErrorSeverity, -- Severity.
				@ErrorState -- State.
				);

	 END CATCH
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTodasLasFuncionalidadesHabilitadas
AS
BEGIN
	
	SELECT Funcionalidad.id_funcionalidad, nombre
	FROM DATA_GROUP.Funcionalidad
	WHERE habilitada=1
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getTodasLasFuncionalidades
AS
BEGIN
	
	SELECT id_funcionalidad, nombre, habilitada
	FROM DATA_GROUP.Funcionalidad
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getFuncionalidadDeUnRol(
	@id_rol numeric(18,0))
AS
BEGIN

	SELECT f.id_funcionalidad, f.nombre, f.habilitada
	FROM DATA_GROUP.Funcionalidad f
	JOIN DATA_GROUP.FuncionalidadXRol fr 
	ON fr.id_rol=@id_rol AND fr.id_funcionalidad=f.id_funcionalidad
	WHERE fr.habilitada=1 AND f.habilitada=1
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getFuncDeUnRolHabilYNoHabilitadas
@id_rol numeric(18,0)
AS
BEGIN
SELECT f.id_funcionalidad, f.nombre, CASE   WHEN f.id_funcionalidad IN (SELECT fr.id_funcionalidad FROM DATA_GROUP.FuncionalidadXRol fr WHERE fr.id_rol=@id_rol and fr.habilitada=1)
											THEN 1
											ELSE 0
									 END habilitada
FROM DATA_GROUP.Funcionalidad f
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[realizar_identificacion](
	@username nvarchar(255),
	@passwordHash nvarchar(255),
	@resultado int OUTPUT
	)
AS
BEGIN
	--  0 Exito
	--  1 Bloqueado
	--  2 Usuario invalido o contrasena falsa

	DECLARE @hashReal nvarchar(255)
	DECLARE @fallidos int
	
	SELECT @hashReal=us.contrasenia, @fallidos=us.intentos_login
	FROM DATA_GROUP.Usuario us
	WHERE us.username = @username
	
	IF @@ROWCOUNT = 0
	BEGIN
		--Usuario invalido
		SET @resultado = -2
		RETURN
	END
	
	IF @fallidos >= 3
	BEGIN
		--Usuario bloqueado
		SET @resultado = -1
		RETURN
	END
	
	IF @hashReal = @passwordHash
	BEGIN
		--Exito
		UPDATE DATA_GROUP.Usuario
		SET intentos_login = 0
		WHERE username = @username
		
		SET @resultado = 0
		
		RETURN
	END
	
	--Password incorrecto
	UPDATE DATA_GROUP.Usuario
	SET intentos_login = (intentos_login + 1)
	WHERE username = @username
	
	SET @resultado = -2
	RETURN
		
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevaRespuesta
@id_pregunta numeric(18,0),
@respuesta nvarchar(400)
AS
BEGIN
	
	UPDATE DATA_GROUP.Pregunta
	SET respuesta=@respuesta, fecha_respuesta=GETDATE()
	WHERE id_pregunta=@id_pregunta
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getPreguntasSinResponder
@id_vendedor numeric(18,0)
AS
BEGIN

	SELECT  preg.id_pregunta, 
			preg.id_publicacion, 
			preg.id_usuario,
			u.username,
			preg.pregunta, 
			preg.fecha_pregunta, 
			preg.respuesta,
			preg.fecha_respuesta 
	FROM DATA_GROUP.Pregunta preg
	JOIN DATA_GROUP.Publicacion pub on pub.id_publicacion=preg.id_publicacion
	JOIN DATA_GROUP.Usuario u on u.id_usuario=preg.id_usuario
	WHERE pub.id_usuario_publicador=@id_vendedor AND respuesta is null

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getPreguntasYaRespondidas
@id_vendedor numeric(18,0)
AS
BEGIN

	SELECT  preg.id_pregunta, 
			preg.id_publicacion, 
			preg.id_usuario,
			u.username, 
			preg.pregunta, 
			preg.fecha_pregunta, 
			preg.respuesta,
			preg.fecha_respuesta 
	FROM DATA_GROUP.Pregunta preg
	JOIN DATA_GROUP.Publicacion pub on pub.id_publicacion=preg.id_publicacion
	JOIN DATA_GROUP.Usuario u on u.id_usuario=preg.id_usuario
	WHERE pub.id_usuario_publicador=@id_vendedor AND respuesta is not null

END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.getRespuestasDeUnaPublicacion
@id_publicacion numeric(18,0)
AS
BEGIN
	
	SELECT  p.id_pregunta, 
			p.id_publicacion,
			p.id_usuario, 
			u.username,
			u.habilitada,
			p.pregunta, 
			p.fecha_pregunta, 
			p.respuesta, 
			p.fecha_respuesta
	FROM DATA_GROUP.Pregunta p
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario = p.id_usuario
	WHERE p.id_publicacion=@id_publicacion
	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevaPregunta
@id_pregunta numeric(18,0) OUTPUT, 
@id_publicacion numeric(18,0), 
@id_usuario numeric(18, 0),
@pregunta nvarchar(255),
@fecha_pregunta datetime
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO DATA_GROUP.Pregunta(id_publicacion, 
											id_usuario, 
											pregunta, 
											fecha_pregunta)
			VALUES (@id_publicacion, 
					@id_usuario, 
					@pregunta, 
					@fecha_pregunta)
					
			SET @id_pregunta = SCOPE_IDENTITY();
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN

		DECLARE @ErrorMessage NVARCHAR(4000);
	    DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
	END CATCH	
END
GO

-------------------------------------------------------------------------------------

CREATE PROCEDURE DATA_GROUP.nuevaPublicacion
@id_publicacion_nueva numeric(18, 0) OUTPUT,
@descripcion nvarchar(255), 
@stock numeric(18,0), 
@fecha_inicio datetime, 
@fecha_vencimiento datetime, 
@precio numeric(18, 2), 
@permite_preguntas bit, 
@id_tipo_publicacion numeric(18,0), 
@id_visibilidad numeric(18, 0), 
@id_estado numeric(18,0), 
@id_usuario_publicador numeric(18, 0), 
@id_rubro numeric(18, 0), 
@habilitada bit
AS
BEGIN
	
	BEGIN TRY
	
		DECLARE @cantidad_publicaciones_gratuitas_activas numeric(18,0);
		
		SELECT @cantidad_publicaciones_gratuitas_activas=COUNT(*)
		FROM DATA_GROUP.Publicacion p
		WHERE p.id_usuario_publicador=@id_usuario_publicador
			AND p.id_estado=1
			AND p.id_visibilidad=10006

		if @cantidad_publicaciones_gratuitas_activas>=3 AND @id_visibilidad=10006 AND @id_estado=1
		BEGIN
	
			DECLARE @ErrorSeverityGratuita INT;
			DECLARE @ErrorStateGratuita INT;

			SELECT @ErrorSeverityGratuita = ERROR_SEVERITY(), @ErrorStateGratuita = ERROR_STATE();

			RAISERROR ('No puede tener mas de 3 publicaciones gratuitas activas(publicada) al mismo tiempo.', -- Message text.
				   @ErrorSeverityGratuita, -- Severity.
				   @ErrorStateGratuita -- State.
				   );
		END
		ELSE
		BEGIN
			BEGIN TRAN

				DECLARE @max_id numeric(18,0)
				SELECT @max_id = MAX(id_publicacion)+1
				FROM DATA_GROUP.Publicacion;
				
				INSERT INTO DATA_GROUP.Publicacion( id_publicacion,
													descripcion, 
													stock, 
													fecha_inicio, 
													fecha_vencimiento, 
													precio, 
													permite_preguntas, 
													id_tipo_publicacion, 
													id_visibilidad, 
													id_estado, 
													id_usuario_publicador, 
													id_rubro, 
													habilitada,
													facturada)
				VALUES( @max_id,
						@descripcion, 
						@stock, 
						@fecha_inicio, 
						@fecha_vencimiento, 
						@precio, 
						@permite_preguntas, 
						@id_tipo_publicacion, 
						@id_visibilidad, 
						@id_estado, 
						@id_usuario_publicador, 
						@id_rubro, 
						@habilitada,
						0)
						
				SET @id_publicacion_nueva = @max_id
				
				--Publicacion no gratuita
				IF( @id_visibilidad!=10006)
				BEGIN
					IF NOT EXISTS ( SELECT * FROM DATA_GROUP.CantVisibilidadesFacturadasPorUsuario c
									WHERE c.id_usuario_fact = @id_usuario_publicador
									AND c.id_visibilidad_fact = @id_visibilidad)
					BEGIN
						INSERT INTO DATA_GROUP.CantVisibilidadesFacturadasPorUsuario(id_usuario_fact, id_visibilidad_fact, cantidad_fact)
						VALUES(@id_usuario_publicador, @id_visibilidad, 0); --Es por cada factura generada
					END
				END
				
			COMMIT TRAN
			RETURN @id_publicacion_nueva
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
	END CATCH
END
GO

------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[modificarPublicacion]
@id_publicacion_modificar numeric(18, 0),
@descripcion nvarchar(255), 
@stock numeric(18,0), 
@fecha_inicio datetime, 
@fecha_vencimiento datetime, 
@precio numeric(18, 2), 
@permite_preguntas bit, 
@id_tipo_publicacion numeric(18,0), 
@id_visibilidad numeric(18, 0), 
@id_estado numeric(18,0), 
--@id_usuario_publicador numeric(18, 0), 
@id_rubro numeric(18, 0)
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN

			UPDATE DATA_GROUP.Publicacion
			SET descripcion = @descripcion, 
				stock = @stock, 
				fecha_inicio = @fecha_inicio, 
				fecha_vencimiento = @fecha_vencimiento, 
				precio = @precio, 
				permite_preguntas = @permite_preguntas, 
				id_tipo_publicacion = @id_tipo_publicacion, 
				id_visibilidad = @id_visibilidad, 
				id_estado = @id_estado, 
				id_rubro = @id_rubro
			WHERE id_publicacion=@id_publicacion_modificar
						
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
	END CATCH
END
GO

------------------------------------------------------------------------------------------

CREATE PROCEDURE [DATA_GROUP].[sp_publicacion_filter](
	@descripcion nvarchar(255) = NULL,
	@fecha_inicio datetime = NULL,
	@fecha_vencimiento datetime = NULL,
	@id_visibilidad numeric(18,0) = NULL,
	@id_estado numeric(18,0) = NULL,
	@id_rubro numeric(18,0) = NULL,
	@id_tipo_publicacion numeric(18,0) = NULL,
	@id_usuario_publicador numeric(18,0) = NULL
)
AS
BEGIN
	SELECT  p.id_publicacion,
			p.descripcion,
			p.fecha_inicio,
			p.fecha_vencimiento,
			p.habilitada,
			p.permite_preguntas,
			p.stock,
			p.precio,
			p.id_estado,
			est.descripcion descEstado,
			p.id_rubro,
			rub.descripcion descRubro,
			p.id_tipo_publicacion,
			tipPub.descripcion descTipoPubli,
			p.id_visibilidad,
			visi.descripcion descVisi,
			p.id_usuario_publicador,
			u.username
	FROM DATA_GROUP.Publicacion p
	INNER JOIN DATA_GROUP.EstadoPublicacion est
	ON est.id_estado=p.id_estado
	INNER JOIN DATA_GROUP.Rubro rub
	ON rub.id_rubro=p.id_rubro
	INNER JOIN DATA_GROUP.TipoPublicacion tipPub
	ON tipPub.id_tipo_publicacion=p.id_tipo_publicacion
	INNER JOIN DATA_GROUP.VisibilidadPublicacion visi
	ON visi.id_visibilidad=p.id_visibilidad
	INNER JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=p.id_usuario_publicador
	WHERE  ((@id_usuario_publicador IS NULL) OR (p.id_usuario_publicador=@id_usuario_publicador))
	  AND ((@id_rubro IS NULL) OR (p.id_rubro = @id_rubro ))
	  AND ((@id_estado IS NULL) OR (p.id_estado = @id_estado))
	  AND ((@id_visibilidad IS NULL) OR (p.id_visibilidad = @id_visibilidad))
	  AND ((@descripcion IS NULL) OR ( p.descripcion like '%'+ @descripcion +'%'))
	  AND ((@id_tipo_publicacion IS NULL) OR (p.id_tipo_publicacion=@id_tipo_publicacion))
	  AND ((@fecha_inicio IS NULL) OR (p.fecha_inicio = @fecha_inicio))
	  AND ((@fecha_vencimiento IS NULL) OR (p.fecha_vencimiento = @fecha_vencimiento))
	ORDER BY p.id_visibilidad ASC

END
GO

------------------------------------------------------------------------------------------

