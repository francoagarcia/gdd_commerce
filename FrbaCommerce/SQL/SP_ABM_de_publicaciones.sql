

IF OBJECT_ID('DATA_GROUP.nuevaPublicacion') is not null
	DROP PROCEDURE DATA_GROUP.nuevaPublicacion
	GO
CREATE PROCEDURE DATA_GROUP.nuevaPublicacion
@id_publicacion_nueva numeric(18, 0) OUTPUT,
@descripcion nvarchar(255), 
@stock numeric(18,0), 
@fecha_inicio datetime, 
@fecha_vencimiento datetime, 
@precio numeric(18, 2), 
@permite_preguntas bit, 
@id_tipo_publicacion numeric(18,0), 
@id_visibilidad numeric(18, 0), 
@id_estado numeric(18,0), 
@id_usuario_publicador numeric(18, 0), 
@id_rubro numeric(18, 0), 
@habilitada bit
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN
		
			DECLARE @max_id numeric(18,0)
			SELECT @max_id = MAX(id_publicacion)+1
			FROM DATA_GROUP.Publicacion;
			
			INSERT INTO DATA_GROUP.Publicacion( id_publicacion,
												descripcion, 
												stock, 
												fecha_inicio, 
												fecha_vencimiento, 
												precio, 
												permite_preguntas, 
												id_tipo_publicacion, 
												id_visibilidad, 
												id_estado, 
												id_usuario_publicador, 
												id_rubro, habilitada)
			VALUES( @max_id,
					@descripcion, 
					@stock, 
					@fecha_inicio, 
					@fecha_vencimiento, 
					@precio, 
					@permite_preguntas, 
					@id_tipo_publicacion, 
					@id_visibilidad, 
					@id_estado, 
					@id_usuario_publicador, 
					@id_rubro, 
					@habilitada)
					
			SET @id_publicacion_nueva = @max_id
			RETURN @id_publicacion_nueva
						
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

