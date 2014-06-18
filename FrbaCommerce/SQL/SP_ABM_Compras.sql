

IF OBJECT_ID('DATA_GROUP.sp_nuevaCompra') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.sp_nuevaCompra
	GO
CREATE PROCEDURE DATA_GROUP.sp_nuevaCompra
@id_publicacion numeric(18, 0),
@id_usuario numeric(18, 0),
@cantidad numeric(18, 0),
@id_compra_nueva numeric(18, 0) OUTPUT
AS
BEGIN	

	BEGIN TRY
		BEGIN TRAN
		
			DECLARE @cantidad_nueva numeric(18, 0)
			SELECT @cantidad_nueva=stock-@cantidad
			FROM DATA_GROUP.Publicacion
			WHERE id_publicacion = @id_publicacion
			
			UPDATE DATA_GROUP.Publicacion
			SET stock = @cantidad_nueva
			WHERE id_publicacion = @id_publicacion
			
			if @cantidad_nueva = 0
			BEGIN
				UPDATE DATA_GROUP.Publicacion
				SET id_estado = (SELECT e.id_estado FROM DATA_GROUP.EstadoPublicacion e WHERE e.descripcion='Finalizada')
				WHERE id_publicacion = @id_publicacion
			END
			
			INSERT INTO DATA_GROUP.Compra(  id_publicacion, 
											id_usuario_comprador, 
											fecha, 
											cantidad,
											facturada)
			VALUES (@id_publicacion, 
					@id_usuario, 
					GETDATE(), 
					@cantidad,
					0)
					
			SET @id_compra_nueva = SCOPE_IDENTITY();

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


IF OBJECT_ID('DATA_GROUP.sp_nuevaOferta') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.sp_nuevaOferta
	GO
CREATE PROCEDURE DATA_GROUP.sp_nuevaOferta
@id_publicacion numeric(18, 0),
@id_usuario_ofertador numeric(18, 0),
@monto numeric(18, 2),
@id_oferta numeric(18, 0) OUTPUT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
		
			INSERT INTO DATA_GROUP.Oferta(id_publicacion, id_usuario_ofertador, monto, fecha)
			VALUES(@id_publicacion, @id_usuario_ofertador, @monto, GETDATE())
			
			SET @id_oferta = SCOPE_IDENTITY();
			
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