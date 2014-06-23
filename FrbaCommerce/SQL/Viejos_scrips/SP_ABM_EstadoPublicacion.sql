


IF OBJECT_ID('DATA_GROUP.sp_EstadoPublicacion_select_all') is not null
	DROP PROCEDURE DATA_GROUP.sp_EstadoPublicacion_select_all
	GO
CREATE PROCEDURE DATA_GROUP.sp_EstadoPublicacion_select_all
AS
BEGIN
	SELECT id_estado, descripcion
	FROM DATA_GROUP.EstadoPublicacion;
END
GO