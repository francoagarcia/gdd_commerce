

-----------------------------------------------------

IF OBJECT_ID('DATA_GROUP.asociarRolAUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.asociarRolAUsuario
	GO
CREATE PROCEDURE DATA_GROUP.asociarRolAUsuario
@id_rol numeric(18, 0),
@id_usuario numeric(18, 0)
AS
BEGIN
	INSERT INTO DATA_GROUP.UsuarioXRol(id_rol, id_usuario)
	VALUES(@id_rol, @id_usuario);
END
GO

-----------------------------------------------------




IF OBJECT_ID('DATA_GROUP.getIdRolPorNombre') IS NOT NULL
	DROP FUNCTION DATA_GROUP.getIdRolPorNombre
	GO
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


IF OBJECT_ID('DATA_GROUP.getTodosLosRoles') is not null
	DROP PROCEDURE DATA_GROUP.getTodosLosRoles
	GO
CREATE PROCEDURE DATA_GROUP.getTodosLosRoles
AS
BEGIN
	select id_rol, nombre, habilitada
	from DATA_GROUP.Rol
END
GO

IF OBJECT_ID('DATA_GROUP.getRolesDeUsuario') is not null
	DROP PROCEDURE DATA_GROUP.getRolesDeUsuario
	GO
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

IF OBJECT_ID('DATA_GROUP.sp_rol_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_rol_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_rol_filter(
	@nombre nvarchar(255) = NULL
)
AS
BEGIN

SELECT id_rol, nombre, habilitada 
FROM DATA_GROUP.Rol
WHERE ((@nombre is null) OR (nombre like '%' + @nombre + '%'))

END
GO


IF OBJECT_ID('DATA_GROUP.modificarRol') is not null
	DROP PROCEDURE DATA_GROUP.modificarRol
	GO
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


IF OBJECT_ID('DATA_GROUP.modificarFuncionalidadDeUnRol') is not null
	DROP PROCEDURE DATA_GROUP.modificarFuncionalidadDeUnRol
	GO
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



IF OBJECT_ID('DATA_GROUP.SP_deshabilitarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_deshabilitarRol
	GO
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


IF OBJECT_ID('DATA_GROUP.SP_habilitarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_habilitarRol
	GO
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


IF OBJECT_ID('DATA_GROUP.SP_agregarFuncionalidadXRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregarFuncionalidadXRol
	GO
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



IF OBJECT_ID('DATA_GROUP.SP_crearRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_crearRol
	GO
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