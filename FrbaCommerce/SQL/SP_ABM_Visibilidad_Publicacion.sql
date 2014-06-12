




IF OBJECT_ID('DATA_GROUP.nuevaVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.nuevaVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.nuevaVisibilidad
@descripcion nvarchar(255),
@precio numeric(18, 2),
@porcentaje numeric(18, 2),
@id_visibilidad_agregado numeric(18, 0) OUTPUT
AS
BEGIN

	BEGIN TRAN
		DECLARE @id_nuevo numeric(18, 0)
		SET @id_nuevo=(SELECT MAX(id_visibilidad) FROM DATA_GROUP.VisibilidadPublicacion)+1
		
		INSERT INTO DATA_GROUP.VisibilidadPublicacion(id_visibilidad, descripcion, porcentaje, precio)
		VALUES(@id_nuevo, @descripcion, @porcentaje, @precio)
		
		SET @id_visibilidad_agregado = @id_nuevo;
	COMMIT TRAN
END
GO


IF OBJECT_ID('DATA_GROUP.modificarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.modificarVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.modificarVisibilidad
@id_visibilidad_a_modificar numeric(18,0),
@descripcion nvarchar(255),
@precio numeric(18, 2),
@porcentaje numeric(18, 2)
AS
BEGIN
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET descripcion=@descripcion, 
		precio=@precio, 
		porcentaje=@porcentaje
	WHERE id_visibilidad=@id_visibilidad_a_modificar;
END
GO



IF OBJECT_ID('DATA_GROUP.inhabilitarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.inhabilitarVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.inhabilitarVisibilidad
@id_visibilidad numeric(18,0)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET habilitada=0
	WHERE id_visibilidad=@id_visibilidad
	
END
GO


IF OBJECT_ID('DATA_GROUP.habilitarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.habilitarVisibilidad
	GO
CREATE PROCEDURE DATA_GROUP.habilitarVisibilidad
@id_visibilidad numeric(18,0)
AS
BEGIN
		
	UPDATE DATA_GROUP.VisibilidadPublicacion
	SET habilitada=1
	WHERE id_visibilidad=@id_visibilidad
	
END
GO


IF OBJECT_ID('DATA_GROUP.getTodasLasVisibilidades') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasVisibilidades
	GO
CREATE PROCEDURE DATA_GROUP.getTodasLasVisibilidades
AS
BEGIN
	select id_visibilidad, descripcion, precio, porcentaje
	from DATA_GROUP.VisibilidadPublicacion
	where habilitada=1;
END
GO





IF OBJECT_ID('DATA_GROUP.sp_Visibilidad_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_Visibilidad_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_Visibilidad_filter(
	@descripcion nvarchar(255) = NULL,
	@precio numeric(18, 2)  = NULL,
	@porcentaje numeric(18, 2) = NULL
)
AS
BEGIN

	SELECT id_visibilidad, descripcion, precio, porcentaje, habilitada
	FROM DATA_GROUP.VisibilidadPublicacion
	WHERE ((@descripcion IS NULL) OR (descripcion like '%' + @descripcion + '%'))
  AND ((@precio IS NULL) OR (@precio = precio ))
  AND ((@porcentaje IS NULL) OR ((@porcentaje = porcentaje)))

END
GO