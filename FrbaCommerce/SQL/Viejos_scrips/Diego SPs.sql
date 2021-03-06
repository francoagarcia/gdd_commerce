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



IF OBJECT_ID('DATA_GROUP.getPreguntas') is not null
	DROP PROCEDURE DATA_GROUP.getPreguntas
	GO
CREATE PROCEDURE DATA_GROUP.getPreguntas
@username nvarchar(255)
AS
BEGIN
	
	SELECT id_pregunta, fecha_pregunta, pregunta
	FROM DATA_GROUP.Pregunta
	WHERE respuesta=NULL AND id_usuario = @username 
	
END
GO


IF OBJECT_ID('DATA_GROUP.getRespuestas') is not null
	DROP PROCEDURE DATA_GROUP.getRespuestas
	GO
CREATE PROCEDURE DATA_GROUP.getRespuestas
@username nvarchar(255)
AS
BEGIN
	
	SELECT Pre.id_pregunta, Pu.descripcion, Pre.respuesta
	FROM DATA_GROUP.Pregunta Pre
	JOIN DATA_GROUP.Publicacion Pu ON Pre.id_publicacion = Pu.id_publicacion
	WHERE Pre.respuesta != NULL AND Pre.id_usuario = @username
	
END
GO



IF OBJECT_ID('DATA_GROUP.SP_agregrarRespuesta') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregrarRespuesta
	GO
CREATE PROCEDURE DATA_GROUP.SP_agregrarRespuesta
@respuesta nvarchar(255), 
@id numeric(18, 0)
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
	UPDATE DATA_GROUP.Pregunta 
	SET respuesta = @respuesta
	WHERE id_pregunta = @id
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


IF OBJECT_ID('DATA_GROUP.getCalificaciones') is not null
	DROP PROCEDURE DATA_GROUP.getCalificaciones
	GO
CREATE PROCEDURE DATA_GROUP.getCalificaciones
@username nvarchar(255)
AS
BEGIN
	
	SELECT Com.id_compra, Com.fecha, Pu.descripcion
	FROM DATA_GROUP.Compra Com
	JOIN DATA_GROUP.Publicacion Pu ON Com.id_publicacion = Pu.id_publicacion
	JOIN DATA_GROUP.CalificacionPublicacion Ca ON Com.id_calificacion = Ca.id_calificacion
	WHERE Ca.estrellas_calificacion = NULL AND Com.id_usuario = @username
	
END
GO


IF OBJECT_ID('DATA_GROUP.SP_agregrarCalificacion') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregrarCalificacion
	GO
CREATE PROCEDURE DATA_GROUP.SP_agregrarCalificacion
@detalle nvarchar(255),
@estrellas numeric(18, 0),
@id_calificacion numeric(18, 0) OUTPUT
AS
BEGIN	
	INSERT INTO DATA_GROUP.CalificacionPublicacion (estrellas_calificacion, detalle_calificacion)
	VALUES (@estrellas, @detalle)
	SET @id_calificacion = SCOPE_IDENTITY() 
END
GO



IF OBJECT_ID('DATA_GROUP.SP_actualizarCompra') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_actualizarCompra
	GO
CREATE PROCEDURE DATA_GROUP.SP_actualizarCompra
@id_calificacion numeric(18, 0),
@id_compra numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Compra
	SET id_calificacion = @id_calificacion
	WHERE id_compra = @id_compra
END
GO



--///////////////////// COMPRAR-OFERTAR/////////////////

IF OBJECT_ID('DATA_GROUP.getRubros') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getRubros
	GO
CREATE PROCEDURE DATA_GROUP.getRubros
AS
BEGIN
	
	SELECT id_rubro, descripcion
	FROM DATA_GROUP.Rubro
	
END
GO





IF OBJECT_ID('DATA_GROUP.filtro_ComprasOfertar') is not null
	DROP PROCEDURE DATA_GROUP.filtro_ComprasOfertar
	GO
