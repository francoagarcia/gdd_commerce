

IF OBJECT_ID('DATA_GROUP.getTodasComprasRealizadas') is not null
	DROP PROCEDURE DATA_GROUP.getTodasComprasRealizadas
	GO
CREATE PROCEDURE DATA_GROUP.getTodasComprasRealizadas
@username nvarchar(255)
AS
BEGIN
	SELECT c.id_compra
	FROM DATA_GROUP.Compra c
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=c.id_usuario_comprador AND u.username=@username
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=c.id_publicacion AND p.id_tipo_publicacion=1
END


IF OBJECT_ID('DATA_GROUP.getTodasLasOfertasRealizadas') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasOfertasRealizadas
	GO
CREATE PROCEDURE DATA_GROUP.getTodasLasOfertasRealizadas
@username nvarchar(255)
AS
BEGIN
	DECLARE @id_usuario numeric(18, 0)
	SET @id_usuario=(SELECT id_usuario FROM DATA_GROUP.Usuario WHERE username=@username)

	SELECT c.id_compra, 'Oferta ganada'
	FROM DATA_GROUP.Compra c
	JOIN DATA_GROUP.Publicacion p
	ON c.id_publicacion=p.id_publicacion 
		AND p.id_tipo_publicacion=2
		AND c.id_usuario_comprador=@id_usuario
	UNION
	SELECT o.id_oferta, 'Oferta perdida'
	FROM DATA_GROUP.Oferta o
	WHERE o.id_usuario_ofertador=@id_usuario
END

IF OBJECT_ID('DATA_GROUP.getCalificacionesDelUsuario') is not null
	DROP PROCEDURE DATA_GROUP.getCalificacionesDelUsuario
	GO
CREATE PROCEDURE DATA_GROUP.getCalificacionesDelUsuario
@username nvarchar(255)
AS
BEGIN
	
	DECLARE @id_usuario numeric(18, 0)
	SET @id_usuario=(SELECT id_usuario FROM DATA_GROUP.Usuario WHERE username=@username)
	
	SELECT cal.estrellas_calificacion, 'Calificacion recibida' as Calificacion
	FROM DATA_GROUP.Compra com
	JOIN DATA_GROUP.CalificacionPublicacion cal
	ON com.id_calificacion=cal.id_calificacion 
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=com.id_publicacion
		AND p.id_usuario_publicador=@id_usuario
	UNION
	SELECT cal.estrellas_calificacion, 'Calificacion otorgada' as Calificacion
	FROM DATA_GROUP.Compra com
	JOIN DATA_GROUP.CalificacionPublicacion cal
	ON com.id_calificacion=cal.id_calificacion
		AND com.id_usuario_comprador=@id_usuario

END
GO













