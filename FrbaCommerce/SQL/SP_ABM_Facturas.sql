

IF OBJECT_ID('DATA_GROUP.getPendientesDeFacturar') is not null
	DROP PROCEDURE DATA_GROUP.getPendientesDeFacturar
	GO
CREATE PROCEDURE DATA_GROUP.getPendientesDeFacturar
@id_usuario numeric(18,0)
AS
BEGIN

	CREATE TABLE temp_pendientes(
	id_publicacion numeric(18,0),
	id_compra numeric(18,0),
	facturar bit,
	tipo_item_a_facturar nvarchar(1),
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
			[Tipo] = 'P',
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
			[Tipo] = 'C',
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

	SELECT id_publicacion, 
			id_compra, 
			facturar, 
			tipo_item_a_facturar, 
			resumen, 
			cantidad_a_rendir, 
			importe_a_rendir,
			id_visibilidad,
			fecha_inicio 
	FROM temp_pendientes 
	ORDER BY fecha_inicio DESC;


	DROP TABLE temp_pendientes;

END
GO


