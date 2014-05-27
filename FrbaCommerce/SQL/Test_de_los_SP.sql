
---------------------------------------------------------------------
---------------------------TESTS SP_login----------------------------
---------------------------------------------------------------------
DECLARE @id_usuario_correcto_output  NUMERIC(18,0);
DECLARE @id_usuario_incorrecto_output  NUMERIC(18,0);
DECLARE @username_correcto nvarchar(255);
DECLARE @contrasenia_correcta nvarchar(255);
DECLARE @contrasenia_incorrecta nvarchar(255);
SET @username_correcto = '58-32419179-67'
SET @contrasenia_correcta = 'w23e'
SET @contrasenia_incorrecta = 'contrasenia mala'

PRINT '---------------Test de login correcto------------------'

EXEC DATA_GROUP.SP_login @username_login=@username_correcto, @contrasenia=@contrasenia_correcta, @id_usuario=@id_usuario_correcto_output OUTPUT;

IF @id_usuario_correcto_output is null
	BEGIN
		PRINT 'El usuario o contraseña es incorrecto'
	END
ELSE
	BEGIN
		PRINT 'El usuario se logueó correctamente'
		PRINT @id_usuario_correcto_output
	END
	
PRINT '---------------Test de login incorrecto------------------'


EXEC DATA_GROUP.SP_login @username_login=@username_correcto, @contrasenia=@contrasenia_incorrecta, @id_usuario=@id_usuario_incorrecto_output OUTPUT;

IF @id_usuario_incorrecto_output is null
	BEGIN
		PRINT 'El usuario o contraseña es incorrecto'
		DECLARE @cantidad_de_intentos numeric(18, 0)
		SET @cantidad_de_intentos = (SELECT intentos_login FROM DATA_GROUP.Usuario WHERE username=@username_correcto)
		PRINT STR(@cantidad_de_intentos)+' es el numero de intentos.'
	END
ELSE
	BEGIN
		PRINT 'El usuario se logueó correctamente'
		PRINT @id_usuario_incorrecto_output
	END
	
---------------------------------------------------------------------
------------------------TESTS SP_ABMCliente--------------------------
---------------------------------------------------------------------

PRINT '---------------Test de nuevo cliente------------------'

EXEC DATA_GROUP.nuevoCliente @tipo_documento='DNI', 
							 @nro_documento=37510337, 
							 @nombre_de_usuario='francoagarcia', 
							 @contrasenia_usuario='pepinos', 
							 @telefono_usuario=null, 
							 @nombre=null, 
							 @apellido=null, 
							 @dom_calle=null, 
							 @nro_calle=null, 
							 @piso=null, 
							 @depto=null, 
							 @localidad=null, 
							 @cod_postal=null, 
							 @mail=null,
							 @fecha_nacimiento=null, 
							 @sexo=1
							 
DECLARE @nombre_usuario nvarchar(255)
SET @nombre_usuario = (SELECT username FROM DATA_GROUP.Usuario WHERE username='francoagarcia')
DECLARE @nro_documento numeric(18, 0)
SET @nro_documento = (SELECT nro_documento FROM DATA_GROUP.Cliente WHERE nro_documento=37510337)

PRINT 'Se agrego el usuario('+@nombre_usuario+') a la tabla Usuarios correctamente'
PRINT 'Se agrego el cliente con documento('+LTRIM(RTRIM(STR(@nro_documento)))+') a la tabla Clientes correctamente'

PRINT '---------------Test modificar cliente------------------'

EXEC DATA_GROUP.modificarCliente @tipo_documento='DNI', 
								 @nro_documento=37510337, 
								 @nombre_de_usuario='franco_El_mas_kpo', 
								 @contrasenia_usuario='pepinos', 
								 @telefono_usuario=null, 
								 @nombre='FRANCO', 
								 @apellido=null, 
								 @dom_calle=null, 
								 @nro_calle=null, 
								 @piso=null, 
								 @depto=null, 
								 @localidad=null, 
								 @cod_postal=null, 
								 @mail=null,
								 @sexo=1

