


IF OBJECT_ID('DATA_GROUP.habilitarParaComprar') is not null
	DROP PROCEDURE DATA_GROUP.habilitarParaComprar
	GO
CREATE PROCEDURE DATA_GROUP.habilitarParaComprar
@id_usuario numeric(18,0)
AS
BEGIN
	
	UPDATE DATA_GROUP.Usuario
	SET habilitada_comprar=1
	WHERE id_usuario=@id_usuario;
END
GO




IF OBJECT_ID('DATA_GROUP.nuevaCalificacion') is not null
	DROP PROCEDURE DATA_GROUP.nuevaCalificacion
	GO
CREATE PROCEDURE DATA_GROUP.nuevaCalificacion
@id_compra numeric(18,0),
@estrellas_calificacion numeric(18, 0),
@detalle_calificacion nvarchar(255),
@id_calificacion numeric(18,0) OUTPUT
AS
BEGIN

BEGIN TRY
	BEGIN TRAN
	
		SELECT @id_calificacion = MAX(id_calificacion)+1
		FROM DATA_GROUP.CalificacionPublicacion

		INSERT INTO DATA_GROUP.CalificacionPublicacion(id_calificacion, estrellas_calificacion, detalle_calificacion)
		VALUES (@id_calificacion, @estrellas_calificacion, @detalle_calificacion)
		
		UPDATE DATA_GROUP.Compra
		SET id_calificacion=@id_calificacion
		WHERE id_compra=@id_compra

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


IF OBJECT_ID('DATA_GROUP.getComprasSinCalificar') is not null
	DROP PROCEDURE DATA_GROUP.getComprasSinCalificar
	GO
CREATE PROCEDURE DATA_GROUP.getComprasSinCalificar
@id_usuario numeric(18, 0)
AS
BEGIN
	SELECT c.id_compra, c.id_publicacion, c.id_usuario_comprador, c.id_calificacion, c.fecha, c.cantidad
	FROM DATA_GROUP.Compra c
	WHERE id_calificacion is null AND id_usuario_comprador=@id_usuario
END


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------


IF OBJECT_ID('DATA_GROUP.sp_nuevaCompra') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.sp_nuevaCompra
	GO
CREATE PROCEDURE DATA_GROUP.sp_nuevaCompra
@id_publicacion numeric(18, 0),
@id_usuario numeric(18, 0),
@cantidad numeric(18, 0),
@id_compra_nueva numeric(18, 0) OUTPUT,
@puede_comprar bit OUTPUT
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
			
			DECLARE @comision numeric(18,2)
			
			SELECT @comision=p.precio*v.porcentaje*@cantidad
			FROM DATA_GROUP.Publicacion p
			JOIN DATA_GROUP.VisibilidadPublicacion v ON v.id_visibilidad=p.id_visibilidad
			
			INSERT INTO DATA_GROUP.Compra(  id_publicacion, 
											id_usuario_comprador, 
											fecha, 
											cantidad,
											comision,
											facturada)
			VALUES (@id_publicacion, 
					@id_usuario, 
					GETDATE(), 
					@cantidad,
					@comision,
					0)
					
			SET @id_compra_nueva = SCOPE_IDENTITY();
			
			EXEC DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador @id_usuario, @puede_comprar OUTPUT
			
			EXEC DATA_GROUP.ValidarComprasRendidasDelVendedor @id_publicacion

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

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------

IF OBJECT_ID('DATA_GROUP.ValidarComprasRendidasDelVendedor') is not null
	DROP PROCEDURE DATA_GROUP.ValidarComprasRendidasDelVendedor
	GO
CREATE PROCEDURE DATA_GROUP.ValidarComprasRendidasDelVendedor
@id_publicacion numeric(18, 0)
AS
BEGIN

	DECLARE @cantidad_sin_rendir int;
	DECLARE @id_vendedor numeric(18,0);
	
	SELECT @id_vendedor=p.id_usuario_publicador
	FROM DATA_GROUP.Publicacion p
	WHERE p.id_publicacion=@id_publicacion
	
	EXEC DATA_GROUP.cantidadDeComprasSinRendir @id_vendedor, @cantidad_sin_rendir OUTPUT
	
	if @cantidad_sin_rendir>10
		EXEC DATA_GROUP.inHabilitarUsuario @id_vendedor
	
END
GO


IF OBJECT_ID('DATA_GROUP.cantidadDeComprasSinRendir') is not null
	DROP PROCEDURE DATA_GROUP.cantidadDeComprasSinRendir
	GO
CREATE PROCEDURE DATA_GROUP.cantidadDeComprasSinRendir
@id_vendedor numeric(18, 0),
@cantidad_sin_rendir int OUTPUT
AS
BEGIN

	SELECT @cantidad_sin_rendir = COUNT(*)
	FROM DATA_GROUP.Compra c
	JOIN DATA_GROUP.Publicacion p ON p.id_usuario_publicador=@id_vendedor AND c.id_publicacion=p.id_publicacion
	WHERE c.facturada=0

END
GO


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------

IF OBJECT_ID('DATA_GROUP.puedeComprar') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.puedeComprar
	GO
CREATE PROCEDURE DATA_GROUP.puedeComprar
@id_usuario numeric(18,0),
@puedeComprar bit OUTPUT
AS
BEGIN
	
	SELECT @puedeComprar = habilitada_comprar
	FROM DATA_GROUP.Usuario
	WHERE id_usuario = @id_usuario
	
END
GO

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------


IF OBJECT_ID('DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador') is not null
	DROP PROCEDURE DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador
	GO
CREATE PROCEDURE DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador
@id_usuario numeric(18, 0),
@puede_comprar bit OUTPUT
AS
BEGIN

	DECLARE @cantidadComprasSinCalificar int
	EXEC DATA_GROUP.cantidadDeComprasSinCalificar @id_usuario, @cantidadComprasSinCalificar OUTPUT
	
	if @cantidadComprasSinCalificar>5
	BEGIN
		UPDATE DATA_GROUP.Usuario
		SET habilitada_comprar=0
		WHERE id_usuario=@id_usuario
		
		SET @puede_comprar=0
	END
	ELSE
		SET @puede_comprar=1
	
END
GO


IF OBJECT_ID('DATA_GROUP.cantidadDeComprasSinCalificar') is not null
	DROP PROCEDURE DATA_GROUP.cantidadDeComprasSinCalificar
	GO
CREATE PROCEDURE DATA_GROUP.cantidadDeComprasSinCalificar
@id_usuario numeric(18, 0),
@cantidad_sin_calificar int OUTPUT
AS
BEGIN

	SELECT @cantidad_sin_calificar=COUNT(*) 
	from DATA_GROUP.Compra c
	WHERE c.id_calificacion is null AND c.id_usuario_comprador=@id_usuario
	
END
GO

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------

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