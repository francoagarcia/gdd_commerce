USE [GD1C2014]
GO

IF OBJECT_ID('DATA_GROUP.sp_rubro_select_all') is not null
	DROP PROCEDURE DATA_GROUP.sp_rubro_select_all
	GO
IF OBJECT_ID('DATA_GROUP.sp_rubro_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_rubro_filter
	GO
IF OBJECT_ID('DATA_GROUP.nuevaVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.nuevaVisibilidad
	GO
IF OBJECT_ID('DATA_GROUP.modificarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.modificarVisibilidad
	GO
IF OBJECT_ID('DATA_GROUP.inhabilitarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.inhabilitarVisibilidad
	GO
IF OBJECT_ID('DATA_GROUP.habilitarVisibilidad') is not null
	DROP PROCEDURE DATA_GROUP.habilitarVisibilidad
	GO
IF OBJECT_ID('DATA_GROUP.sp_Visibilidad_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_Visibilidad_filter
	GO
IF OBJECT_ID('DATA_GROUP.sp_Visibilidad_select_all') is not null
	DROP PROCEDURE DATA_GROUP.sp_Visibilidad_select_all
	GO
IF OBJECT_ID('DATA_GROUP.nuevoCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoCliente
	GO
IF OBJECT_ID('DATA_GROUP.modificarCliente') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.modificarCliente
	GO
IF OBJECT_ID('DATA_GROUP.sp_cliente_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_cliente_filter
	GO
IF OBJECT_ID('DATA_GROUP.nuevaEmpresa') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevaEmpresa
	GO
IF OBJECT_ID('DATA_GROUP.modificarEmpresa') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.modificarEmpresa
	GO
IF OBJECT_ID('DATA_GROUP.sp_empresa_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_empresa_filter
	GO
IF OBJECT_ID('DATA_GROUP.asociarRolAUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.asociarRolAUsuario
	GO
IF OBJECT_ID('DATA_GROUP.getIdRolPorNombre') IS NOT NULL
	DROP FUNCTION DATA_GROUP.getIdRolPorNombre
	GO
IF OBJECT_ID('DATA_GROUP.getTodosLosRoles') is not null
	DROP PROCEDURE DATA_GROUP.getTodosLosRoles
	GO
IF OBJECT_ID('DATA_GROUP.getRolesDeUsuario') is not null
	DROP PROCEDURE DATA_GROUP.getRolesDeUsuario
	GO
IF OBJECT_ID('DATA_GROUP.sp_rol_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_rol_filter
	GO
IF OBJECT_ID('DATA_GROUP.modificarRol') is not null
	DROP PROCEDURE DATA_GROUP.modificarRol
	GO
IF OBJECT_ID('DATA_GROUP.modificarFuncionalidadDeUnRol') is not null
	DROP PROCEDURE DATA_GROUP.modificarFuncionalidadDeUnRol
	GO
IF OBJECT_ID('DATA_GROUP.SP_deshabilitarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_deshabilitarRol
	GO
IF OBJECT_ID('DATA_GROUP.SP_habilitarRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_habilitarRol
	GO
IF OBJECT_ID('DATA_GROUP.SP_agregarFuncionalidadXRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_agregarFuncionalidadXRol
	GO
IF OBJECT_ID('DATA_GROUP.SP_crearRol') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.SP_crearRol
	GO
IF OBJECT_ID('DATA_GROUP.getTodosAnios') is not null
	DROP PROCEDURE DATA_GROUP.getTodosAnios
	GO
IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMasProductosNoVendidos
	GO
IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMayorFacturacion') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMayorFacturacion
	GO
IF OBJECT_ID('DATA_GROUP.getTop5VendedoresConMayorCalificaciones') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5VendedoresConMayorCalificaciones
	GO
IF OBJECT_ID('DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.getTop5ClientesConMasPublicacionesSinCalificar
	GO
IF OBJECT_ID('DATA_GROUP.getTodasComprasRealizadas') is not null
	DROP PROCEDURE DATA_GROUP.getTodasComprasRealizadas
	GO
IF OBJECT_ID('DATA_GROUP.getTodasLasOfertasRealizadas') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasOfertasRealizadas
	GO
IF OBJECT_ID('DATA_GROUP.getCalificacionesDelUsuario') is not null
	DROP PROCEDURE DATA_GROUP.getCalificacionesDelUsuario
	GO
IF OBJECT_ID('DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador') is not null
	DROP PROCEDURE DATA_GROUP.ValidarCalificacionesOtorgadasDelComprador
	GO
IF OBJECT_ID('DATA_GROUP.cantidadDeComprasSinCalificar') is not null
	DROP PROCEDURE DATA_GROUP.cantidadDeComprasSinCalificar
	GO
IF OBJECT_ID('DATA_GROUP.sp_nuevaOferta') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.sp_nuevaOferta
	GO
IF OBJECT_ID('DATA_GROUP.habilitarParaComprar') is not null
	DROP PROCEDURE DATA_GROUP.habilitarParaComprar
	GO
IF OBJECT_ID('DATA_GROUP.nuevaCalificacion') is not null
	DROP PROCEDURE DATA_GROUP.nuevaCalificacion
	GO
IF OBJECT_ID('DATA_GROUP.getComprasSinCalificar') is not null
	DROP PROCEDURE DATA_GROUP.getComprasSinCalificar
	GO
IF OBJECT_ID('DATA_GROUP.sp_nuevaCompra') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.sp_nuevaCompra
	GO

IF OBJECT_ID('DATA_GROUP.ValidarComprasRendidasDelVendedor') is not null
	DROP PROCEDURE DATA_GROUP.ValidarComprasRendidasDelVendedor
	GO
IF OBJECT_ID('DATA_GROUP.cantidadDeComprasSinRendir') is not null
	DROP PROCEDURE DATA_GROUP.cantidadDeComprasSinRendir
	GO
IF OBJECT_ID('DATA_GROUP.puedeComprar') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.puedeComprar
	GO
IF OBJECT_ID('DATA_GROUP.actualizarContraseniaPrimerIngreso') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.actualizarContraseniaPrimerIngreso
	GO
IF OBJECT_ID('DATA_GROUP.nuevoUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.nuevoUsuario
	GO
IF OBJECT_ID('DATA_GROUP.setCantidadIntentos') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.setCantidadIntentos
	GO
If OBJECT_ID('DATA_GROUP.getUsuarioByUsername') is not null
	DROP PROCEDURE DATA_GROUP.getUsuarioByUsername
	GO
IF OBJECT_ID('DATA_GROUP.modificarUsuario') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.modificarUsuario
	GO
IF OBJECT_ID('DATA_GROUP.existeUsuario') is not null
	DROP PROCEDURE DATA_GROUP.existeUsuario
	GO
IF OBJECT_ID('DATA_GROUP.habilitarUsuario') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.habilitarUsuario
	GO
IF OBJECT_ID('DATA_GROUP.inHabilitarUsuario') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.inHabilitarUsuario
	GO
IF OBJECT_ID('DATA_GROUP.sp_Usuario_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_Usuario_filter
	GO
IF OBJECT_ID('DATA_GROUP.promedioCalificaciones') IS NOT NULL
	DROP PROCEDURE DATA_GROUP.promedioCalificaciones
	GO
IF OBJECT_ID('DATA_GROUP.getDatosDelVendedor') is not null
	DROP PROCEDURE DATA_GROUP.getDatosDelVendedor
	GO
IF OBJECT_ID('DATA_GROUP.sp_EstadoPublicacion_select_all') is not null
	DROP PROCEDURE DATA_GROUP.sp_EstadoPublicacion_select_all
	GO
IF OBJECT_ID('DATA_GROUP.getBonificados') is not null
	DROP PROCEDURE DATA_GROUP.getBonificados
	GO
IF OBJECT_ID('DATA_GROUP.getPendientesDeFacturar') is not null
	DROP PROCEDURE DATA_GROUP.getPendientesDeFacturar
	GO
If OBJECT_ID('DATA_GROUP.crearFactura') is not null
	DROP PROCEDURE DATA_GROUP.crearFactura
	GO
IF OBJECT_ID('DATA_GROUP.crearItemFactura') is not null
	DROP PROCEDURE DATA_GROUP.crearItemFactura
	GO
IF OBJECT_ID('DATA_GROUP.getTodasLasFuncionalidadesHabilitadas') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasFuncionalidadesHabilitadas
	GO
IF OBJECT_ID('DATA_GROUP.getTodasLasFuncionalidades') is not null
	DROP PROCEDURE DATA_GROUP.getTodasLasFuncionalidades
	GO
IF OBJECT_ID('DATA_GROUP.getFuncionalidadDeUnRol') is not null
	DROP PROCEDURE DATA_GROUP.getFuncionalidadDeUnRol
	GO
IF OBJECT_ID('DATA_GROUP.getFuncDeUnRolHabilYNoHabilitadas') is not null
	DROP PROCEDURE DATA_GROUP.getFuncDeUnRolHabilYNoHabilitadas
	GO
IF OBJECT_ID('DATA_GROUP.realizar_identificacion') is not null
	DROP PROCEDURE DATA_GROUP.realizar_identificacion;
	GO
IF OBJECT_ID('DATA_GROUP.nuevaRespuesta') is not null
	DROP PROCEDURE DATA_GROUP.nuevaRespuesta
	GO
IF OBJECT_ID('DATA_GROUP.getPreguntasSinResponder') is not null
	DROP PROCEDURE DATA_GROUP.getPreguntasSinResponder
	GO
IF OBJECT_ID('DATA_GROUP.getPreguntasYaRespondidas') is not null
	DROP PROCEDURE DATA_GROUP.getPreguntasYaRespondidas
	GO
IF OBJECT_ID('DATA_GROUP.getRespuestasDeUnaPublicacion') is not null
	DROP PROCEDURE DATA_GROUP.getRespuestasDeUnaPublicacion
	GO
IF OBJECT_ID('DATA_GROUP.nuevaPregunta') is not null
	DROP PROCEDURE DATA_GROUP.nuevaPregunta
	GO
IF OBJECT_ID('DATA_GROUP.nuevaPublicacion') is not null
	DROP PROCEDURE DATA_GROUP.nuevaPublicacion
	GO
IF OBJECT_ID('DATA_GROUP.modificarPublicacion') is not null
	DROP PROCEDURE DATA_GROUP.modificarPublicacion
	GO
IF OBJECT_ID('DATA_GROUP.sp_publicacion_filter') is not null
	DROP PROCEDURE DATA_GROUP.sp_publicacion_filter
	GO

IF OBJECT_ID('DATA_GROUP.FuncionalidadXRol', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.FuncionalidadXRol
	GO
IF OBJECT_ID('DATA_GROUP.UsuarioXRol', 'U') IS NOT NULL	
	DROP TABLE DATA_GROUP.UsuarioXRol;
	GO
IF OBJECT_ID('DATA_GROUP.Compra', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Compra;
	GO
IF OBJECT_ID('DATA_GROUP.Oferta', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Oferta;
	GO
IF OBJECT_ID('DATA_GROUP.CalificacionPublicacion', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.CalificacionPublicacion;
	GO
IF OBJECT_ID('DATA_GROUP.ItemFactura', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.ItemFactura;
	GO
IF OBJECT_ID('DATA_GROUP.Factura', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Factura;
	GO
IF OBJECT_ID('DATA_GROUP.Pregunta', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Pregunta;
	GO
IF OBJECT_ID('DATA_GROUP.Publicacion', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Publicacion;
	GO
IF OBJECT_ID('DATA_GROUP.Rol', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Rol;
	GO
IF OBJECT_ID('DATA_GROUP.Funcionalidad', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Funcionalidad;
	GO
IF OBJECT_ID('DATA_GROUP.CantVisibilidadesFacturadasPorUsuario', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.CantVisibilidadesFacturadasPorUsuario;
	GO
IF OBJECT_ID('DATA_GROUP.Administrador', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Administrador;
	GO
IF OBJECT_ID('DATA_GROUP.Cliente', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Cliente;
	GO
IF OBJECT_ID('DATA_GROUP.Empresa', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Empresa;
	GO
IF OBJECT_ID('DATA_GROUP.Usuario', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Usuario;
	GO
IF OBJECT_ID('DATA_GROUP.TipoDocumento', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.TipoDocumento;
	GO
IF OBJECT_ID('DATA_GROUP.Rubro', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.Rubro;
	GO
IF OBJECT_ID('DATA_GROUP.TipoPublicacion', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.TipoPublicacion;
	GO
IF OBJECT_ID('DATA_GROUP.VisibilidadPublicacion', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.VisibilidadPublicacion;
	GO
IF OBJECT_ID('DATA_GROUP.EstadoPublicacion', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.EstadoPublicacion;
	GO
IF OBJECT_ID('DATA_GROUP.FormaDePago', 'U') IS NOT NULL 
	DROP TABLE DATA_GROUP.FormaDePago;
	GO
IF OBJECT_ID('DATA_GROUP') IS NOT NULL 
	DROP SCHEMA DATA_GROUP
	GO



