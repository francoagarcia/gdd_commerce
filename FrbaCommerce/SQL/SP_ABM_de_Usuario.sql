
----------------------NUEVO USUARIO--------------------------

IF OBJECT_ID('DATA_GROUP.nuevoUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoUsuario
	GO
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

---------------Setear cantidad de intentos-----------
IF OBJECT_ID('DATA_GROUP.setCantidadIntentos') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.setCantidadIntentos
	GO
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

----------------------Gets de usuario--------------------------
If OBJECT_ID('DATA_GROUP.getUsuarioByUsername') is not null
	DROP PROCEDURE DATA_GROUP.getUsuarioByUsername
	GO
CREATE PROCEDURE DATA_GROUP.getUsuarioByUsername(
	@username nvarchar(255))
AS
BEGIN

	SELECT u.id_usuario, u.username, u.contrasenia, u.intentos_login, u.habilitada
	FROM DATA_GROUP.Usuario u
	WHERE u.username=@username AND u.habilitada=1

 END
GO


----------------------MODIFICAR USUARIO--------------------------
IF OBJECT_ID('DATA_GROUP.modificarUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.modificarUsuario
	GO
CREATE PROCEDURE DATA_GROUP.modificarUsuario
@id_usuario numeric(18, 0),
@username nvarchar(255),
@contrasenia nvarchar(255),
@telefono numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET contrasenia=@contrasenia, telefono=@telefono, username=@username
	WHERE id_usuario=@id_usuario
END
GO

----------------------EXISTE USUARIO--------------------------
IF OBJECT_ID('DATA_GROUP.existeUsuario') is not null
	DROP PROCEDURE DATA_GROUP.existeUsuario
	GO
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

----------------------HABILITACION DE USUARIO--------------------------

IF OBJECT_ID('DATA_GROUP.habilitarUsuario') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.habilitarUsuario
	GO
CREATE PROCEDURE DATA_GROUP.habilitarUsuario
@username numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET habilitada=1
	WHERE username=@username
END
GO


IF OBJECT_ID('DATA_GROUP.deshabilitarUsuario') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.deshabilitarUsuario
	GO
CREATE PROCEDURE DATA_GROUP.deshabilitarUsuario
@username numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET habilitada=0
	WHERE username=@username
END
GO
