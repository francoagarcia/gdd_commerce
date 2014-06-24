



----------------------------------------------------
IF OBJECT_ID('DATA_GROUP.nuevoCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoCliente
	GO
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

----------------------MODIFICAR CLIENTE--------------------------

IF OBJECT_ID('DATA_GROUP.modificarCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.modificarCliente
	GO
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




----------------------------------FILTRO DE CLIENTE--------------------------------

IF OBJECT_ID('DATA_GROUP.sp_cliente_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_cliente_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_cliente_filter(
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


