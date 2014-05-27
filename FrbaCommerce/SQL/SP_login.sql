
IF OBJECT_ID('DATA_GROUP.SP_aumentarIntentosDeLogueo') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_aumentarIntentosDeLogueo
	GO
CREATE PROCEDURE DATA_GROUP.SP_aumentarIntentosDeLogueo
@username nvarchar(255)
AS
BEGIN
	IF EXISTS(SELECT username FROM DATA_GROUP.Usuario WHERE username=@username)
		UPDATE DATA_GROUP.Usuario
		SET intentos_login=intentos_login+1
		WHERE username=@username
END
GO


IF OBJECT_ID('DATA_GROUP.SP_reiniciarContadorDeIntentosDeLogueo') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_reiniciarContadorDeIntentosDeLogueo
	GO
CREATE PROCEDURE DATA_GROUP.SP_reiniciarContadorDeIntentosDeLogueo
@username nvarchar(255)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET intentos_login=0
	WHERE username=@username
END
GO


IF OBJECT_ID('DATA_GROUP.SP_login') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_login
	GO
CREATE PROCEDURE DATA_GROUP.SP_login
	(@username_login nvarchar(255), @contrasenia nvarchar(255), @id_usuario numeric(18,0) OUTPUT) 	
AS
BEGIN	
	SET @id_usuario = (SELECT U.id_usuario FROM DATA_GROUP.Usuario U WHERE U.username = @username_login AND U.contrasenia = @contrasenia)
	
	IF @id_usuario is null
		BEGIN
			EXEC DATA_GROUP.SP_aumentarIntentosDeLogueo @username=@username_login
			RAISERROR('Error en inicio de sesion ', -1, -1, 'El usuario no existe o la contraseña es incorrecta')
		END
	ELSE 
		EXEC DATA_GROUP.SP_reiniciarContadorDeIntentosDeLogueo @username=@username_login
	
END
GO

