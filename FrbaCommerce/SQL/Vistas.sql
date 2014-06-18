



CREATE VIEW DATA_GROUP.view_publicaciones_x_visibilidad(id_vendedor, id_visibilidad, cantidad)
AS
SELECT p.id_usuario_publicador, p.id_visibilidad, COUNT(p.id_visibilidad)
FROM DATA_GROUP.Publicacion p
GROUP BY p.id_visibilidad, p.id_usuario_publicador
GO

IF OBJECT_ID('DATA_GROUP.getPublicacionesARendir') is not null
	DROP PROCEDURE DATA_GROUP.getPublicacionesARendir
	GO
CREATE PROCEDURE DATA_GROUP.getPublicacionesARendir
@id_vendedor numeric(18,0)
AS
BEGIN

	SELECT id_vendedor, id_visibilidad, cantidad 
	FROM DATA_GROUP.view_publicaciones_x_visibilidad 
	WHERE id_vendedor=@id_vendedor
	ORDER BY id_vendedor ASC, id_visibilidad ASC

END
GO