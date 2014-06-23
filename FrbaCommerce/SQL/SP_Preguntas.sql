




IF OBJECT_ID('DATA_GROUP.nuevaRespuesta') is not null
	DROP PROCEDURE DATA_GROUP.nuevaRespuesta
	GO
CREATE PROCEDURE DATA_GROUP.nuevaRespuesta
@id_pregunta numeric(18,0),
@respuesta nvarchar(400)
AS
BEGIN
	
	UPDATE DATA_GROUP.Pregunta
	SET respuesta=@respuesta, fecha_respuesta=GETDATE()
	WHERE id_pregunta=@id_pregunta
END
GO


-----------------------------------------------------------------------
-----------------------------------------------------------------------
-----------------------------------------------------------------------


IF OBJECT_ID('DATA_GROUP.getPreguntasSinResponder') is not null
	DROP PROCEDURE DATA_GROUP.getPreguntasSinResponder
	GO
CREATE PROCEDURE DATA_GROUP.getPreguntasSinResponder
@id_vendedor numeric(18,0)
AS
BEGIN

	SELECT  preg.id_pregunta, 
			preg.id_publicacion, 
			preg.id_usuario,
			u.username,
			preg.pregunta, 
			preg.fecha_pregunta, 
			preg.respuesta,
			preg.fecha_respuesta 
	FROM DATA_GROUP.Pregunta preg
	JOIN DATA_GROUP.Publicacion pub on pub.id_publicacion=preg.id_publicacion
	JOIN DATA_GROUP.Usuario u on u.id_usuario=preg.id_usuario
	WHERE pub.id_usuario_publicador=@id_vendedor AND respuesta is null

END
GO


IF OBJECT_ID('DATA_GROUP.getPreguntasYaRespondidas') is not null
	DROP PROCEDURE DATA_GROUP.getPreguntasYaRespondidas
	GO
CREATE PROCEDURE DATA_GROUP.getPreguntasYaRespondidas
@id_vendedor numeric(18,0)
AS
BEGIN

	SELECT  preg.id_pregunta, 
			preg.id_publicacion, 
			preg.id_usuario,
			u.username, 
			preg.pregunta, 
			preg.fecha_pregunta, 
			preg.respuesta,
			preg.fecha_respuesta 
	FROM DATA_GROUP.Pregunta preg
	JOIN DATA_GROUP.Publicacion pub on pub.id_publicacion=preg.id_publicacion
	JOIN DATA_GROUP.Usuario u on u.id_usuario=preg.id_usuario
	WHERE pub.id_usuario_publicador=@id_vendedor AND respuesta is not null

END
GO


-----------------------------------------------------------------------
-----------------------------------------------------------------------
-----------------------------------------------------------------------
-----------------------------------------------------------------------



IF OBJECT_ID('DATA_GROUP.getRespuestasDeUnaPublicacion') is not null
	DROP PROCEDURE DATA_GROUP.getRespuestasDeUnaPublicacion
	GO
CREATE PROCEDURE DATA_GROUP.getRespuestasDeUnaPublicacion
@id_publicacion numeric(18,0)
AS
BEGIN
	
	SELECT  p.id_pregunta, 
			p.id_publicacion,
			p.id_usuario, 
			u.username,
			u.habilitada,
			p.pregunta, 
			p.fecha_pregunta, 
			p.respuesta, 
			p.fecha_respuesta
	FROM DATA_GROUP.Pregunta p
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario = p.id_usuario
	WHERE p.id_publicacion=@id_publicacion
	
END
GO



IF OBJECT_ID('DATA_GROUP.nuevaPregunta') is not null
	DROP PROCEDURE DATA_GROUP.nuevaPregunta
	GO
CREATE PROCEDURE DATA_GROUP.nuevaPregunta
@id_pregunta numeric(18,0) OUTPUT, 
@id_publicacion numeric(18,0), 
@id_usuario numeric(18, 0),
@pregunta nvarchar(255),
@fecha_pregunta datetime
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
			INSERT INTO DATA_GROUP.Pregunta(id_publicacion, 
											id_usuario, 
											pregunta, 
											fecha_pregunta)
			VALUES (@id_publicacion, 
					@id_usuario, 
					@pregunta, 
					@fecha_pregunta)
					
			SET @id_pregunta = SCOPE_IDENTITY();
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