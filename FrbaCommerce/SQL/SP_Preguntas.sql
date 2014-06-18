


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