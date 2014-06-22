





-----------------------------------------------------------------------------------------
-----------------------------------Items para bonificar----------------------------------
-----------------------------------------------------------------------------------------


IF OBJECT_ID('DATA_GROUP.getBonificados') is not null
	DROP PROCEDURE DATA_GROUP.getBonificados
	GO
CREATE PROCEDURE DATA_GROUP.getBonificados
@id_usuario numeric(18,0)
AS
BEGIN
	
	SELECT  c.id_visibilidad_fact, v.descripcion, c.id_usuario_fact, c.cantidad_fact
	FROM DATA_GROUP.CantVisibilidadesFacturadasPorUsuario c
	JOIN DATA_GROUP.VisibilidadPublicacion v ON v.id_visibilidad=c.id_visibilidad_fact
	WHERE c.id_usuario_fact=@id_usuario
	Order by c.id_visibilidad_fact ASC
	
END
GO

-----------------------------------------------------------------------------------------
-------------------------------Pendientes para facturar----------------------------------
-----------------------------------------------------------------------------------------
IF OBJECT_ID('DATA_GROUP.getPendientesDeFacturar') is not null
	DROP PROCEDURE DATA_GROUP.getPendientesDeFacturar
	GO
CREATE PROCEDURE DATA_GROUP.getPendientesDeFacturar
@id_usuario numeric(18,0)
AS
BEGIN

	CREATE TABLE temp_pendientes(
	facturar bit,
	id_publicacion numeric(18,0),
	id_compra numeric(18,0),
	tipo_item_a_facturar nvarchar(10),
	resumen nvarchar(255),
	cantidad_a_rendir numeric(18,0),
	importe_a_rendir numeric(18,2),
	id_visibilidad numeric(18,0),
	fecha_inicio datetime
	);

	INSERT INTO temp_pendientes(id_publicacion, 
								id_compra, 
								facturar, 
								tipo_item_a_facturar, 
								resumen, 
								cantidad_a_rendir, 
								importe_a_rendir,
								id_visibilidad,
								fecha_inicio)
	Select	P.id_publicacion, 
			id_compra = 0,
			[Facturar] = CONVERT(Bit, 0), 
			[Tipo] = 'PUBL',
			[Resumen] = 'Costo por publicacion(' + LTRIM(RTRIM(STR(P.id_publicacion))) + ') - Visibilidad: ' + V.descripcion,
			[Cantidad] = 1, 
			[Importe] = V.precio,
			P.id_visibilidad,
			[FechaDte] = P.fecha_inicio
	From DATA_GROUP.Publicacion P
	Inner Join DATA_GROUP.VisibilidadPublicacion V On V.id_visibilidad = P.id_visibilidad
	Where P.id_usuario_publicador = @id_usuario
	AND P.facturada = 0
	
	Union All
	
	Select	P.id_publicacion, 
			C.id_compra, 
			[Facturar] = CONVERT(Bit, 0),
			[Tipo] = 'COMP',
			[Resumen] = 'Comision por compra en publicacion(' + LTRIM(RTRIM(STR(P.id_publicacion))) +
					') - Usuario: ' + U.username, 
			[Cantidad] = C.cantidad,
			[Importe] = C.comision,
			P.id_visibilidad,
			[FechaDte] = C.fecha
	From DATA_GROUP.Compra C
	Inner Join DATA_GROUP.Publicacion P On P.id_publicacion = C.id_publicacion
	Inner Join DATA_GROUP.Usuario U On U.id_usuario = C.id_usuario_comprador
	Where P.id_usuario_publicador = @id_usuario
	AND C.facturada = 0;

	SELECT  facturar,
			id_publicacion, 
			id_compra, 
			tipo_item_a_facturar, 
			resumen, 
			cantidad_a_rendir, 
			importe_a_rendir,
			id_visibilidad,
			fecha_inicio 
	FROM temp_pendientes 
	ORDER BY fecha_inicio ASC;

	DROP TABLE temp_pendientes;
END
GO

-----------------------------------------------------------------------------------------
-----------------------------------Crear nueva factura-----------------------------------
-----------------------------------------------------------------------------------------

If OBJECT_ID('DATA_GROUP.crearFactura') is not null
	DROP PROCEDURE DATA_GROUP.crearFactura
	GO
CREATE PROCEDURE DATA_GROUP.crearFactura
@nro_factura numeric(18,0) OUTPUT, 
@id_vendedor numeric(18,0), 
@total numeric(18,2), 
@id_forma_pago numeric(18,0), 
@forma_pago_datos nvarchar(255)
AS
BEGIN

BEGIN TRY
	BEGIN TRAN

	SELECT @nro_factura = MAX(nro_factura) + 1 
	FROM DATA_GROUP.Factura
	
	INSERT INTO DATA_GROUP.Factura( nro_factura, 
									id_vendedor, 
									fecha, 
									total, 
									id_forma_pago, 
									forma_pago_datos)
	Values(@nro_factura, @id_vendedor, GETDATE(), @total, @id_forma_pago, @forma_pago_datos);
	


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


-----------------------------------------------------------------------------------------
---------------------------------Crear nuevo item factura--------------------------------
-----------------------------------------------------------------------------------------
IF OBJECT_ID('DATA_GROUP.crearItemFactura') is not null
	DROP PROCEDURE DATA_GROUP.crearItemFactura
	GO
CREATE PROCEDURE DATA_GROUP.crearItemFactura
@nro_factura numeric(18,0), 
@id_publicacion numeric(18,0),
@id_compra numeric(18,0),
@cantidad numeric(18,0), 
@monto numeric(18,2),
@resumen nvarchar(255)
AS
BEGIN

BEGIN TRY
	BEGIN TRAN
		DECLARE @pub_visibilidad_Id INT
		DECLARE @pub_usu_Id INT
		DECLARE @esCompra bit
		
		INSERT INTO DATA_GROUP.ItemFactura( nro_factura, 
											id_publicacion,
											id_compra,
											cantidad, 
											monto, 
											resumen)
		Values(@nro_factura, @id_publicacion, @id_compra, @cantidad, @monto, @resumen)
		
		if @id_compra=0 --Es publicacion
		BEGIN
			UPDATE DATA_GROUP.Publicacion
			SET facturada = 1
			WHERE id_publicacion=@id_publicacion
		END
		ELSE
		BEGIN
			UPDATE DATA_GROUP.Compra
			SET facturada = 1
			WHERE id_compra = @id_compra
		END
		
		DECLARE @id_visibilidad_fact numeric(18,0)
		DECLARE @id_usuario_fact numeric(18,0)
		
		SELECT @id_visibilidad_fact=id_visibilidad, @id_usuario_fact=id_usuario_publicador
		FROM DATA_GROUP.Publicacion 
		WHERE id_publicacion=@id_publicacion
		
		UPDATE DATA_GROUP.CantVisibilidadesFacturadasPorUsuario
		SET cantidad_fact=cantidad_fact+1
		WHERE id_visibilidad_fact=@id_visibilidad_fact AND id_usuario_fact=@id_usuario_fact
	
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






