SELECT @nombre_usuario=u.username
FROM DATA_GROUP.Cliente c
JOIN DATA_GROUP.Usuario u
ON u.id_usuario=c.id_usuario
WHERE c.id_tipo_documento=1 AND c.nro_documento=37510337

DECLARE @nombre nvarchar(255)
SET @nombre = (SELECT nombre FROM DATA_GROUP.Cliente WHERE id_tipo_documento=1 AND nro_documento=37510337)

PRINT 'Se MODIFICO el usuario('+@nombre_usuario+') a la tabla Usuarios correctamente'
PRINT 'Se MODIFICO el cliente con nuevo nombre('+@nombre+') de la tabla Clientes correctamente'

DELETE FROM DATA_GROUP.Cliente
WHERE id_tipo_documento=1 AND nro_documento=37510337

DELETE FROM DATA_GROUP.Usuario
WHERE username=@nombre_usuario	

	
	
---------------------------------------------------------------------
------------------------TESTS SP_ABMEmpresa--------------------------
---------------------------------------------------------------------	

PRINT '---------------Test de nueva Empresa------------------'

EXEC DATA_GROUP.nuevaEmpresa @cuit='03-99999999-99', 
							 @razon_social='trucho',
							 @nombre_de_usuario='papanatas',
							 @contrasenia_usuario='pepinos',
							 @telefono_usuario=null,
							 @mail=null,
							 @dom_calle=null,
							 @piso=null,
							 @depto=null,
							 @localidad=null,
							 @nro_calle=null,
							 @cod_postal=null,
							 @ciudad=null,
							 @nombre_de_contacto=null,
							 @fecha_creacion=null
							  
DECLARE @razon_social_print nvarchar(255)
SET @razon_social_print=(SELECT razon_social FROM DATA_GROUP.Empresa WHERE cuit='03-99999999-99' AND razon_social='trucho')

DECLARE @nombre_usuario nvarchar(255)
SET @nombre_usuario = (SELECT username FROM DATA_GROUP.Usuario WHERE username='papanatas')

PRINT 'Ingresé un nuevo registro en DATA_GROUP.Usuario(username: '+ @nombre_usuario+')'
PRINT 'Ingresé un nuevo registro en DATA_GROUP.Empresa(razon_social: '+@razon_social_print+')'


PRINT '---------------Test de modificar Empresa------------------'

EXEC DATA_GROUP.modificarEmpresa @cuit='03-99999999-99', 
								 @razon_social='trucho',
								 @nombre_de_usuario='poponotos',
								 @contrasenia_usuario='pepinos',
								 @telefono_usuario=null,
								 @mail='algo@gmail.com',
								 @dom_calle=null,
								 @piso=null,
								 @depto=null,
								 @localidad=null,
								 @nro_calle=null,
								 @cod_postal=null,
								 @ciudad=null,
								 @nombre_de_contacto=null
								 
DECLARE @mail_nuevo nvarchar(255)
SET @mail_nuevo = (SELECT mail FROM DATA_GROUP.Empresa WHERE cuit='03-99999999-99')

DECLARE @username_nuevo nvarchar(255)
SELECT @username_nuevo=u.username
FROM DATA_GROUP.Empresa e
JOIN DATA_GROUP.Usuario u 
ON u.id_usuario=e.id_usuario
WHERE e.cuit='03-99999999-99'

PRINT 'MODIFIQUE la tabla DATA_GROUP.Empresa en el campo mail('+@mail_nuevo+')'
PRINT 'MODIFIQUE la tabla DATA_GROUP.Usuario en el campo username('+@username_nuevo+')'

PRINT '..........Estoy por borrar'
DELETE FROM DATA_GROUP.Empresa
WHERE cuit='03-99999999-99'

DELETE FROM DATA_GROUP.Usuario
WHERE username=@username_nuevo
	
	
	
	
	
	
	
	
	
	
	
	
	
	