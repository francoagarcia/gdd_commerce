
----------------------NUEVO USUARIO--------------------------
IF OBJECT_ID('DATA_GROUP.nuevoUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoUsuario
	GO
CREATE PROCEDURE DATA_GROUP.nuevoUsuario
@username nvarchar(255),
@contrasenia nvarchar(255),
@telefono numeric(18, 0),
@tipoUsuario nvarchar(3)
AS
BEGIN
	INSERT INTO DATA_GROUP.Usuario(username, contrasenia, telefono, intentos_login, tipo_usuario)
	VALUES(@username, @contrasenia, @telefono, 0, @tipoUsuario)
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

----------------------Get usuario--------------------------
IF OBJECT_ID('DATA_GROUP.getUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getUsuario
	GO
CREATE PROCEDURE DATA_GROUP.getUsuario
@username nvarchar(255)
AS
BEGIN
	SELECT u.username, u.id_usuario, u.contrasenia, u.intentos_login, u.habilitada
	FROM DATA_GROUP.Usuario u
	WHERE u.username=@username AND u.habilitada=1;
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

