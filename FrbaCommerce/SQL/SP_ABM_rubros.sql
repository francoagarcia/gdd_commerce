

----------------------Get todos los rubros--------------------------
IF OBJECT_ID('DATA_GROUP.sp_rubro_select_all') is not null
	DROP PROCEDURE DATA_GROUP.sp_rubro_select_all
	GO
CREATE PROCEDURE DATA_GROUP.sp_rubro_select_all
AS
BEGIN
	SELECT id_rubro, descripcion
	FROM DATA_GROUP.Rubro;
END
GO


----------------------Filtro de rubros--------------------------
IF OBJECT_ID('DATA_GROUP.sp_rubro_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_rubro_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_rubro_filter(
	@descripcion nvarchar(255) = NULL
)
AS
BEGIN

	SELECT  r.id_rubro,r.descripcion
	FROM DATA_GROUP.Rubro r
	WHERE ((@descripcion IS NULL) OR ( r.descripcion like '%'+ @descripcion +'%'))
	  
END
GO