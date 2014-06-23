

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

IF OBJECT_ID('DATA_GROUP.modificarEmpresa') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.modificarEmpresa
	GO
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

---------------------------------Filtro de Empresa-------------------------------

IF OBJECT_ID('DATA_GROUP.sp_empresa_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_empresa_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_empresa_filter
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






