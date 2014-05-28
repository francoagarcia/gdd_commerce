


IF OBJECT_ID('DATA_GROUP.nuevaVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.nuevaVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.nuevaVisibilidad
@descripcion nvarchar(255),
@precio numeric(18, 2),
@porcentaje numeric(18, 2)
AS
BEGIN
	DECLARE @id_nuevo numeric(18, 0)
	SET @id_nuevo=(SELECT MAX(id_visibilidad) FROM DATA_GROUP.VisibilidadPublicacion)+1
	
	INSERT INTO DATA_GROUP.VisibilidadPublicacion(id_visibilidad, descripcion, porcentaje, precio)
	VALUES(@id_nuevo, @descripcion, @porcentaje, @precio)
END
GO


IF OBJECT_ID('DATA_GROUP.modificarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.modificarVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.modificarVisibilidad
@descripcion nvarchar(255),
@precio numeric(18, 2),
@porcentaje numeric(18, 2)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET descripcion=@descripcion, precio=@precio, porcentaje=@porcentaje
	WHERE descripcion=@descripcion
	
END
GO

IF OBJECT_ID('DATA_GROUP.inhabilitarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.inhabilitarVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.inhabilitarVisibilidad
@descripcion nvarchar(255)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET habilitada=0
	WHERE descripcion=@descripcion
	
END
GO


IF OBJECT_ID('DATA_GROUP.inhabilitarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.habilitarVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.habilitarVisibilidad
@descripcion nvarchar(255)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET habilitada=1
	WHERE descripcion=@descripcion
	
END
GO