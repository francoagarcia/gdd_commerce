
IF OBJECT_ID('DATA_GROUP.getTodasLasFuncionalidadesHabilitadas') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasFuncionalidadesHabilitadas
	GO
CREATE PROCEDURE DATA_GROUP.getTodasLasFuncionalidadesHabilitadas
AS
BEGIN
	
	SELECT Funcionalidad.id_funcionalidad, nombre
	FROM DATA_GROUP.Funcionalidad
	WHERE habilitada=1
	
END
GO

IF OBJECT_ID('DATA_GROUP.getTodasLasFuncionalidades') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasFuncionalidades
	GO
CREATE PROCEDURE DATA_GROUP.getTodasLasFuncionalidades
AS
BEGIN
	
	SELECT Funcionalidad.id_funcionalidad, nombre
	FROM DATA_GROUP.Funcionalidad
	
END
GO

IF OBJECT_ID('DATA_GROUP.getFuncionalidadDeUnRol') is not null
	DROP PROCEDURE DATA_GROUP.getFuncionalidadDeUnRol
	GO
CREATE PROCEDURE DATA_GROUP.getFuncionalidadDeUnRol(
	@id_rol numeric(18,0))
AS
BEGIN

	SELECT f.id_funcionalidad, f.nombre, f.habilitada
	FROM DATA_GROUP.Funcionalidad f
	JOIN DATA_GROUP.FuncionalidadXRol fr 
	ON fr.id_rol=@id_rol AND fr.id_funcionalidad=f.id_funcionalidad
	WHERE fr.habilitada=1 AND f.habilitada=1
	
END
GO