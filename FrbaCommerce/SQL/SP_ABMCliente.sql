
----------------------CREAR CLIENTE--------------------------
IF OBJECT_ID('DATA_GROUP.nuevoCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoCliente
	GO
CREATE PROCEDURE DATA_GROUP.nuevoCliente
@tipo_documento nvarchar(255), --Buscar en otra tabla 
@nro_documento numeric(18, 0), 
@nombre_de_usuario nvarchar(255), --Buscar en otra tabla y poner el tipo de usuario correspondiente
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@nombre nvarchar(255), 
@apellido nvarchar(255), 
@dom_calle nvarchar(255), 
@nro_calle numeric(18, 0), 
@piso numeric(18, 0), 
@depto nvarchar(50), 
@localidad nvarchar(255), 
@cod_postal nvarchar(50), 
@mail nvarchar(255), 
@fecha_nacimiento datetime, 
@sexo bit --1 es masculino, 0 es femenino
AS
BEGIN
	DECLARE @id_tipo_doc numeric(18, 0)
	DECLARE @id_usuario numeric(18, 0)
	
	SELECT @id_tipo_doc=id_tipo_documento
	FROM DATA_GROUP.TipoDocumento
	WHERE descripcion=@tipo_documento
	
	EXEC DATA_GROUP.nuevoUsuario @username=@nombre_de_usuario, @contrasenia=@contrasenia_usuario, @telefono=@telefono_usuario, @tipoUsuario='CLI'
	
	SELECT @id_usuario=id_usuario
	FROM DATA_GROUP.Usuario
	WHERE username=@nombre_de_usuario
	
	INSERT INTO DATA_GROUP.Cliente(id_tipo_documento, nro_documento, id_usuario, nombre, apellido, dom_calle, nro_calle, piso, depto, localidad, cod_postal, mail, fecha_nacimiento, sexo)
							VALUES (@id_tipo_doc, @nro_documento, @id_usuario, @nombre, @apellido, @dom_calle, @nro_calle, @piso, @depto, @localidad, @cod_postal, @mail, @fecha_nacimiento, @sexo)
							
END
GO



----------------------MODIFICAR CLIENTE--------------------------

IF OBJECT_ID('DATA_GROUP.modificarCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.modificarCliente
	GO
CREATE PROCEDURE DATA_GROUP.modificarCliente
@tipo_documento nvarchar(255), --Buscar en otra tabla 
@nro_documento numeric(18, 0), 
@nombre_de_usuario nvarchar(255), --Buscar en otra tabla y poner el tipo de usuario correspondiente
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@nombre nvarchar(255), 
@apellido nvarchar(255), 
@dom_calle nvarchar(255), 
@nro_calle numeric(18, 0), 
@piso numeric(18, 0), 
@depto nvarchar(50), 
@localidad nvarchar(255), 
@cod_postal nvarchar(50), 
@mail nvarchar(255), 
@sexo bit --1 es masculino, 0 es femenino
AS
BEGIN

	DECLARE @id_documento NUMERIC(18, 0)
	SET @id_documento = (SELECT id_tipo_documento FROM DATA_GROUP.TipoDocumento WHERE descripcion=@tipo_documento)

	DECLARE @id_user NUMERIC(18, 0)
	SELECT @id_user=id_usuario FROM DATA_GROUP.Cliente WHERE id_tipo_documento=@id_documento AND nro_documento=@nro_documento
	
	EXEC DATA_GROUP.modificarUsuario @id_usuario=@id_user, @username=@nombre_de_usuario, @contrasenia=@contrasenia_usuario, @telefono=@telefono_usuario
		
	UPDATE DATA_GROUP.Cliente
	SET 
		nombre=@nombre, 
		apellido=@apellido, 
		dom_calle=@dom_calle, 
		nro_calle=@nro_calle, 
		piso=@piso, 
		depto=@depto, 
		localidad=@localidad, 
		cod_postal=@cod_postal, 
		mail=@mail, 
		sexo=@sexo
	WHERE id_tipo_documento=@id_documento AND nro_documento=@nro_documento

END
GO
----------------------HABILITACION DE CLIENTE--------------------------



IF OBJECT_ID('DATA_GROUP.deshabilitarCliente') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.deshabilitarCliente
	GO
CREATE PROCEDURE DATA_GROUP.deshabilitarCliente
@tipo_documento nvarchar(255),
@nro_documento numeric(18, 0)
AS
BEGIN

	DECLARE @id_tipo_doc numeric(18, 0)
	SELECT @id_tipo_doc=id_tipo_documento
	FROM DATA_GROUP.TipoDocumento
	WHERE descripcion=@tipo_documento
	
	DECLARE @id_usu_deshabilitado numeric(18, 0)
	SET @id_usu_deshabilitado = (SELECT id_usuario FROM DATA_GROUP.Cliente WHERE id_tipo_documento=@id_tipo_doc AND nro_documento=@nro_documento)
	
	UPDATE DATA_GROUP.Usuario
	SET habilitada=0
	WHERE id_usuario=@id_usu_deshabilitado
	
END
GO


IF OBJECT_ID('DATA_GROUP.habilitarCliente') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.habilitarCliente
	GO

CREATE PROCEDURE DATA_GROUP.habilitarCliente
@tipo_documento nvarchar(255),
@nro_documento numeric(18, 0)
AS
BEGIN

	DECLARE @id_tipo_doc numeric(18, 0)
	SELECT @id_tipo_doc=id_tipo_documento
	FROM DATA_GROUP.TipoDocumento
	WHERE descripcion=@tipo_documento
	
	DECLARE @id_usu_deshabilitado numeric(18, 0)
	SET @id_usu_deshabilitado = (SELECT id_usuario FROM DATA_GROUP.Cliente WHERE id_tipo_documento=@id_tipo_doc AND nro_documento=@nro_documento)
	
	UPDATE DATA_GROUP.Usuario
	SET habilitada=1
	WHERE id_usuario=@id_usu_deshabilitado
	
END
GO









































