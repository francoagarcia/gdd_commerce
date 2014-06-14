

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




----------------------------------------------------------------------
----------------------------------------------------------------------
----------------------------------------------------------------------

IF OBJECT_ID('DATA_GROUP.modificarPublicacion') is not null
	DROP PROCEDURE DATA_GROUP.modificarPublicacion
	GO
CREATE PROCEDURE DATA_GROUP.modificarPublicacion
@id_publicacion_modificar numeric(18, 0),
@descripcion nvarchar(255), 
@stock numeric(18,0), 
@fecha_inicio datetime, 
@fecha_vencimiento datetime, 
@precio numeric(18, 2), 
@permite_preguntas bit, 
@id_tipo_publicacion numeric(18,0), 
@id_visibilidad numeric(18, 0), 
@id_estado numeric(18,0), 
--@id_usuario_publicador numeric(18, 0), 
@id_rubro numeric(18, 0)
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRAN

			UPDATE DATA_GROUP.Publicacion
			SET descripcion = @descripcion, 
				stock = @stock, 
				fecha_inicio = @fecha_inicio, 
				fecha_vencimiento = @fecha_vencimiento, 
				precio = @precio, 
				permite_preguntas = @permite_preguntas, 
				id_tipo_publicacion = @id_tipo_publicacion, 
				id_visibilidad = @id_visibilidad, 
				id_estado = @id_estado, 
				id_rubro = @id_rubro
			WHERE id_publicacion=@id_publicacion_modificar
						
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



----------------------------------------------------------------------
----------------------------------------------------------------------
----------------------------------------------------------------------

IF OBJECT_ID('DATA_GROUP.sp_publicacion_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_publicacion_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_publicacion_filter(
	@descripcion nvarchar(255) = NULL,
	@fecha_inicio datetime = NULL,
	@fecha_vencimiento datetime = NULL,
	@id_visibilidad numeric(18,0) = NULL,
	@id_estado numeric(18,0) = NULL,
	@id_rubro numeric(18,0) = NULL,
	@id_tipo_publicacion numeric(18,0) = NULL,
	@id_usuario_publicador numeric(18,0)
)
AS
BEGIN
	SELECT  p.id_publicacion,
			p.descripcion,
			p.fecha_inicio,
			p.fecha_vencimiento,
			p.habilitada,
			p.permite_preguntas,
			p.stock,
			p.precio,
			p.id_estado,
			est.descripcion descEstado,
			p.id_rubro,
			rub.descripcion descRubro,
			p.id_tipo_publicacion,
			tipPub.descripcion descTipoPubli,
			p.id_visibilidad,
			visi.descripcion descVisi
	FROM DATA_GROUP.Publicacion p
	INNER JOIN DATA_GROUP.EstadoPublicacion est
	ON est.id_estado=p.id_estado
	INNER JOIN DATA_GROUP.Rubro rub
	ON rub.id_rubro=p.id_rubro
	INNER JOIN DATA_GROUP.TipoPublicacion tipPub
	ON tipPub.id_tipo_publicacion=p.id_tipo_publicacion
	INNER JOIN DATA_GROUP.VisibilidadPublicacion visi
	ON visi.id_visibilidad=p.id_visibilidad
	WHERE  p.id_usuario_publicador=@id_usuario_publicador
	  AND ((@id_rubro IS NULL) OR (p.id_rubro = @id_rubro ))
	  AND ((@id_estado IS NULL) OR (p.id_estado = @id_estado))
	  AND ((@id_visibilidad IS NULL) OR (p.id_visibilidad = @id_visibilidad))
	  AND ((@descripcion IS NULL) OR ( p.descripcion like '%'+ @descripcion +'%'))
	  AND ((@id_tipo_publicacion IS NULL) OR (p.id_tipo_publicacion=@id_tipo_publicacion))
	  AND ((@fecha_inicio IS NULL) OR (p.fecha_inicio = @fecha_inicio))
	  AND ((@fecha_vencimiento IS NULL) OR (p.fecha_vencimiento = @fecha_vencimiento))

END
GO



