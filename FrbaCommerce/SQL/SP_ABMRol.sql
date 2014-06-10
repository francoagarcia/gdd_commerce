
IF OBJECT_ID('DATA_GROUP.SP_deshabilitarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_deshabilitarRol
	GO
CREATE PROCEDURE DATA_GROUP.SP_deshabilitarRol
(@nombreRol nvarchar(255))
AS
BEGIN
	UPDATE DATA_GROUP.Rol SET habilitada=0 WHERE nombre=@nombreRol
END
GO


IF OBJECT_ID('DATA_GROUP.SP_habilitarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_habilitarRol
	GO
CREATE PROCEDURE DATA_GROUP.SP_habilitarRol
(@nombreRol nvarchar(255))
AS
BEGIN
	UPDATE DATA_GROUP.Rol SET habilitada=1 WHERE nombre=@nombreRol
END
GO


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

IF OBJECT_ID('DATA_GROUP.SP_modificarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_modificarRol
	GO
CREATE PROCEDURE DATA_GROUP.SP_modificarRol
(@nombreViejo nvarchar(255), @nombreNuevo nvarchar(255)) 
AS
BEGIN	
	UPDATE DATA_GROUP.ROL 
	SET nombre = @nombreNuevo
	WHERE nombre = @nombreViejo
END
GO


IF OBJECT_ID('DATA_GROUP.SP_crearRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_crearRol
	GO
CREATE PROCEDURE DATA_GROUP.SP_crearRol
(@nombreRolNuevo nvarchar(255))
AS
BEGIN
	IF(NOT EXISTS(SELECT nombre FROM DATA_GROUP.Rol WHERE nombre=@nombreRolNuevo))
		INSERT INTO DATA_GROUP.Rol (nombre) VALUES (@nombreRolNuevo)
END
GO


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


IF OBJECT_ID('DATA_GROUP.SP_agregarFuncionalidadXRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregarFuncionalidadXRol
	GO
CREATE PROCEDURE DATA_GROUP.SP_agregarFuncionalidadXRol
(@func_to_rol nvarchar(255), @rol_to_func nvarchar(255))
AS
BEGIN
	DECLARE @funcionalidad_id numeric(18, 0)
	DECLARE @rol_id numeric(18, 0)

	SELECT @rol_id=id_rol 
	FROM DATA_GROUP.Rol 
	WHERE nombre=@rol_to_func;
	
	SELECT @funcionalidad_id=id_funcionalidad 
	FROM DATA_GROUP.Funcionalidad 
	WHERE nombre=@func_to_rol;
	
	INSERT INTO DATA_GROUP.FuncionalidadXRol(id_funcionalidad, id_rol)
	VALUES (@funcionalidad_id, @rol_id);
		
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

	