CREATE PROCEDURE DATA_GROUP.filtro_ComprasOfertar
@descripcion nvarchar(255),
@rubro nvarchar(255)
AS
BEGIN
	
	SELECT Ti.descripcion, Pu.descripcion, Pu.permite_preguntas
	FROM DATA_GROUP.Publicacion Pu
	JOIN DATA_GROUP.Rubro Ru ON Pu.id_rubro = Ru.id_rubro
	JOIN DATA_GROUP.TipoPublicacion Ti ON Ti.id_tipo_publicacion = Pu.id_tipo_publicacion
	WHERE ( Pu.descripcion like '%'+ @descripcion +'%') AND (Ru.descripcion like '%'+ @rubro +'%') AND (Pu.habilitada = 1) AND (Pu.stock > 0) AND (Pu.fecha_vencimiento < DateAdd(DD, 0, GETDATE()))
	ORDER BY Pu.id_visibilidad
END
GO



--//hice este para testear las publicaciones, ya que no pude agregar alguna que no este vencida

IF OBJECT_ID('DATA_GROUP.filtro_ComprasFalso2') is not null
	DROP PROCEDURE DATA_GROUP.filtro_ComprasFalso2
	GO
CREATE PROCEDURE DATA_GROUP.filtro_ComprasFalso2
@descripcion nvarchar(255),
@rubro nvarchar(255)
AS
BEGIN
	
	SELECT Ti.id_tipo_publicacion, Ti.descripcion, Pu.id_publicacion ,Pu.descripcion, Pu.id_usuario_publicador, Pu.stock, Pu.precio,Pu.permite_preguntas
	FROM DATA_GROUP.Publicacion Pu
	JOIN DATA_GROUP.Rubro Ru ON Pu.id_rubro = Ru.id_rubro
	JOIN DATA_GROUP.TipoPublicacion Ti ON Ti.id_tipo_publicacion = Pu.id_tipo_publicacion
	WHERE ( Pu.descripcion like '%'+ @descripcion +'%') AND (Ru.descripcion like '%'+ @rubro +'%') 
END
GO


IF OBJECT_ID('DATA_GROUP.SP_agregrarPregunta') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregrarPregunta
	GO
CREATE PROCEDURE DATA_GROUP.SP_agregrarPregunta
@pregunta nvarchar(255),
@id_pub numeric(18, 0),
@id_usu numeric(18, 0)
AS
BEGIN	
	INSERT INTO DATA_GROUP.Pregunta(id_publicacion, id_usuario, pregunta, fecha_pregunta)
	VALUES (@id_pub, @id_usu, @pregunta, GETDATE())
	
END
GO


IF OBJECT_ID('DATA_GROUP.getCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getCliente
	GO
CREATE PROCEDURE DATA_GROUP.getCliente
@id_usuario numeric(18, 0)
AS
BEGIN
	
	SELECT username, telefono
	FROM DATA_GROUP.Usuario 
	WHERE id_usuario = @id_usuario
	
	
END
GO

/* --este ya no va
IF OBJECT_ID('DATA_GROUP.SP_agregrarCompra') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregrarCompra
	GO
CREATE PROCEDURE DATA_GROUP.SP_agregrarCompra
@id_pub numeric(18, 0),
@id_usu numeric(18, 0),
@cant numeric(18, 0)
AS
BEGIN	
	INSERT INTO DATA_GROUP.Compra(id_publicacion, id_usuario_comprador, fecha, cantidad)
	VALUES (@id_pub, @id_usu, GETDATE(), @cant)
END
GO

*/


IF OBJECT_ID('DATA_GROUP.SP_actualizarPublicacion') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_actualizarPublicacion
	GO
CREATE PROCEDURE DATA_GROUP.SP_actualizarPublicacion
@id_pub numeric(18, 0),
@stk numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Publicacion
	SET stock = @stk
	WHERE id_publicacion = @id_pub
END
GO


IF OBJECT_ID('DATA_GROUP.SP_agregrarOferta') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregrarOferta
	GO
CREATE PROCEDURE DATA_GROUP.SP_agregrarOferta
@id_pub numeric(18, 0),
@id_usu numeric(18, 0),
@mont numeric(18, 0)
AS
BEGIN	
	INSERT INTO DATA_GROUP.Oferta(id_publicacion, id_usuario_ofertador, fecha, monto)
	VALUES (@id_pub, @id_usu, GETDATE(), @mont)
END
GO



IF OBJECT_ID('DATA_GROUP.getOfertaMayor') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getOfertaMayor
	GO
CREATE PROCEDURE DATA_GROUP.getOfertaMayor
@id_pub numeric(18, 0)
AS
BEGIN
	
	SELECT top 1 monto
	FROM DATA_GROUP.Oferta
	WHERE id_publicacion = @id_pub
	ORDER BY monto DESC
	
END
GO
