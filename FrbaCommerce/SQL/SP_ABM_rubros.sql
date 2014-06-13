


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