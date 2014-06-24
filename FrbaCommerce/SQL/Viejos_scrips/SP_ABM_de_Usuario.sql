
--------------------------Actualizar contrasenia--------------------------


IF OBJECT_ID('DATA_GROUP.actualizarContraseniaPrimerIngreso') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.actualizarContraseniaPrimerIngreso
	GO
CREATE PROCEDURE DATA_GROUP.actualizarContraseniaPrimerIngreso
@id_usuario numeric(18,0),
@contrasenia nvarchar(255)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET contrasenia=@contrasenia
	WHERE id_usuario=@id_usuario;
END
GO


----------------------NUEVO USUARIO--------------------------

IF OBJECT_ID('DATA_GROUP.nuevoUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoUsuario
	GO
CREATE PROCEDURE DATA_GROUP.nuevoUsuario
@username nvarchar(255),
@contrasenia nvarchar(255),
@telefono numeric(18, 0),
@tipoUsuario nvarchar(3),
@id_usuario numeric(18, 0) OUTPUT
AS
BEGIN
	INSERT INTO DATA_GROUP.Usuario(username, contrasenia, telefono, intentos_login, tipo_usuario)
	VALUES(@username, @contrasenia, @telefono, 0, @tipoUsuario)
	
	SET @id_usuario = SCOPE_IDENTITY(); --Me devuelve el id de la ultima fila insertada
END
GO

---------------Setear cantidad de intentos-----------
IF OBJECT_ID('DATA_GROUP.setCantidadIntentos') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.setCantidadIntentos
	GO
CREATE PROCEDURE DATA_GROUP.setCantidadIntentos
@username nvarchar(255),
@cantidad int
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET intentos_login=@cantidad
	WHERE username=@username
END
GO

----------------------Gets de usuario--------------------------
If OBJECT_ID('DATA_GROUP.getUsuarioByUsername') is not null
	DROP PROCEDURE DATA_GROUP.getUsuarioByUsername
	GO
CREATE PROCEDURE DATA_GROUP.getUsuarioByUsername(
	@username nvarchar(255))
AS
BEGIN

	SELECT  u.id_usuario, 
			u.username, 
			u.contrasenia, 
			u.intentos_login, 
			u.habilitada, 
			u.habilitada_comprar, 
			u.telefono
	FROM DATA_GROUP.Usuario u
	WHERE u.username=@username AND u.habilitada=1

 END
GO

----------------------MODIFICAR USUARIO--------------------------

IF OBJECT_ID('DATA_GROUP.modificarUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.modificarUsuario
	GO
CREATE PROCEDURE DATA_GROUP.modificarUsuario
@id_usuario numeric(18, 0),
@username nvarchar(255),
@contrasenia nvarchar(255),
@telefono numeric(18, 0)
AS
BEGIN
	if @contrasenia!='123456'
	BEGIN
		UPDATE DATA_GROUP.Usuario
		SET contrasenia=@contrasenia, telefono=@telefono, username=@username
		WHERE id_usuario=@id_usuario
	END
	ELSE
	BEGIN
		UPDATE DATA_GROUP.Usuario
		SET telefono=@telefono, username=@username
		WHERE id_usuario=@id_usuario
	END
END
GO


----------------------EXISTE USUARIO--------------------------
IF OBJECT_ID('DATA_GROUP.existeUsuario') is not null
	DROP PROCEDURE DATA_GROUP.existeUsuario
	GO
CREATE PROCEDURE DATA_GROUP.existeUsuario
@username nvarchar(255),
@resultado bit OUTPUT
AS
BEGIN
	DECLARE @busquedaUser nvarchar(255)=null

	SELECT @busquedaUser=username
	FROM DATA_GROUP.Usuario
	WHERE username = @username;

	if @busquedaUser is not null
		SET @resultado=1
	else
		SET @resultado=0
		
	RETURN @resultado
END
GO

----------------------HABILITACION DE USUARIO--------------------------

IF OBJECT_ID('DATA_GROUP.habilitarUsuario') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.habilitarUsuario
	GO
CREATE PROCEDURE DATA_GROUP.habilitarUsuario
@id_usuario numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET habilitada=1
	WHERE id_usuario=@id_usuario
END
GO


IF OBJECT_ID('DATA_GROUP.inHabilitarUsuario') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.inHabilitarUsuario
	GO
CREATE PROCEDURE DATA_GROUP.inHabilitarUsuario
@id_usuario numeric(18, 0)
AS
BEGIN
	UPDATE DATA_GROUP.Usuario
	SET habilitada=0
	WHERE id_usuario=@id_usuario
END
GO

----------------------FILTRO USUARIO--------------------------


IF OBJECT_ID('DATA_GROUP.sp_Usuario_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_Usuario_filter
	GO
CREATE PROCEDURE DATA_GROUP.sp_Usuario_filter(
	@username nvarchar(255) = NULL,
	@telefono numeric(18, 0) = NULL
)
AS
BEGIN
	SELECT username, id_usuario, telefono, habilitada, habilitada_comprar
	FROM DATA_GROUP.Usuario
	WHERE ((@username is null) OR (username like '%' + @username + '%'))
		AND ((@telefono is null) OR (@telefono = telefono))
END
GO




----------------------PROMEDIO USUARIO--------------------------
IF OBJECT_ID('DATA_GROUP.promedioCalificaciones') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.promedioCalificaciones
	GO
CREATE PROCEDURE DATA_GROUP.promedioCalificaciones
@id_usuario numeric(18,0),
@promedio numeric(18,2) OUTPUT
AS
BEGIN

	SELECT @promedio=AVG(cal.estrellas_calificacion)
	from DATA_GROUP.Compra c
	join DATA_GROUP.Publicacion p 
		on p.id_publicacion=c.id_publicacion and p.id_usuario_publicador=@id_usuario
	join DATA_GROUP.CalificacionPublicacion cal 
		on c.id_calificacion=cal.id_calificacion;

END
GO






----------------------Datos del vendedor--------------------------
IF OBJECT_ID('DATA_GROUP.getDatosDelVendedor') is not null
	DROP PROCEDURE DATA_GROUP.getDatosDelVendedor
	GO
CREATE PROCEDURE DATA_GROUP.getDatosDelVendedor
@id_usuario numeric(18,0)
AS
BEGIN

	
	DECLARE @tipo_usuario nvarchar(3)
	 
	SELECT @tipo_usuario=tipo_usuario
	FROM DATA_GROUP.Usuario
	WHERE id_usuario=@id_usuario
	
	DECLARE @prom numeric(18,2)
	
	EXEC DATA_GROUP.promedioCalificaciones @id_usuario, @prom output
	
	if @tipo_usuario='CLI'
			SELECT  t.descripcion 'Tipo de documento', 
					c.nro_documento 'Numero de documento',
					c.nombre Nombre,
					c.apellido Apellido,
					c.dom_calle 'Calle de domicilio',
					c.piso Piso,
					c.depto Departamento,
					c.localidad Localidad,
					c.cod_postal 'Codigo postal',
					c.mail 'Mail',
					c.fecha_nacimiento 'Fecha de nacimiento',
					CASE c.sexo WHEN 0 THEN 'Masculino' WHEN 1 THEN 'Femenino' WHEN 2 THEN 'Indefinido' END as 'Sexo',
					u.telefono Telefono,
					u.username 'Nombre de usuario', 
					@prom 'Promedio de calificaciones'
			FROM DATA_GROUP.Cliente c
			INNER JOIN DATA_GROUP.Usuario u
			ON u.id_usuario = c.id_usuario AND u.tipo_usuario='CLI' AND u.id_usuario=@id_usuario
			INNER JOIN DATA_GROUP.TipoDocumento t
			on t.id_tipo_documento=c.id_tipo_documento
	if @tipo_usuario='EMP'
		SELECT  e.cuit CUIT,
			e.razon_social 'Razon social', 
			e.mail Mail, 
			e.dom_calle 'Calle de domicilio', 
			e.piso Piso, 
			e.depto Departamento, 
			e.localidad Localidad, 
			e.cod_postal 'Codigo postal', 
			e.ciudad Ciudad, 
			e.nombre_de_contacto 'Nombre de contacto', 
			e.fecha_creacion 'Fecha de creacion',
			u.telefono 'Telefono',
			u.username 'Nombre de usuario',
			@prom 'Promedio de calificaciones'
		FROM DATA_GROUP.Empresa e
		INNER JOIN DATA_GROUP.Usuario u
		ON u.id_usuario = e.id_usuario AND u.tipo_usuario='EMP' AND u.id_usuario=@id_usuario
	if @tipo_usuario='ADM'
		SELECT  u.id_usuario 'Nro de usuario', 
				u.username 'Nombre de usuario', 
				u.telefono 'Telefono',
				@prom 'Promedio de calificaciones'
		FROM DATA_GROUP.Usuario u
		WHERE u.id_usuario=@id_usuario AND u.tipo_usuario='ADM'

END
GO