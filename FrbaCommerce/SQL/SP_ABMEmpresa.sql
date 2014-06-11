

--------------------------Nueva Empresa---------------------------

IF OBJECT_ID('DATA_GROUP.nuevaEmpresa') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevaEmpresa
	GO
CREATE PROCEDURE DATA_GROUP.nuevaEmpresa(
@id_usuario_agregado numeric(18, 0) OUTPUT,
@nombre_de_usuario nvarchar(255), 
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@cuit nvarchar(50), 
@razon_social nvarchar(50), 
@mail nvarchar(50), 
@dom_calle nvarchar(255), 
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
		BEGIN TRAN
		
		DECLARE @id_usuario_new numeric(18,0);
		
		EXEC DATA_GROUP.nuevoUsuario @nombre_de_usuario, @contrasenia_usuario, @telefono_usuario, 'EMP', @id_usuario_new OUTPUT
		
		DECLARE @id_rol_for_new_user numeric(18) = (SELECT TOP 1 id_rol FROM DATA_GROUP.Rol WHERE nombre = 'Empresa')
		
		EXECUTE DATA_GROUP.asociarRolAUsuario @id_rol_for_new_user, @id_usuario_new
		
		-- Creo el registro del cliente
		INSERT INTO DATA_GROUP.Empresa(cuit, 
									   razon_social, 
									   id_usuario, 
									   mail, 
									   dom_calle, 
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
			@piso, 
			@depto, 
			@localidad, 
			@cod_postal, 
			@ciudad, 
			@nombre_de_contacto, 
			@fecha_creacion)
				
		SET @id_usuario_agregado = SCOPE_IDENTITY();

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

---------------------------------Modificar Empresa-------------------------------
IF OBJECT_ID('DATA_GROUP.modificarEmpresa') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.modificarEmpresa
	GO
CREATE PROCEDURE DATA_GROUP.modificarEmpresa
@cuit nvarchar(50), 
@razon_social nvarchar(50), 
@nombre_de_usuario nvarchar(255),
@contrasenia_usuario nvarchar(255),
@telefono_usuario numeric(18, 0),
@mail nvarchar(50), 
@dom_calle nvarchar(255), 
@piso numeric(18, 0),
@depto nvarchar(50),
@localidad nvarchar(255),
@nro_calle numeric(18, 0),
@cod_postal nvarchar(50),
@ciudad nvarchar(255),
@nombre_de_contacto nvarchar(255)
AS
BEGIN
	
	DECLARE @id_user numeric(18, 0)
	SELECT @id_user=id_usuario
	FROM DATA_GROUP.Empresa
	WHERE cuit=@cuit AND razon_social=@razon_social
	
	EXEC DATA_GROUP.modificarUsuario @id_usuario=@id_user, @username=@nombre_de_usuario, @contrasenia=@contrasenia_usuario, @telefono=@telefono_usuario
	
	UPDATE DATA_GROUP.Empresa
	SET 
		mail=@mail, 
		dom_calle=@dom_calle, 
		piso=@piso, 
		depto=@depto, 
		localidad=@localidad, 
		nro_calle=@nro_calle, 
		cod_postal=@cod_postal, 
		ciudad=@ciudad, 
		nombre_de_contacto=@nombre_de_contacto
	WHERE cuit=@cuit AND razon_social=@razon_social
	
END
GO

---------------------------------Habilitacion de Empresa-------------------------------


IF OBJECT_ID('DATA_GROUP.deshabilitarEmpresa') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.deshabilitarEmpresa
	GO
CREATE PROCEDURE DATA_GROUP.deshabilitarEmpresa
@cuit nvarchar(50),
@razon_social nvarchar(255)
AS
BEGIN

	DECLARE @id_usu_deshabilitado numeric(18, 0)
	SET @id_usu_deshabilitado = (SELECT id_usuario FROM DATA_GROUP.Empresa WHERE cuit=@cuit AND razon_social=@razon_social)
	
	UPDATE DATA_GROUP.Usuario
	SET habilitada=0
	WHERE id_usuario=@id_usu_deshabilitado
	
END
GO


IF OBJECT_ID('DATA_GROUP.habilitarEmpresa') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.habilitarEmpresa
	GO

CREATE PROCEDURE DATA_GROUP.habilitarEmpresa
@cuit nvarchar(50),
@razon_social nvarchar(255)
AS
BEGIN

	DECLARE @id_usu_deshabilitado numeric(18, 0)
	SET @id_usu_deshabilitado = (SELECT id_usuario FROM DATA_GROUP.Empresa WHERE cuit=@cuit AND razon_social=@razon_social)
	
	UPDATE DATA_GROUP.Usuario
	SET habilitada=0
	WHERE id_usuario=@id_usu_deshabilitado
	
END
GO








