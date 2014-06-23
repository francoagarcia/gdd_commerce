

------------------------------------------------------------
--------------------------Login-----------------------------
------------------------------------------------------------

IF OBJECT_ID('DATA_GROUP.realizar_identificacion') is not null
	DROP PROCEDURE DATA_GROUP.realizar_identificacion;
	GO
IF OBJECT_ID('DATA_GROUP.realizar_identificacion') is not null
	DROP PROCEDURE DATA_GROUP.realizar_identificacion;
	GO
CREATE PROCEDURE DATA_GROUP.realizar_identificacion(
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
