


IF OBJECT_ID('DATA_GROUP.getTodosAnios') is not null
	DROP PROCEDURE DATA_GROUP.getTodosAnios
	GO
CREATE PROCEDURE DATA_GROUP.getTodosAnios
AS
BEGIN
	SELECT DISTINCT YEAR(fecha) anio
	FROM DATA_GROUP.Compra
END


IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos
	GO
CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos
@anio int,
@trimestre int,
@mes int,
@visibilidad_desc nvarchar(255)
AS
BEGIN

	DECLARE @visibilidad_id numeric(18, 0)
	SET @visibilidad_id = (SELECT id_visibilidad FROM DATA_GROUP.VisibilidadPublicacion WHERE descripcion=@visibilidad_desc)

	SELECT top 5 p.id_usuario_publicador, SUM(p.stock) CantidadNoVendidaTotal
	FROM DATA_GROUP.Publicacion p
	WHERE YEAR(p.fecha_inicio)=@anio
		AND p.id_visibilidad=@visibilidad_id
		AND MONTH(p.fecha_inicio)=@mes
		AND MONTH(p.fecha_inicio)>(@trimestre-1)*3 AND MONTH(p.fecha_inicio)<=@trimestre*3	
	GROUP BY p.id_usuario_publicador, p.fecha_inicio, p.id_visibilidad
	ORDER BY CantidadNoVendidaTotal DESC, p.fecha_inicio ASC, p.id_visibilidad ASC
	
END
GO


IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMayorFacturacion') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMayorFacturacion
	GO
CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMayorFacturacion
@anio int, 
@trimestre int,
@mes int = NULL,
@visibilidad_desc nvarchar(255) = NULL
AS
BEGIN
	SELECT top 5 f.id_vendedor, SUM(f.total) Facturacion
	FROM DATA_GROUP.Factura f
	JOIN DATA_GROUP.Usuario u
	ON u.id_usuario=f.id_vendedor 
		AND YEAR(f.fecha)=@anio 
		AND MONTH(f.fecha)>(@trimestre-1)*3 AND MONTH(f.fecha)<=@trimestre*3 
	GROUP BY f.id_vendedor
	ORDER BY Facturacion DESC
END
GO


IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMayorCalificaciones') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMayorCalificaciones
	GO
CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMayorCalificaciones
@anio int, 
@trimestre int,
@mes int = NULL,
@visibilidad_desc nvarchar(255) = NULL
AS
BEGIN
	SELECT TOP 5 p.id_usuario_publicador Vendedor, AVG(cal.estrellas_calificacion) Calificaciones
	FROM DATA_GROUP.CalificacionPublicacion cal
	JOIN DATA_GROUP.Compra comp
	ON comp.id_calificacion=cal.id_calificacion
	JOIN DATA_GROUP.Publicacion p
	ON p.id_publicacion=comp.id_publicacion
	WHERE YEAR(comp.fecha)=@anio 
		AND MONTH(comp.fecha)>(@trimestre-1)*3 AND MONTH(comp.fecha)<=@trimestre*3 
	GROUP BY p.id_usuario_publicador
	ORDER BY Calificaciones DESC
END
GO


IF OBJECT_ID('DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar
	GO
CREATE PROCEDURE DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar
@anio int,
@trimestre int,
@mes int = NULL,
@visibilidad_desc nvarchar(255) = NULL
AS
BEGIN
	SELECT TOP 5 com.id_usuario_comprador, COUNT(*) CantidadPublicaciones
	FROM DATA_GROUP.Compra com
	JOIN DATA_GROUP.Cliente cli
	ON com.id_usuario_comprador=cli.id_usuario 
		AND com.id_calificacion is null
		AND YEAR(com.fecha)=@anio 
		AND MONTH(com.fecha)>(@trimestre-1)*3 AND MONTH(com.fecha)<=@trimestre*3 
	GROUP BY com.id_usuario_comprador
	ORDER BY CantidadPublicaciones 
END
GO


ALTERNATIVA

IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos
	GO
CREATE PROCEDURE DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos
@anio int,
@trimestre int,
@mes int,
@visibilidad_desc nvarchar(255)
AS
BEGIN

	SELECT top 5 p.id_usuario_publicador, SUM(p.stock) CantidadNoVendidaTotal
	FROM DATA_GROUP.Publicacion p
	JOIN DATA_GROUP.VisibilidadPublicacion v ON p.id_visibilidad=v.id_visibilidad
	WHERE YEAR(p.fecha_inicio)=@anio
		AND v.descripcion=@visibilidad_desc
		AND MONTH(p.fecha_inicio)=@mes
		AND MONTH(p.fecha_inicio)>(@trimestre-1)*3 AND MONTH(p.fecha_inicio)<=@trimestre*3	
	GROUP BY p.id_usuario_publicador, p.fecha_inicio, p.id_visibilidad
	ORDER BY CantidadNoVendidaTotal DESC, p.fecha_inicio ASC, p.id_visibilidad ASC
	
END
GO




